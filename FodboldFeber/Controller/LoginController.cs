using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FodboldFeber.Model;
using FodboldFeber.View;

namespace FodboldFeber.Controller
{
    class LoginController
    {
        Model.Login login = new Model.Login();
        Authenticated auth = new Authenticated();

        public LoginController()
        {
            LoginParameters = new Model.Login { Username = "", Password = "" };
        }
        public Model.Login LoginParameters { get; set; }

        public void InitializeLoginController()
        {
            login.InitializeLogin();
            if (auth.IsAuthenticated == true)
            {
                Shop shop = new Shop();
                shop.Show();
            }
        }    
    }
}
