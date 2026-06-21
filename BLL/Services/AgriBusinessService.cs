using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Winform.BLL.Models;
using Winform.DAL;

namespace Winform.BLL.Services;

public class AgriBusinessService : IDisposable
{
    private readonly SerialPortManager _serialPortManager;
    private readonly FirebaseRepository _firebaseRepository;
    private Dictionary<string, DeviceSchedule> _schedules = new Dictionary<string, DeviceSchedule>();

    public event Action<SensorData>? SensorDataProcessed;
    public event Action<string>? LogReceived;
    public event Action<string>? ConnectionWarning;

    public bool IsConnected => _serialPortManager.IsOpen;

    public AgriBusinessService()
    {
        _serialPortManager = new SerialPortManager();
        _firebaseRepository = new FirebaseRepository();

        _serialPortManager.RawDataReceived += OnRawDataReceived;
        _serialPortManager.LogMessageGenerated += (log) => LogReceived?.Invoke(log);
    }

    public void InitializeFirebase(string firebaseDbUrl)
    {
        if (!string.IsNullOrEmpty(firebaseDbUrl))
        {
            _firebaseRepository.Initialize(firebaseDbUrl);
            LogReceived?.Invoke($"[HỆ THỐNG] Đã cấu hình Firebase Realtime Database: {firebaseDbUrl}");
            _ = Task.Run(async () => await LoadSchedulesFromFirebaseAsync());
        }
    }

    public string[] GetPorts()
    {
        return _serialPortManager.GetAvailablePorts();
    }

    public void Connect(string portName, int baudRate)
    {
        _serialPortManager.Connect(portName, baudRate);
    }

    public void Disconnect()
    {
        _serialPortManager.Disconnect();
    }

    public void SendModeCommand(bool isAuto)
    {
        string command = isAuto ? "MODE_AUTO" : "MODE_MANUAL";
        _serialPortManager.WriteLine(command);
        LogReceived?.Invoke($"[GỬI LỆNH CHẾ ĐỘ] {command}");
    }

    public void SendThresholdCommand(string prefix, int value)
    {
        string command = $"SET_{prefix}:{value}";
        _serialPortManager.WriteLine(command);
        LogReceived?.Invoke($"[GỬI CẤU HÌNH] {command}");
    }

    public void SendDeviceCommand(string devicePrefix, bool turnOn)
    {
        string command = turnOn ? $"{devicePrefix}_ON" : $"{devicePrefix}_OFF";
        _serialPortManager.WriteLine(command);
        LogReceived?.Invoke($"[GỬI LỆNH] {command}");
    }

    public void SendRawCommand(string command)
    {
        _serialPortManager.WriteLine(command);
        LogReceived?.Invoke($"[GỬI] {command}");
    }

    public async Task<List<SensorDataWithTime>> GetPastHourLogsAsync()
    {
        return await _firebaseRepository.FetchLogsInPastHourAsync();
    }

    public Dictionary<string, DeviceSchedule> GetSchedules()
    {
        return _schedules;
    }

    public async Task LoadSchedulesFromFirebaseAsync()
    {
        try
        {
            _schedules = await _firebaseRepository.GetSchedulesAsync();
            LogReceived?.Invoke($"[HỆ THỐNG] Đã tải {_schedules.Count} lịch trình từ Firebase.");
        }
        catch (Exception ex)
        {
            LogReceived?.Invoke($"[LỖI TẢI LỊCH] {ex.Message}");
        }
    }

    public async Task SaveSchedulesToFirebaseAsync(Dictionary<string, DeviceSchedule> schedules)
    {
        _schedules = schedules;
        try
        {
            await _firebaseRepository.SaveSchedulesAsync(_schedules);
            LogReceived?.Invoke("[HỆ THỐNG] Đã lưu và đồng bộ lịch trình lên Firebase.");
        }
        catch (Exception ex)
        {
            LogReceived?.Invoke($"[LỖI LƯU LỊCH] {ex.Message}");
        }
    }

