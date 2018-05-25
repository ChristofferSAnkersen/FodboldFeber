using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FodboldFeber.View
{
    /// <summary>
    /// Interaction logic for ChooseType.xaml
    /// </summary>
    public partial class ChooseType : Page
    {
        //Handles the navigation between the different customer types.
        public ChooseType()
        {
            InitializeComponent();
        }

        private void BtnLogInPrivateClick(object sender, RoutedEventArgs e)
        {         
            CreatePrivateCustomer page = new CreatePrivateCustomer();
            NavigationService.Navigate(page);
        }

        private void BtnLogInClubClick(object sender, RoutedEventArgs e)
        {
            CreateClubCustomer page = new CreateClubCustomer();
            NavigationService.Navigate(page);
            
        }

        private void BtnLogInCompanyClick(object sender, RoutedEventArgs e)
        {
            CreateCompanyCustomer page = new CreateCompanyCustomer();
            NavigationService.Navigate(page);
        }
    }
}
