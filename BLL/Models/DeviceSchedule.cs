using System;
using System.Collections.Generic;

namespace Winform.BLL.Models;

public class DeviceSchedule
{
    public string Id { get; set; } = string.Empty;
    public string Device { get; set; } = string.Empty; // "pump", "fan", "light"
    public bool Enabled { get; set; }
    public string Mode { get; set; } = "once"; // "once", "daily", "weekly"
    public string OnceDate { get; set; } = string.Empty; // "yyyy-MM-dd"
    public List<int> RepeatDays { get; set; } = new List<int>(); // 1 = Thứ 2, ..., 7 = Chủ Nhật
    public string StartTime { get; set; } = "00:00"; // "HH:mm"
    public int DurationMinutes { get; set; } = 30;
}
