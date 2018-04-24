using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FodboldFeber.Model
{
    class Products
    {
        public void AddProduct()
        {

        }
        public void UpdateProduct()
        {

        }
        public void DeleteProduct()
        {

        }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int CategoryID { get; set; }
        public string ProductDescription { get; set; }
        public int ProductPrice { get; set; }
        public int AmountInStock { get; set; }
        public int AmountInRoute { get; set; }
        public int ShippingPrice { get; set; }
    }
}
