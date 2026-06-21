using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Winform.BLL.Models;

namespace Winform.GUI;

public partial class ScheduleEditForm : Form
{
    public DeviceSchedule Schedule { get; private set; }

    public ScheduleEditForm(DeviceSchedule? schedule = null)
    {
        InitializeComponent();

        if (schedule != null)
        {
            // Edit mode: copy properties
            Schedule = new DeviceSchedule
            {
                Id = schedule.Id,
                Device = schedule.Device,
                Enabled = schedule.Enabled,
                Mode = schedule.Mode,
                OnceDate = schedule.OnceDate,
                RepeatDays = new List<int>(schedule.RepeatDays),
                StartTime = schedule.StartTime,
                DurationMinutes = schedule.DurationMinutes
            };
        }
        else
        {
            // Add mode: create a new one
            Schedule = new DeviceSchedule
            {
                Id = "sch_" + DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
                Enabled = true,
                Device = "pump",
                Mode = "once",
                OnceDate = DateTime.Now.ToString("yyyy-MM-dd"),
                StartTime = DateTime.Now.ToString("HH:mm"),
                DurationMinutes = 15
            };
        }
    }

    private void ScheduleEditForm_Load(object sender, EventArgs e)
    {
        // Setup ComboBoxes
        cboDevice.Items.Clear();
        cboDevice.Items.Add(new KeyValuePair<string, string>("pump", "Máy bơm"));
        cboDevice.Items.Add(new KeyValuePair<string, string>("fan", "Quạt gió"));
        cboDevice.Items.Add(new KeyValuePair<string, string>("light", "Đèn chiếu"));
        cboDevice.DisplayMember = "Value";
        cboDevice.ValueMember = "Key";

        cboMode.Items.Clear();
        cboMode.Items.Add(new KeyValuePair<string, string>("once", "Một lần"));
        cboMode.Items.Add(new KeyValuePair<string, string>("daily", "Hàng ngày"));
        cboMode.Items.Add(new KeyValuePair<string, string>("weekly", "Hàng tuần"));
        cboMode.DisplayMember = "Value";
        cboMode.ValueMember = "Key";

        // Bind Schedule data to UI
        // Select Device
        for (int i = 0; i < cboDevice.Items.Count; i++)
        {
            if (cboDevice.Items[i] is KeyValuePair<string, string> deviceKvp && deviceKvp.Key == Schedule.Device)
            {
                cboDevice.SelectedIndex = i;
                break;
            }
        }
        if (cboDevice.SelectedIndex == -1 && cboDevice.Items.Count > 0) cboDevice.SelectedIndex = 0;

        // Select Mode
        for (int i = 0; i < cboMode.Items.Count; i++)
        {
            if (cboMode.Items[i] is KeyValuePair<string, string> modeKvp && modeKvp.Key == Schedule.Mode)
            {
                cboMode.SelectedIndex = i;
                break;
            }
        }
        if (cboMode.SelectedIndex == -1 && cboMode.Items.Count > 0) cboMode.SelectedIndex = 0;

        // Enabled status
        chkEnabled.Checked = Schedule.Enabled;

        // Once date
        if (DateTime.TryParse(Schedule.OnceDate, out DateTime onceDateVal))
        {
            dtpOnceDate.Value = onceDateVal;
        }

        // Start time
        if (TimeSpan.TryParse(Schedule.StartTime, out TimeSpan startTimeVal))
        {
            dtpStartTime.Value = DateTime.Today.Add(startTimeVal);
        }

        // Duration
        numDuration.Value = Math.Clamp(Schedule.DurationMinutes, numDuration.Minimum, numDuration.Maximum);

        // Repeat days (Weekly)
        var repDays = Schedule.RepeatDays;
        chkMon.Checked = repDays.Contains(1);
        chkTue.Checked = repDays.Contains(2);
        chkWed.Checked = repDays.Contains(3);
        chkThu.Checked = repDays.Contains(4);
        chkFri.Checked = repDays.Contains(5);
        chkSat.Checked = repDays.Contains(6);
        chkSun.Checked = repDays.Contains(7);

        UpdateUIVisibility();
    }

    private void cboMode_SelectedIndexChanged(object sender, EventArgs e)
    {
        UpdateUIVisibility();
    }

    private void UpdateUIVisibility()
    {
        if (cboMode.SelectedItem is KeyValuePair<string, string> modeSel)
        {
            string modeKey = modeSel.Key;
            pnlOnce.Visible = modeKey == "once";
            pnlWeekly.Visible = modeKey == "weekly";
        }
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        if (cboDevice.SelectedItem == null || cboMode.SelectedItem == null)
        {
            MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Gather UI fields
        if (cboDevice.SelectedItem is KeyValuePair<string, string> deviceSel)
        {
            Schedule.Device = deviceSel.Key;
        }
        if (cboMode.SelectedItem is KeyValuePair<string, string> modeSelVal)
        {
            Schedule.Mode = modeSelVal.Key;
        }
        Schedule.Enabled = chkEnabled.Checked;
        Schedule.OnceDate = dtpOnceDate.Value.ToString("yyyy-MM-dd");
        Schedule.StartTime = dtpStartTime.Value.ToString("HH:mm");
        Schedule.DurationMinutes = (int)numDuration.Value;

        // Gather Repeat Days
        Schedule.RepeatDays.Clear();
        if (chkMon.Checked) Schedule.RepeatDays.Add(1);
        if (chkTue.Checked) Schedule.RepeatDays.Add(2);
        if (chkWed.Checked) Schedule.RepeatDays.Add(3);
        if (chkThu.Checked) Schedule.RepeatDays.Add(4);
        if (chkFri.Checked) Schedule.RepeatDays.Add(5);
        if (chkSat.Checked) Schedule.RepeatDays.Add(6);
        if (chkSun.Checked) Schedule.RepeatDays.Add(7);

        if (Schedule.Mode == "weekly" && Schedule.RepeatDays.Count == 0)
        {
            MessageBox.Show("Vui lòng chọn ít nhất một thứ trong tuần để lặp lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        this.DialogResult = DialogResult.OK;
        this.Close();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
    }
}
