using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using NuvotonIcpTool;
using QsfpDigitalDiagnosticMonitoring;

namespace IntegratedGuiV2
{
    public partial class CustomerAndMpForm : KryptonForm
    {

        private MainForm mainForm;

        public CustomerAndMpForm()
        {
            InitializeComponent();

            mainForm = new MainForm(true);
            cProgressBar1.Value = 0;
            cProgressBar2.Value = 0;
        }

        private void MainForm_ReadStateUpdated(object sender, string e)
        {
            lCh1Message.Text = e; // MainForm 送出 ReadStateUpdated event，update to Label.text
        }

        private void MainForm_ProgressUpdated(object sender, int e)
        {
            cProgressBar1.Value = e;
            cProgressBar1.Text = cProgressBar1.Value.ToString() + "%";
        }

        private void _RemoteInitial()
        {
            mainForm.cbInfomation.Checked = true;
            mainForm.cbCorrector.Checked = true;
            mainForm.cbDdm.Checked = true;
            mainForm.cbMemDump.Checked = true;
            mainForm.cbProductSelect.SelectedIndex = 2; // for PICe4.0
            mainForm.cbTxIcConfig.Checked = true;
            mainForm.cbRxIcConfig.Checked = true;
        }

        private void _RemoteControl()
        {
            int errorCountCh1 = 0;
            int errorCountCh2 = 0;

            _RemoteInitial();
            mainForm.ReadStateUpdated += MainForm_ReadStateUpdated;
            mainForm.ProgressValue += MainForm_ProgressUpdated;

            errorCountCh1 = mainForm._GlobalRead();

            lCh1EC.Text = errorCountCh1.ToString();
            lCh2EC.Text = errorCountCh2.ToString();

        }

        private void bLogin_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                bLogin.Enabled = false;
                _RemoteControl();

            }
            finally
            {
                Cursor.Current = Cursors.Default;
                bLogin.Enabled = true;
            }
        }


        private void _SwitchOrNot()
        {
            if (rbSingle.Checked == true)
            {
                cProgressBar1.Visible = true;
                cProgressBar2.Visible = false;
                lCh1Message.Visible = true;
                lCh2Message.Visible = false;
                lCh1EC.Visible = true;
                lCh2EC.Visible = false;
            }
            else if ( rbBoth.Checked == true)
            {
                cProgressBar1.Visible = true ;
                cProgressBar2.Visible = true;
                lCh1Message.Visible = true;
                lCh2Message.Visible = true;
                lCh1EC.Visible = true;
                lCh2EC.Visible = true;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            _SwitchOrNot();
        }

        private void rbBoth_CheckedChanged(object sender, EventArgs e)
        {
            _SwitchOrNot();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            /*
                cProgressBar1.Value += 1;
                cProgressBar1.Text = cProgressBar1.Value.ToString() + "%";

                cProgressBar2.Value += 2;
                cProgressBar2.Text = cProgressBar2.Value.ToString() + "%";

                if (cProgressBar1.Value == 100 || cProgressBar2.Value == 100)
                {
                    timer1.Enabled = false;
                }
            */

        }
    }
}
