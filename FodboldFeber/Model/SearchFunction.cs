using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FodboldFeber.InstantSearch;


namespace FodboldFeber.Model
{
    public class SearchFunction
    {
        //The lists where items are added. The most important is _allProductResultItems. Help results only show a certain string
        List<ProductsResultItem> _allProductResultItems;
        List<HelpResultItem> _allHelpResultItems;

        string _searchText; //The input in the textbox. loops through products added to _allProductResultItems
        public string SearchText
        {
            get
            {
                return _searchText;
            }
            set
            {
                _searchText = value;
                SearchResults.Clear();
                foreach (ProductsResultItem item in _allProductResultItems)
                {
                    if (item.ProductName.ToLower().Contains(_searchText.ToLower()))
                    {
                        SearchResults.Add(item);
                    }
                }
                foreach (HelpResultItem item in _allHelpResultItems)
                {
                    if (item.Title.ToLower().Contains(_searchText.ToLower()))
                    {
                        SearchResults.Add(item);
                    }
                }
            }
        }
        public ObservableCollection<ResultItem> SearchResults { get; set; } //The products that match the input is added here

        private ResultItem _selectedResult;
        // Handle selection here - What to do when item is selected
        public ResultItem SelectedResult
        {
            get
            {
                return _selectedResult;
            }
            set
            {
                _selectedResult = value;
                
            }
        }
        public SearchFunction() //SQL connection which adds all products to _allProductsResultItems. Take 2 parameters of products.
        {
            SearchResults = new ObservableCollection<ResultItem>();

            string connectionString = "Server=EALSQL1.eal.local; Database=DB2017_A27; User Id= USER_A27; Password=SesamLukOp_27;";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Products", con);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            _allProductResultItems = new List<ProductsResultItem>();
            while (reader.Read())
            {
                    _allProductResultItems.Add(new ProductsResultItem("Produkter",
                    (string)reader["ProductName"],
                    (string)reader["ProductDescription"]));
            }

            _allHelpResultItems = new List<HelpResultItem>
            {
                new HelpResultItem("Ingen Resultater", "Prøv at søge anderledes", "Eller kontakt support")
            };
            SearchText = "";
        }
    }
}
