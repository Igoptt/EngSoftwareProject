using Clinic.UI.DTO;

namespace Clinic.UI.FormHelpers
{
    public class RegisterFormHelper
    {
        public bool VerifyRegisterFields(string textBox_FirstName_Text,string textBox_LastName_Text, string textBox_Username_Text, string textBox_Password_Text)
        {
            
            if(string.IsNullOrEmpty(textBox_FirstName_Text) || string.IsNullOrEmpty(textBox_LastName_Text) || string.IsNullOrEmpty(textBox_Username_Text) ||
                string.IsNullOrEmpty(textBox_Password_Text))
            {
                return false;
            }
            return true;
        }

        public ClientDto CreateNewClient(string firstname, string lastname, string username, string password)
        {
            return new ClientDto()
            {
                FirstName = firstname,
                LastName = lastname,
                Username = username,
                Password = password,
            };
        }
        
        public TherapistDto CreateNewTherapist(string firstname, string lastname, string username, string password)
        {
            return new TherapistDto()
            {
                FirstName = firstname,
                LastName = lastname,
                Username = username,
                Password = password,
            };
        }
    }
}