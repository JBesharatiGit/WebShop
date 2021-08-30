using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopIdentity.Models.Stores
{
    public class StoreRow
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [DisplayName("Input Quantity")]
        public int Debit { get; set; }
        [DisplayName("Output Quantity")]
        public int Credit {get; set;}
        }
}
