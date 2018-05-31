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

        private object _selectedProduct;
        public object SelectedProduct
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
        //Functionality to Shop
        public void PopulateList()
        {
            products.FillList(ListOfProducts);
        }
       
        //Functionality to AdminTools
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


