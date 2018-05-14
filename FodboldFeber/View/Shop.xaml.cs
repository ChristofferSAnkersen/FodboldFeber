﻿using System;
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
using FodboldFeber.Controller;

namespace FodboldFeber.View
{
    /// <summary>
    /// Interaction logic for Shop.xaml
    /// </summary>
    public partial class Shop : Window
    {
            
        private ShopController shopController;
        
        public Shop()
        {
           
            InitializeComponent();
            shopController = new ShopController();

            // Sets the itemsource again to make sure it is binded to the list "ListOfProducts" in "Shopcontroller" after it has been populated
            shopController.PopulateList();
            ShopListBox.ItemsSource = shopController.ListOfProducts;


        }
    
       
    }
}
