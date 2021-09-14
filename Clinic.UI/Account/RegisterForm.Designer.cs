using System.ComponentModel;

namespace Clinic.UI
{
    partial class RegisterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.cb_AccountTypeRegister = new System.Windows.Forms.ComboBox();
            this.grpBox_Register = new System.Windows.Forms.GroupBox();
            this.btn_CreateAccount = new System.Windows.Forms.Button();
            this.lb_PasswordTherapistRegister = new System.Windows.Forms.Label();
            this.lb_UsernameTherapistRegister = new System.Windows.Forms.Label();
            this.lb_LastNameTherapist = new System.Windows.Forms.Label();
            this.lb_FirstNameTherapist = new System.Windows.Forms.Label();
            this.textBox_Register_Password = new System.Windows.Forms.TextBox();
            this.textBox_Register_Username = new System.Windows.Forms.TextBox();
            this.textBox_Register_LastName = new System.Windows.Forms.TextBox();
            this.textBox_Register_FirstName = new System.Windows.Forms.TextBox();
            this.grpBox_Register.SuspendLayout();
            this.SuspendLayout();
            // 
            // cb_AccountTypeRegister
            // 
            this.cb_AccountTypeRegister.FormattingEnabled = true;
            this.cb_AccountTypeRegister.Items.AddRange(new object[] { "Cliente", "Terapeuta" });
            this.cb_AccountTypeRegister.Location = new System.Drawing.Point(94, 36);
            this.cb_AccountTypeRegister.Name = "cb_AccountTypeRegister";
            this.cb_AccountTypeRegister.Size = new System.Drawing.Size(659, 21);
            this.cb_AccountTypeRegister.TabIndex = 0;
            this.cb_AccountTypeRegister.Text = "Escolha o tipo de conta que quer criar";
            // 
            // grpBox_Register
            // 
            this.grpBox_Register.Controls.Add(this.btn_CreateAccount);
            this.grpBox_Register.Controls.Add(this.lb_PasswordTherapistRegister);
            this.grpBox_Register.Controls.Add(this.lb_UsernameTherapistRegister);
            this.grpBox_Register.Controls.Add(this.lb_LastNameTherapist);
            this.grpBox_Register.Controls.Add(this.lb_FirstNameTherapist);
            this.grpBox_Register.Controls.Add(this.textBox_Register_Password);
            this.grpBox_Register.Controls.Add(this.textBox_Register_Username);
            this.grpBox_Register.Controls.Add(this.textBox_Register_LastName);
            this.grpBox_Register.Controls.Add(this.textBox_Register_FirstName);
            this.grpBox_Register.Location = new System.Drawing.Point(94, 79);
            this.grpBox_Register.Name = "grpBox_Register";
            this.grpBox_Register.Size = new System.Drawing.Size(659, 328);
            this.grpBox_Register.TabIndex = 1;
            this.grpBox_Register.TabStop = false;
            this.grpBox_Register.Text = "Nova Conta";
            // 
            // btn_CreateAccount
            // 
            this.btn_CreateAccount.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_CreateAccount.Location = new System.Drawing.Point(3, 253);
            this.btn_CreateAccount.Name = "btn_CreateAccount";
            this.btn_CreateAccount.Size = new System.Drawing.Size(653, 72);
            this.btn_CreateAccount.TabIndex = 7;
            this.btn_CreateAccount.Text = "Criar Conta";
            this.btn_CreateAccount.UseVisualStyleBackColor = true;
            this.btn_CreateAccount.Click += new System.EventHandler(this.btn_CreateAccount_Click);
            // 
            // lb_PasswordTherapistRegister
            // 
            this.lb_PasswordTherapistRegister.Location = new System.Drawing.Point(25, 143);
            this.lb_PasswordTherapistRegister.Name = "lb_PasswordTherapistRegister";
            this.lb_PasswordTherapistRegister.Size = new System.Drawing.Size(100, 14);
            this.lb_PasswordTherapistRegister.TabIndex = 6;
            this.lb_PasswordTherapistRegister.Text = "Password";
            // 
            // lb_UsernameTherapistRegister
            // 
            this.lb_UsernameTherapistRegister.Location = new System.Drawing.Point(25, 103);
            this.lb_UsernameTherapistRegister.Name = "lb_UsernameTherapistRegister";
            this.lb_UsernameTherapistRegister.Size = new System.Drawing.Size(100, 14);
            this.lb_UsernameTherapistRegister.TabIndex = 5;
            this.lb_UsernameTherapistRegister.Text = "Username";
            // 
            // lb_LastNameTherapist
            // 
            this.lb_LastNameTherapist.Location = new System.Drawing.Point(25, 57);
            this.lb_LastNameTherapist.Name = "lb_LastNameTherapist";
            this.lb_LastNameTherapist.Size = new System.Drawing.Size(100, 14);
            this.lb_LastNameTherapist.TabIndex = 4;
            this.lb_LastNameTherapist.Text = "Ultimo Nome";
            // 
            // lb_FirstNameTherapist
            // 
            this.lb_FirstNameTherapist.Location = new System.Drawing.Point(25, 16);
            this.lb_FirstNameTherapist.Name = "lb_FirstNameTherapist";
            this.lb_FirstNameTherapist.Size = new System.Drawing.Size(100, 14);
            this.lb_FirstNameTherapist.TabIndex = 3;
            this.lb_FirstNameTherapist.Text = "Primeiro Nome";
            // 
            // textBox_Register_Password
            // 
            this.textBox_Register_Password.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Register_Password.Location = new System.Drawing.Point(25, 162);
            this.textBox_Register_Password.Name = "textBox_Register_Password";
            this.textBox_Register_Password.PasswordChar = '*';
            this.textBox_Register_Password.Size = new System.Drawing.Size(628, 20);
            this.textBox_Register_Password.TabIndex = 2;
            // 
            // textBox_Register_Username
            // 
            this.textBox_Register_Username.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Register_Username.Location = new System.Drawing.Point(25, 120);
            this.textBox_Register_Username.Name = "textBox_Register_Username";
            this.textBox_Register_Username.Size = new System.Drawing.Size(628, 20);
            this.textBox_Register_Username.TabIndex = 2;
            // 
            // textBox_Register_LastName
            // 
            this.textBox_Register_LastName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Register_LastName.Location = new System.Drawing.Point(25, 74);
            this.textBox_Register_LastName.Name = "textBox_Register_LastName";
            this.textBox_Register_LastName.Size = new System.Drawing.Size(628, 20);
            this.textBox_Register_LastName.TabIndex = 1;
            // 
            // textBox_Register_FirstName
            // 
            this.textBox_Register_FirstName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Register_FirstName.Location = new System.Drawing.Point(25, 33);
            this.textBox_Register_FirstName.Name = "textBox_Register_FirstName";
            this.textBox_Register_FirstName.Size = new System.Drawing.Size(628, 20);
            this.textBox_Register_FirstName.TabIndex = 0;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 561);
            this.Controls.Add(this.grpBox_Register);
            this.Controls.Add(this.cb_AccountTypeRegister);
            this.Name = "RegisterForm";
            this.Text = "RegisterForm";
            this.grpBox_Register.ResumeLayout(false);
            this.grpBox_Register.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TextBox textBox_Register_FirstName;

        private System.Windows.Forms.TextBox textBox_Register_Password;
        private System.Windows.Forms.TextBox textBox_Register_LastName;
        private System.Windows.Forms.TextBox textBox_Register_Username;

        private System.Windows.Forms.Button btn_CreateAccount;

        private System.Windows.Forms.GroupBox grpBox_Register;

        private System.Windows.Forms.Button btn_CreateAccountTherapist;

        private System.Windows.Forms.Button btn_RegisterTherapist;
        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.Label lb_LastNameTherapist;
        private System.Windows.Forms.Label lb_UsernameTherapistRegister;
        private System.Windows.Forms.Label lb_PasswordTherapistRegister;
        private System.Windows.Forms.Button bt_;
        private System.Windows.Forms.Label lb_FirstNameTherapist;

        private System.Windows.Forms.ComboBox cb_AccountTypeRegister;

        private System.Windows.Forms.ComboBox comboBox1;

        #endregion
    }
}