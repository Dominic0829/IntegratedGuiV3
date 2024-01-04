using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntegratedGuiV2
{
    public partial class AdminAuthentication : Form
    {
        private const string AdminPassword = "543"; // 帳管密碼
        WaitFormFunc loadingForm = new WaitFormFunc();

        public AdminAuthentication()
        {
            InitializeComponent();
            //tbAdminPassword.KeyDown += TbAdminPassword_KeyDown;
        }

        private void bAuthenticate_Click(object sender, EventArgs e)
        {
            loadingForm.Show(this);

            if (tbAdminPassword.Text == AdminPassword)
            {
                new AccountsManagement().Show();
                this.Hide();
                loadingForm.Close();
            }
            else
            {
                loadingForm.Close();
                MessageBox.Show("Incorrect Administrator Password. Please try again.", "Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbAdminPassword.Text = "";
                tbAdminPassword.Focus();
            }
        }

        private void TbAdminPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                bAuthenticate_Click(sender, e);
            }
        }

        private void lBackToLogin_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
    }
}
