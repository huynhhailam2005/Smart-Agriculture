using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Winform.BLL.Models;
using Winform.BLL.Services;

namespace Winform.GUI;

public partial class ScheduleForm : Form
{
    private readonly AgriBusinessService _businessService;
    private Dictionary<string, DeviceSchedule> _schedules = new Dictionary<string, DeviceSchedule>();

    public ScheduleForm(AgriBusinessService businessService)
    {
        InitializeComponent();
        _businessService = businessService;
    }

    private void ScheduleForm_Load(object sender, EventArgs e)
    {
        // Load local schedules from businessService
        _schedules = new Dictionary<string, DeviceSchedule>(_businessService.GetSchedules());
        PopulateGrid();
    }

    private void PopulateGrid()
    {
        dgvSchedules.Rows.Clear();
        foreach (var sch in _schedules.Values)
        {
            string deviceText = GetDeviceDisplayName(sch.Device);
            string modeText = GetModeDisplayName(sch);
            string activeText = sch.Enabled ? "Kích hoạt" : "Vô hiệu hóa";

            dgvSchedules.Rows.Add(
                sch.Id,
                deviceText,
                modeText,
                sch.StartTime,
                $"{sch.DurationMinutes} phút",
                activeText
            );
        }
    }

    private string GetDeviceDisplayName(string device)
    {
        return device.ToLower() switch
        {
            "pump" => "Máy bơm",
            "fan" => "Quạt gió",
            "light" => "Đèn chiếu",
            _ => device
        };
    }

    private string GetModeDisplayName(DeviceSchedule sch)
    {
        switch (sch.Mode.ToLower())
        {
            case "once":
                return $"Một lần ({sch.OnceDate})";
            case "daily":
                return "Hàng ngày";
            case "weekly":
                if (sch.RepeatDays == null || sch.RepeatDays.Count == 0) return "Hàng tuần";
                var dayNames = sch.RepeatDays.Select(d => GetDayOfWeekName(d));
                return $"Hàng tuần ({string.Join(", ", dayNames)})";
            default:
                return sch.Mode;
        }
    }

    private string GetDayOfWeekName(int day)
    {
        return day switch
        {
            1 => "T2",
            2 => "T3",
            3 => "T4",
            4 => "T5",
            5 => "T6",
            6 => "T7",
            7 => "CN",
            _ => day.ToString()
        };
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        using (var editForm = new ScheduleEditForm())
        {
            if (editForm.ShowDialog(this) == DialogResult.OK)
            {
                var newSchedule = editForm.Schedule;
                _schedules[newSchedule.Id] = newSchedule;
                PopulateGrid();
            }
        }
    }

    private void btnEdit_Click(object sender, EventArgs e)
    {
        if (dgvSchedules.CurrentRow == null)
        {
            MessageBox.Show("Vui lòng chọn một lịch trình để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        string? id = dgvSchedules.CurrentRow.Cells[0].Value?.ToString();
        if (!string.IsNullOrEmpty(id) && _schedules.TryGetValue(id, out var schedule))
        {
            using (var editForm = new ScheduleEditForm(schedule))
            {
                if (editForm.ShowDialog(this) == DialogResult.OK)
                {
                    _schedules[id] = editForm.Schedule;
                    PopulateGrid();
                }
            }
        }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (dgvSchedules.CurrentRow == null)
        {
            MessageBox.Show("Vui lòng chọn một lịch trình để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        string? id = dgvSchedules.CurrentRow.Cells[0].Value?.ToString();
        if (string.IsNullOrEmpty(id)) return;
        var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa lịch trình này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        
        if (confirmResult == DialogResult.Yes)
        {
            _schedules.Remove(id);
            PopulateGrid();
        }
    }

    private async void btnSaveSync_Click(object sender, EventArgs e)
    {
        btnSaveSync.Enabled = false;
        btnSaveSync.Text = "Đang đồng bộ...";
        
        try
        {
            await _businessService.SaveSchedulesToFirebaseAsync(_schedules);
            MessageBox.Show("Đã đồng bộ lịch trình thành công lên Firebase!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi đồng bộ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnSaveSync.Enabled = true;
            btnSaveSync.Text = "Đồng bộ lên Cloud";
        }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}
