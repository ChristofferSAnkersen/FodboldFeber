using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FodboldFeber.Model;
using FodboldFeber.View;

namespace FodboldFeber.ViewModel

{
    public class ShopVM : Products
    {
        private static ShopVM instance;
        public static ShopVM Instance
        {
            get
            {
                if(instance==null)
                {
                    instance = new ShopVM();
                }
                return instance;
            }
        }
        Products products = new Products();
        public SearchFunction searchFunction { get; set; }

        private Products _selectedProduct;
        public Products SelectedProduct
        {
            get
            {
                return _selectedProduct;
            }
            set
            {
                if (value != this._selectedProduct)
                {
                    _selectedProduct = value;
                    OnPropertyChanged("SelectedProduct");
                }
            }
        }

        private ShopVM()
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

            //SelectedProduct = new Model.Products { ProductName = "", ProductID = 0, Category = "", ProductDescription = "", Price = 0, Size = "", ProductImage = "" };

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
   
        //Funktionality to ProductProfile
        public void UpdateProperties()
        {
            ProductName = "opdater?";
        }
        public event PropertyChangedEventHandler VMPropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = VMPropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }



    }
 
}


