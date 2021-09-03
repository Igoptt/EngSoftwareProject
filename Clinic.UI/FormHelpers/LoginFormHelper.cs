namespace Clinic.UI.FormHelpers
{
    public class LoginFormHelper
    {
        
        public LoginFormHelper( )
        {
           
        }
        
        public bool VeryifyLoginFields(string textBox_Username_Text,string textBox_Password_Text)
        {
            
            if(string.IsNullOrEmpty(textBox_Username_Text) || string.IsNullOrEmpty(textBox_Password_Text))
            {
                return false;
            }
            return true;
           
        }
    }
}