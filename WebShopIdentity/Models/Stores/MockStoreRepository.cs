using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopIdentity.Data;
using WebShopIdentity.ViewModels;

namespace WebShopIdentity.Models.Stores
{
    public class MockStoreRepository : IStoreRepository
    {
        private readonly ApplicationDbContext _context;
        public MockStoreRepository(ApplicationDbContext context) 
        {
            _context = context;
        }
        public Store AddToStore(Store store)
        {
            _context.Database.EnsureCreated();
            _context.Add(store);
            int result = _context.SaveChanges();
            return store;
        }

        public Store RemoveFromStore(int id)
        {
           var model= _context.Stores
                .FirstOrDefault(s => s.Id == id);

            if (model !=null)
            {
                _context.Remove(model);
                _context.SaveChanges();
            }
            else 
            {
                throw new ArgumentException("Argument not found");
            }
            return model;
        }

        public Store EditStore(Store storeChanges)
        {
            var store = _context.Stores.Attach(storeChanges);
            store.State= Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return storeChanges;


        }
        public IEnumerable<VW_Stores> GetAllStores() 
        {
            var model = _context.VW_Stores.ToList();
            return model;
        }
        public IEnumerable<DocumentType> VBagDoumentType() 
        {
           return _context.DocumentTypes.ToList();
        }
    }
}
