using System;
using System.IO.Ports;

namespace Winform.DAL;

public class SerialPortManager : IDisposable
{
    private SerialPort? _serialPort;

    public event Action<string>? RawDataReceived;
    public event Action<string>? LogMessageGenerated;

    public bool IsOpen => _serialPort != null && _serialPort.IsOpen;

    public SerialPortManager()
    {
        _serialPort = new SerialPort();
        _serialPort.DataReceived += OnDataReceived;
    }

    public string[] GetAvailablePorts()
    {
        return SerialPort.GetPortNames();
    }

    public void Connect(string portName, int baudRate)
    {
        if (IsOpen || _serialPort == null) return;

        _serialPort.PortName = portName;
        _serialPort.BaudRate = baudRate;
        _serialPort.Open();
        
        LogMessageGenerated?.Invoke($"[HỆ THỐNG] Đã mở cổng {_serialPort.PortName} thành công.");
    }

    public void Disconnect()
    {
        if (!IsOpen || _serialPort == null) return;

        string closedPortName = _serialPort.PortName;
        _serialPort.Close();
        
        LogMessageGenerated?.Invoke($"[HỆ THỐNG] Đã ngắt kết nối cổng {closedPortName}.");
    }

    public void WriteLine(string message)
    {
        if (!IsOpen || _serialPort == null)
        {
            throw new InvalidOperationException("Cổng Serial chưa được mở.");
        }
        _serialPort.WriteLine(message);
    }

    private void OnDataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        try
        {
            if (IsOpen && _serialPort != null)
            {
                string rawData = _serialPort.ReadLine();
                RawDataReceived?.Invoke(rawData);
            }
        }
        catch (Exception)
        {
            // Bỏ qua lỗi ngắt kết nối đột ngột khi đang đọc dữ liệu
        }
    }

    public void Dispose()
    {
        if (_serialPort != null)
        {
            if (_serialPort.IsOpen)
            {
                _serialPort.Close();
            }
            _serialPort.Dispose();
            _serialPort = null;
        }
    }
}
