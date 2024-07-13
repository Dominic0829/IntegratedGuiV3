using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using I2cMasterInterface;
using ExfoIqs1600ScpiInterface;
using System.Xml;

using ComponentFactory.Krypton.Toolkit;
using Mald37045cMata37044c;
using QsfpDigitalDiagnosticMonitoring;
using Rt145Rt146Config;
using System.Threading;
using System.Runtime.Remoting.Channels;
using System.Web.UI.Design;
using System.Security.Policy;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Threading.Tasks;
using NuvotonIcpTool;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using Gn1190Corrector;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;
using System.Globalization;

namespace IntegratedGuiV2
{
    public partial class MainForm : KryptonForm
    {
        private I2cMaster i2cMaster = new I2cMaster();
        private DataTable dtWriteConfig = new DataTable();

        private short iBitrate = 400; //kbps
        private short TriggerDelay = 100; //ms
        private int ProcessingChannel = 0;
        private bool FirstRead = false;
        private bool AutoSelectIcConfig = false;
        private int ErrorState = 0;
        private string sAcConfig;
        private string APROMPath, DATAROMPath;
        private bool writeToFile = false;
        private string fileName = "3234.cfg";
        private bool DebugMode = false;
        private bool I2cConnected = false;
        private bool BypassWriteIcConfig = false;
        private bool FirstRound = true;
        private bool FlagFwUpdated = false;
        private string userRole = "";
        private string lastUsedDirectory;

        public bool InformationReadState { get; private set; }
        public bool DdmReadState { get; private set; }
        public bool MemDumpReadState { get; private set; }
        public bool CorrectorReadState { get; private set; }
        public string FwVersionCode, FwVersionCodeCheck;

        public event EventHandler<string> ReadStateUpdated;
        public event EventHandler<int> ProgressValue;
        public event EventHandler<MessageEventArgs> MainMessageUpdated;
        public event EventHandler<TextBoxTextEventArgs> TextBoxTextChanged;

        
        protected virtual void StateUpdated(string message, int value)
        {
            ReadStateUpdated?.Invoke(this, message);
            ProgressValue?.Invoke(this, value);
            Application.DoEvents();
        }

        private void SetupControlEvents()
        {
            ucNuvotonIcpTool.LinkTextUpdated += new UcNuvotonIcpTool.LinkTextUpdatedEventHandler(ucNuvotonIcp_LinkTextUpdated);
        }

        private void ucNuvotonIcp_LinkTextUpdated(string text)
        {
            
            if (this.bIcpConnect.InvokeRequired)// 檢查是否需要跨執行緒調用
                this.bIcpConnect.Invoke(new Action(() => this.bIcpConnect.Text = text));
            else
                this.bIcpConnect.Text = text;
        }

        public string GetValueFromUcRt146Config(string comboBoxId)
        {
            return ucRt146Config.GetComboBoxSelectedValue(comboBoxId);
        }

        public string GetValueFromUcRt145Config(string comboBoxId)
        {
            return ucRt145Config.GetComboBoxSelectedValue(comboBoxId);
        }

        public string GetFirmwareVersionCodeApi()
        {
            return _GetFirmwareVersionCode();
        }

        public List<string> GetComboBoxItems()
        {
            List<string> items = new List<string>();

            foreach (var item in cbProductSelect.Items)
            {
                items.Add(item.ToString());
            }

            return items;
        }

        public string GetSelectedProduct()
        {
            if (cbProductSelect.InvokeRequired)
                return (string)cbProductSelect.Invoke(new Func<string>(() => (string)cbProductSelect.SelectedItem));
            else
                return (string)cbProductSelect.SelectedItem;
        }

        public Dictionary<string, bool> GetCheckBoxStates()
        {
            return new Dictionary<string, bool>
            {
                { "cbInfomation", cbInfomation.Checked },
                { "cbDdm", cbDdm.Checked },
                { "cbMemDump", cbMemDump.Checked },
                { "cbCorrector", cbCorrector.Checked },
                { "cbTxIcConfig", cbTxIcConfig.Checked },
                { "cbRxIcConfig", cbRxIcConfig.Checked }
            };
        }

        public void SelectProductApi(string selectedProduct)
        {
            if (cbProductSelect.InvokeRequired)
                cbProductSelect.Invoke(new Action(() => CheckAndSelectProduct(selectedProduct)));
            else
                CheckAndSelectProduct(selectedProduct);
        }

