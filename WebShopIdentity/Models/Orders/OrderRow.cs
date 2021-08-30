using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebShopIdentity.Models.Orders;

namespace WebShopIdentity.Models
{
    public class OrderRow
    {
        [Required]
        public int Id { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }
        public int OrderStateId { get; set; }
        public OrderState OrderState { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public double Price { get; set; }

    }
}
