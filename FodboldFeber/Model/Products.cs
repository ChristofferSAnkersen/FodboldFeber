using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FodboldFeber.Model
{
    class Products
    {
        public Products Product { get; set; }
        //Måske skal listofproducts slettes
        public List<Products> ListOfProducts { get; set; }
        public string Query = "";
        public void AddProduct()
        {
            //Product = new Products { ProductID = 1, ProductName = "DækTilSideSpejl", Category = "Merchandise" };
            
            Query = "insert into Products(ProductID, ProductName, Category, ProductDescription, ProductPrice, AmountInStock, AmountInRoute, ShippingPrice) values("+ProductID+","+ProductName+","+Category+","+ProductDescription+","+ProductPrice+","+AmountInStock+","+AmountInRoute+","+ShippingPrice+");";  
        }
        public void UpdateProduct()
        {

        }
        public void DeleteProduct()
        {

        }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public string ProductDescription { get; set; }
        public double ProductPrice { get; set; }
        public int AmountInStock { get; set; }
        public int AmountInRoute { get; set; }
        public double ShippingPrice { get; set; }
    }
}