        private void CheckAndSelectProduct(string selectedProduct)
        {
            if (cbProductSelect.Items.Contains(selectedProduct))
                cbProductSelect.SelectedItem = selectedProduct;
            else
                MessageBox.Show("Product not found in the ComboBox.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void SetCheckboxCheckedApi(CheckBox checkbox, bool value)
        {
            if (checkbox.InvokeRequired)
                checkbox.Invoke(new Action(() => checkbox.Checked = value));
            else
                checkbox.Checked = value;
        }

        public void SetCheckBoxCheckedByNameApi(string checkBoxName, bool value)
        {
            CheckBox checkBox = GetCheckBoxByName(checkBoxName);
            if (checkBox != null)
                SetCheckboxCheckedApi(checkBox, value);
        }

        public bool GetVarBoolStateApi(string varName)
        {
            Type type = this.GetType();

            FieldInfo field = type.GetField(varName, BindingFlags.NonPublic | BindingFlags.Instance);

            if (field != null && field.FieldType == typeof(bool))
            {
                return (bool)field.GetValue(this);
            }
            else
            {
                throw new ArgumentException("Invalid Var Name or Var is not a bool type");
            }
        }

        public void SetVarBoolStateToMainFormApi(string varName, bool value)
        {
            Type type = this.GetType();
            FieldInfo field = type.GetField(varName, BindingFlags.NonPublic | BindingFlags.Instance);

            if (field != null && field.FieldType == typeof(bool))
            {
                field.SetValue(this, value);
            }
            else
            {
                throw new ArgumentException("Invalid Var Name or Var is not a bool type");
            }
        }

        public void ExportRegisterToCsvApi(string fileName)
        {
            if (this.InvokeRequired)
                this.Invoke(new Action(() => _ExportRegisterToCsv(fileName)));
            else
                _ExportRegisterToCsv(fileName);
        }

        public void ExportLogfileToCsvApi(string fileName, bool logFileMode, bool writeSnMode)
        {
            if (this.InvokeRequired)
                this.Invoke(new Action(() => _ExportLogfileToCsv(fileName, logFileMode, writeSnMode)));
            else
                _ExportLogfileToCsv(fileName, logFileMode, writeSnMode);
        }

        public void ForceConnectSingleApi() // Used for MpForm
        {
            if (this.InvokeRequired)
                this.Invoke(new Action(() => ucNuvotonIcpTool.ForceConnectSingleApi()));
            else
                ucNuvotonIcpTool.ForceConnectSingleApi();
        }

        public void StartFlashingApi() // Used for MpForm
        {
            if (this.InvokeRequired)
                this.Invoke(new Action(() => ucNuvotonIcpTool.StartFlashingApi()));
            else
                ucNuvotonIcpTool.StartFlashingApi();
        }

        public void StoreIntoFlashApi()
        {
            if (this.InvokeRequired)
                this.Invoke(new Action(() => ucInformation.StoreIntoFlashApi()));
            else
                ucInformation.StoreIntoFlashApi();
        }

        public void InformationWriteApi() // Used for MpForm
        {
            if (this.InvokeRequired)
                this.Invoke(new Action(() => ucInformation.WriteApi()));
            else
                ucInformation.WriteApi();
        }
        /*
        public void WriteUpPage0LiteApi(string vendorSn, string dataCode)
        {
            if (this.InvokeRequired)
                this.Invoke(new Action(() => ucInformation.WriteUpPage0LiteApi(vendorSn, dataCode)));
            else
                ucInformation.WriteUpPage0LiteApi(vendorSn, dataCode);
        }
        */
        public void InformationStoreIntoFlashApi() // Used for MpForm
        {
            if (this.InvokeRequired)
                this.Invoke(new Action(() => ucInformation.StoreIntoFlashApi()));
            else
                ucInformation.StoreIntoFlashApi();
        }

        public void InformationReadApi() // Used for MpForm
        {
            if (this.InvokeRequired)
                this.Invoke(new Action(() => ucInformation.ReadApi()));
            else
                ucInformation.ReadApi();
        }

        public void SetToChannle2Api(bool mode)
        {
            if (this.InvokeRequired)
                this.Invoke(new Action(() => _SetToChannel2(mode)));
            else
                _SetToChannel2(mode);
        }

        public void SetAutoReconnectApi(bool Mode)
        {
            if (this.InvokeRequired)
                this.Invoke(new Action(() => _SetAutoReconnectControl(Mode)));
            else
                _SetAutoReconnectControl(Mode);
        }

        public void SetBypassEraseAllCheckModeApi(bool Mode)
        {
            if (this.InvokeRequired)
                this.Invoke(new Action(() => _SetBypassEraseAllControl(Mode)));
            else
                _SetBypassEraseAllControl(Mode);
        }

        public bool GetAutoReconnectApi()
        {
            if (this.InvokeRequired)
                return (bool)this.Invoke(new Action(()  => _GetAutoReconnectControl()));
            else
                return _GetAutoReconnectControl();
        }

        public bool GetBypassEraseAllCheckModeApi()
        {
            if (this.InvokeRequired)
                return (bool)this.Invoke(new Action(() => _GetBypassEraseAllControl()));
            else
                return _GetBypassEraseAllControl();
        }

        public int WriteRegisterPageApi(string targetPage, int delayTime, string registerFilePath)
        {
            if (this.InvokeRequired)
                return (int)this.Invoke(new Action(() => _WriteRegisterPage(targetPage, delayTime, registerFilePath)));
            else
                return _WriteRegisterPage(targetPage, delayTime, registerFilePath);
        }


        public void SetVarBoolStateToNuvotonIcpApi(string varName, bool value)
        {
            ucNuvotonIcpTool.SetVarBoolState(varName, value);
        }
        
        public void SetVarIntStateToNuvotonIcpApi(string varName, int value)
        {
            ucNuvotonIcpTool.SetVarIntState(varName, value);
        }

        public void SetCheckBoxStateToNuvotonIcpApi(string checkBoxId, bool state)
        {
            ucNuvotonIcpTool.SetCheckBoxState(checkBoxId, state);
        }

        public bool GetVarBoolStateFromNuvotonIcpApi(string varName)
        {
            return ucNuvotonIcpTool.GetVarBoolState(varName);
        }

        public int GetVarIntStateFromNuvotonIcpApi(string varName)
        {
            return ucNuvotonIcpTool.GetVarIntState(varName);
        }

        public bool GetCheckBoxStateFromNuvotonIcpApi(string checkBoxId)
        {
            return ucNuvotonIcpTool.GetCheckBoxState(checkBoxId);
        }

        public void SetTextBoxTextToNuvotonIcpApi(string textBoxId, string newText)
        {
            ucNuvotonIcpTool.SetTextBoxText(textBoxId, newText);
        }

        public string GetTextBoxTextFromNuvotonIcpApi(string checkBoxId)
        {
            return ucNuvotonIcpTool.GetTextBoxText(checkBoxId);
        }

        public string GetTextBoxTextFromDdmiApi(string checkBoxId)
        {
            return ucInformation.GetTextBoxText(checkBoxId);
        }

        public string GetTextBoxTextFromCorrectorApi(string checkBoxId)
        {
            return (checkBoxId);
        }

        public void SetVendorSnToDdmiApi(string text)
        {
            ucInformation.SetVendorSnApi(text);
        }

        public void SetDataCodeToDdmiApi(string text)
        {
            ucInformation.SetDateCodeApi(text);
        }

        public string GetVendorSnFromDdmiApi()
        {
            return ucInformation.GetVendorSnApi();
        }

        public string GetDateCodeFromDdmiApi()
        {
            return ucInformation.GetDateCodeApi();
        }

        public void SetVarBoolStateToDdmApi(string varName, bool value)
        {
            ucDigitalDiagnosticsMonitoring.SetVarBoolState(varName, value);
        }

        public bool GetVarBoolStateFromDdmApi(string varName)
        {
            return ucDigitalDiagnosticsMonitoring.GetVarBoolState(varName);
        }

        public string GetTextBoxTextFromDdmApi(string textBoxId)
        {
            return ucDigitalDiagnosticsMonitoring.GetTextBoxText(textBoxId);
        }

        public int RxPowerReadApiFromDdmApi()
        {
            if (this.InvokeRequired)
                return (int)this.Invoke(new Action(() => ucDigitalDiagnosticsMonitoring.RxPowerReadApi()));
            else
                return ucDigitalDiagnosticsMonitoring.RxPowerReadApi();
        }

        public void UpdateSecurityLockStateFromNuvotonIcpApi()
        {
            if (this.InvokeRequired)
                this.Invoke(new Action(ucNuvotonIcpTool.UpdateSecurityLockStateApi));
            else
                ucNuvotonIcpTool.UpdateSecurityLockStateApi();
        }

        private CheckBox GetCheckBoxByName(string name)
        {
            switch (name)
            {
                case "cbInfomation":
                    return cbInfomation;
                case "cbDdm":
                    return cbDdm;
                case "cbMemDump":
                    return cbMemDump;
                case "cbCorrector":
                    return cbCorrector;
                case "cbTxIcConfig":
                    return cbTxIcConfig;
                case "cbRxIcConfig":
                    return cbRxIcConfig;

                default:
                    return null;
            }
        }

        private int _AppendWriteToFile(string sAction)
        {
            if (!System.IO.File.Exists(fileName)||
                string.IsNullOrEmpty(System.IO.File.ReadAllText(fileName)))
            { 
                sAcConfig = "//Write,DevAddr,RegAddr,Value\n" + "//Read,DevAddr,RegAddr,Value\n";
            }
            else
            {
                sAcConfig = "";
            }

            sAcConfig += sAction + "\n";

            System.IO.File.AppendAllText(fileName, sAcConfig);
            return 0;
        }

        private int _SetQsfpMode(byte mode)
        {
            byte[] data = new byte[] { 0xaa };

            if (writeToFile == false)
            {

                if (i2cMaster.WriteApi(80, 127, 1, data) < 0)
                    return -1;

                data[0] = mode;

                if (i2cMaster.WriteApi(80, 164, 1, data) < 0)
                    return -1;
            }
            else
            {
                _AppendWriteToFile("Write,0x50,0x7F,0xAA");
                _AppendWriteToFile($"Write,0x50,0x7F,0x{mode:X2}");
            }

            return 0;
        }

        private int _I2cMasterConnect(bool setMode, bool setPassword)
        {
            if (i2cMaster.ConnectApi(400) < 0)
                return -1;

            cbConnect.Checked = true;
            I2cConnected = true;

            if (setMode && _SetQsfpMode(0x4D) < 0)
                return -1;

            if (setPassword && _WriteModulePassword() < 0)
                return -1;
                    
            return 0;
        }
        
        private int _I2cMasterDisconnect()
        {
            if (i2cMaster.DisconnectApi() < 0)
                return -1;

            cbConnect.Checked = false;
            I2cConnected = false;

            return 0;
        }
        
        private int _ChannelSwitch()
        {
            ProcessingChannel = (ProcessingChannel == 1) ? 2 : 1;
            _ChannelSet(ProcessingChannel);
            _UpdateButtonState();

            return ProcessingChannel;
        }

        private int _ChannelSet(int ch)
        {
            if (!I2cConnected)
            {
                if (_I2cMasterConnect(true, false) < 0)
                    return -1;

                I2cConnected = true;
            }

            Thread.Sleep(10);
            int result = i2cMaster.ChannelSetApi(ch);

            if (result < 0)
                return -1; 

            if (ch == 0)
            {
                i2cMaster.DisconnectApi();
                I2cConnected = false;
            }

            return 0;
        }

        public int I2cMasterConnectApi(bool setMode, bool setPassword)
        {
            int result = -1;

            if (this.InvokeRequired)
                return (int)this.Invoke(new Action(() => _I2cMasterConnect(setMode, setPassword)));
            else
                return _I2cMasterConnect(setMode, setPassword);
            
        }

        public int I2cMasterDisconnectApi()
        {
            int result = -1;

            if (this.InvokeRequired)
                this.Invoke(new Action(() => result = _I2cMasterDisconnect()));
            else
                result = _I2cMasterDisconnect();

            return result;
        }

        public int ChannelSwitchApi()
        {
            int result = -1;

            if (this.InvokeRequired)
                this.Invoke(new Action(() => result = _ChannelSwitch()));
            else
                result = _ChannelSwitch();

            return result;
        }

        public void ChannelSetApi(int ch)
        {
            if (this.InvokeRequired)
                this.Invoke(new Action(() => _ChannelSet(ch)));
            else
                _ChannelSet(ch);
        }

        private int _I2cReadIcConfig(byte devAddr, byte regAddr, byte length, byte[] data)
        {
            int i, rv;
            if (i2cMaster.connected == false)
            {
                if (_I2cMasterConnect(true, false) < 0)
                    return -1;
            }

            if (_SetQsfpMode(0x4D) < 0)
                return -1;

            if (writeToFile == false)
            {

                rv = i2cMaster.ReadApi(devAddr, regAddr, length, data);
                if (rv < 0)
                {
                    //MessageBox.Show("TRx module no response!!");
                    _I2cMasterDisconnect();
                    ErrorState = -2;
                }
                else if (rv != length) {
                    //MessageBox.Show("Only read " + rv + " not " + length + " byte Error!!");
                    ErrorState = -1;
                }
                    

                return rv;
            }
            else
            {
                for (i = 0; i < length; i++)
                {
                    if (_AppendWriteToFile($"Write,0x{devAddr:X2},0x{regAddr:X2},0x{data[i]:X2}") < 0)
                        MessageBox.Show("_AppendWriteToFile() Error!!");
                }

                return 0;
            }

        }

        private int _I2cRead(byte devAddr, byte regAddr, byte length, byte[] data)
        {
            int i, rv;
            if (i2cMaster.connected == false)
            {
                if (_I2cMasterConnect(false, false) < 0)
                    return -1;
            }

            if (writeToFile == false)
            {
                rv = i2cMaster.ReadApi(devAddr, regAddr, length, data);
                if (rv < 0)
                {
                    MessageBox.Show("TRx module no response!!");
                    _I2cMasterDisconnect();
                }
                else if (rv != length)
                    MessageBox.Show("Only read " + rv + " not " + length + " byte Error!!");

                return rv;
            }
            else
            {
                for (i = 0; i < length; i++)
                {
                    if (_AppendWriteToFile($"Write,0x{devAddr:X2},0x{regAddr:X2},0x{data[i]:X2}") < 0)
                        MessageBox.Show("_AppendWriteToFile() Error!!");
                }

                return 0;
            }
        }

        private int _I2cRead16(byte devAddr, byte[] regAddr, byte length, byte[] data)
        {
            int i, rv;
            if (i2cMaster.connected == false)
            {
                if (_I2cMasterConnect(true, false) < 0)
                    return -1;
            }

            if (_SetQsfpMode(0x4D) < 0)
                return -1;

            if (writeToFile == false)
            {

                rv = i2cMaster.Read16Api(devAddr, regAddr, length, data);
                if (rv < 0)
                {
                    MessageBox.Show("TRx module no response!!");
                    _I2cMasterDisconnect();
                }
                else if (rv != length)
                    MessageBox.Show("Only read " + rv + " not " + length + " byte Error!!");

                return rv;
            }
            else
            {
                for (i = 0; i<length; i++)
                {
                    if (_AppendWriteToFile($"Write,0x{devAddr:X2},0x{regAddr:X2},0x{data[i]:X2}") < 0)
                        MessageBox.Show("_AppendWriteToFile() Error!!");
                }

                return 0;
            }
        }

        private int _I2cWriteIcConfig(byte devAddr, byte regAddr, byte length, byte[] data)
        {
            int i, rv;

            if (i2cMaster.connected == false)
            {
                if (_I2cMasterConnect(true, false) < 0)
                    return -1;
            }

            if (_SetQsfpMode(0x4D) < 0)
                return -1;

            if (writeToFile == false)
            {
                rv = i2cMaster.WriteApi(devAddr, regAddr, length, data);
                if (rv < 0)
                {
                    MessageBox.Show("TRx module no response!!");
                    _I2cMasterDisconnect();
                }

                return rv;
            }
            else
            {
                for (i = 0; i < length; i++)
                {
                    if (_AppendWriteToFile($"Write,0x{devAddr:X2},0x{regAddr:X2},0x{data[i]:X2}") < 0)
                        MessageBox.Show("_AppendWriteToFile() Error!!");
                }

                return 0;
            }
        }

        private int _I2cWrite(byte devAddr, byte regAddr, byte length, byte[] data)
        {
            int i, rv;

            if (i2cMaster.connected == false)
            {
                if (_I2cMasterConnect(false, false) < 0)
                    return -1;
            }

            if (writeToFile == false)
            {
                rv = i2cMaster.WriteApi(devAddr, regAddr, length, data);
                if (rv < 0)
                {
                    MessageBox.Show("TRx module no response!!");
                    _I2cMasterDisconnect();
                }

                return rv;
            }
            else
            {
                for (i = 0; i < length; i++)
                {
                    if (_AppendWriteToFile($"Write,0x{devAddr:X2},0x{regAddr:X2},0x{data[i]:X2}") < 0)
                        MessageBox.Show("_AppendWriteToFile() Error!!");
                }

                return 0;
            }
        }

        private int _I2cWrite16(byte devAddr, byte[] regAddr, byte length, byte[] data)
        {
            int i, rv;

            if (i2cMaster.connected == false)
            {
                if (_I2cMasterConnect(true, false) < 0)
                    return -1;
            }

            if (_SetQsfpMode(0x4D) < 0)
                return -1;

            if (writeToFile == false)
            {
                rv = i2cMaster.Write16Api(devAddr, regAddr, length, data);
                if (rv < 0)
                {
                    MessageBox.Show("TRx module no response!!");
                    _I2cMasterDisconnect();
                }

                return rv;
            }
            else
            {
                for (i = 0; i < length; i++)
                {
                    if (_AppendWriteToFile($"Write,0x{devAddr:X2},0x{regAddr:X2},0x{data[i]:X2}") < 0)
                        MessageBox.Show("_AppendWriteToFile() Error!!");
                }

                return 0;
            }
        }

        private int _WriteModulePassword()
        {
            byte[] data;
            string dataS;

            data = Encoding.Default.GetBytes(tbPassword.Text);
            dataS = Encoding.Default.GetString(data);
            //MessageBox.Show ("_WirteModulePassword parse： " + dataS);

            if (i2cMaster.WriteApi(80, 123, 4, data) < 0)
                return -1;

            return 0;
        }
        
        private int _GetPassword(int length, byte[] data)
        {
            byte[] tmp = new byte[4];
            TextBox[] textBoxes = new TextBox[] { tbPasswordB0, tbPasswordB1, tbPasswordB2, tbPasswordB3 };

            string dataS;

            if (length < 4)
                return -1;

            if (data == null)
                return -1;

            if (tbPassword.Text.Length != 4)
            {
                MessageBox.Show("Please inpurt password before operate!!");
                return -1;
            }

            /*
            for (int i = 0; i < textBoxes.Length; i++)
            {
                data[i] = Convert.ToByte(textBoxes[i].Text.ToString(), 16);
            }
            */
            data[0] = Convert.ToByte(tbPasswordB0.Text, 16);
            data[1] = Convert.ToByte(tbPasswordB1.Text, 16);
            data[2] = Convert.ToByte(tbPasswordB2.Text, 16);
            data[3] = Convert.ToByte(tbPasswordB3.Text, 16);
            
        dataS = Encoding.Default.GetString(data);
            //MessageBox.Show("_GetPassword parse： " + dataS);

            return 4;
        }

        private int _WritePassword()
        {
            byte[] data = new byte[4];

            if (ucDigitalDiagnosticsMonitoring.i2cWriteCB == null)
                return -1;

            if ((tbPasswordB0.Text.Length == 0) || (tbPasswordB1.Text.Length == 0) ||
                (tbPasswordB2.Text.Length == 0) || (tbPasswordB3.Text.Length == 0))
            {
                MessageBox.Show("Please input 4 hex value password before write!!");
                return -1;
            }

            try
            {
                data[0] = (byte)Convert.ToInt32(tbPasswordB0.Text, 10);
                data[1] = (byte)Convert.ToInt32(tbPasswordB1.Text, 10);
                data[2] = (byte)Convert.ToInt32(tbPasswordB2.Text, 10);
                data[3] = (byte)Convert.ToInt32(tbPasswordB3.Text, 10);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return -1;
            }

            if (ucDigitalDiagnosticsMonitoring.i2cWriteCB(80, 123, 4, data) < 0)
            {
                MessageBox.Show("_WritePassword1 rv: " + ucDigitalDiagnosticsMonitoring.i2cWriteCB(80, 123, 4, data));
                return -1;
            }
           
            //MessageBox.Show("_WritePassword2 rv: " + i2cWriteCB(80, 123, 4, data));
            return 0;
        }

        private int _ExportRegisterToCsv(string fileName)
        {
            if (File.Exists(fileName))
                File.Delete(fileName);

            fileName = fileName.Replace(" ", "") + ".csv";
            string folderPath = System.Windows.Forms.Application.StartupPath;
            string exportFilePath = Path.Combine(folderPath, "LogFolder", fileName);
            exportFilePath = exportFilePath.Replace("\\\\", "\\");

            AppendRxRegisterContents(exportFilePath);
            AppendTxRegisterContents(exportFilePath);

            return 0;
        }

        private void AppendRxRegisterContents(string exportFilePath)
        {
            string vendorInfo;
            string ChipId;
                
            ChipId = "37044_";
            ChipId += ucMata37044cConfig.GetChipId();

            if (ErrorState >= 0) {
                vendorInfo = ucMata37044cConfig.ReadAllRegisterApi();
                //File.AppendAllText(exportFilePath, ChipId + Environment.NewLine);
                File.AppendAllText(exportFilePath, vendorInfo);
                ErrorState = 0;
                return;
            }

            ErrorState = 0;
            ChipId = "RT145_";
            ChipId += ucRt145Config.GetChipId();

            if (ErrorState >= 0) {
                vendorInfo = ucRt145Config.ReadAllRegisterApi();
                //File.AppendAllText(exportFilePath, ChipId + Environment.NewLine);
                File.AppendAllText(exportFilePath, vendorInfo);
                ErrorState = 0;
                return;
            }

            /*
            if (ErrorState < 0) {
                if (ErrorState == -2)
                    lMessage.Text = "Module no response.";
                else if (ErrorState == -1)
                    lMessage.Text = "Target is not Macom_370xx";

                ErrorState = 0;
            }
            */
                        
        }

        private void AppendTxRegisterContents(string exportFilePath)
        {
            string vendorInfo;
            string ChipId;

            ChipId = "37045_";
            ChipId += ucMald37045cConfig.GetChipId();

            if (ErrorState >= 0) {
                vendorInfo = ucMald37045cConfig.ReadAllRegisterApi();
                //File.AppendAllText(exportFilePath, ChipId + Environment.NewLine);
                File.AppendAllText(exportFilePath, vendorInfo);
                ErrorState = 0;
                return;
            }

            ErrorState = 0;
            ChipId = "RT146_";
            ChipId += ucRt146Config.GetChipId();

            if (ErrorState >= 0) {
                vendorInfo = ucRt146Config.ReadAllRegisterApi();
                //File.AppendAllText(exportFilePath, ChipId + Environment.NewLine);
                File.AppendAllText(exportFilePath, vendorInfo);
                ErrorState = 0;
                return;
            }
        }

        private int _WriteRegisterPage (string targetPage, int delayTime, string registerFilePath)
        {

            switch (targetPage) {
                case "Up 00h":
                case "Up 03h":
                case "80h":
                case "81h":
                    if (ucMemoryDump.WriteRegisterPageApi(targetPage, delayTime, registerFilePath) < 0)
                        return -1;
                    
                    break;

                case "Tx":
                    if (ucMald37045cConfig.WriteAllRegisterApi("Tx", delayTime, registerFilePath) < 0)
                        return -1;
                    
                    break;

                case "Rx":
                    if (ucMata37044cConfig.WriteAllRegisterApi("Rx", delayTime, registerFilePath) < 0)
                        return -1;
                    
                    break;

                default:
                    break;
            }
            return 0;
        }
        
        private int _ExportLogfileToCsv(string fileName, bool logFileMode, bool writeSnMode)
        {
            string folderPath;
            string exportFilePath;
            string tempExportFilePath;

            if (!writeSnMode)
                StateUpdated("Read State:\nPreparing resources...", 3);

            if (logFileMode) {
                lastUsedDirectory = Application.StartupPath + "\\";
                //MessageBox.Show("Application startup path: \n " + lastUsedDirectory);

                folderPath = Path.Combine(lastUsedDirectory, "LogFolder");
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);
            }
            else {
                folderPath = lastUsedDirectory;
            }

            fileName = fileName.Replace(" ", "") + ".csv";
            exportFilePath = Path.Combine(folderPath, fileName);
            tempExportFilePath = Path.Combine(folderPath, "temp_" + fileName);
            exportFilePath = exportFilePath.Replace("\\\\", "\\");
            tempExportFilePath = tempExportFilePath.Replace("\\\\", "\\");

            if (File.Exists(exportFilePath))
                File.Delete(exportFilePath);
            //MessageBox.Show("1: \n" + ucInformation.GetVendorInfo() +
            //                "exportFilePath: \n" + exportFilePath);

            AppendVendorInfo(exportFilePath);
            AppendMoreInfo(exportFilePath);

            if (!writeSnMode)
                StateUpdated("Read State:\nInformation...Done", 5);

            if (ucMemoryDump.ExportAllPagesDataApi(tempExportFilePath) < 0)
                return -1;

            AppendFileContentToAnother(tempExportFilePath, exportFilePath);

            if (!writeSnMode)
                StateUpdated("Read State:\nUpPage 00h/03h...Done", 10);
           
            AppendRxRegisterContents(exportFilePath);

            if (!writeSnMode)
                StateUpdated("Read State:\nRxIcConfig...Done", 20);
            
            AppendTxRegisterContents(exportFilePath);

            if (!writeSnMode)
                StateUpdated("Read State:\nTxIcConfig...Done", 30);
           
            if (File.Exists(tempExportFilePath))
                File.Delete(tempExportFilePath);

            //MessageBox.Show("9: \n" + ucInformation.GetVendorInfo() + 
            //                "exportFilePath: \n" + exportFilePath);

            return 0;
        }
        

        private void AppendVendorInfo(string exportFilePath)
        {
            string vendorInfo = ucInformation.GetVendorInfo();
            File.AppendAllText(exportFilePath, vendorInfo);
        }

        private void AppendMoreInfo(string exportFilePath)
        {
            string additionalVendorInfo = ucDigitalDiagnosticsMonitoring.GetMoreInfo();
            File.AppendAllText(exportFilePath, additionalVendorInfo + Environment.NewLine);
        }

        private void AppendFileContentToAnother(string sourceFilePath, string destinationFilePath)
        {
            var lines = File.ReadAllLines(sourceFilePath);
            File.AppendAllLines(destinationFilePath, lines);
        }

        private void _SetToChannel2(bool mode) 
        {
            ucNuvotonIcpTool.SetVarBoolState("SetToChannel2", mode);
        }

        private void _SetAutoReconnectControl(bool ControlState)
        {
            ucNuvotonIcpTool.SetVarBoolState("AutoReconnectMode", ControlState);
            cbAutoReconnect.Checked = ControlState;
        }

        private bool _GetAutoReconnectControl()
        {
            return ucNuvotonIcpTool.GetVarBoolState("AutoReconnectMode");
        }

        private void _SetBypassEraseAllControl(bool ControlState)
        {
            ucNuvotonIcpTool.SetVarBoolState("BypassEraseAllCheckMode", ControlState);
            cbBypassEraseAllCheck.Checked = ControlState;
        }

        private bool _GetBypassEraseAllControl()
        {
            return ucNuvotonIcpTool.GetVarBoolState("BypassEraseAllCheckMode");
        }

        private void UcNuvotonIcpControl_RequestI2cOperation(object sender, I2cOperationEventArgs e)
        {
            switch (e.OperationType)
            {
                case I2cOperationType.Connect:
                    _I2cMasterConnect(true, false);
                    break;
                case I2cOperationType.Disconnect:
                    _I2cMasterDisconnect();
                    break;
                case I2cOperationType.SetChannel:
                    _ChannelSet(e.Channel);
                    _SetAutoReconnectControl(false);
                    break;
            }
        }

        private void UcNuvotonIcpTool_MessageUpdated(object sender, MessageEventArgs e)
        {
            // UC-B data updated，觸發UC-A的MainMessageUpdated event，將Message傳遞給MainForm-UI
            MainMessageUpdated?.Invoke(this, e);
        }
        private void ucDigitalDiagnosticsMonitoring_TextBoxTextChanged(object sender, TextBoxTextEventArgs e)
        {
            TextBoxTextChanged?.Invoke(this, e);
        }

        public MainForm(bool visible)
        {
            InitializeComponent();
            SetupControlEvents(); // For IcpTool Button.text update

            if (!visible)
            {
                this.ShowInTaskbar = false;
            }

            this.FormClosing += new FormClosingEventHandler(_MainForm_FormClosing);
            ucNuvotonIcpTool.MessageUpdated += UcNuvotonIcpTool_MessageUpdated;
            ucNuvotonIcpTool.RequestI2cOperation += UcNuvotonIcpControl_RequestI2cOperation;
            ucDigitalDiagnosticsMonitoring.TextBoxTextChanged += ucDigitalDiagnosticsMonitoring_TextBoxTextChanged;
            this.Size = new System.Drawing.Size(1170, 870);
            _InitialStateBar();
            //_EnableIcConfig();
            //_UpdateTabPageVisibility();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            cbProductSelect.SelectedIndex = 0;

            dtWriteConfig.Columns.Add("Command", typeof(String));
            dtWriteConfig.Columns.Add("DevAddr", typeof(String));
            dtWriteConfig.Columns.Add("RegAddr", typeof(String));
            dtWriteConfig.Columns.Add("Value", typeof(String));

            dgvWriteConfig.DataSource = dtWriteConfig;

            /*
            bool tmp = ucNuvotonIcpTool.GetVarBoolState("PublicVariable");
            ucNuvotonIcpTool.SetVarBoolState("PublicVariable", true);
            MessageBox.Show("ucNuvotonIcp_PublicVariable bool: "
                            + "\nBefore: " + tmp
                            + "\nAfter: " + ucNuvotonIcpTool.GetVarBoolState("PublicVariable")
                            );
            */

            if (ucInformation.SetI2cReadCBApi(_I2cRead) < 0)
            {
                MessageBox.Show("ucInformation.SetI2cReadCBApi() faile Error!!");
                return;
            }
            if (ucInformation.SetI2cWriteCBApi(_I2cWrite) < 0)
            {
                MessageBox.Show("ucInformation.SetI2cReadCBApi() faile Error!!");
                return;
            }
            if (ucInformation.SetGetPasswordCBApi(_GetPassword) < 0)
            {
                MessageBox.Show("ucInformation.SetGetPasswordCBApi() faile Error!!");
                return;
            }
            if (ucDigitalDiagnosticsMonitoring.SetI2cReadCBApi(_I2cRead) < 0)
            {
                MessageBox.Show("ucDigitalDiagnosticsMonitoring.SetI2cReadCBApi() faile Error!!");
                return;
            }
            if (ucDigitalDiagnosticsMonitoring.SetI2cWriteCBApi(_I2cWrite) < 0)
            {
                MessageBox.Show("ucDigitalDiagnosticsMonitoring.SetI2cReadCBApi() faile Error!!");
                return;
            }
            if (ucDigitalDiagnosticsMonitoring.SetWritePasswordCBApi(ucInformation.WritePassword) < 0)
            {
                MessageBox.Show("ucDigitalDiagnosticsMonitoring.SetWritePasswordCBApi() faile Error!!");
                return;
            }
            if (ucMemoryDump.SetI2cReadCBApi(_I2cRead) < 0)
            {
                MessageBox.Show("ucMemoryDump.SetI2cReadCBApi() faile Error!!");
                return;
            }
            if (ucMemoryDump.SetI2cWriteCBApi(_I2cWrite) < 0)
            {
                MessageBox.Show("ucMemoryDump.SetI2cReadCBApi() faile Error!!");
                return;
            }
            if (ucMemoryDump.SetWritePasswordCBApi(ucInformation.WritePassword) < 0)
            {
                MessageBox.Show("ucMemoryDump.SetWritePasswordCBApi() faile Error!!");
                return;
            }

            if (ucGn1190Corrector.SetQsfpI2cReadCBApi(_I2cRead) < 0)
            {
                MessageBox.Show("ucQsfpCorrector.SetQsfpI2cReadCBApi() faile Error!!");
                return;
            }
            if (ucGn1190Corrector.SetQsfpI2cWriteCBApi(_I2cWrite) < 0)
            {
                MessageBox.Show("ucQsfpCorrector.SetQsfpI2cWriteCBApi() faile Error!!");
                return;
            }

            if (ucMald37045cConfig.SetI2cReadCBApi(_I2cReadIcConfig) < 0)
            {
                MessageBox.Show("ucMald37045cConfig.SetI2cReadCBApi() faile Error!!");
                return;
            }
            if (ucMald37045cConfig.SetI2cWriteCBApi(_I2cWriteIcConfig) < 0)
            {
                MessageBox.Show("ucMald37045cConfig.SetI2cWriteCBApi() faile Error!!");
                return;
            }
            if (ucMata37044cConfig.SetI2cReadCBApi(_I2cReadIcConfig) < 0)
            {
                MessageBox.Show("ucMata37044cConfig.SetI2cReadCBApi() faile Error!!");
                return;
            }
            if (ucMata37044cConfig.SetI2cWriteCBApi(_I2cWriteIcConfig) < 0)
            {
                MessageBox.Show("ucMata37044cConfig.SetI2cWriteCBApi() faile Error!!");
                return;
            }

            if (ucRt145Config.SetI2cReadCBApi(_I2cReadIcConfig) < 0)
            {
                MessageBox.Show("ucRt145Config.SetI2cReadCBApi() faile Error!!");
                return;
            }
            if (ucRt145Config.SetI2cWriteCBApi(_I2cWriteIcConfig) < 0)
            {
                MessageBox.Show("ucRt145Config.SetI2cWriteCBApi() faile Error!!");
                return;
            }
            if (ucRt146Config.SetI2cReadCBApi(_I2cReadIcConfig) < 0)
            {
                MessageBox.Show("ucRt145Config.SetI2cReadCBApi() faile Error!!");
                return;
            }
            if (ucRt146Config.SetI2cWriteCBApi(_I2cWriteIcConfig) < 0)
            {
                MessageBox.Show("ucRt145Config.SetI2cWriteCBApi() faile Error!!");
                return;
            }

            if (ucGn2108Config.SetI2cReadCBApi(_I2cReadIcConfig) < 0)
            {
                MessageBox.Show("ucGn1190Config.SetI2cReadCBApi() faile Error!!");
                return;
            }
            if (ucGn2108Config.SetI2cWriteCBApi(_I2cWriteIcConfig) < 0)
            {
                MessageBox.Show("ucGn1190Config.SetI2cWriteCBApi() faile Error!!");
                return;
            }
            if (ucGn2108Config.SetI2cRead16CBApi(_I2cRead16) < 0)
            {
                MessageBox.Show("ucGn1190Config.SetI2cRead16CBApi() faile Error!!");
                return;
            }
            if (ucGn2108Config.SetI2cWrite16CBApi(_I2cWrite16) < 0)
            {
                MessageBox.Show("ucGn1190Config.SetI2cWrite16CBApi() faile Error!!");
                return;
            }

            if (ucGn2109Config.SetI2cReadCBApi(_I2cReadIcConfig) < 0)
            {
                MessageBox.Show("ucGn1190Config.SetI2cReadCBApi() faile Error!!");
                return;
            }
            if (ucGn2109Config.SetI2cWriteCBApi(_I2cWriteIcConfig) < 0)
            {
                MessageBox.Show("ucGn1190Config.SetI2cWriteCBApi() faile Error!!");
                return;
            }
            if (ucGn2109Config.SetI2cRead16CBApi(_I2cRead16) < 0)
            {
                MessageBox.Show("ucGn1190Config.SetI2cRead16CBApi() faile Error!!");
                return;
            }
            if (ucGn2109Config.SetI2cWrite16CBApi(_I2cWrite16) < 0)
            {
                MessageBox.Show("ucGn1190Config.SetI2cWrite16CBApi() faile Error!!");
                return;
            }
        }

        public void SetPermissions(string permissions)
        {
            cbPermission.SelectedItem = permissions;
        }

        public void SetProduct(string product)
        {
            cbProductSelect.SelectedItem = product;
        }
       
        private int _SetWriteConfig() // The function could work, but it's too slow
        {
            byte[] data = new byte[1];
            byte devAddr, regAddr;
            int currentRow = 0;

            progressBar1.Value = 0;

            if (ucDigitalDiagnosticsMonitoring.i2cWriteCB == null)
            {
                MessageBox.Show("i2cWriteCB rv: " + ucDigitalDiagnosticsMonitoring.i2cWriteCB);
                return -1;
            }

            int totalLines = File.ReadLines(fileName).Count();

            using (StreamReader sr = new StreamReader(fileName))
            {
                while (!sr.EndOfStream)
                {
                    currentRow++;
                    double progressPercentage = (double)currentRow / totalLines * 100;
                    progressBar1.Value = (int)progressPercentage;

                    string line = sr.ReadLine();

                    if (line.StartsWith("//") || line.Trim() == "")
                        continue;

                    string[] tokens = line.Split(',');

                    
                    if (tokens.Length < 4)// 檢查 tokens 的數量
                    {
                        MessageBox.Show("Invalid line format: " + line);
                        return -1;
                    }

                    if (tokens[1].Length >= 2)
                    {
                        string devAddrString = tokens[1].Substring(2);

                        if (!byte.TryParse(devAddrString, System.Globalization.NumberStyles.HexNumber, null, out devAddr))
                        {
                            MessageBox.Show("Invalid DevAddr format: " + tokens[1]);
                            return -1;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid DevAddr format: " + tokens[1]);
                        return -1;
                    }

                    string command = tokens[0];
                    devAddr = byte.Parse(tokens[1].Substring(2), System.Globalization.NumberStyles.HexNumber);
                    regAddr = byte.Parse(tokens[2].Substring(2), System.Globalization.NumberStyles.HexNumber);
                    data[0] = byte.Parse(tokens[3].Substring(2), System.Globalization.NumberStyles.HexNumber);

                    switch (command)
                    {
                        case "Write":
                            ucDigitalDiagnosticsMonitoring.i2cWriteCB(devAddr, regAddr, 1, data);
                            break;

                        case "Read":
                            while (ucDigitalDiagnosticsMonitoring.i2cReadCB(devAddr, regAddr, 1, data) != 1)
                            {
                                MessageBox.Show("i2cReadCB() fail!!");
                                Thread.Sleep(100);
                            }
                            if (data[0] != byte.Parse(tokens[4].Substring(2), System.Globalization.NumberStyles.HexNumber))
                            {
                                MessageBox.Show("DevAddr:0x" + devAddr.ToString("X2") + "RegAddr:0x" + regAddr.ToString("X2") +
                                    "Value:0x" + data[0].ToString("X2") + " != " + tokens[4]);
                                return -1;
                            }
                            break;

                        default:
                            MessageBox.Show("Invalid command: " + command);
                            return -1;
                    }

                    Application.DoEvents();
                }
            }

            return 0;
        }

        private void _StoreGlobalWriteCommandtoFile()
        {
            SaveFileDialog sfdSelectFile = new SaveFileDialog();

            sAcConfig = "//Write,DevAddr,RegAddr,Value\n" + "//Read,DevAddr,RegAddr,Value\n" +
                "//Delay10mSec,Time\n";

            ucInformation.WriteApi();
            ucDigitalDiagnosticsMonitoring.bWrite_Click(null, null);
            ucMemoryDump.WriteApi();

            sfdSelectFile.Filter = "cfg files (*.cfg)|*.cfg";
            if (sfdSelectFile.ShowDialog() != DialogResult.OK)
                return;

            System.IO.File.WriteAllText(sfdSelectFile.FileName, sAcConfig);
        }

        private void _InitialStateBar()
        {
            tbInformationReadState.BackColor= Color.White;
            tbDdmReadState.BackColor = Color.White;
            tbMemDumpReadState.BackColor = Color.White;
            tbCorrectorReadState.BackColor = Color.White;
            tbTxConfigReadState.BackColor = Color.White;
            tbRxConfigReadState.BackColor = Color.White;
        }

        private void _DisableButtons()
        {
            cbConnect.Enabled = false;
            bGlobalRead.Enabled = false;
            bInnerSwitch.Enabled = false;
            bOutterSwitch.Enabled = false;
            bGlobalWrite.Enabled = false;
            bStoreIntoFlash.Enabled = false;
            ucNuvotonIcpTool.SetButtonEnable("bLink" , false);
            /*
            tcDdmi.Enabled = false;
            tcIcConfig.Enabled = false;
            ucGn1190Corrector.DisableButtonApi();
            */
            bGlobalWrite2.Enabled = false;
            bGenerateCfg.Enabled = false;
            //bFunctionTest2.Enabled = false;
            bDumpToString.Enabled = false;
            cbInfomation.Enabled = false;
            cbDdm.Enabled = false;
            cbMemDump.Enabled = false;
            cbCorrector.Enabled = false;
            cbTxIcConfig.Enabled = false;
            cbRxIcConfig.Enabled = false;
            cbAPPath.Enabled = false;
            cbDAPath.Enabled = false;
            rbCustomerMode.Enabled = false;
            rbMpMode.Enabled = false;
            bBackToMainForm.Enabled = false;
        }

        private void _EnableButtons()
        {
            cbConnect.Enabled = true;
            bGlobalRead.Enabled = true;
            bInnerSwitch.Enabled = true;
            bOutterSwitch.Enabled = true;
            /*
            tcDdmi.Enabled = true;
            tcIcConfig.Enabled = true;
            ucGn1190Corrector.EnableButtonApi();
            */
            ucNuvotonIcpTool.SetButtonEnable("bLink", true);
            bGlobalWrite2.Enabled = true;
            bGenerateCfg.Enabled = true;
            //bFunctionTest2.Enabled = true;
            bDumpToString.Enabled = true;
            cbInfomation.Enabled = true;
            cbDdm.Enabled = true;
            cbMemDump.Enabled = true;
            cbCorrector.Enabled = true;
            cbTxIcConfig.Enabled = true;
            cbRxIcConfig.Enabled = true;
            cbAPPath.Enabled = true;
            cbDAPath.Enabled = true;
            rbCustomerMode.Enabled = true;
            rbMpMode.Enabled = true;
            bBackToMainForm.Enabled = true;

            if (FirstRead)
            {
                bGlobalWrite.Enabled = true;
                bStoreIntoFlash.Enabled = true;
            }
            else
            {
                bGlobalWrite.Enabled = false;
                bStoreIntoFlash.Enabled = false;
            }
        }

        private void _GenerateXmlFileFromUcComponents()
        {
            string folderPath = System.Windows.Forms.Application.StartupPath;
            string combinedPath = Path.Combine(folderPath, "XmlFolder");
            string xmlFilePath = Path.Combine(combinedPath, "Settings.xml");
            xmlFilePath = xmlFilePath.Replace("\\\\", "\\");

            XmlDocument xmlDoc = new XmlDocument();
            XmlElement root = xmlDoc.CreateElement("Settings");
            xmlDoc.AppendChild(root);
            XmlElement permissionsNode = xmlDoc.CreateElement("Permissions");
            root.AppendChild(permissionsNode);
            string[] roles = { "Administrator", "Engineer", "MP Manager" };

            foreach (string role in roles)
            {
                XmlElement permissionNode = xmlDoc.CreateElement("Permission");
                permissionNode.SetAttribute("role", role);
                permissionsNode.AppendChild(permissionNode);
                                
                List<UserControl> userControls = GetAllUserControls(this); // get MainForm all UserControl

                foreach (UserControl userControl in userControls)
                {
                    XmlElement userControlNode = xmlDoc.CreateElement("UserControl");
                    userControlNode.SetAttribute("name", userControl.Name);

                    /*
                    // 指定 UserControl ...所有 Components enabled = false
                    if (userControl.Name == "ucMald37045cConfig" ||
                        userControl.Name == "ucMata37044cConfig" ||
                        userControl.Name == "ucRt146Config" ||
                        userControl.Name == "ucRt145Config" ||
                        userControl.Name == "ucGn2108Config" ||
                        userControl.Name == "ucGn2109Config")
                    {
                        SetAllComponentsEnabled(userControl, false);
                    }
                    */

                    permissionNode.AppendChild(userControlNode);

                    List<Control> userControlComponents = GetAllControls(userControl); // search all components from UserControl and set xml node
                    userControlComponents.Sort(new ControlComparer());

                    XmlElement componentsNode = xmlDoc.CreateElement("Components");

                    foreach (Control control in userControlComponents)
                    {
                        XmlElement componentNode = xmlDoc.CreateElement("Component");

                        componentNode.SetAttribute("name", control.Name);
                        componentNode.SetAttribute("object", control.GetType().Name);
                        componentNode.SetAttribute("visible", "True");
                        //componentNode.SetAttribute("enabled", control.Enabled.ToString());

                        if (control.Name.Contains("Write") || control.Name.Contains("Flash"))
                        {
                            componentNode.SetAttribute("enabled", "False");
                        }
                        // 新增條件：如果 Component name 含有 "tp" 字串，則 enabled 設為 true
                        else if (control.Name.Contains("tp"))
                        {
                            componentNode.SetAttribute("enabled", "True");
                        }
                        else
                        {
                            componentNode.SetAttribute("enabled", control.Enabled.ToString());
                        }


                        if (control is TextBox textBox)
                        {
                            componentNode.SetAttribute("ReadOnly", textBox.ReadOnly.ToString());
                        }

                        componentsNode.AppendChild(componentNode);
                    }

                    userControlNode.AppendChild(componentsNode);
                }
            }

            xmlDoc.Save(xmlFilePath);
        }

        private void _GenerateXmlFileForProject()
        {
            string destinationFilePath;

            XmlDocument xmlDoc = new XmlDocument();
            XmlElement root = xmlDoc.CreateElement("Project");
            xmlDoc.AppendChild(root);
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML Files|*.xml";
            saveFileDialog.Title = "Save XML File";

            string targetApromPath = APROMPath;
            string targetDataromPath = DATAROMPath;

            XmlElement permissionsNode = xmlDoc.CreateElement("Premissions");

            if (rbCustomerMode.Checked) {
                permissionsNode.SetAttribute("role", "Customer");
            }
            else if (rbMpMode.Checked) {
                permissionsNode.SetAttribute("role", "MP");
            }

            root.AppendChild(permissionsNode);

            // Check produc selected
            if (cbProductSelect.SelectedItem != null) {
                XmlElement productNode = xmlDoc.CreateElement("Product");
                productNode.SetAttribute("name", cbProductSelect.SelectedItem.ToString());
                permissionsNode.AppendChild(productNode);
            }
            else {
                MessageBox.Show("Please select a product.");
                return;
            }

            // Check APROM, DATAROM filepath
            if (!string.IsNullOrWhiteSpace(APROMPath) || !string.IsNullOrWhiteSpace(DATAROMPath)) {
                XmlElement APROMNode = xmlDoc.CreateElement("APROM");
                APROMNode.SetAttribute("name", Path.GetFileName(APROMPath));
                permissionsNode.AppendChild(APROMNode);

                XmlElement DATAROMNode = xmlDoc.CreateElement("DATAROM");
                DATAROMNode.SetAttribute("name", Path.GetFileName(DATAROMPath));
                permissionsNode.AppendChild(DATAROMNode);
            }
            else {
                MessageBox.Show("APROM or DATAROM path is not set.");
                return;
            }

            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                string selectedFileName = saveFileDialog.FileName;
                xmlDoc.Save(selectedFileName);

                lastUsedDirectory = Path.GetDirectoryName(selectedFileName);
                _InitialStateBar();
                _GlobalWrite(false);
                _ExportLogfileToCsv("RegisterFile", false, false); // Export CfgFile to config folder
                //MessageBox.Show("lastUsedDirectory: \n" + lastUsedDirectory);

                if (!string.IsNullOrWhiteSpace(targetApromPath)) {
                    destinationFilePath = Path.Combine(lastUsedDirectory, Path.GetFileName(APROMPath));
                    //MessageBox.Show("APROMPath: \n" + APROMPath +
                    //                "\nlastUsedDirectory: \n" + destinationFilePath);
                    File.Copy(targetApromPath, destinationFilePath, true);
                }
                
                if (!string.IsNullOrWhiteSpace(targetDataromPath)) {
                    destinationFilePath = Path.Combine(lastUsedDirectory, Path.GetFileName(DATAROMPath));
                    //MessageBox.Show("DATAROMPath: \n" + DATAROMPath +
                    //                "\nlastUsedDirectory: \n" + destinationFilePath);
                    File.Copy(targetDataromPath, destinationFilePath, true);
                }
                    
            }
        }

        private List<UserControl> GetAllUserControls(Control control) // 遞迴取得 MainForm 中的所有 User Control
        {
            List<UserControl> userControls = new List<UserControl>();

            foreach (Control childControl in control.Controls)
            {
                if (childControl is UserControl userControl)
                {
                    userControls.Add(userControl);
                }

                userControls.AddRange(GetAllUserControls(childControl));
            }

            return userControls;
        }

        private List<Control> GetAllControls(Control control) // 遞迴取得 User Control 中的所有 Control
        {
            List<Control> controls = new List<Control>();

            foreach (Control childControl in control.Controls)
            {
                controls.Add(childControl);

                if (childControl is UserControl userControl) // If UserControl，遞迴取得其內部的所有元件
                {
                    controls.AddRange(GetAllControls(userControl));
                }

                controls.AddRange(GetAllControls(childControl));
            }

            return controls;
        }

        private void SetAllComponentsEnabled(Control control, bool enabled)
        {
            List<Control> controls = GetAllControls(control);

            foreach (Control c in controls)
            {
                c.Enabled = enabled;
            }
        }

        private class ControlComparer : IComparer<Control> //比較器，用於排序
        {
            public int Compare(Control x, Control y)
            {
                return string.Compare(x.Name, y.Name, StringComparison.Ordinal); // 依components name進行排序
            }
        }

        public int ConfigUiByXmlApi(String configXml)
        {
            OpenFileDialog ofdSelectFile = new OpenFileDialog();
            XmlReader xrConfig;

            string folderPath = System.Windows.Forms.Application.StartupPath;
            string combinedPath = Path.Combine(folderPath, "XmlFolder");
            string xmlFilePath = Path.Combine(combinedPath, configXml);
            xmlFilePath = xmlFilePath.Replace("\\\\", "\\");


            if (xmlFilePath.Length == 0)
            {
                ofdSelectFile.Title = "Select config file";
                ofdSelectFile.Filter = "xml files (*.xml)|*.xml";
                if (ofdSelectFile.ShowDialog() != DialogResult.OK)
                    return -1;
                xrConfig = XmlReader.Create(ofdSelectFile.FileName);
            }
            else
            {
                xrConfig = XmlReader.Create(xmlFilePath);
            }

            while (xrConfig.Read())
            {
                if (xrConfig.IsStartElement())
                {
                    switch (xrConfig.Name)
                    {
                        case "Settings":
                            xrConfig.Read();
                            _ParseSettingsXml(xrConfig);
                            break;

                        default:
                            break;
                    }
                }
            }

            return 0;
        }

        private void _ParseSettingsXml(XmlReader reader)
        {
            while (reader.Read())
            {
                if (reader.IsStartElement() && reader.Name == "Permission")
                {
                    string role = reader.GetAttribute("role");

                    if (role == cbPermission.SelectedItem.ToString())
                    {
                        // The selected permission level matches the current Permission element

                        reader.Read(); // Move to the first UserControl element

                        while (reader.IsStartElement() && reader.Name == "UserControl")
                        {
                            string userControlName = reader.GetAttribute("name");

                            reader.Read(); // Move to the Components element within the UserControl
                            
                            while (reader.IsStartElement() && reader.Name == "Components")
                            {
                                reader.Read(); // Move to the first Component element

                                while (reader.IsStartElement() && reader.Name == "Component")
                                {
                                    _ParseComponentXml(reader, userControlName);
                                }

                                reader.ReadEndElement(); // Move out of the Components element
                            }

                            reader.ReadEndElement(); // Move out of the UserControl element
                        }
                    }
                    else
                    {
                        reader.Skip(); // Skip the elements for other permission levels
                    }
                }
            }
        }

        private void _ParseComponentXml(XmlReader reader, string userControlName)
        {
            string componentName = reader.GetAttribute("name");
            string objectType = reader.GetAttribute("object");
            string visible = reader.GetAttribute("visible");
            string enabled = reader.GetAttribute("enabled");
            string readOnly = reader.GetAttribute("ReadOnly");

            UserControl targetUserControl = (UserControl)Controls.Find(userControlName, true).FirstOrDefault();

            if (targetUserControl != null)
            {
                switch (objectType)
                {
                    case "TextBox":
                        TextBox tbTmp = (TextBox)targetUserControl.Controls.Find(componentName, true).FirstOrDefault();
                        
                        if (tbTmp != null)
                        {
                            if (visible != null) tbTmp.Visible = visible.Equals("True");
                            if (enabled != null) tbTmp.Enabled = enabled.Equals("True");
                            if (readOnly != null) tbTmp.ReadOnly = readOnly.Equals("True");
                        }
                        break;

                    case "Label":
                        Label lTmp = (Label)targetUserControl.Controls.Find(componentName, true).FirstOrDefault();

                        if (lTmp != null)
                        {
                            if (visible != null) lTmp.Visible = visible.Equals("True");
                            if (enabled != null) lTmp.Enabled = enabled.Equals("True");
                        }
                        break;

                    case "Button":
                        Button bTmp = (Button)targetUserControl.Controls.Find(componentName, true).FirstOrDefault();

                        if (bTmp != null)
                        {
                            if (visible != null) bTmp.Visible = visible.Equals("True", StringComparison.OrdinalIgnoreCase);
                            if (enabled != null) bTmp.Enabled = enabled.Equals("True", StringComparison.OrdinalIgnoreCase);
                        }
                        break;

                    case "GroupBox":
                        GroupBox gbTmp = (GroupBox)targetUserControl.Controls.Find(componentName, true).FirstOrDefault();

                        if (gbTmp != null)
                        {
                            if (visible != null) gbTmp.Visible = visible.Equals("True");
                            if (enabled != null) gbTmp.Enabled = enabled.Equals("True");
                        }
                        break;

                    case "CheckBox":
                        CheckBox cbTmp = (CheckBox)targetUserControl.Controls.Find(componentName, true).FirstOrDefault();

                        if (cbTmp != null)
                        {
                            if (visible != null) cbTmp.Visible = visible.Equals("True");
                            if (enabled != null) cbTmp.Enabled = enabled.Equals("True");
                        }
                        break;

                    case "ComboBox":
                        ComboBox cobTmp = (ComboBox)targetUserControl.Controls.Find(componentName, true).FirstOrDefault();

                        if (cobTmp != null)
                        {
                            if (visible != null) cobTmp.Visible = visible.Equals("True");
                            if (enabled != null) cobTmp.Enabled = enabled.Equals("True");
                        }
                        break;

                    default:
                        break;
                }
            }

            reader.Read(); // Move to the next Component element
        }

        private void bOutterSwitch_Click(object sender, EventArgs e)
        {
            if (bOutterSwitch.Enabled == true)
                bOutterSwitch.Enabled = false;
                //_DisableButtons(); //為了避免切換期間，限制輸入其他狀態

            _ChannelSwitch();
            bGlobalRead.Select();

            if (bOutterSwitch.Enabled == false)
                bOutterSwitch.Enabled = true;
                //_EnableButtons(); //為了避免切換期間，限制輸入其他狀態
        }

        private void bInnerSwitch_Click(object sender, EventArgs e)
        {
            if (bInnerSwitch.Enabled == true)
                bInnerSwitch.Enabled = false;
               
            _ChannelSwitch();

            if (bInnerSwitch.Enabled == false)
                bInnerSwitch.Enabled = true;
                
            bInnerSwitch.Select();
        }

        private void _UpdateButtonState()
        {
           
            if (ProcessingChannel == 1)
            {
                rbCh1.Checked = true;
                rbCh2.Checked = false;
                tbInnerStateCh1.BackColor = Color.YellowGreen;
                tbInnerStateCh2.BackColor = Color.White;
            }

            if (ProcessingChannel == 2)
            {
                rbCh2.Checked = true;
                rbCh1.Checked = false;
                tbInnerStateCh1.BackColor = Color.White;
                tbInnerStateCh2.BackColor = Color.YellowGreen;
            }

            System.Windows.Forms.Application.DoEvents();
        }
        /*
        private void _ContinuousMode()
        {
            while(cbContinuousMode.Checked){
                ucNuvotonIcpTool.ConnectSingleApi();
                ucNuvotonIcpTool.StartFlashingApi();
                bInnerSwitch_Click(null, null);
            }
        }
        */
        private void _EnableIcConfig()
        {
            if (cbProductSelect.SelectedIndex != 0)
            {
                cbTxIcConfig.Enabled = true;
                cbTxIcConfig.Checked = false;
                cbRxIcConfig.Enabled = true;
                cbRxIcConfig.Checked = false;
                tbTxConfigReadState.Enabled = true;
                tbRxConfigReadState.Enabled = true;
                AutoSelectIcConfig = true;
            }
            else
            {
                cbTxIcConfig.Enabled = false;
                cbTxIcConfig.Checked = false;
                cbRxIcConfig.Enabled = false;
                cbRxIcConfig.Checked = false;
                tbTxConfigReadState.Enabled = false;
                tbRxConfigReadState.Enabled = false;
                AutoSelectIcConfig = false;
            }
        }

        private void _UpdateTabPageVisibility()
        {
            int variable;

            variable = cbProductSelect.SelectedIndex;

            if (variable == 1)
            {
                tcIcConfig.TabPages.Remove(tabPage32);
                tcIcConfig.TabPages.Remove(tabPage33);

                if (!tcIcConfig.TabPages.Contains(tabPage31))
                {
                    tcIcConfig.TabPages.Add(tabPage31);
                }
            }

            else if (variable == 2)
            {
                tcIcConfig.TabPages.Remove(tabPage31);
                tcIcConfig.TabPages.Remove(tabPage33);

                if (!tcIcConfig.TabPages.Contains(tabPage32))
                {
                    tcIcConfig.TabPages.Add(tabPage32);
                }
            }
            else if (variable == 3)
            {
                tcIcConfig.TabPages.Remove(tabPage31);
                tcIcConfig.TabPages.Remove(tabPage32);

                if (!tcIcConfig.TabPages.Contains(tabPage33))
                {
                    tcIcConfig.TabPages.Add(tabPage33);
                }
            }

            else
            {
                if (!tcIcConfig.TabPages.Contains(tabPage31))
                {
                    tcIcConfig.TabPages.Add(tabPage31);
                }
                if (!tcIcConfig.TabPages.Contains(tabPage32))
                {
                    tcIcConfig.TabPages.Add(tabPage32);
                }
                if (!tcIcConfig.TabPages.Contains(tabPage33))
                {
                    tcIcConfig.TabPages.Add(tabPage33);
                }
            }
        }

        private string _GetFirmwareVersionCode()
        {
            byte[] data = new byte[10];
            byte[] bATmp = new byte[2];

            data[0] = 0xAA;
            if (_I2cWrite(80, 127, 1, data) < 0)
                return "-1";

            if (_I2cRead(80, 165, 10, data) < 0)
                return "-1";

            if ((data[0] == 0) && (data[1] == 0) && (data[2] == 0) && (data[3] == 0) &&
                (data[4] == 0) && (data[5] == 0) && (data[6] == 0) && (data[7] == 0) &&
                (data[8] == 0) && (data[9] == 0)) {
                data[0] = 32;
                if (_I2cWrite(80, 127, 1, data) < 0)
                    return "-1";

                if (_I2cRead(80, 165, 10, data) < 0)
                    return "-1";
            }
            
            bATmp = new byte[8];
            System.Buffer.BlockCopy(data, 2, bATmp, 0, 8);
            
            return Encoding.Default.GetString(bATmp);
        }

        private void bGlobalRead_Click(object sender, EventArgs e)
        {
            _DisableButtons();
            _InitialStateBar();
            _GlobalRead();
            FirstRead = true;
            _EnableButtons();
        }

        internal int _GlobalRead()
        {
            bool readFail = false;
            int errorCount = 0;
            int delay = 10;
            StateUpdated("Read State:\nPreparing resources...", 1);

            if (cbInfomation.Checked)
            {
                Thread.Sleep(delay);
                tbInformationReadState.BackColor = Color.SteelBlue;
                Application.DoEvents();

                if (ucInformation.ReadApi() < 0)
                {
                    tbInformationReadState.BackColor = Color.Red;
                    StateUpdated("Read State:\nInformation...Failed", 3);
                    errorCount++;
                }
                else
                {
                    tbInformationReadState.BackColor = Color.YellowGreen;
                    StateUpdated("Read State:\nInformation...Done", 3);
                }

                Application.DoEvents();
            }

            if (cbDdm.Checked)
            {
                Thread.Sleep(delay);
                tbDdmReadState.BackColor = Color.SteelBlue;
                Application.DoEvents();

                if (ucDigitalDiagnosticsMonitoring.ReadAllApi() < 0)
                {
                    tbDdmReadState.BackColor = Color.Red;
                    StateUpdated("Read State:\nDdm...Failed", 7);
                    errorCount++;
                }
                else
                {
                    tbDdmReadState.BackColor = Color.YellowGreen;
                    StateUpdated("Read State:\nDdm...Done", 7);
                }

                Application.DoEvents();
            }

            if (cbMemDump.Checked)
            {
                Thread.Sleep(delay);
                tbMemDumpReadState.BackColor = Color.SteelBlue;
                Application.DoEvents();

                if (ucMemoryDump.ReadAllApi(null) < 0)
                {
                    tbMemDumpReadState.BackColor = Color.Red;
                    StateUpdated("Read State:\nMemDump...Failed", 10);
                    errorCount++;
                }
                else
                {
                    tbMemDumpReadState.BackColor = Color.YellowGreen;
                    StateUpdated("Read State:\nMemDump...Done", 10);
                }

                Application.DoEvents();
            }

            if (cbCorrector.Checked)
            {
                Thread.Sleep(delay);
                tbCorrectorReadState.BackColor = Color.SteelBlue;
                Application.DoEvents();

                if (ucGn1190Corrector.ReadAllApi() < 0)
                {
                    tbCorrectorReadState.BackColor = Color.Red;
                    StateUpdated("Read State:\nCorrector...Failed", 15);
                    errorCount++;
                }
                else
                {
                    tbCorrectorReadState.BackColor = Color.YellowGreen;
                    StateUpdated("Read State:\nCorrector...Done", 15);
                }

                Application.DoEvents();
            }

            if (cbProductSelect.SelectedIndex != 0)
            {
                if (cbTxIcConfig.Checked)
                {
                    Thread.Sleep(delay);
                    tbTxConfigReadState.BackColor = Color.SteelBlue;
                    Application.DoEvents();

                    switch (cbProductSelect.SelectedIndex)
                    {
                        case 1: // SAS4.0
                            if (ucMald37045cConfig.ReadAllApi() < 0)
                                readFail = true;

                            break;
                        case 2: // PCIe4
                            if (ucRt146Config.ReadAllApi() < 0)
                                readFail = true;

                            break;
                        case 3: // QSFP28
                            if (ucGn2108Config.ReadAllApi() < 0)
                                readFail = true;

                            break;
                    }

                    if (readFail)
                    {
                        tbTxConfigReadState.BackColor = Color.Red;
                        StateUpdated("Read State:\nTxIcConfig...Failed", 23);
                        errorCount++;
                    }
                    else
                    {
                        tbTxConfigReadState.BackColor = Color.YellowGreen;
                        StateUpdated("Read State:\nTxIcConfig...Done", 23);
                    }

                    Application.DoEvents();
                    readFail = false;
                }

                if (cbRxIcConfig.Checked)
                {
                    Thread.Sleep(delay);
                    tbRxConfigReadState.BackColor = Color.SteelBlue;
                    Application.DoEvents();

                    switch (cbProductSelect.SelectedIndex)
                    {
                        case 1: // SAS4.0
                            if (ucMata37044cConfig.ReadAllApi() < 0)
                                readFail = true;

                            break;
                        case 2: // PCIe4
                            if (ucRt145Config.ReadAllApi() < 0)
                                readFail = true;

                            break;
                        case 3: // QSFP28
                            if (ucGn2109Config.ReadAllApi() < 0)
                                readFail = true;

                            break;
                    }

                    if (readFail)
                    {
                        tbRxConfigReadState.BackColor = Color.Red;
                        StateUpdated("Read State:\nRxIcConfig...Failed", 30);
                        errorCount++;
                    }
                    else
                    {
                        tbRxConfigReadState.BackColor = Color.YellowGreen;
                        StateUpdated("Read State:\nRxIcConfig...Done", 30);
                    }

                    Application.DoEvents();
                }
            }
            return errorCount;
        }

        private bool _LoadFilesPosition(string fileType)
        {
            //string initialDirectory = AppDomain.CurrentDomain.BaseDirectory;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Files position";
                openFileDialog.Filter = "Binary Files (*.bin)|*.bin";
                //openFileDialog.InitialDirectory = initialDirectory;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string sourceFilePath = Path.GetFileName(openFileDialog.FileName);
                    lastUsedDirectory = Path.GetDirectoryName(openFileDialog.FileName);

                    //MessageBox.Show("lastUsedDirectory: \n" + lastUsedDirectory );

                    if (fileType == "APROM")
                    {
                        APROMPath = lastUsedDirectory + "\\" + sourceFilePath;
                        cbAPPath.Checked = true;
                        //MessageBox.Show("APROMPath: \n" + APROMPath);
                    }

                    if (fileType == "DATAROM")
                    {
                        DATAROMPath = lastUsedDirectory + "\\" + sourceFilePath;
                        cbDAPath.Checked = true;
                    }

                    return true;
                }
                else
                {
                    if (fileType == "APROM")
                        cbAPPath.Checked = false;

                    if (fileType == "DATAROM")
                        cbDAPath.Checked = false;

                    return false;  
                }
            }
        }

