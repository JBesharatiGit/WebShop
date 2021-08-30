using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopIdentity.Data;
using WebShopIdentity.ViewModels;

namespace WebShopIdentity.Models.Stores
{
    
    public class MockStoreRowRepository : IStoreRowRepository
    {
        private readonly ApplicationDbContext _context;
        public MockStoreRowRepository(ApplicationDbContext context) 
        {
            this._context = context;
        }
            public StoreRow AddStoreRow(StoreRow storeRow)
        {
            storeRow.Id = 0;

            _context.Database.EnsureCreated();
            _context.Add(storeRow);
            int result = _context.SaveChanges();
            return storeRow;
        }

        public StoreRow EditStorRow(StoreRow storeRow)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VW_StoreRows> GetAllStoreRows(int id)
        {
            //var modelS = _context.VW_Stores.ToList();
          var model=  _context.VW_StoreRows.Where(s=>s.StoreId==id).ToList();
            
            return model;
        }

        public StoreRow RemoveStoreRow(int id)
        {
            var model = _context.StoreRows.FirstOrDefault(R => R.Id == id);
            if (model != null)
            {
                _context.StoreRows.Remove(model);
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException("Argument not found");
            }
            return model;
        }

        public VW_Stores VBageStore(int id)
        {
            var model = _context.VW_Stores.FirstOrDefault(o => o.Id == id);
            return model;
        }
        public IEnumerable<Product> VBagProduct()
        {

            var model = _context.Products.ToList();


            return model;
        }
    }
}
