namespace Clinic.UI.FormHelpers
{
    public class RegisterFormHelper
    {

        
        public RegisterFormHelper( )
        {
        }
        
        public bool VeryifyRegisterFields(string textBox_FirstName_Text,string textBox_LastName_Text, string textBox_Username_Text, string textBox_Password_Text)
        {
            
            if(string.IsNullOrEmpty(textBox_FirstName_Text) || string.IsNullOrEmpty(textBox_LastName_Text) || string.IsNullOrEmpty(textBox_Username_Text) ||
                string.IsNullOrEmpty(textBox_Password_Text))
            {
                return false;
            }
            return true;
           
        }
    }
}