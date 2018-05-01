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

namespace FodboldFeber.View
{
    /// <summary>
    /// Interaction logic for AdminTools.xaml
    /// </summary>
    public partial class AdminTools : Page
    {
        ShopController shopController = new ShopController();

        //1st step of converting textbox strings from the UI to integer values
        private int amountInStock;
        public int price;
        public int shippingPrice;
   
        
        public AdminTools()
        {
            InitializeComponent();
        }

        private void CreateProduct_Click(object sender, RoutedEventArgs e)
        {

        //2nd step of converting textbox strings from the UI to interger values
            amountInStock = int.Parse(AmountInStock.Text);
            price = int.Parse(ProductPrice.Text);
            shippingPrice = int.Parse(ShippingPrice.Text);


            //Assigning values from the textboxes in the UI to the Product in shopcontroller
            ShopController.Product.ProductName = ProductName.Text;
            ShopController.Product.ProductDescription = ProductDescription.Text;
            ShopController.Product.AmountInStock = amountInStock;
            ShopController.Product.ProductPrice = price;
            ShopController.Product.ShippingPrice = shippingPrice;
            ShopController.Product.Category = Category.Text;
            shopController.AddProduct();

            MessageBox.Show("Varen er tilføjet");
          
        }
    }
}
