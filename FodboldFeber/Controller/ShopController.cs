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

        AdminTools adminTools;

        public void AddProduct()
        {
            Products p = new Products();
            //Adding the values to the property "Product" of the Products class
            p.Product = adminTools.Query;
            p.AddProduct();
           
        }
    }
}


