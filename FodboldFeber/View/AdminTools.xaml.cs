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
using FodboldFeber.Controller;

namespace FodboldFeber.View
{
    /// <summary>
    /// Interaction logic for AdminTools.xaml
    /// </summary>
    public partial class AdminTools : Page
    {
        //1st step of converting textbox strings from the UI to integer values
        private int _amountInStock;
        private int _price;
        private int _shippingPrice;
        public AdminTools()
        {
            InitializeComponent();
        }

        private void CreateProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string connectionString = "Server=EALSQL1.eal.local; Database=DB2017_A27; User Id= USER_A27; Password=SesamLukOp_27;";
                string Query = "insert into Products(ProductName, Category, ProductDescription, ProductPrice, AmountInStock, ShippingPrice) values('" + this.ProductName.Text + "','" + this.Category.Text + "','" + this.ProductDescription.Text + "','" + this.ProductPrice.Text + "','" + this.AmountInStock.Text + "','" + this.ShippingPrice.Text + "');";
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd1 = new SqlCommand(Query, con);
                SqlDataReader myReader;
                con.Open();
                myReader = cmd1.ExecuteReader();
                MessageBox.Show("Varen er nu tilføjet");
                while (myReader.Read())
                {
                }
                con.Close();

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex + "Det virker ikke :(");
            }

        }


        private void ProductName_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            string originalText = textbox.Text;
            textbox.Text = string.Empty;
            textbox.GotFocus -= ProductName_GotFocus;
        }
    }
}
