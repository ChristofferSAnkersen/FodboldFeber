using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FodboldFeber.Model;
using FodboldFeber.View;

namespace FodboldFeber.Controller
{
    class ShopController
    {
        //private Products _products;
        public Products Product { get; set; }
        //måske skal listofproducts slettes
        public List<Products> ListOfProducts { get; set; }

        public void AddProduct()
        {
            Products products = new Products();
            //Adding the values to the property "Product" of the ShopController class
            Product = products.Product;
           
        }
    }
}


