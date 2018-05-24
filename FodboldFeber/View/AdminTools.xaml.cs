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
using System.Data.SqlClient;
using System.ComponentModel;

namespace FodboldFeber.View
{
    /// <summary>
    /// Interaction logic for AdminTools.xaml
    /// </summary>
    public partial class AdminTools : Page
    {
        private ShopVM shopVM;
        public AdminTools()
        {
            InitializeComponent();
            shopVM = ShopVM.Instance;
            this.DataContext = shopVM;
            //Default values for the properties, with the goal of displaying the needed message 
            //in the textboxes, instructing the user of what they should type in the boxes
            ProductID.Text = "Angiv ProduktID";
            ProductName.Text = "Angiv Produkt Navn";
            Category.Text = "Angiv Kategori";
            ProductDescription.Text = "Angiv beskrivelse";

            ProductPrice.Text = "Angiv Pris";
            AmountInStock.Text = "Angiv Antal På Lager";
            ShippingPrice.Text = "Angiv Fragtpris";
            this.Size.Text = "Angiv Størrelse";
            DiscountPrice.Text = "Angiv Tilbudspris";

            
            ListInCombobox();
        }
        //Connection to the sql database
        string connectionString = "Server=EALSQL1.eal.local; Database=DB2017_A27; User Id= USER_A27; Password=SesamLukOp_27;";

        //String query, used to add/delete/update the desired values in the database in the methods below
        public string Query = "";
        //Function that makes it possible for the combobox to be filled with already existing items in the database for the user to choose from when deciding what item(s) to delete or update
        public void ListInCombobox()
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                string Query = "SELECT * from Products";
                SqlCommand listCommands = new SqlCommand(Query, con);
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


