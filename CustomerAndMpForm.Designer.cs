using System.Windows.Forms;

namespace IntegratedGuiV2
{
    partial class CustomerAndMpForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerAndMpForm));
            this.kryptonPalette1 = new ComponentFactory.Krypton.Toolkit.KryptonPalette(this.components);
            this.bStart = new System.Windows.Forms.Button();
            this.tbFilePath = new System.Windows.Forms.TextBox();
            this.lFilePath = new System.Windows.Forms.Label();
            this.lLogin = new System.Windows.Forms.Label();
            this.cProgressBar1 = new CircularProgressBar.CircularProgressBar();
            this.rbSingle = new System.Windows.Forms.RadioButton();
            this.rbBoth = new System.Windows.Forms.RadioButton();
            this.cProgressBar2 = new CircularProgressBar.CircularProgressBar();
            this.lCh1Message = new System.Windows.Forms.Label();
            this.lCh2Message = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lCh1EC = new System.Windows.Forms.Label();
            this.lCh2EC = new System.Windows.Forms.Label();
            this.lProduct = new System.Windows.Forms.Label();
            this.lMode = new System.Windows.Forms.Label();
            this.lModeT = new System.Windows.Forms.Label();
            this.lProductT = new System.Windows.Forms.Label();
            this.lPathAP = new System.Windows.Forms.Label();
            this.lApName = new System.Windows.Forms.Label();
            this.cbBypassW = new System.Windows.Forms.CheckBox();
            this.cbI2cConnect = new System.Windows.Forms.CheckBox();
            this.gbOperatorMode = new System.Windows.Forms.GroupBox();
            this.cbNgInterrupt = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbRssiCriteria = new System.Windows.Forms.TextBox();
            this.cbRelinkCheck = new System.Windows.Forms.CheckBox();
            this.rbLogFileMode = new System.Windows.Forms.RadioButton();
            this.bRenewRssi = new System.Windows.Forms.Button();
            this.rbOnlySN = new System.Windows.Forms.RadioButton();
            this.rbFullMode = new System.Windows.Forms.RadioButton();
            this.cbEngineerMode = new System.Windows.Forms.CheckBox();
            this.cbBarcodeMode = new System.Windows.Forms.CheckBox();
            this.gbCodeEditor = new System.Windows.Forms.GroupBox();
            this.cbSnNamingRule = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.dudYy = new System.Windows.Forms.DomainUpDown();
            this.dudMm = new System.Windows.Forms.DomainUpDown();
            this.dudDd = new System.Windows.Forms.DomainUpDown();
            this.dudRr = new System.Windows.Forms.DomainUpDown();
            this.dudSsss = new System.Windows.Forms.DomainUpDown();
            this.dudWw = new System.Windows.Forms.DomainUpDown();
            this.dudD = new System.Windows.Forms.DomainUpDown();
            this.dudL = new System.Windows.Forms.DomainUpDown();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lMm = new System.Windows.Forms.Label();
            this.lDd = new System.Windows.Forms.Label();
            this.lRr = new System.Windows.Forms.Label();
            this.lSsss = new System.Windows.Forms.Label();
            this.lWw = new System.Windows.Forms.Label();
            this.lD = new System.Windows.Forms.Label();
            this.lL = new System.Windows.Forms.Label();
            this.lRssiCh2_3 = new System.Windows.Forms.Label();
            this.lRssiCh2_2 = new System.Windows.Forms.Label();
            this.lRssiCh2_1 = new System.Windows.Forms.Label();
            this.lRssiCh2_0 = new System.Windows.Forms.Label();
            this.tbRssiCh2_3 = new System.Windows.Forms.TextBox();
            this.tbRssiCh2_2 = new System.Windows.Forms.TextBox();
            this.tbRssiCh2_1 = new System.Windows.Forms.TextBox();
            this.tbRssiCh2_0 = new System.Windows.Forms.TextBox();
            this.tbLogFilePath = new System.Windows.Forms.TextBox();
            this.lRssiCh1_3 = new System.Windows.Forms.Label();
            this.lLogFilePath = new System.Windows.Forms.Label();
            this.bWriteSnDateCone = new System.Windows.Forms.Button();
            this.lRssiCh1_2 = new System.Windows.Forms.Label();
            this.lRssiCh1_1 = new System.Windows.Forms.Label();
            this.tbRssiCh1_3 = new System.Windows.Forms.TextBox();
            this.tbRssiCh1_2 = new System.Windows.Forms.TextBox();
            this.tbRssiCh1_1 = new System.Windows.Forms.TextBox();
            this.lVenderSn = new System.Windows.Forms.Label();
            this.tbRssiCh1_0 = new System.Windows.Forms.TextBox();
            this.tbVenderSn = new System.Windows.Forms.TextBox();
            this.lRssiCh1_0 = new System.Windows.Forms.Label();
            this.lDateCode = new System.Windows.Forms.Label();
            this.tbDateCode = new System.Windows.Forms.TextBox();
            this.bRelinkTest = new System.Windows.Forms.Button();
            this.tbRelinkCount = new System.Windows.Forms.TextBox();
            this.tbIntervalTime = new System.Windows.Forms.TextBox();
            this.bLogFileComparison = new System.Windows.Forms.Button();
            this.bCfgFileComparison = new System.Windows.Forms.Button();
            this.lDataName = new System.Windows.Forms.Label();
            this.lPathData = new System.Windows.Forms.Label();
            this.tbVersionCodeCh1 = new System.Windows.Forms.TextBox();
            this.tbVersionCodeReNewCh1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbVersionCodeReNewCh2 = new System.Windows.Forms.TextBox();
            this.tbVersionCodeCh2 = new System.Windows.Forms.TextBox();
            this.cbSecurityLock = new System.Windows.Forms.CheckBox();
            this.bWriteFromFile = new System.Windows.Forms.Button();
            this.tbOrignalSNCh1 = new System.Windows.Forms.TextBox();
            this.tbReNewSnCh1 = new System.Windows.Forms.TextBox();
            this.lOriginalSN = new System.Windows.Forms.Label();
            this.lReNewSn = new System.Windows.Forms.Label();
            this.tbReNewSnCh2 = new System.Windows.Forms.TextBox();
            this.tbOrignalSNCh2 = new System.Windows.Forms.TextBox();
            this.gbPrompt = new System.Windows.Forms.GroupBox();
            this.lStatus = new System.Windows.Forms.Label();
            this.tbStartTime = new System.Windows.Forms.TextBox();
            this.lMm2 = new System.Windows.Forms.Label();
            this.lDd2 = new System.Windows.Forms.Label();
            this.dudMm2 = new System.Windows.Forms.DomainUpDown();
            this.dudDd2 = new System.Windows.Forms.DomainUpDown();
            this.lYy = new System.Windows.Forms.Label();
            this.gbOperatorMode.SuspendLayout();
            this.gbCodeEditor.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.gbPrompt.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPalette1
            // 
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(145)))), ((int)(((byte)(168)))));
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(145)))), ((int)(((byte)(168)))));
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Border.Color1 = System.Drawing.Color.DimGray;
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Border.Color2 = System.Drawing.Color.DimGray;
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.None;
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Border.Rounding = 15;
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(72)))), ((int)(((byte)(91)))));
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(145)))), ((int)(((byte)(168)))));
            // 
            // bStart
            // 
            this.bStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(115)))), ((int)(((byte)(138)))));
            this.bStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bStart.FlatAppearance.BorderSize = 0;
            this.bStart.Font = new System.Drawing.Font("Nirmala UI", 16F, System.Drawing.FontStyle.Bold);
            this.bStart.ForeColor = System.Drawing.Color.White;
            this.bStart.Location = new System.Drawing.Point(20, 73);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(76, 53);
            this.bStart.TabIndex = 44;
            this.bStart.Text = "Start";
            this.bStart.UseVisualStyleBackColor = false;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // tbFilePath
            // 
            this.tbFilePath.BackColor = System.Drawing.Color.White;
            this.tbFilePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbFilePath.Font = new System.Drawing.Font("Nirmala UI", 10F);
            this.tbFilePath.ForeColor = System.Drawing.Color.Silver;
            this.tbFilePath.Location = new System.Drawing.Point(20, 47);
            this.tbFilePath.Name = "tbFilePath";
            this.tbFilePath.Size = new System.Drawing.Size(289, 25);
            this.tbFilePath.TabIndex = 43;
            this.tbFilePath.Text = "Please click here, to import the Config file...";
            this.tbFilePath.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tbFilePath_MouseClick);
            this.tbFilePath.Enter += new System.EventHandler(this.tbFilePath_Leave);
            this.tbFilePath.Leave += new System.EventHandler(this.tbFilePath_Leave);
            // 
            // lFilePath
            // 
            this.lFilePath.AutoSize = true;
            this.lFilePath.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lFilePath.ForeColor = System.Drawing.Color.White;
            this.lFilePath.Location = new System.Drawing.Point(16, 27);
            this.lFilePath.Name = "lFilePath";
            this.lFilePath.Size = new System.Drawing.Size(118, 19);
            this.lFilePath.TabIndex = 42;
            this.lFilePath.Text = "Config File path:";
            // 
            // lLogin
            // 
            this.lLogin.AutoSize = true;
            this.lLogin.Font = new System.Drawing.Font("Nirmala UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(72)))), ((int)(((byte)(91)))));
            this.lLogin.Location = new System.Drawing.Point(15, -4);
            this.lLogin.Name = "lLogin";
            this.lLogin.Size = new System.Drawing.Size(292, 30);
            this.lLogin.TabIndex = 41;
            this.lLogin.Text = "OptiSync Firmware Manager";
            // 
            // cProgressBar1
            // 
            this.cProgressBar1.AnimationFunction = ((WinFormAnimation.AnimationFunctions.Function)(resources.GetObject("cProgressBar1.AnimationFunction")));
            this.cProgressBar1.AnimationSpeed = 500;
            this.cProgressBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(145)))), ((int)(((byte)(168)))));
            this.cProgressBar1.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Bold);
            this.cProgressBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(213)))), ((int)(((byte)(219)))));
            this.cProgressBar1.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.cProgressBar1.InnerMargin = 2;
            this.cProgressBar1.InnerWidth = -1;
            this.cProgressBar1.Location = new System.Drawing.Point(323, 21);
            this.cProgressBar1.MarqueeAnimationSpeed = 2000;
            this.cProgressBar1.Name = "cProgressBar1";
            this.cProgressBar1.OuterColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(26)))), ((int)(((byte)(43)))));
            this.cProgressBar1.OuterMargin = -25;
            this.cProgressBar1.OuterWidth = 26;
            this.cProgressBar1.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(213)))), ((int)(((byte)(219)))));
            this.cProgressBar1.ProgressWidth = 3;
            this.cProgressBar1.SecondaryFont = new System.Drawing.Font("PMingLiU", 36F);
            this.cProgressBar1.Size = new System.Drawing.Size(100, 100);
            this.cProgressBar1.StartAngle = 270;
            this.cProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.cProgressBar1.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.cProgressBar1.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.cProgressBar1.SubscriptText = "";
            this.cProgressBar1.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.cProgressBar1.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.cProgressBar1.SuperscriptText = "";
            this.cProgressBar1.TabIndex = 48;
            this.cProgressBar1.Text = "Ch1";
            this.cProgressBar1.TextMargin = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.cProgressBar1.Value = 68;
            // 
            // rbSingle
            // 
            this.rbSingle.AutoSize = true;
            this.rbSingle.Checked = true;
            this.rbSingle.ForeColor = System.Drawing.Color.MidnightBlue;
            this.rbSingle.Location = new System.Drawing.Point(102, 76);
            this.rbSingle.Name = "rbSingle";
            this.rbSingle.Size = new System.Drawing.Size(68, 23);
            this.rbSingle.TabIndex = 49;
            this.rbSingle.TabStop = true;
            this.rbSingle.Text = "Single";
            this.rbSingle.UseVisualStyleBackColor = true;
            this.rbSingle.CheckedChanged += new System.EventHandler(this.raSingle_CheckedChanged);
            // 
            // rbBoth
            // 
            this.rbBoth.AutoSize = true;
            this.rbBoth.ForeColor = System.Drawing.Color.MidnightBlue;
            this.rbBoth.Location = new System.Drawing.Point(102, 99);
            this.rbBoth.Name = "rbBoth";
            this.rbBoth.Size = new System.Drawing.Size(89, 23);
            this.rbBoth.TabIndex = 50;
            this.rbBoth.Text = "Both side";
            this.rbBoth.UseVisualStyleBackColor = true;
            this.rbBoth.CheckedChanged += new System.EventHandler(this.rbBoth_CheckedChanged);
            // 
            // cProgressBar2
            // 
            this.cProgressBar2.AnimationFunction = ((WinFormAnimation.AnimationFunctions.Function)(resources.GetObject("cProgressBar2.AnimationFunction")));
            this.cProgressBar2.AnimationSpeed = 500;
            this.cProgressBar2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(145)))), ((int)(((byte)(168)))));
            this.cProgressBar2.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Bold);
            this.cProgressBar2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(213)))), ((int)(((byte)(219)))));
            this.cProgressBar2.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.cProgressBar2.InnerMargin = 2;
            this.cProgressBar2.InnerWidth = -1;
            this.cProgressBar2.Location = new System.Drawing.Point(429, 21);
            this.cProgressBar2.MarqueeAnimationSpeed = 2000;
            this.cProgressBar2.Name = "cProgressBar2";
            this.cProgressBar2.OuterColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(26)))), ((int)(((byte)(43)))));
            this.cProgressBar2.OuterMargin = -25;
            this.cProgressBar2.OuterWidth = 26;
            this.cProgressBar2.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(213)))), ((int)(((byte)(219)))));
            this.cProgressBar2.ProgressWidth = 3;
            this.cProgressBar2.SecondaryFont = new System.Drawing.Font("PMingLiU", 36F);
            this.cProgressBar2.Size = new System.Drawing.Size(100, 100);
            this.cProgressBar2.StartAngle = 270;
            this.cProgressBar2.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.cProgressBar2.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.cProgressBar2.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.cProgressBar2.SubscriptText = "";
            this.cProgressBar2.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.cProgressBar2.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.cProgressBar2.SuperscriptText = "";
            this.cProgressBar2.TabIndex = 51;
            this.cProgressBar2.Text = "Ch2";
            this.cProgressBar2.TextMargin = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.cProgressBar2.Value = 68;
            this.cProgressBar2.Visible = false;
            // 
            // lCh1Message
            // 
            this.lCh1Message.AutoSize = true;
            this.lCh1Message.Font = new System.Drawing.Font("Nirmala UI", 7F, System.Drawing.FontStyle.Bold);
            this.lCh1Message.ForeColor = System.Drawing.Color.White;
            this.lCh1Message.Location = new System.Drawing.Point(328, 120);
            this.lCh1Message.Name = "lCh1Message";
            this.lCh1Message.Size = new System.Drawing.Size(14, 12);
            this.lCh1Message.TabIndex = 52;
            this.lCh1Message.Text = "...";
            // 
            // lCh2Message
            // 
            this.lCh2Message.AutoSize = true;
            this.lCh2Message.Font = new System.Drawing.Font("Nirmala UI", 7F, System.Drawing.FontStyle.Bold);
            this.lCh2Message.ForeColor = System.Drawing.Color.White;
            this.lCh2Message.Location = new System.Drawing.Point(434, 120);
            this.lCh2Message.Name = "lCh2Message";
            this.lCh2Message.Size = new System.Drawing.Size(14, 12);
            this.lCh2Message.TabIndex = 53;
            this.lCh2Message.Text = "...";
            this.lCh2Message.Visible = false;
            // 
            // lCh1EC
            // 
            this.lCh1EC.AutoSize = true;
            this.lCh1EC.BackColor = System.Drawing.Color.Transparent;
            this.lCh1EC.Font = new System.Drawing.Font("Nirmala UI", 5F, System.Drawing.FontStyle.Bold);
            this.lCh1EC.ForeColor = System.Drawing.Color.White;
            this.lCh1EC.Location = new System.Drawing.Point(397, 19);
            this.lCh1EC.Name = "lCh1EC";
            this.lCh1EC.Size = new System.Drawing.Size(11, 10);
            this.lCh1EC.TabIndex = 54;
            this.lCh1EC.Text = "...";
            this.lCh1EC.Visible = false;
            // 
            // lCh2EC
            // 
            this.lCh2EC.AutoSize = true;
            this.lCh2EC.BackColor = System.Drawing.Color.Transparent;
            this.lCh2EC.Font = new System.Drawing.Font("Nirmala UI", 5F, System.Drawing.FontStyle.Bold);
            this.lCh2EC.ForeColor = System.Drawing.Color.White;
            this.lCh2EC.Location = new System.Drawing.Point(504, 19);
            this.lCh2EC.Name = "lCh2EC";
            this.lCh2EC.Size = new System.Drawing.Size(11, 10);
            this.lCh2EC.TabIndex = 55;
            this.lCh2EC.Text = "...";
            this.lCh2EC.Visible = false;
            // 
            // lProduct
            // 
            this.lProduct.AutoSize = true;
            this.lProduct.Font = new System.Drawing.Font("Nirmala UI", 8F, System.Drawing.FontStyle.Bold);
            this.lProduct.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lProduct.Location = new System.Drawing.Point(74, 180);
            this.lProduct.Name = "lProduct";
            this.lProduct.Size = new System.Drawing.Size(12, 13);
            this.lProduct.TabIndex = 56;
            this.lProduct.Text = "_";
            // 
            // lMode
            // 
            this.lMode.AutoSize = true;
            this.lMode.Font = new System.Drawing.Font("Nirmala UI", 8F, System.Drawing.FontStyle.Bold);
            this.lMode.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lMode.Location = new System.Drawing.Point(65, 195);
            this.lMode.Name = "lMode";
            this.lMode.Size = new System.Drawing.Size(12, 13);
            this.lMode.TabIndex = 57;
            this.lMode.Text = "_";
            // 
            // lModeT
            // 
            this.lModeT.AutoSize = true;
            this.lModeT.Font = new System.Drawing.Font("Nirmala UI", 8F, System.Drawing.FontStyle.Bold);
            this.lModeT.ForeColor = System.Drawing.Color.White;
            this.lModeT.Location = new System.Drawing.Point(21, 195);
            this.lModeT.Name = "lModeT";
            this.lModeT.Size = new System.Drawing.Size(41, 13);
            this.lModeT.TabIndex = 59;
            this.lModeT.Text = "Mode:";
            // 
            // lProductT
            // 
            this.lProductT.AutoSize = true;
            this.lProductT.Font = new System.Drawing.Font("Nirmala UI", 8F, System.Drawing.FontStyle.Bold);
            this.lProductT.ForeColor = System.Drawing.Color.White;
            this.lProductT.Location = new System.Drawing.Point(21, 180);
            this.lProductT.Name = "lProductT";
            this.lProductT.Size = new System.Drawing.Size(51, 13);
            this.lProductT.TabIndex = 58;
            this.lProductT.Text = "Product:";
            // 
            // lPathAP
            // 
            this.lPathAP.AutoSize = true;
            this.lPathAP.Font = new System.Drawing.Font("Nirmala UI", 8F, System.Drawing.FontStyle.Bold);
            this.lPathAP.ForeColor = System.Drawing.Color.White;
            this.lPathAP.Location = new System.Drawing.Point(21, 210);
            this.lPathAP.Name = "lPathAP";
            this.lPathAP.Size = new System.Drawing.Size(51, 13);
            this.lPathAP.TabIndex = 60;
            this.lPathAP.Text = "APROM:";
            // 
            // lApName
            // 
            this.lApName.AutoSize = true;
            this.lApName.Font = new System.Drawing.Font("Nirmala UI", 6F, System.Drawing.FontStyle.Bold);
            this.lApName.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lApName.Location = new System.Drawing.Point(76, 212);
            this.lApName.Name = "lApName";
            this.lApName.Size = new System.Drawing.Size(8, 11);
            this.lApName.TabIndex = 61;
            this.lApName.Text = "_";
            // 
            // cbBypassW
            // 
            this.cbBypassW.AutoSize = true;
            this.cbBypassW.Checked = true;
            this.cbBypassW.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbBypassW.Font = new System.Drawing.Font("Nirmala UI", 6F, System.Drawing.FontStyle.Bold);
            this.cbBypassW.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(72)))), ((int)(((byte)(91)))));
            this.cbBypassW.Location = new System.Drawing.Point(110, 151);
            this.cbBypassW.Name = "cbBypassW";
            this.cbBypassW.Size = new System.Drawing.Size(102, 15);
            this.cbBypassW.TabIndex = 62;
            this.cbBypassW.Text = "BypassIcConfigWrite";
            this.cbBypassW.UseVisualStyleBackColor = true;
            this.cbBypassW.Visible = false;
            // 
            // cbI2cConnect
            // 
            this.cbI2cConnect.AutoSize = true;
            this.cbI2cConnect.Checked = true;
            this.cbI2cConnect.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbI2cConnect.Font = new System.Drawing.Font("Nirmala UI", 6F, System.Drawing.FontStyle.Bold);
            this.cbI2cConnect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(72)))), ((int)(((byte)(91)))));
            this.cbI2cConnect.Location = new System.Drawing.Point(469, 0);
            this.cbI2cConnect.Name = "cbI2cConnect";
            this.cbI2cConnect.Size = new System.Drawing.Size(65, 15);
            this.cbI2cConnect.TabIndex = 63;
            this.cbI2cConnect.Text = "ChConnect";
            this.cbI2cConnect.UseVisualStyleBackColor = true;
            this.cbI2cConnect.CheckedChanged += new System.EventHandler(this.I2cMasterConnect_CheckedChanged);
            // 
            // gbOperatorMode
            // 
            this.gbOperatorMode.Controls.Add(this.cbNgInterrupt);
            this.gbOperatorMode.Controls.Add(this.label6);
            this.gbOperatorMode.Controls.Add(this.tbRssiCriteria);
            this.gbOperatorMode.Controls.Add(this.cbRelinkCheck);
            this.gbOperatorMode.Controls.Add(this.rbLogFileMode);
            this.gbOperatorMode.Controls.Add(this.bRenewRssi);
            this.gbOperatorMode.Controls.Add(this.rbOnlySN);
            this.gbOperatorMode.Controls.Add(this.rbFullMode);
            this.gbOperatorMode.Controls.Add(this.cbEngineerMode);
            this.gbOperatorMode.Controls.Add(this.cbBarcodeMode);
            this.gbOperatorMode.Controls.Add(this.gbCodeEditor);
            this.gbOperatorMode.Controls.Add(this.lRssiCh2_3);
            this.gbOperatorMode.Controls.Add(this.lRssiCh2_2);
            this.gbOperatorMode.Controls.Add(this.lRssiCh2_1);
            this.gbOperatorMode.Controls.Add(this.lRssiCh2_0);
            this.gbOperatorMode.Controls.Add(this.tbRssiCh2_3);
            this.gbOperatorMode.Controls.Add(this.tbRssiCh2_2);
            this.gbOperatorMode.Controls.Add(this.tbRssiCh2_1);
            this.gbOperatorMode.Controls.Add(this.tbRssiCh2_0);
            this.gbOperatorMode.Controls.Add(this.tbLogFilePath);
            this.gbOperatorMode.Controls.Add(this.lRssiCh1_3);
            this.gbOperatorMode.Controls.Add(this.lLogFilePath);
            this.gbOperatorMode.Controls.Add(this.bWriteSnDateCone);
            this.gbOperatorMode.Controls.Add(this.lRssiCh1_2);
            this.gbOperatorMode.Controls.Add(this.lRssiCh1_1);
            this.gbOperatorMode.Controls.Add(this.cbBypassW);
            this.gbOperatorMode.Controls.Add(this.tbRssiCh1_3);
            this.gbOperatorMode.Controls.Add(this.tbRssiCh1_2);
            this.gbOperatorMode.Controls.Add(this.tbRssiCh1_1);
            this.gbOperatorMode.Controls.Add(this.lVenderSn);
            this.gbOperatorMode.Controls.Add(this.tbRssiCh1_0);
            this.gbOperatorMode.Controls.Add(this.tbVenderSn);
            this.gbOperatorMode.Controls.Add(this.lRssiCh1_0);
            this.gbOperatorMode.Controls.Add(this.lDateCode);
            this.gbOperatorMode.Controls.Add(this.tbDateCode);
            this.gbOperatorMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(72)))), ((int)(((byte)(91)))));
            this.gbOperatorMode.Location = new System.Drawing.Point(23, 240);
            this.gbOperatorMode.Name = "gbOperatorMode";
            this.gbOperatorMode.Size = new System.Drawing.Size(506, 203);
            this.gbOperatorMode.TabIndex = 70;
            this.gbOperatorMode.TabStop = false;
            this.gbOperatorMode.Text = "MP information";
            this.gbOperatorMode.Visible = false;
            // 
            // cbNgInterrupt
            // 
            this.cbNgInterrupt.AutoSize = true;
            this.cbNgInterrupt.Font = new System.Drawing.Font("Nirmala UI", 6F, System.Drawing.FontStyle.Bold);
            this.cbNgInterrupt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(72)))), ((int)(((byte)(91)))));
            this.cbNgInterrupt.Location = new System.Drawing.Point(199, 49);
            this.cbNgInterrupt.Name = "cbNgInterrupt";
            this.cbNgInterrupt.Size = new System.Drawing.Size(72, 15);
            this.cbNgInterrupt.TabIndex = 109;
            this.cbNgInterrupt.Text = "NG Interrupt";
            this.cbNgInterrupt.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Nirmala UI", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(199, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 11);
            this.label6.TabIndex = 108;
            this.label6.Text = "Criteria";
            // 
            // tbRssiCriteria
            // 
            this.tbRssiCriteria.Font = new System.Drawing.Font("Nirmala UI", 6F);
            this.tbRssiCriteria.ForeColor = System.Drawing.Color.MidnightBlue;
            this.tbRssiCriteria.Location = new System.Drawing.Point(199, 25);
            this.tbRssiCriteria.Name = "tbRssiCriteria";
            this.tbRssiCriteria.Size = new System.Drawing.Size(32, 18);
            this.tbRssiCriteria.TabIndex = 107;
            this.tbRssiCriteria.Text = "250";
            this.tbRssiCriteria.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbRelinkCheck
            // 
            this.cbRelinkCheck.AutoSize = true;
            this.cbRelinkCheck.Font = new System.Drawing.Font("Nirmala UI", 6F, System.Drawing.FontStyle.Bold);
            this.cbRelinkCheck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(72)))), ((int)(((byte)(91)))));
            this.cbRelinkCheck.Location = new System.Drawing.Point(240, 179);
            this.cbRelinkCheck.Name = "cbRelinkCheck";
            this.cbRelinkCheck.Size = new System.Drawing.Size(64, 15);
            this.cbRelinkCheck.TabIndex = 106;
            this.cbRelinkCheck.Text = "TimeCheck";
            this.cbRelinkCheck.UseVisualStyleBackColor = true;
            this.cbRelinkCheck.Visible = false;
            this.cbRelinkCheck.CheckedChanged += new System.EventHandler(this.cbRelinkCheck_CheckedChanged);
            // 
            // rbLogFileMode
            // 
            this.rbLogFileMode.AutoSize = true;
            this.rbLogFileMode.Font = new System.Drawing.Font("Nirmala UI", 6F, System.Drawing.FontStyle.Bold);
            this.rbLogFileMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(72)))), ((int)(((byte)(91)))));
            this.rbLogFileMode.Location = new System.Drawing.Point(408, 182);
            this.rbLogFileMode.Name = "rbLogFileMode";
            this.rbLogFileMode.Size = new System.Drawing.Size(89, 15);
            this.rbLogFileMode.TabIndex = 101;
            this.rbLogFileMode.Text = "LogFileCom mode";
            this.rbLogFileMode.UseVisualStyleBackColor = true;
            this.rbLogFileMode.Visible = false;
            this.rbLogFileMode.CheckedChanged += new System.EventHandler(this.BarcodeMode_CheckedChanged);
            // 
            // bRenewRssi
            // 
            this.bRenewRssi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(115)))), ((int)(((byte)(138)))));
            this.bRenewRssi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bRenewRssi.FlatAppearance.BorderSize = 0;
            this.bRenewRssi.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bRenewRssi.ForeColor = System.Drawing.Color.White;
            this.bRenewRssi.Location = new System.Drawing.Point(99, 21);
            this.bRenewRssi.Name = "bRenewRssi";
            this.bRenewRssi.Size = new System.Drawing.Size(90, 52);
            this.bRenewRssi.TabIndex = 89;
            this.bRenewRssi.Text = "ReRSSI";
            this.bRenewRssi.UseVisualStyleBackColor = false;
            this.bRenewRssi.Click += new System.EventHandler(this.ReRssi_Click);
            // 
            // rbOnlySN
            // 
            this.rbOnlySN.AutoSize = true;
            this.rbOnlySN.Font = new System.Drawing.Font("Nirmala UI", 6F, System.Drawing.FontStyle.Bold);
            this.rbOnlySN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(72)))), ((int)(((byte)(91)))));
            this.rbOnlySN.Location = new System.Drawing.Point(408, 167);
            this.rbOnlySN.Name = "rbOnlySN";
            this.rbOnlySN.Size = new System.Drawing.Size(74, 15);
            this.rbOnlySN.TabIndex = 99;
            this.rbOnlySN.Text = "Only Write SN";
            this.rbOnlySN.UseVisualStyleBackColor = true;
            this.rbOnlySN.Visible = false;
            this.rbOnlySN.CheckedChanged += new System.EventHandler(this.BarcodeMode_CheckedChanged);
            // 
            // rbFullMode
            // 
            this.rbFullMode.AutoSize = true;
            this.rbFullMode.Checked = true;
            this.rbFullMode.Font = new System.Drawing.Font("Nirmala UI", 6F, System.Drawing.FontStyle.Bold);
            this.rbFullMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(72)))), ((int)(((byte)(91)))));
            this.rbFullMode.Location = new System.Drawing.Point(408, 153);
            this.rbFullMode.Name = "rbFullMode";
            this.rbFullMode.Size = new System.Drawing.Size(59, 15);
            this.rbFullMode.TabIndex = 98;
            this.rbFullMode.TabStop = true;
            this.rbFullMode.Text = "Full mode";
            this.rbFullMode.UseVisualStyleBackColor = true;
            this.rbFullMode.Visible = false;
            this.rbFullMode.CheckedChanged += new System.EventHandler(this.BarcodeMode_CheckedChanged);
            // 
            // cbEngineerMode
            // 
            this.cbEngineerMode.AutoSize = true;
            this.cbEngineerMode.Font = new System.Drawing.Font("Nirmala UI", 6F, System.Drawing.FontStyle.Bold);
            this.cbEngineerMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(72)))), ((int)(((byte)(91)))));
            this.cbEngineerMode.Location = new System.Drawing.Point(309, 179);
            this.cbEngineerMode.Name = "cbEngineerMode";
            this.cbEngineerMode.Size = new System.Drawing.Size(90, 15);
            this.cbEngineerMode.TabIndex = 95;
            this.cbEngineerMode.Text = "Register map view";
            this.cbEngineerMode.UseVisualStyleBackColor = true;
            this.cbEngineerMode.CheckedChanged += new System.EventHandler(this.BarcodeMode_CheckedChanged);
            // 
            // cbBarcodeMode
            // 
            this.cbBarcodeMode.AutoSize = true;
            this.cbBarcodeMode.Font = new System.Drawing.Font("Nirmala UI", 6F, System.Drawing.FontStyle.Bold);
            this.cbBarcodeMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(72)))), ((int)(((byte)(91)))));
            this.cbBarcodeMode.Location = new System.Drawing.Point(309, 154);
            this.cbBarcodeMode.Name = "cbBarcodeMode";
            this.cbBarcodeMode.Size = new System.Drawing.Size(77, 15);
            this.cbBarcodeMode.TabIndex = 94;
            this.cbBarcodeMode.Text = "Barcode mode";
            this.cbBarcodeMode.UseVisualStyleBackColor = true;
            this.cbBarcodeMode.CheckedChanged += new System.EventHandler(this.cbBarcodeMode_CheckedChanged);
            // 
            // gbCodeEditor
            // 
            this.gbCodeEditor.Controls.Add(this.dudDd2);
            this.gbCodeEditor.Controls.Add(this.dudMm2);
            this.gbCodeEditor.Controls.Add(this.lDd2);
            this.gbCodeEditor.Controls.Add(this.lMm2);
            this.gbCodeEditor.Controls.Add(this.cbSnNamingRule);
            this.gbCodeEditor.Controls.Add(this.flowLayoutPanel2);
            this.gbCodeEditor.Controls.Add(this.flowLayoutPanel1);
            this.gbCodeEditor.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.gbCodeEditor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(72)))), ((int)(((byte)(91)))));
            this.gbCodeEditor.Location = new System.Drawing.Point(245, 61);
            this.gbCodeEditor.Name = "gbCodeEditor";
            this.gbCodeEditor.Size = new System.Drawing.Size(256, 89);
            this.gbCodeEditor.TabIndex = 93;
            this.gbCodeEditor.TabStop = false;
            this.gbCodeEditor.Text = "Code Editor";
            // 
            // cbSnNamingRule
            // 
            this.cbSnNamingRule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSnNamingRule.FormattingEnabled = true;
            this.cbSnNamingRule.Location = new System.Drawing.Point(5, 15);
            this.cbSnNamingRule.Name = "cbSnNamingRule";
            this.cbSnNamingRule.Size = new System.Drawing.Size(152, 21);
            this.cbSnNamingRule.TabIndex = 108;
            this.cbSnNamingRule.SelectedIndexChanged += new System.EventHandler(this.cbSnNamingRule_SelectedIndexChanged);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.Controls.Add(this.dudYy);
            this.flowLayoutPanel2.Controls.Add(this.dudMm);
            this.flowLayoutPanel2.Controls.Add(this.dudDd);
            this.flowLayoutPanel2.Controls.Add(this.dudRr);
            this.flowLayoutPanel2.Controls.Add(this.dudSsss);
            this.flowLayoutPanel2.Controls.Add(this.dudWw);
            this.flowLayoutPanel2.Controls.Add(this.dudD);
            this.flowLayoutPanel2.Controls.Add(this.dudL);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 58);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(250, 28);
            this.flowLayoutPanel2.TabIndex = 107;
            this.flowLayoutPanel2.WrapContents = false;
            // 
            // dudYy
            // 
            this.dudYy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(72)))), ((int)(((byte)(91)))));
            this.dudYy.Location = new System.Drawing.Point(3, 3);
            this.dudYy.Name = "dudYy";
            this.dudYy.Size = new System.Drawing.Size(40, 22);
            this.dudYy.TabIndex = 100;
            this.dudYy.TextChanged += new System.EventHandler(this.domainUpDown_TextChanged);
            // 
            // dudMm
            // 
            this.dudMm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(72)))), ((int)(((byte)(91)))));
            this.dudMm.Location = new System.Drawing.Point(49, 3);
            this.dudMm.Name = "dudMm";
            this.dudMm.Size = new System.Drawing.Size(40, 22);
            this.dudMm.TabIndex = 101;
            this.dudMm.TextChanged += new System.EventHandler(this.domainUpDown_TextChanged);
            // 
            // dudDd
            // 
            this.dudDd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(72)))), ((int)(((byte)(91)))));
            this.dudDd.Location = new System.Drawing.Point(95, 3);
            this.dudDd.Name = "dudDd";
            this.dudDd.Size = new System.Drawing.Size(40, 22);
            this.dudDd.TabIndex = 102;
            // 
            // dudRr
            // 
            this.dudRr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(72)))), ((int)(((byte)(91)))));
            this.dudRr.Location = new System.Drawing.Point(141, 3);
            this.dudRr.Name = "dudRr";
            this.dudRr.Size = new System.Drawing.Size(40, 22);
            this.dudRr.TabIndex = 103;
            // 
            // dudSsss
            // 
            this.dudSsss.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(72)))), ((int)(((byte)(91)))));
            this.dudSsss.Location = new System.Drawing.Point(187, 3);
            this.dudSsss.Name = "dudSsss";
            this.dudSsss.Size = new System.Drawing.Size(55, 22);
            this.dudSsss.TabIndex = 104;
            // 
            // dudWw
            // 
            this.dudWw.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(72)))), ((int)(((byte)(91)))));
            this.dudWw.Location = new System.Drawing.Point(248, 3);
            this.dudWw.Name = "dudWw";
            this.dudWw.Size = new System.Drawing.Size(40, 22);
            this.dudWw.TabIndex = 105;
            this.dudWw.TextChanged += new System.EventHandler(this.domainUpDown_TextChanged);
            // 
            // dudD
            // 
            this.dudD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(72)))), ((int)(((byte)(91)))));
            this.dudD.Location = new System.Drawing.Point(294, 3);
            this.dudD.Name = "dudD";
            this.dudD.Size = new System.Drawing.Size(40, 22);
            this.dudD.TabIndex = 106;
            // 
            // dudL
            // 
            this.dudL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(72)))), ((int)(((byte)(91)))));
            this.dudL.Location = new System.Drawing.Point(340, 3);
            this.dudL.Name = "dudL";
            this.dudL.Size = new System.Drawing.Size(40, 22);
            this.dudL.TabIndex = 107;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lYy);
            this.flowLayoutPanel1.Controls.Add(this.lMm);
            this.flowLayoutPanel1.Controls.Add(this.lDd);
            this.flowLayoutPanel1.Controls.Add(this.lRr);
            this.flowLayoutPanel1.Controls.Add(this.lSsss);
            this.flowLayoutPanel1.Controls.Add(this.lWw);
            this.flowLayoutPanel1.Controls.Add(this.lD);
            this.flowLayoutPanel1.Controls.Add(this.lL);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 45);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(247, 18);
            this.flowLayoutPanel1.TabIndex = 109;
            // 
            // lMm
            // 
            this.lMm.AutoSize = true;
            this.lMm.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lMm.Location = new System.Drawing.Point(30, 0);
            this.lMm.Name = "lMm";
            this.lMm.Size = new System.Drawing.Size(29, 13);
            this.lMm.TabIndex = 105;
            this.lMm.Text = "MM";
            // 
            // lDd
            // 
            this.lDd.AutoSize = true;
            this.lDd.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lDd.Location = new System.Drawing.Point(65, 0);
            this.lDd.Name = "lDd";
            this.lDd.Size = new System.Drawing.Size(23, 13);
            this.lDd.TabIndex = 106;
            this.lDd.Text = "DD";
            // 
            // lRr
            // 
            this.lRr.AutoSize = true;
            this.lRr.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lRr.Location = new System.Drawing.Point(94, 0);
            this.lRr.Name = "lRr";
            this.lRr.Size = new System.Drawing.Size(21, 13);
            this.lRr.TabIndex = 107;
            this.lRr.Text = "RR";
            // 
            // lSsss
            // 
            this.lSsss.AutoSize = true;
            this.lSsss.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lSsss.Location = new System.Drawing.Point(121, 0);
            this.lSsss.Name = "lSsss";
            this.lSsss.Size = new System.Drawing.Size(31, 13);
            this.lSsss.TabIndex = 108;
            this.lSsss.Text = "SSSS";
            // 
            // lWw
            // 
            this.lWw.AutoSize = true;
            this.lWw.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lWw.Location = new System.Drawing.Point(158, 0);
            this.lWw.Name = "lWw";
            this.lWw.Size = new System.Drawing.Size(29, 13);
            this.lWw.TabIndex = 109;
            this.lWw.Text = "WW";
            // 
            // lD
            // 
            this.lD.AutoSize = true;
            this.lD.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lD.Location = new System.Drawing.Point(193, 0);
            this.lD.Name = "lD";
            this.lD.Size = new System.Drawing.Size(15, 13);
            this.lD.TabIndex = 110;
            this.lD.Text = "D";
            // 
            // lL
            // 
            this.lL.AutoSize = true;
            this.lL.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lL.Location = new System.Drawing.Point(214, 0);
            this.lL.Name = "lL";
            this.lL.Size = new System.Drawing.Size(13, 13);
            this.lL.TabIndex = 111;
            this.lL.Text = "L";
            // 
            // lRssiCh2_3
            // 
            this.lRssiCh2_3.AutoSize = true;
            this.lRssiCh2_3.Font = new System.Drawing.Font("Nirmala UI", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lRssiCh2_3.ForeColor = System.Drawing.Color.White;
            this.lRssiCh2_3.Location = new System.Drawing.Point(467, 13);
            this.lRssiCh2_3.Name = "lRssiCh2_3";
            this.lRssiCh2_3.Size = new System.Drawing.Size(29, 11);
            this.lRssiCh2_3.TabIndex = 90;
            this.lRssiCh2_3.Text = "RSSI-4";
            // 
            // lRssiCh2_2
            // 
            this.lRssiCh2_2.AutoSize = true;
            this.lRssiCh2_2.Font = new System.Drawing.Font("Nirmala UI", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lRssiCh2_2.ForeColor = System.Drawing.Color.White;
            this.lRssiCh2_2.Location = new System.Drawing.Point(434, 13);
            this.lRssiCh2_2.Name = "lRssiCh2_2";
            this.lRssiCh2_2.Size = new System.Drawing.Size(29, 11);
            this.lRssiCh2_2.TabIndex = 89;
            this.lRssiCh2_2.Text = "RSSI-3";
            // 
            // lRssiCh2_1
            // 
            this.lRssiCh2_1.AutoSize = true;
            this.lRssiCh2_1.Font = new System.Drawing.Font("Nirmala UI", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lRssiCh2_1.ForeColor = System.Drawing.Color.White;
            this.lRssiCh2_1.Location = new System.Drawing.Point(401, 13);
            this.lRssiCh2_1.Name = "lRssiCh2_1";
            this.lRssiCh2_1.Size = new System.Drawing.Size(29, 11);
            this.lRssiCh2_1.TabIndex = 88;
            this.lRssiCh2_1.Text = "RSSI-2";
            // 
            // lRssiCh2_0
            // 
            this.lRssiCh2_0.AutoSize = true;
            this.lRssiCh2_0.Font = new System.Drawing.Font("Nirmala UI", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lRssiCh2_0.ForeColor = System.Drawing.Color.White;
            this.lRssiCh2_0.Location = new System.Drawing.Point(368, 13);
            this.lRssiCh2_0.Name = "lRssiCh2_0";
            this.lRssiCh2_0.Size = new System.Drawing.Size(29, 11);
            this.lRssiCh2_0.TabIndex = 87;
            this.lRssiCh2_0.Text = "RSSI-1";
            // 
            // tbRssiCh2_3
            // 
            this.tbRssiCh2_3.Enabled = false;
            this.tbRssiCh2_3.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRssiCh2_3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.tbRssiCh2_3.Location = new System.Drawing.Point(469, 25);
            this.tbRssiCh2_3.Name = "tbRssiCh2_3";
            this.tbRssiCh2_3.Size = new System.Drawing.Size(32, 23);
            this.tbRssiCh2_3.TabIndex = 86;
            // 
            // tbRssiCh2_2
            // 
            this.tbRssiCh2_2.Enabled = false;
            this.tbRssiCh2_2.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRssiCh2_2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.tbRssiCh2_2.Location = new System.Drawing.Point(436, 25);
            this.tbRssiCh2_2.Name = "tbRssiCh2_2";
            this.tbRssiCh2_2.Size = new System.Drawing.Size(32, 23);
            this.tbRssiCh2_2.TabIndex = 85;
            // 
            // tbRssiCh2_1
            // 
            this.tbRssiCh2_1.Enabled = false;
            this.tbRssiCh2_1.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRssiCh2_1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.tbRssiCh2_1.Location = new System.Drawing.Point(403, 25);
            this.tbRssiCh2_1.Name = "tbRssiCh2_1";
            this.tbRssiCh2_1.Size = new System.Drawing.Size(32, 23);
            this.tbRssiCh2_1.TabIndex = 84;
            // 
            // tbRssiCh2_0
            // 
            this.tbRssiCh2_0.Enabled = false;
            this.tbRssiCh2_0.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRssiCh2_0.ForeColor = System.Drawing.Color.MidnightBlue;
            this.tbRssiCh2_0.Location = new System.Drawing.Point(370, 25);
            this.tbRssiCh2_0.Name = "tbRssiCh2_0";
            this.tbRssiCh2_0.Size = new System.Drawing.Size(32, 23);
            this.tbRssiCh2_0.TabIndex = 83;
            // 
            // tbLogFilePath
            // 
            this.tbLogFilePath.BackColor = System.Drawing.Color.White;
            this.tbLogFilePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbLogFilePath.Font = new System.Drawing.Font("Nirmala UI", 10F);
            this.tbLogFilePath.ForeColor = System.Drawing.Color.MidnightBlue;
            this.tbLogFilePath.Location = new System.Drawing.Point(13, 167);
            this.tbLogFilePath.Name = "tbLogFilePath";
            this.tbLogFilePath.Size = new System.Drawing.Size(207, 25);
            this.tbLogFilePath.TabIndex = 72;
            this.tbLogFilePath.Text = "Please click here to set the export file path.";
            this.tbLogFilePath.Click += new System.EventHandler(this.tbLogFilePath_Click);
            // 
            // lRssiCh1_3
            // 
            this.lRssiCh1_3.AutoSize = true;
            this.lRssiCh1_3.Font = new System.Drawing.Font("Nirmala UI", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lRssiCh1_3.ForeColor = System.Drawing.Color.White;
            this.lRssiCh1_3.Location = new System.Drawing.Point(331, 13);
            this.lRssiCh1_3.Name = "lRssiCh1_3";
            this.lRssiCh1_3.Size = new System.Drawing.Size(29, 11);
            this.lRssiCh1_3.TabIndex = 75;
            this.lRssiCh1_3.Text = "RSSI-4";
            // 
            // lLogFilePath
            // 
            this.lLogFilePath.AutoSize = true;
            this.lLogFilePath.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lLogFilePath.ForeColor = System.Drawing.Color.White;
            this.lLogFilePath.Location = new System.Drawing.Point(9, 152);
            this.lLogFilePath.Name = "lLogFilePath";
            this.lLogFilePath.Size = new System.Drawing.Size(76, 13);
            this.lLogFilePath.TabIndex = 71;
            this.lLogFilePath.Text = "Log file path:";
            // 
            // bWriteSnDateCone
            // 
            this.bWriteSnDateCone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(115)))), ((int)(((byte)(138)))));
            this.bWriteSnDateCone.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bWriteSnDateCone.FlatAppearance.BorderSize = 0;
            this.bWriteSnDateCone.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold);
            this.bWriteSnDateCone.ForeColor = System.Drawing.Color.White;
            this.bWriteSnDateCone.Location = new System.Drawing.Point(6, 21);
            this.bWriteSnDateCone.Name = "bWriteSnDateCone";
            this.bWriteSnDateCone.Size = new System.Drawing.Size(90, 52);
            this.bWriteSnDateCone.TabIndex = 82;
            this.bWriteSnDateCone.Text = "Write SN";
            this.bWriteSnDateCone.UseVisualStyleBackColor = false;
            this.bWriteSnDateCone.Visible = false;
            this.bWriteSnDateCone.Click += new System.EventHandler(this.bWriteSnDateCode_Click);
            // 
            // lRssiCh1_2
            // 
            this.lRssiCh1_2.AutoSize = true;
            this.lRssiCh1_2.Font = new System.Drawing.Font("Nirmala UI", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lRssiCh1_2.ForeColor = System.Drawing.Color.White;
            this.lRssiCh1_2.Location = new System.Drawing.Point(298, 13);
            this.lRssiCh1_2.Name = "lRssiCh1_2";
            this.lRssiCh1_2.Size = new System.Drawing.Size(29, 11);
            this.lRssiCh1_2.TabIndex = 74;
            this.lRssiCh1_2.Text = "RSSI-3";
            // 
            // lRssiCh1_1
            // 
            this.lRssiCh1_1.AutoSize = true;
            this.lRssiCh1_1.Font = new System.Drawing.Font("Nirmala UI", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lRssiCh1_1.ForeColor = System.Drawing.Color.White;
            this.lRssiCh1_1.Location = new System.Drawing.Point(265, 13);
            this.lRssiCh1_1.Name = "lRssiCh1_1";
            this.lRssiCh1_1.Size = new System.Drawing.Size(29, 11);
            this.lRssiCh1_1.TabIndex = 73;
            this.lRssiCh1_1.Text = "RSSI-2";
            // 
            // tbRssiCh1_3
            // 
            this.tbRssiCh1_3.Enabled = false;
            this.tbRssiCh1_3.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRssiCh1_3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.tbRssiCh1_3.Location = new System.Drawing.Point(333, 25);
            this.tbRssiCh1_3.Name = "tbRssiCh1_3";
            this.tbRssiCh1_3.Size = new System.Drawing.Size(32, 23);
            this.tbRssiCh1_3.TabIndex = 72;
            // 
            // tbRssiCh1_2
            // 
            this.tbRssiCh1_2.Enabled = false;
            this.tbRssiCh1_2.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRssiCh1_2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.tbRssiCh1_2.Location = new System.Drawing.Point(300, 25);
            this.tbRssiCh1_2.Name = "tbRssiCh1_2";
            this.tbRssiCh1_2.Size = new System.Drawing.Size(32, 23);
            this.tbRssiCh1_2.TabIndex = 71;
            // 
            // tbRssiCh1_1
            // 
            this.tbRssiCh1_1.Enabled = false;
            this.tbRssiCh1_1.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRssiCh1_1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.tbRssiCh1_1.Location = new System.Drawing.Point(267, 25);
            this.tbRssiCh1_1.Name = "tbRssiCh1_1";
            this.tbRssiCh1_1.Size = new System.Drawing.Size(32, 23);
            this.tbRssiCh1_1.TabIndex = 70;
            // 
            // lVenderSn
            // 
            this.lVenderSn.AutoSize = true;
            this.lVenderSn.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lVenderSn.ForeColor = System.Drawing.Color.White;
            this.lVenderSn.Location = new System.Drawing.Point(108, 74);
            this.lVenderSn.Name = "lVenderSn";
            this.lVenderSn.Size = new System.Drawing.Size(64, 13);
            this.lVenderSn.TabIndex = 64;
            this.lVenderSn.Text = "Vender SN:";
            // 
            // tbRssiCh1_0
            // 
            this.tbRssiCh1_0.Enabled = false;
            this.tbRssiCh1_0.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRssiCh1_0.ForeColor = System.Drawing.Color.MidnightBlue;
            this.tbRssiCh1_0.Location = new System.Drawing.Point(234, 25);
            this.tbRssiCh1_0.Name = "tbRssiCh1_0";
            this.tbRssiCh1_0.Size = new System.Drawing.Size(32, 23);
            this.tbRssiCh1_0.TabIndex = 69;
            // 
            // tbVenderSn
            // 
            this.tbVenderSn.Enabled = false;
            this.tbVenderSn.ForeColor = System.Drawing.Color.MidnightBlue;
            this.tbVenderSn.Location = new System.Drawing.Point(110, 91);
            this.tbVenderSn.Name = "tbVenderSn";
            this.tbVenderSn.Size = new System.Drawing.Size(130, 26);
            this.tbVenderSn.TabIndex = 65;
            this.tbVenderSn.Text = "YYMMDDRRSSSS";
            // 
            // lRssiCh1_0
            // 
            this.lRssiCh1_0.AutoSize = true;
            this.lRssiCh1_0.Font = new System.Drawing.Font("Nirmala UI", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lRssiCh1_0.ForeColor = System.Drawing.Color.White;
            this.lRssiCh1_0.Location = new System.Drawing.Point(232, 13);
            this.lRssiCh1_0.Name = "lRssiCh1_0";
            this.lRssiCh1_0.Size = new System.Drawing.Size(29, 11);
            this.lRssiCh1_0.TabIndex = 68;
            this.lRssiCh1_0.Text = "RSSI-1";
            // 
            // lDateCode
            // 
            this.lDateCode.AutoSize = true;
            this.lDateCode.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDateCode.ForeColor = System.Drawing.Color.White;
            this.lDateCode.Location = new System.Drawing.Point(11, 74);
            this.lDateCode.Name = "lDateCode";
            this.lDateCode.Size = new System.Drawing.Size(62, 13);
            this.lDateCode.TabIndex = 66;
            this.lDateCode.Text = "Date code:";
            // 
            // tbDateCode
            // 
            this.tbDateCode.Enabled = false;
            this.tbDateCode.ForeColor = System.Drawing.Color.MidnightBlue;
            this.tbDateCode.Location = new System.Drawing.Point(13, 91);
            this.tbDateCode.Name = "tbDateCode";
            this.tbDateCode.Size = new System.Drawing.Size(90, 26);
            this.tbDateCode.TabIndex = 67;
            this.tbDateCode.Text = "YYMMDD";
            // 
            // bRelinkTest
            // 
            this.bRelinkTest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(115)))), ((int)(((byte)(138)))));
            this.bRelinkTest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bRelinkTest.FlatAppearance.BorderSize = 0;
            this.bRelinkTest.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bRelinkTest.ForeColor = System.Drawing.Color.White;
            this.bRelinkTest.Location = new System.Drawing.Point(217, 205);
            this.bRelinkTest.Name = "bRelinkTest";
            this.bRelinkTest.Size = new System.Drawing.Size(38, 20);
            this.bRelinkTest.TabIndex = 105;
            this.bRelinkTest.Text = "Test";
            this.bRelinkTest.UseVisualStyleBackColor = false;
            this.bRelinkTest.Visible = false;
            this.bRelinkTest.Click += new System.EventHandler(this.bRelinkTest_Click);
            // 
            // tbRelinkCount
            // 
            this.tbRelinkCount.Font = new System.Drawing.Font("Nirmala UI", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRelinkCount.ForeColor = System.Drawing.Color.Black;
            this.tbRelinkCount.Location = new System.Drawing.Point(235, 184);
            this.tbRelinkCount.Name = "tbRelinkCount";
            this.tbRelinkCount.Size = new System.Drawing.Size(20, 18);
            this.tbRelinkCount.TabIndex = 102;
            this.tbRelinkCount.Text = "3";
            this.tbRelinkCount.Visible = false;
            // 
            // tbIntervalTime
            // 
            this.tbIntervalTime.Font = new System.Drawing.Font("Nirmala UI", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbIntervalTime.ForeColor = System.Drawing.Color.Black;
            this.tbIntervalTime.Location = new System.Drawing.Point(204, 184);
            this.tbIntervalTime.Name = "tbIntervalTime";
            this.tbIntervalTime.Size = new System.Drawing.Size(28, 18);
            this.tbIntervalTime.TabIndex = 90;
            this.tbIntervalTime.Text = "30";
            this.tbIntervalTime.Visible = false;
            // 
            // bLogFileComparison
            // 
            this.bLogFileComparison.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(115)))), ((int)(((byte)(138)))));
            this.bLogFileComparison.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bLogFileComparison.FlatAppearance.BorderSize = 0;
            this.bLogFileComparison.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bLogFileComparison.ForeColor = System.Drawing.Color.White;
            this.bLogFileComparison.Location = new System.Drawing.Point(21, 153);
            this.bLogFileComparison.Name = "bLogFileComparison";
            this.bLogFileComparison.Size = new System.Drawing.Size(121, 25);
            this.bLogFileComparison.TabIndex = 97;
            this.bLogFileComparison.Text = "LogFile comparison";
            this.bLogFileComparison.UseVisualStyleBackColor = false;
            this.bLogFileComparison.Visible = false;
            this.bLogFileComparison.Click += new System.EventHandler(this.bLogFileComparison_Click);
            // 
            // bCfgFileComparison
            // 
            this.bCfgFileComparison.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(115)))), ((int)(((byte)(138)))));
            this.bCfgFileComparison.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bCfgFileComparison.FlatAppearance.BorderSize = 0;
            this.bCfgFileComparison.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bCfgFileComparison.ForeColor = System.Drawing.Color.White;
            this.bCfgFileComparison.Location = new System.Drawing.Point(21, 127);
            this.bCfgFileComparison.Name = "bCfgFileComparison";
            this.bCfgFileComparison.Size = new System.Drawing.Size(121, 25);
            this.bCfgFileComparison.TabIndex = 89;
            this.bCfgFileComparison.Text = "CfgFile comparison";
            this.bCfgFileComparison.UseVisualStyleBackColor = false;
            this.bCfgFileComparison.Visible = false;
            this.bCfgFileComparison.Click += new System.EventHandler(this.bCfgFileComparison_Click);
            // 
            // lDataName
            // 
            this.lDataName.AutoSize = true;
            this.lDataName.Font = new System.Drawing.Font("Nirmala UI", 6F, System.Drawing.FontStyle.Bold);
            this.lDataName.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lDataName.Location = new System.Drawing.Point(91, 227);
            this.lDataName.Name = "lDataName";
            this.lDataName.Size = new System.Drawing.Size(8, 11);
            this.lDataName.TabIndex = 72;
            this.lDataName.Text = "_";
            // 
            // lPathData
            // 
            this.lPathData.AutoSize = true;
            this.lPathData.Font = new System.Drawing.Font("Nirmala UI", 8F, System.Drawing.FontStyle.Bold);
            this.lPathData.ForeColor = System.Drawing.Color.White;
            this.lPathData.Location = new System.Drawing.Point(21, 225);
            this.lPathData.Name = "lPathData";
            this.lPathData.Size = new System.Drawing.Size(64, 13);
            this.lPathData.TabIndex = 71;
            this.lPathData.Text = "DATAROM:";
            // 
            // tbVersionCodeCh1
            // 
            this.tbVersionCodeCh1.Enabled = false;
            this.tbVersionCodeCh1.Font = new System.Drawing.Font("Nirmala UI", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbVersionCodeCh1.ForeColor = System.Drawing.Color.Black;
            this.tbVersionCodeCh1.Location = new System.Drawing.Point(339, 149);
            this.tbVersionCodeCh1.Name = "tbVersionCodeCh1";
            this.tbVersionCodeCh1.Size = new System.Drawing.Size(70, 18);
            this.tbVersionCodeCh1.TabIndex = 73;
            // 
            // tbVersionCodeReNewCh1
            // 
            this.tbVersionCodeReNewCh1.Enabled = false;
            this.tbVersionCodeReNewCh1.Font = new System.Drawing.Font("Nirmala UI", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbVersionCodeReNewCh1.ForeColor = System.Drawing.Color.Black;
            this.tbVersionCodeReNewCh1.Location = new System.Drawing.Point(339, 169);
            this.tbVersionCodeReNewCh1.Name = "tbVersionCodeReNewCh1";
            this.tbVersionCodeReNewCh1.Size = new System.Drawing.Size(70, 18);
            this.tbVersionCodeReNewCh1.TabIndex = 74;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 7F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(289, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 12);
            this.label1.TabIndex = 75;
            this.label1.Text = "Renew";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 7F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(269, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 12);
            this.label2.TabIndex = 77;
            this.label2.Text = "FW Version";
            // 
            // tbVersionCodeReNewCh2
            // 
            this.tbVersionCodeReNewCh2.Enabled = false;
            this.tbVersionCodeReNewCh2.Font = new System.Drawing.Font("Nirmala UI", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbVersionCodeReNewCh2.ForeColor = System.Drawing.Color.Black;
            this.tbVersionCodeReNewCh2.Location = new System.Drawing.Point(442, 169);
            this.tbVersionCodeReNewCh2.Name = "tbVersionCodeReNewCh2";
            this.tbVersionCodeReNewCh2.Size = new System.Drawing.Size(70, 18);
            this.tbVersionCodeReNewCh2.TabIndex = 79;
            this.tbVersionCodeReNewCh2.Visible = false;
            // 
            // tbVersionCodeCh2
            // 
            this.tbVersionCodeCh2.Enabled = false;
            this.tbVersionCodeCh2.Font = new System.Drawing.Font("Nirmala UI", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbVersionCodeCh2.ForeColor = System.Drawing.Color.Black;
            this.tbVersionCodeCh2.Location = new System.Drawing.Point(442, 149);
            this.tbVersionCodeCh2.Name = "tbVersionCodeCh2";
            this.tbVersionCodeCh2.Size = new System.Drawing.Size(70, 18);
            this.tbVersionCodeCh2.TabIndex = 78;
            this.tbVersionCodeCh2.Visible = false;
            // 
            // cbSecurityLock
            // 
            this.cbSecurityLock.AutoSize = true;
            this.cbSecurityLock.Checked = true;
            this.cbSecurityLock.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSecurityLock.Font = new System.Drawing.Font("Nirmala UI", 6F, System.Drawing.FontStyle.Bold);
            this.cbSecurityLock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(72)))), ((int)(((byte)(91)))));
            this.cbSecurityLock.Location = new System.Drawing.Point(388, 0);
            this.cbSecurityLock.Name = "cbSecurityLock";
            this.cbSecurityLock.Size = new System.Drawing.Size(70, 15);
            this.cbSecurityLock.TabIndex = 80;
            this.cbSecurityLock.Text = "SecurityLock";
            this.cbSecurityLock.UseVisualStyleBackColor = true;
            this.cbSecurityLock.Visible = false;
            // 
            // bWriteFromFile
            // 
            this.bWriteFromFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(115)))), ((int)(((byte)(138)))));
            this.bWriteFromFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bWriteFromFile.FlatAppearance.BorderSize = 0;
            this.bWriteFromFile.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bWriteFromFile.ForeColor = System.Drawing.Color.White;
            this.bWriteFromFile.Location = new System.Drawing.Point(144, 153);
            this.bWriteFromFile.Name = "bWriteFromFile";
            this.bWriteFromFile.Size = new System.Drawing.Size(122, 25);
            this.bWriteFromFile.TabIndex = 82;
            this.bWriteFromFile.Text = "WriteFromFile_SAS3";
            this.bWriteFromFile.UseVisualStyleBackColor = false;
            this.bWriteFromFile.Visible = false;
            this.bWriteFromFile.Click += new System.EventHandler(this.bWriteFromFile_Click);
            // 
            // tbOrignalSNCh1
            // 
            this.tbOrignalSNCh1.Enabled = false;
            this.tbOrignalSNCh1.Font = new System.Drawing.Font("Nirmala UI", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbOrignalSNCh1.ForeColor = System.Drawing.Color.Black;
            this.tbOrignalSNCh1.Location = new System.Drawing.Point(339, 189);
            this.tbOrignalSNCh1.Name = "tbOrignalSNCh1";
            this.tbOrignalSNCh1.Size = new System.Drawing.Size(70, 18);
            this.tbOrignalSNCh1.TabIndex = 83;
            this.tbOrignalSNCh1.Visible = false;
            // 
            // tbReNewSnCh1
            // 
            this.tbReNewSnCh1.Enabled = false;
            this.tbReNewSnCh1.Font = new System.Drawing.Font("Nirmala UI", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbReNewSnCh1.ForeColor = System.Drawing.Color.Black;
            this.tbReNewSnCh1.Location = new System.Drawing.Point(339, 209);
            this.tbReNewSnCh1.Name = "tbReNewSnCh1";
            this.tbReNewSnCh1.Size = new System.Drawing.Size(70, 18);
            this.tbReNewSnCh1.TabIndex = 84;
            this.tbReNewSnCh1.Visible = false;
            // 
            // lOriginalSN
            // 
            this.lOriginalSN.AutoSize = true;
            this.lOriginalSN.Font = new System.Drawing.Font("Nirmala UI", 7F, System.Drawing.FontStyle.Bold);
            this.lOriginalSN.ForeColor = System.Drawing.Color.White;
            this.lOriginalSN.Location = new System.Drawing.Point(264, 191);
            this.lOriginalSN.Name = "lOriginalSN";
            this.lOriginalSN.Size = new System.Drawing.Size(60, 12);
            this.lOriginalSN.TabIndex = 85;
            this.lOriginalSN.Text = "Original SN";
            this.lOriginalSN.Visible = false;
            // 
            // lReNewSn
            // 
            this.lReNewSn.AutoSize = true;
            this.lReNewSn.Font = new System.Drawing.Font("Nirmala UI", 7F, System.Drawing.FontStyle.Bold);
            this.lReNewSn.ForeColor = System.Drawing.Color.White;
            this.lReNewSn.Location = new System.Drawing.Point(286, 211);
            this.lReNewSn.Name = "lReNewSn";
            this.lReNewSn.Size = new System.Drawing.Size(38, 12);
            this.lReNewSn.TabIndex = 86;
            this.lReNewSn.Text = "ReNew";
            this.lReNewSn.Visible = false;
            // 
            // tbReNewSnCh2
            // 
            this.tbReNewSnCh2.Enabled = false;
            this.tbReNewSnCh2.Font = new System.Drawing.Font("Nirmala UI", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbReNewSnCh2.ForeColor = System.Drawing.Color.Black;
            this.tbReNewSnCh2.Location = new System.Drawing.Point(442, 209);
            this.tbReNewSnCh2.Name = "tbReNewSnCh2";
            this.tbReNewSnCh2.Size = new System.Drawing.Size(70, 18);
            this.tbReNewSnCh2.TabIndex = 88;
            this.tbReNewSnCh2.Visible = false;
            // 
            // tbOrignalSNCh2
            // 
            this.tbOrignalSNCh2.Enabled = false;
            this.tbOrignalSNCh2.Font = new System.Drawing.Font("Nirmala UI", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbOrignalSNCh2.ForeColor = System.Drawing.Color.Black;
            this.tbOrignalSNCh2.Location = new System.Drawing.Point(442, 189);
            this.tbOrignalSNCh2.Name = "tbOrignalSNCh2";
            this.tbOrignalSNCh2.Size = new System.Drawing.Size(70, 18);
            this.tbOrignalSNCh2.TabIndex = 87;
            this.tbOrignalSNCh2.Visible = false;
            // 
            // gbPrompt
            // 
            this.gbPrompt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(145)))), ((int)(((byte)(168)))));
            this.gbPrompt.Controls.Add(this.lStatus);
            this.gbPrompt.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.gbPrompt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(72)))), ((int)(((byte)(91)))));
            this.gbPrompt.Location = new System.Drawing.Point(198, 73);
            this.gbPrompt.Name = "gbPrompt";
            this.gbPrompt.Size = new System.Drawing.Size(119, 73);
            this.gbPrompt.TabIndex = 104;
            this.gbPrompt.TabStop = false;
            this.gbPrompt.Text = "Prompt";
            this.gbPrompt.Visible = false;
            // 
            // lStatus
            // 
            this.lStatus.AutoSize = true;
            this.lStatus.Font = new System.Drawing.Font("Calibri", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lStatus.ForeColor = System.Drawing.Color.Black;
            this.lStatus.Location = new System.Drawing.Point(2, 26);
            this.lStatus.Name = "lStatus";
            this.lStatus.Size = new System.Drawing.Size(30, 28);
            this.lStatus.TabIndex = 99;
            this.lStatus.Text = "...";
            this.lStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbStartTime
            // 
            this.tbStartTime.Font = new System.Drawing.Font("Nirmala UI", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbStartTime.ForeColor = System.Drawing.Color.Black;
            this.tbStartTime.Location = new System.Drawing.Point(172, 184);
            this.tbStartTime.Name = "tbStartTime";
            this.tbStartTime.Size = new System.Drawing.Size(28, 18);
            this.tbStartTime.TabIndex = 105;
            this.tbStartTime.Text = "10";
            this.tbStartTime.Visible = false;
            // 
            // lMm2
            // 
            this.lMm2.AutoSize = true;
            this.lMm2.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lMm2.Location = new System.Drawing.Point(166, 8);
            this.lMm2.Name = "lMm2";
            this.lMm2.Size = new System.Drawing.Size(29, 13);
            this.lMm2.TabIndex = 110;
            this.lMm2.Text = "MM";
            this.lMm2.Visible = false;
            // 
            // lDd2
            // 
            this.lDd2.AutoSize = true;
            this.lDd2.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lDd2.Location = new System.Drawing.Point(211, 8);
            this.lDd2.Name = "lDd2";
            this.lDd2.Size = new System.Drawing.Size(23, 13);
            this.lDd2.TabIndex = 111;
            this.lDd2.Text = "DD";
            this.lDd2.Visible = false;
            // 
            // dudMm2
            // 
            this.dudMm2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(72)))), ((int)(((byte)(91)))));
            this.dudMm2.Location = new System.Drawing.Point(167, 21);
            this.dudMm2.Name = "dudMm2";
            this.dudMm2.Size = new System.Drawing.Size(40, 22);
            this.dudMm2.TabIndex = 112;
            this.dudMm2.Visible = false;
            // 
            // dudDd2
            // 
            this.dudDd2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(72)))), ((int)(((byte)(91)))));
            this.dudDd2.Location = new System.Drawing.Point(211, 21);
            this.dudDd2.Name = "dudDd2";
            this.dudDd2.Size = new System.Drawing.Size(40, 22);
            this.dudDd2.TabIndex = 113;
            this.dudDd2.Visible = false;
            // 
            // lYy
            // 
            this.lYy.AutoSize = true;
            this.lYy.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lYy.Location = new System.Drawing.Point(3, 0);
            this.lYy.Name = "lYy";
            this.lYy.Size = new System.Drawing.Size(21, 13);
            this.lYy.TabIndex = 104;
            this.lYy.Text = "YY";
            // 
            // CustomerAndMpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(145)))), ((int)(((byte)(168)))));
            this.ClientSize = new System.Drawing.Size(534, 446);
            this.Controls.Add(this.bRelinkTest);
            this.Controls.Add(this.gbPrompt);
            this.Controls.Add(this.tbStartTime);
            this.Controls.Add(this.bLogFileComparison);
            this.Controls.Add(this.tbRelinkCount);
            this.Controls.Add(this.tbReNewSnCh2);
            this.Controls.Add(this.tbOrignalSNCh2);
            this.Controls.Add(this.lReNewSn);
            this.Controls.Add(this.lOriginalSN);
            this.Controls.Add(this.bCfgFileComparison);
            this.Controls.Add(this.tbReNewSnCh1);
            this.Controls.Add(this.tbOrignalSNCh1);
            this.Controls.Add(this.tbIntervalTime);
            this.Controls.Add(this.bWriteFromFile);
            this.Controls.Add(this.cbSecurityLock);
            this.Controls.Add(this.tbVersionCodeReNewCh2);
            this.Controls.Add(this.tbVersionCodeCh2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbVersionCodeReNewCh1);
            this.Controls.Add(this.tbVersionCodeCh1);
            this.Controls.Add(this.lDataName);
            this.Controls.Add(this.lPathData);
            this.Controls.Add(this.gbOperatorMode);
            this.Controls.Add(this.cbI2cConnect);
            this.Controls.Add(this.lApName);
            this.Controls.Add(this.lPathAP);
            this.Controls.Add(this.lMode);
            this.Controls.Add(this.lProduct);
            this.Controls.Add(this.lCh2EC);
            this.Controls.Add(this.lCh1EC);
            this.Controls.Add(this.lCh2Message);
            this.Controls.Add(this.lCh1Message);
            this.Controls.Add(this.cProgressBar2);
            this.Controls.Add(this.rbBoth);
            this.Controls.Add(this.rbSingle);
            this.Controls.Add(this.cProgressBar1);
            this.Controls.Add(this.bStart);
            this.Controls.Add(this.tbFilePath);
            this.Controls.Add(this.lFilePath);
            this.Controls.Add(this.lLogin);
            this.Controls.Add(this.lProductT);
            this.Controls.Add(this.lModeT);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "CustomerAndMpForm";
            this.Palette = this.kryptonPalette1;
            this.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.gbOperatorMode.ResumeLayout(false);
            this.gbOperatorMode.PerformLayout();
            this.gbCodeEditor.ResumeLayout(false);
            this.gbCodeEditor.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.gbPrompt.ResumeLayout(false);
            this.gbPrompt.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPalette kryptonPalette1;
        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.TextBox tbFilePath;
        private System.Windows.Forms.Label lFilePath;
        private System.Windows.Forms.Label lLogin;
        private CircularProgressBar.CircularProgressBar cProgressBar1;
        private System.Windows.Forms.RadioButton rbSingle;
        private System.Windows.Forms.RadioButton rbBoth;
        private CircularProgressBar.CircularProgressBar cProgressBar2;
        private System.Windows.Forms.Label lCh1Message;
        private System.Windows.Forms.Label lCh2Message;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lCh1EC;
        private System.Windows.Forms.Label lCh2EC;
        private System.Windows.Forms.Label lProduct;
        private System.Windows.Forms.Label lMode;
        private System.Windows.Forms.Label lModeT;
        private System.Windows.Forms.Label lProductT;
        private System.Windows.Forms.Label lPathAP;
        private System.Windows.Forms.Label lApName;
        private System.Windows.Forms.CheckBox cbBypassW;
        private System.Windows.Forms.CheckBox cbI2cConnect;
        private System.Windows.Forms.GroupBox gbOperatorMode;
        private System.Windows.Forms.Label lVenderSn;
        private System.Windows.Forms.TextBox tbRssiCh1_0;
        private System.Windows.Forms.TextBox tbVenderSn;
        private System.Windows.Forms.Label lRssiCh1_0;
        private System.Windows.Forms.Label lDateCode;
        private System.Windows.Forms.TextBox tbDateCode;
        private System.Windows.Forms.Label lRssiCh1_3;
        private System.Windows.Forms.Label lRssiCh1_2;
        private System.Windows.Forms.Label lRssiCh1_1;
        private System.Windows.Forms.TextBox tbRssiCh1_3;
        private System.Windows.Forms.TextBox tbRssiCh1_2;
        private System.Windows.Forms.TextBox tbRssiCh1_1;
        private System.Windows.Forms.TextBox tbLogFilePath;
        private System.Windows.Forms.Label lLogFilePath;
        private System.Windows.Forms.Label lDataName;
        private System.Windows.Forms.Label lPathData;
        private System.Windows.Forms.TextBox tbVersionCodeCh1;
        private System.Windows.Forms.TextBox tbVersionCodeReNewCh1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbVersionCodeReNewCh2;
        private System.Windows.Forms.TextBox tbVersionCodeCh2;
        private System.Windows.Forms.CheckBox cbSecurityLock;
        private System.Windows.Forms.Button bWriteFromFile;
        private System.Windows.Forms.Button bWriteSnDateCone;
        private System.Windows.Forms.TextBox tbOrignalSNCh1;
        private System.Windows.Forms.TextBox tbReNewSnCh1;
        private System.Windows.Forms.Label lOriginalSN;
        private System.Windows.Forms.Label lReNewSn;
        private System.Windows.Forms.TextBox tbReNewSnCh2;
        private System.Windows.Forms.TextBox tbOrignalSNCh2;
        private System.Windows.Forms.Button bCfgFileComparison;
        private System.Windows.Forms.TextBox tbRssiCh2_3;
        private System.Windows.Forms.TextBox tbRssiCh2_2;
        private System.Windows.Forms.TextBox tbRssiCh2_1;
        private System.Windows.Forms.TextBox tbRssiCh2_0;
        private System.Windows.Forms.Label lRssiCh2_3;
        private System.Windows.Forms.Label lRssiCh2_2;
        private System.Windows.Forms.Label lRssiCh2_1;
        private System.Windows.Forms.Label lRssiCh2_0;
        private System.Windows.Forms.GroupBox gbCodeEditor;
        private System.Windows.Forms.CheckBox cbBarcodeMode;
        private System.Windows.Forms.Button bRenewRssi;
        private System.Windows.Forms.CheckBox cbEngineerMode;
        private System.Windows.Forms.Button bLogFileComparison;
        private System.Windows.Forms.TextBox tbIntervalTime;
        private System.Windows.Forms.RadioButton rbOnlySN;
        private System.Windows.Forms.RadioButton rbFullMode;
        private System.Windows.Forms.RadioButton rbLogFileMode;
        private System.Windows.Forms.GroupBox gbPrompt;
        private System.Windows.Forms.Label lStatus;
        private System.Windows.Forms.TextBox tbRelinkCount;
        private System.Windows.Forms.Button bRelinkTest;
        private System.Windows.Forms.TextBox tbStartTime;
        private System.Windows.Forms.CheckBox cbRelinkCheck;
        private System.Windows.Forms.TextBox tbRssiCriteria;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cbNgInterrupt;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.DomainUpDown dudYy;
        private System.Windows.Forms.DomainUpDown dudMm;
        private System.Windows.Forms.DomainUpDown dudDd;
        private System.Windows.Forms.DomainUpDown dudRr;
        private System.Windows.Forms.DomainUpDown dudSsss;
        private ComboBox cbSnNamingRule;
        private DomainUpDown dudWw;
        private DomainUpDown dudD;
        private DomainUpDown dudL;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label lMm;
        private Label lDd;
        private Label lRr;
        private Label lSsss;
        private Label lWw;
        private Label lD;
        private Label lL;
        private DomainUpDown dudDd2;
        private DomainUpDown dudMm2;
        private Label lDd2;
        private Label lMm2;
        private Label lYy;
    }
}