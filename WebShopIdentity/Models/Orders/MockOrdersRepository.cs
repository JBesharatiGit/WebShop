using WebShopIdentity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopIdentity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;


namespace WebShopIdentity.Models
{
    public class MockOrdersRepository : IOrdersRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public MockOrdersRepository(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager) 
        {
            _context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public Order AddOrder(Order order)
        {
            _context.Database.EnsureCreated();
            _context.Orders.Add(order);
            int result = _context.SaveChanges();
            
            return order;
        }

        public Order EditOrder(Order orders, int? id)
        {
            if (id != 0)
            {
                var model = _context.Orders
                 .FirstOrDefault(e => e.OrderId == id);
                return model;
            }

            else
            {
                try
                {
                    var model = _context.Orders
                    .FirstOrDefault(e => e.OrderId == orders.OrderId);
                    //model.Name = orders.Name;
                    model.OrderDate = orders.OrderDate;
                    model.ApplicationUserId = orders.ApplicationUserId;

                    var result = _context.SaveChanges();
                }
                catch (Exception e)
                {

                    throw new Exception(e.Message);
                }

            }

            return orders;


        }

        public IEnumerable<OrdersListViewModel> GetAllOrders()
        {
            //var v = _context.VW_ShopHistory.ToList();
            OrdersListViewModel ordersListViewModel;
            List<OrdersListViewModel> lsordersListViewModel = new List<OrdersListViewModel>();
           
            _context.Database.EnsureCreated();
           
            var model = _context.Orders
                .OrderBy(x => x.OrderId)
                .ToList();
            //var user = _context.Users.ToList();
            var users = userManager.Users;
            foreach (var item in model)
            {
                ordersListViewModel = new OrdersListViewModel();
                ordersListViewModel.order = item;
                foreach (var u in users)
                {
                    if (u.Id == item.ApplicationUserId)
                    {
                        ordersListViewModel.CpersonName = u.FirstName+'-'+u.LastName;
                        ordersListViewModel.Email = u.Email;
                        break;
                    }

                }

                lsordersListViewModel.Add(ordersListViewModel);
            }
            return lsordersListViewModel;
        }

        public Order GetProduct(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveOrder(int id)
        {
            var model = _context.Orders
                 .FirstOrDefault(e => e.OrderId == id);
            if (model != null)
            {
                _context.Orders.Remove(model);
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Argument not found");
            }
        }

        public IEnumerable<ApplicationUser> VBagUser()
        {

            var model = userManager.Users;
           
            return model;
        }

        
       
    }
}