        private void _GenerateCfgButtonState()
        {
            if ((cbAPPath.Checked) && (rbCustomerMode.Checked || rbMpMode.Checked))
                bGenerateCfg.Enabled = true;
            else
                bGenerateCfg.Enabled = false;
        }

        private void bGlobalWrite_Click(object sender, EventArgs e)
        {
            _DisableButtons();
            _InitialStateBar();

            _GlobalWrite(false);

            _EnableButtons();
        }

        internal int _GlobalWrite2(bool CustomerMode, string CfgFilePath)
        {

            string DirectoryPath = Application.StartupPath;
            string TempRegisterFilePath = Path.Combine(DirectoryPath, "LogFolder/TempRegister.csv");

            StateUpdated("Write State:\nPreparing resources...", 61);
            Application.DoEvents();

            if (CustomerMode)
            {
                if (WriteRegisterPageApi("Up 00h", 50, TempRegisterFilePath) < 0) return -1; //Write from LogFile/TempRegister
                StateUpdated("Write State:\nUpPage 00h...Done", 63);
                Application.DoEvents();
                if (WriteRegisterPageApi("Up 03h", 50, TempRegisterFilePath) < 0) return -1;
                StateUpdated("Write State:\nUpPage 03h...Done", 65);
                Application.DoEvents();
            }
            else
            {
                if (WriteRegisterPageApi("Up 00h", 50, CfgFilePath) < 0) return -1; //Write from Cfg.RegisterFile
                StateUpdated("Write State:\nUpPage 00h...Done", 63);
                Application.DoEvents();
                if (WriteRegisterPageApi("Up 03h", 50, CfgFilePath) < 0) return -1;
                StateUpdated("Write State:\nUpPage 03h...Done", 65);
                Application.DoEvents();
            }

            if (WriteRegisterPageApi("80h", 200, TempRegisterFilePath) < 0) return -1; //Write from LogFile/TempRegister
            StateUpdated("Write State:\nPage 0x80h...Done", 67);
            Application.DoEvents();
            if (WriteRegisterPageApi("81h", 200, TempRegisterFilePath) < 0) return -1;
            StateUpdated("Write State:\nPage 0x81h...Done", 70);
            Application.DoEvents();
            if (WriteRegisterPageApi("Rx", 1000, TempRegisterFilePath) < 0) return -1;
            StateUpdated("Write State:\nRxIcConfig...Done", 80);
            Application.DoEvents();
            if (WriteRegisterPageApi("Tx", 1000, TempRegisterFilePath) < 0) return -1;
            StateUpdated("Write State:\nTxIcConfig...Done", 90);
            Application.DoEvents();

            StoreIntoFlashApi();
            StateUpdated("Write State:\nStore into flash...Done", 95);
            Application.DoEvents();

            return 0;
        }


