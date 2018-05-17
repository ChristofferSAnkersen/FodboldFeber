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
        // CustomerController cController;
        public Login()
        {
            InitializeComponent();
        }
        //private static string connectionString = "Server=EALSQL1.eal.local; Database=DB2017_A27; User Id= USER_A27; Password=SesamLukOp_27;";

        private void btn_logIn_Click(object sender, RoutedEventArgs e)
        {
            lvm.InitializeLoginController();
        }



        private void Button_Click(object sender, RoutedEventArgs e)
            {
                ChooseType page = new ChooseType();
                NavigationService.Navigate(page);
            }
    }
}




