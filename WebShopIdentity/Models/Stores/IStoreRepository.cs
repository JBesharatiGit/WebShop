using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopIdentity.ViewModels;

namespace WebShopIdentity.Models.Stores
{
    public interface IStoreRepository
    {
        public Store AddToStore(Store store);
        public Store RemoveFromStore(int id);
        public Store EditStore(Store store);
        public IEnumerable<VW_Stores> GetAllStores();
        public IEnumerable<DocumentType> VBagDoumentType();
    }
}