    private void CheckAndExecuteSchedules(SensorData data)
    {
        if (data.IsAutoMode) return; // Chỉ chạy hẹn giờ ở chế độ MANUAL
        if (_schedules == null || _schedules.Count == 0) return;

        DateTime now = DateTime.Now;
        string currentTimeStr = now.ToString("HH:mm");
        string currentDateStr = now.ToString("yyyy-MM-dd");
        int currentDayOfWeek = (int)now.DayOfWeek; // 0 = Sunday, 1 = Monday, ..., 6 = Saturday
        int standardDayOfWeek = currentDayOfWeek == 0 ? 7 : currentDayOfWeek; // 1 = Thứ 2, ..., 7 = Chủ Nhật

        bool hasActiveSchedulePump = false;
        bool shouldTurnOnPump = false;

        bool hasActiveScheduleFan = false;
        bool shouldTurnOnFan = false;

        bool hasActiveScheduleLight = false;
        bool shouldTurnOnLight = false;

        foreach (var sch in _schedules.Values)
        {
            if (!sch.Enabled) continue;

            bool isPump = sch.Device.Equals("pump", StringComparison.OrdinalIgnoreCase);
            bool isFan = sch.Device.Equals("fan", StringComparison.OrdinalIgnoreCase);
            bool isLight = sch.Device.Equals("light", StringComparison.OrdinalIgnoreCase);

            if (!isPump && !isFan && !isLight) continue;

            if (isPump) hasActiveSchedulePump = true;
            if (isFan) hasActiveScheduleFan = true;
            if (isLight) hasActiveScheduleLight = true;

            bool dateMatch = false;
            if (sch.Mode.Equals("once", StringComparison.OrdinalIgnoreCase))
            {
                dateMatch = currentDateStr == sch.OnceDate;
            }
            else if (sch.Mode.Equals("daily", StringComparison.OrdinalIgnoreCase))
            {
                dateMatch = true;
            }
            else if (sch.Mode.Equals("weekly", StringComparison.OrdinalIgnoreCase))
            {
                dateMatch = sch.RepeatDays != null && sch.RepeatDays.Contains(standardDayOfWeek);
            }

            if (!dateMatch) continue;

            if (TimeSpan.TryParse(sch.StartTime, out TimeSpan startTime))
            {
                TimeSpan endTime = startTime.Add(TimeSpan.FromMinutes(sch.DurationMinutes));
                TimeSpan currentShortTime = new TimeSpan(now.Hour, now.Minute, now.Second);

                bool timeMatch = false;
                if (endTime.Days > 0 || endTime < startTime)
                {
                    TimeSpan normalEndTime = new TimeSpan(endTime.Hours, endTime.Minutes, endTime.Seconds);
                    timeMatch = currentShortTime >= startTime || currentShortTime < normalEndTime;
                }
                else
                {
                    timeMatch = currentShortTime >= startTime && currentShortTime < endTime;
                }

                if (timeMatch)
                {
                    if (isPump) shouldTurnOnPump = true;
                    if (isFan) shouldTurnOnFan = true;
                    if (isLight) shouldTurnOnLight = true;
                }
            }
        }

        if (hasActiveSchedulePump && data.DeviceState != null)
        {
            bool isCurrentlyOn = data.DeviceState.IsPumpOn;
            if (shouldTurnOnPump && !isCurrentlyOn)
            {
                SendDeviceCommand("PUMP", true);
            }
            else if (!shouldTurnOnPump && isCurrentlyOn)
            {
                SendDeviceCommand("PUMP", false);
            }
        }

        if (hasActiveScheduleFan && data.DeviceState != null)
        {
            bool isCurrentlyOn = data.DeviceState.IsFanOn;
            if (shouldTurnOnFan && !isCurrentlyOn)
            {
                SendDeviceCommand("FAN", true);
            }
            else if (!shouldTurnOnFan && isCurrentlyOn)
            {
                SendDeviceCommand("FAN", false);
            }
        }

        if (hasActiveScheduleLight && data.DeviceState != null)
        {
            bool isCurrentlyOn = data.DeviceState.IsLightOn;
            if (shouldTurnOnLight && !isCurrentlyOn)
            {
                SendDeviceCommand("LIGHT", true);
            }
            else if (!shouldTurnOnLight && isCurrentlyOn)
            {
                SendDeviceCommand("LIGHT", false);
            }
        }
    }

    private void OnRawDataReceived(string rawData)
    {
        string cleanRaw = rawData.Trim();
        if (string.IsNullOrEmpty(cleanRaw)) return;

        LogReceived?.Invoke($"[RAW] {cleanRaw}");
        ParseData(cleanRaw);
    }

    private void ParseData(string packet)
    {
        int startIndex = packet.IndexOf('*');
        int endIndex = packet.IndexOf('#', startIndex >= 0 ? startIndex : 0);

        if (startIndex >= 0 && endIndex > startIndex)
        {
            try
            {
                string content = packet.Substring(startIndex + 1, endIndex - startIndex - 1);
                string[] parts = content.Split('|');

                if (parts.Length >= 4)
                {
                    var sensorData = new SensorData
                    {
                        Temperature = float.Parse(parts[0].Trim()),
                        Humidity = float.Parse(parts[1].Trim()),
                        SoilMoisture = int.Parse(parts[2].Trim()),
                        LightLevel = int.Parse(parts[3].Trim())
                    };

                    if (parts.Length >= 7)
                    {
                        sensorData.DeviceState = new DeviceState
                        {
                            IsPumpOn = parts[4].Trim() == "1",
                            IsFanOn = parts[5].Trim() == "1",
                            IsLightOn = parts[6].Trim() == "1"
                        };
                    }

                    if (parts.Length >= 11)
                    {
                        sensorData.IsAutoMode = parts[7].Trim() == "1";
                        sensorData.TempThreshold = int.Parse(parts[8].Trim());
                        sensorData.SoilThreshold = int.Parse(parts[9].Trim());
                        sensorData.LightThreshold = int.Parse(parts[10].Trim());
                    }

                    SensorDataProcessed?.Invoke(sensorData);
                    CheckAndExecuteSchedules(sensorData);

                    _ = Task.Run(async () =>
                    {
                        try
                        {
                            await _firebaseRepository.PushSensorLogAsync(sensorData);
                            await _firebaseRepository.UpdateCurrentStatusAsync(sensorData);
                        }
                        catch (Exception ex)
                        {
                            ConnectionWarning?.Invoke($"[LỖI FIREBASE] Ghi dữ liệu thất bại: {ex.Message}");
                        }
                    });
                }
                else
                {
                    ConnectionWarning?.Invoke($"[CẢNH BÁO] Gói tin không đủ trường dữ liệu tối thiểu (chỉ có {parts.Length}/4 trường).");
                }
            }
            catch (Exception ex)
            {
                ConnectionWarning?.Invoke($"[LỖI PARSE] Lỗi phân tích: {ex.Message}");
            }
        }
        else
        {
            ConnectionWarning?.Invoke($"[CẢNH BÁO] Gói tin không đúng định dạng: '{packet}'");
        }
    }

    public void Dispose()
    {
        _serialPortManager.Dispose();
    }
}
