using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clinic.Data;
using Clinic.Data.Repositories;
using Clinic.UI.FormHelpers;

namespace Clinic.UI
{
    public partial class LoginForm : Form
    {
        private readonly LoginFormHelper _loginFormHelper;
        private readonly DatabaseManager _databaseManager;
        public LoginForm()
        {
            InitializeComponent();
            _databaseManager = new DatabaseManager();
            _loginFormHelper = new LoginFormHelper();

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (_loginFormHelper.VeryifyLoginFields(textBox_Username_Login.Text, textBox_Password_Login.Text))
            {
                if (cb_AccountTypeLogin.SelectedIndex == 0) //cliente
                {
                    // var clientLoggingIn = _unitOfWork.ClientRepository.GetClientByUsername(textBox_Username_Login.Text);
                    var clientLoggingIn = _databaseManager.ClientLoggingIn(textBox_Username_Login.Text);
                    if (clientLoggingIn != null && clientLoggingIn.Password == textBox_Password_Login.Text)
                    {
                        var form = new ClientViewForm(_databaseManager, clientLoggingIn.Id);
                        form.Show();
                        //Hide();
                        // MessageBox.Show($"Bem vindo {clientLoggingIn.FirstName}!");
                    }
                    else
                    {
                        MessageBox.Show("Introduza um Username e Password validos");
                    }
                    
                }
                else if (cb_AccountTypeLogin.SelectedIndex == 1) //terapeuta
                {
                    // var therapistLoggingIn = _unitOfWork.TherapistRepository.GetTherapistByUsername(textBox_Username_Login.Text);
                    var therapistLoggingIn = _databaseManager.TherapistLoggingIn(textBox_Username_Login.Text);
                    if (therapistLoggingIn != null && therapistLoggingIn.Password == textBox_Password_Login.Text)
                    {
                        var form = new TherapistViewForm(_databaseManager, therapistLoggingIn.Id);
                        form.Show();
                        //Hide();
                    }
                    else
                    {
                        MessageBox.Show("Introduza um Username e Password validos");
                    }
                }  
            }
            else
            {
                MessageBox.Show("Introduza o seu username e password");
            }
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            var registerForm = new RegisterForm(_databaseManager);
            registerForm.Show();
        }
    }
}