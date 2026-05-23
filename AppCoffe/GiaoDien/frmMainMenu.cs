using AppCoffe.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppCoffe.GiaoDien
{
    public partial class frmMainMenu : Form
    {
        private string userRole;
        public frmMainMenu(string role)
        {
            InitializeComponent();
            this.userRole = role;
        }
        private void frmMainMenu_Load(object sender, EventArgs e)
        {
            if (userRole == "Staff")
            {
                btnThongke.Visible = false;
            }
        }

        private void btnKtraban_Click(object sender, EventArgs e)
        {
            ucSoDoBan sodo = new ucSoDoBan();
            sodo.ShowDialog();
        }

        private void btndangxuat_Click(object sender, EventArgs e)
        {
            this.Close();
            frmLogin login = new frmLogin();
            login.Show();
        }
    }
}
