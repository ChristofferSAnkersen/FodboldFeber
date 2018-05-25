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
using System.Windows.Shapes;
using System.ComponentModel;
using System.Data;
using FodboldFeber.ViewModel;

namespace FodboldFeber.View
{
    /// <summary>
    /// Interaction logic for Shop.xaml
    /// </summary>
    public partial class Shop : Page
    {

        private ShopVM shopVM;
        private CustomerVM customerVM;

        public Shop()
        {
            InitializeComponent();
            shopVM = ShopVM.Instance;
            this.DataContext = shopVM;

           
            customerVM = CustomerVM.Instance;

            //Makes sure the "ShopListBox" only populates once when navigating to the "Shop" page.
            if(shopVM.ListOfProducts.Count == 0)
            {
                shopVM.PopulateList();
            }
            // Sets the itemsource again to make sure it is binded to the list "ListOfProducts" in "ShopVM" after it has been populated

            ShopListBox.ItemsSource = shopVM.ListOfProducts;
        }
        
        private void BtnNavigation_Click(object sender, RoutedEventArgs e)
        {
            var item = ItemsControl.ContainerFromElement(ShopListBox, e.OriginalSource as DependencyObject) as ListBoxItem;
            ShopListBox.SelectedItem = item;
            if (item != null)
            {
                ShopListBox.ItemsSource = shopVM.ListOfProducts;

                ShopFrame.Content = new ProductProfile();

            }
        }

        private void ShopListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
         
            //var item = ItemsControl.ContainerFromElement(ShopListBox, e.OriginalSource as DependencyObject) as ListBoxItem;
            //ShopListBox.SelectedItem = item;
            if (ShopListBox.SelectedItem != null)
            {
                //ShopListBox.ItemsSource = shopVM.ListOfProducts;
                //shopVM.SelectedProduct = ShopListBox.SelectedItem;
                ShopFrame.Content = new ProductProfile();

            }
        }
    }
}
