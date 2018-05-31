using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FodboldFeber.Model
{
    //Currently not in use, but we will leave it here for further expansion of the application
    class Orders
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public string DeliveryAddress { get; set; }
        public int AmountOfProductsOrdered { get; set; }
        public int DelivertTime { get; set; }
        public DateTime DateOfOrder { get; set; }
        public int TotalOrderPrice { get; set; }
        public object PaymentMethod { get; set; } //What is the best datatype here?
        public int TotalShippingPrice { get; set; }

    }
}
