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
            DataContext = shopVM;
            //Default values for the properties, with the goal of displaying the needed message 
            //in the textboxes, instructing the user of what they should type in the boxes
            ProductID.Text = "Angiv ProduktID";
            ProductName.Text = "Angiv Produktnavn";
            Category.Text = "Angiv Kategori";
            ProductDescription.Text = "Angiv Beskrivelse";
            ProductImage.Text = "Indsæt Link Til Billede";
            ProductPrice.Text = "Angiv Pris";
            AmountInStock.Text = "Angiv Antal På Lager";
            ShippingPrice.Text = "Angiv Fragtpris";
            Size.Text = "Angiv Størrelse";
            DiscountPrice.Text = "Angiv Tilbudspris";

            txb_ProductName.Text = "Angiv Produktnavn";
            txb_ProductID.Text = "Angiv ProduktID";
            txb_ProductDescription.Text = "Angiv Beskrivelse";
            txb_AmountInStock.Text = "Angiv Antal På Lager";
            txb_ProductImage.Text = "Indsæt Link Til Billede";
            txb_Price.Text = "Angiv Pris";
            txb_DiscountPrice.Text = "Angiv Tilbudspris";
            txb_ShippingPrice.Text = "Angiv Fragtpris";
            
            ListInCombobox();
        }
        //Connection to the sql database
        private string _connectionString = "Server=EALSQL1.eal.local; Database=DB2017_A27; User Id= USER_A27; Password=SesamLukOp_27;";

        //String query, used to add/delete/update the desired values in the database in the methods below
        //private string _query = "";
        //Function that makes it possible for the combobox to be filled with already existing items in the database for the user to choose from when deciding what item(s) to delete or update
        public void ListInCombobox()
        {
            shopVM.ListOfProducts.Clear();
            shopVM.PopulateList();
            foreach (var item in shopVM.ListOfProducts)
            {
                ChooseItem.Items.Add(item.ProductName);
            }
            
        }


        //Event that adds a product to the database with the information given by the user, the actual logic lies in "Products" 
        private void btnCreateProduct(object sender, RoutedEventArgs e)
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
            if (textbox.Name == "ProductImage" && textbox.Text == "" || textbox.Text == "Indsæt Link Til Billede" || textbox.Text == "Indsæt Link Til Billede")
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
            else if (textbox.Name == "ProductImage" && textbox.Text == "")
            {
                textbox.Text = "Indsæt Link Til Billede";
            }
            textbox.GotFocus += TextBox_GotFocus;
        } //Determines what happens when textboxes loses focus

        private void TextBox2_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            if (textbox.Name == "txb_ProductID" && textbox.Text == "" || textbox.Text == "ProduktID" || textbox.Text == "Angiv ProduktID")
            {
                textbox.Text = string.Empty;
            }
            if (textbox.Name == "txb_ProductName" && textbox.Text == "" || textbox.Text == "Produktnavn" || textbox.Text == "Angiv Produktnavn")
            {
                textbox.Text = string.Empty;
            }
            if (textbox.Name == "txb_ProductDescription" && textbox.Text == "" || textbox.Text == "Produkt Beskrivelse" || textbox.Text == "Angiv Beskrivelse")
            {
                textbox.Text = string.Empty;
            }
            if (textbox.Name == "txb_ProductPrice" && textbox.Text == "" || textbox.Text == "Pris" || textbox.Text == "Angiv Pris")
            {
                textbox.Text = string.Empty;
            }
            if (textbox.Name == "txb_AmountInStock" && textbox.Text == "" || textbox.Text == "Antal På Lager" || textbox.Text == "Angiv Antal På Lager")
            {
                textbox.Text = string.Empty;
            }
            if (textbox.Name == "txb_ShippingPrice" && textbox.Text == "" || textbox.Text == "Fragtpris" || textbox.Text == "Angiv Fragtpris")
            {
                textbox.Text = string.Empty;
            }
            if (textbox.Name == "txb_DiscountPrice" && textbox.Text == "" || textbox.Text == "Tilbudspris" || textbox.Text == "Angiv Tilbudspris")
            {
                textbox.Text = string.Empty;
            }
            if (textbox.Name == "txb_ProductImage" && textbox.Text == "" || textbox.Text == "Indsæt Link Til Billede" || textbox.Text == "Indsæt Link Til Billede")
            {
                textbox.Text = string.Empty;
            }
            textbox.GotFocus -= TextBox2_GotFocus;
        }

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
                    SqlConnection con = new SqlConnection(_connectionString);
                    con.Open();
                    string _query = "SELECT * from Products where ProductName='" + ChooseItem.Text + "' ";
                    SqlCommand listCommands = new SqlCommand(_query, con);
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

                        ImageSourceConverter converter = new ImageSourceConverter();
                        this.img_product2.Source = (ImageSource)converter.ConvertFromString(ProductImage);

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
        private void btnDeleteButton(object sender, RoutedEventArgs e)
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
        private void btnUpdateProduct(object sender, RoutedEventArgs e)
        {
            
            shopVM.UpdateProductControl();

            MessageBox.Show("Varens oplysninger er nu opdateret");
            //Clears the ChooseItem combobox 
            ChooseItem.Items.Clear();
            //Populates the ChooseItem combobox again, including the just updated itemlist
            ListInCombobox();
        }

        private void ProductImage_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ProductImage.Text))
            {
                ImageSourceConverter converter = new ImageSourceConverter();
                this.img_product.Source = (ImageSource)converter.ConvertFromString("https://churchtraconline.com/articles/apple/uploads/2017/09/Antu_insert-image.svg_-846x846.png");
            }

            else if(ProductImage.Text != "Indsæt Link Til Billede")
            {
                
                ImageSourceConverter converter = new ImageSourceConverter();
                this.img_product.Source = (ImageSource)converter.ConvertFromString(ProductImage.Text);
                
            }
            else
            {
                MessageBox.Show("Ugyldigt input");
            }
          
        }

    }
}
