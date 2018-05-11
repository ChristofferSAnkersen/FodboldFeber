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
using FodboldFeber.Controller;


namespace FodboldFeber.View
{
    /// <summary>
    /// Interaction logic for CreateClubCustomer.xaml
    /// </summary>
    public partial class CreateClubCustomer : Page
    {
        private CustomerController customerController;
        public CreateClubCustomer()
        {
            InitializeComponent();
            customerController = new CustomerController();
            this.DataContext = customerController;
            txtbox_name.Text = "Angiv dit fuldnavn";
            txtbox_username.Text = "Angiv Brugernavn";
            txtbox_password.Text = "Angiv Kodeord";
            txtbox_phoneNumber.Text = "Angiv Telefonnummer";
            txtbox_email.Text = "Angiv Email";
            txtbox_clubaddress.Text = "Angiv Adresse";
            txtbox_clubname.Text = "Angv Klubnavn";
            txtbox_clubposition.Text = "Angiv din position in klubben";
        //  txtbox_city.Text = "Angiv By";
       //   txtbox_postnummer.Text = "Angiv postnummer";



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            customerController.AddClubUserControl();
            MessageBox.Show("Du er nu oprettet, Tak for at vise interesse for fodboldfeber :)");
        }
    }
}
