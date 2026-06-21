using System;
using System.Drawing;
using System.Windows.Forms;
using Winform.BLL.Models;
using Winform.BLL.Services;

namespace Winform.GUI;

public partial class MainForm : Form
{
    private readonly AgriBusinessService _businessService;
    private bool _isAutoMode = true;

    public MainForm()
    {
        InitializeComponent();
        _businessService = new AgriBusinessService();
        
        // Đăng ký các sự kiện từ BLL
        _businessService.SensorDataProcessed += OnSensorDataProcessed;
        _businessService.LogReceived += OnLogReceived;
        _businessService.ConnectionWarning += OnConnectionWarning;
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        LoadAvailablePorts();
        cboBaudRate.SelectedIndex = 1; // Mặc định chọn 9600
        
        // Khởi tạo Tag cho các nút bấm thiết bị
        btnPump.Tag = "OFF";
        btnFan.Tag = "OFF";
        btnLight.Tag = "OFF";
        
        // Khóa các ô điều khiển khi chưa kết nối
        SetControlStatus(false);
    }

    private void SetControlStatus(bool enabled)
    {
        grpControl.Enabled = enabled && !_isAutoMode; // Chỉ mở điều khiển thiết bị khi ở chế độ thủ công
        grpThresholds.Enabled = enabled;
        txtSend.Enabled = enabled;
        btnSend.Enabled = enabled;
    }

    private void LoadAvailablePorts()
    {
        cboPorts.Items.Clear();
        string[] ports = _businessService.GetPorts();
        cboPorts.Items.AddRange(ports);
        
        if (cboPorts.Items.Count > 0)
        {
            cboPorts.SelectedIndex = 0;
        }
        else
        {
            lblStatus.Text = "Không tìm thấy cổng COM ảo nào. Hãy tạo cổng bằng VSPE!";
        }
    }

