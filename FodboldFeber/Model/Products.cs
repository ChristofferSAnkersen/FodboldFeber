using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Linq;


namespace FodboldFeber.Model
{
   
    public class Products
    {
        //List of products, should have the same data as the table "Products" in the database
        
        public List<Products> ListOfProducts = new List<Products>();
        public string Category { get; set; }
        public string ProductDescription { get; set; }
        public double ProductPrice { get; set; }
        public int AmountInStock { get; set; }
        public double ShippingPrice { get; set; }
        public string Size { get; set; }
        public double DiscountPrice { get; set; }

        //Der mangler funktionalitet med listen, blandt andet bliver den ikke brugt lige pt, og der bliver ikke slettet i listen når der bliver slettet i databasen
        public void AddProduct()
        {
            try
            {
                string connectionString = "Server=EALSQL1.eal.local; Database=DB2017_A27; User Id= USER_A27; Password=SesamLukOp_27;";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Products", con);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Products p = new Products();
                    p.ProductID = (int)reader["ProductID"];
                    p.ProductName = (string)reader["ProductName"];
                    p.Category = (string)reader["Category"];
                    p.ProductDescription = (string)reader["ProductDescription"];
                    p.ProductPrice = (double)reader["ProductPrice"];
                    p.AmountInStock = (int)reader["AmountInStock"];
                    p.ShippingPrice = (double)reader["ShippingPrice"];
                    p.Size = (string)reader["Size"];
                    p.DiscountPrice = (double)reader["DiscountPrice"];
                    ListOfProducts.Add(p);
                }
                
            }
            catch(SqlException e)
            {
                Console.WriteLine(e+"Could not add items to the list");
            }
        }
        public void UpdateProduct()
        {

        }
        public void DeleteProduct()
        {

        }
        public int ProductID { get; set; }
        private string _productName = "";
        public string ProductName
        {
            get
            {
                return _productName;
            }
            set
            {
                if (_productName.Equals(value) == false)
                    _productName = value;
                OnPropertyChanged("ProductName");

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
