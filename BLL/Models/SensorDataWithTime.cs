using System;

namespace Winform.BLL.Models;

public class SensorDataWithTime
{
    public float Temperature { get; set; }
    public float Humidity { get; set; }
    public int SoilMoisture { get; set; }
    public int LightLevel { get; set; }
    public DateTime Timestamp { get; set; }
    
    public bool IsPumpOn { get; set; }
    public bool IsFanOn { get; set; }
    public bool IsLightOn { get; set; }
}