    private void btnConnect_Click(object sender, EventArgs e)
    {
        if (!_businessService.IsConnected)
        {
            string? portName = cboPorts.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(portName))
            {
                MessageBox.Show("Vui lòng chọn cổng COM trước khi kết nối!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int baudRate = Convert.ToInt32(cboBaudRate.SelectedItem);
                
                string firebaseDbUrl = txtFirebaseUrl.Text.Trim();
                if (!string.IsNullOrEmpty(firebaseDbUrl) && !firebaseDbUrl.StartsWith("https://YOUR-PROJECT-ID", StringComparison.OrdinalIgnoreCase))
                {
                    _businessService.InitializeFirebase(firebaseDbUrl);
                }
                else
                {
                    AppendLog("[HỆ THỐNG] Bỏ qua cấu hình Firebase do chưa nhập URL chính xác.");
                }

                _businessService.Connect(portName, baudRate);

                btnConnect.Text = "Ngắt kết nối";
                btnConnect.BackColor = Color.Crimson;
                cboPorts.Enabled = false;
                cboBaudRate.Enabled = false;
                txtFirebaseUrl.Enabled = false;
                lblStatus.Text = $"Đang kết nối qua {portName} ({baudRate} bps)...";
                
                SetControlStatus(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối cổng COM: {ex.Message}", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        else
        {
            try
            {
                _businessService.Disconnect();

                btnConnect.Text = "Kết nối";
                btnConnect.BackColor = Color.DodgerBlue;
                cboPorts.Enabled = true;
                cboBaudRate.Enabled = true;
                txtFirebaseUrl.Enabled = true;
                lblStatus.Text = "Chưa kết nối";
                ResetDisplay();
                
                SetControlStatus(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đóng cổng COM: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void ResetDisplay()
    {
        lblTempVal.Text = "--.- °C";
        lblHumVal.Text = "--.- %";
        lblSoilVal.Text = "-- %";
        lblLightVal.Text = "-- %";
        
        UpdateDeviceUI("0", btnPump);
        UpdateDeviceUI("0", btnFan);
        UpdateDeviceUI("0", btnLight);
    }

    private void OnSensorDataProcessed(SensorData data)
    {
        if (this.InvokeRequired)
        {
            this.BeginInvoke(new Action(() => OnSensorDataProcessed(data)));
            return;
        }

        // Cập nhật các thông số đo
        lblTempVal.Text = $"{data.Temperature:F1} °C";
        lblHumVal.Text = $"{data.Humidity:F1} %";
        lblSoilVal.Text = $"{data.SoilMoisture} %";
        lblLightVal.Text = $"{data.LightLevel} %";

        // Cập nhật trạng thái các rơ le/thiết bị
        if (data.DeviceState != null)
        {
            UpdateDeviceUI(data.DeviceState.IsPumpOn ? "1" : "0", btnPump);
            UpdateDeviceUI(data.DeviceState.IsFanOn ? "1" : "0", btnFan);
            UpdateDeviceUI(data.DeviceState.IsLightOn ? "1" : "0", btnLight);
        }

        // Đồng bộ hóa Chế độ hoạt động (Tự động / Thủ công)
        _isAutoMode = data.IsAutoMode;
        if (_isAutoMode)
        {
            lblModeStatus.Text = "TỰ ĐỘNG (AUTO)";
            lblModeStatus.BackColor = Color.LightGreen;
            lblModeStatus.ForeColor = Color.DarkGreen;
            btnToggleMode.Text = "Chuyển sang THỦ CÔNG";
            grpControl.Enabled = false; // Ở chế độ Tự động, không cho phép bấm nút điều khiển thiết bị
        }
        else
        {
            lblModeStatus.Text = "THỦ CÔNG (MANUAL)";
            lblModeStatus.BackColor = Color.LightCoral;
            lblModeStatus.ForeColor = Color.DarkRed;
            btnToggleMode.Text = "Chuyển sang TỰ ĐỘNG";
            grpControl.Enabled = true; // Cho phép bấm nút ở chế độ Thủ công
        }

        // Cập nhật các ngưỡng hiển thị nếu người dùng không đang tập trung chỉnh sửa
        if (!numTempThresh.Focused) numTempThresh.Value = Math.Clamp(data.TempThreshold, numTempThresh.Minimum, numTempThresh.Maximum);
        if (!numSoilThresh.Focused) numSoilThresh.Value = Math.Clamp(data.SoilThreshold, numSoilThresh.Minimum, numSoilThresh.Maximum);
        if (!numLightThresh.Focused) numLightThresh.Value = Math.Clamp(data.LightThreshold, numLightThresh.Minimum, numLightThresh.Maximum);
    }

    private void OnLogReceived(string message)
    {
        if (this.InvokeRequired)
        {
            this.BeginInvoke(new Action(() => OnLogReceived(message)));
            return;
        }
        AppendLog(message);
    }

    private void OnConnectionWarning(string warningMessage)
    {
        if (this.InvokeRequired)
        {
            this.BeginInvoke(new Action(() => OnConnectionWarning(warningMessage)));
            return;
        }
        AppendLog(warningMessage);
    }

    private void UpdateDeviceUI(string state, Button btn)
    {
        bool isOn = state == "1";
        btn.Tag = isOn ? "ON" : "OFF";
        if (isOn)
        {
            btn.ForeColor = Color.White;
            if (btn == btnPump) btn.BackColor = Color.MediumSeaGreen;
            else if (btn == btnFan) btn.BackColor = Color.DodgerBlue;
            else if (btn == btnLight) btn.BackColor = Color.Orange;
        }
        else
        {
            btn.BackColor = Color.FromArgb(230, 230, 230);
            btn.ForeColor = Color.Gray;
        }
    }

    private void btnOpenCharts_Click(object sender, EventArgs e)
    {
        if (!_businessService.IsConnected)
        {
            MessageBox.Show("Vui lòng kết nối cổng COM và Firebase trước khi xem biểu đồ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var chartForm = new ChartForm(_businessService);
        chartForm.ShowDialog(this);
    }

    private void btnToggleMode_Click(object sender, EventArgs e)
    {
        
        // Đảo chế độ và gửi lệnh tương ứng
        bool targetAutoMode = !_isAutoMode;
        _businessService.SendModeCommand(targetAutoMode);
    }

    private void btnSetTemp_Click(object sender, EventArgs e)
    {
        if (!_businessService.IsConnected) return;
        _businessService.SendThresholdCommand("TEMP", (int)numTempThresh.Value);
    }

    private void btnSetSoil_Click(object sender, EventArgs e)
    {
        if (!_businessService.IsConnected) return;
        _businessService.SendThresholdCommand("SOIL", (int)numSoilThresh.Value);
    }

    private void btnSetLight_Click(object sender, EventArgs e)
    {
        if (!_businessService.IsConnected) return;
        _businessService.SendThresholdCommand("LIGHT", (int)numLightThresh.Value);
    }

    private void btnPump_Click(object sender, EventArgs e)
    {
        ToggleDevice("PUMP", btnPump);
    }

    private void btnFan_Click(object sender, EventArgs e)
    {
        ToggleDevice("FAN", btnFan);
    }

    private void btnLight_Click(object sender, EventArgs e)
    {
        ToggleDevice("LIGHT", btnLight);
    }

    private void ToggleDevice(string devicePrefix, Button btn)
    {
        if (!_businessService.IsConnected)
        {
            MessageBox.Show("Vui lòng kết nối cổng COM trước khi điều khiển thiết bị!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            string currentStatus = btn.Tag?.ToString() ?? "OFF";
            bool shouldTurnOn = currentStatus != "ON";
            _businessService.SendDeviceCommand(devicePrefix, shouldTurnOn);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi gửi lệnh điều khiển {devicePrefix}: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnSend_Click(object sender, EventArgs e)
    {
        if (_businessService.IsConnected)
        {
            string command = txtSend.Text.Trim();
            if (!string.IsNullOrEmpty(command))
            {
                try
                {
                    _businessService.SendRawCommand(command);
                    txtSend.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi gửi dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        else
        {
            MessageBox.Show("Vui lòng kết nối với cổng COM trước khi gửi dữ liệu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
        txtReceive.Clear();
    }

    private void AppendLog(string message)
    {
        string timestamp = DateTime.Now.ToString("HH:mm:ss");
        txtReceive.AppendText($"[{timestamp}] {message}{Environment.NewLine}");
    }

    private void btnOpenSchedules_Click(object sender, EventArgs e)
    {
        var scheduleForm = new ScheduleForm(_businessService);
        scheduleForm.ShowDialog(this);
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        _businessService.Dispose();
    }
}
