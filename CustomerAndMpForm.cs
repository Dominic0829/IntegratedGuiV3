using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;
using System.Xml;
using ComponentFactory.Krypton.Toolkit;
using I2cMasterInterface;
using Ionic.Zip;
using NuvotonIcpTool;
using QsfpDigitalDiagnosticMonitoring;
using Rt145Rt146Config;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace IntegratedGuiV2
{
    
    public partial class CustomerAndMpForm: KryptonForm
    {
        private MainForm mainForm; // Assist processing for i2c communication
        private System.Windows.Forms.Timer timer;
        private int SequenceIndexA = 0;
        private int SequenceIndexB = 0;
        private int SequenceIndexDirectionA = 0;
        private int SequenceIndexDirectionB = 0;
        private int ForceOpenSAS4 = 0;
        private bool DoubleSideMode = false;
        private int ProcessingChannel = 1;
        private int SerialNumber = 1;
        private int MinSerialNumber = 1;
        private int MaxSerialNumber = 9999;
        private bool DemoMode = false;
        private bool DebugMode = false;
        private bool FirstRound = true;
        private bool RxPowerUpdate = false;
        private bool I2cConnected = false;
        private bool ForceConnectWithoutInvoke = false;
        private string CurrentDate = DateTime.Now.ToString("yyMMdd");
        private int Revision = 1;
        private string TempFolderPath = string.Empty;
        private string LogFileFolderPath = string.Empty;
        private CancellationTokenSource cancellationTokenSource;

        private Thread RxPowerUpdateThread;
        private bool ContinueRxPowerUpdate = true;
        private WaitFormFunc loadingForm = new WaitFormFunc();

        private void MainForm_MainMessageUpdated(object sender, MessageEventArgs e)
        {
            if (ProcessingChannel == 1) {
                BeginInvoke(new Action(() =>
                {
                    lCh1Message.Text = e.Message;
                    cProgressBar1.Value = e.ProgressValue;
                    cProgressBar1.Text = cProgressBar1.Value.ToString() + "%";
                }));
            }
            else if (ProcessingChannel == 2) {
                BeginInvoke(new Action(() =>
                {
                    lCh2Message.Text = e.Message;
                    cProgressBar2.Value = e.ProgressValue;
                    cProgressBar2.Text = cProgressBar2.Value.ToString() + "%";
                }));
            }
        }

        private void InitializeDomainUpDowns()
        {
            for (int i = 30; i >= 15; i--) {
                dudYy.Items.Add(i.ToString("D2"));
            }
            dudYy.SelectedItem = DateTime.Now.ToString("yy");

            for (int i = 12; i >= 1; i--) {
                dudMm.Items.Add(i.ToString("D2"));
            }
            dudMm.SelectedItem = DateTime.Now.ToString("MM");

            for (int i = 31; i >= 1; i--) {
                dudDd.Items.Add(i.ToString("D2"));
            }
            dudDd.SelectedItem = DateTime.Now.ToString("dd");

            for (int i = 99; i >= 1; i--) {
                dudRr.Items.Add(i.ToString("D2"));
            }
            dudRr.SelectedItem = Revision.ToString("D2");

            for (int i = 9999; i >= 1; i--) {
                dudSsss.Items.Add(i.ToString("D4"));
            }
            dudSsss.SelectedItem = SerialNumber.ToString("D4");
        }

        private void domainUpDown_TextChanged(object sender, EventArgs e)
        {
            UpdateTextBoxAA();
        }

        private void UpdateTextBoxAA()
        {
            string yy = !string.IsNullOrEmpty(dudYy.Text) ? dudYy.Text : DateTime.Now.ToString("yy");
            string mm = !string.IsNullOrEmpty(dudMm.Text) ? dudMm.Text : DateTime.Now.ToString("MM");
            string dd = !string.IsNullOrEmpty(dudDd.Text) ? dudDd.Text : DateTime.Now.ToString("dd");
            string rr = !string.IsNullOrEmpty(dudRr.Text) ? dudRr.Text : Revision.ToString("D2");
            string ssss = !string.IsNullOrEmpty(dudSsss.Text) ? dudSsss.Text : SerialNumber.ToString("D4");
            tbVenderSn.Text = yy + mm + dd + rr + ssss;
            tbDateCode.Text = yy + mm + dd;
        }

        private void BindEvents()
        {
            dudYy.TextChanged += new EventHandler(domainUpDown_TextChanged);
            dudMm.TextChanged += new EventHandler(domainUpDown_TextChanged);
            dudDd.TextChanged += new EventHandler(domainUpDown_TextChanged);
            dudRr.TextChanged += new EventHandler(domainUpDown_TextChanged);
            dudSsss.TextChanged += new EventHandler(domainUpDown_TextChanged);
        }

        private void HandlePluginWaiting(bool isWaiting)
        {
            if (!ForceConnectWithoutInvoke && isWaiting )
                loadingForm.OnPluginWaiting();
                
        }
                
        private void HandlePluginDetected(bool isDetected)
        {
            if (!ForceConnectWithoutInvoke && isDetected)
                loadingForm.PluginDetected();
        }

        public CustomerAndMpForm()
        {
            InitializeComponent();
            InitializeDomainUpDowns();
            BindEvents();
            UpdateTextBoxAA();
            mainForm = new MainForm(true);
            this.FormClosing += new FormClosingEventHandler(_FormClosing);
            this.Size = new Size(550, 280);
            this.Text = "OptiSync Manager";
            cProgressBar1.Value = 0;
            cProgressBar2.Value = 0;
            this.Load += MainForm_Load;
            this.KeyPreview = true;
            this.KeyDown += _HideKeys_KeyDown;
            this.tbVenderSn.KeyDown += TbVenderSnCh1_KeyDown;
            mainForm.OnPluginWaiting += HandlePluginWaiting;
            mainForm.OnPluginDetected += HandlePluginDetected;

            if (!(mainForm.ChannelSetApi(1) < 0)) // (bool setMode, bool setPassword)
                I2cConnected = true;
            else {
                MessageBox.Show("I2c master connection failed.\nPlease check if the hardware configuration or UI is activated.",
                                "I2c master connection failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            mainForm.ReadStateUpdated += MainForm_ReadStateUpdated;
            mainForm.ProgressValue += MainForm_ProgressUpdated;
            //ucNuvotonIcpTool.MessageUpdated += UcNuvotonIcpTool_MessageUpdated;
            mainForm.MainMessageUpdated += MainForm_MainMessageUpdated;

            //ucMainForm initial...
            if (DebugMode) {
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
            else {
                mainForm?.SetCheckBoxCheckedByNameApi("cbInfomation", true);
                mainForm?.SetCheckBoxCheckedByNameApi("cbDdm", true);
                mainForm?.SetCheckBoxCheckedByNameApi("cbMemDump", true);
                mainForm?.SetCheckBoxCheckedByNameApi("cbCorrector", true);
                mainForm?.SetCheckBoxCheckedByNameApi("cbTxIcConfig", true);
                mainForm?.SetCheckBoxCheckedByNameApi("cbRxIcConfig", true);
            }

            //ucNuvotonICP initial...
            if (DebugMode) {
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
            else {
                mainForm.SetCheckBoxStateToNuvotonIcpApi("cbLDROM", false);
                mainForm.SetCheckBoxStateToNuvotonIcpApi("cbAPROM", true);
                mainForm.SetCheckBoxStateToNuvotonIcpApi("cbDataFlash", false);
                mainForm.SetCheckBoxStateToNuvotonIcpApi("cbSecurityLock", true);
            }

            mainForm.UpdateSecurityLockStateFromNuvotonIcpApi();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            tbRssiCh1_3.Select();
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
            tbVersionCodeCh1.Text = "";
            tbVersionCodeCh2.Text = "";
            tbVersionCodeReNewCh1.Text = "";
            tbVersionCodeReNewCh2.Text = "";
            lStatus.TextAlign = ContentAlignment.MiddleCenter;
            bStart.Select();

            if (!FirstRound) {
                for (int i = 100; i > -1; i -= 5)// For ProgressBar renew
                {
                    cProgressBar1.Value = i;
                    cProgressBar1.Text = "" + i + "%";
                    cProgressBar2.Value = i;
                    cProgressBar2.Text = "" + i + "%";
                    Thread.Sleep(1);
                }
            }

            Application.DoEvents();
        }

        private void _InitialUiForWriteSn()
        {
            tbOrignalSNCh1.BackColor = Color.LightBlue;
            tbOrignalSNCh2.BackColor = Color.LightBlue;
            tbReNewSnCh1.BackColor = Color.LightBlue;
            tbReNewSnCh2.BackColor = Color.LightBlue;
            tbOrignalSNCh1.ForeColor = Color.Black;
            tbOrignalSNCh2.ForeColor = Color.Black;
            tbReNewSnCh1.ForeColor = Color.Black;
            tbReNewSnCh2.ForeColor = Color.Black;
        }

        private void _HideKeys_KeyDown(object sender, KeyEventArgs e)
        {
            Keys[][] expectedKeys = {
                new Keys[] { Keys.NumPad4, Keys.NumPad4, Keys.NumPad6, Keys.NumPad6 },
                new Keys[] { Keys.NumPad8, Keys.NumPad8, Keys.NumPad2, Keys.NumPad2 },
                new Keys[] { Keys.Left, Keys.Left, Keys.Right, Keys.Right },
                new Keys[] { Keys.Up, Keys.Up, Keys.Down, Keys.Down },
                new Keys[] { Keys.Up, Keys.Down, Keys.Left, Keys.Right,
                             Keys.Up, Keys.Down, Keys.Left, Keys.Right, }
            };

            Action[] actions = {
                () => _OpenLoginForm(),
                () => _OpenAdminAuthenticationForm(),
                () => _OpenLoginForm(),
                () => _OpenAdminAuthenticationForm(),
                () => _OpenEngineerForm()
            };

            int[] sequenceIndices = {   SequenceIndexA, SequenceIndexB, 
                                        SequenceIndexDirectionA, SequenceIndexDirectionB,
                                        ForceOpenSAS4 };

            for (int i = 0; i < expectedKeys.Length; i++) {
                if (e.KeyCode == expectedKeys[i][sequenceIndices[i]]) {
                    sequenceIndices[i]++;
                    if (CheckSequenceComplete(sequenceIndices[i], expectedKeys[i])) {
                        I2cConnected = (mainForm.I2cMasterDisconnectApi() < 0);
                        actions[i]();
                        ResetSequence();
                    }
                }
                else 
                    ResetSequence();
            }

            SequenceIndexA = sequenceIndices[0];
            SequenceIndexB = sequenceIndices[1];
            SequenceIndexDirectionA = sequenceIndices[2];
            SequenceIndexDirectionB = sequenceIndices[3];
            ForceOpenSAS4 = sequenceIndices[4];
        }

        private void TbVenderSnCh1_KeyDown(object sender, KeyEventArgs e)
        {
            int ComparisonResults;

            if (cbBarcodeMode.Enabled && e.KeyCode == Keys.Enter) {
                tbVenderSn.Enabled = false;

                if (cbBarcodeMode.Checked)
                    _PromptInitialUi();

                if (ValidateVenderSn() >= 0) {
                    tbDateCode.Text = tbVenderSn.Text.Substring(0, 6);
                    
                    if (rbFullMode.Checked) { //Handle CfgFile
                        bool isCustomerMode = lMode.Text == "Customer";

                        if ((isCustomerMode || lMode.Text == "MP") && 
                            _Processor(isCustomerMode) < 0) {
                            MessageBox.Show("There are some problems", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }

                        if (cbBarcodeMode.Checked && WriteSnDateCode() < 0)
                            _PromptError();
                        else
                            _PromptCompleted();
                    }

                    else if (rbOnlySN.Checked) {
                        
                        if (cbBarcodeMode.Checked && WriteSnDateCode() < 0)
                            _PromptError();
                        else
                            _PromptCompleted();
                    }

                    else if (rbLogFileMode.Checked) {

                        if (cbBarcodeMode.Checked) {

                            ComparisonResults = _LogFileComparison();

                            if (ComparisonResults < 0)
                                _PromptError();
                            else if (ComparisonResults == 1)
                                _PromptWrong();
                            else
                                _PromptCorrect();
                        }
                    }
                }

                tbVenderSn.Text = "";
                tbVenderSn.Enabled = true;
                loadingForm.Close();
                this.BringToFront();
                this.Activate();
                tbVenderSn.Select();
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

        private void _OpenEngineerForm()
        {
            MainForm mainForm = new MainForm(true);
            loadingForm.Show(this);
            mainForm.SetPermissions("Administrator");
            mainForm.SetProduct("SAS4.0");
            mainForm.Show();
            loadingForm.Close();
            this.Hide();
        }

        private void _OpenLoginForm()
        {
            LoginForm formB = new LoginForm();
            formB.Show();
            this.Hide();
        }

        private void _OpenAdminAuthenticationForm()
        {
            AdminAuthentication formC = new AdminAuthentication();
            formC.Show();
            this.Hide();
        }

        private void ResetSequence()
        {
            SequenceIndexA = 0;
            SequenceIndexB = 0;
            SequenceIndexDirectionA = 0;
            SequenceIndexDirectionB = 0;
            ForceOpenSAS4 = 0;
        }

        private void MainForm_ReadStateUpdated(object sender, string e)
        {
            if (ProcessingChannel == 1) {
                if (lCh1Message.InvokeRequired) {
                    Invoke(new Action(() =>
                    {
                        lCh1Message.Text = e; // MainForm 送出 ReadStateUpdated event，update to Label.text
                    }));
                }
                else
                    lCh1Message.Text = e;
            }
            else if (ProcessingChannel == 2) {
                if (lCh2Message.InvokeRequired) {
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

            if (ProcessingChannel == 1) {
                if (cProgressBar1.InvokeRequired) {
                    Invoke(new Action(() =>
                    {
                        cProgressBar1.Value = e;
                        cProgressBar1.Text = cProgressBar1.Value.ToString() + "%";
                    }));
                }
                else {
                    cProgressBar1.Value = e;
                    cProgressBar1.Text = cProgressBar1.Value.ToString() + "%";
                }
            }
            else if (ProcessingChannel == 2) {
                if (cProgressBar2.InvokeRequired) {
                    Invoke(new Action(() =>
                    {
                        cProgressBar2.Value = e;
                        cProgressBar2.Text = cProgressBar2.Value.ToString() + "%";
                    }));
                }
                else {
                    cProgressBar2.Value = e;
                    cProgressBar2.Text = cProgressBar2.Value.ToString() + "%";
                }
            }
        }
        
        private int _RemoteInitial(bool cutomerMode) // True: Customer Mode, Flase: MP mode
        {
            string apromPath, dataromPath;
            string directoryPath;

            /*
            if (cbBypassW.Checked)
                mainForm.SetVarBoolStateToMainFormApi("BypassWriteIcConfig", true);
            */

            if ((string.IsNullOrEmpty(lProduct.Text))) {
                MessageBox.Show("The configuration file format is incorrect.");
                return -1;
            }

            else {
                string selectedProduct = lProduct.Text;
                mainForm?.SelectProductApi(selectedProduct);
            }

            if (cutomerMode) // Customer Mode
            {
                mainForm?.SetCheckBoxCheckedByNameApi("cbInfomation", true);
                mainForm?.SetCheckBoxCheckedByNameApi("cbDdm", true);
                mainForm?.SetCheckBoxCheckedByNameApi("cbMemDump", false);
                mainForm?.SetCheckBoxCheckedByNameApi("cbCorrector", true);
                mainForm?.SetCheckBoxCheckedByNameApi("cbTxIcConfig", false);
                mainForm?.SetCheckBoxCheckedByNameApi("cbRxIcConfig", false);
            }
            else // Mp Mode
            {
                mainForm?.SetCheckBoxCheckedByNameApi("cbInfomation", true);
                mainForm?.SetCheckBoxCheckedByNameApi("cbDdm", true);
                mainForm?.SetCheckBoxCheckedByNameApi("cbMemDump", false);
                mainForm?.SetCheckBoxCheckedByNameApi("cbCorrector", true);
                mainForm?.SetCheckBoxCheckedByNameApi("cbTxIcConfig", false);
                mainForm?.SetCheckBoxCheckedByNameApi("cbRxIcConfig", false);
            }

            if (!(string.IsNullOrEmpty(lApName.Text) || lApName.Text == "_")) {
                mainForm.SetCheckBoxStateToNuvotonIcpApi("cbAPROM", true);
                directoryPath = TempFolderPath;
                apromPath = Path.Combine(directoryPath, lApName.Text);
                mainForm.SetTextBoxTextToNuvotonIcpApi("tbAPROM", apromPath);
                if (DebugMode) {
                    MessageBox.Show("TempFolderPath: \n" + TempFolderPath +
                                "\n\nAPROM path: \n" + mainForm.GetTextBoxTextFromNuvotonIcpApi("tbAPROM"));
                }
                
            }
            else {
                MessageBox.Show("The configuration file format is incorrect.\nAPROM path not specified.", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            if (!(string.IsNullOrEmpty(lDataName.Text) || lDataName.Text == "_")) {
                mainForm.SetCheckBoxStateToNuvotonIcpApi("cbDataFlash", true);
                directoryPath = TempFolderPath;
                dataromPath = Path.Combine(directoryPath, lDataName.Text);
                mainForm.SetTextBoxTextToNuvotonIcpApi("tbDataFlash", dataromPath);
                //MessageBox.Show("DATAROM path: \n" + mainForm.GetTextBoxTextFromNuvotonIcpApi("tbDataFlash"));
            }
            else
                mainForm.SetCheckBoxStateToNuvotonIcpApi("cbDataFlash", false);

            mainForm.SetCheckBoxStateToNuvotonIcpApi("cbLDROM", false);

            if (cbSecurityLock.Checked) {
                mainForm.SetCheckBoxStateToNuvotonIcpApi("cbSecurityLock", true); // Dominic
            }
            else {
                mainForm.SetCheckBoxStateToNuvotonIcpApi("cbSecurityLock", false);
            }

            mainForm.SetVarIntStateToNuvotonIcpApi("LinkState", 0);
            mainForm.UpdateSecurityLockStateFromNuvotonIcpApi();
            Thread.Sleep(10);

            return 0;
        }

        private void _SwitchOrNot()
        {
            if (rbSingle.Checked == true) {
                cProgressBar1.Visible = true;
                cProgressBar2.Visible = false;
                lCh1Message.Visible = true;
                lCh2Message.Visible = false;
                //lCh1EC.Visible = true;
                //lCh2EC.Visible = false;
                DoubleSideMode = false;
                tbVersionCodeCh2.Visible = false;
                tbVersionCodeReNewCh2.Visible = false;
                tbOrignalSNCh2.Visible = false;
                tbReNewSnCh2.Visible = false;
                lRssiCh2_0.Visible = false;
                lRssiCh2_1.Visible = false;
                lRssiCh2_2.Visible = false;
                lRssiCh2_3.Visible = false;
                tbRssiCh2_0.Visible = false;
                tbRssiCh2_1.Visible = false;
                tbRssiCh2_2.Visible = false;
                tbRssiCh2_3.Visible = false;
            }
            else if (rbBoth.Checked == true) {
                cProgressBar1.Visible = true;
                cProgressBar2.Visible = true;
                lCh1Message.Visible = true;
                lCh2Message.Visible = true;
                //lCh1EC.Visible = true;
                //lCh2EC.Visible = true;
                DoubleSideMode = true;
                tbVersionCodeCh2.Visible = true;
                tbVersionCodeReNewCh2.Visible = true;
                lRssiCh2_0.Visible = true;
                lRssiCh2_1.Visible = true;
                lRssiCh2_2.Visible = true;
                lRssiCh2_3.Visible = true;
                tbRssiCh2_0.Visible = true;
                tbRssiCh2_1.Visible = true;
                tbRssiCh2_2.Visible = true;
                tbRssiCh2_3.Visible = true;

                if (lMode.Text == "MP") {
                    tbOrignalSNCh2.Visible = true;
                    tbReNewSnCh2.Visible = true;
                }
                else {
                    tbOrignalSNCh2.Visible = false;
                    tbReNewSnCh2.Visible = false;
                }
            }
        }

        private void _SaveLastBinPaths(string zipPath, string logFilePath)
        {
            string exeFolderPath = Application.StartupPath;
            string combinedPath = Path.Combine(exeFolderPath, "XmlFolder");

            if (!Directory.Exists(combinedPath))
                Directory.CreateDirectory(combinedPath);

            string xmlFilePath = Path.Combine(combinedPath, "MainFormPaths.xml");
            xmlFilePath = xmlFilePath.Replace("\\\\", "\\");

            XmlDocument xmlDoc = new XmlDocument();

            if (File.Exists(xmlFilePath)) {
                xmlDoc.Load(xmlFilePath);
            }
            else {
                XmlElement root = xmlDoc.CreateElement("Paths");
                xmlDoc.AppendChild(root);
            }

            XmlNode rootElement = xmlDoc.DocumentElement;

            if (!string.IsNullOrEmpty(zipPath)) {
                XmlElement zipPathElement = rootElement.SelectSingleNode("FormPaths/ZipPath") as XmlElement;
                if (zipPathElement == null) {
                    XmlElement formPaths = rootElement.SelectSingleNode("FormPaths") as XmlElement;
                    if (formPaths == null) {
                        formPaths = xmlDoc.CreateElement("FormPaths");
                        rootElement.AppendChild(formPaths);
                    }

                    zipPathElement = xmlDoc.CreateElement("ZipPath");
                    formPaths.AppendChild(zipPathElement);
                }
                zipPathElement.InnerText = Path.GetDirectoryName(zipPath);
            }

            if (!string.IsNullOrEmpty(logFilePath)) {
                XmlElement logFilePathElement = rootElement.SelectSingleNode("FormPaths/LogFilePath") as XmlElement;
                if (logFilePathElement == null) {
                    XmlElement formPaths = rootElement.SelectSingleNode("FormPaths") as XmlElement;
                    if (formPaths == null) {
                        formPaths = xmlDoc.CreateElement("FormPaths");
                        rootElement.AppendChild(formPaths);
                    }

                    logFilePathElement = xmlDoc.CreateElement("LogFilePath");
                    formPaths.AppendChild(logFilePathElement);
                }
                logFilePathElement.InnerText = logFilePath;
            }

            xmlDoc.Save(xmlFilePath);
        }

        private LastBinPaths _LoadLastPaths()
        {
            string folderPath = Application.StartupPath;
            string combinedPath = Path.Combine(folderPath, "XmlFolder");
            string xmlFilePath = Path.Combine(combinedPath, "MainFormPaths.xml");
            xmlFilePath = xmlFilePath.Replace("\\\\", "\\");

            try {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlFilePath);
                XmlNode zipPathNode = xmlDoc.SelectSingleNode("//ZipPath");
                XmlNode logFilePathNode = xmlDoc.SelectSingleNode("//LogFilePath");

                string zipPath = zipPathNode?.InnerText;
                string logFilePath = logFilePathNode?.InnerText;

                return new LastBinPaths {
                    ZipPath = zipPath,
                    LogFilePath = logFilePath
                };
            }
            catch (Exception) {
                return new LastBinPaths {
                    ZipPath = null,
                    LogFilePath = null
                };
            }
        }

        private void _LoadXmlFile()
        {
            LastBinPaths lastPath = _LoadLastPaths();
            string initialDirectory = lastPath.ZipPath;
            tbLogFilePath.Text = lastPath.LogFilePath;
            tbLogFilePath.SelectionStart = tbLogFilePath.Text.Length;

            if (string.IsNullOrEmpty(initialDirectory))
                initialDirectory = AppDomain.CurrentDomain.BaseDirectory;

            using (OpenFileDialog openFileDialog = new OpenFileDialog()) {
                openFileDialog.Title = "Files position";
                openFileDialog.Filter = "Zip Files (*.zip)|*.zip";
                openFileDialog.InitialDirectory = initialDirectory;

                if (openFileDialog.ShowDialog() == DialogResult.OK) {
                    string selectedFilePath = openFileDialog.FileName;
                    string extension = Path.GetExtension(selectedFilePath).ToLower();

                    if (extension == ".zip") {
                        try {
                            TempFolderPath = ExtractZipToTemporaryFolder(selectedFilePath);
                            SetHiddenAttribute(TempFolderPath);
                            string xmlFilePath = Path.Combine(TempFolderPath, "Cfg.xml");

                            if (File.Exists(xmlFilePath)) {
                                _ParserXmlForProjectInformation(xmlFilePath);
                                tbFilePath.Text = selectedFilePath;

                            }
                            else {
                                MessageBox.Show("Cfg.xml not found in the zip file.");
                            }
                        }
                        catch (Exception ex) {
                            MessageBox.Show("Failed to extract zip file: " + ex.Message);
                        }
                    }
                    
                    tbFilePath.SelectionStart = tbFilePath.Text.Length;
                }
            }
        }

        private string ExtractZipToTemporaryFolder(string zipFilePath)
        {
            string tempPath = Path.Combine(Path.GetTempPath(), Path.GetFileNameWithoutExtension(zipFilePath));

            using (ZipFile zip = ZipFile.Read(zipFilePath)) {
                zip.Password = "2368";
                zip.ExtractAll(tempPath, ExtractExistingFileAction.OverwriteSilently);
            }

            return tempPath;
        }

        private void SetHiddenAttribute(string folderPath)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(folderPath);
            dirInfo.Attributes |= FileAttributes.Hidden;
        }

        private void _SetLogFilePath()
        {
            string initialDirectory = Application.StartupPath;

            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog()) {
                folderBrowserDialog.Description = "Select a Folder";
                folderBrowserDialog.SelectedPath = initialDirectory;

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK) {
                    tbLogFilePath.Text = folderBrowserDialog.SelectedPath;
                    tbLogFilePath.SelectionStart = tbLogFilePath.Text.Length;
                    LogFileFolderPath = folderBrowserDialog.SelectedPath;
                    _SaveLastBinPaths(null, LogFileFolderPath);
                }
            }

        }

        private void _ParserXmlForProjectInformation_original(string filePath)
        {
            lApName.Text = "_";
            lDataName.Text = "_";

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);
            XmlNode permissionsNode = xmlDoc.SelectSingleNode("//Premissions");
            string role = permissionsNode.Attributes["role"].Value;
            XmlNode productNode = xmlDoc.SelectSingleNode("//Product");
            string productName = productNode.Attributes["name"].Value;
            XmlNode APROMNode = xmlDoc.SelectSingleNode("//APROM");
            string APROMName = APROMNode.Attributes["name"].Value;
            XmlNode DATAROMNode = xmlDoc.SelectSingleNode("//DATAROM");
            string DARAROMName = DATAROMNode.Attributes["name"].Value;

            lMode.Text = role;
            lProduct.Text = productName;

            if (!string.IsNullOrEmpty(APROMName))
                lApName.Text = APROMName;
            else
                MessageBox.Show("The configuration file format is incorrect.\nAPROM path not specified.", "Warning!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            if (!string.IsNullOrEmpty(DARAROMName))
                lDataName.Text = DARAROMName;
        }

        private void _ParserXmlForProjectInformation_method2(XmlDocument xmlDoc)
        {
            lApName.Text = "_";
            lDataName.Text = "_";

            XmlNode permissionsNode = xmlDoc.SelectSingleNode("//Premissions");
            string role = permissionsNode.Attributes["role"].Value;
            XmlNode productNode = xmlDoc.SelectSingleNode("//Product");
            string productName = productNode.Attributes["name"].Value;
            XmlNode APROMNode = xmlDoc.SelectSingleNode("//APROM");
            string APROMName = APROMNode.Attributes["name"].Value;
            XmlNode DATAROMNode = xmlDoc.SelectSingleNode("//DATAROM");
            string DARAROMName = DATAROMNode.Attributes["name"].Value;

            lMode.Text = role;
            lProduct.Text = productName;

            if (!string.IsNullOrWhiteSpace(APROMName))
                lApName.Text = APROMName;
            else
                MessageBox.Show("The configuration file format is incorrect.\nAPROM path not specified.", "Warning!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            if (!string.IsNullOrWhiteSpace(DARAROMName))
                lDataName.Text = DARAROMName;
        }

        private void _ParserXmlForProjectInformation(string filePath)
        {
            lApName.Text = "_";
            lDataName.Text = "_";

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);
            XmlNode permissionsNode = xmlDoc.SelectSingleNode("//Premissions");
            string role = permissionsNode.Attributes["role"].Value;
            XmlNode productNode = xmlDoc.SelectSingleNode("//Product");
            string productName = productNode.Attributes["name"].Value;
            XmlNode APROMNode = xmlDoc.SelectSingleNode("//APROM");
            string APROMName = APROMNode.Attributes["name"].Value;
            XmlNode DATAROMNode = xmlDoc.SelectSingleNode("//DATAROM");
            string DARAROMName = DATAROMNode.Attributes["name"].Value;

            lMode.Text = role;
            lProduct.Text = productName;

            if (!string.IsNullOrWhiteSpace(APROMName)) {
                lApName.Text = APROMName;
            }
            else {
                MessageBox.Show("The configuration file format is incorrect.\nAPROM path not specified.", "Warning!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (!string.IsNullOrWhiteSpace(DARAROMName)) {
                lDataName.Text = DARAROMName;
            }
        }

        private bool _PathCheck(Label lable)
        {
            string directoryPath = TempFolderPath;
            string fileName = lable.Text;
            string filePath = Path.Combine(directoryPath, fileName);

            if (File.Exists(filePath)) {
                if (Path.GetExtension(filePath).Equals(".bin", StringComparison.OrdinalIgnoreCase))
                    return true;
                else {
                    MessageBox.Show("Please verify if there is an error in the format of the Config file.");
                    return false;
                }
            }

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
            bool customerMode = lMode.Text == "Customer";
            int channelNumber = customerMode ? 1 : 13;

            if (tbFilePath.Text == "Please click here, to import the Config file...") {
                tbFilePath.Text = "";
                tbFilePath.ForeColor = Color.MidnightBlue;
            }

            _CleanTempFolder(); // Before change zip file, Clean the tempFolder
            _LoadXmlFile();

            if (lMode.Text == "Customer") {
                this.Size = new Size(550, 280);
                // rbSingle.Enabled = true;
                //rbBoth.Enabled = true;
                cbSecurityLock.Visible = false;
                gbOperatorMode.Visible = false;
                bWriteSnDateCone.Visible = false;
                tbOrignalSNCh1.Visible = false;
                tbOrignalSNCh2.Visible = false;
                tbReNewSnCh1.Visible = false;
                tbReNewSnCh2.Visible = false;
                lOriginalSN.Visible = false;
                lReNewSn.Visible = false;
                bCfgFileComparison.Visible = false;
                bLogFileComparison.Visible = false;
                bRenewRssi.Visible = false;
            }

            else if (lMode.Text == "MP") {
                this.Size = new Size(550, 445);
                rbSingle.Select();
                _GenerateDateCode();
                //rbSingle.Enabled = false;
                //rbBoth.Enabled = false;
                cbSecurityLock.Visible = true;
                gbOperatorMode.Visible = true;
                bWriteSnDateCone.Visible = true;
                tbOrignalSNCh1.Visible = true;
                tbOrignalSNCh2.Visible = true;
                tbReNewSnCh1.Visible = true;
                tbReNewSnCh2.Visible = true;
                lOriginalSN.Visible = true;
                lReNewSn.Visible = true;
                bCfgFileComparison.Visible = true;
                bLogFileComparison.Visible = true;
                bRenewRssi.Visible = true;

                if (rbBoth.Checked) {
                    tbOrignalSNCh2.Visible = true;
                    tbReNewSnCh2.Visible = true;
                }
                else {
                    tbOrignalSNCh2.Visible = false;
                    tbReNewSnCh2.Visible = false;
                }
            }

            I2cConnected = !(mainForm.ChannelSetApi(channelNumber) < 0);
        }
                
        private int _RxPowerUpdateWithoutThread()
        {
            if (mainForm.RxPowerReadApiFromDdmApi() < 0) {
                MessageBox.Show("Please check the module plugin status");
                return -1;
            }

            if (ProcessingChannel == 1) {
                tbRssiCh1_0.Text = _decimalRemove(mainForm.GetTextBoxTextFromDdmApi("tbRxPower1"));
                tbRssiCh1_1.Text = _decimalRemove(mainForm.GetTextBoxTextFromDdmApi("tbRxPower2"));
                tbRssiCh1_2.Text = _decimalRemove(mainForm.GetTextBoxTextFromDdmApi("tbRxPower3"));
                tbRssiCh1_3.Text = _decimalRemove(mainForm.GetTextBoxTextFromDdmApi("tbRxPower4"));
            }
            else if (ProcessingChannel == 2) {
                tbRssiCh2_0.Text = _decimalRemove(mainForm.GetTextBoxTextFromDdmApi("tbRxPower1"));
                tbRssiCh2_1.Text = _decimalRemove(mainForm.GetTextBoxTextFromDdmApi("tbRxPower2"));
                tbRssiCh2_2.Text = _decimalRemove(mainForm.GetTextBoxTextFromDdmApi("tbRxPower3"));
                tbRssiCh2_3.Text = _decimalRemove(mainForm.GetTextBoxTextFromDdmApi("tbRxPower4"));
            }

            return 0;
        }

        private string _decimalRemove(string text)
        {
            if (text == "4.4" || text == "4")
                return "0";
            

            int decimalIndex = text.IndexOf('.');
            if (decimalIndex != -1) {
                text = text.Substring(0, decimalIndex);
            }

            return text;
        }

        private void tbFilePath_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbFilePath.Text)) {
                tbFilePath.Text = "Please click here, to import the Config file...";
                tbFilePath.ForeColor = Color.Silver;
            }
        }
       
        private void _FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing) {
                I2cConnected = (mainForm.I2cMasterDisconnectApi() < 0);
                Application.Exit();
            }
            _CleanTempFolder();
        }

        private void _CleanTempFolder()
        {
            if (Directory.Exists(TempFolderPath)) {
                try {
                    Directory.Delete(TempFolderPath, true);
                }
                catch (Exception ex) {
                    MessageBox.Show("Failed to delete temporary folder: " + ex.Message);
                }
            }
        }
        private void _DisableButtonsForBarcodeMode()
        {
            bStart.Enabled = false;
            bWriteSnDateCone.Enabled = false;
            bCfgFileComparison.Enabled = false;
            bLogFileComparison.Enabled = false;
            bRenewRssi.Enabled = false;
            gbCodeEditor.Enabled = false;
            tbLogFilePath.Enabled = false;
            tbVenderSn.Enabled = true;
        }
        private void _EnableButtonsForBarcodeMode()
        {
            bStart.Enabled = true;
            bWriteSnDateCone.Enabled = true;
            bCfgFileComparison.Enabled = true;
            bLogFileComparison.Enabled = true;
            bRenewRssi.Enabled = true;
            gbCodeEditor.Enabled = true;
            tbVenderSn.Enabled = false;
            tbLogFilePath.Enabled = true;
            tbFilePath.Enabled = true;
            rbSingle.Enabled = true;
            rbBoth.Enabled = true;
            cbSecurityLock.Enabled = true;
            cbI2cConnect.Enabled = true;
            cbEngineerMode.Enabled = true;
        }

        private void _DisableButtons()
        {
            //loadingForm.Show(this);
            tbLogFilePath.Enabled = false;
            tbFilePath.Enabled = false;
            bStart.Enabled = false;
            rbSingle.Enabled = false;
            rbBoth.Enabled = false;
            cbSecurityLock.Enabled = false;
            cbI2cConnect.Enabled = false;
            //cbBypassW.Enabled = false;
            cbEngineerMode.Enabled = false;
            //gbOperatorMode.Enabled = false;
            button2.Enabled = false;
            bWriteSnDateCone.Enabled = false;
            bCfgFileComparison.Enabled = false;
            bLogFileComparison.Enabled = false;
            bRenewRssi.Enabled = false;
        }

        private void _EnableButtons()
        {
            tbFilePath.Enabled = true;
            bStart.Enabled = true;
            rbSingle.Enabled = true;
            rbBoth.Enabled = true;
            cbSecurityLock.Enabled = true;
            cbI2cConnect.Enabled = true;
            //cbBypassW.Enabled = true;
            cbEngineerMode.Enabled = true;
            //gbOperatorMode.Enabled = true;
            button2.Enabled = true;
            bWriteSnDateCone.Enabled = true;
            bCfgFileComparison.Enabled = true;
            bLogFileComparison.Enabled = true;
            bRenewRssi.Enabled = true;
            //loadingForm.Close();
            this.BringToFront();
            this.Activate();
        }

        private int _RemoteControl(bool customerMode)
        {
            string DirectoryPath = TempFolderPath;
            string RegisterFileName = "RegisterFile.csv";
            string RegisterFilePath = Path.Combine(DirectoryPath, RegisterFileName); //Generate the CfgFilePath with config folder
            string BackupFileName = "ModuleRegisterFile";
            int channelNumber = (lMode.Text == "Customer" || lMode.Text == "") ? 1 : 13;

            if (DebugMode) {
                MessageBox.Show("directoryPath: \n" + DirectoryPath +
                                "\nRegisterFilePath: \n" + RegisterFilePath);
            }

            if (!((_PathCheck(lApName)) || (_PathCheck(lDataName)))) {
                MessageBox.Show("No file path specified. Please choose the file again.", "Config file", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }
            else {
                I2cConnected = !(mainForm.ChannelSetApi(channelNumber) < 0);
                _RxPowerUpdateWithoutThread();
                mainForm.ExportLogfileApi(BackupFileName, true, false); //目標模組Cfg Backup

                if (ProcessingChannel == 1) {
                    mainForm.SetToChannle2Api(false);
                    tbVersionCodeCh1.Text = mainForm.GetFirmwareVersionCodeApi();
                }
                else if (ProcessingChannel == 2) {
                    mainForm.SetToChannle2Api(true);
                    tbVersionCodeCh2.Text = mainForm.GetFirmwareVersionCodeApi();
                }

                if (DebugMode)
                    MessageBox.Show("GlobalRead...Done");

                //Set ICPTool Funciton
                mainForm.SetAutoReconnectApi(true); // An automatic connection to MCU will be initiated.
                mainForm.SetBypassEraseAllCheckModeApi(true); // Avoid the intervention of MessgaeBox

                if (DebugMode) {
                    MessageBox.Show("AutoReconnec mode: " + mainForm.GetAutoReconnectApi()
                                + "\nBypassEraseAll mode " + mainForm.GetBypassEraseAllCheckModeApi()
                                );
                }

                mainForm.ForceConnectApi(0,0); // Link DUT and EraseAPROM
                Thread.Sleep(10);
                mainForm.StartFlashingApi(); // Firmware update
                Thread.Sleep(10);
                mainForm._GlobalWriteFromRegisterMap(customerMode, RegisterFilePath);
                Thread.Sleep(10);

                /*
                if (!customerMode)
                    mainForm.ComparisonRegisterApi(RegisterFilePath, false , cbEngineerMode.Checked);
                */
                
                Thread.Sleep(10);

                if (ProcessingChannel == 1) {
                    lCh1Message.Text = "Update completed.";
                    cProgressBar1.Value = 100;
                    cProgressBar1.Text = "100%";
                    tbVersionCodeReNewCh1.Text = mainForm.GetFirmwareVersionCodeApi();
                }
                else if (ProcessingChannel == 2) {
                    lCh2Message.Text = "Update completed.";
                    cProgressBar2.Value = 100;
                    cProgressBar2.Text = "100%";
                    tbVersionCodeReNewCh2.Text = mainForm.GetFirmwareVersionCodeApi();
                }

                Application.DoEvents();
                Thread.Sleep(100);
            }

            return 0;
        }

        private int _WriteSnDatecode(int ch)
        {
            string venderSn;
            string originalVenderSn, originalDateCode;
            string LogFileName = CurrentDate + Revision.ToString("D2") + SerialNumber.ToString("D4");
            int channelNumber;

            if (ch == 1) {
                LogFileName = LogFileName + "A";
                channelNumber = (lMode.Text == "Customer" || lMode.Text == "") ? 1 : 13;
            }
            else {
                LogFileName = LogFileName + "B";
                channelNumber = (lMode.Text == "Customer" || lMode.Text == "") ? 2 : 23;
            }

            I2cConnected = !(mainForm.ChannelSetApi(channelNumber) < 0);
            Thread.Sleep(100);

            _UpdateMessage(ch, "CheckVendorSN");
            if (mainForm.InformationReadApi() < 0) return -1;
            originalVenderSn = mainForm.GetVendorSnFromDdmiApi();
            originalDateCode = mainForm.GetDateCodeFromDdmiApi();

            if (ProcessingChannel == 1) {
                tbOrignalSNCh1.Text = originalVenderSn;
                tbOrignalSNCh1.BackColor = Color.DarkBlue;
                tbOrignalSNCh1.ForeColor = Color.White;
            }
            else {
                tbOrignalSNCh2.Text = originalVenderSn;
                tbOrignalSNCh2.BackColor = Color.DarkBlue;
                tbOrignalSNCh2.ForeColor = Color.White;
            }

            venderSn = tbVenderSn.Text;

            if (DebugMode) {
                mainForm.SetVendorSnToDdmiApi(venderSn);
                mainForm.SetDataCodeToDdmiApi(CurrentDate);
                MessageBox.Show("Information check"
                            + "\nBefore:\n"
                            + "VenderSn: " + originalVenderSn
                            + "\nDateCode: " + originalDateCode
                            + "\n\nAfter:\n"
                            + "VerderSn: " + mainForm.GetVendorSnFromDdmiApi()
                            + "\nDateCode:" + mainForm.GetDateCodeFromDdmiApi()
                            );
            }
            else {
                mainForm.SetVendorSnToDdmiApi(venderSn);
                mainForm.SetDataCodeToDdmiApi(CurrentDate);
            }

            _UpdateMessage(ch, "Write..Start");
            
            if (mainForm.InformationWriteApi() < 0) return -1;
            Thread.Sleep(100);
            _UpdateMessage(ch, "Write..Done");
            if (mainForm.InformationStoreIntoFlashApi() < 0) return -1;
            Thread.Sleep(100);
            _UpdateMessage(ch, "StoreFlash..Done");
            if (mainForm.InformationReadApi() < 0) return -1;
            Thread.Sleep(10);

            if (ProcessingChannel == 1) {
                tbReNewSnCh1.Text = mainForm.GetVendorSnFromDdmiApi();
                tbReNewSnCh1.BackColor = Color.DarkBlue;
                tbReNewSnCh1.ForeColor = Color.White;
            }
                
            else if (ProcessingChannel == 2) {
                tbReNewSnCh2.Text = mainForm.GetVendorSnFromDdmiApi();
                tbReNewSnCh2.BackColor = Color.DarkBlue;
                tbReNewSnCh1.ForeColor = Color.White;
            }
            
            if (_RxPowerUpdateWithoutThread() < 0) return -1;
            if (mainForm.ExportLogfileApi(LogFileName, true, true) < 0) return -1; //Must be implement
            Thread.Sleep(10);
            _UpdateMessage(ch, "LogFile..exported");

            return 0;
        }

        private void _UpdateMessage(int channel, string message)
        {
            string msgLabel = channel == 1 ? "lCh1Message" : "lCh2Message";
            switch (msgLabel) {
                case "lCh1Message":
                    lCh1Message.Text = message;
                    //cProgressBar1.Value = value;
                    //cProgressBar1.Text = value.ToString() + "%";
                    break;
                case "lCh2Message":
                    lCh2Message.Text = message;
                    //cProgressBar2.Value = value;
                    //cProgressBar2.Text = value.ToString() + "%";
                    break;
            }
            Application.DoEvents();
        }
        
        private int _Processor(bool customerMode) // True: Customer Mode, Flase: MP mode
        {
            _DisableButtons();
            int channelNumber = customerMode ? 1 : 13;

            loadingForm.Show(this);
            _InitialUi();
            _SaveLastBinPaths(tbFilePath.Text, null);
            I2cConnected = (mainForm.I2cMasterDisconnectApi() < 0);
            I2cConnected = !(mainForm.ChannelSetApi(channelNumber) < 0);

            for (ProcessingChannel = 1; ProcessingChannel <= (DoubleSideMode ? 2 : 1); ProcessingChannel++) {
                if (_RemoteInitial(customerMode) < 0) {
                    loadingForm.Close();
                    return -1;
                }

                if (_RemoteControl(customerMode) < 0) {
                    loadingForm.Close();
                    return -1;
                }

                //if (!customerMode)
                //_WriteSnDatecode(ProcessingChannel); // Writing SN and DateCode, then export csv file.

                if (ProcessingChannel == 1 && DoubleSideMode) {
                    if (DebugMode)
                        MessageBox.Show("Switch channel");

                    mainForm.ChannelSwitchApi(customerMode); // switch to ch2
                    I2cConnected = (mainForm.I2cMasterDisconnectApi() < 0);
                    I2cConnected = !(mainForm.ChannelSetApi(channelNumber) < 0);
                }

                FirstRound = false;
            }

            if (DoubleSideMode) {
                mainForm.ChannelSwitchApi(customerMode); // return to ch1
                I2cConnected = (mainForm.I2cMasterDisconnectApi() < 0);
                I2cConnected = !(mainForm.ChannelSetApi(channelNumber) < 0);
            }

            ProcessingChannel = 1;
            if (!cbBarcodeMode.Checked)
                _EnableButtons();
            loadingForm.Close();
            return 0;
        }

        private int ValidateVenderSn()
        {
            string venderSn = tbVenderSn.Text;

            if (venderSn.Length != 12) {
                MessageBox.Show("The serial number must be 12 characters long.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            int yy = int.Parse(venderSn.Substring(0, 2));
            if (yy < 23 || yy > 30) {
                MessageBox.Show("The first two digits(YY) must be between 23 and 30.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            int mm = int.Parse(venderSn.Substring(2, 2));
            if (mm < 1 || mm > 12) {
                MessageBox.Show("The 3~4 digits(MM) must be between 01 and 12.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            int dd = int.Parse(venderSn.Substring(4, 2));
            if (dd < 1 || dd > 31) {
                MessageBox.Show("The 5~6 digits(DD) must be between 01 and 31.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            int ssss = int.Parse(venderSn.Substring(8, 4));
            if (ssss < 1 || ssss > 9999) {
                MessageBox.Show("The 9~12 digits(SSSS) must be between 0001 and 9999.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            return 0;
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            bool isCustomerMode = (lMode.Text == "Customer" || lMode.Text == "");

            if ((isCustomerMode || lMode.Text == "MP") &&
                _Processor(isCustomerMode) < 0) {
                MessageBox.Show("There are some problems", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
        }

        private void I2cMasterConnect_CheckedChanged(object sender, EventArgs e)
        {
            int channelNumber;

            if ((lMode.Text == "Customer") || (lMode.Text == ""))
                channelNumber = 1;
            else
                channelNumber = 13;

            if (cbI2cConnect.Checked) {
                if (!(mainForm.ChannelSetApi(channelNumber) < 0))
                    I2cConnected = true;
                else {
                    MessageBox.Show("I2c master connection failed.\nPlease check if the hardware configuration or UI is activated.",
                                    "I2c master connection failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
            else
                I2cConnected = (mainForm.I2cMasterDisconnectApi() < 0);
        }

        private void tbLogFilePath_Click(object sender, EventArgs e)
        {
            _SetLogFilePath();
        }
                       
        private void button2_Click(object sender, EventArgs e)
        {
            _DisableButtons();

            string DirectoryPath = Application.StartupPath;
            string TempRegisterFilePath = Path.Combine(DirectoryPath, "LogFolder/TempRegister.csv");

            mainForm.WriteRegisterPageApi("Up 00h", 50, TempRegisterFilePath);
            mainForm.WriteRegisterPageApi("Up 03h", 50, TempRegisterFilePath);
            mainForm.WriteRegisterPageApi("80h", 200, TempRegisterFilePath);
            mainForm.WriteRegisterPageApi("81h", 200, TempRegisterFilePath);
            mainForm.WriteRegisterPageApi("Rx", 1000, TempRegisterFilePath);
            mainForm.WriteRegisterPageApi("Tx", 1000, TempRegisterFilePath);
            mainForm.StoreIntoFlashApi();
            mainForm._GlobalRead();
            string LogFileName = "AfterFlasing";
            mainForm.ExportLogfileApi(LogFileName, true, true);

            /*
            string[] commands = { "Up 00h", "Up 03h", "80h", "81h", "Tx", "Rx" };
            
            foreach(var command in commands) {             
                mainForm.WriteRegisterPageApi(command);
                Thread.Sleep(500);
            }
            */

            _EnableButtons();
        }

        private int WriteSnDateCode()
        {
            loadingForm.Show(this);
            string DirectoryPath = TempFolderPath;
            string RegisterFilePath = Path.Combine(DirectoryPath, "RegisterFile.csv"); //Generate the CfgFilePath with config folder
            FirstRound = true;  //??
            
            _DisableButtons();
            _InitialUi();
            _InitialUiForWriteSn();

            if (_VenderSnInputFormatCheck() < 0)
                return -1;

            for (ProcessingChannel = 1; ProcessingChannel <= (DoubleSideMode ? 2 : 1); ProcessingChannel++) {
                if (_WriteSnDatecode(ProcessingChannel) < 0) return -1; // Writing SN and DateCode, then export csv file.

                _UpdateMessage(ProcessingChannel, "VenderSN writed");

                if (ProcessingChannel == 1) {
                    tbVenderSn.Text = CurrentDate + Revision.ToString("D2") + SerialNumber.ToString("D4");
                    tbVersionCodeCh1.Text = mainForm.GetFirmwareVersionCodeApi();
                }
                else if (ProcessingChannel == 2) {
                    tbVersionCodeCh2.Text = mainForm.GetFirmwareVersionCodeApi();
                }

                if (mainForm.ComparisonRegisterApi(RegisterFilePath, true, "CfgFile", cbEngineerMode.Checked) < 0)
                    return -1;
                Application.DoEvents();

                Thread.Sleep(100);
                if (!DoubleSideMode) {
                    break;
                }
                
            }

            if (DoubleSideMode) {
               if (mainForm.ChannelSwitchApi(false) < 0) return -1; // return to ch1
            }

            SerialNumber++;
            tbVenderSn.Text = CurrentDate + Revision.ToString("D2") + SerialNumber.ToString("D4");

            this.BringToFront();
            this.Activate();
            
            if(!cbBarcodeMode.Checked)
                _EnableButtons();

            loadingForm.Close();
            return 0;
        }

        private void _GenerateDateCode()
        {
            int initilaSN1 = 1;
            //int initilaSN2 = 2;

            tbVenderSn.Text = CurrentDate + Revision.ToString("D2") + initilaSN1.ToString("D4");
            //tbVenderSnCh2.Text = CurrentDate + Revision.ToString("D2") + initilaSN2.ToString("D4");
            tbDateCode.Text = CurrentDate;
        }

        private int _VenderSnInputFormatCheck()
        {
            int serialNumber1, serialNumber2;
            string newSerialNumber1, newSerialNumber2;

            try {

                string inputdata = tbVenderSn.Text;

                if (inputdata.Length != 12) {
                    MessageBox.Show("The SN must be exactly 12 characters long." +
                                    "\nPlease enter a valid Vender SN (YYMMDDRRSSSS).");
                    tbVenderSn.Text = CurrentDate + Revision.ToString("D2") + SerialNumber.ToString("D4");
                    return -1;
                }

                CurrentDate = inputdata.Substring(0, 6).ToString(); // Get YYMMDD
                Revision = Convert.ToInt16(inputdata.Substring(6, 2)); // Get RR
                SerialNumber = Convert.ToInt16(inputdata.Substring(8, 4)); // Get SSSS

                if (DebugMode) {
                    MessageBox.Show("YYMMDD: " + CurrentDate +
                                    "\nRR: " + Revision +
                                    "\nssssPart: " + SerialNumber);
                }

                serialNumber1 = SerialNumber;

                if (serialNumber1 < MinSerialNumber || serialNumber1 > MaxSerialNumber) {
                    MessageBox.Show("Invalid serial number in VenderSN" +
                                    $"Serial number must be between {MinSerialNumber:D4} and {MaxSerialNumber:D4}.");
                    return -1;
                }

              
                newSerialNumber1 = serialNumber1.ToString("0000");
                tbVenderSn.Text = $"{CurrentDate}{Revision.ToString("D2")}{newSerialNumber1}";
            }
            catch (Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
                return -1;
            }

            return 0;

        }

        private void _PromptCorrect()
        {
            if (cbBarcodeMode.Checked) {
                gbPrompt.Visible = true;
                gbPrompt.BackColor = Color.SpringGreen;
                lStatus.Visible = true;
                lStatus.Text = "Correct";
            }
           
            _UpdateMessage(ProcessingChannel, "Verify State:\nLogfile are matching");

        }
        private void _PromptWrong()
        {
            if (cbBarcodeMode.Checked) {
                gbPrompt.Visible = true;
                gbPrompt.BackColor = Color.Violet;
                lStatus.Visible = true;
                lStatus.Text = "Wrong !!";
            }
            
            _UpdateMessage(ProcessingChannel, "Verify State:\nWrong !!");
        }

        private void _PromptError()
        {
            if (cbBarcodeMode.Checked) {
                gbPrompt.Visible = true;
                gbPrompt.BackColor = Color.HotPink;
                lStatus.Visible = true;
                lStatus.Text = "Error !!";
            }
            
            _UpdateMessage(ProcessingChannel, "Verify State:\nLogfile Mismatch!!");
        }

        private void _PromptCompleted()
        {
            if (cbBarcodeMode.Checked) {
                gbPrompt.Visible = true;
                gbPrompt.BackColor = Color.SpringGreen;
                lStatus.Visible = true;
                lStatus.Text = "Completed";
            }
            
            _UpdateMessage(ProcessingChannel, "Completed");
        }

        private void _PromptInitialUi()
        {
            if (cbBarcodeMode.Checked) {
                gbPrompt.Visible = true;
                gbPrompt.BackColor = Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(145)))), ((int)(((byte)(168)))));
                lStatus.Visible = true;
                lStatus.Text = "...";
            }
        }

        private void bWriteSnDateCode_Click(object sender, EventArgs e)
        {
            try {
                this.Enabled = false;
                WriteSnDateCode();
            }
            finally {
                this.Enabled = true;
            }
        }

        private void bCfgFileComparison_Click(object sender, EventArgs e)
        {
            _CfgFileComparison();
        }

        private int _CfgFileComparison()
        {
            int ComparisonResults = 0;
            int ChannelNumber = 1;
            string DirectoryPath = TempFolderPath;
            string RegisterFilePath = Path.Combine(DirectoryPath, "RegisterFile.csv"); //Generate the CfgFilePath with config folder
            FirstRound = true;

            loadingForm.Show(this);
            _DisableButtons();
            _InitialUi();

            for (ProcessingChannel = 1; ProcessingChannel <= (DoubleSideMode ? 2 : 1); ProcessingChannel++) {
                if (ProcessingChannel == 1)
                    ChannelNumber = (lMode.Text == "Customer" || lMode.Text == "") ? 1 : 13;
                else
                    ChannelNumber = (lMode.Text == "Customer" || lMode.Text == "") ? 2 : 23;

                I2cConnected = !(mainForm.ChannelSetApi(ChannelNumber) < 0);
                Thread.Sleep(300);

                ComparisonResults = mainForm.ComparisonRegisterApi(RegisterFilePath, true, "CfgFile", cbEngineerMode.Checked);
                Thread.Sleep(100);

                if (!DoubleSideMode)
                    break;
            }

            if (DoubleSideMode)
                if (mainForm.ChannelSwitchApi(false) < 0)
                    return -1;

            this.BringToFront();
            this.Activate();
            loadingForm.Close();

            if (!cbBarcodeMode.Checked)
                _EnableButtons();

            if (ComparisonResults < 0)
                return -1;
            else if (ComparisonResults == 1)
                return 1;
            else
                return 0;
        }

        private void bLogFileComparison_Click(object sender, EventArgs e)
        {
            int ComparisonResults = _LogFileComparison();

            if (ComparisonResults < 0)
                _PromptError();
            else if (ComparisonResults == 1)
                _PromptWrong();
            else
                _PromptCorrect();
        }

        private int _LogFileComparison()
        {
            int ComparisonResults = 0;
            int ChannelNumber = 1;
            string DirectoryPath = tbLogFilePath.Text;
            string ObjectFileName = tbVenderSn.Text + "A";
            string RegisterFilePath = Path.Combine(DirectoryPath, ObjectFileName + ".csv"); //Generate the CfgFilePath with config folder
            //mainForm.InformationReadApi();
            //string OriginalVenderSn = mainForm.GetVendorSnFromDdmiApi();
            //string OriginalDateCode = mainForm.GetDateCodeFromDdmiApi();
            FirstRound = true;

            if (!Directory.Exists(DirectoryPath)) {
                MessageBox.Show("Please check if the log file path has been correctly specified?");
                return-1;
            }

            if (!File.Exists(RegisterFilePath)) {
                MessageBox.Show("Please check if the log file exists at the specified path?" +
                                "\n\nTarget path: " + DirectoryPath + "\\..." +
                                "\nModule SN: " + ObjectFileName + ".csv" + "   <<Missing file");
                return-1;
            }

            loadingForm.Show(this);
            _DisableButtons();
            _InitialUi();

            for (ProcessingChannel = 1; ProcessingChannel <= (DoubleSideMode ? 2 : 1); ProcessingChannel++) {
                if (ProcessingChannel == 1) 
                    ChannelNumber = (lMode.Text == "Customer" || lMode.Text == "") ? 1 : 13;
                else 
                    ChannelNumber = (lMode.Text == "Customer" || lMode.Text == "") ? 2 : 23;

                I2cConnected = !(mainForm.ChannelSetApi(ChannelNumber) < 0);
                Thread.Sleep(300);

                ComparisonResults = mainForm.ComparisonRegisterApi(RegisterFilePath, true, "LogFile", cbEngineerMode.Checked);
                Thread.Sleep(100);

                if (!DoubleSideMode) 
                    break;
            }

            if (DoubleSideMode) 
                if (mainForm.ChannelSwitchApi(false) < 0) return -1;

            this.BringToFront();
            this.Activate();
            loadingForm.Close();

            if (!cbBarcodeMode.Checked) 
                _EnableButtons();

            if (ComparisonResults < 0)
                return -1;
            else if (ComparisonResults == 1)
                return 1;
            else                
                return 0;
            
        }

        private void cbBarcodeMode_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBarcodeMode.Checked) {
                _DisableButtonsForBarcodeMode();
                rbSingle.Enabled = false;
                rbBoth.Enabled = false;
                rbSingle.Checked = true;
                rbFullMode.Visible = true;
                rbOnlySN.Visible = true;
                rbLogFileMode.Visible = true;
                tbVenderSn.Text = "";
                tbVenderSn.Select();
                gbPrompt.Visible = true;
                _PromptInitialUi();
            }
            else {
                rbSingle.Enabled = true;
                rbBoth.Enabled = true;
                rbFullMode.Visible = false;
                rbOnlySN.Visible = false;
                rbLogFileMode.Visible = false;
                gbPrompt.Visible = false;
                UpdateTextBoxAA();
                _EnableButtonsForBarcodeMode();
            }
        }

        private void ReRssi_Click(object sender, EventArgs e)
        {
            loadingForm.Show(this);
            _DisableButtons();
            mainForm.ChannelSetApi(13);
            ProcessingChannel = 1;
            _RxPowerUpdateWithoutThread();

            if (rbBoth.Checked) {
                mainForm.ChannelSetApi(23);
                ProcessingChannel = 2;
                Thread.Sleep(500);
                _RxPowerUpdateWithoutThread();
                Thread.Sleep(200);
                mainForm.ChannelSetApi(13);
            }
            
            _EnableButtons();
            loadingForm.Close();
        }

        private void PerformLongRunningOperation()
        {
            System.Threading.Thread.Sleep(5000); // 模擬一個5秒的操作
        }

        private void BarcodeMode_CheckedChanged(object sender, EventArgs e)
        {
            tbVenderSn.Select();
        }

        private void bRelinkTest_Click(object sender, EventArgs e)
        {
            loadingForm.Show(this);
            int relinkCount, timeInterval;
            _DisableButtons();
            ForceConnectWithoutInvoke = true;

            if (string.IsNullOrEmpty(tbRelinkCount.Text) || string.IsNullOrEmpty(tbTimeInterval.Text)) {
                int.TryParse(tbRelinkCount.Text, out relinkCount);
                int.TryParse(tbTimeInterval.Text, out timeInterval);
                mainForm.ForceConnectApi(relinkCount, timeInterval);
            }
            else
                mainForm.ForceConnectApi(0, 0);


            ForceConnectWithoutInvoke = false;
            _EnableButtons();
            loadingForm.Close();
        }
    }

    public class LastBinPaths
    {
        public string ZipPath { get; set; }
        public string LogFilePath { get; set; }
    }

}

