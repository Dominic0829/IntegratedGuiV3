using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace IntegratedGuiV2
{
    public partial class LoginForm1 : Form
    {

        static string decryptionPassword = "c369";  // password for account management
        OleDbConnection dbConnect = new OleDbConnection($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=dbUsers.mdb;Jet OLEDB:Database Password={decryptionPassword}");
        OleDbCommand dbCommand = new OleDbCommand();
        OleDbDataAdapter dbAdapter = new OleDbDataAdapter();
        WaitFormFunc loadingForm = new WaitFormFunc();

        public LoginForm1()
        {
            InitializeComponent();
        }

        private void bLogin_Click(object sender, EventArgs e)
        {
            loadingForm.Show(this);

            dbConnect.Open();
            string login = "SELECT * FROM ConnproMembers WHERE dbId= @dbId AND dbPassword = @dbPassword";
            dbCommand = new OleDbCommand(login, dbConnect);
            dbCommand.Parameters.AddWithValue("@dbId", tbId.Text);
            dbCommand.Parameters.AddWithValue("@dbPassword", tbPassword.Text);
            OleDbDataReader dbReader = dbCommand.ExecuteReader();


            if (dbReader.Read())
            {
                new MainForm().Show();
                this.Hide();
                loadingForm.Close();
            }
            else
            {
                loadingForm.Close();
                MessageBox.Show("Oops, seems like the account or password is not valid, Please try again.", "Login failed.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbId.Text = "";
                tbPassword.Text = "";
                tbId.Focus();
            }

            dbConnect.Close();
        }

        private void TbLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                bLogin_Click(sender, e);
            }
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            tbId.Text = "";
            tbPassword.Text = "";
            tbId.Focus();
        }

        private void cbShowPasswrod_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowPasswrod.Checked)
            {
                tbPassword.PasswordChar = '\0';
            }
            else
            {
                tbPassword.PasswordChar = '•';
            }
        }

        private void lCreateAccount_Click(object sender, EventArgs e)
        {
            this.Hide();

            AdminAuthentication adminAuthForm = new AdminAuthentication();
            adminAuthForm.FormClosed += (s, args) => {
                this.Show(); // Re LoginForm1
            };
            adminAuthForm.ShowDialog();
        }

        private void lExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
