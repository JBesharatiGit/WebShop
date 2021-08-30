using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using WebShopIdentity.Data;
using WebShopIdentity.Models;
using WebShopIdentity.Models.Stores;

namespace WebShopIdentity.Models
{
    public class MockPurchaseRepository : IPurchaseRepository
    {
        private readonly ApplicationDbContext _context;
        public MockPurchaseRepository(ApplicationDbContext context) 
        {
            _context = context;
        }
        public Purchase Add(Purchase purchase)
        {
            Order order = new Order() {ApplicationUserId= purchase.UserId,OrderDate= purchase.OrderDate };
            Store store = new Store() { ReceipDate = purchase.OrderDate, DocumentTypeId = 2 };
            

            using (_context)
            {
                using (IDbContextTransaction  dbtrn=_context.Database.BeginTransaction())
                {
                    try
                    {
                        _context.Database.EnsureCreated();
                        _context.Orders.Add(order);
                        int result = _context.SaveChanges();
                        
                        int oid = order.OrderId;
                        purchase.OrderId = oid;

                        foreach (var item in purchase.LstOrderRow)
                        {
                            item.OrderId = oid;
                            item.OrderStateId = 1;
                            _context.OrderRows.Add(item);
                            _context.SaveChanges();
                        }

                        //Store
                        _context.Add(store);
                        int rresult = _context.SaveChanges();

                        int sId = store.Id;
                        foreach (var item in purchase.LstOrderRow)
                        {
                            StoreRow storeRow = new StoreRow() {StoreId=sId, ProductId=item.ProductId,Credit=1 };
                            _context.Add(storeRow);
                            int roresult = _context.SaveChanges();
                        }
                        dbtrn.Commit();
                    }
                    catch (DbEntityValidationException ex)
                    {
                        dbtrn.Rollback();
                        throw new ArgumentException("",ex.Message);
                    }

                }

            }   


           
            return purchase;
        }
    }
}
