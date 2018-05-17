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
using System.Data;

namespace FodboldFeber.View
{
    /// <summary>
    /// Interaction logic for ProductProfile.xaml
    /// </summary>
    public partial class ProductProfile : Page
    {
        private ShopController shopController;
        public ProductProfile()
        {
            InitializeComponent();
            shopController = new ShopController();
            shopController.PopulateList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Varen er nu tilføjet til kurven");
            
        }
    }
}
