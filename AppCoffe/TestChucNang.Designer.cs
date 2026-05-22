namespace AppCoffe
{
    partial class TestChucNang
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
            this.ucQuanLyMenu1 = new AppCoffe.UserControls.ucQuanLyMenu();
            this.SuspendLayout();
            // 
            // ucQuanLyMenu1
            // 
            this.ucQuanLyMenu1.Location = new System.Drawing.Point(0, 0);
            this.ucQuanLyMenu1.Name = "ucQuanLyMenu1";
            this.ucQuanLyMenu1.Size = new System.Drawing.Size(879, 529);
            this.ucQuanLyMenu1.TabIndex = 0;
            // 
            // TestChucNang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 625);
            this.Controls.Add(this.ucQuanLyMenu1);
            this.Name = "TestChucNang";
            this.Text = "TestChucNang";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.ucQuanLyMenu ucQuanLyMenu1;
    }
}