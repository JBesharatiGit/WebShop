using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopIdentity.Models
{
    public class Purchase
    {
        public string UserId { get; set; }
        public int OrderId { get; set; }
        public string OrderDate { get; set; }
        public int OrderState { get; set; }
        public IEnumerable<OrderRow> LstOrderRow { get; set; }
        
    }
}
