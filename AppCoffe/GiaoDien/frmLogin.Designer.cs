namespace AppCoffe.GiaoDien
{
    partial class frmLogin
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
            this.txtdangnhap = new System.Windows.Forms.TextBox();
            this.btnXacnhan = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtmatkhau = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtdangnhap
            // 
            this.txtdangnhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.txtdangnhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtdangnhap.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtdangnhap.Location = new System.Drawing.Point(387, 166);
            this.txtdangnhap.Margin = new System.Windows.Forms.Padding(4);
            this.txtdangnhap.Name = "txtdangnhap";
            this.txtdangnhap.Size = new System.Drawing.Size(212, 34);
            this.txtdangnhap.TabIndex = 2;
            // 
            // btnXacnhan
            // 
            this.btnXacnhan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXacnhan.BackColor = System.Drawing.Color.White;
            this.btnXacnhan.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnXacnhan.ForeColor = System.Drawing.Color.Black;
            this.btnXacnhan.Location = new System.Drawing.Point(499, 317);
            this.btnXacnhan.Margin = new System.Windows.Forms.Padding(4);
            this.btnXacnhan.Name = "btnXacnhan";
            this.btnXacnhan.Size = new System.Drawing.Size(188, 60);
            this.btnXacnhan.TabIndex = 6;
            this.btnXacnhan.Text = "Đăng Nhập";
            this.btnXacnhan.UseVisualStyleBackColor = false;
            this.btnXacnhan.Click += new System.EventHandler(this.btnXacnhan_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Controls.Add(this.btnXacnhan);
            this.panel2.Controls.Add(this.txtmatkhau);
            this.panel2.Controls.Add(this.txtdangnhap);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(-134, -70);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(810, 429);
            this.panel2.TabIndex = 5;
            // 
            // txtmatkhau
            // 
            this.txtmatkhau.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.txtmatkhau.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtmatkhau.Location = new System.Drawing.Point(387, 249);
            this.txtmatkhau.Margin = new System.Windows.Forms.Padding(4);
            this.txtmatkhau.Name = "txtmatkhau";
            this.txtmatkhau.PasswordChar = '*';
            this.txtmatkhau.Size = new System.Drawing.Size(212, 38);
            this.txtmatkhau.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(200, 156);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 46);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tài Khoản :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(200, 241);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 46);
            this.label3.TabIndex = 1;
            this.label3.Text = "Mật Khẩu :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // frmLogin
            // 
            this.AcceptButton = this.btnXacnhan;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(638, 347);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtdangnhap;
        private System.Windows.Forms.Button btnXacnhan;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtmatkhau;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}