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
         
        }
        public  void AddProductControl()
        {
            AddPrivateUser();
        }

    }
        
        
}
