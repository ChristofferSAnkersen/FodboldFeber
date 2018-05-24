using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FodboldFeber.Model
{
    //This class' purpose is to provide the needed data for the "ListOfProducts" list in the "Products" class.
    public class ShopData
    {
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string ProductImage { get; set; }
        public string ProductDescription { get; set; }
    }
}
