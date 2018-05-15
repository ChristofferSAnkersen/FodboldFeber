using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FodboldFeber.Model;
using FodboldFeber.View;

namespace FodboldFeber.ViewModel
{
    class LoginVM
    {
        DataAccess DA = new DataAccess();
        Authenticated auth = new Authenticated();

        public LoginVM()
        {
            LoginParameters = new Model.Login { Username = "", Password = "" };
        }
        public Model.Login LoginParameters { get; set; }

        public void InitializeLoginController()
        {
            DA.InitializeLogin();
            if (auth.IsAuthenticated == true)
            {
                Shop shop = new Shop();
                shop.Show();
            }
        }    
    }
}