        internal int _GlobalWrite(bool ExternalMode)
        {
            bool writeFail = false;
            int returnValue = 0;
            int errorCount = 0;
            int delay = 10;

            StateUpdated("Write State:\nPreparing resources...", 62);
            Application.DoEvents();

            if (DebugMode)
                MessageBox.Show("cbInfomation Check state: " + cbInfomation.CheckState);

            
            if (cbInfomation.Checked)
            {
                Thread.Sleep(delay);
                tbInformationReadState.BackColor = Color.SteelBlue;
                Application.DoEvents();

                if (ucInformation.WriteApi() < 0)
                {
                    tbInformationReadState.BackColor = Color.Red;
                    StateUpdated("Write State:\nInformation...Failed", 65);
                    errorCount++;
                }
                else
                {
                    tbInformationReadState.BackColor = Color.YellowGreen;
                    StateUpdated("Write State:\nInformation...Done", 65);
                    if (DebugMode)
                        MessageBox.Show("Write State: Information...Done");
                }
                Application.DoEvents();
            }

            if (DebugMode)
                MessageBox.Show("cbDdm Check state: " + cbDdm.CheckState);

            if (cbDdm.Checked)
            {
                Thread.Sleep(delay);
                tbDdmReadState.BackColor = Color.SteelBlue;
                Application.DoEvents();

                if (ucDigitalDiagnosticsMonitoring.WriteApi() < 0)
                {
                    returnValue = ucDigitalDiagnosticsMonitoring.WriteApi();
                    MessageBox.Show("rv : " + returnValue);
                    tbDdmReadState.BackColor = Color.Red;
                    StateUpdated("Write State:\nDdm...Failed", 68);
                    errorCount++;
                }

                else
                {
                    tbDdmReadState.BackColor = Color.YellowGreen;
                    StateUpdated("Write State:\nDdm...Done", 68);
                    if (DebugMode)
                        MessageBox.Show("Write State: Ddm...Done");
                }
                Application.DoEvents();
            }

            if (DebugMode)
                MessageBox.Show("cbMemDump Check state: " + cbMemDump.CheckState);

            if (cbMemDump.Checked)
            {
                Thread.Sleep(delay);
                tbMemDumpReadState.BackColor = Color.SteelBlue;
                Application.DoEvents();

                if (ucMemoryDump.WriteApi() < 0)
                {
                    tbMemDumpReadState.BackColor = Color.Red;
                    StateUpdated("Write State:\nMemoryDump...Failed", 70);
                    errorCount++;
                }
                else
                {
                    tbMemDumpReadState.BackColor = Color.YellowGreen;
                    StateUpdated("Write State:\nMemoryDump...Done", 70);
                    if (DebugMode)
                        MessageBox.Show("Write State: MemoryDump...Done");
                }
                Application.DoEvents();
            }

            if (DebugMode)
                MessageBox.Show("cbCorrector Check state: " + cbCorrector.CheckState);

            if (cbCorrector.Checked)
            {
                Thread.Sleep(delay);
                tbCorrectorReadState.BackColor = Color.SteelBlue;
                Application.DoEvents();

                if (ucGn1190Corrector.WriteAllApi() < 0)
                {
                    tbCorrectorReadState.BackColor = Color.Red;
                    StateUpdated("Write State:\nCorrector...Failed", 80);
                    errorCount++;
                }
                else
                {
                    tbCorrectorReadState.BackColor = Color.YellowGreen;
                    StateUpdated("Write State:\nCorrector...Done", 80);
                    if (DebugMode)
                        MessageBox.Show("Write State: Corrector...Done");
                }
                Application.DoEvents();
            }

            if (DebugMode)
            {
                MessageBox.Show("cbTxIcConfig Check state: " + cbTxIcConfig.CheckState
                                + "\ncbProductSelect state: " + cbProductSelect.Text
                                );
            }

            if (cbProductSelect.SelectedIndex != 0)
            {
                if (cbTxIcConfig.Checked)
                {
                    Thread.Sleep(delay);
                    tbTxConfigReadState.BackColor = Color.SteelBlue;
                    Application.DoEvents();

                    if (!BypassWriteIcConfig)
                    {
                        switch (cbProductSelect.SelectedIndex)
                        {
                            case 1: // SAS4.0
                                if (ucMald37045cConfig.WriteAllApi() < 0)
                                    writeFail = true;

                                break;
                            case 2: // PCIe4
                                if (ucRt146Config.WriteAllApi() < 0)
                                    writeFail = true;

                                break;
                            case 3: // QSFP28
                                if (ucGn2108Config.WriteAllApi() < 0)
                                    writeFail = true;

                                break;
                        }
                    }

                    if (writeFail)
                    {
                        tbTxConfigReadState.BackColor = Color.Red;
                        StateUpdated("Write State:\nTxIcConfig...Failed", 89);
                        errorCount++;
                    }
                    else
                    {
                        tbTxConfigReadState.BackColor = Color.YellowGreen;
                        StateUpdated("Write State:\nTxIcConfig...Done", 89);
                        if (DebugMode)
                            MessageBox.Show("Write State: TxIcConfig...Done");
                    }
                    Application.DoEvents();
                    writeFail = false;
                }

                if (DebugMode)
                    MessageBox.Show("cbRxIcConfig Check state: " + cbRxIcConfig.CheckState);

                if (cbRxIcConfig.Checked)
                {
                    Thread.Sleep(delay);
                    tbRxConfigReadState.BackColor = Color.SteelBlue;
                    Application.DoEvents();

                    if (!BypassWriteIcConfig)
                    {
                        switch (cbProductSelect.SelectedIndex)
                        {
                            case 1: // SAS4.0
                                if (ucMata37044cConfig.WriteAllApi() < 0)
                                    writeFail = true;

                                break;
                            case 2: // PCIe4
                                if (ucRt145Config.WriteAllApi() < 0)
                                    writeFail = true;

                                break;
                            case 3: // QSFP28
                                if (ucGn2109Config.WriteAllApi() < 0)
                                    writeFail = true;

                                break;
                        }
                    }

                    if (writeFail)
                    {
                        tbRxConfigReadState.BackColor = Color.Red;
                        StateUpdated("Write State:\nRxIcConfig...Failed", 98);
                        errorCount++;
                    }
                    else
                    {
                        tbRxConfigReadState.BackColor = Color.YellowGreen;
                        StateUpdated("Write State:\nRxIcConfig...Done", 98);
                        if (DebugMode)
                            MessageBox.Show("Write State: RxIcConfig...Done");
                    }

                    Application.DoEvents();
                }
            }

            return errorCount;
        }

