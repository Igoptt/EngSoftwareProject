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
        private readonly DatabaseContext _databaseContext;
        private readonly UnitOfWork _unitOfWork;
        private readonly LoginFormHelper _loginFormHelper;

        public LoginForm()
        {
            InitializeComponent();
            _databaseContext = new DatabaseContext();
            _databaseContext.LoadDatabase();
            _unitOfWork = new UnitOfWork(_databaseContext);
            _loginFormHelper = new LoginFormHelper();

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (_loginFormHelper.VeryifyLoginFields(textBox_Username_Login.Text, textBox_Password_Login.Text))
            {
                if (cb_AccountTypeLogin.SelectedIndex == 0) //cliente
                {
                    var clientLoggingIn = _unitOfWork.ClientRepository.GetClientByUsername(textBox_Username_Login.Text);
                    if (clientLoggingIn != null && clientLoggingIn.Password == textBox_Password_Login.Text)
                    {
                        var form = new ClientViewForm(_unitOfWork, clientLoggingIn.Id);
                        form.Show();
                        MessageBox.Show($"Bem vindo {clientLoggingIn.FirstName}!");
                    }
                    else
                    {
                        MessageBox.Show("Introduza um Username e Password validos");
                    }
                    


                }
                else if (cb_AccountTypeLogin.SelectedIndex == 1) //terapeuta
                {
                    var form = new TherapistViewForm(_unitOfWork);
                    form.Show();
                }  
            }
            else
            {
                MessageBox.Show("Introduza o seu username e password");
            }
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            var registerForm = new RegisterForm(_unitOfWork);
            registerForm.Show();
        }
    }
}