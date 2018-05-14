using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FodboldFeber.Model
{
    class Authenticated : INotifyPropertyChanged
    {
        private bool _isAuthenticated = false;
        public bool IsAuthenticated
        {
            get
            {
                return _isAuthenticated;
            }
            set
            {
                if (_isAuthenticated.Equals(value) == false)
                {
                    _isAuthenticated = true;
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
