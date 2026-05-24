namespace AppCoffe.UserControls
{
    partial class usCardMonAn
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
            this.picAnhMon = new System.Windows.Forms.PictureBox();
            this.lblTenMon = new System.Windows.Forms.Label();
            this.lblGiaMon = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picAnhMon)).BeginInit();
            this.SuspendLayout();
            // 
            // picAnhMon
            // 
            this.picAnhMon.Dock = System.Windows.Forms.DockStyle.Top;
            this.picAnhMon.Location = new System.Drawing.Point(0, 0);
            this.picAnhMon.Name = "picAnhMon";
            this.picAnhMon.Size = new System.Drawing.Size(56, 111);
            this.picAnhMon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAnhMon.TabIndex = 0;
            this.picAnhMon.TabStop = false;
            // 
            // lblTenMon
            // 
            this.lblTenMon.AccessibleName = "";
            this.lblTenMon.AutoSize = true;
            this.lblTenMon.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTenMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTenMon.Location = new System.Drawing.Point(0, 111);
            this.lblTenMon.Name = "lblTenMon";
            this.lblTenMon.Size = new System.Drawing.Size(81, 20);
            this.lblTenMon.TabIndex = 1;
            this.lblTenMon.Text = "Tên món";
            this.lblTenMon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTenMon.Click += new System.EventHandler(this.usCardMonAn_Click);
            // 
            // lblGiaMon
            // 
            this.lblGiaMon.AccessibleName = "";
            this.lblGiaMon.AutoSize = true;
            this.lblGiaMon.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblGiaMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblGiaMon.Location = new System.Drawing.Point(0, 427);
            this.lblGiaMon.Name = "lblGiaMon";
            this.lblGiaMon.Padding = new System.Windows.Forms.Padding(0, 0, 0, 30);
            this.lblGiaMon.Size = new System.Drawing.Size(79, 50);
            this.lblGiaMon.TabIndex = 2;
            this.lblGiaMon.Text = "Giá món";
            this.lblGiaMon.Click += new System.EventHandler(this.usCardMonAn_Click);
            // 
            // usCardMonAn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.lblGiaMon);
            this.Controls.Add(this.lblTenMon);
            this.Controls.Add(this.picAnhMon);
            this.Name = "usCardMonAn";
            this.Size = new System.Drawing.Size(56, 497);
            this.Click += new System.EventHandler(this.usCardMonAn_Click);
            ((System.ComponentModel.ISupportInitialize)(this.picAnhMon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picAnhMon;
        private System.Windows.Forms.Label lblTenMon;
        private System.Windows.Forms.Label lblGiaMon;
    }
}