        private void bStoreIntoFlash_Click(object sender, EventArgs e)
        {
            _DisableButtons();
            ucInformation.StoreIntoFlashApi();
            _EnableButtons();
        }

        private void bSaveCfgFile_Click(object sender, EventArgs e)
        {
            string LogFileName = "RegisterFile";
            lastUsedDirectory = Application.StartupPath;
            _DisableButtons();
            // Save the file 
            _GlobalWrite(false);
            _InitialStateBar();

            _ExportLogfileToCsv(LogFileName, false, false);

            _EnableButtons();
        }

        private void bLoadCfgFile_Click(object sender, EventArgs e)
        {
            string DirectoryPath = Application.StartupPath;
            string TempRegisterFilePath = Path.Combine(DirectoryPath, "LogFolder/TempRegister.csv");

            _DisableButtons();

            progressBar1.Value = 0;
            _ConnectI2c();
            Thread.Sleep(500);
            _ConnectI2c();

            //Write data from RegisterFile
            progressBar1.Value = 5;
            WriteRegisterPageApi("Up 00h", 10, TempRegisterFilePath);
            progressBar1.Value = 10;
            WriteRegisterPageApi("Up 03h", 10, TempRegisterFilePath);
            progressBar1.Value = 20;
            WriteRegisterPageApi("80h", 200, TempRegisterFilePath);
            progressBar1.Value = 30;
            WriteRegisterPageApi("81h", 200, TempRegisterFilePath);
            progressBar1.Value = 40;
            WriteRegisterPageApi("Rx", 1000, TempRegisterFilePath);
            progressBar1.Value = 50;
            WriteRegisterPageApi("Tx", 1000, TempRegisterFilePath);
            progressBar1.Value = 60;

            StoreIntoFlashApi();
            progressBar1.Value = 80;

            _ConnectI2c();
            Thread.Sleep(500);
            _ConnectI2c();

            progressBar1.Value = 90;
            _InitialStateBar();
            _GlobalRead();

            progressBar1.Value = 100;

            _EnableButtons();
        }

