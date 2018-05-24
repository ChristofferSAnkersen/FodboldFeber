﻿using System;
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
using FodboldFeber;
using FodboldFeber.View;
using FodboldFeber.ViewModel;

namespace FodboldFeber
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
     

        //private news news;
        public MainWindow()
        {
            InitializeComponent();
            
            StartPage.Content = new Frontpage();
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            StartPage.Content = new About();
        }

        private void Contact_Click(object sender, RoutedEventArgs e)
        {
            StartPage.Content = new Contact();
        }

        private void Customers_Click(object sender, RoutedEventArgs e)
        {
            StartPage.Content = new Customers();
        }

        private void Frontpage_Click(object sender, RoutedEventArgs e)
        {
            StartPage.Content = new Frontpage();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {

            if (Login.Content.ToString() == "Profil")
            {
                StartPage.Content = new CustomerProfile();
            }
      
            else if (Login.Content.ToString() == "Login")
            {
                StartPage.Content = new Login();
            }


        }

        private void News_Click(object sender, RoutedEventArgs e)
        {
            News news = new News();
            StartPage.Content = news;
        }
        private void Shop_Click(object sender, RoutedEventArgs e)
        {

            StartPage.Content = new Shop();
        }
        private void IfUserIsLoggedIn()
        {
          


        }

        private void btnDiscord_Click(object sender, RoutedEventArgs e)
        {       //Discord server link            
                System.Diagnostics.Process.Start("https://discord.gg/JmFcHY");       
        }
    }
}
