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
using FodboldFeber.Controller;


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
        }

        private void CreateProduct_Click(object sender, RoutedEventArgs e)
        {
           
            shopController.AddProductControl();
            MessageBox.Show("Varen blev tilføjet");
  
        }
    }
}
