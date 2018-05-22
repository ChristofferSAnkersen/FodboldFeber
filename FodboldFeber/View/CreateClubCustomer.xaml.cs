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


namespace FodboldFeber.View
{
    /// <summary>
    /// Interaction logic for CreateClubCustomer.xaml
    /// </summary>
    public partial class CreateClubCustomer : Page
    {
        private CustomerVM customerVM;
        public CreateClubCustomer()
        {
            InitializeComponent();
            customerVM = new CustomerVM();
            this.DataContext = customerVM;
            txtbox_name.Text = "Angiv dit fulde navn";
            txtbox_username.Text = "Angiv Brugernavn";
            txtbox_password.Text = "Angiv Kodeord";
            txtbox_phoneNumber.Text = "Angiv Telefonnummer";
            txtbox_email.Text = "Angiv Email";
            txtbox_clubaddress.Text = "Angiv Adresse";
            txtbox_clubname.Text = "Angiv Klubnavn";
            txtbox_clubposition.Text = "Angiv din position i klubben";
        //  txtbox_city.Text = "Angiv By";
       //   txtbox_postnummer.Text = "Angiv postnummer";



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            customerVM.AddClubUserControl();
            MessageBox.Show("Du er nu oprettet, Tak for at vise interesse for fodboldfeber :)");
        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            if (textbox.Name == "txtbox_name" && textbox.Text == "" || textbox.Text == "Angiv dit fulde navn")
            {
                textbox.Text = string.Empty;
            }
            if (textbox.Name == "txtbox_email" && textbox.Text == "" || textbox.Text == "Angiv Email")
            {
                textbox.Text = string.Empty;
            }
            if (textbox.Name == "txtbox_username" && textbox.Text == "" || textbox.Text == "Angiv Brugernavn")
            {
                textbox.Text = string.Empty;
            }
            if (textbox.Name == "txtbox_password" && textbox.Text == "" || textbox.Text == "Angiv Kodeord")
            {
                textbox.Text = string.Empty;
            }
            if (textbox.Name == "txtbox_phoneNumber" && textbox.Text == "" || textbox.Text == "Angiv Telefonnummer")
            {
                textbox.Text = string.Empty;
            }
            if (textbox.Name == "txtbox_clubname" && textbox.Text == "" || textbox.Text == "Angiv Klubnavn")
            {
                textbox.Text = string.Empty;
            }
            if (textbox.Name == "txtbox_clubposition" && textbox.Text == "" || textbox.Text == "Angiv din position i klubben")
            {
                textbox.Text = string.Empty;
            }
            if (textbox.Name == "txtbox_clubaddress" && textbox.Text == "" || textbox.Text == "Angiv Adresse")
            {
                textbox.Text = string.Empty;
            }
        

            textbox.GotFocus -= TextBox_GotFocus;
        }
        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            if (textbox.Name == "txtbox_name" && textbox.Text == "")
            {
                textbox.Text = "Angiv dit fulde navn";
            }
            else if (textbox.Name == "txtbox_email" && textbox.Text == "")
            {
                textbox.Text = "Angiv Email";
            }
            else if (textbox.Name == "txtbox_username" && textbox.Text == "")
            {
                textbox.Text = "Angiv Brugernavn";
            }
            else if (textbox.Name == "txtbox_password" && textbox.Text == "")
            {
                textbox.Text = "Angiv Kodeord";
            }
            else if (textbox.Name == "txtbox_phonenumber" && textbox.Text == "")
            {
                textbox.Text = "Angiv Telefonnummer";
            }
            else if (textbox.Name == "txtbox_clubname" && textbox.Text == "")
            {
                textbox.Text = "Angiv Klubnavn";
            }
            else if (textbox.Name == "txtbox_clubposition" && textbox.Text == "")
            {
                textbox.Text = "Angiv din position i klubben";
            }
            else if (textbox.Name == "txtbox_clubaddress" && textbox.Text == "")
            {
                textbox.Text = "Angiv Adresse";
            }
            textbox.GotFocus += TextBox_GotFocus;
        }
    }
}
