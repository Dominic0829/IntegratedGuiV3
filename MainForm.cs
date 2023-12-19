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

namespace IntegratedGuiV2
{
    public partial class MainForm : KryptonForm
    {
        private I2cMaster i2cMaster = new I2cMaster();
        private AdapterSelector adapterSelector = new AdapterSelector();
        private ExfoIqs1600Scpi powerMeter = new ExfoIqs1600Scpi();

        private int iHandler = -1;
        private short iBitrate = 400; //kbps
        private short TriggerDelay = 100; //ms
        private int Channel = 0;
        private bool FirstRead = false;
        private bool StopContinuousMode = false;
        private bool AutoSelectIcConfig = false;
        private string sAcConfig;


        private int _SetQsfpMode(byte mode)
        {
            byte[] data = new byte[] { 0xaa };

            if (i2cMaster.WriteApi(80, 127, 1, data) < 0)
                return -1;

            data[0] = mode;

            if (i2cMaster.WriteApi(80, 164, 1, data) < 0)
                return -1;

            return 0;
        }

        private int _I2cMasterConnect(bool setMode)
        {
            if (i2cMaster.ConnectApi(iBitrate) < 0)
                return -1;

            cbConnected.Checked = true;

            if (setMode)
            {
                if (_SetQsfpMode(0x4D) < 0)
                    return -1;
            }

            return 0;
        }

        private int _I2cMasterDisconnect()
        {
            if (i2cMaster.DisconnectApi() < 0)
                return -1;

            cbConnected.Checked = false;

            return 0;
        }

