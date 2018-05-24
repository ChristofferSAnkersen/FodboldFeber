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
using FodboldFeber.ViewModel;
using System.Data.SqlClient;
using FodboldFeber.View;
using System.ComponentModel;
using System.Data;



namespace FodboldFeber.View
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        LoginVM lvm = new LoginVM();
        private CustomerVM customerVM;
        // CustomerController cController;
        public Login()
        {
            InitializeComponent();
            customerVM = CustomerVM.Instance;
        }
        //private static string connectionString = "Server=EALSQL1.eal.local; Database=DB2017_A27; User Id= USER_A27; Password=SesamLukOp_27;";

        public void LoggedIn()
        {
            customerVM.UserIsLoggedIn = true;
        }
        private void BtnInitlogInClick(object sender, RoutedEventArgs e)
        {
            LoggedIn();
            lvm.InitializeLoginController();
            if (lvm.IsAuthenticated == true)
            {
                customerVM.UpdateButtonContent();
                Shop page = new Shop();
                NavigationService.Navigate(page);
            }
        }
       

        private void BtnClickSignIn(object sender, RoutedEventArgs e)
            {
                ChooseType page = new ChooseType();
                NavigationService.Navigate(page);
            }

        private void BtnClickForgotPassword(object sender, RoutedEventArgs e)
        {
            PasswordRecovery page = new PasswordRecovery();
            NavigationService.Navigate(page);
        }
     
    }
}




