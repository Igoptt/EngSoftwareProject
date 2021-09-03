using System;
using System.Windows.Forms;
using Clinic.Data.Repositories;
using Clinic.UI.DTO;
using Clinic.UI.FormHelpers;

namespace Clinic.UI
{
    public partial class RegisterForm : Form
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly RegisterFormHelper _registerFormHelper;

        public RegisterForm(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _registerFormHelper = new RegisterFormHelper();
            InitializeComponent();
        }
       

        private void btn_CreateAccount_Click(object sender, EventArgs e)
        {
            
                if (_registerFormHelper.VeryifyRegisterFields(textBox_Register_FirstName.Text,textBox_Register_LastName.Text,textBox_Register_Username.Text,textBox_Register_Password.Text))
                {
                    if (cb_AccountTypeRegister.SelectedIndex == 0) //cliente
                    {
                        var clientDto = new ClientDto
                        {
                            FirstName = textBox_Register_FirstName.Text,
                            LastName = textBox_Register_LastName.Text,
                            Username = textBox_Register_Username.Text,
                            Password = textBox_Register_Password.Text
                        };
                        
                        _unitOfWork.ClientRepository.Insert(clientDto.MapToClientDb());
                        MessageBox.Show($@"Conta criada! Bem vindo {clientDto.FirstName}");
                        this.Close();
                        var form = new ClientViewForm(_unitOfWork);
                        form.Show();

                    }
                    else if (cb_AccountTypeRegister.SelectedIndex == 1)//terapeuta
                    {
                        var therapistDto = new TherapistDto
                        {
                            FirstName = textBox_Register_FirstName.Text,
                            LastName = textBox_Register_LastName.Text,
                            Username = textBox_Register_Username.Text,
                            Password = textBox_Register_Password.Text
                        };
                        
                        _unitOfWork.TherapistRepository.Insert(therapistDto.MapToTherapistDb());
                        MessageBox.Show($@"Conta criada! Bem vindo {therapistDto.FirstName}");
                        this.Close();
                        var form = new TherapistViewForm(_unitOfWork);
                        form.Show();
                        
                    } 
                }
                else
                {
                    MessageBox.Show(@"Todos os campos devem estar preênchidos.");
                }
            
        }

        
        


    }
}