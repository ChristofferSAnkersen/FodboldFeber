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

namespace FodboldFeber.View
{
    /// <summary>
    /// Interaction logic for Shop.xaml
    /// </summary>
    public partial class Shop : Window
    {
        public Shop()
        {
            InitializeComponent();
            FillDataGrid();
        }

        string connectionString = "Server=EALSQL1.eal.local; Database=DB2017_A27; User Id= USER_A27; Password=SesamLukOp_27;";


        private void Button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                string ImageQuery = "SELECT * from Products where ProductName='" + lbl_klaphat.Content + "' ";
                SqlCommand listCommands = new SqlCommand(ImageQuery, con);
                SqlDataReader reader = listCommands.ExecuteReader();

                while (reader.Read())
                {
                    string ImagePicture = reader.GetString(9).ToString();
                    ImageSourceConverter converter = new ImageSourceConverter();
                    this.img_product1.Source = (ImageSource)converter.ConvertFromString(ImagePicture);
                }
            }

            catch (SqlException ex)
            {
                Console.WriteLine(ex + "Fejl");
            }

        }

        private void FillDataGrid()
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                string query = "SELECT ProductImage, ProductName, ProductPrice from Products ";
                SqlCommand createcommands = new SqlCommand(query, con);
                createcommands.ExecuteNonQuery();

                SqlDataAdapter adapter = new SqlDataAdapter(createcommands);
                DataTable dt = new DataTable("Products");
                adapter.Fill(dt);
                ShopDataGrid.ItemsSource = dt.DefaultView;
                adapter.Update(dt);

                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e + "Could not load shop page");
            }
        }
    }
}
