using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopIdentity.ViewModels;

namespace WebShopIdentity.Models.Stores
{
    public interface IStoreRowRepository
    {
        public StoreRow AddStoreRow(StoreRow storeRow);
        public StoreRow RemoveStoreRow(int id);
        public StoreRow EditStorRow(StoreRow storeRow);
        public IEnumerable<VW_StoreRows> GetAllStoreRows(int id);
        public VW_Stores VBageStore(int id);
        public IEnumerable<Product> VBagProduct();
    }
}
