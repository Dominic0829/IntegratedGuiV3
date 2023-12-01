using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using I2cMasterInterface;

using ComponentFactory.Krypton.Toolkit;

namespace IntegratedGuiV2
{
    public partial class MainForm : KryptonForm
    {
        private I2cMaster i2cMaster = new I2cMaster();

        private int _I2cConnect()
        {
            if (i2cMaster.ConnectApi(400) < 0)
                return -1;

            cbConnect.Checked = true;

            return 0;
        }

        private int _I2cDisconnect()
        {
            if (i2cMaster.DisconnectApi() < 0)
                return -1;

            cbConnect.Checked = false;

            return 0;
        }

        private void cbConnect_CheckedChanged(object sender, EventArgs e)
        {
            if (cbConnect.Checked == true)
                _I2cConnect();
            else
                _I2cDisconnect();
        }

        public MainForm()
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(1080, 850);

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        
    }
}
