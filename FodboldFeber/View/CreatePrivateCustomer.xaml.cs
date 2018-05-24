using FodboldFeber.ViewModel;
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
        private CustomerVM customerVM;
        public CreatePrivateCustomer()
        {
            InitializeComponent();
            customerVM = new CustomerVM();
            this.DataContext = customerVM;
            txtbox_name.Text = "Angiv dit fulde navn";
            txtbox_username.Text = "Angiv Brugernavn";
            txtbox_password.Text = "Angiv Kodeord";
            txtbox_phoneNumber.Text = "Angiv Telefonnummer";
            txtbox_email.Text = "Angiv Email";
            txtbox_address.Text = "Angiv Adresse";
        }

        private void CreateUser_Click(object sender, RoutedEventArgs e)
        {
            customerVM.AddPrivateUserControl();
            MessageBox.Show("Du er nu oprettet, Tak for at vise interesse for fodboldfeber :)");
            PrivateCustomerFrame.Content = new Frontpage();
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
            if (textbox.Name == "txtbox_address" && textbox.Text == "" || textbox.Text == "Angiv Adresse")
            {
                textbox.Text = string.Empty;
            }
            if (textbox.Name == "txtbox_phoneNumber" && textbox.Text == "" || textbox.Text == "Angiv Telefonnummer")
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
            else if (textbox.Name == "txtbox_address" && textbox.Text == "")
            {
                textbox.Text = "Angiv Adresse";
            }
            else if (textbox.Name == "txtbox_phoneNumber" && textbox.Text == "")
            {
                textbox.Text = "Angiv Telefonnummer";
            }

            textbox.GotFocus += TextBox_GotFocus;
        }
    }
}
