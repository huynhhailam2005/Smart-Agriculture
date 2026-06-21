namespace Winform.GUI;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    // Connection & Firebase Controls
    private System.Windows.Forms.GroupBox grpConnection;
    private System.Windows.Forms.Label lblPort;
    private System.Windows.Forms.ComboBox cboPorts;
    private System.Windows.Forms.Label lblBaudRate;
    private System.Windows.Forms.ComboBox cboBaudRate;
    private System.Windows.Forms.Label lblFirebaseUrl;
    private System.Windows.Forms.TextBox txtFirebaseUrl;
    private System.Windows.Forms.Button btnConnect;
    private System.Windows.Forms.Button btnOpenCharts;


    // Control Panel Controls (Manual overrides)
    private System.Windows.Forms.GroupBox grpControl;
    private System.Windows.Forms.Button btnPump;
    private System.Windows.Forms.Button btnFan;
    private System.Windows.Forms.Button btnLight;

    // Sensors Panel Controls
    private System.Windows.Forms.GroupBox grpSensors;
    private System.Windows.Forms.Label lblTempTitle;
    private System.Windows.Forms.Label lblTempVal;
    private System.Windows.Forms.Label lblHumTitle;
    private System.Windows.Forms.Label lblHumVal;
    private System.Windows.Forms.Label lblSoilTitle;
    private System.Windows.Forms.Label lblSoilVal;
    private System.Windows.Forms.Label lblLightTitle;
    private System.Windows.Forms.Label lblLightVal;

    // Mode & Threshold Config Panel Controls
    private System.Windows.Forms.GroupBox grpThresholds;
    private System.Windows.Forms.Label lblModeTitle;
    private System.Windows.Forms.Button btnToggleMode;
    private System.Windows.Forms.Label lblModeStatus;
    private System.Windows.Forms.Label lblTempThresh;
    private System.Windows.Forms.NumericUpDown numTempThresh;
    private System.Windows.Forms.Button btnSetTemp;
    private System.Windows.Forms.Label lblSoilThresh;
    private System.Windows.Forms.NumericUpDown numSoilThresh;
    private System.Windows.Forms.Button btnSetSoil;
    private System.Windows.Forms.Label lblLightThresh;
    private System.Windows.Forms.NumericUpDown numLightThresh;
    private System.Windows.Forms.Button btnSetLight;
    private System.Windows.Forms.Button btnOpenSchedules;

    // Console / Logging Controls
    private System.Windows.Forms.GroupBox grpConsole;
    private System.Windows.Forms.TextBox txtReceive;
    private System.Windows.Forms.TextBox txtSend;
    private System.Windows.Forms.Button btnSend;
    private System.Windows.Forms.Button btnClear;
    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.ToolStripStatusLabel lblStatus;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.grpConnection = new System.Windows.Forms.GroupBox();
        this.lblPort = new System.Windows.Forms.Label();
        this.cboPorts = new System.Windows.Forms.ComboBox();
        this.lblBaudRate = new System.Windows.Forms.Label();
        this.cboBaudRate = new System.Windows.Forms.ComboBox();
        this.lblFirebaseUrl = new System.Windows.Forms.Label();
        this.txtFirebaseUrl = new System.Windows.Forms.TextBox();
        this.btnConnect = new System.Windows.Forms.Button();
        this.btnOpenCharts = new System.Windows.Forms.Button();
        this.grpControl = new System.Windows.Forms.GroupBox();
        this.btnPump = new System.Windows.Forms.Button();
        this.btnFan = new System.Windows.Forms.Button();
        this.btnLight = new System.Windows.Forms.Button();
        this.grpSensors = new System.Windows.Forms.GroupBox();
        this.lblTempTitle = new System.Windows.Forms.Label();
        this.lblTempVal = new System.Windows.Forms.Label();
        this.lblHumTitle = new System.Windows.Forms.Label();
        this.lblHumVal = new System.Windows.Forms.Label();
        this.lblSoilTitle = new System.Windows.Forms.Label();
        this.lblSoilVal = new System.Windows.Forms.Label();
        this.lblLightTitle = new System.Windows.Forms.Label();
        this.lblLightVal = new System.Windows.Forms.Label();
        this.grpThresholds = new System.Windows.Forms.GroupBox();
        this.lblModeTitle = new System.Windows.Forms.Label();
        this.btnToggleMode = new System.Windows.Forms.Button();
        this.lblModeStatus = new System.Windows.Forms.Label();
        this.lblTempThresh = new System.Windows.Forms.Label();
        this.numTempThresh = new System.Windows.Forms.NumericUpDown();
        this.btnSetTemp = new System.Windows.Forms.Button();
        this.lblSoilThresh = new System.Windows.Forms.Label();
        this.numSoilThresh = new System.Windows.Forms.NumericUpDown();
        this.btnSetSoil = new System.Windows.Forms.Button();
        this.lblLightThresh = new System.Windows.Forms.Label();
        this.numLightThresh = new System.Windows.Forms.NumericUpDown();
        this.btnSetLight = new System.Windows.Forms.Button();
        this.btnOpenSchedules = new System.Windows.Forms.Button();
        this.grpConsole = new System.Windows.Forms.GroupBox();
        this.txtReceive = new System.Windows.Forms.TextBox();
        this.txtSend = new System.Windows.Forms.TextBox();
        this.btnSend = new System.Windows.Forms.Button();
        this.btnClear = new System.Windows.Forms.Button();
        this.statusStrip1 = new System.Windows.Forms.StatusStrip();
        this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
        this.grpConnection.SuspendLayout();
        this.grpControl.SuspendLayout();
        this.grpSensors.SuspendLayout();
        this.grpThresholds.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.numTempThresh)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.numSoilThresh)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.numLightThresh)).BeginInit();
        this.grpConsole.SuspendLayout();
        this.statusStrip1.SuspendLayout();
        this.SuspendLayout();
        // 
        // grpConnection
        // 
        this.grpConnection.Controls.Add(this.lblPort);
        this.grpConnection.Controls.Add(this.cboPorts);
        this.grpConnection.Controls.Add(this.lblBaudRate);
        this.grpConnection.Controls.Add(this.cboBaudRate);
        this.grpConnection.Controls.Add(this.lblFirebaseUrl);
        this.grpConnection.Controls.Add(this.txtFirebaseUrl);
        this.grpConnection.Controls.Add(this.btnConnect);
        this.grpConnection.Controls.Add(this.btnOpenCharts);
        this.grpConnection.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.grpConnection.Location = new System.Drawing.Point(12, 12);
        this.grpConnection.Name = "grpConnection";
        this.grpConnection.Size = new System.Drawing.Size(260, 280);
        this.grpConnection.TabIndex = 0;
        this.grpConnection.TabStop = false;
        this.grpConnection.Text = "Cấu hình Kết nối & Cơ sở dữ liệu";
        // 
        // lblPort
        // 
        this.lblPort.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.lblPort.Location = new System.Drawing.Point(15, 25);
        this.lblPort.Name = "lblPort";
        this.lblPort.Size = new System.Drawing.Size(80, 25);
        this.lblPort.TabIndex = 0;
        this.lblPort.Text = "Cổng COM:";
        this.lblPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // cboPorts
        // 
        this.cboPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cboPorts.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.cboPorts.FormattingEnabled = true;
        this.cboPorts.Location = new System.Drawing.Point(100, 25);
        this.cboPorts.Name = "cboPorts";
        this.cboPorts.Size = new System.Drawing.Size(140, 23);
        this.cboPorts.TabIndex = 1;
        // 
        // lblBaudRate
        // 
        this.lblBaudRate.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.lblBaudRate.Location = new System.Drawing.Point(15, 60);
        this.lblBaudRate.Name = "lblBaudRate";
        this.lblBaudRate.Size = new System.Drawing.Size(80, 25);
        this.lblBaudRate.TabIndex = 2;
        this.lblBaudRate.Text = "Baud Rate:";
        this.lblBaudRate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // cboBaudRate
        // 
        this.cboBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cboBaudRate.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.cboBaudRate.FormattingEnabled = true;
        this.cboBaudRate.Items.AddRange(new object[] {
        "4800",
        "9600",
        "19200",
        "38400",
        "57600",
        "115200"});
        this.cboBaudRate.Location = new System.Drawing.Point(100, 60);
        this.cboBaudRate.Name = "cboBaudRate";
        this.cboBaudRate.Size = new System.Drawing.Size(140, 23);
        this.cboBaudRate.TabIndex = 3;
        // 
        // lblFirebaseUrl
        // 
        this.lblFirebaseUrl.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.lblFirebaseUrl.Location = new System.Drawing.Point(15, 95);
        this.lblFirebaseUrl.Name = "lblFirebaseUrl";
        this.lblFirebaseUrl.Size = new System.Drawing.Size(225, 20);
        this.lblFirebaseUrl.TabIndex = 4;
        this.lblFirebaseUrl.Text = "Firebase RTDB URL:";
        this.lblFirebaseUrl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // txtFirebaseUrl
        // 
        this.txtFirebaseUrl.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.txtFirebaseUrl.Location = new System.Drawing.Point(15, 118);
        this.txtFirebaseUrl.Name = "txtFirebaseUrl";
        this.txtFirebaseUrl.Size = new System.Drawing.Size(225, 23);
        this.txtFirebaseUrl.TabIndex = 5;
        this.txtFirebaseUrl.Text = "https://smart-agriculture-iot-b1517-default-rtdb.asia-southeast1.firebasedatabase.app/";
        // 
        // btnConnect
        // 
        this.btnConnect.BackColor = System.Drawing.Color.DodgerBlue;
        this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnConnect.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.btnConnect.ForeColor = System.Drawing.Color.White;
        this.btnConnect.Location = new System.Drawing.Point(15, 155);
        this.btnConnect.Name = "btnConnect";
        this.btnConnect.Size = new System.Drawing.Size(225, 50);
        this.btnConnect.TabIndex = 6;
        this.btnConnect.Text = "Kết nối";
        this.btnConnect.UseVisualStyleBackColor = false;
        this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
        // 
        // btnOpenCharts
        // 
        this.btnOpenCharts.BackColor = System.Drawing.Color.MediumSeaGreen;
        this.btnOpenCharts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnOpenCharts.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.btnOpenCharts.ForeColor = System.Drawing.Color.White;
        this.btnOpenCharts.Location = new System.Drawing.Point(15, 215);
        this.btnOpenCharts.Name = "btnOpenCharts";
        this.btnOpenCharts.Size = new System.Drawing.Size(225, 45);
        this.btnOpenCharts.TabIndex = 7;
        this.btnOpenCharts.Text = "Xem Biểu Đồ Lịch Sử";
        this.btnOpenCharts.UseVisualStyleBackColor = false;
        this.btnOpenCharts.Click += new System.EventHandler(this.btnOpenCharts_Click);
        // 
        // grpControl
        // 
        this.grpControl.Controls.Add(this.btnPump);
        this.grpControl.Controls.Add(this.btnFan);
        this.grpControl.Controls.Add(this.btnLight);
        this.grpControl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.grpControl.Location = new System.Drawing.Point(12, 305);
        this.grpControl.Name = "grpControl";
        this.grpControl.Size = new System.Drawing.Size(260, 215);
        this.grpControl.TabIndex = 1;
        this.grpControl.TabStop = false;
        this.grpControl.Text = "Điều khiển Thiết bị (Thủ công)";
        // 
        // 
        // btnPump
        // 
        this.btnPump.BackColor = System.Drawing.Color.Gray;
        this.btnPump.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnPump.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.btnPump.ForeColor = System.Drawing.Color.White;
        this.btnPump.Location = new System.Drawing.Point(15, 20);
        this.btnPump.Name = "btnPump";
        this.btnPump.Size = new System.Drawing.Size(230, 45);
        this.btnPump.TabIndex = 0;
        this.btnPump.Text = "MÁY BƠM";
        this.btnPump.UseVisualStyleBackColor = false;
        this.btnPump.Click += new System.EventHandler(this.btnPump_Click);
        // 
        // btnFan
        // 
        this.btnFan.BackColor = System.Drawing.Color.Gray;
        this.btnFan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnFan.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.btnFan.ForeColor = System.Drawing.Color.White;
        this.btnFan.Location = new System.Drawing.Point(15, 80);
        this.btnFan.Name = "btnFan";
        this.btnFan.Size = new System.Drawing.Size(230, 45);
        this.btnFan.TabIndex = 2;
        this.btnFan.Text = "QUẠT GIÓ";
        this.btnFan.UseVisualStyleBackColor = false;
        this.btnFan.Click += new System.EventHandler(this.btnFan_Click);
        // 
        // btnLight
        // 
        this.btnLight.BackColor = System.Drawing.Color.Gray;
        this.btnLight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnLight.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.btnLight.ForeColor = System.Drawing.Color.White;
        this.btnLight.Location = new System.Drawing.Point(15, 140);
        this.btnLight.Name = "btnLight";
        this.btnLight.Size = new System.Drawing.Size(230, 45);
        this.btnLight.TabIndex = 4;
        this.btnLight.Text = "ĐÈN CHIẾU";
        this.btnLight.UseVisualStyleBackColor = false;
        this.btnLight.Click += new System.EventHandler(this.btnLight_Click);
        // 
        // grpSensors
        // 
        this.grpSensors.Controls.Add(this.lblTempTitle);
        this.grpSensors.Controls.Add(this.lblTempVal);
        this.grpSensors.Controls.Add(this.lblHumTitle);
        this.grpSensors.Controls.Add(this.lblHumVal);
        this.grpSensors.Controls.Add(this.lblSoilTitle);
        this.grpSensors.Controls.Add(this.lblSoilVal);
        this.grpSensors.Controls.Add(this.lblLightTitle);
        this.grpSensors.Controls.Add(this.lblLightVal);
        this.grpSensors.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.grpSensors.Location = new System.Drawing.Point(288, 12);
        this.grpSensors.Name = "grpSensors";
        this.grpSensors.Size = new System.Drawing.Size(320, 498);
        this.grpSensors.TabIndex = 2;
        this.grpSensors.TabStop = false;
        this.grpSensors.Text = "Thông số Cảm biến từ Mạch";
        // 
        // lblTempTitle
        // 
        this.lblTempTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.lblTempTitle.ForeColor = System.Drawing.Color.DimGray;
        this.lblTempTitle.Location = new System.Drawing.Point(15, 25);
        this.lblTempTitle.Name = "lblTempTitle";
        this.lblTempTitle.Size = new System.Drawing.Size(290, 20);
        this.lblTempTitle.TabIndex = 0;
        this.lblTempTitle.Text = "Nhiệt độ không khí:";
        // 
        // lblTempVal
        // 
        this.lblTempVal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
        this.lblTempVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.lblTempVal.Font = new System.Drawing.Font("Consolas", 20F, System.Drawing.FontStyle.Bold);
        this.lblTempVal.ForeColor = System.Drawing.Color.Crimson;
        this.lblTempVal.Location = new System.Drawing.Point(15, 48);
        this.lblTempVal.Name = "lblTempVal";
        this.lblTempVal.Size = new System.Drawing.Size(290, 60);
        this.lblTempVal.TabIndex = 1;
        this.lblTempVal.Text = "--.- °C";
        this.lblTempVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lblHumTitle
        // 
        this.lblHumTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.lblHumTitle.ForeColor = System.Drawing.Color.DimGray;
        this.lblHumTitle.Location = new System.Drawing.Point(15, 140);
        this.lblHumTitle.Name = "lblHumTitle";
        this.lblHumTitle.Size = new System.Drawing.Size(290, 20);
        this.lblHumTitle.TabIndex = 2;
        this.lblHumTitle.Text = "Độ ẩm không khí:";
        // 
        // lblHumVal
        // 
        this.lblHumVal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
        this.lblHumVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.lblHumVal.Font = new System.Drawing.Font("Consolas", 20F, System.Drawing.FontStyle.Bold);
        this.lblHumVal.ForeColor = System.Drawing.Color.DodgerBlue;
        this.lblHumVal.Location = new System.Drawing.Point(15, 163);
        this.lblHumVal.Name = "lblHumVal";
        this.lblHumVal.Size = new System.Drawing.Size(290, 60);
        this.lblHumVal.TabIndex = 3;
        this.lblHumVal.Text = "--.- %";
        this.lblHumVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lblSoilTitle
        // 
        this.lblSoilTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.lblSoilTitle.ForeColor = System.Drawing.Color.DimGray;
        this.lblSoilTitle.Location = new System.Drawing.Point(15, 260);
        this.lblSoilTitle.Name = "lblSoilTitle";
        this.lblSoilTitle.Size = new System.Drawing.Size(290, 20);
        this.lblSoilTitle.TabIndex = 4;
        this.lblSoilTitle.Text = "Độ ẩm đất:";
        // 
        // lblSoilVal
        // 
        this.lblSoilVal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(255)))), ((int)(((byte)(240)))));
        this.lblSoilVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.lblSoilVal.Font = new System.Drawing.Font("Consolas", 20F, System.Drawing.FontStyle.Bold);
        this.lblSoilVal.ForeColor = System.Drawing.Color.ForestGreen;
        this.lblSoilVal.Location = new System.Drawing.Point(15, 283);
        this.lblSoilVal.Name = "lblSoilVal";
        this.lblSoilVal.Size = new System.Drawing.Size(290, 60);
        this.lblSoilVal.TabIndex = 5;
        this.lblSoilVal.Text = "-- %";
        this.lblSoilVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lblLightTitle
        // 
        this.lblLightTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.lblLightTitle.ForeColor = System.Drawing.Color.DimGray;
        this.lblLightTitle.Location = new System.Drawing.Point(15, 380);
        this.lblLightTitle.Name = "lblLightTitle";
        this.lblLightTitle.Size = new System.Drawing.Size(290, 20);
        this.lblLightTitle.TabIndex = 6;
        this.lblLightTitle.Text = "Cường độ ánh sáng:";
        // 
        // lblLightVal
        // 
        this.lblLightVal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(240)))));
        this.lblLightVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.lblLightVal.Font = new System.Drawing.Font("Consolas", 20F, System.Drawing.FontStyle.Bold);
        this.lblLightVal.ForeColor = System.Drawing.Color.Goldenrod;
        this.lblLightVal.Location = new System.Drawing.Point(15, 403);
        this.lblLightVal.Name = "lblLightVal";
        this.lblLightVal.Size = new System.Drawing.Size(290, 60);
        this.lblLightVal.TabIndex = 7;
        this.lblLightVal.Text = "-- %";
        this.lblLightVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // grpThresholds
        // 
        this.grpThresholds.Controls.Add(this.lblModeTitle);
        this.grpThresholds.Controls.Add(this.btnToggleMode);
        this.grpThresholds.Controls.Add(this.lblModeStatus);
        this.grpThresholds.Controls.Add(this.lblTempThresh);
        this.grpThresholds.Controls.Add(this.numTempThresh);
        this.grpThresholds.Controls.Add(this.btnSetTemp);
        this.grpThresholds.Controls.Add(this.lblSoilThresh);
        this.grpThresholds.Controls.Add(this.numSoilThresh);
        this.grpThresholds.Controls.Add(this.btnSetSoil);
        this.grpThresholds.Controls.Add(this.lblLightThresh);
        this.grpThresholds.Controls.Add(this.numLightThresh);
        this.grpThresholds.Controls.Add(this.btnSetLight);
        this.grpThresholds.Controls.Add(this.btnOpenSchedules);
        this.grpThresholds.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.grpThresholds.Location = new System.Drawing.Point(624, 12);
        this.grpThresholds.Name = "grpThresholds";
        this.grpThresholds.Size = new System.Drawing.Size(300, 498);
        this.grpThresholds.TabIndex = 3;
        this.grpThresholds.TabStop = false;
        this.grpThresholds.Text = "Cấu hình Chế độ & Ngưỡng Tự động";
        // 
        // lblModeTitle
        // 
        this.lblModeTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.lblModeTitle.ForeColor = System.Drawing.Color.DimGray;
        this.lblModeTitle.Location = new System.Drawing.Point(15, 25);
        this.lblModeTitle.Name = "lblModeTitle";
        this.lblModeTitle.Size = new System.Drawing.Size(270, 20);
        this.lblModeTitle.TabIndex = 0;
        this.lblModeTitle.Text = "Chế độ hoạt động hiện tại:";
        // 
        // lblModeStatus
        // 
        this.lblModeStatus.BackColor = System.Drawing.Color.LightGreen;
        this.lblModeStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.lblModeStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        this.lblModeStatus.ForeColor = System.Drawing.Color.DarkGreen;
        this.lblModeStatus.Location = new System.Drawing.Point(15, 50);
        this.lblModeStatus.Name = "lblModeStatus";
        this.lblModeStatus.Size = new System.Drawing.Size(270, 40);
        this.lblModeStatus.TabIndex = 1;
        this.lblModeStatus.Text = "TỰ ĐỘNG (AUTO)";
        this.lblModeStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // btnToggleMode
        // 
        this.btnToggleMode.BackColor = System.Drawing.Color.Orange;
        this.btnToggleMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnToggleMode.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.btnToggleMode.ForeColor = System.Drawing.Color.White;
        this.btnToggleMode.Location = new System.Drawing.Point(15, 100);
        this.btnToggleMode.Name = "btnToggleMode";
        this.btnToggleMode.Size = new System.Drawing.Size(270, 40);
        this.btnToggleMode.TabIndex = 2;
        this.btnToggleMode.Text = "Chuyển sang THỦ CÔNG";
        this.btnToggleMode.UseVisualStyleBackColor = false;
        this.btnToggleMode.Click += new System.EventHandler(this.btnToggleMode_Click);
        // 
        // lblTempThresh
        // 
        this.lblTempThresh.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.lblTempThresh.ForeColor = System.Drawing.Color.DimGray;
        this.lblTempThresh.Location = new System.Drawing.Point(15, 160);
        this.lblTempThresh.Name = "lblTempThresh";
        this.lblTempThresh.Size = new System.Drawing.Size(270, 20);
        this.lblTempThresh.TabIndex = 3;
        this.lblTempThresh.Text = "Ngưỡng nhiệt độ bật quạt (°C):";
        // 
        // numTempThresh
        // 
        this.numTempThresh.Font = new System.Drawing.Font("Segoe UI", 12F);
        this.numTempThresh.Location = new System.Drawing.Point(15, 185);
        this.numTempThresh.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
        this.numTempThresh.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
        this.numTempThresh.Name = "numTempThresh";
        this.numTempThresh.Size = new System.Drawing.Size(160, 29);
        this.numTempThresh.TabIndex = 4;
        this.numTempThresh.Value = new decimal(new int[] {
            31,
            0,
            0,
            0});
        // 
        // btnSetTemp
        // 
        this.btnSetTemp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnSetTemp.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.btnSetTemp.Location = new System.Drawing.Point(185, 185);
        this.btnSetTemp.Name = "btnSetTemp";
        this.btnSetTemp.Size = new System.Drawing.Size(100, 29);
        this.btnSetTemp.TabIndex = 5;
        this.btnSetTemp.Text = "Cài đặt";
        this.btnSetTemp.UseVisualStyleBackColor = true;
        this.btnSetTemp.Click += new System.EventHandler(this.btnSetTemp_Click);
        // 
        // lblSoilThresh
        // 
        this.lblSoilThresh.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.lblSoilThresh.ForeColor = System.Drawing.Color.DimGray;
        this.lblSoilThresh.Location = new System.Drawing.Point(15, 240);
        this.lblSoilThresh.Name = "lblSoilThresh";
        this.lblSoilThresh.Size = new System.Drawing.Size(270, 20);
        this.lblSoilThresh.TabIndex = 6;
        this.lblSoilThresh.Text = "Ngưỡng độ ẩm đất bật bơm (%):";
        // 
        // numSoilThresh
        // 
        this.numSoilThresh.Font = new System.Drawing.Font("Segoe UI", 12F);
        this.numSoilThresh.Location = new System.Drawing.Point(15, 265);
        this.numSoilThresh.Name = "numSoilThresh";
        this.numSoilThresh.Size = new System.Drawing.Size(160, 29);
        this.numSoilThresh.TabIndex = 7;
        this.numSoilThresh.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
        // 
        // btnSetSoil
        // 
        this.btnSetSoil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnSetSoil.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.btnSetSoil.Location = new System.Drawing.Point(185, 265);
        this.btnSetSoil.Name = "btnSetSoil";
        this.btnSetSoil.Size = new System.Drawing.Size(100, 29);
        this.btnSetSoil.TabIndex = 8;
        this.btnSetSoil.Text = "Cài đặt";
        this.btnSetSoil.UseVisualStyleBackColor = true;
        this.btnSetSoil.Click += new System.EventHandler(this.btnSetSoil_Click);
        // 
        // lblLightThresh
        // 
        this.lblLightThresh.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.lblLightThresh.ForeColor = System.Drawing.Color.DimGray;
        this.lblLightThresh.Location = new System.Drawing.Point(15, 320);
        this.lblLightThresh.Name = "lblLightThresh";
        this.lblLightThresh.Size = new System.Drawing.Size(270, 20);
        this.lblLightThresh.TabIndex = 9;
        this.lblLightThresh.Text = "Ngưỡng ánh sáng bật đèn (%):";
        // 
        // numLightThresh
        // 
        this.numLightThresh.Font = new System.Drawing.Font("Segoe UI", 12F);
        this.numLightThresh.Location = new System.Drawing.Point(15, 345);
        this.numLightThresh.Name = "numLightThresh";
        this.numLightThresh.Size = new System.Drawing.Size(160, 29);
        this.numLightThresh.TabIndex = 10;
        this.numLightThresh.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
        // 
        // btnSetLight
        // 
        this.btnSetLight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnSetLight.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.btnSetLight.Location = new System.Drawing.Point(185, 345);
        this.btnSetLight.Name = "btnSetLight";
        this.btnSetLight.Size = new System.Drawing.Size(100, 29);
        this.btnSetLight.TabIndex = 11;
        this.btnSetLight.Text = "Cài đặt";
        this.btnSetLight.UseVisualStyleBackColor = true;
        this.btnSetLight.Click += new System.EventHandler(this.btnSetLight_Click);
        // 
        // btnOpenSchedules
        // 
        this.btnOpenSchedules.BackColor = System.Drawing.Color.MediumPurple;
        this.btnOpenSchedules.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnOpenSchedules.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.btnOpenSchedules.ForeColor = System.Drawing.Color.White;
        this.btnOpenSchedules.Location = new System.Drawing.Point(15, 410);
        this.btnOpenSchedules.Name = "btnOpenSchedules";
        this.btnOpenSchedules.Size = new System.Drawing.Size(270, 50);
        this.btnOpenSchedules.TabIndex = 12;
        this.btnOpenSchedules.Text = "Lên Lịch Hoạt Động Thiết Bị";
        this.btnOpenSchedules.UseVisualStyleBackColor = false;
        this.btnOpenSchedules.Click += new System.EventHandler(this.btnOpenSchedules_Click);
        // 
        // grpConsole
        // 
        this.grpConsole.Controls.Add(this.txtReceive);
        this.grpConsole.Controls.Add(this.txtSend);
        this.grpConsole.Controls.Add(this.btnSend);
        this.grpConsole.Controls.Add(this.btnClear);
        this.grpConsole.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.grpConsole.Location = new System.Drawing.Point(938, 12);
        this.grpConsole.Name = "grpConsole";
        this.grpConsole.Size = new System.Drawing.Size(410, 498);
        this.grpConsole.TabIndex = 4;
        this.grpConsole.TabStop = false;
        this.grpConsole.Text = "Bảng Log & Giao tiếp Serial";
        // 
        // txtReceive
        // 
        this.txtReceive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
        this.txtReceive.Font = new System.Drawing.Font("Consolas", 9F);
        this.txtReceive.ForeColor = System.Drawing.Color.LightGreen;
        this.txtReceive.Location = new System.Drawing.Point(15, 25);
        this.txtReceive.Multiline = true;
        this.txtReceive.Name = "txtReceive";
        this.txtReceive.ReadOnly = true;
        this.txtReceive.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        this.txtReceive.Size = new System.Drawing.Size(380, 355);
        this.txtReceive.TabIndex = 0;
        // 
        // txtSend
        // 
        this.txtSend.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.txtSend.Location = new System.Drawing.Point(15, 400);
        this.txtSend.Name = "txtSend";
        this.txtSend.Size = new System.Drawing.Size(280, 24);
        this.txtSend.TabIndex = 1;
        // 
        // btnSend
        // 
        this.btnSend.BackColor = System.Drawing.Color.ForestGreen;
        this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnSend.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.btnSend.ForeColor = System.Drawing.Color.White;
        this.btnSend.Location = new System.Drawing.Point(305, 400);
        this.btnSend.Name = "btnSend";
        this.btnSend.Size = new System.Drawing.Size(90, 25);
        this.btnSend.TabIndex = 2;
        this.btnSend.Text = "Gửi lệnh";
        this.btnSend.UseVisualStyleBackColor = false;
        this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
        // 
        // btnClear
        // 
        this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.btnClear.Location = new System.Drawing.Point(15, 445);
        this.btnClear.Name = "btnClear";
        this.btnClear.Size = new System.Drawing.Size(120, 30);
        this.btnClear.TabIndex = 3;
        this.btnClear.Text = "Xóa Console";
        this.btnClear.UseVisualStyleBackColor = true;
        this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
        // 
        // statusStrip1
        // 
        this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        this.lblStatus});
        this.statusStrip1.Location = new System.Drawing.Point(0, 528);
        this.statusStrip1.Name = "statusStrip1";
        this.statusStrip1.Size = new System.Drawing.Size(1360, 22);
        this.statusStrip1.TabIndex = 5;
        this.statusStrip1.Text = "statusStrip1";
        // 
        // lblStatus
        // 
        this.lblStatus.Name = "lblStatus";
        this.lblStatus.Size = new System.Drawing.Size(79, 17);
        this.lblStatus.Text = "Chưa kết nối";
        // 
        // Form1
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(1360, 550);
        this.Controls.Add(this.statusStrip1);
        this.Controls.Add(this.grpConsole);
        this.Controls.Add(this.grpThresholds);
        this.Controls.Add(this.grpSensors);
        this.Controls.Add(this.grpControl);
        this.Controls.Add(this.grpConnection);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.Name = "MainForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Hệ thống giám sát Nông nghiệp thông minh - Smart Agri Dashboard";
        this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
        this.Load += new System.EventHandler(this.MainForm_Load);
        this.grpConnection.ResumeLayout(false);
        this.grpConnection.PerformLayout();
        this.grpControl.ResumeLayout(false);
        this.grpSensors.ResumeLayout(false);
        this.grpThresholds.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.numTempThresh)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.numSoilThresh)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.numLightThresh)).EndInit();
        this.grpConsole.ResumeLayout(false);
        this.grpConsole.PerformLayout();
        this.statusStrip1.ResumeLayout(false);
        this.statusStrip1.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion
}
