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
using System.Data.SqlClient;
using System.ComponentModel;

namespace FodboldFeber.View
{
    /// <summary>
    /// Interaction logic for AdminTools.xaml
    /// </summary>
    public partial class AdminTools : Page
    {
        ShopController shopController = new ShopController();
        public AdminTools()
        {
            InitializeComponent();
        }
        public string Query = "";
        private void CreateProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Connection to the sql database
             string connectionString = "Server=EALSQL1.eal.local; Database=DB2017_A27; User Id= USER_A27; Password=SesamLukOp_27;";
                //Assigns the textbox values to the "Query" variable.
                Query = "insert into Products(ProductID, ProductName, Category, ProductDescription, ProductPrice, AmountInStock, ShippingPrice, Size, DiscountPrice) values('" +this.ProductID.Text+ "','" +this.ProductName.Text+ "','" +this.Category.Text+ "','" +this.ProductDescription.Text+ "','" +this.ProductPrice.Text+ "','" +this.AmountInStock.Text+ "','" +this.ShippingPrice.Text+ "','" +this.Size.Text+ "','" +this.DiscountPrice.Text+ "');";
                SqlConnection con = new SqlConnection(connectionString);
                //Adds the user input for products to the table "Products" in the database
                SqlCommand cmd1 = new SqlCommand(Query, con);
                SqlDataReader myReader;
                con.Open();
                myReader = cmd1.ExecuteReader();
                //Should add the created product to a list - done in the Products class
                shopController.AddProduct();
                MessageBox.Show("Varen er nu tilføjet");
                while (myReader.Read())
                {
                }
                con.Close();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex + "Det virker ikke :(");
            }
        }
        private void ProductName_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            if (textbox.Name == "ProductID" && textbox.Text == "" || textbox.Text == "ProduktID")
            {
                textbox.Text = string.Empty;
            }
            if (textbox.Name == "ProductName" && textbox.Text == "" || textbox.Text == "Produkt navn")
            {
                textbox.Text = string.Empty;
            }
            if (textbox.Name == "ProductDescription" && textbox.Text == "" || textbox.Text == "Produkt beskrivelse")
            {
                textbox.Text = string.Empty;
            }
            if (textbox.Name == "ProductPrice" && textbox.Text == "" || textbox.Text == "Pris")
            {
                textbox.Text = string.Empty;
            }
            if (textbox.Name == "AmountInStock" && textbox.Text == "" || textbox.Text == "Antal på lager")
            {
                textbox.Text = string.Empty;
            }
            if (textbox.Name == "ShippingPrice" && textbox.Text == "" || textbox.Text == "Fragt pris")
            {
                textbox.Text = string.Empty;
            }
            if (textbox.Name == "DiscountPrice" && textbox.Text == "" || textbox.Text == "Tilbuds pris")
            {
                textbox.Text = string.Empty;
            }
            textbox.GotFocus -= ProductName_GotFocus;


        }
        private void ProductName_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Name == "ProductID" && textBox.Text == "")
            {
                textBox.Text = "ProduktID";
            }
            else if (textBox.Name == "ProductName" && textBox.Text == "")
            {
                textBox.Text = "Produkt navn";
            }
            else if (textBox.Name == "ProductDescription" && textBox.Text == "")
            {
                textBox.Text = "Produkt beskrivelse";
            }
            else if (textBox.Name == "ProductPrice" && textBox.Text == "")
            {
                textBox.Text = "Pris";
            }
            else if (textBox.Name == "AmountInStock" && textBox.Text == "")
            {
                textBox.Text = "Antal på lager";
            }
            else if (textBox.Name == "ShippingPrice" && textBox.Text == "")
            {
                textBox.Text = "Fragt pris";
            }
            else if (textBox.Name == "DiscountPrice" && textBox.Text == "")
            {
                textBox.Text = "Tilbuds pris";
            }
            textBox.GotFocus += ProductName_GotFocus;
        }
    }
}
