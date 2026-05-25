namespace AppCoffe.UserControls
{
    partial class ucThongKe
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.cboSapXep = new System.Windows.Forms.ComboBox();
            this.lblSapXep = new System.Windows.Forms.Label();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.dgvThongKe = new System.Windows.Forms.DataGridView();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblTongDoanhThu = new System.Windows.Forms.Label();
            this.btnQuayLai = new System.Windows.Forms.Button();
            this.pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFilter
            // 
            this.pnlFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(78)))));
            this.pnlFilter.Controls.Add(this.btnThongKe);
            this.pnlFilter.Controls.Add(this.lblTimKiem);
            this.pnlFilter.Controls.Add(this.txtTimKiem);
            this.pnlFilter.Controls.Add(this.cboSapXep);
            this.pnlFilter.Controls.Add(this.lblSapXep);
            this.pnlFilter.Controls.Add(this.dtpDenNgay);
            this.pnlFilter.Controls.Add(this.lblDenNgay);
            this.pnlFilter.Controls.Add(this.dtpTuNgay);
            this.pnlFilter.Controls.Add(this.lblTuNgay);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Padding = new System.Windows.Forms.Padding(16, 12, 16, 8);
            this.pnlFilter.Size = new System.Drawing.Size(900, 113);
            this.pnlFilter.TabIndex = 0;
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTimKiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(188)))), ((int)(((byte)(209)))));
            this.lblTimKiem.Location = new System.Drawing.Point(11, 73);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(101, 28);
            this.lblTimKiem.TabIndex = 8;
            this.lblTimKiem.Text = "Tìm món:";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTimKiem.Location = new System.Drawing.Point(108, 71);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(235, 34);
            this.txtTimKiem.TabIndex = 7;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // cboSapXep
            // 
            this.cboSapXep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSapXep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.cboSapXep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSapXep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboSapXep.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cboSapXep.FormattingEnabled = true;
            this.cboSapXep.Items.AddRange(new object[] {
            "Thành tiền giảm dần",
            "Thành tiền tăng dần",
            "Số lượng bán giảm dần",
            "Số lượng bán tăng dần"});
            this.cboSapXep.Location = new System.Drawing.Point(471, 69);
            this.cboSapXep.Name = "cboSapXep";
            this.cboSapXep.Size = new System.Drawing.Size(247, 36);
            this.cboSapXep.TabIndex = 6;
            this.cboSapXep.SelectedIndexChanged += new System.EventHandler(this.cboSapXep_SelectedIndexChanged);
            // 
            // lblSapXep
            // 
            this.lblSapXep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSapXep.AutoSize = true;
            this.lblSapXep.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblSapXep.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(188)))), ((int)(((byte)(209)))));
            this.lblSapXep.Location = new System.Drawing.Point(374, 69);
            this.lblSapXep.Name = "lblSapXep";
            this.lblSapXep.Size = new System.Drawing.Size(91, 28);
            this.lblSapXep.TabIndex = 5;
            this.lblSapXep.Text = "Sắp xếp:";
            // 
            // btnThongKe
            // 
            this.btnThongKe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThongKe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(78)))));
            this.btnThongKe.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThongKe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(188)))), ((int)(((byte)(209)))));
            this.btnThongKe.Location = new System.Drawing.Point(744, 3);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(137, 64);
            this.btnThongKe.TabIndex = 4;
            this.btnThongKe.Text = "Thống Kê";
            this.btnThongKe.UseVisualStyleBackColor = false;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpDenNgay.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDenNgay.Location = new System.Drawing.Point(420, 15);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(174, 34);
            this.dtpDenNgay.TabIndex = 3;
            this.dtpDenNgay.TabStop = false;
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblDenNgay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(188)))), ((int)(((byte)(209)))));
            this.lblDenNgay.Location = new System.Drawing.Point(312, 17);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(113, 28);
            this.lblDenNgay.TabIndex = 2;
            this.lblDenNgay.Text = "Đến ngày :";
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpTuNgay.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTuNgay.Location = new System.Drawing.Point(108, 15);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(174, 34);
            this.dtpTuNgay.TabIndex = 1;
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTuNgay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(188)))), ((int)(((byte)(209)))));
            this.lblTuNgay.Location = new System.Drawing.Point(13, 17);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(100, 28);
            this.lblTuNgay.TabIndex = 0;
            this.lblTuNgay.Text = "Từ ngày :";
            // 
            // dgvThongKe
            // 
            this.dgvThongKe.AllowUserToAddRows = false;
            this.dgvThongKe.AllowUserToDeleteRows = false;
            this.dgvThongKe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThongKe.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvThongKe.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvThongKe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThongKe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvThongKe.Location = new System.Drawing.Point(0, 113);
            this.dgvThongKe.Name = "dgvThongKe";
            this.dgvThongKe.ReadOnly = true;
            this.dgvThongKe.RowHeadersWidth = 51;
            this.dgvThongKe.RowTemplate.Height = 24;
            this.dgvThongKe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvThongKe.Size = new System.Drawing.Size(900, 369);
            this.dgvThongKe.TabIndex = 1;
            this.dgvThongKe.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvThongKe_CellContentClick);
            this.dgvThongKe.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvThongKe_DataBindingComplete);
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(78)))));
            this.pnlBottom.Controls.Add(this.btnQuayLai);
            this.pnlBottom.Controls.Add(this.lblTongDoanhThu);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 482);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(16, 10, 16, 10);
            this.pnlBottom.Size = new System.Drawing.Size(900, 68);
            this.pnlBottom.TabIndex = 2;
            // 
            // lblTongDoanhThu
            // 
            this.lblTongDoanhThu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTongDoanhThu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(78)))));
            this.lblTongDoanhThu.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTongDoanhThu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(188)))), ((int)(((byte)(209)))));
            this.lblTongDoanhThu.Location = new System.Drawing.Point(261, 13);
            this.lblTongDoanhThu.Name = "lblTongDoanhThu";
            this.lblTongDoanhThu.Size = new System.Drawing.Size(620, 38);
            this.lblTongDoanhThu.TabIndex = 0;
            this.lblTongDoanhThu.Text = "Tổng Doanh Thu: 0 VNĐ";
            this.lblTongDoanhThu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnQuayLai
            // 
            this.btnQuayLai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(78)))));
            this.btnQuayLai.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnQuayLai.FlatAppearance.BorderSize = 2;
            this.btnQuayLai.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnQuayLai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(188)))), ((int)(((byte)(209)))));
            this.btnQuayLai.Location = new System.Drawing.Point(3, 6);
            this.btnQuayLai.Name = "btnQuayLai";
            this.btnQuayLai.Size = new System.Drawing.Size(144, 55);
            this.btnQuayLai.TabIndex = 7;
            this.btnQuayLai.Text = "Quay lại";
            this.btnQuayLai.UseVisualStyleBackColor = false;
            this.btnQuayLai.Click += new System.EventHandler(this.btnQuayLai_Click);
            // 
            // ucThongKe
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.dgvThongKe);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlFilter);
            this.MaximumSize = new System.Drawing.Size(900, 550);
            this.MinimumSize = new System.Drawing.Size(900, 550);
            this.Name = "ucThongKe";
            this.Size = new System.Drawing.Size(900, 550);
            this.Load += new System.EventHandler(this.ucThongKe_Load);
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.DataGridView dgvThongKe;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label lblTongDoanhThu;
        private System.Windows.Forms.ComboBox cboSapXep;
        private System.Windows.Forms.Label lblSapXep;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnQuayLai;
    }
}
