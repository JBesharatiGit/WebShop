using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopIdentity.ViewModels
{
    public class VW_StoreRows
    {
        
        //public string ReceipDate { get; set; }
        //public string DocumentName { get; set; }
        public int Id { get; set; }
        public int StoreId { get; set; }
        public int Debit { get; set; }
        public int Credit { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int ProductCategoryID { get; set; }
        public double ProductPrice { get; set; }
    }
}
