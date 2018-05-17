using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using FodboldFeber.ViewModel;
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
    /// Interaction logic for CreateCompanyCustomer.xaml
    /// </summary>
    public partial class CreateCompanyCustomer : Page
    {
        private CustomerVM customerVM;
        public CreateCompanyCustomer()
        {   
            InitializeComponent();
            customerVM = new CustomerVM();
            this.DataContext = customerVM;
            txtbox_name.Text = "Angiv dit fuldnavn";
            txtbox_username.Text = "Angiv Brugernavn";
            txtbox_password.Text = "Angiv Kodeord";
            txtbox_phonenumber.Text = "Angiv Telefonnummer";
            txtbox_email.Text = "Angiv Email";
            txtbox_companyaddress.Text = "Angiv Adresse";
            txtbox_companyname.Text = "Angv Klubnavn";
            txtbox_companyposition.Text = "Angiv din position in klubben";
            //txtbox_city.Text = "Angiv By";
            //txtbox_postnummer.Text = "Angiv postnummer";
            txtbox_cvr.Text = "Angiv CVR";



        }

      
            

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            customerVM.AddCompanyUserControl();
            MessageBox.Show("Du er nu oprettet, Tak for at vise interesse for fodboldfeber :)");

        }
    }
}
