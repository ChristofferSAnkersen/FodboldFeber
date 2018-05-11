using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FodboldFeber.Model;

namespace FodboldFeber.Controller
{
    class CustomerController : Users
    {
        public CustomerController()
        {
            UserName = "Angiv dit fuldenavn";
            Name = "Angiv brugernavn";
            Address = "Angiv adresse";
            Password = "Angiv kodeord";
            PhoneNumber = 0;
            Email = "Angiv email";
            ClubAddress = "Angiv Klubadresse";
            ClubName = "Angiv klubbens navn";
            ClubPosition = "Angiv din position i klubben";
            CompanyName = "Angiv virksomhedens navn";
            CompanyAddress = "Angiv virksomhedens adresse";
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


    }
        
        
}
