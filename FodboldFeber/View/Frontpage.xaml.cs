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

namespace FodboldFeber.View
{
    /// <summary>
    /// Interaction logic for Frontpage.xaml
    /// </summary>
    public partial class Frontpage : Page
    {

        private ShopVM shopVM;

        public Frontpage()
        {
            InitializeComponent();
            shopVM = new ShopVM();

            // Sets the itemsource again to make sure it is binded to the list "ListOfProducts" in "ShopVM" after it has been populated
            shopVM.PopulateList();
            ShopListBox.ItemsSource = shopVM.ListOfProducts;
        }
    }
}
