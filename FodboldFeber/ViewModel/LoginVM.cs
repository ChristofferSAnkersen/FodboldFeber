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
    class LoginVM : Authenticated
    {
        DataAccess dataAccess = new DataAccess();
        public LoginVM()
        {
            LoginParameters = new Model.Login { Username = "", Password = "" };
        }
        public Model.Login LoginParameters { get; set; }

        public void InitializeLoginController() //Kører login i DataAccess.cs, og åbner shoppen efter login -- Skal implementere IsAuthenticated som krav et sted
        {
            dataAccess.InitializeLogin();
            if (IsAuthenticated.Equals(true))
            {
                Shop shop = new Shop();
            }
            
        }    
    }
}
