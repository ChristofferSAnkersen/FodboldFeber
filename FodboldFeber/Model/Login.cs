using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Data;
using FodboldFeber.ViewModel;

namespace FodboldFeber.Model
{
    class Login : INotifyPropertyChanged
    {
        private static string _username = "";
        private static string _password = "";

        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                if (_username.Equals(value) == false)
                {
                    _username = value;
                    OnPropertyChanged("Username");
                }
            }
        }

        public string Password
        {
            get
            {
                    return _password;
            }
            set
            {
                if (_password.Equals(value) == false)
                {
                    _password = value;
                    OnPropertyChanged("Password");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}