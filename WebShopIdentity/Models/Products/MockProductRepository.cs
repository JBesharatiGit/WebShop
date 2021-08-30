using WebShopIdentity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopIdentity.Data;
using WebShopIdentity.Models;

namespace WebShopIdentity.Models
{
    public class MockProductRepository : IproductRepository
    {
        private readonly ApplicationDbContext _context;
        public MockProductRepository(ApplicationDbContext context) 
        {
            _context = context;
        }

        public Product AddProduct(Product product)
        {


            _context.Database.EnsureCreated();
            _context.Products.Add(product);
           int result= _context.SaveChanges();
            return product;
        }

        public Product EditProduct(Product product,int? id)
        {
            if (id!=0)
            {
                var model = _context.Products
                 .FirstOrDefault(e => e.ProductID == id);
                return model;
            }

            else
            {
                try
                {
                    var model = _context.Products
                    .FirstOrDefault(e => e.ProductID == product.ProductID);
                    model.Name = product.Name;
                    model.ProductPrice = product.ProductPrice;
                    model.ProductCategoryID = product.ProductCategoryID;
                    model.PhotoName = product.PhotoName;

                    var result = _context.SaveChanges();
                }
                catch (Exception e)
                {

                    throw new Exception(e.Message);
                }

            }

            return product;
               
            
        }

       // public IEnumerable<ProductsListViewModel> GetAllProducts()
        public IEnumerable<VW_StoreBalance> GetAllProducts()
        {


            //ProductsListViewModel productsListViewModel;
            //List<ProductsListViewModel> lsProductsListViewModel = new List<ProductsListViewModel>();
            //_context.Database.EnsureCreated();
            //var model = _context.Products
            //    .OrderBy(x => x.ProductID)
            //    //.Where(x => x.ProductID < 10)
            //    .ToList();
            //var cat = _context.ProductCategorys.ToList();
            //foreach (var item in model)
            //{
            //    productsListViewModel = new ProductsListViewModel();
            //    productsListViewModel.product = item;
            //    foreach (var c in cat)
            //    {
            //        if (c.ProductCategoryID == item.ProductCategoryID)
            //        {
            //            productsListViewModel.CtegoryName = c.Name;
            //            break;
            //        }

            //    }

            //    lsProductsListViewModel.Add(productsListViewModel);
            //}
            //return lsProductsListViewModel;

            var v = _context.VW_StoreBalance.ToList();
            return v;
        }

        public ProductsListViewModel GetProduct(int id)
        {
            ProductsListViewModel productsListViewModel=new ProductsListViewModel();
            productsListViewModel.product = _context.Products
                  .FirstOrDefault(p => p.ProductID == id);

            var cat = _context.ProductCategorys.ToList();

            foreach (var c in cat)
            {
                if (c.ProductCategoryID == productsListViewModel.product.ProductCategoryID)
                {
                    productsListViewModel.CtegoryName = c.Name;
                    break;
                }

            }

            return productsListViewModel;    
        }

        public void RemoveProduct(int id)
        {
            var model = _context.Products
                .FirstOrDefault(e => e.ProductID == id);
            if (model != null)
            {
                _context.Products.Remove(model);
                _context.SaveChanges();
            }
            else 
            {
                throw new ArgumentException("Argument not found");
            }
        }

        public IEnumerable<ProductCategory> VBagCategory() 
        {
        
           var model = _context.ProductCategorys.ToList();
             
            
            return model;
        }
    }
}
