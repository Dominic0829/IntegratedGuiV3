namespace IntegratedGuiV2
{
    partial class AdminAuthentication
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminAuthentication));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lBackToLogin = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bCheck = new System.Windows.Forms.Button();
            this.tbAdminPassword = new System.Windows.Forms.TextBox();
            this.lPassword = new System.Windows.Forms.Label();
            this.lAuthentication = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lBackToLogin);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.bCheck);
            this.panel1.Controls.Add(this.tbAdminPassword);
            this.panel1.Controls.Add(this.lPassword);
            this.panel1.Controls.Add(this.lAuthentication);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 178);
            this.panel1.TabIndex = 0;
            // 
            // lBackToLogin
            // 
            this.lBackToLogin.AutoSize = true;
            this.lBackToLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lBackToLogin.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lBackToLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(183)))), ((int)(((byte)(43)))));
            this.lBackToLogin.Location = new System.Drawing.Point(136, 149);
            this.lBackToLogin.Name = "lBackToLogin";
            this.lBackToLogin.Size = new System.Drawing.Size(106, 19);
            this.lBackToLogin.TabIndex = 36;
            this.lBackToLogin.Text = "Back to LOGIN";
            this.lBackToLogin.Click += new System.EventHandler(this.lBackToLogin_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(10, 64);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(75, 81);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 35;
            this.pictureBox1.TabStop = false;
            // 
            // bCheck
            // 
            this.bCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(183)))), ((int)(((byte)(43)))));
            this.bCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bCheck.FlatAppearance.BorderSize = 0;
            this.bCheck.ForeColor = System.Drawing.Color.White;
            this.bCheck.Location = new System.Drawing.Point(91, 109);
            this.bCheck.Name = "bCheck";
            this.bCheck.Size = new System.Drawing.Size(200, 36);
            this.bCheck.TabIndex = 34;
            this.bCheck.Text = "LOGIN";
            this.bCheck.UseVisualStyleBackColor = false;
            this.bCheck.Click += new System.EventHandler(this.bAuthenticate_Click);
            // 
            // tbAdminPassword
            // 
            this.tbAdminPassword.BackColor = System.Drawing.Color.White;
            this.tbAdminPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbAdminPassword.Font = new System.Drawing.Font("Bodoni MT", 16.2F, System.Drawing.FontStyle.Bold);
            this.tbAdminPassword.Location = new System.Drawing.Point(91, 75);
            this.tbAdminPassword.Multiline = true;
            this.tbAdminPassword.Name = "tbAdminPassword";
            this.tbAdminPassword.PasswordChar = '•';
            this.tbAdminPassword.Size = new System.Drawing.Size(200, 30);
            this.tbAdminPassword.TabIndex = 33;
            this.tbAdminPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbAdminPassword_KeyDown);
            // 
            // lPassword
            // 
            this.lPassword.AutoSize = true;
            this.lPassword.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPassword.ForeColor = System.Drawing.Color.DarkGray;
            this.lPassword.Location = new System.Drawing.Point(87, 49);
            this.lPassword.Name = "lPassword";
            this.lPassword.Size = new System.Drawing.Size(77, 19);
            this.lPassword.TabIndex = 32;
            this.lPassword.Text = "Passwrod:";
            // 
            // lAuthentication
            // 
            this.lAuthentication.AutoSize = true;
            this.lAuthentication.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lAuthentication.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(132)))), ((int)(((byte)(92)))));
            this.lAuthentication.Location = new System.Drawing.Point(58, 8);
            this.lAuthentication.Name = "lAuthentication";
            this.lAuthentication.Size = new System.Drawing.Size(184, 32);
            this.lAuthentication.TabIndex = 31;
            this.lAuthentication.Text = "Authentication";
            // 
            // AdminAuthentication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(241)))), ((int)(((byte)(212)))));
            this.ClientSize = new System.Drawing.Size(300, 178);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AdminAuthentication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminAuthentication";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lBackToLogin;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button bCheck;
        private System.Windows.Forms.TextBox tbAdminPassword;
        private System.Windows.Forms.Label lPassword;
        private System.Windows.Forms.Label lAuthentication;
    }
}