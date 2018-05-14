using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FodboldFeber.InstantSearch
{
    public class ProductsResultItem : ResultItem
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        //Add more parameters here if wanted. Remember to add everywhere else, where needed. Below fx

        public ProductsResultItem(string group, string productName, string productDescription)
            : base(group)
        {
            this.ProductName = productName;
            this.ProductDescription = productDescription;
            //These are the parameters chosen. Note that group can be several things. Here it is representing products
        }
    }
}
