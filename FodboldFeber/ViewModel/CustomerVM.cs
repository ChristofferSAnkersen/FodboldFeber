using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FodboldFeber.Model;

namespace FodboldFeber.ViewModel
{
    class CustomerVM : Customers
    {
        public bool UserIsLoggedIn = false;
        private static CustomerVM instance;
        public static CustomerVM Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CustomerVM();
                }
                return instance;
            }
        }
        public CustomerVM()
        {
            UserName = "Angiv dit fuldenavn";
            Name = "Angiv brugernavn";
            Address = "Angiv adresse";
            Password = "Angiv kodeord";
            PhoneNumber = 0;
            Email = "Angiv email";
            ClubName = "Angiv klubbens navn";
            ClubPosition = "Angiv din position i klubben";
            CompanyName = "Angiv virksomhedens navn";
            CVR= 0;
            CompanyPosition = "Angiv din position i virksomheden ";
            

    }
        public  void AddPrivateUserControl()
        {
            AddPrivateUser();
        }
        public void AddClubUserControl()
        {
            AddClubUser();
        }
        public void AddCompanyUserControl()
        {
            AddCompanyUser();
        }
        public new void CheckIfExist()
        {
            CheckIfUserExists();
        }
        public void UpdateUserControl()
        {
            UpdateUser();
        }
        public void UpdateButtonContent()
        {
            MainWindow mainWindow = new MainWindow();
            if (UserIsLoggedIn == true)
            {
                mainWindow.Login.Content = "Profil";

            }
        }

    }
        
        
}
