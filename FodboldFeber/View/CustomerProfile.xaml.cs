using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Interaction logic for CustomerProfile.xaml
    /// </summary>
    public partial class CustomerProfile : Page
    {

        private CustomerVM customerVM;

        public CustomerProfile()
        {
            InitializeComponent();
            customerVM = CustomerVM.Instance;
            this.DataContext = customerVM;

            GetUserInfo();

            HideEditTxtboxes();
            txtEditName.Text = "Angiv nyt klubnavn";
            txtEditAddress.Text = "Angiv ny adresse";
            txtEditEmail.Text = "Angiv ny email";
            txtEditPhone.Text = "Angiv nyt telefonnummer";

            //btnSave.Visibility = Visibility.Hidden;
            
        }


        //Button that shows the desired textboxes used for editing user info on the profil page
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            ShowEditTxtboxes();
            btnSave.Visibility = Visibility.Visible;
        }

        //Button that hides txtboxes and the button itself after the info has been saved
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            btnSave.Visibility = Visibility.Hidden;
            HideEditTxtboxes();
            MessageBox.Show("Din profil er nu ændret.");
        }

        private void HideEditTxtboxes()
        {
            //Method that hides the textboxes used for editing the concerned user info
            txtEditName.Visibility = Visibility.Hidden;
            txtEditAddress.Visibility = Visibility.Hidden;
            txtEditEmail.Visibility = Visibility.Hidden;
            txtEditPhone.Visibility = Visibility.Hidden;
        }

        private void ShowEditTxtboxes()
        {
            //Method that shows the textboxes used for editing the concerned user info
            txtEditName.Visibility = Visibility.Visible;
            txtEditAddress.Visibility = Visibility.Visible;
            txtEditEmail.Visibility = Visibility.Visible;
            txtEditPhone.Visibility = Visibility.Visible;
        }

        //Methods that clear textboxes when a click is performed inside
        private void txtEditName_GotFocus(object sender, RoutedEventArgs e)
        {
            txtEditName.Text = "";
        }

        private void txtEditAddress_GotFocus(object sender, RoutedEventArgs e)
        {
            txtEditAddress.Text = "";
        }

        private void txtEditEmail_GotFocus(object sender, RoutedEventArgs e)
        {
            txtEditEmail.Text = "";
        }

        private void txtEditPhone_GotFocus(object sender, RoutedEventArgs e)
        {
            txtEditPhone.Text = "";
        }

        //Method that sets content of the current frame to AdminTools

        private void btnAdminTools_Click(object sender, RoutedEventArgs e)
        {
            CustomerProfileFrame.Content = new AdminTools();
        }


        //Sql Query that gets info from Db -> Where username is the content of the label on the profile (which is the username the logged in user)
        private void GetUserInfo()
        {
                try
                {
                    SqlConnection con = new SqlConnection("Server=EALSQL1.eal.local; Database=DB2017_A27; User Id= USER_A27; Password=SesamLukOp_27;");
                    con.Open();
                    string query = "SELECT * from Private_User where username='" + lblName.Content.ToString() + "' ";
                    SqlCommand listCommands = new SqlCommand(query, con);
                    SqlDataReader reader = listCommands.ExecuteReader();

                    while (reader.Read())
                    {
                        //Must assign all column data from the database to variables, so that we can assign the variables to the textboxes, 
                        //so that the textboxes can display the information of the chosen product
                        string ShowName = reader.GetString(2).ToString();
                        string ShowPhoneNumber = reader.GetString(3).ToString();
                        string ShowEmail = reader.GetString(4).ToString();
                        string ShowAddress = reader.GetString(5).ToString();

                        lblPrivateName.Content = ShowName;
                        lblPhone.Content = ShowPhoneNumber;
                        lblEmail.Content = ShowEmail;
                        lblAddress.Content = ShowAddress;

                    }
                    con.Close();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex + "Kunne ikke finde bruger oplysningerne");
                }
        }

    }
}
