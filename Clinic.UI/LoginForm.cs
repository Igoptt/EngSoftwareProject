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

namespace Clinic.UI
{
    public partial class LoginForm : Form
    {
        private readonly DatabaseContext _databaseContext;
        private readonly UnitOfWork _unitOfWork;    

        public LoginForm()
        {
            InitializeComponent();
            _databaseContext = new DatabaseContext();
            _databaseContext.LoadDatabase();
            _unitOfWork = new UnitOfWork(_databaseContext);

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (cb_AccountTypeLogin.SelectedIndex == 0) //cliente
            {
                var form = new ClientViewForm(_unitOfWork);
                form.Show();
            }
            else if (cb_AccountTypeLogin.SelectedIndex == 1) //terapeuta
            {
                var form = new TherapistViewForm(_unitOfWork);
                form.Show();
            }
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            var registerForm = new RegisterForm(_unitOfWork);
            registerForm.Show();
        }
    }
}