namespace Clinic.UI
{
    partial class LoginForm
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
            this.btn_register = new System.Windows.Forms.Button();
            this.btn_login = new System.Windows.Forms.Button();
            this.cb_AccountTypeLogin = new System.Windows.Forms.ComboBox();
            this.textBox_Username_Login = new System.Windows.Forms.TextBox();
            this.textBox_Password_Login = new System.Windows.Forms.TextBox();
            this.label_Username = new System.Windows.Forms.Label();
            this.label_Password = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_register
            // 
            this.btn_register.Location = new System.Drawing.Point(290, 301);
            this.btn_register.Name = "btn_register";
            this.btn_register.Size = new System.Drawing.Size(238, 39);
            this.btn_register.TabIndex = 0;
            this.btn_register.Text = "Criar Conta";
            this.btn_register.UseVisualStyleBackColor = true;
            this.btn_register.Click += new System.EventHandler(this.btn_register_Click);
            // 
            // btn_login
            // 
            this.btn_login.Location = new System.Drawing.Point(290, 222);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(238, 64);
            this.btn_login.TabIndex = 0;
            this.btn_login.Text = "Login";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // cb_AccountTypeLogin
            // 
            this.cb_AccountTypeLogin.FormattingEnabled = true;
            this.cb_AccountTypeLogin.Items.AddRange(new object[] { "Cliente", "Terapeuta" });
            this.cb_AccountTypeLogin.Location = new System.Drawing.Point(289, 82);
            this.cb_AccountTypeLogin.Name = "cb_AccountTypeLogin";
            this.cb_AccountTypeLogin.Size = new System.Drawing.Size(239, 21);
            this.cb_AccountTypeLogin.TabIndex = 1;
            this.cb_AccountTypeLogin.Text = "Escolha o tipo de conta";
            // 
            // textBox_Username_Login
            // 
            this.textBox_Username_Login.Location = new System.Drawing.Point(289, 133);
            this.textBox_Username_Login.Name = "textBox_Username_Login";
            this.textBox_Username_Login.Size = new System.Drawing.Size(239, 20);
            this.textBox_Username_Login.TabIndex = 2;
            // 
            // textBox_Password_Login
            // 
            this.textBox_Password_Login.Location = new System.Drawing.Point(290, 182);
            this.textBox_Password_Login.Name = "textBox_Password_Login";
            this.textBox_Password_Login.PasswordChar = '*';
            this.textBox_Password_Login.Size = new System.Drawing.Size(238, 20);
            this.textBox_Password_Login.TabIndex = 3;
            // 
            // label_Username
            // 
            this.label_Username.Location = new System.Drawing.Point(289, 106);
            this.label_Username.Name = "label_Username";
            this.label_Username.Size = new System.Drawing.Size(112, 24);
            this.label_Username.TabIndex = 4;
            this.label_Username.Text = "Username";
            // 
            // label_Password
            // 
            this.label_Password.Location = new System.Drawing.Point(290, 156);
            this.label_Password.Name = "label_Password";
            this.label_Password.Size = new System.Drawing.Size(112, 24);
            this.label_Password.TabIndex = 5;
            this.label_Password.Text = "Password";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label_Password);
            this.Controls.Add(this.label_Username);
            this.Controls.Add(this.textBox_Password_Login);
            this.Controls.Add(this.textBox_Username_Login);
            this.Controls.Add(this.cb_AccountTypeLogin);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.btn_register);
            this.Name = "LoginForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label_Username;
        private System.Windows.Forms.Label label_Password;

        private System.Windows.Forms.TextBox textBox_Username_Login;
        private System.Windows.Forms.TextBox textBox_Password_Login;

        private System.Windows.Forms.ComboBox cb_AccountTypeLogin;

        private System.Windows.Forms.Button btn_register;
        private System.Windows.Forms.Button btn_login;

        #endregion
    }
}