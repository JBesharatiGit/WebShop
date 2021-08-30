using WebShopIdentity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopIdentity.Models.Orders;

namespace WebShopIdentity.Models
{
    public interface IOrderRowRepository
    {
        OrderRow GetOrderRow(int id);
        public IEnumerable<OrderRowListViewModel> GetAllOrderRows(int id);
        OrderRow AddOrderRow(OrderRow orderRow);
        OrderRow RemoveOrderRow(int id);
        OrderRow EditOrderRow(OrderRow ordeRowChanges);
        public IEnumerable<Product> VBagProduct();
        public Order VBageOrder(int id);
        public IEnumerable<OrderState> VBageState();
    }
}
