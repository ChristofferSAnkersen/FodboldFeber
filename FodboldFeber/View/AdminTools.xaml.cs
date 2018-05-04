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
        private ShopController shopController;
        public AdminTools()
        {
            InitializeComponent();
            shopController = new ShopController();
            this.DataContext = shopController;
            ProductID.Text = "Vælg produktID";
            ProductPrice.Text = "Angiv pris";
            AmountInStock.Text = "Angiv antal på lager";
            ShippingPrice.Text = "Angiv fragtpris";
            DiscountPrice.Text = "Angiv tilbudspris";
            //ListInCombobox();
        }
        //Connection to the sql database
        string connectionString = "Server=EALSQL1.eal.local; Database=DB2017_A27; User Id= USER_A27; Password=SesamLukOp_27;";

        //Function that makes it possible for the combobox to be filled with already existing items in the database for the user to choose from when deciding what item(s) to delete or update
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
                    //Chooses the row that should be the determing factor(displayed in the combobox) it is GetString(1) because 1st collumn in the table is 0, 2nd is 1...
                    string ProductNames = reader.GetString(1);
                    ChooseItem.Items.Add(ProductNames);
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
            
            //Should add the created product to a list - done in the Products class
            shopController.AddProductControl();
            MessageBox.Show("Varen er nu tilføjet");

            //Clears the ChooseItem combobox
                ChooseItem.Items.Clear();
            //Populates the ChooseItem combobox again, including the just added item
                ListInCombobox();

        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
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
            textbox.GotFocus -= TextBox_GotFocus;


        } //Determines what happens when textboxes are focused
        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            if (textbox.Name == "ProductID" && textbox.Text == "" || textbox.Name == "txb_ProductID" && textbox.Text == "")
            {
                textbox.Text = "ProduktID";
            }
            else if (textbox.Name == "ProductName" && textbox.Text == "" || textbox.Name == "txb_ProductName" && textbox.Text == "")
            {
                textbox.Text = "Produkt navn";
            }
            else if (textbox.Name == "ProductDescription" && textbox.Text == "" || textbox.Name == "txb_ProductDescription" && textbox.Text == "")
            {
                textbox.Text = "Produkt beskrivelse";
            }
            else if (textbox.Name == "ProductPrice" && textbox.Text == "" || textbox.Name == "txb_Price" && textbox.Text == "")
            {
                textbox.Text = "Pris";
            }
            else if (textbox.Name == "AmountInStock" && textbox.Text == "" || textbox.Name == "txb_AmountInStock" && textbox.Text == "")
            {
                textbox.Text = "Antal på lager";
            }
            else if (textbox.Name == "ShippingPrice" && textbox.Text == "" || textbox.Name == "txb_ShippingPrice" && textbox.Text == "")
            {
                textbox.Text = "Fragt pris";
            }
            else if (textbox.Name == "DiscountPrice" && textbox.Text == "" || textbox.Name == "txb_DiscountPrice" && textbox.Text == "")
            {
                textbox.Text = "Tilbuds pris";
            }
            textbox.GotFocus += TextBox_GotFocus;
        } //Determines what happens when textboxes loses focus


        //Event that determines the content of the textboxes in the update/delete area of "AdminTools"
        private void ChooseItem_DropDownClosed(object sender, EventArgs e)
        {
            {
                try
                {
                    SqlConnection con = new SqlConnection(connectionString);
                    con.Open();
                    string DeleteQuery = "SELECT * from Products where ProductName='" + ChooseItem.Text + "' ";
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

        //Deletes the values for the a item, determined by the named chosen in the "ChooseItem" combobox
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);

            try
            {
                con.Open();
                string Query = "delete from Products where ProductName = '" + this.ChooseItem.Text + "'";
                SqlCommand cmd1 = new SqlCommand(Query, con);
                SqlDataReader myReader;
                myReader = cmd1.ExecuteReader();
                MessageBox.Show("Varen er nu slettet");
                //Clears the ChooseItem combobox 
                ChooseItem.Items.Clear();
                //Populets the ChooseItem combobox again, including the just added item
                ListInCombobox();
                con.Close();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex + "Varen kunne ikke blive slettet");
            }
        }

        //Updates the values for the chosen item in "ChooseItem", to the values the user has specified
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Assigns the updated textbox values for the item choosen by the user in the "ChooseItem" combobox, and adds them to the "Query" variable.
                Query = "Update Products set ProductID='" +this.txb_ProductID.Text+ "', ProductName='"+this.txb_ProductName.Text+"', Category='"+this.cmb_Category.Text+"', ProductDescription='"+this.txb_ProductDescription.Text+"', ProductPrice='"+this.txb_Price.Text+"', AmountInStock='"+this.txb_AmountInStock.Text+"', ShippingPrice='"+this.txb_ShippingPrice.Text+"', Size='"+this.cmb_Size.Text+"', DiscountPrice='"+this.txb_DiscountPrice.Text+"' where ProductName='"+this.ChooseItem.Text+"' " ;
                SqlConnection con = new SqlConnection(connectionString);
                // The newly updated information about the item is updated in the database too
                SqlCommand cmd1 = new SqlCommand(Query, con);
                SqlDataReader myReader;
                con.Open();
                myReader = cmd1.ExecuteReader();
                //Adds the updated information to the chosen item to a list - done in the Products class
                shopController.AddProduct();
                MessageBox.Show("Varens oplysninger er nu opdateret");
                while (myReader.Read())
                {
                }
                //Clears the ChooseItem combobox 
                ChooseItem.Items.Clear();
                //Populates the ChooseItem combobox again, including the just updated item
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
