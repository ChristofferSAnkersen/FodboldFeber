using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FodboldFeber;
using FodboldFeber.Model;
using FodboldFeber.ViewModel;
using FodboldFeber.View;
using System.Collections.Generic;



namespace UnitTests
{
    [TestClass]
    public class UnitTests
    {
        Products products = new Products();
        ShopVM shopVM = ShopVM.Instance;
        DataAccess dataAccess = new DataAccess();
        MainWindow mainWindow = new MainWindow();

        public List<ShopData> ListOfProducts = new List<ShopData>();
        //Makes sure that the connection string sued to establish a connection has some value
        [TestMethod]
        public void ConnectionEstablished()
        {
          
            string Connection = dataAccess.Access();
            Assert.IsNotNull(Connection);
        }
        //Checks if the default value for ProductName is loaded upon startup.
        [TestMethod]
        public void DefaultValuesLoaded()
        {
            Assert.AreNotEqual(shopVM.ProductName, null);
        }
    }
}
