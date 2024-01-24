using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using ComponentFactory.Krypton.Toolkit;
using I2cMasterInterface;
using NuvotonIcpTool;
using QsfpDigitalDiagnosticMonitoring;

namespace IntegratedGuiV2
{
    public partial class CustomerAndMpForm : KryptonForm
    {

        private MainForm mainForm;
        private UcNuvotonIcpTool ucNuvotonIcpTool;
        private int SequenceIndexA = 0;
        private int SequenceIndexB = 0;
        private bool DoubleSide = false;

        public CustomerAndMpForm()
        {
            InitializeComponent();

            mainForm = new MainForm(true);
            ucNuvotonIcpTool = new UcNuvotonIcpTool();
            this.FormClosing += new FormClosingEventHandler(_FormClosing);

            cProgressBar1.Value = 0;
            cProgressBar2.Value = 0;
            this.Load += MainForm_Load;
            this.KeyPreview = true;
            this.KeyDown += _HideKeys_KeyDown;
            mainForm.I2cLinkInitalApi();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            bStart.Select();
        }

        private void _InitialUi()
        {
            lCh1EC.Text = "...";
            lCh2EC.Text = "...";
            lCh1Message.Text = "...";
            lCh2Message.Text = "...";
            cProgressBar1.Text = "Ch1";
            cProgressBar2.Text = "Ch2";
            cProgressBar1.Value = 0;
            cProgressBar2.Value = 0;
            bStart.Select();
        }

        private void _HideKeys_KeyDown(object sender, KeyEventArgs e)
        {
            Keys[] expectedKeysA = { Keys.NumPad4, Keys.NumPad4, Keys.NumPad6, Keys.NumPad6 };
            Keys[] expectedKeysB = { Keys.NumPad8, Keys.NumPad8, Keys.NumPad2, Keys.NumPad2 };

            if (e.KeyCode == expectedKeysA[SequenceIndexA])
            {
                SequenceIndexA++;
                if (CheckSequenceComplete(SequenceIndexA, expectedKeysA))
                {
                    OpenLoginForm();
                    ResetSequence();
                }
            }
            else if (e.KeyCode == expectedKeysB[SequenceIndexB])
            {
                SequenceIndexB++;
                if (CheckSequenceComplete(SequenceIndexB, expectedKeysB))
                {
                    OpenAdminAuthenticationForm();
                    ResetSequence();
                }
            }
            else
            {
                ResetSequence();
            }
        }

        private bool CheckSequenceComplete(int currentIndex, Keys[] expectedKeys)
        {
            return currentIndex == expectedKeys.Length;
        }

        private void OpenLoginForm()
        {
            LoginForm formB = new LoginForm();
            formB.Show();
            this.Hide();
        }

        private void OpenAdminAuthenticationForm()
        {
            AdminAuthentication formC = new AdminAuthentication();
            formC.Show();
            this.Hide();
        }

        private void ResetSequence()
        {
            SequenceIndexA = 0;
            SequenceIndexB = 0;
        }

        private void MainForm_ReadStateUpdated(object sender, string e)
        {
            if (lCh1Message.InvokeRequired)// 檢查是否需要 Invoke
            {
                // 使用 Invoke 在 UI 线程上執行更新
                Invoke(new Action(() =>
                {
                    lCh1Message.Text = e; // MainForm 送出 ReadStateUpdated event，update to Label.text
                }));
            }
            else
            {
                lCh1Message.Text = e;
            }
        }

