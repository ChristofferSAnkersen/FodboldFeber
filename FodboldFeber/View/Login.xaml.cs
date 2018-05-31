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
        
        private CustomerVM customerVM;
        private LoginVM loginVM;
        private MainWindow mainWindow;
   
        public Login()
        {
            InitializeComponent();
            customerVM = CustomerVM.Instance;
            loginVM = LoginVM.Instance;
        }

        
        private void BtnInitlogInClick(object sender, RoutedEventArgs e)
        {
            loginVM.InitializeLoginController();
            if (loginVM.IsAuthenticated == true)
            {
                loginVM.UpdateButtonContent();
                mainWindow = MainWindow.Instance;
                mainWindow.Login.Content = "Profil";
                Frontpage page = new Frontpage();
                NavigationService.Navigate(page);
            }
        }
       
        //Page navigation
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




