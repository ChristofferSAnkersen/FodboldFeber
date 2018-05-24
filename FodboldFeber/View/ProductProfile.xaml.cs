﻿using System.Windows;
using System.Windows.Controls;
using FodboldFeber.ViewModel;

namespace FodboldFeber.View
{
    /// <summary>
    /// Interaction logic for ProductProfile.xaml
    /// </summary>
    public partial class ProductProfile : Page
    {
        private ShopVM shopVM;
        public ProductProfile()
        {
            InitializeComponent();
            shopVM = ShopVM.Instance;
            this.DataContext = shopVM.SelectedProduct;
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Varen er nu tilføjet til kurven");
            
        }
    }
}
