using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopIdentity.Models.Orders
{
    public class OrderState
    {
        public int Id { get; set; }
        public string StateName { get; set; }
        public IEnumerable<OrderRow> OrderRow { get; set; }
    }
}
