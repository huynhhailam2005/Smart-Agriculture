namespace Winform.GUI;

partial class ScheduleEditForm
{
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.Label lblDevice;
    private System.Windows.Forms.ComboBox cboDevice;
    private System.Windows.Forms.Label lblMode;
    private System.Windows.Forms.ComboBox cboMode;
    private System.Windows.Forms.CheckBox chkEnabled;
    
    private System.Windows.Forms.Panel pnlOnce;
    private System.Windows.Forms.Label lblOnceDate;
    private System.Windows.Forms.DateTimePicker dtpOnceDate;
    
    private System.Windows.Forms.Panel pnlWeekly;
    private System.Windows.Forms.Label lblWeeklyDays;
    private System.Windows.Forms.CheckBox chkMon;
    private System.Windows.Forms.CheckBox chkTue;
    private System.Windows.Forms.CheckBox chkWed;
    private System.Windows.Forms.CheckBox chkThu;
    private System.Windows.Forms.CheckBox chkFri;
    private System.Windows.Forms.CheckBox chkSat;
    private System.Windows.Forms.CheckBox chkSun;

    private System.Windows.Forms.Label lblStartTime;
    private System.Windows.Forms.DateTimePicker dtpStartTime;
    private System.Windows.Forms.Label lblDuration;
    private System.Windows.Forms.NumericUpDown numDuration;
    private System.Windows.Forms.Label lblMinutes;

    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnCancel;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.lblDevice = new System.Windows.Forms.Label();
        this.cboDevice = new System.Windows.Forms.ComboBox();
        this.lblMode = new System.Windows.Forms.Label();
        this.cboMode = new System.Windows.Forms.ComboBox();
        this.chkEnabled = new System.Windows.Forms.CheckBox();
        this.pnlOnce = new System.Windows.Forms.Panel();
        this.lblOnceDate = new System.Windows.Forms.Label();
        this.dtpOnceDate = new System.Windows.Forms.DateTimePicker();
        this.pnlWeekly = new System.Windows.Forms.Panel();
        this.lblWeeklyDays = new System.Windows.Forms.Label();
        this.chkMon = new System.Windows.Forms.CheckBox();
        this.chkTue = new System.Windows.Forms.CheckBox();
        this.chkWed = new System.Windows.Forms.CheckBox();
        this.chkThu = new System.Windows.Forms.CheckBox();
        this.chkFri = new System.Windows.Forms.CheckBox();
        this.chkSat = new System.Windows.Forms.CheckBox();
        this.chkSun = new System.Windows.Forms.CheckBox();
        this.lblStartTime = new System.Windows.Forms.Label();
        this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
        this.lblDuration = new System.Windows.Forms.Label();
        this.numDuration = new System.Windows.Forms.NumericUpDown();
        this.lblMinutes = new System.Windows.Forms.Label();
        this.btnSave = new System.Windows.Forms.Button();
        this.btnCancel = new System.Windows.Forms.Button();
        this.pnlOnce.SuspendLayout();
        this.pnlWeekly.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.numDuration)).BeginInit();
        this.SuspendLayout();
        // 
        // lblDevice
        // 
        this.lblDevice.AutoSize = true;
        this.lblDevice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.lblDevice.Location = new System.Drawing.Point(20, 20);
        this.lblDevice.Name = "lblDevice";
        this.lblDevice.Size = new System.Drawing.Size(91, 15);
        this.lblDevice.TabIndex = 0;
        this.lblDevice.Text = "Chọn Thiết bị:";
        // 
        // cboDevice
        // 
        this.cboDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cboDevice.FormattingEnabled = true;
        this.cboDevice.Location = new System.Drawing.Point(130, 17);
        this.cboDevice.Name = "cboDevice";
        this.cboDevice.Size = new System.Drawing.Size(200, 23);
        this.cboDevice.TabIndex = 1;
        // 
        // lblMode
        // 
        this.lblMode.AutoSize = true;
        this.lblMode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.lblMode.Location = new System.Drawing.Point(20, 60);
        this.lblMode.Name = "lblMode";
        this.lblMode.Size = new System.Drawing.Size(78, 15);
        this.lblMode.TabIndex = 2;
        this.lblMode.Text = "Kiểu lặp lại:";
        // 
        // cboMode
        // 
        this.cboMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cboMode.FormattingEnabled = true;
        this.cboMode.Location = new System.Drawing.Point(130, 57);
        this.cboMode.Name = "cboMode";
        this.cboMode.Size = new System.Drawing.Size(200, 23);
        this.cboMode.TabIndex = 3;
        this.cboMode.SelectedIndexChanged += new System.EventHandler(this.cboMode_SelectedIndexChanged);
        // 
        // chkEnabled
        // 
        this.chkEnabled.AutoSize = true;
        this.chkEnabled.Checked = true;
        this.chkEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
        this.chkEnabled.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.chkEnabled.Location = new System.Drawing.Point(130, 100);
        this.chkEnabled.Name = "chkEnabled";
        this.chkEnabled.Size = new System.Drawing.Size(126, 19);
        this.chkEnabled.TabIndex = 4;
        this.chkEnabled.Text = "Kích hoạt lịch này";
        this.chkEnabled.UseVisualStyleBackColor = true;
        // 
        // pnlOnce
        // 
        this.pnlOnce.Controls.Add(this.lblOnceDate);
        this.pnlOnce.Controls.Add(this.dtpOnceDate);
        this.pnlOnce.Location = new System.Drawing.Point(15, 130);
        this.pnlOnce.Name = "pnlOnce";
        this.pnlOnce.Size = new System.Drawing.Size(330, 40);
        this.pnlOnce.TabIndex = 5;
        // 
        // lblOnceDate
        // 
        this.lblOnceDate.AutoSize = true;
        this.lblOnceDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.lblOnceDate.Location = new System.Drawing.Point(5, 12);
        this.lblOnceDate.Name = "lblOnceDate";
        this.lblOnceDate.Size = new System.Drawing.Size(68, 15);
        this.lblOnceDate.TabIndex = 0;
        this.lblOnceDate.Text = "Chọn ngày:";
        // 
        // dtpOnceDate
        // 
        this.dtpOnceDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
        this.dtpOnceDate.Location = new System.Drawing.Point(115, 6);
        this.dtpOnceDate.Name = "dtpOnceDate";
        this.dtpOnceDate.Size = new System.Drawing.Size(200, 23);
        this.dtpOnceDate.TabIndex = 1;
        // 
        // pnlWeekly
        // 
        this.pnlWeekly.Controls.Add(this.lblWeeklyDays);
        this.pnlWeekly.Controls.Add(this.chkMon);
        this.pnlWeekly.Controls.Add(this.chkTue);
        this.pnlWeekly.Controls.Add(this.chkWed);
        this.pnlWeekly.Controls.Add(this.chkThu);
        this.pnlWeekly.Controls.Add(this.chkFri);
        this.pnlWeekly.Controls.Add(this.chkSat);
        this.pnlWeekly.Controls.Add(this.chkSun);
        this.pnlWeekly.Location = new System.Drawing.Point(15, 130);
        this.pnlWeekly.Name = "pnlWeekly";
        this.pnlWeekly.Size = new System.Drawing.Size(330, 80);
        this.pnlWeekly.TabIndex = 6;
        this.pnlWeekly.Visible = false;
        // 
        // lblWeeklyDays
        // 
        this.lblWeeklyDays.AutoSize = true;
        this.lblWeeklyDays.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.lblWeeklyDays.Location = new System.Drawing.Point(5, 5);
        this.lblWeeklyDays.Name = "lblWeeklyDays";
        this.lblWeeklyDays.Size = new System.Drawing.Size(89, 15);
        this.lblWeeklyDays.TabIndex = 0;
        this.lblWeeklyDays.Text = "Lặp vào các thứ:";
        // 
        // chkMon
        // 
        this.chkMon.AutoSize = true;
        this.chkMon.Location = new System.Drawing.Point(115, 4);
        this.chkMon.Name = "chkMon";
        this.chkMon.Size = new System.Drawing.Size(48, 19);
        this.chkMon.TabIndex = 1;
        this.chkMon.Text = "Th 2";
        this.chkMon.UseVisualStyleBackColor = true;
        // 
        // chkTue
        // 
        this.chkTue.AutoSize = true;
        this.chkTue.Location = new System.Drawing.Point(170, 4);
        this.chkTue.Name = "chkTue";
        this.chkTue.Size = new System.Drawing.Size(48, 19);
        this.chkTue.TabIndex = 2;
        this.chkTue.Text = "Th 3";
        this.chkTue.UseVisualStyleBackColor = true;
        // 
        // chkWed
        // 
        this.chkWed.AutoSize = true;
        this.chkWed.Location = new System.Drawing.Point(225, 4);
        this.chkWed.Name = "chkWed";
        this.chkWed.Size = new System.Drawing.Size(48, 19);
        this.chkWed.TabIndex = 3;
        this.chkWed.Text = "Th 4";
        this.chkWed.UseVisualStyleBackColor = true;
        // 
        // chkThu
        // 
        this.chkThu.AutoSize = true;
        this.chkThu.Location = new System.Drawing.Point(280, 4);
        this.chkThu.Name = "chkThu";
        this.chkThu.Size = new System.Drawing.Size(48, 19);
        this.chkThu.TabIndex = 4;
        this.chkThu.Text = "Th 5";
        this.chkThu.UseVisualStyleBackColor = true;
        // 
        // chkFri
        // 
        this.chkFri.AutoSize = true;
        this.chkFri.Location = new System.Drawing.Point(115, 29);
        this.chkFri.Name = "chkFri";
        this.chkFri.Size = new System.Drawing.Size(48, 19);
        this.chkFri.TabIndex = 5;
        this.chkFri.Text = "Th 6";
        this.chkFri.UseVisualStyleBackColor = true;
        // 
        // chkSat
        // 
        this.chkSat.AutoSize = true;
        this.chkSat.Location = new System.Drawing.Point(170, 29);
        this.chkSat.Name = "chkSat";
        this.chkSat.Size = new System.Drawing.Size(48, 19);
        this.chkSat.TabIndex = 6;
        this.chkSat.Text = "Th 7";
        this.chkSat.UseVisualStyleBackColor = true;
        // 
        // chkSun
        // 
        this.chkSun.AutoSize = true;
        this.chkSun.Location = new System.Drawing.Point(225, 29);
        this.chkSun.Name = "chkSun";
        this.chkSun.Size = new System.Drawing.Size(42, 19);
        this.chkSun.TabIndex = 7;
        this.chkSun.Text = "CN";
        this.chkSun.UseVisualStyleBackColor = true;
        // 
        // lblStartTime
        // 
        this.lblStartTime.AutoSize = true;
        this.lblStartTime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.lblStartTime.Location = new System.Drawing.Point(20, 230);
        this.lblStartTime.Name = "lblStartTime";
        this.lblStartTime.Size = new System.Drawing.Size(83, 15);
        this.lblStartTime.TabIndex = 7;
        this.lblStartTime.Text = "Giờ bắt đầu:";
        // 
        // dtpStartTime
        // 
        this.dtpStartTime.CustomFormat = "HH:mm";
        this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        this.dtpStartTime.ShowUpDown = true;
        this.dtpStartTime.Location = new System.Drawing.Point(130, 227);
        this.dtpStartTime.Name = "dtpStartTime";
        this.dtpStartTime.Size = new System.Drawing.Size(100, 23);
        this.dtpStartTime.TabIndex = 8;
        // 
        // lblDuration
        // 
        this.lblDuration.AutoSize = true;
        this.lblDuration.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.lblDuration.Location = new System.Drawing.Point(20, 270);
        this.lblDuration.Name = "lblDuration";
        this.lblDuration.Size = new System.Drawing.Size(101, 15);
        this.lblDuration.TabIndex = 9;
        this.lblDuration.Text = "Thời lượng chạy:";
        // 
        // numDuration
        // 
        this.numDuration.Location = new System.Drawing.Point(130, 268);
        this.numDuration.Maximum = new decimal(new int[] {
            1440,
            0,
            0,
            0});
        this.numDuration.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
        this.numDuration.Name = "numDuration";
        this.numDuration.Size = new System.Drawing.Size(100, 23);
        this.numDuration.TabIndex = 10;
        this.numDuration.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
        // 
        // lblMinutes
        // 
        this.lblMinutes.AutoSize = true;
        this.lblMinutes.Location = new System.Drawing.Point(238, 270);
        this.lblMinutes.Name = "lblMinutes";
        this.lblMinutes.Size = new System.Drawing.Size(31, 15);
        this.lblMinutes.TabIndex = 11;
        this.lblMinutes.Text = "phút";
        // 
        // btnSave
        // 
        this.btnSave.BackColor = System.Drawing.Color.ForestGreen;
        this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.btnSave.ForeColor = System.Drawing.Color.White;
        this.btnSave.Location = new System.Drawing.Point(60, 320);
        this.btnSave.Name = "btnSave";
        this.btnSave.Size = new System.Drawing.Size(110, 35);
        this.btnSave.TabIndex = 12;
        this.btnSave.Text = "Lưu cấu hình";
        this.btnSave.UseVisualStyleBackColor = false;
        this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
        // 
        // btnCancel
        // 
        this.btnCancel.BackColor = System.Drawing.Color.Gray;
        this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.btnCancel.ForeColor = System.Drawing.Color.White;
        this.btnCancel.Location = new System.Drawing.Point(190, 320);
        this.btnCancel.Name = "btnCancel";
        this.btnCancel.Size = new System.Drawing.Size(110, 35);
        this.btnCancel.TabIndex = 13;
        this.btnCancel.Text = "Hủy bỏ";
        this.btnCancel.UseVisualStyleBackColor = false;
        this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
        // 
        // ScheduleEditForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(360, 380);
        this.Controls.Add(this.btnCancel);
        this.Controls.Add(this.btnSave);
        this.Controls.Add(this.lblMinutes);
        this.Controls.Add(this.numDuration);
        this.Controls.Add(this.lblDuration);
        this.Controls.Add(this.dtpStartTime);
        this.Controls.Add(this.lblStartTime);
        this.Controls.Add(this.pnlWeekly);
        this.Controls.Add(this.pnlOnce);
        this.Controls.Add(this.chkEnabled);
        this.Controls.Add(this.cboMode);
        this.Controls.Add(this.lblMode);
        this.Controls.Add(this.cboDevice);
        this.Controls.Add(this.lblDevice);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "ScheduleEditForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Cấu hình Chi Tiết Lịch Trình";
        this.Load += new System.EventHandler(this.ScheduleEditForm_Load);
        this.pnlOnce.ResumeLayout(false);
        this.pnlOnce.PerformLayout();
        this.pnlWeekly.ResumeLayout(false);
        this.pnlWeekly.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.numDuration)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}
