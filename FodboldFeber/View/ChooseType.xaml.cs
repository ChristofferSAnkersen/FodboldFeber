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

namespace FodboldFeber.View
{
    /// <summary>
    /// Interaction logic for ChooseType.xaml
    /// </summary>
    public partial class ChooseType : Page
    {
        public ChooseType()
        {
            InitializeComponent();
        }

        private void btn_logIn_Copy1_Click(object sender, RoutedEventArgs e)
        {
           
            this.Content = new CreatePrivateCustomer();
        }

        private void btn_logIn_Copy2_Click(object sender, RoutedEventArgs e)
        {
           
            this.Content = new CreateClubCustomer();
        }

        private void btn_logIn_Copy3_Click(object sender, RoutedEventArgs e)
        {
        
            this.Content = new CreateCompanyCustomer();
        }
    }
}
