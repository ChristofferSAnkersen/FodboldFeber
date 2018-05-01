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
            ShopController shopcontroller = new ShopController();

            //2nd step of converting textbox strings from the UI to interger values
            _amountInStock = int.Parse(AmountInStock.Text);
            _price = int.Parse(ProductPrice.Text);
            _shippingPrice = int.Parse(ShippingPrice.Text);

            //Assigning values from the textboxes in the UI to the Product in shopcontroller
            shopcontroller.Product.ProductName = ProductName.Text;
            shopcontroller.Product.ProductDescription = ProductDescription.Text;
            shopcontroller.Product.AmountInStock = _amountInStock;
            shopcontroller.Product.ProductPrice = _price;
            shopcontroller.Product.ShippingPrice = _shippingPrice;
            shopcontroller.Product.Category = Category.Text;
          
        }

        private void Opret_Vare_Click(object sender, RoutedEventArgs e)
        {

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
