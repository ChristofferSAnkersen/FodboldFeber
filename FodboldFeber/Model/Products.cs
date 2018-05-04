using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.ComponentModel;


namespace FodboldFeber.Model
{
   
    public class Products
    {
        //List of products, should have the same data as the table "Products" in the database

        //Local variables used in the matching properties just below
        private string _productName = "JegSkalÆndreMigNu!!!";
        private int _productID;
        private string _category = "JegSkalÆndreMigNu!!!";
        private string _productDescription = "JegSkalÆndreMigNu!!!";
        private double _price;
        private int _amountInStock;
        private double _shippingPrice;
        private string _size = "JegSkalÆndreMigNu!!!";
        private double _discountPrice;
        private string _productImage = "JegSkalÆndreMigNu!!!";

        //Properties for the product
        public string ProductName
        {
            get
            {
                return this._productName;
            }
            set
            {
                if (value != this._productName)
                {
                    _productName = value;
                    OnPropertyChanged("ProductName");
                }

            }
        }
        public int ProductID
        {
            get
            {
                return this._productID;
            }
            set
            {
                if (value != this._productID)
                {
                    _productID = value;
                    OnPropertyChanged("ProduktID");
                }

            }
        }
        public string Category
        {
            get
            {
                return this._category;
            }
            set
            {
                if (value != this._category)
                {
                    _category = value;
                    OnPropertyChanged("Category");
                }
            }
        }
        public string ProductDescription
        {
            get
            {
                return this._productDescription;
            }
            set
            {
                if (value != this._productDescription)
                {
                    _productDescription = value;
                    OnPropertyChanged("ProductDescription");
                }
            }
        }
        public double Price
        {
            get
            {
                return _price;
            }
            set
            {
                if (value != _price)
                {
                    _price = value;
                    OnPropertyChanged("Price");
                }
            }
        }
        public int AmountInStock
        {
            get
            {
                return _amountInStock;
            }
            set
            {
                if (value != _amountInStock)
                {
                    _amountInStock = value;
                    OnPropertyChanged("AmountInStock");
                }
            }
        }
        public double ShippingPrice
        {
            get
            {
                return _shippingPrice;
            }
            set
            {
                if (value != _shippingPrice)
                {
                    _shippingPrice = value;
                    OnPropertyChanged("ShippingPrice");
                }
            }
        }
        public string Size
        {
            get
            {
                return _size;
            }
            set
            {
                if (value != _size)
                {
                    _size = value;
                    OnPropertyChanged("Size");
                }
            }
        }
        public double DiscountPrice
        {
            get
            {
                return _discountPrice;
            }
            set
            {
                if (value != _discountPrice)
                {
                    _discountPrice = value;
                    OnPropertyChanged("DiscountPrice");
                }
            }
        }
        public string ProductImage
        {
            get
            {
                return _productImage;
            }
            set
            {
                if (value != _productImage)
                {
                    _productImage = value;
                    OnPropertyChanged("ProductImage");
                }
            }
        }

        string query = "";
        private static string connectionString = "Server=EALSQL1.eal.local; Database=DB2017_A27; User Id= USER_A27; Password=SesamLukOp_27;";

        //Der mangler funktionalitet med listen, blandt andet bliver den ikke brugt lige pt, og der bliver ikke slettet i listen når der bliver slettet i databasen
        public void AddProduct()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    //Fills the query variable with the information of the properties
                    query = "insert into Products(ProductID, ProductName, Category, ProductDescription, ProductPrice, AmountInStock, ShippingPrice, Size, DiscountPrice, ProductImage) values('" + this.ProductID + "','" + this.ProductName + "','" + this.Category + "','" + this.ProductDescription + "','" + this.Price + "','" + this.AmountInStock + "','" + this.ShippingPrice + "','" + this.Size + "','" + this.DiscountPrice + "','" + this.ProductImage + "');";
                    //Inserts the data of query into the "Products" table in the database
                    SqlCommand cmd1 = new SqlCommand(query, con);
                  
                    SqlDataReader myReader = cmd1.ExecuteReader();
                    

                    while (myReader.Read())
                    {

                        //at the moment the list is not used

                        //Products p = new Products();
                        //p.ProductID = myReader["ProductID"];
                        //p.ProductName = (string)myReader["ProductName"];
                        //p.Category = (string)myReader["Category"];
                        //p.ProductDescription = (string)myReader["ProductDescription"];
                        //p.ProductPrice = (double)MyReader["ProductPrice"];
                        //p.AmountInStock = (int)MyReader["AmountInStock"];
                        //p.ShippingPrice = (double)MyReader["ShippingPrice"];
                        //p.Size = (string)MyReader["Size"];
                        //p.DiscountPrice = (double)MyReader["DiscountPrice"];
                        //ListOfProducts.Add(p);
                    }
                    con.Close();
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e + "Could not add items to the list");
                }
            }
        }
        public void UpdateProduct()
        {

        }
        public void DeleteProduct()
        {

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
