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
        
        private static LoginVM instance;
        public static LoginVM Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LoginVM();
                }
                return instance;
            }
        }

        private MainWindow mainWindow;
        DataAccess dataAccess = new DataAccess();
        public LoginVM()
        {
            LoginParameters = new Model.Login { Username = "", Password = "" };
        }
        public Model.Login LoginParameters { get; set; }

        //Runs login in DataAccess.cs, and opens the shop after login
        public void InitializeLoginController() 
        {
            dataAccess.InitializeLogin();
        }
        public void UpdateButtonContent()
        {
            mainWindow = MainWindow.Instance;
            if (IsAuthenticated == true)
            {
                mainWindow.Login.Content = "Profil";
            }
        }
    }
}
