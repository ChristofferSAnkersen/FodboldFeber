using FodboldFeber.Controller;
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
    /// Interaction logic for CreatePrivateCustomer.xaml
    /// </summary>
    public partial class CreatePrivateCustomer : Page
    {
        private CustomerController customerController;
        public CreatePrivateCustomer()
        {
            InitializeComponent();
            customerController = new CustomerController();
            txtbox_name.Text = "Angiv dit fuldnavn";
            txtbox_username.Text = "Angiv Brugernavn";
            txtbox_password.Text = "Angiv Kodeord";
            txtbox_phoneNumber.Text = "Angiv Telefonnummer";
            txtbox_email.Text = "Angiv Email";
            txtbox_address.Text = "Angiv Adresse";

            
        }

        private void CreateUser_Click(object sender, RoutedEventArgs e)
        {
            customerController.AddProductControl();
            MessageBox.Show("Du er nu oprettet, Tak for at vise interesse for fodboldfeber :)");
        }
    }
}
