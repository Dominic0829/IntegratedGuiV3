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
            this.tbLogFIlePath = new System.Windows.Forms.TextBox();
            this.lRssi3 = new System.Windows.Forms.Label();
            this.lLogFilePath = new System.Windows.Forms.Label();
            this.lRssi2 = new System.Windows.Forms.Label();
            this.lRssi1 = new System.Windows.Forms.Label();
            this.tbRssi3 = new System.Windows.Forms.TextBox();
            this.tbRssi2 = new System.Windows.Forms.TextBox();
            this.tbRssi1 = new System.Windows.Forms.TextBox();
            this.lVenderSn = new System.Windows.Forms.Label();
            this.tbRssi0 = new System.Windows.Forms.TextBox();
            this.tbVenderSn = new System.Windows.Forms.TextBox();
            this.lRssi0 = new System.Windows.Forms.Label();
            this.lDateCode = new System.Windows.Forms.Label();
            this.tbDateCode = new System.Windows.Forms.TextBox();
            this.lDataName = new System.Windows.Forms.Label();
            this.lPathData = new System.Windows.Forms.Label();
            this.tbVersionCodeCh1 = new System.Windows.Forms.TextBox();
            this.tbVersionCodeCheckCh1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbVersionCodeCheckCh2 = new System.Windows.Forms.TextBox();
            this.tbVersionCodeCh2 = new System.Windows.Forms.TextBox();
            this.cbSecurityLock = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.gbOperatorMode.SuspendLayout();
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
            this.bStart.Location = new System.Drawing.Point(20, 76);
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
            this.tbFilePath.Location = new System.Drawing.Point(20, 45);
            this.tbFilePath.Name = "tbFilePath";
            this.tbFilePath.Size = new System.Drawing.Size(289, 25);
            this.tbFilePath.TabIndex = 43;
            this.tbFilePath.Text = "Please click here, to import the Config file...";
            this.tbFilePath.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tbFilePath_MouseClick);
            this.tbFilePath.Enter += new System.EventHandler(this.tbFilePath_Enter);
            this.tbFilePath.Leave += new System.EventHandler(this.tbFilePath_Leave);
            // 
            // lFilePath
            // 
            this.lFilePath.AutoSize = true;
            this.lFilePath.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lFilePath.ForeColor = System.Drawing.Color.White;
            this.lFilePath.Location = new System.Drawing.Point(16, 23);
            this.lFilePath.Name = "lFilePath";
            this.lFilePath.Size = new System.Drawing.Size(118, 19);
            this.lFilePath.TabIndex = 42;
            this.lFilePath.Text = "Config File path:";
            // 
            // lLogin
            // 
            this.lLogin.AutoSize = true;
            this.lLogin.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(72)))), ((int)(((byte)(91)))));
            this.lLogin.Location = new System.Drawing.Point(15, -8);
            this.lLogin.Name = "lLogin";
            this.lLogin.Size = new System.Drawing.Size(337, 32);
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
            this.cProgressBar1.Location = new System.Drawing.Point(317, 31);
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
            this.cProgressBar2.Location = new System.Drawing.Point(423, 31);
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
            this.lCh1Message.Location = new System.Drawing.Point(322, 130);
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
            this.lCh2Message.Location = new System.Drawing.Point(428, 130);
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
            this.lCh1EC.Location = new System.Drawing.Point(391, 29);
            this.lCh1EC.Name = "lCh1EC";
            this.lCh1EC.Size = new System.Drawing.Size(11, 10);
            this.lCh1EC.TabIndex = 54;
            this.lCh1EC.Text = "...";
            // 
            // lCh2EC
            // 
            this.lCh2EC.AutoSize = true;
            this.lCh2EC.BackColor = System.Drawing.Color.Transparent;
            this.lCh2EC.Font = new System.Drawing.Font("Nirmala UI", 5F, System.Drawing.FontStyle.Bold);
            this.lCh2EC.ForeColor = System.Drawing.Color.White;
            this.lCh2EC.Location = new System.Drawing.Point(498, 29);
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
            this.lProduct.Location = new System.Drawing.Point(73, 168);
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
            this.lMode.Location = new System.Drawing.Point(64, 183);
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
            this.lModeT.Location = new System.Drawing.Point(20, 183);
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
            this.lProductT.Location = new System.Drawing.Point(20, 168);
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
            this.lPathAP.Location = new System.Drawing.Point(20, 198);
            this.lPathAP.Name = "lPathAP";
            this.lPathAP.Size = new System.Drawing.Size(51, 13);
            this.lPathAP.TabIndex = 60;
            this.lPathAP.Text = "APROM:";
            // 
            // lAPPath
            // 
            this.lApName.AutoSize = true;
            this.lApName.Font = new System.Drawing.Font("Nirmala UI", 6F, System.Drawing.FontStyle.Bold);
            this.lApName.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lApName.Location = new System.Drawing.Point(70, 200);
            this.lApName.Name = "lAPPath";
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
            this.cbBypassW.Location = new System.Drawing.Point(436, 15);
            this.cbBypassW.Name = "cbBypassW";
            this.cbBypassW.Size = new System.Drawing.Size(102, 15);
            this.cbBypassW.TabIndex = 62;
            this.cbBypassW.Text = "BypassIcConfigWrite";
            this.cbBypassW.UseVisualStyleBackColor = true;
            // 
            // cbI2cConnect
            // 
            this.cbI2cConnect.AutoSize = true;
            this.cbI2cConnect.Checked = true;
            this.cbI2cConnect.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbI2cConnect.Font = new System.Drawing.Font("Nirmala UI", 6F, System.Drawing.FontStyle.Bold);
            this.cbI2cConnect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(72)))), ((int)(((byte)(91)))));
            this.cbI2cConnect.Location = new System.Drawing.Point(436, 0);
            this.cbI2cConnect.Name = "cbI2cConnect";
            this.cbI2cConnect.Size = new System.Drawing.Size(65, 15);
            this.cbI2cConnect.TabIndex = 63;
            this.cbI2cConnect.Text = "ChConnect";
            this.cbI2cConnect.UseVisualStyleBackColor = true;
            this.cbI2cConnect.CheckedChanged += new System.EventHandler(this.I2cMasterConnect_CheckedChanged);
            // 
            // gbOperatorMode
            // 
            this.gbOperatorMode.Controls.Add(this.tbLogFIlePath);
            this.gbOperatorMode.Controls.Add(this.lRssi3);
            this.gbOperatorMode.Controls.Add(this.lLogFilePath);
            this.gbOperatorMode.Controls.Add(this.lRssi2);
            this.gbOperatorMode.Controls.Add(this.lRssi1);
            this.gbOperatorMode.Controls.Add(this.tbRssi3);
            this.gbOperatorMode.Controls.Add(this.tbRssi2);
            this.gbOperatorMode.Controls.Add(this.tbRssi1);
            this.gbOperatorMode.Controls.Add(this.lVenderSn);
            this.gbOperatorMode.Controls.Add(this.tbRssi0);
            this.gbOperatorMode.Controls.Add(this.tbVenderSn);
            this.gbOperatorMode.Controls.Add(this.lRssi0);
            this.gbOperatorMode.Controls.Add(this.lDateCode);
            this.gbOperatorMode.Controls.Add(this.tbDateCode);
            this.gbOperatorMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(72)))), ((int)(((byte)(91)))));
            this.gbOperatorMode.Location = new System.Drawing.Point(23, 231);
            this.gbOperatorMode.Name = "gbOperatorMode";
            this.gbOperatorMode.Size = new System.Drawing.Size(486, 151);
            this.gbOperatorMode.TabIndex = 70;
            this.gbOperatorMode.TabStop = false;
            this.gbOperatorMode.Text = "MP information";
            // 
            // tbLogFIlePath
            // 
            this.tbLogFIlePath.BackColor = System.Drawing.Color.White;
            this.tbLogFIlePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbLogFIlePath.Font = new System.Drawing.Font("Nirmala UI", 10F);
            this.tbLogFIlePath.ForeColor = System.Drawing.Color.Silver;
            this.tbLogFIlePath.Location = new System.Drawing.Point(10, 117);
            this.tbLogFIlePath.Name = "tbLogFIlePath";
            this.tbLogFIlePath.Size = new System.Drawing.Size(281, 25);
            this.tbLogFIlePath.TabIndex = 72;
            this.tbLogFIlePath.Text = "Please click here to set the export file path.";
            this.tbLogFIlePath.Visible = false;
            this.tbLogFIlePath.Click += new System.EventHandler(this.tbLogFilePath);
            // 
            // lRssi3
            // 
            this.lRssi3.AutoSize = true;
            this.lRssi3.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lRssi3.ForeColor = System.Drawing.Color.White;
            this.lRssi3.Location = new System.Drawing.Point(432, 21);
            this.lRssi3.Name = "lRssi3";
            this.lRssi3.Size = new System.Drawing.Size(39, 13);
            this.lRssi3.TabIndex = 75;
            this.lRssi3.Text = "RSSI-4";
            // 
            // lLogFilePath
            // 
            this.lLogFilePath.AutoSize = true;
            this.lLogFilePath.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lLogFilePath.ForeColor = System.Drawing.Color.White;
            this.lLogFilePath.Location = new System.Drawing.Point(6, 101);
            this.lLogFilePath.Name = "lLogFilePath";
            this.lLogFilePath.Size = new System.Drawing.Size(76, 13);
            this.lLogFilePath.TabIndex = 71;
            this.lLogFilePath.Text = "Log file path:";
            this.lLogFilePath.Visible = false;
            // 
            // lRssi2
            // 
            this.lRssi2.AutoSize = true;
            this.lRssi2.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lRssi2.ForeColor = System.Drawing.Color.White;
            this.lRssi2.Location = new System.Drawing.Point(381, 21);
            this.lRssi2.Name = "lRssi2";
            this.lRssi2.Size = new System.Drawing.Size(39, 13);
            this.lRssi2.TabIndex = 74;
            this.lRssi2.Text = "RSSI-3";
            // 
            // lRssi1
            // 
            this.lRssi1.AutoSize = true;
            this.lRssi1.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lRssi1.ForeColor = System.Drawing.Color.White;
            this.lRssi1.Location = new System.Drawing.Point(330, 21);
            this.lRssi1.Name = "lRssi1";
            this.lRssi1.Size = new System.Drawing.Size(39, 13);
            this.lRssi1.TabIndex = 73;
            this.lRssi1.Text = "RSSI-2";
            // 
            // tbRssi3
            // 
            this.tbRssi3.Enabled = false;
            this.tbRssi3.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRssi3.Location = new System.Drawing.Point(434, 37);
            this.tbRssi3.Name = "tbRssi3";
            this.tbRssi3.Size = new System.Drawing.Size(45, 23);
            this.tbRssi3.TabIndex = 72;
            // 
            // tbRssi2
            // 
            this.tbRssi2.Enabled = false;
            this.tbRssi2.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRssi2.Location = new System.Drawing.Point(383, 37);
            this.tbRssi2.Name = "tbRssi2";
            this.tbRssi2.Size = new System.Drawing.Size(45, 23);
            this.tbRssi2.TabIndex = 71;
            // 
            // tbRssi1
            // 
            this.tbRssi1.Enabled = false;
            this.tbRssi1.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRssi1.Location = new System.Drawing.Point(332, 37);
            this.tbRssi1.Name = "tbRssi1";
            this.tbRssi1.Size = new System.Drawing.Size(45, 23);
            this.tbRssi1.TabIndex = 70;
            // 
            // lVenderSn
            // 
            this.lVenderSn.AutoSize = true;
            this.lVenderSn.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lVenderSn.ForeColor = System.Drawing.Color.White;
            this.lVenderSn.Location = new System.Drawing.Point(8, 19);
            this.lVenderSn.Name = "lVenderSn";
            this.lVenderSn.Size = new System.Drawing.Size(64, 13);
            this.lVenderSn.TabIndex = 64;
            this.lVenderSn.Text = "Vender SN:";
            // 
            // tbRssi0
            // 
            this.tbRssi0.Enabled = false;
            this.tbRssi0.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRssi0.Location = new System.Drawing.Point(281, 37);
            this.tbRssi0.Name = "tbRssi0";
            this.tbRssi0.Size = new System.Drawing.Size(45, 23);
            this.tbRssi0.TabIndex = 69;
            // 
            // tbVenderSn
            // 
            this.tbVenderSn.ForeColor = System.Drawing.Color.Silver;
            this.tbVenderSn.Location = new System.Drawing.Point(10, 36);
            this.tbVenderSn.Name = "tbVenderSn";
            this.tbVenderSn.Size = new System.Drawing.Size(117, 26);
            this.tbVenderSn.TabIndex = 65;
            this.tbVenderSn.Text = "YYMMDLSSSS";
            this.tbVenderSn.Enter += new System.EventHandler(this.tbVenderSn_Enter);
            this.tbVenderSn.Leave += new System.EventHandler(this.tbVenderSn_Leave);
            // 
            // lRssi0
            // 
            this.lRssi0.AutoSize = true;
            this.lRssi0.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lRssi0.ForeColor = System.Drawing.Color.White;
            this.lRssi0.Location = new System.Drawing.Point(279, 21);
            this.lRssi0.Name = "lRssi0";
            this.lRssi0.Size = new System.Drawing.Size(39, 13);
            this.lRssi0.TabIndex = 68;
            this.lRssi0.Text = "RSSI-1";
            // 
            // lDateCode
            // 
            this.lDateCode.AutoSize = true;
            this.lDateCode.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDateCode.ForeColor = System.Drawing.Color.White;
            this.lDateCode.Location = new System.Drawing.Point(131, 19);
            this.lDateCode.Name = "lDateCode";
            this.lDateCode.Size = new System.Drawing.Size(62, 13);
            this.lDateCode.TabIndex = 66;
            this.lDateCode.Text = "Date code:";
            // 
            // tbDateCode
            // 
            this.tbDateCode.ForeColor = System.Drawing.Color.Silver;
            this.tbDateCode.Location = new System.Drawing.Point(133, 36);
            this.tbDateCode.Name = "tbDateCode";
            this.tbDateCode.Size = new System.Drawing.Size(90, 26);
            this.tbDateCode.TabIndex = 67;
            this.tbDateCode.Text = "YYMMDD";
            this.tbDateCode.Enter += new System.EventHandler(this.tbDateCode_Enter);
            this.tbDateCode.Leave += new System.EventHandler(this.tbDateCode_Leave);
            // 
            // lDataPath
            // 
            this.lDataName.AutoSize = true;
            this.lDataName.Font = new System.Drawing.Font("Nirmala UI", 6F, System.Drawing.FontStyle.Bold);
            this.lDataName.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lDataName.Location = new System.Drawing.Point(82, 215);
            this.lDataName.Name = "lDataPath";
            this.lDataName.Size = new System.Drawing.Size(8, 11);
            this.lDataName.TabIndex = 72;
            this.lDataName.Text = "_";
            // 
            // lPathData
            // 
            this.lPathData.AutoSize = true;
            this.lPathData.Font = new System.Drawing.Font("Nirmala UI", 8F, System.Drawing.FontStyle.Bold);
            this.lPathData.ForeColor = System.Drawing.Color.White;
            this.lPathData.Location = new System.Drawing.Point(20, 213);
            this.lPathData.Name = "lPathData";
            this.lPathData.Size = new System.Drawing.Size(64, 13);
            this.lPathData.TabIndex = 71;
            this.lPathData.Text = "DATAROM:";
            // 
            // tbVersionCodeCh1
            // 
            this.tbVersionCodeCh1.Enabled = false;
            this.tbVersionCodeCh1.Font = new System.Drawing.Font("Nirmala UI", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbVersionCodeCh1.Location = new System.Drawing.Point(362, 159);
            this.tbVersionCodeCh1.Name = "tbVersionCodeCh1";
            this.tbVersionCodeCh1.Size = new System.Drawing.Size(50, 18);
            this.tbVersionCodeCh1.TabIndex = 73;
            // 
            // tbVersionCodeCheckCh1
            // 
            this.tbVersionCodeCheckCh1.Enabled = false;
            this.tbVersionCodeCheckCh1.Font = new System.Drawing.Font("Nirmala UI", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbVersionCodeCheckCh1.Location = new System.Drawing.Point(362, 179);
            this.tbVersionCodeCheckCh1.Name = "tbVersionCodeCheckCh1";
            this.tbVersionCodeCheckCh1.Size = new System.Drawing.Size(50, 18);
            this.tbVersionCodeCheckCh1.TabIndex = 74;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 7F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(322, 179);
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
            this.label2.Location = new System.Drawing.Point(319, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 12);
            this.label2.TabIndex = 77;
            this.label2.Text = "Version";
            // 
            // tbVersionCodeCheckCh2
            // 
            this.tbVersionCodeCheckCh2.Enabled = false;
            this.tbVersionCodeCheckCh2.Font = new System.Drawing.Font("Nirmala UI", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbVersionCodeCheckCh2.Location = new System.Drawing.Point(465, 179);
            this.tbVersionCodeCheckCh2.Name = "tbVersionCodeCheckCh2";
            this.tbVersionCodeCheckCh2.Size = new System.Drawing.Size(50, 18);
            this.tbVersionCodeCheckCh2.TabIndex = 79;
            this.tbVersionCodeCheckCh2.Visible = false;
            // 
            // tbVersionCodeCh2
            // 
            this.tbVersionCodeCh2.Enabled = false;
            this.tbVersionCodeCh2.Font = new System.Drawing.Font("Nirmala UI", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbVersionCodeCh2.Location = new System.Drawing.Point(465, 159);
            this.tbVersionCodeCh2.Name = "tbVersionCodeCh2";
            this.tbVersionCodeCh2.Size = new System.Drawing.Size(50, 18);
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
            this.cbSecurityLock.Location = new System.Drawing.Point(365, 0);
            this.cbSecurityLock.Name = "cbSecurityLock";
            this.cbSecurityLock.Size = new System.Drawing.Size(70, 15);
            this.cbSecurityLock.TabIndex = 80;
            this.cbSecurityLock.Text = "SecurityLock";
            this.cbSecurityLock.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(115)))), ((int)(((byte)(138)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(20, 131);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 29);
            this.button1.TabIndex = 81;
            this.button1.Text = "ExportFile";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(115)))), ((int)(((byte)(138)))));
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(102, 131);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(89, 29);
            this.button2.TabIndex = 82;
            this.button2.Text = "WriteFromFile";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // CustomerAndMpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(145)))), ((int)(((byte)(168)))));
            this.ClientSize = new System.Drawing.Size(536, 391);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbSecurityLock);
            this.Controls.Add(this.tbVersionCodeCheckCh2);
            this.Controls.Add(this.tbVersionCodeCh2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbVersionCodeCheckCh1);
            this.Controls.Add(this.tbVersionCodeCh1);
            this.Controls.Add(this.lDataName);
            this.Controls.Add(this.lPathData);
            this.Controls.Add(this.gbOperatorMode);
            this.Controls.Add(this.cbI2cConnect);
            this.Controls.Add(this.cbBypassW);
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
        private System.Windows.Forms.TextBox tbRssi0;
        private System.Windows.Forms.TextBox tbVenderSn;
        private System.Windows.Forms.Label lRssi0;
        private System.Windows.Forms.Label lDateCode;
        private System.Windows.Forms.TextBox tbDateCode;
        private System.Windows.Forms.Label lRssi3;
        private System.Windows.Forms.Label lRssi2;
        private System.Windows.Forms.Label lRssi1;
        private System.Windows.Forms.TextBox tbRssi3;
        private System.Windows.Forms.TextBox tbRssi2;
        private System.Windows.Forms.TextBox tbRssi1;
        private System.Windows.Forms.TextBox tbLogFIlePath;
        private System.Windows.Forms.Label lLogFilePath;
        private System.Windows.Forms.Label lDataName;
        private System.Windows.Forms.Label lPathData;
        private System.Windows.Forms.TextBox tbVersionCodeCh1;
        private System.Windows.Forms.TextBox tbVersionCodeCheckCh1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbVersionCodeCheckCh2;
        private System.Windows.Forms.TextBox tbVersionCodeCh2;
        private System.Windows.Forms.CheckBox cbSecurityLock;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}