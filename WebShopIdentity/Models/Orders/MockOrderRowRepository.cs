using WebShopIdentity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopIdentity.Data;
using WebShopIdentity.Models.Orders;

namespace WebShopIdentity.Models
{
    public class MockOrderRowRepository : IOrderRowRepository
    {
        ApplicationDbContext _context;
        public MockOrderRowRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public OrderRow AddOrderRow(OrderRow orderRow)
        {
            double pprice = _context.Products
               .FirstOrDefault(e => e.ProductID == orderRow.ProductId).ProductPrice;
            orderRow.Price = pprice;
            orderRow.Id = 0;

            _context.Database.EnsureCreated();
            _context.OrderRows.Add(orderRow);
            _context.SaveChanges();

            return orderRow;
        }

        public OrderRow EditOrderRow(OrderRow ordeRowChanges)
        {
            double pprice = _context.Products
               .FirstOrDefault(e => e.ProductID == ordeRowChanges.ProductId).ProductPrice;
            ordeRowChanges.Price = pprice;
           

            var orderRow= _context.OrderRows.Attach(ordeRowChanges);
            orderRow.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return ordeRowChanges;

        }

        public IEnumerable<OrderRowListViewModel> GetAllOrderRows(int id)
        {
            List<OrderRowListViewModel> lstOrderRowListViewModel=new List<OrderRowListViewModel>();
            OrderRowListViewModel orderRowListViewModel;

            var oRows = _context.OrderRows.Where(o=>o.OrderId==id).ToList();
            var prod = _context.Products.ToList();
            foreach (var o in oRows)
            {
                orderRowListViewModel = new OrderRowListViewModel();
                orderRowListViewModel.orderRow = o;
                foreach (var p in prod)
                {
                    if (o.ProductId==p.ProductID)
                    {
                        orderRowListViewModel.ProductName = p.Name;
                        break;
                    }

                }
                lstOrderRowListViewModel.Add(orderRowListViewModel);

            }
            return lstOrderRowListViewModel;
        }

        public OrderRow GetOrderRow(int id)
        {
           var model= _context.OrderRows.FirstOrDefault(or => or.Id == id);
            return model;

        }

        public OrderRow RemoveOrderRow(int id)
        {
           var model= _context.OrderRows.FirstOrDefault(R=>R.Id==id);
            if (model != null)
            {
                _context.OrderRows.Remove(model);
                _context.SaveChanges();
            }
            else 
            {
                throw new ArgumentNullException("Argument not found");
            }
            return model;
        }

        public IEnumerable<Product> VBagProduct()
        {

            var model = _context.Products.ToList();


            return model;
        }
        public Order VBageOrder(int id) 
        {
           var model= _context.Orders.FirstOrDefault(o => o.OrderId == id);
            return model;
        }
        public IEnumerable<OrderState> VBageState() 
        {
          return  _context.OrderStates.ToList();
        }
    }
}
