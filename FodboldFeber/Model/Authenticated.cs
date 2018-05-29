using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FodboldFeber.Model
{
    //Determines if the user is logged in 
    public class Authenticated : INotifyPropertyChanged
    {
        
        private static bool _isAuthenticated = false;
        public bool IsAuthenticated
        {
            
            get
            {
                return _isAuthenticated;
            }
            set
            {
                if (_isAuthenticated.Equals(value) != value)
                {
                    _isAuthenticated = value;
                    OnPropertyChanged("IsAuthenticated");
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
