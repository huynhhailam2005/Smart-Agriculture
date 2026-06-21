namespace Winform.BLL.Models;

public class SensorData
{
    public float Temperature { get; set; }
    public float Humidity { get; set; }
    public int SoilMoisture { get; set; }
    public int LightLevel { get; set; }
    
    // Đính kèm trạng thái thiết bị nếu có trong gói tin
    public DeviceState? DeviceState { get; set; }

    // Trạng thái chế độ tự động và các ngưỡng cấu hình
    public bool IsAutoMode { get; set; }
    public int TempThreshold { get; set; }
    public int SoilThreshold { get; set; }
    public int LightThreshold { get; set; }
}
