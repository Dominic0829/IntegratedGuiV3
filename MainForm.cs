using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using I2cMasterInterface;
using System.Xml;

using ComponentFactory.Krypton.Toolkit;
using Mald37045cMata37044c;
using QsfpDigitalDiagnosticMonitoring;
using Rt145Rt146Config;
using System.Threading;
using System.Runtime.Remoting.Channels;

namespace IntegratedGuiV2
{
    public partial class MainForm : KryptonForm
    {
        private I2cMaster i2cMaster = new I2cMaster();
        private AdapterSelector adapterSelector = new AdapterSelector();

        private int iHandler = -1;
        private short iBitrate = 100; //kbps
        private short TriggerDelay = 100; //ms
        private int Channel = 0;
        private bool StopContinuousMode = false;

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

        private int _I2cMasterConnect()
        {
            if (i2cMaster.ConnectApi(100) < 0)
                return -1;

            cbConnected.Checked = true;

            if (_SetQsfpMode(0x4D) < 0)
                return -1;

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
                if (_I2cMasterConnect() < 0)
                    return -1;
            }

            if (_SetQsfpMode(0x4D) < 0)
                return -1;

            rv = i2cMaster.ReadApi(devAddr, regAddr, length, data);
            if (rv < 0)
            {
                MessageBox.Show("TRx module no response!! for read");
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
                if (_I2cMasterConnect() < 0)
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

        private int _WriteModulePassword()
        {
            byte[] data;

            data = Encoding.Default.GetBytes(tbPassword.Text);

            if (i2cMaster.WriteApi(80, 123, 4, data) < 0)
                return -1;

            return 0;
        }

        private void cbConnected_CheckedChanged(object sender, EventArgs e)
        {
            if (cbConnected.Checked == true)
            {
                if (_I2cMasterConnect() < 0)
                    return;
                _WriteModulePassword();
                i2cMaster.ChannelSet(1);
                gbChannelSwitcher.Enabled = true;
                Channel = 1;
                UpdateButtonState();
            }
            else
            {
                _I2cMasterDisconnect();
                gbChannelSwitcher.Enabled = false;
            }

        }

        private int _GetPassword(int length, byte[] data)
        {
            byte[] tmp = new byte[4];

            if (length < 4)
                return -1;

            if (data == null)
                return -1;

            data = Encoding.Default.GetBytes(tbPassword.Text);
            return 4;
        }


        public MainForm()
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(1080, 850);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //UcDigitalDiagnosticsMonitoring1.SetI2cReadCBApi(_I2cRead);
            //UcDigitalDiagnosticsMonitoring1.SetI2cWriteCBApi(_I2cWrite);

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
        }

        private void btReadOverAll_Click(object sender, EventArgs e)
        {

            ucDigitalDiagnosticsMonitoring.bRead_Click(sender, e);
            ucInformation._bRead_Click(sender, e);
            ucMemoryDump.bRead_Click(sender, e);

            UcMald37045cConfig1.bReadAll_Click(sender, e);
            UcMata37044cConfig1.bReadAll_Click(sender, e);

            UcRt146Config1.bReadAll_Click(sender, e);
            UcRt145Config1.bReadAll_Click(sender, e);

        }

        private void GenerateXmlSettings()
        {
            XmlDocument xmlDoc = new XmlDocument();
            
            XmlElement root = xmlDoc.CreateElement("Settings"); // XML Root node
            xmlDoc.AppendChild(root);
            XmlElement permissionsNode = xmlDoc.CreateElement("Permissions"); // Permissions node
            root.AppendChild(permissionsNode);

            string[] roles = { "Admin", "Engineer", "Operator" }; //Permission conditions

            foreach (string role in roles)
            {
                XmlElement permissionNode = xmlDoc.CreateElement("Permission");
                permissionNode.SetAttribute("role", role);
                permissionsNode.AppendChild(permissionNode);

                List<UserControl> userControls = GetAllUserControls(this); // Get all user control from MainForm

                foreach (UserControl userControl in userControls)
                {
                    XmlElement userControlNode = xmlDoc.CreateElement("UserControl");
                    userControlNode.SetAttribute("name", userControl.Name);
                    permissionNode.AppendChild(userControlNode);

                    // Go through all the components in the User Control and create nodes for each
                    List<Control> userControlComponents = GetAllControls(userControl); 
                    XmlElement componentsNode = xmlDoc.CreateElement("Components");

                    foreach (Control control in userControlComponents)
                    {
                        XmlElement componentNode = xmlDoc.CreateElement("Component");
                        componentNode.SetAttribute("name", control.Name);
                        componentNode.SetAttribute("visible", "true"); // Default value
                        componentsNode.AppendChild(componentNode);
                    }

                    userControlNode.AppendChild(componentsNode);
                }
            }

            xmlDoc.Save("Settings.xml"); // Save XML file
        }

        // Go through the MainForm and get all the UserControls.
        private List<UserControl> GetAllUserControls(Control control)
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

        // Go through the UserControls and get all the components
        private List<Control> GetAllControls(Control control)
        {
            List<Control> controls = new List<Control>();

            foreach (Control childControl in control.Controls)
            {
                controls.Add(childControl);

                //  Get all the components from each UserControl
                if (childControl is UserControl userControl)
                {
                    controls.AddRange(GetAllControls(userControl));
                }

                controls.AddRange(GetAllControls(childControl));
            }

            return controls;
        }
   
        private void btSwitch_Click(object sender, EventArgs e)
        {
            if (btSwitch.Enabled == true)
                btSwitch.Enabled = false;

            Channel = (Channel == 1) ? 2 : 1;

            i2cMaster.ChannelSet(Channel);
            UpdateButtonState();
            StopContinuousMode = !StopContinuousMode;

            if (btSwitch.Enabled == false)
                btSwitch.Enabled = true;
            
            return;
        }
        

        private void UpdateButtonState()
        {
           
            if (Channel == 1)
            {
                rbCh1.Checked = true;
                rbCh2.Checked = false;
            }

            if (Channel == 2)
            {
                rbCh2.Checked = true;
                rbCh1.Checked = false;
            }

            System.Windows.Forms.Application.DoEvents();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //GenerateXmlSettings();
            //i2cMaster.ConnectApi();
            //
            /*
            i2cMaster.ChannelSet(1);
            Thread.Sleep(3000);
            i2cMaster.ChannelSet(0);
            Thread.Sleep(3000);
            i2cMaster.ChannelSet(2);
            Thread.Sleep(3000);
            i2cMaster.ChannelSet(0);
            */
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
