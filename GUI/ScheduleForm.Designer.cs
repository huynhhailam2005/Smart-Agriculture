namespace Winform.GUI;

partial class ScheduleForm
{
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.DataGridView dgvSchedules;
    private System.Windows.Forms.DataGridViewTextBoxColumn colId;
    private System.Windows.Forms.DataGridViewTextBoxColumn colDevice;
    private System.Windows.Forms.DataGridViewTextBoxColumn colMode;
    private System.Windows.Forms.DataGridViewTextBoxColumn colStartTime;
    private System.Windows.Forms.DataGridViewTextBoxColumn colDuration;
    private System.Windows.Forms.DataGridViewTextBoxColumn colActive;

    private System.Windows.Forms.Button btnAdd;
    private System.Windows.Forms.Button btnEdit;
    private System.Windows.Forms.Button btnDelete;
    private System.Windows.Forms.Button btnSaveSync;
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
        this.dgvSchedules = new System.Windows.Forms.DataGridView();
        this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.colDevice = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.colMode = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.colStartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.colDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.colActive = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.btnAdd = new System.Windows.Forms.Button();
        this.btnEdit = new System.Windows.Forms.Button();
        this.btnDelete = new System.Windows.Forms.Button();
        this.btnSaveSync = new System.Windows.Forms.Button();
        this.btnCancel = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)(this.dgvSchedules)).BeginInit();
        this.SuspendLayout();
        // 
        // dgvSchedules
        // 
        this.dgvSchedules.AllowUserToAddRows = false;
        this.dgvSchedules.AllowUserToDeleteRows = false;
        this.dgvSchedules.AllowUserToResizeRows = false;
        this.dgvSchedules.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvSchedules.BackgroundColor = System.Drawing.Color.White;
        this.dgvSchedules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvSchedules.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colDevice,
            this.colMode,
            this.colStartTime,
            this.colDuration,
            this.colActive
        });
        this.dgvSchedules.Location = new System.Drawing.Point(12, 12);
        this.dgvSchedules.MultiSelect = false;
        this.dgvSchedules.Name = "dgvSchedules";
        this.dgvSchedules.ReadOnly = true;
        this.dgvSchedules.RowHeadersVisible = false;
        this.dgvSchedules.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.dgvSchedules.Size = new System.Drawing.Size(660, 270);
        this.dgvSchedules.TabIndex = 0;
        // 
        // colId
        // 
        this.colId.HeaderText = "ID";
        this.colId.Name = "colId";
        this.colId.ReadOnly = true;
        this.colId.Visible = false;
        // 
        // colDevice
        // 
        this.colDevice.FillWeight = 85F;
        this.colDevice.HeaderText = "Thiết bị";
        this.colDevice.Name = "colDevice";
        this.colDevice.ReadOnly = true;
        // 
        // colMode
        // 
        this.colMode.FillWeight = 160F;
        this.colMode.HeaderText = "Chế độ lặp";
        this.colMode.Name = "colMode";
        this.colMode.ReadOnly = true;
        // 
        // colStartTime
        // 
        this.colStartTime.FillWeight = 80F;
        this.colStartTime.HeaderText = "Bắt đầu";
        this.colStartTime.Name = "colStartTime";
        this.colStartTime.ReadOnly = true;
        // 
        // colDuration
        // 
        this.colDuration.FillWeight = 85F;
        this.colDuration.HeaderText = "Thời lượng";
        this.colDuration.Name = "colDuration";
        this.colDuration.ReadOnly = true;
        // 
        // colActive
        // 
        this.colActive.FillWeight = 90F;
        this.colActive.HeaderText = "Trạng thái";
        this.colActive.Name = "colActive";
        this.colActive.ReadOnly = true;
        // 
        // btnAdd
        // 
        this.btnAdd.BackColor = System.Drawing.Color.DodgerBlue;
        this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.btnAdd.ForeColor = System.Drawing.Color.White;
        this.btnAdd.Location = new System.Drawing.Point(12, 295);
        this.btnAdd.Name = "btnAdd";
        this.btnAdd.Size = new System.Drawing.Size(100, 35);
        this.btnAdd.TabIndex = 1;
        this.btnAdd.Text = "Thêm mới";
        this.btnAdd.UseVisualStyleBackColor = false;
        this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
        // 
        // btnEdit
        // 
        this.btnEdit.BackColor = System.Drawing.Color.Orange;
        this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.btnEdit.ForeColor = System.Drawing.Color.White;
        this.btnEdit.Location = new System.Drawing.Point(125, 295);
        this.btnEdit.Name = "btnEdit";
        this.btnEdit.Size = new System.Drawing.Size(100, 35);
        this.btnEdit.TabIndex = 2;
        this.btnEdit.Text = "Chỉnh sửa";
        this.btnEdit.UseVisualStyleBackColor = false;
        this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
        // 
        // btnDelete
        // 
        this.btnDelete.BackColor = System.Drawing.Color.Crimson;
        this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.btnDelete.ForeColor = System.Drawing.Color.White;
        this.btnDelete.Location = new System.Drawing.Point(238, 295);
        this.btnDelete.Name = "btnDelete";
        this.btnDelete.Size = new System.Drawing.Size(100, 35);
        this.btnDelete.TabIndex = 3;
        this.btnDelete.Text = "Xóa bỏ";
        this.btnDelete.UseVisualStyleBackColor = false;
        this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
        // 
        // btnSaveSync
        // 
        this.btnSaveSync.BackColor = System.Drawing.Color.ForestGreen;
        this.btnSaveSync.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnSaveSync.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.btnSaveSync.ForeColor = System.Drawing.Color.White;
        this.btnSaveSync.Location = new System.Drawing.Point(400, 295);
        this.btnSaveSync.Name = "btnSaveSync";
        this.btnSaveSync.Size = new System.Drawing.Size(150, 35);
        this.btnSaveSync.TabIndex = 4;
        this.btnSaveSync.Text = "Đồng bộ lên Cloud";
        this.btnSaveSync.UseVisualStyleBackColor = false;
        this.btnSaveSync.Click += new System.EventHandler(this.btnSaveSync_Click);
        // 
        // btnCancel
        // 
        this.btnCancel.BackColor = System.Drawing.Color.Gray;
        this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.btnCancel.ForeColor = System.Drawing.Color.White;
        this.btnCancel.Location = new System.Drawing.Point(572, 295);
        this.btnCancel.Name = "btnCancel";
        this.btnCancel.Size = new System.Drawing.Size(100, 35);
        this.btnCancel.TabIndex = 5;
        this.btnCancel.Text = "Đóng lại";
        this.btnCancel.UseVisualStyleBackColor = false;
        this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
        // 
        // ScheduleForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(684, 345);
        this.Controls.Add(this.btnCancel);
        this.Controls.Add(this.btnSaveSync);
        this.Controls.Add(this.btnDelete);
        this.Controls.Add(this.btnEdit);
        this.Controls.Add(this.btnAdd);
        this.Controls.Add(this.dgvSchedules);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "ScheduleForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Quản lý Lịch trình hoạt động thiết bị";
        this.Load += new System.EventHandler(this.ScheduleForm_Load);
        ((System.ComponentModel.ISupportInitialize)(this.dgvSchedules)).EndInit();
        this.ResumeLayout(false);
    }
}
