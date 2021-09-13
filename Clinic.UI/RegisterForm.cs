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
        private readonly DatabaseManager _databaseManager;

        public RegisterForm(DatabaseManager databaseManager)
        {
            // _unitOfWork = unitOfWork;
            _databaseManager = databaseManager;
            _registerFormHelper = new RegisterFormHelper();
            InitializeComponent();
        }
       

        private void btn_CreateAccount_Click(object sender, EventArgs e)
        {
            
                if (_registerFormHelper.VerifyRegisterFields(textBox_Register_FirstName.Text,textBox_Register_LastName.Text,textBox_Register_Username.Text,textBox_Register_Password.Text))
                {
                    if (cb_AccountTypeRegister.SelectedIndex == 0) //cliente
                    {
                        var clientDto = _registerFormHelper.CreateNewClient(textBox_Register_FirstName.Text,
                            textBox_Register_LastName.Text, textBox_Register_Username.Text,
                            textBox_Register_Password.Text);
                        
                        // var clientCreatedId = _unitOfWork.ClientRepository.Insert(clientDto.MapToClientDb());
                        var clientCreatedId = _databaseManager.InsertNewClient(clientDto);
                        this.Close();
                        var form = new ClientViewForm(_databaseManager, clientCreatedId);
                        form.Show();

                    }
                    else if (cb_AccountTypeRegister.SelectedIndex == 1)//terapeuta
                    {
                        var therapistDto = _registerFormHelper.CreateNewTherapist(textBox_Register_FirstName.Text,
                            textBox_Register_LastName.Text, textBox_Register_Username.Text,
                            textBox_Register_Password.Text);
                        // var therapistCreatedId = _unitOfWork.TherapistRepository.Insert(therapistDto.MapToTherapistDb());
                        var therapistCreatedId = _databaseManager.InsertNewTherapist(therapistDto);
                        this.Close();
                        var form = new TherapistViewForm(_databaseManager, therapistCreatedId);
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