        private int _I2cRead(byte devAddr, byte regAddr, byte length, byte[] data)
        {
            int rv;
            if (i2cMaster.connected == false)
            {
                if (_I2cMasterConnect(true) < 0)
                    return -1;
            }
            
            if (_SetQsfpMode(0x4D) < 0)
                return -1;
            
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

        private int _I2cRead2(byte devAddr, byte regAddr, byte length, byte[] data)
        {
            int rv;
            if (i2cMaster.connected == false)
            {
                if (_I2cMasterConnect(false) < 0)
                    return -1;
            }

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

        private int _I2cRead16(byte devAddr, byte[] regAddr, byte length, byte[] data)
        {
            int rv;
            if (i2cMaster.connected == false)
            {
                if (_I2cMasterConnect(true) < 0)
                    return -1;
            }

            if (_SetQsfpMode(0x4D) < 0)
                return -1;

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

        private int _I2cWrite(byte devAddr, byte regAddr, byte length, byte[] data)
        {
            int rv;

            if (i2cMaster.connected == false)
            {
                if (_I2cMasterConnect(true) < 0)
                    return -1;
            }
            
            if (_SetQsfpMode(0x4D) < 0)
                return -1;
            
            rv = i2cMaster.WriteApi(devAddr, regAddr, length, data);
            if (rv < 0)
            {
                MessageBox.Show("TRx module no response!!");
                _I2cMasterDisconnect();
            }

            return rv;
        }

        private int _I2cWrite2(byte devAddr, byte regAddr, byte length, byte[] data)
        {
            int rv;

            if (i2cMaster.connected == false)
            {
                if (_I2cMasterConnect(false) < 0)
                    return -1;
            }

            rv = i2cMaster.WriteApi(devAddr, regAddr, length, data);
            if (rv < 0)
            {
                MessageBox.Show("TRx module no response!!");
                _I2cMasterDisconnect();
            }

            return rv;
        }

        private int _I2cWrite16(byte devAddr, byte[] regAddr, byte length, byte[] data)
        {
            int rv;

            if (i2cMaster.connected == false)
            {
                if (_I2cMasterConnect(true) < 0)
                    return -1;
            }

            if (_SetQsfpMode(0x4D) < 0)
                return -1;

            rv = i2cMaster.Write16Api(devAddr, regAddr, length, data);
            if (rv < 0)
            {
                MessageBox.Show("TRx module no response!!");
                _I2cMasterDisconnect();
            }

            return rv;
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

        private int _GetPassword_(int length, byte[] data)
        {
            byte[] tmp = new byte[4];
            string dataS;

            if (length < 4)
                return -1;

            if (data == null)
                return -1;

            if (tbPassword.Text.Length != 4)
            {
                MessageBox.Show("Please input a 4-digit password before operating!!");
                return -1;
            }

            for (int i = 0; i < 4; i++)
            {
                data[i] = Convert.ToByte(tbPassword.Text[i].ToString(), 16);
            }

            dataS = Encoding.Default.GetString(data);
            MessageBox.Show("GetPassword parsed: " + dataS);

            return 4;
        }

        private int _GetPassword(int length, byte[] data)
        {
            byte[] tmp = new byte[4];
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

            data[0] = Convert.ToByte(tbPasswordB0.Text, 16);
            data[1] = Convert.ToByte(tbPasswordB1.Text, 16);
            data[2] = Convert.ToByte(tbPasswordB2.Text, 16);
            data[3] = Convert.ToByte(tbPasswordB3.Text, 16);

            dataS = Encoding.Default.GetString(data);
            //MessageBox.Show("_GetPassword parse： " + dataS);

            return 4;
        }

        private void cbConnected_CheckedChanged(object sender, EventArgs e)
        {
            if (cbConnected.Checked == true)
            {
                if (_I2cMasterConnect(true) < 0)
                    return;
                _WriteModulePassword();
                i2cMaster.ChannelSet(1);
                gbChannelSwitcher.Enabled = true;
                Channel = 1;
                _UpdateButtonState();
            }
            else
            {
                _I2cMasterDisconnect();
                gbChannelSwitcher.Enabled = false;
            }

        }

        public MainForm()
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(1170, 850);
            _InitialStateBar();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            cbProductSelect.SelectedIndex = 0;

            if (ucInformation.SetI2cReadCBApi(_I2cRead2) < 0)
            {
                MessageBox.Show("ucInformation.SetI2cReadCBApi() faile Error!!");
                return;
            }
            if (ucInformation.SetI2cWriteCBApi(_I2cWrite2) < 0)
            {
                MessageBox.Show("ucInformation.SetI2cReadCBApi() faile Error!!");
                return;
            }
            if (ucInformation.SetGetPasswordCBApi(_GetPassword) < 0)
            {
                MessageBox.Show("ucInformation.SetGetPasswordCBApi() faile Error!!");
                return;
            }

            if (ucDigitalDiagnosticsMonitoring.SetI2cReadCBApi(_I2cRead2) < 0)
            {
                MessageBox.Show("ucDigitalDiagnosticsMonitoring.SetI2cReadCBApi() faile Error!!");
                return;
            }
            if (ucDigitalDiagnosticsMonitoring.SetI2cWriteCBApi(_I2cWrite2) < 0)
            {
                MessageBox.Show("ucDigitalDiagnosticsMonitoring.SetI2cReadCBApi() faile Error!!");
                return;
            }
            if (ucDigitalDiagnosticsMonitoring.SetWritePasswordCBApi(ucInformation.WritePassword) < 0)
            {
                MessageBox.Show("ucDigitalDiagnosticsMonitoring.SetWritePasswordCBApi() faile Error!!");
                return;
            }

            if (ucMemoryDump.SetI2cReadCBApi(_I2cRead2) < 0)
            {
                MessageBox.Show("ucMemoryDump.SetI2cReadCBApi() faile Error!!");
                return;
            }
            if (ucMemoryDump.SetI2cWriteCBApi(_I2cWrite2) < 0)
            {
                MessageBox.Show("ucMemoryDump.SetI2cReadCBApi() faile Error!!");
                return;
            }
            if (ucMemoryDump.SetWritePasswordCBApi(ucInformation.WritePassword) < 0)
            {
                MessageBox.Show("ucMemoryDump.SetWritePasswordCBApi() faile Error!!");
                return;
            }

            if (ucGn1190Corrector.SetQsfpI2cReadCBApi(_I2cRead2) < 0)
            {
                MessageBox.Show("ucQsfpCorrector.SetQsfpI2cReadCBApi() faile Error!!");
                return;
            }
            if (ucGn1190Corrector.SetQsfpI2cWriteCBApi(_I2cWrite2) < 0)
            {
                MessageBox.Show("ucQsfpCorrector.SetQsfpI2cWriteCBApi() faile Error!!");
                return;
            }

            if (ucMald37045cConfig.SetI2cReadCBApi(_I2cRead) < 0)
            {
                MessageBox.Show("ucMald37045cConfig.SetI2cReadCBApi() faile Error!!");
                return;
            }
            if (ucMald37045cConfig.SetI2cWriteCBApi(_I2cWrite) < 0)
            {
                MessageBox.Show("ucMald37045cConfig.SetI2cWriteCBApi() faile Error!!");
                return;
            }
            if (ucMata37044cConfig.SetI2cReadCBApi(_I2cRead) < 0)
            {
                MessageBox.Show("ucMata37044cConfig.SetI2cReadCBApi() faile Error!!");
                return;
            }
            if (ucMata37044cConfig.SetI2cWriteCBApi(_I2cWrite) < 0)
            {
                MessageBox.Show("ucMata37044cConfig.SetI2cWriteCBApi() faile Error!!");
                return;
            }

            if (ucRt145Config.SetI2cReadCBApi(_I2cRead) < 0)
            {
                MessageBox.Show("ucRt145Config.SetI2cReadCBApi() faile Error!!");
                return;
            }
            if (ucRt145Config.SetI2cWriteCBApi(_I2cWrite) < 0)
            {
                MessageBox.Show("ucRt145Config.SetI2cWriteCBApi() faile Error!!");
                return;
            }
            if (ucRt146Config.SetI2cReadCBApi(_I2cRead) < 0)
            {
                MessageBox.Show("ucRt145Config.SetI2cReadCBApi() faile Error!!");
                return;
            }
            if (ucRt146Config.SetI2cWriteCBApi(_I2cWrite) < 0)
            {
                MessageBox.Show("ucRt145Config.SetI2cWriteCBApi() faile Error!!");
                return;
            }

            if (ucGn2108Config.SetI2cReadCBApi(_I2cRead) < 0)
            {
                MessageBox.Show("ucGn1190Config.SetI2cReadCBApi() faile Error!!");
                return;
            }
            if (ucGn2108Config.SetI2cWriteCBApi(_I2cWrite) < 0)
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

            if (ucGn2109Config.SetI2cReadCBApi(_I2cRead) < 0)
            {
                MessageBox.Show("ucGn1190Config.SetI2cReadCBApi() faile Error!!");
                return;
            }
            if (ucGn2109Config.SetI2cWriteCBApi(_I2cWrite) < 0)
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
        
        private void bGlobalRead_Click(object sender, EventArgs e)
        {

            bool readFail = false;
            _DisableButtons();
            _InitialStateBar();

            if (cbInfomation.Checked)
            {
                tbInformationReadState.BackColor = Color.SteelBlue;
                Application.DoEvents();

                if (ucInformation.ReadAllApi() < 0)
                    tbInformationReadState.BackColor = Color.Red;
                else
                    tbInformationReadState.BackColor = Color.YellowGreen;

                Application.DoEvents();
            }

            if (cbDdm.Checked)
            {
                tbDdmReadState.BackColor = Color.SteelBlue;
                Application.DoEvents();

                if (ucDigitalDiagnosticsMonitoring.ReadAllApi() < 0)
                    tbDdmReadState.BackColor = Color.Red;
                else
                    tbDdmReadState.BackColor = Color.YellowGreen;

                Application.DoEvents();
            }

            if (cbMemDump.Checked)
            {
                tbMemDumpReadState.BackColor = Color.SteelBlue;
                Application.DoEvents();

                if (ucMemoryDump.ReadAllApi() < 0)
                    tbMemDumpReadState.BackColor = Color.Red;
                else
                    tbMemDumpReadState.BackColor = Color.YellowGreen;

                Application.DoEvents();
            }

            if (cbCorrector.Checked)
            {
                tbCorrectorReadState.BackColor = Color.SteelBlue;
                Application.DoEvents();

                if (ucGn1190Corrector.ReadAllApi() < 0)
                    tbCorrectorReadState.BackColor = Color.Red;
                else
                    tbCorrectorReadState.BackColor = Color.YellowGreen;

                Application.DoEvents();
            }

            if (cbProductSelect.SelectedIndex != 0)
            {
                if (cbTxIcConfig.Checked)
                {
                    tbTxConfigReadState.BackColor = Color.SteelBlue;
                    Application.DoEvents();

                    switch (cbProductSelect.SelectedIndex)
                    {
                        case 1: // SAS4.0
                            if (ucMald37045cConfig.ReadAllApi() < 0 )
                                readFail = true;

                            break;
                        case 2: // PCIe4
                            if (ucRt146Config.ReadAllApi() < 0 )
                                readFail = true;

                            break;
                        case 3: // QSFP28
                            if (ucGn2108Config.ReadAllApi() < 0)
                                readFail = true;

                            break;
                    }

                    if (readFail)
                        tbTxConfigReadState.BackColor = Color.Red;
                    else
                        tbTxConfigReadState.BackColor = Color.YellowGreen;

                    Application.DoEvents();
                    readFail = false;
                }

                if (cbRxIcConfig.Checked)
                {
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
                        tbRxConfigReadState.BackColor = Color.Red;
                    else
                        tbRxConfigReadState.BackColor = Color.YellowGreen;

                    Application.DoEvents();
                }
            }
           
            FirstRead = true;
            _EnableButtons();
        }

        private void _StoreGlobalWriteCommandtoFile()
        {
            SaveFileDialog sfdSelectFile = new SaveFileDialog();

            sAcConfig = "//Write,DevAddr,RegAddr,Value\n" + "//Read,DevAddr,RegAddr,Value\n" +
                "//Delay10mSec,Time\n";

            ucInformation._bWrite_Click(null,null);
            ucDigitalDiagnosticsMonitoring.bWrite_Click(null, null);
            ucMemoryDump.bWrite_Click(null, null);

            sfdSelectFile.Filter = "cfg files (*.cfg)|*.cfg";
            if (sfdSelectFile.ShowDialog() != DialogResult.OK)
                return;

            System.IO.File.WriteAllText(sfdSelectFile.FileName, sAcConfig);
        }

        private void bGlobalWrite_Click(object sender, EventArgs e)
        {
            bool writeFail = false;

            _DisableButtons();
            _InitialStateBar();

            if (cbInfomation.Checked)
            {
                tbInformationReadState.BackColor = Color.SteelBlue;
                Application.DoEvents();
                
                if (ucInformation.WriteApi() < 0)
                    tbInformationReadState.BackColor = Color.Red;
                else
                    tbInformationReadState.BackColor = Color.YellowGreen;
                
                Application.DoEvents();
            }

            if (cbDdm.Checked)
            {
                tbDdmReadState.BackColor = Color.SteelBlue;
                Application.DoEvents();

                if (ucDigitalDiagnosticsMonitoring.WriteApi() <0)
                    tbDdmReadState.BackColor = Color.Red;
                else
                    tbDdmReadState.BackColor = Color.YellowGreen;
                
                Application.DoEvents();
            }

            if (cbMemDump.Checked)
            {
                tbMemDumpReadState.BackColor = Color.SteelBlue;
                Application.DoEvents();

                if (ucMemoryDump.WriteApi()< 0)
                    tbMemDumpReadState.BackColor = Color.Red;
                else
                    tbMemDumpReadState.BackColor = Color.YellowGreen;

                Application.DoEvents();
            }

            if (cbCorrector.Checked)
            {
                tbCorrectorReadState.BackColor = Color.SteelBlue;
                Application.DoEvents();

                if (ucGn1190Corrector.WriteAllApi() < 0)
                    tbCorrectorReadState.BackColor = Color.Red;
                else
                    tbCorrectorReadState.BackColor = Color.YellowGreen;

                Application.DoEvents();
            }

            if (cbProductSelect.SelectedIndex != 0)
            {
                if (cbTxIcConfig.Checked)
                {
                    tbTxConfigReadState.BackColor = Color.SteelBlue;
                    Application.DoEvents();

                    switch (cbProductSelect.SelectedIndex)
                    {
                        case 1: // SAS4.0
                            if (ucMald37045cConfig.WriteAllApi() < 0)
                                writeFail = true;

                            break;
                        case 2: // PCIe4
                            if (ucRt146Config.WriteAllApi() <0)
                                writeFail = true;

                            break;
                        case 3: // QSFP28
                            if (ucGn2108Config.WriteAllApi() < 0)
                                writeFail = true;

                            break;
                    }

                    if (writeFail)
                        tbTxConfigReadState.BackColor = Color.Red;
                    else
                        tbTxConfigReadState.BackColor = Color.YellowGreen;

                    Application.DoEvents();
                    writeFail = false;
                }

                if (cbRxIcConfig.Checked)
                {
                    tbRxConfigReadState.BackColor = Color.SteelBlue;
                    Application.DoEvents();

                    switch (cbProductSelect.SelectedIndex)
                    {
                        case 1: // SAS4.0
                            if (ucMata37044cConfig.WriteAllApi() < 0)
                                writeFail = true;

                            break;
                        case 2: // PCIe4
                            if (ucRt145Config.WriteAllApi() <0)
                                writeFail = true;

                            break;
                        case 3: // QSFP28
                            if (ucGn2109Config.WriteAllApi() <0)
                                writeFail = true;

                            break;
                    }

                    if (writeFail)
                        tbRxConfigReadState.BackColor = Color.Red;
                    else
                        tbRxConfigReadState.BackColor = Color.YellowGreen;

                    Application.DoEvents();
                }
            }

            _EnableButtons();
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
            bGlobalRead.Enabled = false;
            bInnerSwitch.Enabled = false;
            bOutterSwitch.Enabled = false;
            bGlobalWrite.Enabled = false;
            bStoreIntoFlash.Enabled = false;
            tcDdmi.Enabled = false;
            tcIcConfig.Enabled = false;
            ucGn1190Corrector.DisableButtonApi();
        }

        private void _EnableButtons()
        {
            bGlobalRead.Enabled = true;
            bInnerSwitch.Enabled = true;
            bOutterSwitch.Enabled = true;
            tcDdmi.Enabled = true;
            tcIcConfig.Enabled = true;
            ucGn1190Corrector.EnableButtonApi();

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

        private void _GenerateXmlSettings()
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlElement root = xmlDoc.CreateElement("Settings");
            xmlDoc.AppendChild(root);
            XmlElement permissionsNode = xmlDoc.CreateElement("Permissions");
            root.AppendChild(permissionsNode);
            string[] roles = { "Admin", "Engineer", "Operator" };

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

            xmlDoc.Save("Settings.xml");
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

            if (configXml.Length == 0)
            {
                ofdSelectFile.Title = "Select config file";
                ofdSelectFile.Filter = "xml files (*.xml)|*.xml";
                if (ofdSelectFile.ShowDialog() != DialogResult.OK)
                    return -1;
                xrConfig = XmlReader.Create(ofdSelectFile.FileName);
            }
            else
            {
                xrConfig = XmlReader.Create(configXml);
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
                _DisableButtons();

            _channelSwitch();

            if (bOutterSwitch.Enabled == false)
                _EnableButtons();
                
        }

        private void bInnerSwitch_Click(object sender, EventArgs e)
        {
            if (bInnerSwitch.Enabled == true)
                _DisableButtons();

            _channelSwitch();

            if (bInnerSwitch.Enabled == false)
                _EnableButtons();
        }

        private void _channelSwitch()
        {
            Channel = (Channel == 1) ? 2 : 1;

            i2cMaster.ChannelSet(Channel);
            _UpdateButtonState();

            return;
        }
        
        private void _UpdateButtonState()
        {
           
            if (Channel == 1)
            {
                rbCh1.Checked = true;
                rbCh2.Checked = false;
                tbInnerStateCh1.BackColor = Color.YellowGreen;
                tbInnerStateCh2.BackColor = Color.White;
            }

            if (Channel == 2)
            {
                rbCh2.Checked = true;
                rbCh1.Checked = false;
                tbInnerStateCh1.BackColor = Color.White;
                tbInnerStateCh2.BackColor = Color.YellowGreen;
            }

            System.Windows.Forms.Application.DoEvents();
        }

        private void _ContinuousMode()
        {
            while(cbContinuousMode.Checked){ 
            ucNuvotonIcpTool.bLink_Click(null, null);
            ucNuvotonIcpTool.bStart_Click(null, null);
            bInnerSwitch_Click(null, null);
            }
        }

        

        private void _EnableIcConfig()
        {
            if (cbProductSelect.SelectedIndex != 0)
            {
                cbTxIcConfig.Enabled = true;
                cbTxIcConfig.Checked = true;
                cbRxIcConfig.Enabled = true;
                cbRxIcConfig.Checked = true;
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
        private void bFunctionTest_Click(object sender, EventArgs e)
        {
            if (bFunctionTest.Enabled)
                bFunctionTest.Enabled = false;

            //InitializeComponentsVisibility();
            //_GenerateXmlSettings();
            //ConfigUiByXmlApi("settings.xml");
            //_StoreGlobalWriteCommandtoFile();
            ucDigitalDiagnosticsMonitoring.bStoreIntoFlash_Click(sender, e);
            bFunctionTest.Enabled = true;
        }

        private void cbProductSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            _EnableIcConfig();
            _UpdateTabPageVisibility();
        }

        private void cbContinuousMode_CheckedChanged(object sender, EventArgs e)
        {
            _ContinuousMode();
        }

        private void cbPermission_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConfigUiByXmlApi("settings.xml");
        }

        private void bScanComponents_Click(object sender, EventArgs e)
        {
            if (bScanComponents.Enabled)
                bScanComponents.Enabled = false;

            _GenerateXmlSettings();
            bScanComponents.Enabled = true;
        }

        private void bStoreIntoFlash_Click(object sender, EventArgs e)
        {
            _DisableButtons();
            ucInformation.bStoreIntoFlash_Click(null, null);
            _EnableButtons();
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
