using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FodboldFeber.Model;
using FodboldFeber.View;

namespace FodboldFeber.Controller
{
    public class ShopController : Products
    {
        Products products = new Products();
        public ShopController()
        {
            //Default values for the properties, with the goal of displaying the needed message 
            //in the textboxes, instructing the user of what they should type in the boxes
            //ListOfProducts = products.ListOfProducts;
            ChooseItem = "Vælg produkt";

            ProductName = "Angiv Produktnavn";
            ProductID = 0;
            Category = "Vælg Kategori";
            ProductDescription = "Angiv Beskrivelse";
            Price = 0;
            AmountInStock = 0;
            ShippingPrice = 0;
            Size = "Angiv størrelse";
            DiscountPrice = 0;
            ProductImage = "Vælg billede";

        }
        //Funktionality to Shop
        public void PopulateList()
        {
            products.FillList(ListOfProducts);
            
        }
       
        //Funktionality to AdminTools
        public void AddProductControl()
        {
            AddProduct();
        }
        public void DeleteProductControl()
        {
            DeleteProduct();
        }
        public void UpdateProductControl()
        {
            UpdateProduct();
        }
   
    }
 
}


