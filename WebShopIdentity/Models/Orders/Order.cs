using WebShopIdentity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WebShopIdentity.Models
{
    public class Order
    {
        [Required]
        public int OrderId { get; set; }
        //[DisplayFormat(ApplyFormatInEditMode =true,DataFormatString ="{0:yyyy-MM-dd}")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Order Date")]
        public string OrderDate { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        [DisplayName("Customer Name")]
        public string ApplicationUserId { get; set; }
        public IEnumerable<OrderRow> OrderRow { get; set; }

    }
}
