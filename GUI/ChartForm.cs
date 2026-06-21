using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Winform.BLL.Models;
using Winform.BLL.Services;

namespace Winform.GUI;

public partial class ChartForm : Form
{
    private readonly AgriBusinessService _businessService;

    public ChartForm(AgriBusinessService businessService)
    {
        InitializeComponent();
        _businessService = businessService;
    }

    private async void ChartForm_Load(object sender, EventArgs e)
    {
        ConfigureChartAxes();

        try
        {
            lblStatus.Text = "Đang tải dữ liệu lịch sử từ Firebase...";
            List<SensorDataWithTime> logs = await _businessService.GetPastHourLogsAsync();
            
            foreach (var log in logs)
            {
                AddDataPointToCharts(log.Timestamp, log.Temperature, log.Humidity, log.SoilMoisture, log.LightLevel);
            }
            
            lblStatus.Text = $"Đã tải {logs.Count} bản ghi lịch sử. Đang đồng bộ thời gian thực...";
        }
        catch (Exception ex)
        {
            lblStatus.Text = $"Lỗi tải lịch sử: {ex.Message}. Đang đồng bộ thời gian thực...";
        }

        _businessService.SensorDataProcessed += OnSensorDataProcessed;
    }

    private void ConfigureChartAxes()
    {
        ConfigureSingleChartArea(chartTemp.ChartAreas[0]);
        ConfigureSingleChartArea(chartHum.ChartAreas[0]);
        ConfigureSingleChartArea(chartSoil.ChartAreas[0]);
        ConfigureSingleChartArea(chartLight.ChartAreas[0]);
    }

    private void ConfigureSingleChartArea(ChartArea area)
    {
        area.AxisX.LabelStyle.Format = "HH:mm:ss";
        area.AxisX.MajorGrid.LineColor = Color.LightGray;
        area.AxisY.MajorGrid.LineColor = Color.LightGray;
    }

    private void OnSensorDataProcessed(SensorData data)
    {
        if (this.IsDisposed) return;

        if (this.InvokeRequired)
        {
            this.BeginInvoke(new Action(() => OnSensorDataProcessed(data)));
            return;
        }

        DateTime now = DateTime.Now;
        AddDataPointToCharts(now, data.Temperature, data.Humidity, data.SoilMoisture, data.LightLevel);
        RemoveOldDataPoints();

        lblStatus.Text = $"Đồng bộ thời gian thực thành công (Lần cuối: {now:HH:mm:ss})";
    }

    private void AddDataPointToCharts(DateTime timestamp, float temp, float hum, int soil, int light)
    {
        double xVal = timestamp.ToOADate();

        chartTemp.Series["Temperature"].Points.AddXY(xVal, temp);
        chartHum.Series["Humidity"].Points.AddXY(xVal, hum);
        chartSoil.Series["SoilMoisture"].Points.AddXY(xVal, soil);
        chartLight.Series["LightLevel"].Points.AddXY(xVal, light);
    }

    private void RemoveOldDataPoints()
    {
        double oneHourAgo = DateTime.Now.AddHours(-1).ToOADate();

        RemoveFromSeries(chartTemp.Series["Temperature"], oneHourAgo);
        RemoveFromSeries(chartHum.Series["Humidity"], oneHourAgo);
        RemoveFromSeries(chartSoil.Series["SoilMoisture"], oneHourAgo);
        RemoveFromSeries(chartLight.Series["LightLevel"], oneHourAgo);

        chartTemp.ResetAutoValues();
        chartHum.ResetAutoValues();
        chartSoil.ResetAutoValues();
        chartLight.ResetAutoValues();
    }

    private void RemoveFromSeries(Series series, double limit)
    {
        while (series.Points.Count > 0 && series.Points[0].XValue < limit)
        {
            series.Points.RemoveAt(0);
        }
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        _businessService.SensorDataProcessed -= OnSensorDataProcessed;
        base.OnFormClosing(e);
    }
}
