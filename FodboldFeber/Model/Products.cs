using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Collections.ObjectModel;
using FodboldFeber.Controller;

namespace FodboldFeber.Model
{
    public class Products : INotifyPropertyChanged
    {
       
        public ObservableCollection<Products> products { get; set; }
      
        //Local variables used in the matching properties just below
        private string _productName ="JegSkalÆndreMigNu!!!";
        private string _productID = "JegSkalÆndreMigNu!!!";
        private string _category = "JegSkalÆndreMigNu!!!";
        private string _productDescription = "JegSkalÆndreMigNu!!!";
        private string _price = "JegSkalÆndreMigNu!!!";
        private string _amountInStock = "JegSkalÆndreMigNu!!!";
        private string _shippingPrice = "JegSkalÆndreMigNu!!!";
        private string _size = "JegSkalÆndreMigNu!!!";
        private string _discountPrice = "JegSkalÆndreMigNu!!!";
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
                if(value!= this._productName)
                {
                    _productName = value;
                    OnPropertyChanged("ProductName");
                }
                   
            }
        }
        public string ProductID
        {
            get
            {
                return this._productID;
            }
            set
            {
                if(value !=this._productID)
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
                if(value!=this._category)
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
        public string Price
        {
            get
            {
                return _price;
            }
            set
            {
                if(value != _price)
                {
                    _price = value;
                    OnPropertyChanged("Price");
                }
            }
        }
        public string AmountInStock
        {
            get
            {
                return _amountInStock;
            }
            set
            {
                if(value != _amountInStock)
                {
                    _amountInStock = value;
                    OnPropertyChanged("AmountInStock");
                }
            }
        }
        public string ShippingPrice
        {
            get
            {
                return _shippingPrice;
            }
            set
            {
                if(value != _shippingPrice)
                {
                    _shippingPrice = value;
                    OnPropertyChanged("ShippingPRice");
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
                if(value != _size)
                {
                    _size = value;
                    OnPropertyChanged("Size");
                }
            }
        }
        public string DiscountPrice
        {
            get
            {
                return _discountPrice;
            }
            set
            {
                if(value != _discountPrice)
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
                if(value != _productImage)
                {
                    _productImage = value;
                    OnPropertyChanged("ProductImage");
                }
            }
        }
        
        
        string query = "";
        private static string connectionString = "Server=EALSQL1.eal.local; Database=DB2017_A27; User Id= USER_A27; Password=SesamLukOp_27;";
        public void AddProduct()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                   //Fills the query variable with the information of the properties
                    query = "insert into Products(ProductID, ProductName, Category, ProductDescription, ProductPrice, AmountInStock, ShippingPrice, Size, DiscountPrice, ProductImage) values('" +this.ProductID+ "','" +this.ProductName+ "','"+this.Category+ "','"+this.ProductDescription+ "','"+this.Price+ "','"+this.AmountInStock+ "','"+this.ShippingPrice+ "','"+this.Size+ "','"+this.DiscountPrice+ "','"+this.ProductImage+"');";
                    //Inserts the data of query into the "Products" table in the database
                    SqlCommand cmd1 = new SqlCommand(query, con);
                    SqlDataReader myReader;
                    con.Open();
                    myReader = cmd1.ExecuteReader();
                    while (myReader.Read())
                    {
                    }
                    con.Close();

                }
                catch (SqlException e)
                {
                    Console.WriteLine(e + "Det virker ikke :(");
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
           
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
