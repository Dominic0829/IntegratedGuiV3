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
using System.Web.UI;
using System.Windows.Forms;
using System.Xml;
using ComponentFactory.Krypton.Toolkit;
using I2cMasterInterface;
using NuvotonIcpTool;
using QsfpDigitalDiagnosticMonitoring;
using Rt145Rt146Config;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace IntegratedGuiV2
{
    public partial class CustomerAndMpForm : KryptonForm
    {
        private MainForm mainForm; // Assist processing for i2c communication
        private System.Windows.Forms.Timer timer;
        private int SequenceIndexA = 0;
        private int SequenceIndexB = 0;
        private bool DoubleSide = false;
        private int ProcessingChannel = 1;
        private bool DemoMode = false;
        private bool TestMode = false;
        private bool FirstRound = true;
        private bool RxPowerUpdate = false;
        private bool I2cConnected = false;

        private Thread RxPowerUpdateThread;
        private bool ContinueRxPowerUpdate = true;

        private void MainForm_MainMessageUpdated(object sender, MessageEventArgs e)
        {
            if (ProcessingChannel == 1)
            {
                BeginInvoke(new Action(() =>
                {
                    lCh1Message.Text = e.Message;
                    cProgressBar1.Value = e.ProgressValue;
                    cProgressBar1.Text = cProgressBar1.Value.ToString() + "%";
                }));
            }
            else if (ProcessingChannel == 2)
            {
                BeginInvoke(new Action(() =>
                {
                    lCh2Message.Text = e.Message;
                    cProgressBar2.Value = e.ProgressValue;
                    cProgressBar2.Text = cProgressBar2.Value.ToString() + "%";
                }));
            }
        }

        private void _MessageUpdate(string message, int number)
        {
            if (ProcessingChannel == 1)
            {
                    lCh1Message.Text = message;
                    cProgressBar1.Value = number;
                    cProgressBar1.Text = cProgressBar1.Value.ToString() + "%";
            }
            else if (ProcessingChannel == 2)
            {
                    lCh2Message.Text = message;
                    cProgressBar2.Value = number;
                    cProgressBar2.Text = cProgressBar2.Value.ToString() + "%";
            }
            Application.DoEvents();
        }

        public CustomerAndMpForm()
        {
            InitializeComponent();
           
            mainForm = new MainForm(true);
            this.FormClosing += new FormClosingEventHandler(_FormClosing);
            this.Size = new System.Drawing.Size(550, 220);
            cProgressBar1.Value = 0;
            cProgressBar2.Value = 0;
            this.Load += MainForm_Load;
            this.KeyPreview = true;
            this.KeyDown += _HideKeys_KeyDown;

            if (!(mainForm.I2cMasterConnectApi(true, true) < 0)) // (bool setMode, bool setPassword)
                I2cConnected = true;
            else
            {
                MessageBox.Show("I2c master connection failed.\nPlease check if the hardware configuration or UI is activated.",
                                "I2c master connection failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
                

            mainForm.ReadStateUpdated += MainForm_ReadStateUpdated;
            mainForm.ProgressValue += MainForm_ProgressUpdated;
            //ucNuvotonIcpTool.MessageUpdated += UcNuvotonIcpTool_MessageUpdated;
            mainForm.MainMessageUpdated += MainForm_MainMessageUpdated;
           
            //ucMainForm initial...
            if (TestMode)
            {
                bool beforeTestMode = mainForm.GetVarBoolStateFromNuvotonIcpApi("TestMode");
                mainForm.SetVarBoolStateToNuvotonIcpApi("TestMode", true);
                MessageBox.Show("Icp TestMode state...\n\nBefore: " + beforeTestMode
                                + "\n\nAfter: " + mainForm.GetVarBoolStateFromNuvotonIcpApi("TestMode")
                                );
                //mainForm?.SelectProduct("SAS4.0"); Force switch
                mainForm?.SetCheckBoxCheckedByNameApi("cbInfomation", false);
                mainForm?.SetCheckBoxCheckedByNameApi("cbTxIcConfig", false);
                mainForm?.SetCheckBoxCheckedByNameApi("cbRxIcConfig", true);

                var checkBoxStates = mainForm.GetCheckBoxStates();
                var items = String.Join(", ", mainForm.GetComboBoxItems());
                string selectedProduct = mainForm.GetSelectedProduct();


                var BeforecbInformation = checkBoxStates["cbInfomation"];
                var BeforecbTxIcConfig = checkBoxStates["cbTxIcConfig"];
                var BeforecbRxIcConfig = checkBoxStates["cbRxIcConfig"];
                var BeforeItems = items;
                var BeforeSelectedProducts = selectedProduct;

                mainForm?.SetCheckBoxCheckedByNameApi("cbInfomation", true);
                mainForm?.SetCheckBoxCheckedByNameApi("cbTxIcConfig", true);
                mainForm?.SetCheckBoxCheckedByNameApi("cbRxIcConfig", true);

                checkBoxStates = mainForm.GetCheckBoxStates();
                MessageBox.Show("CheckBox state...\n\nBefore: "
                                + "\n   cbInfomation state: " + BeforecbInformation
                                + "\n   cbTxIcConfig state: " + BeforecbTxIcConfig
                                + "\n   cbRxIcConfig state: " + BeforecbRxIcConfig
                                + "\n   cbProductSelect items: " + BeforeItems
                                + "\n   cbProductSelect state: " + BeforeSelectedProducts
                                + "\n\nAfter:\n   cbInfomation state: " + checkBoxStates["cbInfomation"]
                                + "\n   cbTxIcConfig state: " + checkBoxStates["cbTxIcConfig"]
                                + "\n   cbRxIcConfig state: " + checkBoxStates["cbRxIcConfig"]
                                + "\n   cbProductSelect state: " + selectedProduct
                                );
            }
            else
            {
                mainForm?.SetCheckBoxCheckedByNameApi("cbInfomation", true);
                mainForm?.SetCheckBoxCheckedByNameApi("cbDdm", true);
                mainForm?.SetCheckBoxCheckedByNameApi("cbMemDump", true);
                mainForm?.SetCheckBoxCheckedByNameApi("cbCorrector", true);
                mainForm?.SetCheckBoxCheckedByNameApi("cbTxIcConfig", true);
                mainForm?.SetCheckBoxCheckedByNameApi("cbRxIcConfig", true);
            }

            //ucNuvotonICP initial...
            if (TestMode)
            {
                MessageBox.Show("ReLink and Erase APROM...Done");
                bool beforeSecurityLock = mainForm.GetCheckBoxStateFromNuvotonIcpApi("cbSecurityLock");
                mainForm.SetCheckBoxStateToNuvotonIcpApi("cbSecurityLock", false);
                mainForm.UpdateSecurityLockStateFromNuvotonIcpApi();
                MessageBox.Show("SecurityLock state...\n\nBefore: " + beforeSecurityLock
                                + "\n\nAfter: " + mainForm.GetCheckBoxStateFromNuvotonIcpApi("cbSecurityLock")
                                );

                var BeforecbLDROM = mainForm.GetCheckBoxStateFromNuvotonIcpApi("cbLDROM");
                var BeforecbAPROM = mainForm.GetCheckBoxStateFromNuvotonIcpApi("cbAPROM");
                var BeforecbDATAROM = mainForm.GetCheckBoxStateFromNuvotonIcpApi("cbDataFlash");
                string pathLDROM = mainForm.GetTextBoxTextFromNuvotonIcpApi("tbLDROM");
                string pathAPROM = mainForm.GetTextBoxTextFromNuvotonIcpApi("tbAPROM");
                string pathDATAROM = mainForm.GetTextBoxTextFromNuvotonIcpApi("tbDataFlash");

                mainForm.SetCheckBoxStateToNuvotonIcpApi("cbLDROM", false);
                mainForm.SetCheckBoxStateToNuvotonIcpApi("cbAPROM", true);
                mainForm.SetCheckBoxStateToNuvotonIcpApi("cbDataFlash", false);

                MessageBox.Show("Flashing checkBox state...\n\nBefore: "
                                + "\n   cbLDROM: " + BeforecbLDROM
                                + "\n   cbAPROM: " + BeforecbAPROM
                                + "\n   cbDataFlash: " + BeforecbDATAROM
                                + "\n   tbLDROM: " + pathLDROM
                                + "\n   tbAPROM: " + pathAPROM
                                + "\n   tbcbDataFlash: " + pathDATAROM
                                + "\n\nAfter:\n   cbLDROM: " + mainForm.GetCheckBoxStateFromNuvotonIcpApi("cbLDROM")
                                + "\n   cbAPROM: " + mainForm.GetCheckBoxStateFromNuvotonIcpApi("cbAPROM")
                                + "\n   cbDataFlash: " + mainForm.GetCheckBoxStateFromNuvotonIcpApi("cbDataFlash")
                                );
            }
            else
            {
                mainForm.SetCheckBoxStateToNuvotonIcpApi("cbLDROM", false);
                mainForm.SetCheckBoxStateToNuvotonIcpApi("cbAPROM", true);
                mainForm.SetCheckBoxStateToNuvotonIcpApi("cbDataFlash", false);
                mainForm.SetCheckBoxStateToNuvotonIcpApi("cbSecurityLock", true);
            }

            mainForm.UpdateSecurityLockStateFromNuvotonIcpApi();
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
            Application.DoEvents();
            
            if (!FirstRound)
            {
                for (int i = 100; i > 0 ; i--)// For ProgressBar renew
                {
                    cProgressBar1.Value = i;
                    cProgressBar1.Text = "" + i + "%";
                    cProgressBar2.Value = i;
                    cProgressBar2.Text = "" + i + "%";
                    Thread.Sleep(1);
                }
            }

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
                    if (!(mainForm.I2cMasterDisconnectApi() < 0))
                        I2cConnected = false;
                    OpenLoginForm();
                    ResetSequence();
                }
            }
            else if (e.KeyCode == expectedKeysB[SequenceIndexB])
            {
                SequenceIndexB++;
                if (CheckSequenceComplete(SequenceIndexB, expectedKeysB))
                {
                    if (!(mainForm.I2cMasterDisconnectApi() < 0))
                        I2cConnected = false;
                    OpenAdminAuthenticationForm();
                    ResetSequence();
                }
            }
            else
            {
                ResetSequence();
            }
        }

        private void _UpdateButtonState()
        {
            if (I2cConnected)
                cbI2cConnect.Checked = true;
            else if (!I2cConnected)
                cbI2cConnect.Checked = false;
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
            if (ProcessingChannel == 1)
            {
                if (lCh1Message.InvokeRequired)
                {
                    Invoke(new Action(() =>
                    {
                        lCh1Message.Text = e; // MainForm 送出 ReadStateUpdated event，update to Label.text
                    }));
                }
                else
                    lCh1Message.Text = e;
            }
            else if (ProcessingChannel == 2)
            {
                if (lCh2Message.InvokeRequired)
                {
                    Invoke(new Action(() =>
                    {
                        lCh2Message.Text = e;
                    }));
                }
                else
                    lCh2Message.Text = e;
            }
            
        }

        private void MainForm_ProgressUpdated(object sender, int e)
        {

            if (ProcessingChannel == 1)
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
            else if (ProcessingChannel == 2)
            {
                if (cProgressBar2.InvokeRequired)
                {
                    Invoke(new Action(() =>
                    {
                        cProgressBar2.Value = e;
                        cProgressBar2.Text = cProgressBar2.Value.ToString() + "%";
                    }));
                }
                else
                {
                    cProgressBar2.Value = e;
                    cProgressBar2.Text = cProgressBar2.Value.ToString() + "%";
                }
            }
        }

        private void _RemoteInitial()
        {
            if (cbBypassW.Checked)
                mainForm.SetVarBoolStateToMainFormApi("BypassWriteIcConfig", true);

            string selectedProduct = lProduct.Text;
            mainForm?.SelectProductApi(selectedProduct);

            mainForm?.SetCheckBoxCheckedByNameApi("cbInfomation", true);
            mainForm?.SetCheckBoxCheckedByNameApi("cbDdm", true);
            mainForm?.SetCheckBoxCheckedByNameApi("cbMemDump", true);
            mainForm?.SetCheckBoxCheckedByNameApi("cbCorrector", true);
            mainForm?.SetCheckBoxCheckedByNameApi("cbTxIcConfig", true);
            mainForm?.SetCheckBoxCheckedByNameApi("cbRxIcConfig", true);

            mainForm.SetTextBoxTextToNuvotonIcpApi("tbAPROM", lPath.Text);
            mainForm.SetVarIntStateToNuvotonIcpApi("LinkState", 0);
            mainForm.SetCheckBoxStateToNuvotonIcpApi("cbLDROM", false);
            mainForm.SetCheckBoxStateToNuvotonIcpApi("cbAPROM", true);
            mainForm.SetCheckBoxStateToNuvotonIcpApi("cbDataFlash", false);
            mainForm.SetCheckBoxStateToNuvotonIcpApi("cbSecurityLock", true); // Dominic
            mainForm.UpdateSecurityLockStateFromNuvotonIcpApi();
            Thread.Sleep(100);
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
                    tbFilePath.SelectionStart = tbFilePath.Text.Length;
                }
            }
        }

        private void _SetCsvFilePath()
        {
            string initialDirectory = AppDomain.CurrentDomain.BaseDirectory;

            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Select a Folder";
                folderBrowserDialog.RootFolder = Environment.SpecialFolder.LocalApplicationData;
                folderBrowserDialog.SelectedPath = initialDirectory;

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    tbLogFIlePath.Text = folderBrowserDialog.SelectedPath;
                    tbLogFIlePath.SelectionStart = tbLogFIlePath.Text.Length;
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
                MessageBox.Show("No file path specified. Please choose the file again.", "Config file", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            return false;
        }

        private void raSingle_CheckedChanged(object sender, EventArgs e)
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

        private void _LogFilePathChanges()
        {
            if (tbFilePath.Text == "Please click here to set the export file path.")
            {
                tbFilePath.Text = "";
                tbFilePath.ForeColor = Color.MidnightBlue;
            }

            _LoadXmlFile();

            if (lMode.Text == "Customer")
            {
                this.Size = new System.Drawing.Size(550, 220);
                rbSingle.Enabled = true;
                rbBoth.Enabled = true;
            }

            else if (lMode.Text == "MP")
            {
                this.Size = new System.Drawing.Size(550, 300);
                rbSingle.Select();
                rbSingle.Enabled = false;
                rbBoth.Enabled = false;
                if (!(mainForm.I2cMasterConnectApi(true, true) < 0))
                    I2cConnected = true;
                mainForm.ChannelSetApi(1);

                ContinueRxPowerUpdate = true;
                if (RxPowerUpdateThread == null || !RxPowerUpdateThread.IsAlive)
                {
                    RxPowerUpdateThread = new Thread(new ThreadStart(_RxPowerUpdateThread));
                    RxPowerUpdateThread.IsBackground = true;
                    RxPowerUpdateThread.Start();
                }
            }
        }

        private void tbFilePath_MouseClick(object sender, MouseEventArgs e)
        {
            _ConfigFilePathChanges();
        }

        private void tbFilePath_Enter(object sender, EventArgs e)
        {
            _ConfigFilePathChanges();
        }

        private void _ConfigFilePathChanges()
        {
            if (tbFilePath.Text == "Please click here, to import the Config file...")
            {
                tbFilePath.Text = "";
                tbFilePath.ForeColor = Color.MidnightBlue;
            }

            _LoadXmlFile();

            if (lMode.Text == "Customer")
            {
                this.Size = new System.Drawing.Size(550, 220);
                rbSingle.Enabled = true;
                rbBoth.Enabled = true;
            }
                
            else if (lMode.Text == "MP")
            {
                this.Size = new System.Drawing.Size(550, 300);
                rbSingle.Select();
                rbSingle.Enabled = false;
                rbBoth.Enabled = false;
                if (!(mainForm.I2cMasterConnectApi(true, true) < 0))
                    I2cConnected = true;
                mainForm.ChannelSetApi(1);

                ContinueRxPowerUpdate = true;
                if (RxPowerUpdateThread == null || !RxPowerUpdateThread.IsAlive)
                {
                    RxPowerUpdateThread = new Thread(new ThreadStart(_RxPowerUpdateThread));
                    RxPowerUpdateThread.IsBackground = true;
                    RxPowerUpdateThread.Start();
                }
            }
        }

        private void _RxPowerUpdateThread()
        {
            int currentState = 1;

            while (ContinueRxPowerUpdate)
            {
                mainForm.RxPowerReadApiFromDdmApi();

                Invoke(new Action(() =>
                {
                    switch (currentState)
                    {
                        case 1:
                            tbRssi0.Text = "0";
                            tbRssi1.Text = mainForm.GetTextBoxTextFromDdmApi("tbRxPower2");
                            tbRssi2.Text = mainForm.GetTextBoxTextFromDdmApi("tbRxPower3");
                            tbRssi3.Text = mainForm.GetTextBoxTextFromDdmApi("tbRxPower4");
                            break;
                        case 2:
                            tbRssi0.Text = mainForm.GetTextBoxTextFromDdmApi("tbRxPower1");
                            tbRssi1.Text = "0";
                            tbRssi2.Text = mainForm.GetTextBoxTextFromDdmApi("tbRxPower3");
                            tbRssi3.Text = mainForm.GetTextBoxTextFromDdmApi("tbRxPower4");
                            break;
                        case 3:
                            tbRssi0.Text = mainForm.GetTextBoxTextFromDdmApi("tbRxPower1");
                            tbRssi1.Text = mainForm.GetTextBoxTextFromDdmApi("tbRxPower2");
                            tbRssi2.Text = "0";
                            tbRssi3.Text = mainForm.GetTextBoxTextFromDdmApi("tbRxPower4");
                            break;
                        case 4:
                            tbRssi0.Text = mainForm.GetTextBoxTextFromDdmApi("tbRxPower1");
                            tbRssi1.Text = mainForm.GetTextBoxTextFromDdmApi("tbRxPower2");
                            tbRssi2.Text = mainForm.GetTextBoxTextFromDdmApi("tbRxPower3");
                            tbRssi3.Text = "0";
                            break;
                        default:
                            break;
                    }

                    currentState = currentState < 4 ? currentState + 1 : 1;
                }));

                Thread.Sleep(100); 
            }
        }

        public void StopRxPowerUpdateThread()
        {
            if (RxPowerUpdateThread != null && RxPowerUpdateThread.IsAlive)
            {
                ContinueRxPowerUpdate = false; // 標記為 false 通知線程退出循環
                RxPowerUpdateThread.Join(); // 等待線程結束
                RxPowerUpdateThread = null; // 設為 null，以便可以重新啟動
            }
        }
        /*
        private void _RxPowerUpdateThread()
        {
            while (true)
            {
                Invoke(new Action(() =>
                {
                    _RxPowerUpdate();
                }));

                Thread.Sleep(1000); // 使線程休眠1秒
            }
        }
        */
        private void tbFilePath_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbFilePath.Text))
            {
                tbFilePath.Text = "Please click here, to import the Config file...";
                tbFilePath.ForeColor = Color.Silver;
            }
        }

        private void tbVenderSn_Enter(object sender, EventArgs e)
        {
            if (tbVenderSn.Text == "YYMMDLSSSS")
            {
                tbVenderSn.Text = "";
                tbVenderSn.ForeColor = Color.MidnightBlue;
            }
        }

        private void tbVenderSn_Leave(object sender, EventArgs e)
        {
            if (tbVenderSn.Text == "")
            {
                tbVenderSn.Text = "YYMMDLSSSS";
                tbVenderSn.ForeColor = Color.Silver;
            }
        }

        private void tbDateCode_Enter(object sender, EventArgs e)
        {
            if (tbDateCode.Text == "YYMMDD")
            {
                tbDateCode.Text = "";
                tbDateCode.ForeColor = Color.MidnightBlue;
            }
        }

        private void tbDateCode_Leave(object sender, EventArgs e)
        {
            if (tbDateCode.Text == "")
            {
                tbDateCode.Text = "YYMMDD";
                tbDateCode.ForeColor = Color.Silver;
            }
        }

        private void _FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (!(mainForm.I2cMasterDisconnectApi() < 0))
                    I2cConnected = false;
                Application.Exit();
            }
        }

        private void _RemoteControl()
        {
            string errorCountCh1R = "", errorCountCh1W = "";
            string errorCountCh2R = "", errorCountCh2W = "";
            string txCrossPoint0 = "X", txCrossPoint1 = "X", txIbias0 = "X", txIbias1 = "X";
            string rxLosTh0 = "X", rxLosTh1 = "X", rxDeEmphasis0 = "X", rxDeEmphasis1 = "X";

            if ((_PathCheck(lPath)))
            {
                // Processing FW update...
                if (DemoMode)
                {
                    if (ProcessingChannel == 1)
                    {
                        lCh1Message.Text = "Update completed.";
                        cProgressBar1.Value = 100;
                        cProgressBar1.Text = "100%";
                        Thread.Sleep(500);
                        MessageBox.Show("CH1_Read_FwUpdate_Write");
                    }
                    else if (ProcessingChannel == 2)
                    {
                        lCh2Message.Text = "Update completed.";
                        cProgressBar2.Value = 100;
                        cProgressBar2.Text = "100%";
                        Thread.Sleep(500);
                        MessageBox.Show("CH2_Read_FwUpdate_Write");
                    }
                    
                }
                else 
                {
                    if (TestMode)
                    {
                        txCrossPoint0 = mainForm.GetValueFromUcRt146Config("cbCrossPointCh0");
                        txIbias0 = mainForm.GetValueFromUcRt146Config("cbIbiasCurrentCh0");
                        rxLosTh0 = mainForm.GetValueFromUcRt145Config("cbLosThresholdCh0");
                        rxDeEmphasis0 = mainForm.GetValueFromUcRt145Config("cbDeEmphasisCh0");
                    }
                    
                    if (ProcessingChannel == 1)
                        errorCountCh1R = mainForm._GlobalRead().ToString(); // Tack out DUT data
                    else if (ProcessingChannel == 2)
                        errorCountCh2R = mainForm._GlobalRead().ToString(); // Tack out DUT data

                    if (TestMode)
                    {
                        txCrossPoint1 = mainForm.GetValueFromUcRt146Config("cbCrossPointCh0");
                        txIbias1 = mainForm.GetValueFromUcRt146Config("cbIbiasCurrentCh0");
                        rxLosTh1 = mainForm.GetValueFromUcRt145Config("cbLosThresholdCh0");
                        rxDeEmphasis1 = mainForm.GetValueFromUcRt145Config("cbDeEmphasisCh0");
                        MessageBox.Show("Read IcConfig...\n\nBefore: "
                                   + "\n   txCrossPoint0: " + txCrossPoint0
                                   + "\n   txIbias0: " + txIbias0
                                   + "\n   rxLosTh0: " + rxLosTh0
                                   + "\n   rxDeEmphasis0: " + rxDeEmphasis0
                                   + "\n\nAfter:\n   txCrossPoint1: " + txCrossPoint1
                                   + "\n   txIbias1: " + txIbias1
                                   + "\n   rxLosTh1: " + rxLosTh1
                                   + "\n   rxDeEmphasis1: " + rxDeEmphasis1
                                   );
                    }
                                         
                    Thread.Sleep(10);
                    if (ProcessingChannel == 1)
                        lCh1EC.Text = $"R:{errorCountCh1R} ";
                    else if (ProcessingChannel == 2)
                        lCh2EC.Text = $"R:{errorCountCh2R} ";

                    if (TestMode)
                        MessageBox.Show("GlobalRead...Done");

                    mainForm.SetAutoReconnectApi(true); //Initial mode state before Connect module
                    mainForm.SetBypassEraseAllCheckModeApi(true);

                    if (TestMode)
                    {
                        MessageBox.Show("AutoReconnec mode: " + mainForm.GetAutoReconnectApi()
                                   + "\nBypassEraseAll mode " + mainForm.GetBypassEraseAllCheckModeApi()
                                   );
                    }

                    mainForm.ForceConnectSingleApi(); // Link DUT and EraseAPROM
                    Thread.Sleep(10);

                    mainForm.StartFlashingApi(); // Firmware update
                    Thread.Sleep(10);
                    
                    if (TestMode)
                        MessageBox.Show("Firmware burning...Done");

                    if (ProcessingChannel == 1)
                    {
                        errorCountCh1W = mainForm._GlobalWrite(true).ToString(); // Write the previous parameter into Flash
                        lCh1EC.Text = $"R:{errorCountCh1R} /W:{errorCountCh1W} ";
                    }
                    else if (ProcessingChannel == 2) 
                    {
                        errorCountCh2W = mainForm._GlobalWrite(true).ToString(); // Write the previous parameter into Flash
                        lCh2EC.Text = $"R:{errorCountCh2R} /W:{errorCountCh2W} ";
                    }

                    if (TestMode)
                        MessageBox.Show("GlobalWrite...Done");

                    if (ProcessingChannel == 1)
                    {
                        lCh1Message.Text = "Update completed.";
                        cProgressBar1.Value = 100;
                        cProgressBar1.Text = "100%";
                    }
                    else if (ProcessingChannel == 2)
                    {
                        lCh2Message.Text = "Update completed.";
                        cProgressBar2.Value = 100;
                        cProgressBar2.Text = "100%";
                    }
                    
                    Application.DoEvents();
                    Thread.Sleep(500);
                }
            }
        }

        private void _MpModeProcessor()
        {
            _MessageUpdate("Preparing resources...", 0);
            mainForm.InformationReadApi();
            string VenderSn = mainForm.GetVendorSnFromDdmiApi();
            string DateCode = mainForm.GetDateCodeFromDdmiApi();
            string LogFileName = VenderSn + DateCode;
            mainForm.SetVendorSnToDdmiApi(tbVenderSn.Text);
            mainForm.SetDataCodeToDdmiApi(tbDateCode.Text);

            MessageBox.Show("Information check"
                            + "\nBefore:\n"
                            + "VenderSn: " + VenderSn
                            + "\nDateCode: " + DateCode
                            + "\n\nAfter:\n"
                            + "VerderSn: " + mainForm.GetVendorSnFromDdmiApi()
                            + "\nDateCode:" + mainForm.GetDateCodeFromDdmiApi()
                            );

            _MessageUpdate("Writing...", 30);
            lCh1Message.Text = "Writing...";
            mainForm.InformationWriteApi();
            Thread.Sleep(10);
            _MessageUpdate("Write...Done", 50);
            mainForm.InformationStoreIntoFlashApi();
            Thread.Sleep(10);
            _MessageUpdate("Store into flash...", 70);
            //StopRxPowerUpdateThread();
            mainForm.MemDumpExprotCsvApi(LogFileName);
            Thread.Sleep(10);
            _MessageUpdate("Finished", 100);
        }
        
        private void _CustomerModeProcessor()
        {
            _InitialUi();

            for (ProcessingChannel = 1; ProcessingChannel <= (DoubleSide ? 2 : 1); ProcessingChannel++)
            {
                _RemoteInitial();
                _RemoteControl();

                if (ProcessingChannel == 1 && DoubleSide)
                {
                    if (TestMode)
                        MessageBox.Show("Switch channel");

                    mainForm.ChannelSwitchApi(); // switch

                    if (!(mainForm.I2cMasterDisconnectApi() < 0))// ReLink-step1 ；觀察有其必要性?
                        I2cConnected = false;

                    if (!(mainForm.I2cMasterConnectApi(true, true) < 0))// ReLink-step2
                        I2cConnected = true;
                }

                FirstRound = false;
            }

            if (DoubleSide)
            {
                mainForm.ChannelSwitchApi();

                if (!(mainForm.I2cMasterDisconnectApi() < 0))// ReLink-step1 ；觀察有其必要性?
                    I2cConnected = false;

                if (!(mainForm.I2cMasterConnectApi(true, true) < 0))// ReLink-step2
                    I2cConnected = true;
            }
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            try
            {
                bStart.Enabled = false;
               
                if(lMode.Text == "Customer")
                    _CustomerModeProcessor();
                else if (lMode.Text == "MP")
                    _MpModeProcessor();
                
            }
            finally
            {
                if (!(mainForm.I2cMasterDisconnectApi() < 0))
                    I2cConnected = false;

                _UpdateButtonState();
                bStart.Enabled = true;
            }
        }

        private void I2cMasterConnect_CheckedChanged(object sender, EventArgs e)
        {
            if (cbI2cConnect.Checked)
            {
                if (!(mainForm.I2cMasterConnectApi(true, true) < 0))
                    I2cConnected = true;
                else
                {
                    MessageBox.Show("I2c master connection failed.\nPlease check if the hardware configuration or UI is activated.",
                                    "I2c master connection failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
            else
                if (!(mainForm.I2cMasterDisconnectApi() < 0))
                    I2cConnected = false;
        }

        private void _RxPowerUpdate()
        {
            mainForm.RxPowerReadApiFromDdmApi();
            tbRssi0.Text = mainForm.GetTextBoxTextFromDdmApi("tbRxPower1");
            tbRssi1.Text = mainForm.GetTextBoxTextFromDdmApi("tbRxPower2");
            tbRssi2.Text = mainForm.GetTextBoxTextFromDdmApi("tbRxPower3");
            tbRssi3.Text = mainForm.GetTextBoxTextFromDdmApi("tbRxPower4");
        }

        private void tbLogFilePath(object sender, EventArgs e)
        {
            _SetCsvFilePath();
        }
    }
}