        private void bReNew_Click(object sender, EventArgs e)
        {
            _DisableButtons();

            dtWriteConfig.Clear();
            
            dgvWriteConfig.DataSource = dtWriteConfig;

            _EnableButtons();
        }

        private void bScanComponents_Click(object sender, EventArgs e)
        {
            if (bScanComponents.Enabled)
                bScanComponents.Enabled = false;

            //_GenerateXmlFileFromUcComponents();
            _GenerateXmlFileForProject();
            bScanComponents.Enabled = true;
        }

        private void cbProductSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            _EnableIcConfig();
            _UpdateTabPageVisibility();
        }

        private void cbPermission_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConfigUiByXmlApi("settings.xml");
        }

        private void _MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _I2cMasterDisconnect();

            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        private void rbCustomerMode_CheckedChanged(object sender, EventArgs e)
        {
            _GenerateCfgButtonState();
        }

        private void rbMpMode_CheckedChanged(object sender, EventArgs e)
        {
            _GenerateCfgButtonState();
        }

        private void bBackToMainForm_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void cbContinuousMode_CheckedChanged(Object sender, EventArgs e)
        {
            MessageBox.Show("Function to be confirmed");
        }

        private void bGenerateCfg_Click(object sender, EventArgs e)
        {
            _DisableButtons();

            _GenerateXmlFileForProject();

            _EnableButtons();
        }

        private void cbConnected_CheckedChanged(object sender, EventArgs e)
        {
            _DisableButtons();

            if (FirstRound)
            {
                ProcessingChannel = 1;
                FirstRound = false;
            }

            _ConnectI2c();
            _EnableButtons();
        }

        private void _ConnectI2c()
        {
            if (cbConnect.Checked == true) {
                _I2cMasterConnect(true, true);
                i2cMaster.ChannelSetApi(ProcessingChannel);
                _UpdateButtonState();
                gbChannelSwitcher.Enabled = true;
            }
            else {
                _I2cMasterDisconnect();
                gbChannelSwitcher.Enabled = false;
            }
        }

        private void bIcpConnect_Click(object sender, EventArgs e)
        {
            bIcpConnect.Enabled = false;

            ucNuvotonIcpTool.IcpConnectApi();

            //if (!bIcpConnect.Enabled)
            bIcpConnect.Enabled = true;
        }

        private void cbAutoReconnect_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAutoReconnect.Checked)
                _SetAutoReconnectControl(true);
            else if (!cbAutoReconnect.Checked)
                _SetAutoReconnectControl(false);
        }

        private void bAutoReconnectStateCheck_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ucNuvotonIcp\nAutoReconnectMode: " + _GetAutoReconnectControl());
        }
        
        private void cbBypassEraseAllCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBypassEraseAllCheck.Checked)
                _SetBypassEraseAllControl(true);
            else if (!cbBypassEraseAllCheck.Checked)
                _SetBypassEraseAllControl(false);
        }

        private void bBypassEraseAllStateCheck_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ucNuvotonIcp\nBypassEraseAllMode: " + _GetBypassEraseAllControl());
        }

        private void cbAPPath_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAPPath.Checked)
            {
                _LoadFilesPosition("APROM");
                _GenerateCfgButtonState();
            }
            else if (!cbAPPath.Checked)
            {
                APROMPath = "";
            }
            
        }

        private void cbDAPath_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDAPath.Checked)
            {
                _LoadFilesPosition("DATAROM");
                _GenerateCfgButtonState();
            }
            else if (!cbDAPath.Checked)
            {
                DATAROMPath = "";
            }
            
        }
    }

    public class ComboBoxItem
    {
        public string Text { get; set; }
        public int Value { get; set; }
        public override string ToString()
        {
            return Text;
        }

    }

}
