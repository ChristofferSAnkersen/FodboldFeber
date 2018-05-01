using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.ComponentModel;

namespace FodboldFeber.Model
{
    public class Products : INotifyPropertyChanged
    {
        public static Products Product { get; set; }
        //Måske skal listofproducts slettes
        public List<Products> ListOfProducts { get; set; }
        public string Query = "";
        public void AddProduct()
        {
            Product = new Products { ProductID = 1, ProductName = "DækTilSideSpejl", Category = "Merchandise", ProductDescription="en test", ProductPrice = 20, AmountInStock = 20, ShippingPrice = 20 };
            Query = "insert into Products(ProductID, ProductName, Category, ProductDescription, ProductPrice, AmountInStock, AmountInRoute, ShippingPrice) values('"+ProductID+"','"+ProductName+"','"+Category+"','"+ProductDescription+"','"+ProductPrice+"','"+AmountInStock+"','"+AmountInRoute+"','"+ShippingPrice+"');";  
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

        public string Category { get; set; }
        public string ProductDescription { get; set; }
        public double ProductPrice { get; set; }
        public int AmountInStock { get; set; }
        public int AmountInRoute { get; set; }
        public double ShippingPrice { get; set; }

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
