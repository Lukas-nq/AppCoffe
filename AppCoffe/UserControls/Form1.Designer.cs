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
            this.lblTieuDe = new System.Windows.Forms.Label();
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
            this.picAnhMon.Location = new System.Drawing.Point(17, 61);
            this.picAnhMon.Name = "picAnhMon";
            this.picAnhMon.Size = new System.Drawing.Size(302, 130);
            this.picAnhMon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAnhMon.TabIndex = 0;
            this.picAnhMon.TabStop = false;
            // 
            // numSoLuong
            // 
            this.numSoLuong.Location = new System.Drawing.Point(526, 169);
            this.numSoLuong.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSoLuong.Name = "numSoLuong";
            this.numSoLuong.Size = new System.Drawing.Size(120, 22);
            this.numSoLuong.TabIndex = 1;
            this.numSoLuong.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(12, 260);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(405, 64);
            this.txtGhiChu.TabIndex = 2;
            this.txtGhiChu.Text = "";
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTieuDe.Location = new System.Drawing.Point(203, 9);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(342, 29);
            this.lblTieuDe.TabIndex = 3;
            this.lblTieuDe.Text = "TÙY CHỈNH MÓN ĐÃ CHỌN";
            // 
            // lblMon
            // 
            this.lblMon.AutoSize = true;
            this.lblMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblMon.Location = new System.Drawing.Point(378, 61);
            this.lblMon.Name = "lblMon";
            this.lblMon.Size = new System.Drawing.Size(66, 22);
            this.lblMon.TabIndex = 4;
            this.lblMon.Text = "MÓN: ";
            // 
            // lblGia
            // 
            this.lblGia.AutoSize = true;
            this.lblGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblGia.Location = new System.Drawing.Point(378, 110);
            this.lblGia.Name = "lblGia";
            this.lblGia.Size = new System.Drawing.Size(49, 22);
            this.lblGia.TabIndex = 5;
            this.lblGia.Text = "GIÁ:";
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblSoLuong.Location = new System.Drawing.Point(378, 169);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(119, 22);
            this.lblSoLuong.TabIndex = 6;
            this.lblSoLuong.Text = "SỐ LƯỢNG:";
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblGhiChu.Location = new System.Drawing.Point(12, 226);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(101, 25);
            this.lblGhiChu.TabIndex = 7;
            this.lblGhiChu.Text = "GHI CHÚ";
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(164, 364);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(150, 57);
            this.btnHuy.TabIndex = 8;
            this.btnHuy.Text = "HỦY";
            this.btnHuy.UseVisualStyleBackColor = true;
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Location = new System.Drawing.Point(435, 364);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(150, 57);
            this.btnXacNhan.TabIndex = 9;
            this.btnXacNhan.Text = "XÁC NHẬN";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            // 
            // frmPopupTreo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.lblGhiChu);
            this.Controls.Add(this.lblSoLuong);
            this.Controls.Add(this.lblGia);
            this.Controls.Add(this.lblMon);
            this.Controls.Add(this.lblTieuDe);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.numSoLuong);
            this.Controls.Add(this.picAnhMon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPopupTreo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Xác nhận chọn món";
            ((System.ComponentModel.ISupportInitialize)(this.picAnhMon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picAnhMon;
        private System.Windows.Forms.NumericUpDown numSoLuong;
        private System.Windows.Forms.RichTextBox txtGhiChu;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblMon;
        private System.Windows.Forms.Label lblGia;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnXacNhan;
    }
}