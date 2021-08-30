using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopIdentity.Models;

namespace WebShopIdentity.ViewModels
{
    
    public class VW_StoreBalance
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public string CatName { get; set; }
        public string PhotoName { get; set; }
        public int sumIn { get; set; }
        public int sumOut { get; set; }
        public int Inventory { get; set; }
    }
}
