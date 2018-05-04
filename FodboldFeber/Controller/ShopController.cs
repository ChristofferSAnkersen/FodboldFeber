using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FodboldFeber.Model;
using FodboldFeber.View;

namespace FodboldFeber.Controller
{
    public class ShopController : Products
    {

        public ShopController()
        {
            //Default values for the properties, with the goal of displaying the needed message 
            //in the textboxes, instructing the user of what they should type in the boxes
            ProductName = "Vælg Produktnavn";
            ProductID ="Vælg ProduktID";
            Category = "Vælg Kategori";
            ProductDescription = "Vælg beskrivelse";
            Price = "Vælg pris";
            AmountInStock = "Angiv antal på lager";
            ShippingPrice = "Vælg fragt pris";
            Size = "Angiv størrelse";
            DiscountPrice = "Vælg tilbudspris";
            ProductImage = "Vælg billede";
        }

        public void AddProductControl()
        {
            AddProduct();
        }
        
    }
}


