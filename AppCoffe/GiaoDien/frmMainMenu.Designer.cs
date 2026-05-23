namespace AppCoffe.GiaoDien
{
    partial class frmMainMenu
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
            this.panelMenu = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.GtnGoimon = new System.Windows.Forms.Button();
            this.btnKtraban = new System.Windows.Forms.Button();
            this.btnMenu = new System.Windows.Forms.Button();
            this.btnThongke = new System.Windows.Forms.Button();
            this.btndangxuat = new System.Windows.Forms.Button();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelMenu.Controls.Add(this.btndangxuat);
            this.panelMenu.Controls.Add(this.btnThongke);
            this.panelMenu.Controls.Add(this.btnMenu);
            this.panelMenu.Controls.Add(this.btnKtraban);
            this.panelMenu.Controls.Add(this.GtnGoimon);
            this.panelMenu.Controls.Add(this.label1);
            this.panelMenu.Location = new System.Drawing.Point(145, 24);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(772, 529);
            this.panelMenu.TabIndex = 0;
            this.panelMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMenu_Paint);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(772, 77);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mixi Coffe";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GtnGoimon
            // 
            this.GtnGoimon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GtnGoimon.Location = new System.Drawing.Point(23, 161);
            this.GtnGoimon.Name = "GtnGoimon";
            this.GtnGoimon.Size = new System.Drawing.Size(732, 55);
            this.GtnGoimon.TabIndex = 1;
            this.GtnGoimon.Text = "Gọi món";
            this.GtnGoimon.UseVisualStyleBackColor = true;
            // 
            // btnKtraban
            // 
            this.btnKtraban.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKtraban.Location = new System.Drawing.Point(23, 233);
            this.btnKtraban.Name = "btnKtraban";
            this.btnKtraban.Size = new System.Drawing.Size(732, 55);
            this.btnKtraban.TabIndex = 2;
            this.btnKtraban.Text = "Kiểm tra bàn";
            this.btnKtraban.UseVisualStyleBackColor = true;
            // 
            // btnMenu
            // 
            this.btnMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMenu.Location = new System.Drawing.Point(23, 311);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(732, 55);
            this.btnMenu.TabIndex = 3;
            this.btnMenu.Text = "Menu";
            this.btnMenu.UseVisualStyleBackColor = true;
            // 
            // btnThongke
            // 
            this.btnThongke.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThongke.Location = new System.Drawing.Point(23, 383);
            this.btnThongke.Name = "btnThongke";
            this.btnThongke.Size = new System.Drawing.Size(732, 55);
            this.btnThongke.TabIndex = 4;
            this.btnThongke.Text = "Thống kê";
            this.btnThongke.UseVisualStyleBackColor = true;
            // 
            // btndangxuat
            // 
            this.btndangxuat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btndangxuat.Location = new System.Drawing.Point(23, 459);
            this.btndangxuat.Name = "btndangxuat";
            this.btndangxuat.Size = new System.Drawing.Size(732, 55);
            this.btndangxuat.TabIndex = 5;
            this.btndangxuat.Text = "Đăng xuất";
            this.btndangxuat.UseVisualStyleBackColor = true;
            // 
            // frmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 625);
            this.Controls.Add(this.panelMenu);
            this.Name = "frmMainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMainMenu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btndangxuat;
        private System.Windows.Forms.Button btnThongke;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Button btnKtraban;
        private System.Windows.Forms.Button GtnGoimon;
    }
}