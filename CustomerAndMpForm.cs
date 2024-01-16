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
        }

        private void MainForm_ReadStateUpdated(object sender, string e)
        {
            // 當 Form B 發送 ReadStateUpdated 事件時，更新對應的 Label 文本
            lCh1Message.Text = e;
        }

        private void _RemoteInitial()
        {
            mainForm.cbInfomation.Checked = true;
            mainForm.cbCorrector.Checked = true;
            mainForm.cbDdm.Checked = true;
            mainForm.cbMemDump.Checked = true;
        }

        private void _RemoteControl()
        {
            _RemoteInitial();
            mainForm.ReadStateUpdated += MainForm_ReadStateUpdated;
            mainForm._GlobalRead();

        }

        private void bLogin_Click(object sender, EventArgs e)
        {
            bLogin.Enabled = false;

            _RemoteControl();
            bLogin.Enabled = true;
        }


        private void _SwitchOrNot()
        {
            if (rbSingle.Checked == true)
            {
                cProgressBar1.Visible = true;
                cProgressBar2.Visible = false;
                lCh1Message.Visible = true;
                lCh2Message.Visible = false;
            }
            else if ( rbBoth.Checked == true)
            {
                cProgressBar1.Visible = true ;
                cProgressBar2.Visible = true;
                lCh1Message.Visible = true;
                lCh2Message.Visible = true;
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

        
    }
}
