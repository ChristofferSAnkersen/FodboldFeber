using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FodboldFeber.Model;
using FodboldFeber.View;

namespace FodboldFeber.Controller
{
    public class ShopController
    {
        private static Products _result;
        public static Products Product { get; set; }
        
    

        //måske skal listofproducts slettes
        public List<Products> ListOfProducts { get; set; }

        public void AddProduct()
        {
            //Adding the values to the property "Product" of the ShopController class
            Product = Products.Product;
           
        }
    }
}


