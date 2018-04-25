using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FodboldFeber.Model
{
    class ShoppingCart
    {
        public int ProductID { get; set; }
        public int AmountOfProductsOrdered { get; set; }
        public int ProductPrice { get; set; }
        public int AmountInStock { get; set; }
        public void EmptyCart()
        {

        }
        public void UpdateCart()
        {

        }
    }
}