        private void MainForm_ProgressUpdated(object sender, int e)
        {

            if (cProgressBar1.InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    cProgressBar1.Value = e;
                    cProgressBar1.Text = cProgressBar1.Value.ToString() + "%";
                }));
            }
            else
            {
                cProgressBar1.Value = e;
                cProgressBar1.Text = cProgressBar1.Value.ToString() + "%";
            }
        }

        private void UcNuvotonIcpTool_MessageUpdated(object sender, MessageEventArgs e)
        {
            BeginInvoke(new Action(() =>
            {
                lCh1Message.Text = e.Message;
                cProgressBar1.Value = e.ProgressValue;
                cProgressBar1.Text = cProgressBar1.Value.ToString() + "%";
            }));
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
            ucNuvotonIcpTool.tbAPROM.Text = lPath.Text; //臨時性安排!!
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
                DoubleSide = false;
            }
            else if ( rbBoth.Checked == true)
            {
                cProgressBar1.Visible = true ;
                cProgressBar2.Visible = true;
                lCh1Message.Visible = true;
                lCh2Message.Visible = true;
                lCh1EC.Visible = true;
                lCh2EC.Visible = true;
                DoubleSide = true;
            }
        }

        private void _LoadXmlFile()
        {
            string initialDirectory = AppDomain.CurrentDomain.BaseDirectory;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Files position";
                openFileDialog.Filter = "Xml Files (*.xml)|*.xml";
                openFileDialog.InitialDirectory = initialDirectory;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    tbFilePath.Text = openFileDialog.FileName;
                    _ParserXmlForProjectInformation(openFileDialog.FileName);
                }
            }
        }

        private void _ParserXmlForProjectInformation(string filePath)
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);

            XmlNode permissionsNode = xmlDoc.SelectSingleNode("//Premissions");
            string role = permissionsNode.Attributes["role"].Value;

            XmlNode productNode = xmlDoc.SelectSingleNode("//Product");
            string productName = productNode.Attributes["name"].Value;

            XmlNode binFileNode = xmlDoc.SelectSingleNode("//BinFile");
            string binFileName = binFileNode.Attributes["name"].Value;

            lMode.Text = role;
            lProduct.Text = productName;
            binFileName = currentDirectory + binFileName;
            lPath.Text = binFileName;
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            //Cursor.Current = Cursors.WaitCursor;
            _InitialUi();
            Thread.Sleep(130);

            try
            {
                bStart.Enabled = false;
                _RemoteControl();
            }
            finally
            {
               
                //Cursor.Current = Cursors.Default;
                bStart.Enabled = true;
            }
        }

        private void _RemoteControl()
        {
            string errorCountCh1R, errorCountCh1W = "";
            string errorCountCh2R, errorCountCh2W = "";
                

            if (_PathCheck(lPath))
            {
                _RemoteInitial();
                mainForm.ReadStateUpdated += MainForm_ReadStateUpdated;
                mainForm.ProgressValue += MainForm_ProgressUpdated;
                ucNuvotonIcpTool.MessageUpdated += UcNuvotonIcpTool_MessageUpdated;

                MessageBox.Show("CH1_Read_FwUpdate_Write");
                /*
                errorCountCh1R = mainForm._GlobalRead().ToString(); // Tack out DUT data
                lCh1EC.Text = $"R:{errorCountCh1R} ";

                ucNuvotonIcpTool.ConnectSingleApi(); // Link DUT
                ucNuvotonIcpTool.WriteStartApi(); // Firmware update

                errorCountCh1W = mainForm._GlobalWirte().ToString();
                lCh1EC.Text = $"R:{errorCountCh1R} /W:{errorCountCh1W} ";
                */
                lCh1Message.Text = "Update completed.";
                cProgressBar1.Value = 100;
                cProgressBar1.Text = "100%" ;

                if (DoubleSide)
                {
                    mainForm.i2cMaster.ChannelSetApi(2);
                    Thread.Sleep(500);
                    MessageBox.Show("CH2_Read_FwUpdate_Write");
                    /*
                    errorCountCh2R = mainForm._GlobalRead().ToString(); // Tack out DUT data
                    lCh2EC.Text = $"R:{errorCountCh2R} ";

                    ucNuvotonIcpTool.ConnectSingleApi(); // Link DUT
                    ucNuvotonIcpTool.WriteStartApi(); // Firmware update

                    errorCountCh2W = mainForm._GlobalWirte().ToString();
                    lCh2EC.Text = $"R:{errorCountCh2R} /W:{errorCountCh2W} ";
                    */
                    lCh2Message.Text = "Update completed.";
                    cProgressBar2.Value = 100;
                    cProgressBar2.Text = "100%";

                    mainForm.i2cMaster.ChannelSetApi(1);
                    Thread.Sleep(500);
                }
            }
        }

        private bool _PathCheck(System.Windows.Forms.Label lable)
        {
            string filePath = lable.Text;

            if (File.Exists(filePath))
            {
                if (Path.GetExtension(filePath).Equals(".bin", StringComparison.OrdinalIgnoreCase))
                    return true;
                else
                    MessageBox.Show("Please verify if there is an error in the format of the Config file.");
            }
            else
                MessageBox.Show("No file path specified. Please choose the file again.", "Config file", MessageBoxButtons.OK, MessageBoxIcon.Error);


            return false;
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

        private void tbFilePath_MouseClick(object sender, MouseEventArgs e)
        {
            _LoadXmlFile();
        }

        private void _FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                mainForm.I2cMasterDisconnectApi();
                Application.Exit();
            }
        }

    }
}
