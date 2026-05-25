namespace AppCoffe.UserControls
{
    partial class frmPopupTreo
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picAnhMon = new System.Windows.Forms.PictureBox();
            this.numSoLuong = new System.Windows.Forms.NumericUpDown();
            this.txtGhiChu = new System.Windows.Forms.RichTextBox();
            this.lblMon = new System.Windows.Forms.Label();
            this.lblGia = new System.Windows.Forms.Label();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnXacNhan = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picAnhMon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).BeginInit();
            this.SuspendLayout();
            // 
            // picAnhMon
            // 
            this.picAnhMon.Dock = System.Windows.Forms.DockStyle.Top;
            this.picAnhMon.Location = new System.Drawing.Point(0, 0);
            this.picAnhMon.Name = "picAnhMon";
            this.picAnhMon.Size = new System.Drawing.Size(407, 175);
            this.picAnhMon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAnhMon.TabIndex = 0;
            this.picAnhMon.TabStop = false;
            // 
            // numSoLuong
            // 
            this.numSoLuong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.numSoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.numSoLuong.Location = new System.Drawing.Point(339, 229);
            this.numSoLuong.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSoLuong.Name = "numSoLuong";
            this.numSoLuong.Size = new System.Drawing.Size(56, 30);
            this.numSoLuong.TabIndex = 1;
            this.numSoLuong.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGhiChu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.txtGhiChu.Location = new System.Drawing.Point(10, 315);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(385, 57);
            this.txtGhiChu.TabIndex = 2;
            this.txtGhiChu.Text = "";
            // 
            // lblMon
            // 
            this.lblMon.AutoSize = true;
            this.lblMon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblMon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(56)))), ((int)(((byte)(175)))));
            this.lblMon.Location = new System.Drawing.Point(12, 188);
            this.lblMon.Name = "lblMon";
            this.lblMon.Size = new System.Drawing.Size(73, 28);
            this.lblMon.TabIndex = 4;
            this.lblMon.Text = "MÓN: ";
            // 
            // lblGia
            // 
            this.lblGia.AutoSize = true;
            this.lblGia.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblGia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(56)))), ((int)(((byte)(175)))));
            this.lblGia.Location = new System.Drawing.Point(12, 228);
            this.lblGia.Name = "lblGia";
            this.lblGia.Size = new System.Drawing.Size(51, 28);
            this.lblGia.TabIndex = 5;
            this.lblGia.Text = "GIÁ:";
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblSoLuong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(56)))), ((int)(((byte)(175)))));
            this.lblSoLuong.Location = new System.Drawing.Point(212, 228);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(121, 28);
            this.lblSoLuong.TabIndex = 6;
            this.lblSoLuong.Text = "SỐ LƯỢNG:";
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblGhiChu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(56)))), ((int)(((byte)(175)))));
            this.lblGhiChu.Location = new System.Drawing.Point(12, 281);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(94, 28);
            this.lblGhiChu.TabIndex = 7;
            this.lblGhiChu.Text = "GHI CHÚ";
            // 
            // btnHuy
            // 
            this.btnHuy.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnHuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(212)))), ((int)(((byte)(252)))));
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnHuy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(56)))), ((int)(((byte)(175)))));
            this.btnHuy.Location = new System.Drawing.Point(10, 378);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(112, 57);
            this.btnHuy.TabIndex = 8;
            this.btnHuy.Text = "HỦY";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnXacNhan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(212)))), ((int)(((byte)(252)))));
            this.btnXacNhan.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnXacNhan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(56)))), ((int)(((byte)(175)))));
            this.btnXacNhan.Location = new System.Drawing.Point(140, 378);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(255, 57);
            this.btnXacNhan.TabIndex = 9;
            this.btnXacNhan.Text = "XÁC NHẬN";
            this.btnXacNhan.UseVisualStyleBackColor = false;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // frmPopupTreo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(212)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(407, 456);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.lblGhiChu);
            this.Controls.Add(this.lblSoLuong);
            this.Controls.Add(this.lblGia);
            this.Controls.Add(this.lblMon);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.numSoLuong);
            this.Controls.Add(this.picAnhMon);
            this.ForeColor = System.Drawing.Color.Fuchsia;
            this.MinimizeBox = false;
            this.Name = "frmPopupTreo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Món Ăn";
            this.Load += new System.EventHandler(this.frmPopupTreo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picAnhMon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picAnhMon;
        private System.Windows.Forms.NumericUpDown numSoLuong;
        private System.Windows.Forms.RichTextBox txtGhiChu;
        private System.Windows.Forms.Label lblMon;
        private System.Windows.Forms.Label lblGia;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnXacNhan;
    }
}