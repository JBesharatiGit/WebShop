using WebShopIdentity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopIdentity.Models
{
    public interface IOrdersRepository
    {
        Order GetProduct(int id);
        public IEnumerable<OrdersListViewModel> GetAllOrders();
        Order AddOrder(Order order);
        void RemoveOrder(int id);
        Order EditOrder(Order orders, int? id);
        public IEnumerable<ApplicationUser> VBagUser();


    }
}
