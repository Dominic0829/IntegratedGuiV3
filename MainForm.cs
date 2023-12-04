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



namespace IntegratedGuiV2
{
    public partial class MainForm : KryptonForm
    {
        private I2cMaster i2cMaster = new I2cMaster();
        UCDigitalDiagnosticsMonitoring UcDigitalDiagnosticsMonitoring1 = new UCDigitalDiagnosticsMonitoring();
        UcInformation UcInformation1 = new UcInformation();
        UCMemoryDump UcMemoryDump1 = new UCMemoryDump();

        UcMald37045cConfig UcMald37045cConfig1 = new UcMald37045cConfig();
        UcMata37044cConfig UcMata37044cConfig1 = new UcMata37044cConfig();

        UcRt146Config UcRt146Config1 = new UcRt146Config();
        UcRt145Config UcRt145Config1 = new UcRt145Config();

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
                MessageBox.Show("QSFP+ module no response!!");
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
                MessageBox.Show("QSFP+ module no response!!");
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
            }
            else
                _I2cMasterDisconnect();
        }

        public MainForm()
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(1080, 850);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;



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

            UcDigitalDiagnosticsMonitoring1.bRead_Click(sender, e);
            UcInformation1._bRead_Click(sender, e);
            UcMemoryDump1.bRead_Click(sender, e);

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



        private void button1_Click(object sender, EventArgs e)
        {
            GenerateXmlSettings();
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