        //Event that adds a product to the database with the information given by the user, the actual logic lies in "Products" 
        private void CreateProduct_Click(object sender, RoutedEventArgs e)
        {
            
            //Adds the product to the database through "ShopController" -> "Products"
            shopVM.AddProductControl();
            MessageBox.Show("Varen er nu tilføjet");

            //Clears the ChooseItem combobox
                ChooseItem.Items.Clear();
            //Populates the ChooseItem combobox again, including the just added item
                ListInCombobox();

        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            if (textbox.Name == "ProductID" && textbox.Text == "" || textbox.Text == "ProduktID" || textbox.Text == "Angiv ProduktID")
            {
                textbox.Text = string.Empty;
            }
            if (textbox.Name == "ProductName" && textbox.Text == "" || textbox.Text == "Produktnavn" || textbox.Text == "Angiv Produktnavn")
            {
                textbox.Text = string.Empty;
            }
            if (textbox.Name == "ProductDescription" && textbox.Text == "" || textbox.Text == "Produkt Beskrivelse" || textbox.Text == "Angiv Beskrivelse")
            {
                textbox.Text = string.Empty;
            }
            if (textbox.Name == "ProductPrice" && textbox.Text == "" || textbox.Text == "Pris" || textbox.Text == "Angiv Pris")
            {
                textbox.Text = string.Empty;
            }
            if (textbox.Name == "AmountInStock" && textbox.Text == "" || textbox.Text == "Antal På Lager" || textbox.Text == "Angiv Antal På Lager")
            {
                textbox.Text = string.Empty;
            }
            if (textbox.Name == "ShippingPrice" && textbox.Text == "" || textbox.Text == "Fragtpris" || textbox.Text == "Angiv Fragtpris")
            {
                textbox.Text = string.Empty;
            }
            if (textbox.Name == "DiscountPrice" && textbox.Text == "" || textbox.Text == "Tilbudspris" || textbox.Text == "Angiv Tilbudspris")
            {
                textbox.Text = string.Empty;
            }
            textbox.GotFocus -= TextBox_GotFocus;


        } //Determines what happens when textboxes are focused
        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            if (textbox.Name == "ProductID" && textbox.Text == "")
            {
                textbox.Text = "Angiv ProduktID";
            }
            else if (textbox.Name == "ProductName" && textbox.Text == "")
            {
                textbox.Text = "Angiv Produktnavn";
            }
            else if (textbox.Name == "ProductDescription" && textbox.Text == "")
            {
                textbox.Text = "Angiv Beskrivelse";
            }
            else if (textbox.Name == "ProductPrice" && textbox.Text == "")
            {
                textbox.Text = "Angiv Pris";
            }
            else if (textbox.Name == "AmountInStock" && textbox.Text == "")
            {
                textbox.Text = "Angiv Antal På Lager";
            }
            else if (textbox.Name == "ShippingPrice" && textbox.Text == "")
            {
                textbox.Text = "Angiv Fragtpris";
            }
            else if (textbox.Name == "DiscountPrice" && textbox.Text == "")
            {
                textbox.Text = "Angiv Tilbudspris";
            }
            textbox.GotFocus += TextBox_GotFocus;
        } //Determines what happens when textboxes loses focus
        private void TextBox2_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            if (textbox.Name == "txb_ProductID" && textbox.Text == "")
            {
                textbox.Text = "ProduktID";
            }
            else if (textbox.Name == "txb_ProductName" && textbox.Text == "")
            {
                textbox.Text = "Produktnavn";
            }
            else if (textbox.Name == "txb_ProductDescription" && textbox.Text == "")
            {
                textbox.Text = "Produkt Beskrivelse";
            }
            else if (textbox.Name == "txb_Price" && textbox.Text == "")
            {
                textbox.Text = "Pris";
            }
            else if (textbox.Name == "txb_AmountInStock" && textbox.Text == "")
            {
                textbox.Text = "Antal På Lager";
            }
            else if (textbox.Name == "txb_ShippingPrice" && textbox.Text == "")
            {
                textbox.Text = "Fragtpris";
            }
            else if (textbox.Name == "txb_DiscountPrice" && textbox.Text == "")
            {
                textbox.Text = "Tilbudspris";
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
                    string query = "SELECT * from Products where ProductName='" + ChooseItem.Text + "' ";
                    SqlCommand listCommands = new SqlCommand(query, con);
                    SqlDataReader reader = listCommands.ExecuteReader();

                    while (reader.Read())
                    {
                        //Must assign all column data from the database to variables, so that we can assign the variables to the textboxes, 
                        //so that the textboxes can display the information of the chosen product
                        string ProductID = reader.GetInt32(0).ToString();
                        string ProductName = reader.GetString(1);
                        string Category = reader.GetString(2);
                        string ProductDescription = reader.GetString(3);
                        string ProductPrice = reader.GetDouble(4).ToString();
                        string AmountInStock = reader.GetInt32(5).ToString();
                        string ShippingPrice = reader.GetDouble(6).ToString();
                        string Size = reader.GetString(7);
                        string DiscountPrice = reader.GetDouble(8).ToString();
                        string ProductImage = reader.GetString(9);

                        txb_ProductID.Text = ProductID;
                        txb_ProductName.Text = ProductName;
                        cmb_Category.Text = Category;
                        txb_ProductDescription.Text = ProductDescription;
                        txb_Price.Text = ProductPrice;
                        txb_AmountInStock.Text = AmountInStock;
                        txb_ShippingPrice.Text = ShippingPrice;
                        cmb_Size.Text = Size;
                        txb_DiscountPrice.Text = DiscountPrice;
                        txb_ProductImage.Text = ProductImage;
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
            //The actual logic for deleting an item lies in "Products", which it reaches through "ShopController" -> "Products"
            shopVM.DeleteProductControl();

            MessageBox.Show("Varen er nu slettet");
            //Clears the ChooseItem combobox 
            ChooseItem.Items.Clear();
            //Populates the ChooseItem combobox again, including the just added item
            ListInCombobox();
        }

        //Updates the values for the chosen item in "ChooseItem", to the values the user has specified
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            
            shopVM.UpdateProductControl();

            MessageBox.Show("Varens oplysninger er nu opdateret");
            //Clears the ChooseItem combobox 
            ChooseItem.Items.Clear();
            //Populates the ChooseItem combobox again, including the just updated itemlist
            ListInCombobox();
        }

   
    }
}
