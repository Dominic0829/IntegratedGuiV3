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
            this.bLogin = new System.Windows.Forms.Button();
            this.tbId = new System.Windows.Forms.TextBox();
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
            // bLogin
            // 
            this.bLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(115)))), ((int)(((byte)(138)))));
            this.bLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bLogin.FlatAppearance.BorderSize = 0;
            this.bLogin.Font = new System.Drawing.Font("Nirmala UI", 16F, System.Drawing.FontStyle.Bold);
            this.bLogin.ForeColor = System.Drawing.Color.White;
            this.bLogin.Location = new System.Drawing.Point(20, 113);
            this.bLogin.Name = "bLogin";
            this.bLogin.Size = new System.Drawing.Size(76, 53);
            this.bLogin.TabIndex = 44;
            this.bLogin.Text = "Start";
            this.bLogin.UseVisualStyleBackColor = false;
            this.bLogin.Click += new System.EventHandler(this.bLogin_Click);
            // 
            // tbId
            // 
            this.tbId.BackColor = System.Drawing.Color.White;
            this.tbId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbId.Font = new System.Drawing.Font("Nirmala UI", 14F);
            this.tbId.Location = new System.Drawing.Point(20, 45);
            this.tbId.Multiline = true;
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(281, 30);
            this.tbId.TabIndex = 43;
            // 
            // lFilePath
            // 
            this.lFilePath.AutoSize = true;
            this.lFilePath.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lFilePath.ForeColor = System.Drawing.Color.White;
            this.lFilePath.Location = new System.Drawing.Point(16, 23);
            this.lFilePath.Name = "lFilePath";
            this.lFilePath.Size = new System.Drawing.Size(70, 19);
            this.lFilePath.TabIndex = 42;
            this.lFilePath.Text = "File path:";
            // 
            // lLogin
            // 
            this.lLogin.AutoSize = true;
            this.lLogin.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(72)))), ((int)(((byte)(91)))));
            this.lLogin.Location = new System.Drawing.Point(98, -3);
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
            this.cProgressBar1.Location = new System.Drawing.Point(317, 38);
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
            this.rbSingle.Location = new System.Drawing.Point(102, 113);
            this.rbSingle.Name = "rbSingle";
            this.rbSingle.Size = new System.Drawing.Size(68, 23);
            this.rbSingle.TabIndex = 49;
            this.rbSingle.TabStop = true;
            this.rbSingle.Text = "Single";
            this.rbSingle.UseVisualStyleBackColor = true;
            this.rbSingle.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // rbBoth
            // 
            this.rbBoth.AutoSize = true;
            this.rbBoth.Location = new System.Drawing.Point(102, 136);
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
            this.cProgressBar2.Location = new System.Drawing.Point(423, 38);
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
            this.lCh1Message.Font = new System.Drawing.Font("Nirmala UI", 8F, System.Drawing.FontStyle.Bold);
            this.lCh1Message.ForeColor = System.Drawing.Color.White;
            this.lCh1Message.Location = new System.Drawing.Point(313, 139);
            this.lCh1Message.Name = "lCh1Message";
            this.lCh1Message.Size = new System.Drawing.Size(16, 13);
            this.lCh1Message.TabIndex = 52;
            this.lCh1Message.Text = "...";
            // 
            // lCh2Message
            // 
            this.lCh2Message.AutoSize = true;
            this.lCh2Message.Font = new System.Drawing.Font("Nirmala UI", 8F, System.Drawing.FontStyle.Bold);
            this.lCh2Message.ForeColor = System.Drawing.Color.White;
            this.lCh2Message.Location = new System.Drawing.Point(418, 139);
            this.lCh2Message.Name = "lCh2Message";
            this.lCh2Message.Size = new System.Drawing.Size(16, 13);
            this.lCh2Message.TabIndex = 53;
            this.lCh2Message.Text = "...";
            this.lCh2Message.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lCh1EC
            // 
            this.lCh1EC.AutoSize = true;
            this.lCh1EC.Font = new System.Drawing.Font("Nirmala UI", 8F, System.Drawing.FontStyle.Bold);
            this.lCh1EC.ForeColor = System.Drawing.Color.White;
            this.lCh1EC.Location = new System.Drawing.Point(401, 35);
            this.lCh1EC.Name = "lCh1EC";
            this.lCh1EC.Size = new System.Drawing.Size(16, 13);
            this.lCh1EC.TabIndex = 54;
            this.lCh1EC.Text = "...";
            // 
            // lCh2EC
            // 
            this.lCh2EC.AutoSize = true;
            this.lCh2EC.Font = new System.Drawing.Font("Nirmala UI", 8F, System.Drawing.FontStyle.Bold);
            this.lCh2EC.ForeColor = System.Drawing.Color.White;
            this.lCh2EC.Location = new System.Drawing.Point(508, 35);
            this.lCh2EC.Name = "lCh2EC";
            this.lCh2EC.Size = new System.Drawing.Size(16, 13);
            this.lCh2EC.TabIndex = 55;
            this.lCh2EC.Text = "...";
            // 
            // lProduct
            // 
            this.lProduct.AutoSize = true;
            this.lProduct.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lProduct.ForeColor = System.Drawing.Color.White;
            this.lProduct.Location = new System.Drawing.Point(151, 78);
            this.lProduct.Name = "lProduct";
            this.lProduct.Size = new System.Drawing.Size(66, 19);
            this.lProduct.TabIndex = 56;
            this.lProduct.Text = "Product:";
            // 
            // lMode
            // 
            this.lMode.AutoSize = true;
            this.lMode.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lMode.ForeColor = System.Drawing.Color.White;
            this.lMode.Location = new System.Drawing.Point(16, 78);
            this.lMode.Name = "lMode";
            this.lMode.Size = new System.Drawing.Size(52, 19);
            this.lMode.TabIndex = 57;
            this.lMode.Text = "Mode:";
            // 
            // CustomerAndMpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(145)))), ((int)(((byte)(168)))));
            this.ClientSize = new System.Drawing.Size(536, 176);
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
            this.Controls.Add(this.bLogin);
            this.Controls.Add(this.tbId);
            this.Controls.Add(this.lFilePath);
            this.Controls.Add(this.lLogin);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "CustomerAndMpForm";
            this.Palette = this.kryptonPalette1;
            this.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPalette kryptonPalette1;
        private System.Windows.Forms.Button bLogin;
        private System.Windows.Forms.TextBox tbId;
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
    }
}