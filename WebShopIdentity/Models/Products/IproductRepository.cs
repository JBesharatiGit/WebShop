using WebShopIdentity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopIdentity.Models
{
    public interface IproductRepository
    {
        ProductsListViewModel GetProduct(int id);
       // public IEnumerable<ProductsListViewModel> GetAllProducts();
        public IEnumerable<VW_StoreBalance> GetAllProducts();

        Product AddProduct(Product product);
        void RemoveProduct(int id);
        Product EditProduct(Product product,int? id);
        public IEnumerable<ProductCategory> VBagCategory();
        //List<Product> FilterListProduct(Product product);

    }
}
