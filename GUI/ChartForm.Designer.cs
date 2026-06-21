namespace Winform.GUI;

partial class ChartForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.DataVisualization.Charting.Chart chartTemp;
    private System.Windows.Forms.DataVisualization.Charting.Chart chartHum;
    private System.Windows.Forms.DataVisualization.Charting.Chart chartSoil;
    private System.Windows.Forms.DataVisualization.Charting.Chart chartLight;
    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.ToolStripStatusLabel lblStatus;

    /// <summary>
    /// Clean up any resources being used.
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
    /// Required method for Designer modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
        System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
        System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
        System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
        System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
        System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
        System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
        System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
        System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
        System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
        System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
        System.Windows.Forms.DataVisualization.Charting.Title title4 = new System.Windows.Forms.DataVisualization.Charting.Title();
        this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
        this.chartTemp = new System.Windows.Forms.DataVisualization.Charting.Chart();
        this.chartHum = new System.Windows.Forms.DataVisualization.Charting.Chart();
        this.chartSoil = new System.Windows.Forms.DataVisualization.Charting.Chart();
        this.chartLight = new System.Windows.Forms.DataVisualization.Charting.Chart();
        this.statusStrip1 = new System.Windows.Forms.StatusStrip();
        this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
        this.tableLayoutPanel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.chartTemp)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.chartHum)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.chartSoil)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.chartLight)).BeginInit();
        this.statusStrip1.SuspendLayout();
        this.SuspendLayout();
        // 
        // tableLayoutPanel1
        // 
        this.tableLayoutPanel1.ColumnCount = 2;
        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
        this.tableLayoutPanel1.Controls.Add(this.chartTemp, 0, 0);
        this.tableLayoutPanel1.Controls.Add(this.chartHum, 1, 0);
        this.tableLayoutPanel1.Controls.Add(this.chartSoil, 0, 1);
        this.tableLayoutPanel1.Controls.Add(this.chartLight, 1, 1);
        this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
        this.tableLayoutPanel1.Name = "tableLayoutPanel1";
        this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10, 10, 10, 30);
        this.tableLayoutPanel1.RowCount = 2;
        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
        this.tableLayoutPanel1.Size = new System.Drawing.Size(984, 661);
        this.tableLayoutPanel1.TabIndex = 0;
        // 
        // chartTemp
        // 
        chartArea1.Name = "ChartArea1";
        this.chartTemp.ChartAreas.Add(chartArea1);
        this.chartTemp.Dock = System.Windows.Forms.DockStyle.Fill;
        this.chartTemp.Location = new System.Drawing.Point(13, 13);
        this.chartTemp.Name = "chartTemp";
        series1.BorderWidth = 2;
        series1.ChartArea = "ChartArea1";
        series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
        series1.Color = System.Drawing.Color.Crimson;
        series1.Name = "Temperature";
        series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
        this.chartTemp.Series.Add(series1);
        this.chartTemp.Size = new System.Drawing.Size(476, 299);
        this.chartTemp.TabIndex = 0;
        title1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        title1.ForeColor = System.Drawing.Color.Crimson;
        title1.Name = "Title1";
        title1.Text = "Nhiệt độ không khí (°C)";
        this.chartTemp.Titles.Add(title1);
        // 
        // chartHum
        // 
        chartArea2.Name = "ChartArea1";
        this.chartHum.ChartAreas.Add(chartArea2);
        this.chartHum.Dock = System.Windows.Forms.DockStyle.Fill;
        this.chartHum.Location = new System.Drawing.Point(495, 13);
        this.chartHum.Name = "chartHum";
        series2.BorderWidth = 2;
        series2.ChartArea = "ChartArea1";
        series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
        series2.Color = System.Drawing.Color.DodgerBlue;
        series2.Name = "Humidity";
        series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
        this.chartHum.Series.Add(series2);
        this.chartHum.Size = new System.Drawing.Size(476, 299);
        this.chartHum.TabIndex = 1;
        title2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        title2.ForeColor = System.Drawing.Color.DodgerBlue;
        title2.Name = "Title1";
        title2.Text = "Độ ẩm không khí (%)";
        this.chartHum.Titles.Add(title2);
        // 
        // chartSoil
        // 
        chartArea3.Name = "ChartArea1";
        this.chartSoil.ChartAreas.Add(chartArea3);
        this.chartSoil.Dock = System.Windows.Forms.DockStyle.Fill;
        this.chartSoil.Location = new System.Drawing.Point(13, 318);
        this.chartSoil.Name = "chartSoil";
        series3.BorderWidth = 2;
        series3.ChartArea = "ChartArea1";
        series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
        series3.Color = System.Drawing.Color.ForestGreen;
        series3.Name = "SoilMoisture";
        series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
        this.chartSoil.Series.Add(series3);
        this.chartSoil.Size = new System.Drawing.Size(476, 300);
        this.chartSoil.TabIndex = 2;
        title3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        title3.ForeColor = System.Drawing.Color.ForestGreen;
        title3.Name = "Title1";
        title3.Text = "Độ ẩm đất (%)";
        this.chartSoil.Titles.Add(title3);
        // 
        // chartLight
        // 
        chartArea4.Name = "ChartArea1";
        this.chartLight.ChartAreas.Add(chartArea4);
        this.chartLight.Dock = System.Windows.Forms.DockStyle.Fill;
        this.chartLight.Location = new System.Drawing.Point(495, 318);
        this.chartLight.Name = "chartLight";
        series4.BorderWidth = 2;
        series4.ChartArea = "ChartArea1";
        series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
        series4.Color = System.Drawing.Color.Goldenrod;
        series4.Name = "LightLevel";
        series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
        this.chartLight.Series.Add(series4);
        this.chartLight.Size = new System.Drawing.Size(476, 300);
        this.chartLight.TabIndex = 3;
        title4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        title4.ForeColor = System.Drawing.Color.Goldenrod;
        title4.Name = "Title1";
        title4.Text = "Cường độ ánh sáng (%)";
        this.chartLight.Titles.Add(title4);
        // 
        // statusStrip1
        // 
        this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        this.lblStatus});
        this.statusStrip1.Location = new System.Drawing.Point(0, 639);
        this.statusStrip1.Name = "statusStrip1";
        this.statusStrip1.Size = new System.Drawing.Size(984, 22);
        this.statusStrip1.TabIndex = 1;
        this.statusStrip1.Text = "statusStrip1";
        // 
        // lblStatus
        // 
        this.lblStatus.Name = "lblStatus";
        this.lblStatus.Size = new System.Drawing.Size(206, 17);
        this.lblStatus.Text = "Đang tải dữ liệu lịch sử từ Firebase...";
        // 
        // ChartForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(984, 661);
        this.Controls.Add(this.statusStrip1);
        this.Controls.Add(this.tableLayoutPanel1);
        this.Name = "ChartForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Biểu đồ Giám sát Thông số Thời gian thực (1 Giờ gần đây)";
        this.Load += new System.EventHandler(this.ChartForm_Load);
        this.tableLayoutPanel1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.chartTemp)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.chartHum)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.chartSoil)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.chartLight)).EndInit();
        this.statusStrip1.ResumeLayout(false);
        this.statusStrip1.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion
}
