﻿using FodboldFeber.View;
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
using System.Windows.Shapes;

namespace FodboldFeber
{
    /// <summary>
    /// Interaction logic for Shoppingcary.xaml
    /// </summary>
    public partial class Shoppingcart : Window
    {
        public Shoppingcart()
        {
            InitializeComponent();
        }

        public void BackToShoplbl_Click(object sender, RoutedEventArgs e)
        {
                Shop shop = new Shop();
                shop.Show();
                this.Close();
            
        }
    }
}
