﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Data;


namespace FodboldFeber.Model
{
   
    public class Products : INotifyPropertyChanged
    {
        public List<ShopData> ListOfProducts = new List<ShopData>();

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
     

        private string _chooseItem = "JegSkalÆndreMigNu!!!";

        //Property with the purpose of handling the string value displayed in the "ChooseItem" combobox, located in "AdminTools"
        public string ChooseItem
        {
            get
            {
                return _chooseItem;
            }
            set
            {
                if (value!= this._chooseItem)
                {
                    _chooseItem = value;
                    OnPropertyChanged("ChooseItem");
                }
            }
        }

    
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
            get { return _size; }
            set { if (value != _size) {_size = value; OnPropertyChanged("Size"); } }

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

        private string _query = "";
        //Connection string used in the varius logic methods below.
        private static string _connectionString = "Server=EALSQL1.eal.local; Database=DB2017_A27; User Id= USER_A27; Password=SesamLukOp_27;";

        //Logic to Shop, populates the list used to display items in the frontend
        public void FillList(List<ShopData> ListOfProducts)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Products", con);
                    SqlDataReader myReader = sqlCommand.ExecuteReader();
                    
                    while (myReader.Read())
                    {
                        ShopData sd = new ShopData();
                        sd.ProductName = (string)myReader["ProductName"];
                        sd.Price = (double)myReader["ProductPrice"];
                        sd.ProductImage = (string)myReader["ProductImage"];
                        sd.ProductDescription = (string)myReader["ProductDescription"];
                        ListOfProducts.Add(sd);
                    }
                    con.Close();
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e + "Kunne ikke udfylde listen");
                }
            }
        }

        //Actual logic for Adding a product. Is called by "ShopController" by a btn click event in "AdminTools"
        public void AddProduct()
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                try
                {
                    con.Open();
                    //Fills the _query variable with the information of the properties
                    _query = "insert into Products(ProductID, ProductName, Category, ProductDescription, ProductPrice, AmountInStock, ShippingPrice, Size, DiscountPrice, ProductImage) values('" + ProductID + "','" + ProductName + "','" + Category + "','" + ProductDescription + "','" + Price + "','" + AmountInStock + "','" + ShippingPrice + "','" + Size + "','" + DiscountPrice + "','" + ProductImage + "');";
                    //Inserts the data of _query into the "Products" table in the database
                    SqlCommand cmd1 = new SqlCommand(_query, con);
                    SqlDataReader myReader;
                    myReader = cmd1.ExecuteReader();


                    con.Close();
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e + "Kunne ikke tilføje produkter til listen!!");
                }
            }
        }

        //Actual logic for deleting a product. Is called by ShopController by a btn click event in "AdminTools"
        public void DeleteProduct()
        {
            SqlConnection con = new SqlConnection(_connectionString);

            try
            {
                con.Open();
                string _query = "delete from Products where ProductName = '" + this.ChooseItem+ "'";
                SqlCommand cmd1 = new SqlCommand(_query, con);
                SqlDataReader myReader;
                myReader = cmd1.ExecuteReader();
            
                con.Close();

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex + "Varen kunne ikke blive slettet");
            }
        }
        //Actual logic for updating a product. Is called by ShopController by a btn click event in "AdminTools"
        public void UpdateProduct()
        {
            try
            {
                //Assigns the updated textbox values for the item choosen by the user in the "ChooseItem" combobox, and adds them to the "_query" variable.
                _query = "Update Products set ProductID='" + this.ProductID+ "', ProductName='" + this.ProductName+ "', Category='" + this.Category+ "', ProductDescription='" + this.ProductDescription+ "', ProductPrice='" + this.Price+ "', AmountInStock='" + this.AmountInStock+ "', ShippingPrice='" + this.ShippingPrice+ "', Size='" + this.Size+ "', DiscountPrice='" + this.DiscountPrice+ "' where ProductName='" + this.ChooseItem+ "' ";
                SqlConnection con = new SqlConnection(_connectionString);
                // The newly updated information about the item is updated in the database too
                SqlCommand cmd1 = new SqlCommand(_query, con);
                SqlDataReader myReader;
                con.Open();
                myReader = cmd1.ExecuteReader();
             
                con.Close();

            }
            catch (SqlException exe)
            {
                Console.WriteLine(exe + "Varen kunne ikke opdateres");
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
