using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using Winform.BLL.Models;

namespace Winform.DAL;

public class FirebaseRepository
{
    private FirebaseClient? _client;
    private string? _baseUrl;

    public void Initialize(string baseUrl)
    {
        if (string.IsNullOrEmpty(baseUrl)) return;
        
        if (!baseUrl.EndsWith("/"))
        {
            baseUrl += "/";
        }

        _baseUrl = baseUrl;
        _client = new FirebaseClient(_baseUrl);
    }

    public async Task PushSensorLogAsync(SensorData data)
    {
        if (_client == null) return;

        var payload = new
        {
            temp_air = data.Temperature,
            hum_air = data.Humidity,
            hum_soil = data.SoilMoisture,
            light_level = data.LightLevel,
            timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
            pump = data.DeviceState?.IsPumpOn ?? false ? 1 : 0,
            fan = data.DeviceState?.IsFanOn ?? false ? 1 : 0,
            light = data.DeviceState?.IsLightOn ?? false ? 1 : 0,
            control_mode = data.IsAutoMode ? "AUTO" : "MANUAL",
            temp_max = data.TempThreshold,
            soil_min = data.SoilThreshold,
            light_min = data.LightThreshold
        };

        await _client.Child("smart_agri/logs").PostAsync(payload);
    }

    public async Task UpdateCurrentStatusAsync(SensorData data)
    {
        if (_client == null) return;

        var sensors = new
        {
            temp_air = data.Temperature,
            hum_air = data.Humidity,
            hum_soil = data.SoilMoisture,
            light_level = data.LightLevel
        };

        var devices = new
        {
            pump = data.DeviceState?.IsPumpOn ?? false ? 1 : 0,
            fan = data.DeviceState?.IsFanOn ?? false ? 1 : 0,
            light = data.DeviceState?.IsLightOn ?? false ? 1 : 0
        };

        var settings = new
        {
            control_mode = data.IsAutoMode ? "AUTO" : "MANUAL",
            auto_thresholds = new
            {
                soil_min = data.SoilThreshold,
                soil_max = 80,
                temp_max = data.TempThreshold,
                light_min = data.LightThreshold
            },
            schedules = new
            {
                light_on_time = "18:00",
                light_off_time = "22:00"
            }
        };

        await _client.Child("smart_agri/sensors").PutAsync(sensors);
        await _client.Child("smart_agri/devices").PutAsync(devices);
        await _client.Child("smart_agri/settings").PutAsync(settings);
        await _client.Child("smart_agri/last_update").PutAsync($"\"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}\"");
    }

    public async Task<List<SensorDataWithTime>> FetchLogsInPastHourAsync()
    {
        var list = new List<SensorDataWithTime>();
        if (_client == null) return list;

        try
        {
            // Tải dữ liệu từ node logs mới
            var logs = await _client.Child("smart_agri/logs").OnceAsync<Newtonsoft.Json.Linq.JObject>();
            DateTime oneHourAgo = DateTime.Now.AddHours(-1);

            foreach (var log in logs)
            {
                var obj = log.Object;
                if (obj == null) continue;

                // Thử đọc trường timestamp mới trước, sau đó fallback sang Timestamp/LastUpdate cũ
                string? tsStr = obj["timestamp"]?.ToString() ?? obj["Timestamp"]?.ToString() ?? obj["LastUpdate"]?.ToString();
                if (DateTime.TryParse(tsStr, out DateTime timestamp))
                {
                    if (timestamp >= oneHourAgo)
                    {
                        list.Add(new SensorDataWithTime
                        {
                            Temperature = obj["temp_air"]?.ToObject<float>() ?? obj["Temperature"]?.ToObject<float>() ?? 0f,
                            Humidity = obj["hum_air"]?.ToObject<float>() ?? obj["Humidity"]?.ToObject<float>() ?? 0f,
                            SoilMoisture = obj["hum_soil"]?.ToObject<int>() ?? obj["SoilMoisture"]?.ToObject<int>() ?? 0,
                            LightLevel = obj["light_level"]?.ToObject<int>() ?? obj["LightLevel"]?.ToObject<int>() ?? 0,
                            Timestamp = timestamp,
                            IsPumpOn = (obj["pump"]?.ToObject<int>() ?? obj["PumpState"]?.ToObject<int>() ?? 0) == 1,
                            IsFanOn = (obj["fan"]?.ToObject<int>() ?? obj["FanState"]?.ToObject<int>() ?? 0) == 1,
                            IsLightOn = (obj["light"]?.ToObject<int>() ?? obj["LightState"]?.ToObject<int>() ?? 0) == 1
                        });
                    }
                }
            }
        }
        catch (Exception)
        {
            // Bỏ qua lỗi và trả về danh sách rỗng
        }

        return list.OrderBy(x => x.Timestamp).ToList();
    }

    public async Task SaveSchedulesAsync(Dictionary<string, DeviceSchedule> schedules)
    {
        if (_client == null) return;
        await _client.Child("smart_agri/settings/schedules").PutAsync(schedules);
    }

    public async Task<Dictionary<string, DeviceSchedule>> GetSchedulesAsync()
    {
        if (_client == null) return new Dictionary<string, DeviceSchedule>();
        try
        {
            var data = await _client.Child("smart_agri/settings/schedules").OnceAsync<DeviceSchedule>();
            var dict = new Dictionary<string, DeviceSchedule>();
            foreach (var item in data)
            {
                if (item.Object != null)
                {
                    dict[item.Key] = item.Object;
                }
            }
            return dict;
        }
        catch (Exception)
        {
            return new Dictionary<string, DeviceSchedule>();
        }
    }
}
