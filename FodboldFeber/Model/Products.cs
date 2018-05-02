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
        
        public string Product { get; set; }
       
        
        public List<string> ListOfProducts;
        
        public void AddProduct()
        {
            ListOfProducts.Add(Product);
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
