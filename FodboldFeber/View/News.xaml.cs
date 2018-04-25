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

namespace FodboldFeber.View
{
    /// <summary>
    /// Interaction logic for News.xaml
    /// </summary>
    public partial class News : Window
    {
        public News()
        {
            InitializeComponent();
        }

        private void Frontpage_Click(object sender, RoutedEventArgs e)
        {
            MainWindow frontpage = new MainWindow();
            frontpage.Show();
            this.Close();
        }

        private void News_Click(object sender, RoutedEventArgs e)
        {
            News news = new News();
            news.Show();
            this.Close();
        }

        private void Shop_Click(object sender, RoutedEventArgs e)
        {
            Shop shop = new Shop();
            shop.Show();
            this.Close();
        }
        private void Contact_Click(object sender, RoutedEventArgs e)
        {
            Contact contact = new Contact();
            contact.Show();
            this.Close();
        }

    }
}
