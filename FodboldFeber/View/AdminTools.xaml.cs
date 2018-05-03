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
            ListInCombobox();
        }
        //Connection to the sql database
        string connectionString = "Server=EALSQL1.eal.local; Database=DB2017_A27; User Id= USER_A27; Password=SesamLukOp_27;";

        //Function that makes it possible for the combobox to be filled with already existing items in the database for the user to choose from when deciding what item(s) to delete
        public void ListInCombobox()
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                string DeleteQuery = "SELECT * from Products";
                SqlCommand listCommands = new SqlCommand(DeleteQuery, con);
                SqlDataReader reader = listCommands.ExecuteReader();
              
                while(reader.Read())
                {
                    //Chooses the row that should be the determing factor(displayed in the combobox) it is GetString(1) because 1st collumn in the table is 0, 2nd is 1
                    string ProductNames = reader.GetString(1);
                    ChooseToDelete.Items.Add(ProductNames);
                }
                con.Close();
            }
            catch(SqlException e)
            {
                Console.WriteLine(e + "Listen kunne ikke blive udfyldt");
            }
        }
        public string Query = "";

        private void CreateProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
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
                //Clears the ChooseToDelete combobox 
                ChooseToDelete.Items.Clear();
                //Populates the ChooseToDelete combobox again, including the just added item
                ListInCombobox();
                con.Close();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex + "Varen kunne ikke blive tilføjet");
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


        //Event that determines the content of the textboxes in the update/delete are of "AdminTools"
        private void ChooseToDelete_DropDownClosed(object sender, EventArgs e)
        {
            {
                try
                {
                    SqlConnection con = new SqlConnection(connectionString);
                    con.Open();
                    string DeleteQuery = "SELECT * from Products where ProductName='" + ChooseToDelete.Text + "' ";
                    SqlCommand listCommands = new SqlCommand(DeleteQuery, con);
                    SqlDataReader reader = listCommands.ExecuteReader();

                    while (reader.Read())
                    {
                        //Must assign all column data from the database to variables, so that we can assign the variables to the textboxes, so that the textboxes can display the information of the chosen product
                        string ProductID = reader.GetInt32(0).ToString();
                        string ProductName = reader.GetString(1);
                        string Category = reader.GetString(2);
                        string ProductDescription = reader.GetString(3);
                        string ProductPrice = reader.GetDouble(4).ToString();
                        string AmountInStock = reader.GetInt32(5).ToString();
                        string ShippingPrice = reader.GetDouble(6).ToString();
                        string Size = reader.GetString(7);
                        string DiscountPrice = reader.GetDouble(8).ToString();

                        txb_ProductID.Text = ProductID;
                        txb_ProductName.Text = ProductName;
                        cmb_Category.Text = Category;
                        txb_ProductDescription.Text = ProductDescription;
                        txb_Price.Text = ProductPrice;
                        txb_AmountInStock.Text = AmountInStock;
                        txb_ShippingPrice.Text = ShippingPrice;
                        cmb_Size.Text = Size;
                        txb_DiscountPrice.Text = DiscountPrice;
                    }
                    con.Close();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex + "Listen kunne ikke blive udfyldt");
                }
            }
        }

        //Deletes the values for the a item, determined by the named chosen in the "ChooseToDelete" combobox
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);

            try
            {
                
                con.Open();
                string Query = "delete from Products where ProductName = '" + this.ChooseToDelete.Text + "'";

                
                SqlCommand cmd1 = new SqlCommand(Query, con);
                SqlDataReader myReader;
                myReader = cmd1.ExecuteReader();
                MessageBox.Show("Varen er nu slettet");
                //Clears the ChooseToDelete combobox 
                ChooseToDelete.Items.Clear();
                //Populets the ChooseToDelete combobox again, including the just added item
                ListInCombobox();
                con.Close();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex + "Varen kunne ikke blive slettet");
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Assigns the textbox values to the "Query" variable.

                Query = "Update Products set ProductID='" +this.txb_ProductID.Text+ "', ProductName='"+this.txb_ProductName.Text+"', Category='"+this.cmb_Category.Text+"', ProductDescription='"+this.txb_ProductDescription.Text+"', ProductPrice='"+this.txb_Price.Text+"', AmountInStock='"+this.txb_AmountInStock.Text+"', ShippingPrice='"+this.txb_ShippingPrice.Text+"', Size='"+this.cmb_Size.Text+"', DiscountPrice='"+this.txb_DiscountPrice.Text+"' where ProductName='"+this.ChooseToDelete.Text+"' " ;
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
                //Clears the ChooseToDelete combobox 
                ChooseToDelete.Items.Clear();
                //Populates the ChooseToDelete combobox again, including the just added item
                ListInCombobox();
                con.Close();

            }
            catch(SqlException exe)
            {
                MessageBox.Show(exe + "Varen kunne ikke opdateres");
            }
        }
    }
}
