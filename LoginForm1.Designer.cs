namespace IntegratedGuiV2
{
    partial class LoginForm1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lExit = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bClear = new System.Windows.Forms.Button();
            this.bLogin = new System.Windows.Forms.Button();
            this.cbShowPasswrod = new System.Windows.Forms.CheckBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbId = new System.Windows.Forms.TextBox();
            this.lPassword = new System.Windows.Forms.Label();
            this.lId = new System.Windows.Forms.Label();
            this.lLogin = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lExit);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.bClear);
            this.panel1.Controls.Add(this.bLogin);
            this.panel1.Controls.Add(this.cbShowPasswrod);
            this.panel1.Controls.Add(this.tbPassword);
            this.panel1.Controls.Add(this.tbId);
            this.panel1.Controls.Add(this.lPassword);
            this.panel1.Controls.Add(this.lId);
            this.panel1.Controls.Add(this.lLogin);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 450);
            this.panel1.TabIndex = 0;
            // 
            // lExit
            // 
            this.lExit.AutoSize = true;
            this.lExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lExit.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(183)))), ((int)(((byte)(43)))));
            this.lExit.Location = new System.Drawing.Point(212, 421);
            this.lExit.Name = "lExit";
            this.lExit.Size = new System.Drawing.Size(33, 19);
            this.lExit.TabIndex = 33;
            this.lExit.Text = "Exit";
            this.lExit.Click += new System.EventHandler(this.lExit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(183)))), ((int)(((byte)(43)))));
            this.label2.Location = new System.Drawing.Point(71, 421);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 19);
            this.label2.TabIndex = 32;
            this.label2.Text = "Create Account";
            this.label2.Click += new System.EventHandler(this.lCreateAccount_Click);
            // 
            // bClear
            // 
            this.bClear.BackColor = System.Drawing.Color.White;
            this.bClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(183)))), ((int)(((byte)(43)))));
            this.bClear.Location = new System.Drawing.Point(24, 315);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(200, 36);
            this.bClear.TabIndex = 31;
            this.bClear.Text = "CLEAR";
            this.bClear.UseVisualStyleBackColor = false;
            this.bClear.Click += new System.EventHandler(this.bClear_Click);
            // 
            // bLogin
            // 
            this.bLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(183)))), ((int)(((byte)(43)))));
            this.bLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bLogin.FlatAppearance.BorderSize = 0;
            this.bLogin.ForeColor = System.Drawing.Color.White;
            this.bLogin.Location = new System.Drawing.Point(24, 273);
            this.bLogin.Name = "bLogin";
            this.bLogin.Size = new System.Drawing.Size(200, 36);
            this.bLogin.TabIndex = 30;
            this.bLogin.Text = "LOGIN";
            this.bLogin.UseVisualStyleBackColor = false;
            this.bLogin.Click += new System.EventHandler(this.bLogin_Click);
            // 
            // cbShowPasswrod
            // 
            this.cbShowPasswrod.AutoSize = true;
            this.cbShowPasswrod.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbShowPasswrod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbShowPasswrod.Font = new System.Drawing.Font("Nirmala UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbShowPasswrod.ForeColor = System.Drawing.Color.DarkGray;
            this.cbShowPasswrod.Location = new System.Drawing.Point(119, 220);
            this.cbShowPasswrod.Name = "cbShowPasswrod";
            this.cbShowPasswrod.Size = new System.Drawing.Size(105, 17);
            this.cbShowPasswrod.TabIndex = 29;
            this.cbShowPasswrod.Text = "Show Password";
            this.cbShowPasswrod.UseVisualStyleBackColor = true;
            this.cbShowPasswrod.Click += new System.EventHandler(this.cbShowPasswrod_CheckedChanged);
            // 
            // tbPassword
            // 
            this.tbPassword.BackColor = System.Drawing.Color.White;
            this.tbPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPassword.Font = new System.Drawing.Font("Bodoni MT", 16.2F, System.Drawing.FontStyle.Bold);
            this.tbPassword.Location = new System.Drawing.Point(24, 186);
            this.tbPassword.Multiline = true;
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '•';
            this.tbPassword.Size = new System.Drawing.Size(200, 30);
            this.tbPassword.TabIndex = 28;
            // 
            // tbId
            // 
            this.tbId.BackColor = System.Drawing.Color.White;
            this.tbId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbId.Font = new System.Drawing.Font("Bodoni MT", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbId.Location = new System.Drawing.Point(24, 127);
            this.tbId.Multiline = true;
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(200, 30);
            this.tbId.TabIndex = 27;
            this.tbId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbLogin_KeyDown);
            // 
            // lPassword
            // 
            this.lPassword.AutoSize = true;
            this.lPassword.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPassword.ForeColor = System.Drawing.Color.DarkGray;
            this.lPassword.Location = new System.Drawing.Point(20, 160);
            this.lPassword.Name = "lPassword";
            this.lPassword.Size = new System.Drawing.Size(77, 19);
            this.lPassword.TabIndex = 26;
            this.lPassword.Text = "Passwrod:";
            // 
            // lId
            // 
            this.lId.AutoSize = true;
            this.lId.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lId.ForeColor = System.Drawing.Color.DarkGray;
            this.lId.Location = new System.Drawing.Point(20, 101);
            this.lId.Name = "lId";
            this.lId.Size = new System.Drawing.Size(27, 19);
            this.lId.TabIndex = 25;
            this.lId.Text = "ID:";
            // 
            // lLogin
            // 
            this.lLogin.AutoSize = true;
            this.lLogin.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(132)))), ((int)(((byte)(92)))));
            this.lLogin.Location = new System.Drawing.Point(84, 8);
            this.lLogin.Name = "lLogin";
            this.lLogin.Size = new System.Drawing.Size(87, 32);
            this.lLogin.TabIndex = 24;
            this.lLogin.Text = "LOGIN";
            // 
            // LoginForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(241)))), ((int)(((byte)(212)))));
            this.ClientSize = new System.Drawing.Size(250, 450);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "LoginForm1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginForm1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lExit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bClear;
        private System.Windows.Forms.Button bLogin;
        private System.Windows.Forms.CheckBox cbShowPasswrod;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.Label lPassword;
        private System.Windows.Forms.Label lId;
        private System.Windows.Forms.Label lLogin;
    }
}