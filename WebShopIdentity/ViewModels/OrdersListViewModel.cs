using WebShopIdentity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopIdentity.ViewModels
{
    public class OrdersListViewModel
    {
        public Order order { get; set; }
        public string CpersonName { get; set; }
        public string  Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BillingAddress { get; set; }
        public string BillingZip { get; set; }
        public string BillibgCity { get; set; }
        public string DeliveryAddress { get; set; }
        public string DeliveryZip { get; set; }
        public string DeliveryCity { get; set; }
    }
}
