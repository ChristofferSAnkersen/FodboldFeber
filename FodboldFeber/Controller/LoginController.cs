using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FodboldFeber.Model;

namespace FodboldFeber.Controller
{
    class LoginController
    {
        Login login = new Login();

        public string Username = "";
        public string Password = "";

        public LoginController()
        {
            login.Username = "Brugernavn";
            login.Password = "Kodeord";


        }

        public void InitializeLoginController()
        {
            login.InitializeLogin();
        }

        
    }
}
