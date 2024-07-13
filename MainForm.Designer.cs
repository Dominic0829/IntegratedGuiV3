using Mald37045cMata37044c;
using System.Windows.Forms.VisualStyles;

namespace IntegratedGuiV2
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tcDdmi = new System.Windows.Forms.TabControl();
            this.tabPage11 = new System.Windows.Forms.TabPage();
            this.ucInformation = new QsfpDigitalDiagnosticMonitoring.UcInformation();
            this.tabPage12 = new System.Windows.Forms.TabPage();
            this.ucDigitalDiagnosticsMonitoring = new QsfpDigitalDiagnosticMonitoring.UCDigitalDiagnosticsMonitoring();
            this.tabPage13 = new System.Windows.Forms.TabPage();
            this.ucMemoryDump = new QsfpDigitalDiagnosticMonitoring.UCMemoryDump();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ucGn1190Corrector = new Gn1190Corrector.UcGn1190CorrectorLite();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tcIcConfig = new System.Windows.Forms.TabControl();
            this.tabPage31 = new System.Windows.Forms.TabPage();
            this.tcSas40 = new System.Windows.Forms.TabControl();
            this.tabPage311 = new System.Windows.Forms.TabPage();
            this.ucMald37045cConfig = new Mald37045cMata37044c.UcMald37045cConfig();
            this.tabPage312 = new System.Windows.Forms.TabPage();
            this.ucMata37044cConfig = new Mald37045cMata37044c.UcMata37044cConfig();
            this.tabPage32 = new System.Windows.Forms.TabPage();
            this.tcPcie4 = new System.Windows.Forms.TabControl();
            this.tabPage321 = new System.Windows.Forms.TabPage();
            this.ucRt146Config = new Rt145Rt146Config.UcRt146Config();
            this.tabPage322 = new System.Windows.Forms.TabPage();
            this.ucRt145Config = new Rt145Rt146Config.UcRt145Config();
            this.tabPage33 = new System.Windows.Forms.TabPage();
            this.tcQsfp28 = new System.Windows.Forms.TabControl();
            this.tabPage331 = new System.Windows.Forms.TabPage();
            this.ucGn2108Config = new Gn2108Gn2109Config.UcGn2108Config();
            this.tabPage332 = new System.Windows.Forms.TabPage();
            this.ucGn2109Config = new Gn2108Gn2109Config.UcGn2109Config();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.bBypassEraseAllStateCheck = new System.Windows.Forms.Button();
            this.cbBypassEraseAllCheck = new System.Windows.Forms.CheckBox();
            this.bAutoReconnectStateCheck = new System.Windows.Forms.Button();
            this.cbAutoReconnect = new System.Windows.Forms.CheckBox();
            this.bIcpConnect = new System.Windows.Forms.Button();
            this.ucNuvotonIcpTool = new NuvotonIcpTool.UcNuvotonIcpTool();
            this.lContinuousMode = new System.Windows.Forms.Label();
            this.cbContinuousMode = new System.Windows.Forms.CheckBox();
            this.lCh2 = new System.Windows.Forms.Label();
            this.lCh1 = new System.Windows.Forms.Label();
            this.tbInnerStateCh2 = new System.Windows.Forms.TextBox();
            this.tbInnerStateCh1 = new System.Windows.Forms.TextBox();
            this.bInnerSwitch = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.gbWriteConfig = new System.Windows.Forms.GroupBox();
            this.dgvWriteConfig = new System.Windows.Forms.DataGridView();
            this.kryptonPalette1 = new ComponentFactory.Krypton.Toolkit.KryptonPalette(this.components);
            this.cbConnect = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.lPassword = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.bGlobalRead = new System.Windows.Forms.Button();
            this.gbChannelSwitcher = new System.Windows.Forms.GroupBox();
            this.rbCh2 = new System.Windows.Forms.RadioButton();
            this.bOutterSwitch = new System.Windows.Forms.Button();
            this.rbCh1 = new System.Windows.Forms.RadioButton();
            this.tbInformationReadState = new System.Windows.Forms.TextBox();
            this.tbDdmReadState = new System.Windows.Forms.TextBox();
            this.tbMemDumpReadState = new System.Windows.Forms.TextBox();
            this.tbCorrectorReadState = new System.Windows.Forms.TextBox();
            this.tbTxConfigReadState = new System.Windows.Forms.TextBox();
            this.tbRxConfigReadState = new System.Windows.Forms.TextBox();
            this.cbInfomation = new System.Windows.Forms.CheckBox();
            this.gbGlobalControl = new System.Windows.Forms.GroupBox();
            this.cbRxIcConfig = new System.Windows.Forms.CheckBox();
            this.cbTxIcConfig = new System.Windows.Forms.CheckBox();
            this.cbCorrector = new System.Windows.Forms.CheckBox();
            this.cbMemDump = new System.Windows.Forms.CheckBox();
            this.cbDdm = new System.Windows.Forms.CheckBox();
            this.bGlobalWrite = new System.Windows.Forms.Button();
            this.bGlobalWrite2 = new System.Windows.Forms.Button();
            this.tbPasswordB3 = new System.Windows.Forms.TextBox();
            this.tbPasswordB2 = new System.Windows.Forms.TextBox();
            this.tbPasswordB1 = new System.Windows.Forms.TextBox();
            this.tbPasswordB0 = new System.Windows.Forms.TextBox();
            this.bScanComponents = new System.Windows.Forms.Button();
            this.bStoreIntoFlash = new System.Windows.Forms.Button();
            this.bFunctionTest2 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.bDumpToString = new System.Windows.Forms.Button();
            this.gbPermissions = new System.Windows.Forms.GroupBox();
            this.cbPermission = new System.Windows.Forms.ComboBox();
            this.gbProduct = new System.Windows.Forms.GroupBox();
            this.cbProductSelect = new System.Windows.Forms.ComboBox();
            this.gbGenerateCfg = new System.Windows.Forms.GroupBox();
            this.cbDAPath = new System.Windows.Forms.CheckBox();
            this.bGenerateCfg = new System.Windows.Forms.Button();
            this.rbMpMode = new System.Windows.Forms.RadioButton();
            this.rbCustomerMode = new System.Windows.Forms.RadioButton();
            this.cbAPPath = new System.Windows.Forms.CheckBox();
            this.bBackToMainForm = new System.Windows.Forms.Button();
            this.lMessage = new System.Windows.Forms.Label();
            this.tcMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tcDdmi.SuspendLayout();
            this.tabPage11.SuspendLayout();
            this.tabPage12.SuspendLayout();
            this.tabPage13.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tcIcConfig.SuspendLayout();
            this.tabPage31.SuspendLayout();
            this.tcSas40.SuspendLayout();
            this.tabPage311.SuspendLayout();
            this.tabPage312.SuspendLayout();
            this.tabPage32.SuspendLayout();
            this.tcPcie4.SuspendLayout();
            this.tabPage321.SuspendLayout();
            this.tabPage322.SuspendLayout();
            this.tabPage33.SuspendLayout();
            this.tcQsfp28.SuspendLayout();
            this.tabPage331.SuspendLayout();
            this.tabPage332.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.gbWriteConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWriteConfig)).BeginInit();
            this.gbChannelSwitcher.SuspendLayout();
            this.gbGlobalControl.SuspendLayout();
            this.gbPermissions.SuspendLayout();
            this.gbProduct.SuspendLayout();
            this.gbGenerateCfg.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tabPage1);
            this.tcMain.Controls.Add(this.tabPage2);
            this.tcMain.Controls.Add(this.tabPage3);
            this.tcMain.Controls.Add(this.tabPage4);
            this.tcMain.Controls.Add(this.tabPage5);
            this.tcMain.Location = new System.Drawing.Point(3, 28);
            this.tcMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(1000, 800);
            this.tcMain.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.tabPage1.Controls.Add(this.tcDdmi);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(992, 774);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "DDMI";
            // 
            // tcDdmi
            // 
            this.tcDdmi.Controls.Add(this.tabPage11);
            this.tcDdmi.Controls.Add(this.tabPage12);
            this.tcDdmi.Controls.Add(this.tabPage13);
            this.tcDdmi.Location = new System.Drawing.Point(5, 5);
            this.tcDdmi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tcDdmi.Name = "tcDdmi";
            this.tcDdmi.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tcDdmi.SelectedIndex = 0;
            this.tcDdmi.Size = new System.Drawing.Size(980, 780);
            this.tcDdmi.TabIndex = 5;
            // 
            // tabPage11
            // 
            this.tabPage11.Controls.Add(this.ucInformation);
            this.tabPage11.Location = new System.Drawing.Point(4, 22);
            this.tabPage11.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage11.Size = new System.Drawing.Size(972, 754);
            this.tabPage11.TabIndex = 0;
            this.tabPage11.Text = "Information";
            this.tabPage11.UseVisualStyleBackColor = true;
            // 
            // ucInformation
            // 
            this.ucInformation.Location = new System.Drawing.Point(5, 5);
            this.ucInformation.Margin = new System.Windows.Forms.Padding(4);
            this.ucInformation.Name = "ucInformation";
            this.ucInformation.Size = new System.Drawing.Size(960, 760);
            this.ucInformation.TabIndex = 1;
            // 
            // tabPage12
            // 
            this.tabPage12.Controls.Add(this.ucDigitalDiagnosticsMonitoring);
            this.tabPage12.Location = new System.Drawing.Point(4, 22);
            this.tabPage12.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage12.Name = "tabPage12";
            this.tabPage12.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage12.Size = new System.Drawing.Size(972, 754);
            this.tabPage12.TabIndex = 1;
            this.tabPage12.Text = "DDM";
            this.tabPage12.UseVisualStyleBackColor = true;
            // 
            // ucDigitalDiagnosticsMonitoring
            // 
            this.ucDigitalDiagnosticsMonitoring.Location = new System.Drawing.Point(5, 5);
            this.ucDigitalDiagnosticsMonitoring.Margin = new System.Windows.Forms.Padding(4);
            this.ucDigitalDiagnosticsMonitoring.Name = "ucDigitalDiagnosticsMonitoring";
            this.ucDigitalDiagnosticsMonitoring.Size = new System.Drawing.Size(960, 760);
            this.ucDigitalDiagnosticsMonitoring.TabIndex = 1;
            // 
            // tabPage13
            // 
            this.tabPage13.Controls.Add(this.ucMemoryDump);
            this.tabPage13.Location = new System.Drawing.Point(4, 22);
            this.tabPage13.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage13.Name = "tabPage13";
            this.tabPage13.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage13.Size = new System.Drawing.Size(972, 754);
            this.tabPage13.TabIndex = 2;
            this.tabPage13.Text = "MemDump";
            this.tabPage13.UseVisualStyleBackColor = true;
            // 
            // ucMemoryDump
            // 
            this.ucMemoryDump.Location = new System.Drawing.Point(5, 5);
            this.ucMemoryDump.Margin = new System.Windows.Forms.Padding(4);
            this.ucMemoryDump.Name = "ucMemoryDump";
            this.ucMemoryDump.Size = new System.Drawing.Size(960, 760);
            this.ucMemoryDump.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ucGn1190Corrector);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(992, 774);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Corrector";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ucGn1190Corrector
            // 
            this.ucGn1190Corrector.BackColor = System.Drawing.Color.Transparent;
            this.ucGn1190Corrector.Location = new System.Drawing.Point(5, 5);
            this.ucGn1190Corrector.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucGn1190Corrector.Name = "ucGn1190Corrector";
            this.ucGn1190Corrector.Size = new System.Drawing.Size(980, 780);
            this.ucGn1190Corrector.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tcIcConfig);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage3.Size = new System.Drawing.Size(992, 774);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "IC Config";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tcIcConfig
            // 
            this.tcIcConfig.Controls.Add(this.tabPage31);
            this.tcIcConfig.Controls.Add(this.tabPage32);
            this.tcIcConfig.Controls.Add(this.tabPage33);
            this.tcIcConfig.Location = new System.Drawing.Point(5, 5);
            this.tcIcConfig.Margin = new System.Windows.Forms.Padding(2);
            this.tcIcConfig.Name = "tcIcConfig";
            this.tcIcConfig.SelectedIndex = 0;
            this.tcIcConfig.Size = new System.Drawing.Size(980, 780);
            this.tcIcConfig.TabIndex = 0;
            // 
            // tabPage31
            // 
            this.tabPage31.Controls.Add(this.tcSas40);
            this.tabPage31.Location = new System.Drawing.Point(4, 22);
            this.tabPage31.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage31.Name = "tabPage31";
            this.tabPage31.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage31.Size = new System.Drawing.Size(972, 754);
            this.tabPage31.TabIndex = 0;
            this.tabPage31.Text = "SAS4.0";
            this.tabPage31.UseVisualStyleBackColor = true;
            // 
            // tcSas40
            // 
            this.tcSas40.Controls.Add(this.tabPage311);
            this.tcSas40.Controls.Add(this.tabPage312);
            this.tcSas40.Location = new System.Drawing.Point(5, 5);
            this.tcSas40.Margin = new System.Windows.Forms.Padding(2);
            this.tcSas40.Name = "tcSas40";
            this.tcSas40.SelectedIndex = 0;
            this.tcSas40.Size = new System.Drawing.Size(960, 760);
            this.tcSas40.TabIndex = 0;
            // 
            // tabPage311
            // 
            this.tabPage311.Controls.Add(this.ucMald37045cConfig);
            this.tabPage311.Location = new System.Drawing.Point(4, 22);
            this.tabPage311.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage311.Name = "tabPage311";
            this.tabPage311.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage311.Size = new System.Drawing.Size(952, 734);
            this.tabPage311.TabIndex = 0;
            this.tabPage311.Text = "MALD37045C";
            this.tabPage311.UseVisualStyleBackColor = true;
            // 
            // ucMald37045cConfig
            // 
            this.ucMald37045cConfig.Location = new System.Drawing.Point(5, 5);
            this.ucMald37045cConfig.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucMald37045cConfig.Name = "ucMald37045cConfig";
            this.ucMald37045cConfig.Size = new System.Drawing.Size(940, 740);
            this.ucMald37045cConfig.TabIndex = 0;
            // 
            // tabPage312
            // 
            this.tabPage312.Controls.Add(this.ucMata37044cConfig);
            this.tabPage312.Location = new System.Drawing.Point(4, 22);
            this.tabPage312.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage312.Name = "tabPage312";
            this.tabPage312.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage312.Size = new System.Drawing.Size(952, 734);
            this.tabPage312.TabIndex = 1;
            this.tabPage312.Text = "MATA37044C";
            this.tabPage312.UseVisualStyleBackColor = true;
            // 
            // ucMata37044cConfig
            // 
            this.ucMata37044cConfig.Location = new System.Drawing.Point(5, 5);
            this.ucMata37044cConfig.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucMata37044cConfig.Name = "ucMata37044cConfig";
            this.ucMata37044cConfig.Size = new System.Drawing.Size(940, 740);
            this.ucMata37044cConfig.TabIndex = 0;
            // 
            // tabPage32
            // 
            this.tabPage32.Controls.Add(this.tcPcie4);
            this.tabPage32.Location = new System.Drawing.Point(4, 22);
            this.tabPage32.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage32.Name = "tabPage32";
            this.tabPage32.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage32.Size = new System.Drawing.Size(972, 754);
            this.tabPage32.TabIndex = 1;
            this.tabPage32.Text = "PCIe4.0";
            this.tabPage32.UseVisualStyleBackColor = true;
            // 
            // tcPcie4
            // 
            this.tcPcie4.Controls.Add(this.tabPage321);
            this.tcPcie4.Controls.Add(this.tabPage322);
            this.tcPcie4.Location = new System.Drawing.Point(5, 5);
            this.tcPcie4.Margin = new System.Windows.Forms.Padding(2);
            this.tcPcie4.Name = "tcPcie4";
            this.tcPcie4.SelectedIndex = 0;
            this.tcPcie4.Size = new System.Drawing.Size(960, 760);
            this.tcPcie4.TabIndex = 0;
            // 
            // tabPage321
            // 
            this.tabPage321.Controls.Add(this.ucRt146Config);
            this.tabPage321.Location = new System.Drawing.Point(4, 22);
            this.tabPage321.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage321.Name = "tabPage321";
            this.tabPage321.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage321.Size = new System.Drawing.Size(952, 734);
            this.tabPage321.TabIndex = 0;
            this.tabPage321.Text = "RT146";
            this.tabPage321.UseVisualStyleBackColor = true;
            // 
            // ucRt146Config
            // 
            this.ucRt146Config.BackColor = System.Drawing.Color.White;
            this.ucRt146Config.Location = new System.Drawing.Point(5, 5);
            this.ucRt146Config.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucRt146Config.Name = "ucRt146Config";
            this.ucRt146Config.Size = new System.Drawing.Size(940, 740);
            this.ucRt146Config.TabIndex = 0;
            // 
            // tabPage322
            // 
            this.tabPage322.Controls.Add(this.ucRt145Config);
            this.tabPage322.Location = new System.Drawing.Point(4, 22);
            this.tabPage322.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage322.Name = "tabPage322";
            this.tabPage322.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage322.Size = new System.Drawing.Size(952, 734);
            this.tabPage322.TabIndex = 1;
            this.tabPage322.Text = "RT145";
            this.tabPage322.UseVisualStyleBackColor = true;
            // 
            // ucRt145Config
            // 
            this.ucRt145Config.BackColor = System.Drawing.Color.Transparent;
            this.ucRt145Config.Location = new System.Drawing.Point(5, 5);
            this.ucRt145Config.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucRt145Config.Name = "ucRt145Config";
            this.ucRt145Config.Size = new System.Drawing.Size(940, 740);
            this.ucRt145Config.TabIndex = 0;
            // 
            // tabPage33
            // 
            this.tabPage33.Controls.Add(this.tcQsfp28);
            this.tabPage33.Location = new System.Drawing.Point(4, 22);
            this.tabPage33.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage33.Name = "tabPage33";
            this.tabPage33.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage33.Size = new System.Drawing.Size(972, 754);
            this.tabPage33.TabIndex = 2;
            this.tabPage33.Text = "QSFP28";
            this.tabPage33.UseVisualStyleBackColor = true;
            // 
            // tcQsfp28
            // 
            this.tcQsfp28.Controls.Add(this.tabPage331);
            this.tcQsfp28.Controls.Add(this.tabPage332);
            this.tcQsfp28.Location = new System.Drawing.Point(5, 5);
            this.tcQsfp28.Name = "tcQsfp28";
            this.tcQsfp28.SelectedIndex = 0;
            this.tcQsfp28.Size = new System.Drawing.Size(960, 760);
            this.tcQsfp28.TabIndex = 0;
            // 
            // tabPage331
            // 
            this.tabPage331.Controls.Add(this.ucGn2108Config);
            this.tabPage331.Location = new System.Drawing.Point(4, 22);
            this.tabPage331.Name = "tabPage331";
            this.tabPage331.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage331.Size = new System.Drawing.Size(952, 734);
            this.tabPage331.TabIndex = 0;
            this.tabPage331.Text = "Gn2108";
            this.tabPage331.UseVisualStyleBackColor = true;
            // 
            // ucGn2108Config
            // 
            this.ucGn2108Config.Location = new System.Drawing.Point(5, 5);
            this.ucGn2108Config.Margin = new System.Windows.Forms.Padding(4);
            this.ucGn2108Config.Name = "ucGn2108Config";
            this.ucGn2108Config.Size = new System.Drawing.Size(940, 740);
            this.ucGn2108Config.TabIndex = 0;
            // 
            // tabPage332
            // 
            this.tabPage332.Controls.Add(this.ucGn2109Config);
            this.tabPage332.Location = new System.Drawing.Point(4, 22);
            this.tabPage332.Name = "tabPage332";
            this.tabPage332.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage332.Size = new System.Drawing.Size(952, 734);
            this.tabPage332.TabIndex = 1;
            this.tabPage332.Text = "Gn2109";
            this.tabPage332.UseVisualStyleBackColor = true;
            // 
            // ucGn2109Config
            // 
            this.ucGn2109Config.Location = new System.Drawing.Point(5, 5);
            this.ucGn2109Config.Margin = new System.Windows.Forms.Padding(4);
            this.ucGn2109Config.Name = "ucGn2109Config";
            this.ucGn2109Config.Size = new System.Drawing.Size(940, 740);
            this.ucGn2109Config.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.bBypassEraseAllStateCheck);
            this.tabPage4.Controls.Add(this.cbBypassEraseAllCheck);
            this.tabPage4.Controls.Add(this.bAutoReconnectStateCheck);
            this.tabPage4.Controls.Add(this.cbAutoReconnect);
            this.tabPage4.Controls.Add(this.bIcpConnect);
            this.tabPage4.Controls.Add(this.ucNuvotonIcpTool);
            this.tabPage4.Controls.Add(this.lContinuousMode);
            this.tabPage4.Controls.Add(this.cbContinuousMode);
            this.tabPage4.Controls.Add(this.lCh2);
            this.tabPage4.Controls.Add(this.lCh1);
            this.tabPage4.Controls.Add(this.tbInnerStateCh2);
            this.tabPage4.Controls.Add(this.tbInnerStateCh1);
            this.tabPage4.Controls.Add(this.bInnerSwitch);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage4.Size = new System.Drawing.Size(992, 774);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "ICP Tool";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // bBypassEraseAllStateCheck
            // 
            this.bBypassEraseAllStateCheck.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.bBypassEraseAllStateCheck.Location = new System.Drawing.Point(284, 28);
            this.bBypassEraseAllStateCheck.Margin = new System.Windows.Forms.Padding(2);
            this.bBypassEraseAllStateCheck.Name = "bBypassEraseAllStateCheck";
            this.bBypassEraseAllStateCheck.Size = new System.Drawing.Size(77, 20);
            this.bBypassEraseAllStateCheck.TabIndex = 1023;
            this.bBypassEraseAllStateCheck.Text = "CheckState";
            this.bBypassEraseAllStateCheck.UseVisualStyleBackColor = true;
            this.bBypassEraseAllStateCheck.Visible = false;
            this.bBypassEraseAllStateCheck.Click += new System.EventHandler(this.bBypassEraseAllStateCheck_Click);
            // 
            // cbBypassEraseAllCheck
            // 
            this.cbBypassEraseAllCheck.AutoSize = true;
            this.cbBypassEraseAllCheck.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbBypassEraseAllCheck.Location = new System.Drawing.Point(22, 31);
            this.cbBypassEraseAllCheck.Name = "cbBypassEraseAllCheck";
            this.cbBypassEraseAllCheck.Size = new System.Drawing.Size(259, 17);
            this.cbBypassEraseAllCheck.TabIndex = 1022;
            this.cbBypassEraseAllCheck.Text = "Bypass confirm button before EraseAll operation";
            this.cbBypassEraseAllCheck.UseVisualStyleBackColor = true;
            this.cbBypassEraseAllCheck.CheckedChanged += new System.EventHandler(this.cbBypassEraseAllCheck_CheckedChanged);
            // 
            // bAutoReconnectStateCheck
            // 
            this.bAutoReconnectStateCheck.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.bAutoReconnectStateCheck.Location = new System.Drawing.Point(284, 9);
            this.bAutoReconnectStateCheck.Margin = new System.Windows.Forms.Padding(2);
            this.bAutoReconnectStateCheck.Name = "bAutoReconnectStateCheck";
            this.bAutoReconnectStateCheck.Size = new System.Drawing.Size(77, 20);
            this.bAutoReconnectStateCheck.TabIndex = 1021;
            this.bAutoReconnectStateCheck.Text = "CheckState";
            this.bAutoReconnectStateCheck.UseVisualStyleBackColor = true;
            this.bAutoReconnectStateCheck.Visible = false;
            this.bAutoReconnectStateCheck.Click += new System.EventHandler(this.bAutoReconnectStateCheck_Click);
            // 
            // cbAutoReconnect
            // 
            this.cbAutoReconnect.AutoSize = true;
            this.cbAutoReconnect.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbAutoReconnect.Location = new System.Drawing.Point(22, 12);
            this.cbAutoReconnect.Name = "cbAutoReconnect";
            this.cbAutoReconnect.Size = new System.Drawing.Size(130, 17);
            this.cbAutoReconnect.TabIndex = 1020;
            this.cbAutoReconnect.Text = "AutoReconnect Mode";
            this.cbAutoReconnect.UseVisualStyleBackColor = true;
            this.cbAutoReconnect.CheckedChanged += new System.EventHandler(this.cbAutoReconnect_CheckedChanged);
            // 
            // bIcpConnect
            // 
            this.bIcpConnect.Font = new System.Drawing.Font("PMingLiU", 16F);
            this.bIcpConnect.Location = new System.Drawing.Point(22, 74);
            this.bIcpConnect.Margin = new System.Windows.Forms.Padding(2);
            this.bIcpConnect.Name = "bIcpConnect";
            this.bIcpConnect.Size = new System.Drawing.Size(118, 57);
            this.bIcpConnect.TabIndex = 1019;
            this.bIcpConnect.Text = "Connect";
            this.bIcpConnect.UseVisualStyleBackColor = true;
            this.bIcpConnect.Click += new System.EventHandler(this.bIcpConnect_Click);
            // 
            // ucNuvotonIcpTool
            // 
            this.ucNuvotonIcpTool.Location = new System.Drawing.Point(53, 71);
            this.ucNuvotonIcpTool.Margin = new System.Windows.Forms.Padding(4);
            this.ucNuvotonIcpTool.Name = "ucNuvotonIcpTool";
            this.ucNuvotonIcpTool.Size = new System.Drawing.Size(433, 300);
            this.ucNuvotonIcpTool.TabIndex = 0;
            // 
            // lContinuousMode
            // 
            this.lContinuousMode.AutoSize = true;
            this.lContinuousMode.Location = new System.Drawing.Point(525, 183);
            this.lContinuousMode.Name = "lContinuousMode";
            this.lContinuousMode.Size = new System.Drawing.Size(281, 12);
            this.lContinuousMode.TabIndex = 1018;
            this.lContinuousMode.Text = "(The DUT will cross-flash firmware in a sequential pattern.)";
            this.lContinuousMode.Visible = false;
            // 
            // cbContinuousMode
            // 
            this.cbContinuousMode.AutoSize = true;
            this.cbContinuousMode.Font = new System.Drawing.Font("PMingLiU", 16F);
            this.cbContinuousMode.Location = new System.Drawing.Point(502, 153);
            this.cbContinuousMode.Name = "cbContinuousMode";
            this.cbContinuousMode.Size = new System.Drawing.Size(174, 26);
            this.cbContinuousMode.TabIndex = 1015;
            this.cbContinuousMode.Text = "Continuous mode";
            this.cbContinuousMode.UseVisualStyleBackColor = true;
            this.cbContinuousMode.Visible = false;
            this.cbContinuousMode.CheckedChanged += new System.EventHandler(this.cbContinuousMode_CheckedChanged);
            // 
            // lCh2
            // 
            this.lCh2.AutoSize = true;
            this.lCh2.Enabled = false;
            this.lCh2.Font = new System.Drawing.Font("PMingLiU", 16F);
            this.lCh2.Location = new System.Drawing.Point(676, 79);
            this.lCh2.Name = "lCh2";
            this.lCh2.Size = new System.Drawing.Size(44, 22);
            this.lCh2.TabIndex = 1014;
            this.lCh2.Text = "Ch2";
            // 
            // lCh1
            // 
            this.lCh1.AutoSize = true;
            this.lCh1.Enabled = false;
            this.lCh1.Font = new System.Drawing.Font("PMingLiU", 16F);
            this.lCh1.Location = new System.Drawing.Point(622, 79);
            this.lCh1.Name = "lCh1";
            this.lCh1.Size = new System.Drawing.Size(44, 22);
            this.lCh1.TabIndex = 1013;
            this.lCh1.Text = "Ch1";
            // 
            // tbInnerStateCh2
            // 
            this.tbInnerStateCh2.BackColor = System.Drawing.Color.White;
            this.tbInnerStateCh2.Enabled = false;
            this.tbInnerStateCh2.Font = new System.Drawing.Font("PMingLiU", 1F);
            this.tbInnerStateCh2.Location = new System.Drawing.Point(672, 103);
            this.tbInnerStateCh2.Name = "tbInnerStateCh2";
            this.tbInnerStateCh2.Size = new System.Drawing.Size(50, 9);
            this.tbInnerStateCh2.TabIndex = 1017;
            // 
            // tbInnerStateCh1
            // 
            this.tbInnerStateCh1.BackColor = System.Drawing.Color.White;
            this.tbInnerStateCh1.Enabled = false;
            this.tbInnerStateCh1.Font = new System.Drawing.Font("PMingLiU", 1F);
            this.tbInnerStateCh1.Location = new System.Drawing.Point(616, 103);
            this.tbInnerStateCh1.Name = "tbInnerStateCh1";
            this.tbInnerStateCh1.Size = new System.Drawing.Size(50, 9);
            this.tbInnerStateCh1.TabIndex = 1016;
            // 
            // bInnerSwitch
            // 
            this.bInnerSwitch.Font = new System.Drawing.Font("PMingLiU", 16F);
            this.bInnerSwitch.Location = new System.Drawing.Point(502, 74);
            this.bInnerSwitch.Margin = new System.Windows.Forms.Padding(2);
            this.bInnerSwitch.Name = "bInnerSwitch";
            this.bInnerSwitch.Size = new System.Drawing.Size(98, 57);
            this.bInnerSwitch.TabIndex = 2;
            this.bInnerSwitch.Text = "Channel Switch";
            this.bInnerSwitch.UseVisualStyleBackColor = true;
            this.bInnerSwitch.Click += new System.EventHandler(this.bInnerSwitch_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.gbWriteConfig);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage5.Size = new System.Drawing.Size(992, 774);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "...";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // gbWriteConfig
            // 
            this.gbWriteConfig.Controls.Add(this.dgvWriteConfig);
            this.gbWriteConfig.Location = new System.Drawing.Point(24, 23);
            this.gbWriteConfig.Name = "gbWriteConfig";
            this.gbWriteConfig.Size = new System.Drawing.Size(349, 600);
            this.gbWriteConfig.TabIndex = 88;
            this.gbWriteConfig.TabStop = false;
            this.gbWriteConfig.Text = "Write Config";
            // 
            // dgvWriteConfig
            // 
            this.dgvWriteConfig.AllowUserToResizeColumns = false;
            this.dgvWriteConfig.AllowUserToResizeRows = false;
            this.dgvWriteConfig.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvWriteConfig.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWriteConfig.Location = new System.Drawing.Point(6, 21);
            this.dgvWriteConfig.Name = "dgvWriteConfig";
            this.dgvWriteConfig.RowHeadersWidth = 51;
            this.dgvWriteConfig.RowTemplate.Height = 24;
            this.dgvWriteConfig.Size = new System.Drawing.Size(337, 573);
            this.dgvWriteConfig.TabIndex = 0;
            // 
            // kryptonPalette1
            // 
            this.kryptonPalette1.ButtonStyles.ButtonForm.StateNormal.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.kryptonPalette1.ButtonStyles.ButtonForm.StateNormal.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.kryptonPalette1.ButtonStyles.ButtonForm.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette1.ButtonStyles.ButtonForm.StateNormal.Border.Width = 0;
            this.kryptonPalette1.ButtonStyles.ButtonForm.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.kryptonPalette1.ButtonStyles.ButtonForm.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.kryptonPalette1.ButtonStyles.ButtonForm.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette1.ButtonStyles.ButtonForm.StatePressed.Border.Width = 0;
            this.kryptonPalette1.ButtonStyles.ButtonForm.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.kryptonPalette1.ButtonStyles.ButtonForm.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.kryptonPalette1.ButtonStyles.ButtonForm.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette1.ButtonStyles.ButtonForm.StateTracking.Border.Width = 0;
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.None;
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Border.Rounding = 15;
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.ButtonEdgeInset = 10;
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Content.Padding = new System.Windows.Forms.Padding(10, -1, -1, -1);
            // 
            // cbConnect
            // 
            this.cbConnect.Location = new System.Drawing.Point(1010, 10);
            this.cbConnect.Margin = new System.Windows.Forms.Padding(2);
            this.cbConnect.Name = "cbConnect";
            this.cbConnect.Size = new System.Drawing.Size(105, 22);
            this.cbConnect.StateCommon.ShortText.Color1 = System.Drawing.SystemColors.ControlText;
            this.cbConnect.StateCommon.ShortText.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbConnect.TabIndex = 5;
            this.cbConnect.Values.Text = "I2c Connect";
            this.cbConnect.CheckedChanged += new System.EventHandler(this.cbConnected_CheckedChanged);
            // 
            // lPassword
            // 
            this.lPassword.AutoSize = true;
            this.lPassword.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.lPassword.Location = new System.Drawing.Point(4, 3);
            this.lPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lPassword.Name = "lPassword";
            this.lPassword.Size = new System.Drawing.Size(66, 15);
            this.lPassword.TabIndex = 6;
            this.lPassword.Text = "Password：";
            // 
            // tbPassword
            // 
            this.tbPassword.Font = new System.Drawing.Font("PMingLiU", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbPassword.Location = new System.Drawing.Point(67, 0);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(2);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.ShortcutsEnabled = false;
            this.tbPassword.Size = new System.Drawing.Size(72, 22);
            this.tbPassword.TabIndex = 7;
            this.tbPassword.Text = "3234";
            this.tbPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbPassword.UseSystemPasswordChar = true;
            // 
            // bGlobalRead
            // 
            this.bGlobalRead.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.bGlobalRead.Location = new System.Drawing.Point(1013, 59);
            this.bGlobalRead.Margin = new System.Windows.Forms.Padding(2);
            this.bGlobalRead.Name = "bGlobalRead";
            this.bGlobalRead.Size = new System.Drawing.Size(100, 28);
            this.bGlobalRead.TabIndex = 2;
            this.bGlobalRead.Text = "Global Read";
            this.bGlobalRead.UseVisualStyleBackColor = true;
            this.bGlobalRead.Click += new System.EventHandler(this.bGlobalRead_Click);
            // 
            // gbChannelSwitcher
            // 
            this.gbChannelSwitcher.Controls.Add(this.rbCh2);
            this.gbChannelSwitcher.Controls.Add(this.bOutterSwitch);
            this.gbChannelSwitcher.Controls.Add(this.rbCh1);
            this.gbChannelSwitcher.Enabled = false;
            this.gbChannelSwitcher.Font = new System.Drawing.Font("PMingLiU", 6F);
            this.gbChannelSwitcher.Location = new System.Drawing.Point(832, 3);
            this.gbChannelSwitcher.Margin = new System.Windows.Forms.Padding(1);
            this.gbChannelSwitcher.Name = "gbChannelSwitcher";
            this.gbChannelSwitcher.Padding = new System.Windows.Forms.Padding(1);
            this.gbChannelSwitcher.Size = new System.Drawing.Size(143, 40);
            this.gbChannelSwitcher.TabIndex = 1007;
            this.gbChannelSwitcher.TabStop = false;
            // 
            // rbCh2
            // 
            this.rbCh2.AutoSize = true;
            this.rbCh2.Enabled = false;
            this.rbCh2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCh2.Location = new System.Drawing.Point(96, 14);
            this.rbCh2.Margin = new System.Windows.Forms.Padding(1);
            this.rbCh2.Name = "rbCh2";
            this.rbCh2.Size = new System.Drawing.Size(45, 19);
            this.rbCh2.TabIndex = 1009;
            this.rbCh2.TabStop = true;
            this.rbCh2.Text = "Ch2";
            this.rbCh2.UseVisualStyleBackColor = true;
            // 
            // bOutterSwitch
            // 
            this.bOutterSwitch.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.bOutterSwitch.Location = new System.Drawing.Point(3, 7);
            this.bOutterSwitch.Margin = new System.Windows.Forms.Padding(2);
            this.bOutterSwitch.Name = "bOutterSwitch";
            this.bOutterSwitch.Size = new System.Drawing.Size(45, 28);
            this.bOutterSwitch.TabIndex = 6;
            this.bOutterSwitch.Text = "SW";
            this.bOutterSwitch.UseVisualStyleBackColor = true;
            this.bOutterSwitch.Click += new System.EventHandler(this.bOutterSwitch_Click);
            // 
            // rbCh1
            // 
            this.rbCh1.AutoSize = true;
            this.rbCh1.Enabled = false;
            this.rbCh1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCh1.Location = new System.Drawing.Point(53, 14);
            this.rbCh1.Margin = new System.Windows.Forms.Padding(1);
            this.rbCh1.Name = "rbCh1";
            this.rbCh1.Size = new System.Drawing.Size(45, 19);
            this.rbCh1.TabIndex = 1008;
            this.rbCh1.TabStop = true;
            this.rbCh1.Text = "Ch1";
            this.rbCh1.UseVisualStyleBackColor = true;
            // 
            // tbInformationReadState
            // 
            this.tbInformationReadState.Enabled = false;
            this.tbInformationReadState.Font = new System.Drawing.Font("PMingLiU", 0.1F);
            this.tbInformationReadState.Location = new System.Drawing.Point(20, 35);
            this.tbInformationReadState.Margin = new System.Windows.Forms.Padding(2);
            this.tbInformationReadState.Name = "tbInformationReadState";
            this.tbInformationReadState.ShortcutsEnabled = false;
            this.tbInformationReadState.Size = new System.Drawing.Size(61, 8);
            this.tbInformationReadState.TabIndex = 1008;
            // 
            // tbDdmReadState
            // 
            this.tbDdmReadState.Enabled = false;
            this.tbDdmReadState.Font = new System.Drawing.Font("PMingLiU", 0.1F);
            this.tbDdmReadState.Location = new System.Drawing.Point(20, 62);
            this.tbDdmReadState.Margin = new System.Windows.Forms.Padding(2);
            this.tbDdmReadState.Name = "tbDdmReadState";
            this.tbDdmReadState.ShortcutsEnabled = false;
            this.tbDdmReadState.Size = new System.Drawing.Size(61, 8);
            this.tbDdmReadState.TabIndex = 1009;
            // 
            // tbMemDumpReadState
            // 
            this.tbMemDumpReadState.Enabled = false;
            this.tbMemDumpReadState.Font = new System.Drawing.Font("PMingLiU", 0.1F);
            this.tbMemDumpReadState.Location = new System.Drawing.Point(20, 88);
            this.tbMemDumpReadState.Margin = new System.Windows.Forms.Padding(2);
            this.tbMemDumpReadState.Name = "tbMemDumpReadState";
            this.tbMemDumpReadState.ShortcutsEnabled = false;
            this.tbMemDumpReadState.Size = new System.Drawing.Size(61, 8);
            this.tbMemDumpReadState.TabIndex = 1010;
            // 
            // tbCorrectorReadState
            // 
            this.tbCorrectorReadState.Enabled = false;
            this.tbCorrectorReadState.Font = new System.Drawing.Font("PMingLiU", 0.1F);
            this.tbCorrectorReadState.Location = new System.Drawing.Point(20, 114);
            this.tbCorrectorReadState.Margin = new System.Windows.Forms.Padding(2);
            this.tbCorrectorReadState.Name = "tbCorrectorReadState";
            this.tbCorrectorReadState.ShortcutsEnabled = false;
            this.tbCorrectorReadState.Size = new System.Drawing.Size(61, 8);
            this.tbCorrectorReadState.TabIndex = 1011;
            // 
            // tbTxConfigReadState
            // 
            this.tbTxConfigReadState.Enabled = false;
            this.tbTxConfigReadState.Font = new System.Drawing.Font("PMingLiU", 0.1F);
            this.tbTxConfigReadState.Location = new System.Drawing.Point(20, 142);
            this.tbTxConfigReadState.Margin = new System.Windows.Forms.Padding(2);
            this.tbTxConfigReadState.Name = "tbTxConfigReadState";
            this.tbTxConfigReadState.ShortcutsEnabled = false;
            this.tbTxConfigReadState.Size = new System.Drawing.Size(61, 8);
            this.tbTxConfigReadState.TabIndex = 1012;
            // 
            // tbRxConfigReadState
            // 
            this.tbRxConfigReadState.Enabled = false;
            this.tbRxConfigReadState.Font = new System.Drawing.Font("PMingLiU", 0.1F);
            this.tbRxConfigReadState.Location = new System.Drawing.Point(20, 169);
            this.tbRxConfigReadState.Margin = new System.Windows.Forms.Padding(2);
            this.tbRxConfigReadState.Name = "tbRxConfigReadState";
            this.tbRxConfigReadState.ShortcutsEnabled = false;
            this.tbRxConfigReadState.Size = new System.Drawing.Size(61, 8);
            this.tbRxConfigReadState.TabIndex = 1013;
            // 
            // cbInfomation
            // 
            this.cbInfomation.AutoSize = true;
            this.cbInfomation.BackColor = System.Drawing.Color.Transparent;
            this.cbInfomation.Checked = true;
            this.cbInfomation.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbInfomation.Location = new System.Drawing.Point(4, 19);
            this.cbInfomation.Margin = new System.Windows.Forms.Padding(2);
            this.cbInfomation.Name = "cbInfomation";
            this.cbInfomation.Size = new System.Drawing.Size(83, 19);
            this.cbInfomation.TabIndex = 1014;
            this.cbInfomation.Text = "Information";
            this.cbInfomation.UseVisualStyleBackColor = false;
            // 
            // gbGlobalControl
            // 
            this.gbGlobalControl.Controls.Add(this.tbDdmReadState);
            this.gbGlobalControl.Controls.Add(this.tbInformationReadState);
            this.gbGlobalControl.Controls.Add(this.tbMemDumpReadState);
            this.gbGlobalControl.Controls.Add(this.tbCorrectorReadState);
            this.gbGlobalControl.Controls.Add(this.tbRxConfigReadState);
            this.gbGlobalControl.Controls.Add(this.tbTxConfigReadState);
            this.gbGlobalControl.Controls.Add(this.cbRxIcConfig);
            this.gbGlobalControl.Controls.Add(this.cbTxIcConfig);
            this.gbGlobalControl.Controls.Add(this.cbCorrector);
            this.gbGlobalControl.Controls.Add(this.cbMemDump);
            this.gbGlobalControl.Controls.Add(this.cbDdm);
            this.gbGlobalControl.Controls.Add(this.cbInfomation);
            this.gbGlobalControl.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.gbGlobalControl.Location = new System.Drawing.Point(1013, 168);
            this.gbGlobalControl.Margin = new System.Windows.Forms.Padding(2);
            this.gbGlobalControl.Name = "gbGlobalControl";
            this.gbGlobalControl.Padding = new System.Windows.Forms.Padding(2);
            this.gbGlobalControl.Size = new System.Drawing.Size(100, 185);
            this.gbGlobalControl.TabIndex = 1015;
            this.gbGlobalControl.TabStop = false;
            this.gbGlobalControl.Text = "Global control";
            // 
            // cbRxIcConfig
            // 
            this.cbRxIcConfig.AutoSize = true;
            this.cbRxIcConfig.BackColor = System.Drawing.Color.Transparent;
            this.cbRxIcConfig.Location = new System.Drawing.Point(4, 152);
            this.cbRxIcConfig.Margin = new System.Windows.Forms.Padding(2);
            this.cbRxIcConfig.Name = "cbRxIcConfig";
            this.cbRxIcConfig.Size = new System.Drawing.Size(80, 19);
            this.cbRxIcConfig.TabIndex = 1019;
            this.cbRxIcConfig.Text = "RxIcConfig";
            this.cbRxIcConfig.UseVisualStyleBackColor = false;
            // 
            // cbTxIcConfig
            // 
            this.cbTxIcConfig.AutoSize = true;
            this.cbTxIcConfig.BackColor = System.Drawing.Color.Transparent;
            this.cbTxIcConfig.Location = new System.Drawing.Point(4, 126);
            this.cbTxIcConfig.Margin = new System.Windows.Forms.Padding(2);
            this.cbTxIcConfig.Name = "cbTxIcConfig";
            this.cbTxIcConfig.Size = new System.Drawing.Size(80, 19);
            this.cbTxIcConfig.TabIndex = 1018;
            this.cbTxIcConfig.Text = "TxIcConfig";
            this.cbTxIcConfig.UseVisualStyleBackColor = false;
            // 
            // cbCorrector
            // 
            this.cbCorrector.AutoSize = true;
            this.cbCorrector.BackColor = System.Drawing.Color.Transparent;
            this.cbCorrector.Checked = true;
            this.cbCorrector.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCorrector.Location = new System.Drawing.Point(4, 98);
            this.cbCorrector.Margin = new System.Windows.Forms.Padding(2);
            this.cbCorrector.Name = "cbCorrector";
            this.cbCorrector.Size = new System.Drawing.Size(72, 19);
            this.cbCorrector.TabIndex = 1017;
            this.cbCorrector.Text = "Corrector";
            this.cbCorrector.UseVisualStyleBackColor = false;
            // 
            // cbMemDump
            // 
            this.cbMemDump.AutoSize = true;
            this.cbMemDump.BackColor = System.Drawing.Color.Transparent;
            this.cbMemDump.Checked = true;
            this.cbMemDump.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbMemDump.Location = new System.Drawing.Point(4, 72);
            this.cbMemDump.Margin = new System.Windows.Forms.Padding(2);
            this.cbMemDump.Name = "cbMemDump";
            this.cbMemDump.Size = new System.Drawing.Size(83, 19);
            this.cbMemDump.TabIndex = 1016;
            this.cbMemDump.Text = "MemDump";
            this.cbMemDump.UseVisualStyleBackColor = false;
            // 
            // cbDdm
            // 
            this.cbDdm.AutoSize = true;
            this.cbDdm.BackColor = System.Drawing.Color.Transparent;
            this.cbDdm.Checked = true;
            this.cbDdm.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDdm.Location = new System.Drawing.Point(4, 46);
            this.cbDdm.Margin = new System.Windows.Forms.Padding(2);
            this.cbDdm.Name = "cbDdm";
            this.cbDdm.Size = new System.Drawing.Size(56, 19);
            this.cbDdm.TabIndex = 1015;
            this.cbDdm.Text = "DDM";
            this.cbDdm.UseVisualStyleBackColor = false;
            // 
            // bGlobalWrite
            // 
            this.bGlobalWrite.Enabled = false;
            this.bGlobalWrite.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.bGlobalWrite.Location = new System.Drawing.Point(1013, 91);
            this.bGlobalWrite.Margin = new System.Windows.Forms.Padding(2);
            this.bGlobalWrite.Name = "bGlobalWrite";
            this.bGlobalWrite.Size = new System.Drawing.Size(100, 28);
            this.bGlobalWrite.TabIndex = 3;
            this.bGlobalWrite.Text = "Global Write";
            this.bGlobalWrite.UseVisualStyleBackColor = true;
            this.bGlobalWrite.Click += new System.EventHandler(this.bGlobalWrite_Click);
            // 
            // bGlobalWrite2
            // 
            this.bGlobalWrite2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bGlobalWrite2.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.bGlobalWrite2.Location = new System.Drawing.Point(1013, 516);
            this.bGlobalWrite2.Margin = new System.Windows.Forms.Padding(2);
            this.bGlobalWrite2.Name = "bGlobalWrite2";
            this.bGlobalWrite2.Size = new System.Drawing.Size(100, 28);
            this.bGlobalWrite2.TabIndex = 1017;
            this.bGlobalWrite2.Text = "Load CfgFile";
            this.bGlobalWrite2.UseVisualStyleBackColor = false;
            this.bGlobalWrite2.Click += new System.EventHandler(this.bLoadCfgFile_Click);
            // 
            // tbPasswordB3
            // 
            this.tbPasswordB3.Location = new System.Drawing.Point(113, 30);
            this.tbPasswordB3.Name = "tbPasswordB3";
            this.tbPasswordB3.Size = new System.Drawing.Size(30, 22);
            this.tbPasswordB3.TabIndex = 1023;
            this.tbPasswordB3.Text = "34";
            this.tbPasswordB3.UseSystemPasswordChar = true;
            this.tbPasswordB3.Visible = false;
            // 
            // tbPasswordB2
            // 
            this.tbPasswordB2.Location = new System.Drawing.Point(77, 30);
            this.tbPasswordB2.Name = "tbPasswordB2";
            this.tbPasswordB2.Size = new System.Drawing.Size(30, 22);
            this.tbPasswordB2.TabIndex = 1022;
            this.tbPasswordB2.Text = "33";
            this.tbPasswordB2.UseSystemPasswordChar = true;
            this.tbPasswordB2.Visible = false;
            // 
            // tbPasswordB1
            // 
            this.tbPasswordB1.Location = new System.Drawing.Point(41, 30);
            this.tbPasswordB1.Name = "tbPasswordB1";
            this.tbPasswordB1.Size = new System.Drawing.Size(30, 22);
            this.tbPasswordB1.TabIndex = 1021;
            this.tbPasswordB1.Text = "32";
            this.tbPasswordB1.UseSystemPasswordChar = true;
            this.tbPasswordB1.Visible = false;
            // 
            // tbPasswordB0
            // 
            this.tbPasswordB0.Location = new System.Drawing.Point(5, 30);
            this.tbPasswordB0.Name = "tbPasswordB0";
            this.tbPasswordB0.Size = new System.Drawing.Size(30, 22);
            this.tbPasswordB0.TabIndex = 1020;
            this.tbPasswordB0.Text = "33";
            this.tbPasswordB0.UseSystemPasswordChar = true;
            this.tbPasswordB0.Visible = false;
            // 
            // bScanComponents
            // 
            this.bScanComponents.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bScanComponents.Enabled = false;
            this.bScanComponents.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.bScanComponents.Location = new System.Drawing.Point(1013, 762);
            this.bScanComponents.Margin = new System.Windows.Forms.Padding(2);
            this.bScanComponents.Name = "bScanComponents";
            this.bScanComponents.Size = new System.Drawing.Size(119, 28);
            this.bScanComponents.TabIndex = 1024;
            this.bScanComponents.Text = "ScanCom.ToXml";
            this.bScanComponents.UseVisualStyleBackColor = false;
            this.bScanComponents.Visible = false;
            this.bScanComponents.Click += new System.EventHandler(this.bScanComponents_Click);
            // 
            // bStoreIntoFlash
            // 
            this.bStoreIntoFlash.Enabled = false;
            this.bStoreIntoFlash.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.bStoreIntoFlash.Location = new System.Drawing.Point(1013, 123);
            this.bStoreIntoFlash.Margin = new System.Windows.Forms.Padding(2);
            this.bStoreIntoFlash.Name = "bStoreIntoFlash";
            this.bStoreIntoFlash.Size = new System.Drawing.Size(100, 28);
            this.bStoreIntoFlash.TabIndex = 1025;
            this.bStoreIntoFlash.Text = "Store into Fl.";
            this.bStoreIntoFlash.UseVisualStyleBackColor = true;
            this.bStoreIntoFlash.Click += new System.EventHandler(this.bStoreIntoFlash_Click);
            // 
            // bFunctionTest2
            // 
            this.bFunctionTest2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bFunctionTest2.Enabled = false;
            this.bFunctionTest2.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.bFunctionTest2.Location = new System.Drawing.Point(1013, 722);
            this.bFunctionTest2.Margin = new System.Windows.Forms.Padding(2);
            this.bFunctionTest2.Name = "bFunctionTest2";
            this.bFunctionTest2.Size = new System.Drawing.Size(119, 28);
            this.bFunctionTest2.TabIndex = 1027;
            this.bFunctionTest2.Text = "ReData table";
            this.bFunctionTest2.UseVisualStyleBackColor = false;
            this.bFunctionTest2.Visible = false;
            this.bFunctionTest2.Click += new System.EventHandler(this.bReNew_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(1014, 545);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 4);
            this.progressBar1.TabIndex = 1028;
            // 
            // bDumpToString
            // 
            this.bDumpToString.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bDumpToString.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.bDumpToString.Location = new System.Drawing.Point(1013, 486);
            this.bDumpToString.Margin = new System.Windows.Forms.Padding(2);
            this.bDumpToString.Name = "bDumpToString";
            this.bDumpToString.Size = new System.Drawing.Size(100, 28);
            this.bDumpToString.TabIndex = 1029;
            this.bDumpToString.Text = "Save CfgFile";
            this.bDumpToString.UseVisualStyleBackColor = false;
            this.bDumpToString.Click += new System.EventHandler(this.bSaveCfgFile_Click);
            // 
            // gbPermissions
            // 
            this.gbPermissions.Controls.Add(this.cbPermission);
            this.gbPermissions.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.gbPermissions.Location = new System.Drawing.Point(1013, 409);
            this.gbPermissions.Name = "gbPermissions";
            this.gbPermissions.Size = new System.Drawing.Size(100, 45);
            this.gbPermissions.TabIndex = 1031;
            this.gbPermissions.TabStop = false;
            this.gbPermissions.Text = "Permissions";
            // 
            // cbPermission
            // 
            this.cbPermission.AutoCompleteCustomSource.AddRange(new string[] {
            "Admin",
            "Engineer",
            "Operator"});
            this.cbPermission.Enabled = false;
            this.cbPermission.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPermission.FormattingEnabled = true;
            this.cbPermission.Items.AddRange(new object[] {
            "MP Manager",
            "Engineer",
            "Administrator"});
            this.cbPermission.Location = new System.Drawing.Point(5, 20);
            this.cbPermission.Name = "cbPermission";
            this.cbPermission.Size = new System.Drawing.Size(90, 22);
            this.cbPermission.TabIndex = 1020;
            this.cbPermission.Text = "Permission Sel..";
            this.cbPermission.SelectedIndexChanged += new System.EventHandler(this.cbPermission_SelectedIndexChanged);
            // 
            // gbProduct
            // 
            this.gbProduct.Controls.Add(this.cbProductSelect);
            this.gbProduct.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.gbProduct.Location = new System.Drawing.Point(1013, 358);
            this.gbProduct.Name = "gbProduct";
            this.gbProduct.Size = new System.Drawing.Size(100, 45);
            this.gbProduct.TabIndex = 1032;
            this.gbProduct.TabStop = false;
            this.gbProduct.Text = "Product";
            // 
            // cbProductSelect
            // 
            this.cbProductSelect.Enabled = false;
            this.cbProductSelect.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbProductSelect.FormattingEnabled = true;
            this.cbProductSelect.Items.AddRange(new object[] {
            "Products",
            "SAS4.0",
            "PCIe4.0",
            "QSFP28"});
            this.cbProductSelect.Location = new System.Drawing.Point(5, 15);
            this.cbProductSelect.Name = "cbProductSelect";
            this.cbProductSelect.Size = new System.Drawing.Size(90, 22);
            this.cbProductSelect.TabIndex = 5;
            this.cbProductSelect.Text = "Product Sel...";
            this.cbProductSelect.SelectedIndexChanged += new System.EventHandler(this.cbProductSelect_SelectedIndexChanged);
            // 
            // gbGenerateCfg
            // 
            this.gbGenerateCfg.Controls.Add(this.cbDAPath);
            this.gbGenerateCfg.Controls.Add(this.bGenerateCfg);
            this.gbGenerateCfg.Controls.Add(this.rbMpMode);
            this.gbGenerateCfg.Controls.Add(this.rbCustomerMode);
            this.gbGenerateCfg.Controls.Add(this.cbAPPath);
            this.gbGenerateCfg.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.gbGenerateCfg.Location = new System.Drawing.Point(1014, 562);
            this.gbGenerateCfg.Margin = new System.Windows.Forms.Padding(2);
            this.gbGenerateCfg.Name = "gbGenerateCfg";
            this.gbGenerateCfg.Padding = new System.Windows.Forms.Padding(2);
            this.gbGenerateCfg.Size = new System.Drawing.Size(118, 125);
            this.gbGenerateCfg.TabIndex = 1033;
            this.gbGenerateCfg.TabStop = false;
            this.gbGenerateCfg.Text = "Generate Cfg file";
            // 
            // cbDAPath
            // 
            this.cbDAPath.AutoSize = true;
            this.cbDAPath.BackColor = System.Drawing.Color.Transparent;
            this.cbDAPath.Location = new System.Drawing.Point(6, 35);
            this.cbDAPath.Margin = new System.Windows.Forms.Padding(2);
            this.cbDAPath.Name = "cbDAPath";
            this.cbDAPath.Size = new System.Drawing.Size(113, 19);
            this.cbDAPath.TabIndex = 1037;
            this.cbDAPath.Text = "DATAROM Path";
            this.cbDAPath.UseVisualStyleBackColor = false;
            this.cbDAPath.CheckedChanged += new System.EventHandler(this.cbDAPath_CheckedChanged);
            // 
            // bGenerateCfg
            // 
            this.bGenerateCfg.Enabled = false;
            this.bGenerateCfg.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.bGenerateCfg.Location = new System.Drawing.Point(7, 90);
            this.bGenerateCfg.Margin = new System.Windows.Forms.Padding(2);
            this.bGenerateCfg.Name = "bGenerateCfg";
            this.bGenerateCfg.Size = new System.Drawing.Size(84, 28);
            this.bGenerateCfg.TabIndex = 1034;
            this.bGenerateCfg.Text = "Generate";
            this.bGenerateCfg.UseVisualStyleBackColor = true;
            this.bGenerateCfg.Click += new System.EventHandler(this.bGenerateCfg_Click);
            // 
            // rbMpMode
            // 
            this.rbMpMode.AutoSize = true;
            this.rbMpMode.Location = new System.Drawing.Point(6, 70);
            this.rbMpMode.Margin = new System.Windows.Forms.Padding(2);
            this.rbMpMode.Name = "rbMpMode";
            this.rbMpMode.Size = new System.Drawing.Size(73, 19);
            this.rbMpMode.TabIndex = 1036;
            this.rbMpMode.Text = "MP mode";
            this.rbMpMode.UseVisualStyleBackColor = true;
            this.rbMpMode.CheckedChanged += new System.EventHandler(this.rbMpMode_CheckedChanged);
            // 
            // rbCustomerMode
            // 
            this.rbCustomerMode.AutoSize = true;
            this.rbCustomerMode.Checked = true;
            this.rbCustomerMode.Location = new System.Drawing.Point(6, 52);
            this.rbCustomerMode.Margin = new System.Windows.Forms.Padding(2);
            this.rbCustomerMode.Name = "rbCustomerMode";
            this.rbCustomerMode.Size = new System.Drawing.Size(101, 19);
            this.rbCustomerMode.TabIndex = 1035;
            this.rbCustomerMode.TabStop = true;
            this.rbCustomerMode.Text = "Customer mode";
            this.rbCustomerMode.UseVisualStyleBackColor = true;
            this.rbCustomerMode.CheckedChanged += new System.EventHandler(this.rbCustomerMode_CheckedChanged);
            // 
            // cbAPPath
            // 
            this.cbAPPath.AutoSize = true;
            this.cbAPPath.BackColor = System.Drawing.Color.Transparent;
            this.cbAPPath.Location = new System.Drawing.Point(6, 18);
            this.cbAPPath.Margin = new System.Windows.Forms.Padding(2);
            this.cbAPPath.Name = "cbAPPath";
            this.cbAPPath.Size = new System.Drawing.Size(96, 19);
            this.cbAPPath.TabIndex = 1034;
            this.cbAPPath.Text = "APROM Path";
            this.cbAPPath.UseVisualStyleBackColor = false;
            this.cbAPPath.CheckedChanged += new System.EventHandler(this.cbAPPath_CheckedChanged);
            // 
            // bBackToMainForm
            // 
            this.bBackToMainForm.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.bBackToMainForm.Location = new System.Drawing.Point(1013, 800);
            this.bBackToMainForm.Margin = new System.Windows.Forms.Padding(2);
            this.bBackToMainForm.Name = "bBackToMainForm";
            this.bBackToMainForm.Size = new System.Drawing.Size(119, 28);
            this.bBackToMainForm.TabIndex = 1035;
            this.bBackToMainForm.Text = "Back to Main";
            this.bBackToMainForm.UseVisualStyleBackColor = true;
            this.bBackToMainForm.Click += new System.EventHandler(this.bBackToMainForm_Click);
            // 
            // lMessage
            // 
            this.lMessage.AutoSize = true;
            this.lMessage.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lMessage.Location = new System.Drawing.Point(1010, 34);
            this.lMessage.Name = "lMessage";
            this.lMessage.Size = new System.Drawing.Size(16, 15);
            this.lMessage.TabIndex = 1036;
            this.lMessage.Text = "...";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1184, 849);
            this.Controls.Add(this.lMessage);
            this.Controls.Add(this.bBackToMainForm);
            this.Controls.Add(this.gbGenerateCfg);
            this.Controls.Add(this.gbProduct);
            this.Controls.Add(this.gbPermissions);
            this.Controls.Add(this.bDumpToString);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.bFunctionTest2);
            this.Controls.Add(this.bStoreIntoFlash);
            this.Controls.Add(this.bScanComponents);
            this.Controls.Add(this.bGlobalWrite2);
            this.Controls.Add(this.bGlobalWrite);
            this.Controls.Add(this.gbGlobalControl);
            this.Controls.Add(this.gbChannelSwitcher);
            this.Controls.Add(this.bGlobalRead);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.lPassword);
            this.Controls.Add(this.cbConnect);
            this.Controls.Add(this.tcMain);
            this.Controls.Add(this.tbPasswordB3);
            this.Controls.Add(this.tbPasswordB2);
            this.Controls.Add(this.tbPasswordB1);
            this.Controls.Add(this.tbPasswordB0);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Palette = this.kryptonPalette1;
            this.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AOC Integrated Firmware Master ";
            this.tcMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tcDdmi.ResumeLayout(false);
            this.tabPage11.ResumeLayout(false);
            this.tabPage12.ResumeLayout(false);
            this.tabPage13.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tcIcConfig.ResumeLayout(false);
            this.tabPage31.ResumeLayout(false);
            this.tcSas40.ResumeLayout(false);
            this.tabPage311.ResumeLayout(false);
            this.tabPage312.ResumeLayout(false);
            this.tabPage32.ResumeLayout(false);
            this.tcPcie4.ResumeLayout(false);
            this.tabPage321.ResumeLayout(false);
            this.tabPage322.ResumeLayout(false);
            this.tabPage33.ResumeLayout(false);
            this.tcQsfp28.ResumeLayout(false);
            this.tabPage331.ResumeLayout(false);
            this.tabPage332.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.gbWriteConfig.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWriteConfig)).EndInit();
            this.gbChannelSwitcher.ResumeLayout(false);
            this.gbChannelSwitcher.PerformLayout();
            this.gbGlobalControl.ResumeLayout(false);
            this.gbGlobalControl.PerformLayout();
            this.gbPermissions.ResumeLayout(false);
            this.gbProduct.ResumeLayout(false);
            this.gbGenerateCfg.ResumeLayout(false);
            this.gbGenerateCfg.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage11;
        private System.Windows.Forms.TabPage tabPage12;
        private System.Windows.Forms.TabPage tabPage13;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage31;
        private System.Windows.Forms.TabPage tabPage311;
        private System.Windows.Forms.TabPage tabPage312;
        private System.Windows.Forms.TabPage tabPage32;
        private System.Windows.Forms.TabPage tabPage321;
        private System.Windows.Forms.TabPage tabPage322;
        private System.Windows.Forms.TabPage tabPage33;
        private System.Windows.Forms.TabPage tabPage331;
        private System.Windows.Forms.TabPage tabPage332;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabControl tcDdmi;
        private System.Windows.Forms.TabControl tcIcConfig;
        private System.Windows.Forms.TabControl tcSas40;
        private System.Windows.Forms.TabControl tcPcie4;
        private System.Windows.Forms.TabControl tcQsfp28;
        private System.Windows.Forms.Label lPassword;
        protected internal System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.GroupBox gbGlobalControl;
        private System.Windows.Forms.GroupBox gbChannelSwitcher;
        private System.Windows.Forms.TextBox tbInformationReadState;
        private System.Windows.Forms.TextBox tbDdmReadState;
        private System.Windows.Forms.TextBox tbMemDumpReadState;
        private System.Windows.Forms.TextBox tbCorrectorReadState;
        private System.Windows.Forms.TextBox tbTxConfigReadState;
        private System.Windows.Forms.TextBox tbRxConfigReadState;
        private System.Windows.Forms.TextBox tbInnerStateCh2;
        private System.Windows.Forms.TextBox tbInnerStateCh1;
        private System.Windows.Forms.CheckBox cbInfomation;
        private System.Windows.Forms.CheckBox cbDdm;
        private System.Windows.Forms.CheckBox cbMemDump;
        private System.Windows.Forms.CheckBox cbCorrector;
        private System.Windows.Forms.CheckBox cbTxIcConfig;
        private System.Windows.Forms.CheckBox cbRxIcConfig;
        private System.Windows.Forms.ComboBox cbProductSelect;
        private System.Windows.Forms.ComboBox cbPermission;
        private System.Windows.Forms.CheckBox cbContinuousMode;
        private System.Windows.Forms.Button bGlobalRead;
        private System.Windows.Forms.Button bOutterSwitch;
        private System.Windows.Forms.Button bInnerSwitch;
        private System.Windows.Forms.Button bGlobalWrite;
        private System.Windows.Forms.Button bGlobalWrite2;
        private System.Windows.Forms.RadioButton rbCh1;
        private System.Windows.Forms.RadioButton rbCh2;
        private System.Windows.Forms.Label lCh2;
        private System.Windows.Forms.Label lCh1;
        private System.Windows.Forms.Label lContinuousMode;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox cbConnect;
        private ComponentFactory.Krypton.Toolkit.KryptonPalette kryptonPalette1;
        private System.Windows.Forms.TextBox tbPasswordB3;
        private System.Windows.Forms.TextBox tbPasswordB2;
        private System.Windows.Forms.TextBox tbPasswordB1;
        private System.Windows.Forms.TextBox tbPasswordB0;
        private System.Windows.Forms.Button bScanComponents;
        private System.Windows.Forms.Button bStoreIntoFlash;
        private System.Windows.Forms.GroupBox gbWriteConfig;
        private System.Windows.Forms.DataGridView dgvWriteConfig;
        private System.Windows.Forms.Button bFunctionTest2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button bDumpToString;
        private System.Windows.Forms.GroupBox gbPermissions;
        private System.Windows.Forms.GroupBox gbProduct;
        private System.Windows.Forms.GroupBox gbGenerateCfg;
        private System.Windows.Forms.RadioButton rbMpMode;
        private System.Windows.Forms.RadioButton rbCustomerMode;
        public System.Windows.Forms.CheckBox cbAPPath;
        private System.Windows.Forms.Button bGenerateCfg;
        private System.Windows.Forms.Button bBackToMainForm;
        private QsfpDigitalDiagnosticMonitoring.UcInformation ucInformation;
        private QsfpDigitalDiagnosticMonitoring.UCDigitalDiagnosticsMonitoring ucDigitalDiagnosticsMonitoring;
        private QsfpDigitalDiagnosticMonitoring.UCMemoryDump ucMemoryDump;
        private Gn1190Corrector.UcGn1190CorrectorLite ucGn1190Corrector;
        private Mald37045cMata37044c.UcMald37045cConfig ucMald37045cConfig;
        private Mald37045cMata37044c.UcMata37044cConfig ucMata37044cConfig;
        private Rt145Rt146Config.UcRt146Config ucRt146Config;
        private Rt145Rt146Config.UcRt145Config ucRt145Config;
        private Gn2108Gn2109Config.UcGn2108Config ucGn2108Config;
        private Gn2108Gn2109Config.UcGn2109Config ucGn2109Config;
        private NuvotonIcpTool.UcNuvotonIcpTool ucNuvotonIcpTool;
        private System.Windows.Forms.Button bIcpConnect;
        private System.Windows.Forms.CheckBox cbAutoReconnect;
        private System.Windows.Forms.Button bAutoReconnectStateCheck;
        private System.Windows.Forms.CheckBox cbBypassEraseAllCheck;
        private System.Windows.Forms.Button bBypassEraseAllStateCheck;
        public System.Windows.Forms.CheckBox cbDAPath;
        public System.Windows.Forms.Label lMessage;
    }
}

