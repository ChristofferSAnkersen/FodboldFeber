﻿using System;
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

        List<ProductsResultItem> _allProductResultItems;
        List<HelpResultItem> _allHelpResultItems;

        string _searchText;
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
        public ObservableCollection<ResultItem> SearchResults { get; set; }

        ResultItem _selectedResult;
        public ResultItem SelectedResult
        {
            get
            {
                return _selectedResult;
            }
            set
            {
                _selectedResult = value;
                // Handle selection here
            }
        }
        public SearchFunction()
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

            _allHelpResultItems = new List<HelpResultItem>();
            _allHelpResultItems.Add(new HelpResultItem("Ingen Resultater", "Prøv at søge anderledes", "Eller kontakt support"));
            SearchText = "";
        }
    }
}
