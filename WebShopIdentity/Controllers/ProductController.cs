using WebShopIdentity.Models;
using WebShopIdentity.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace WebShopIdentity.Properties
{
    //[Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly IproductRepository _productRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        //**Constructor**
        public ProductController(IproductRepository productRepository,IWebHostEnvironment webHostEnvironment) {
            _productRepository = productRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult GetProduct(int id) 
        {
            ViewBag.sessionList = GetSessionList();

            var model= _productRepository.GetProduct(id);
            return View(model);
        }
        public IActionResult GetAllProducts() 
        {
            return View(_productRepository.GetAllProducts());
        }

        [HttpGet]
        public IActionResult AddProduct() {
            ViewBag.Category = _productRepository.VBagCategory();
            return View();
        }
        
        [HttpPost]
        public IActionResult AddProduct(ProductCreateViewModel model)
        {

            if (ModelState.IsValid)
            {
                string uniqeFileName = null;
                if (model.Photo!=null)
                {
                  string uploadsFolder=  Path.Combine(_webHostEnvironment.WebRootPath , "Images\\");
                  uniqeFileName= Guid.NewGuid().ToString() + '_' + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder + uniqeFileName);
                    model.Photo.CopyTo(new FileStream(filePath,FileMode.Create));
                }
                Product product = new Product { Name = model.Name, ProductPrice = model.ProductPrice, ProductCategoryID = model.ProductCategoryID, PhotoName = uniqeFileName };
                _productRepository.AddProduct(product);
                return RedirectToAction("GetAllProducts");
                //return RedirectToAction("Detail",new { id=product.ProductID});

            }

            return View();
        }
        public IActionResult RemoveProduct(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _productRepository.RemoveProduct(id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
                
            }

            return RedirectToAction("GetAllProducts");
        }
        [HttpGet]
        public IActionResult EditProduct(int id) 
        {
            var model=_productRepository.EditProduct(null,id);
            ViewBag.Category = _productRepository.VBagCategory();

            return View(model);
        }
        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            _productRepository.EditProduct(product, 0);
            return RedirectToAction("GetAllProducts");
        }
        //[AllowAnonymous]
        [Authorize]
        public IActionResult GAP()
        {
            ViewBag.sessionList = GetSessionList();

            var model= _productRepository.GetAllProducts();
            return View(model);
        }
        
        
        //**Session IactionResult**
        public IActionResult AddToSessionVar(int id)
        {
            int counter = 0;
            List<OrderRow> myComplexObject = new List<OrderRow>();

            var s = SessionOrder.GetObjectFromJason<List<OrderRow>>(HttpContext.Session, "Test");
            var p = _productRepository.GetProduct(id);

            if (HttpContext.Session.Keys.Count() > 0)
            {
                myComplexObject.AddRange(s);
                counter = myComplexObject.Count();
            }

            counter += 1;
            myComplexObject.Add(new OrderRow { Id = 0, OrderId = counter, ProductId = p.product.ProductID, Price = p.product.ProductPrice });
            SessionOrder.SetObjectAsJson(HttpContext.Session, "Test", myComplexObject);

            return RedirectToAction("GetProduct", "Product",new {Id= id });
        }
        public IActionResult RemoveFromSessionVar(int id) 
        {
            List<OrderRow> myComplexObject = new List<OrderRow>();

            var s = SessionOrder.GetObjectFromJason<List<OrderRow>>(HttpContext.Session, "Test");
            //var p = _productRepository.GetProduct(id);

            if (HttpContext.Session.Keys.Count() > 0)
            {
                myComplexObject.AddRange(s);
                var removeArticle = myComplexObject.FirstOrDefault(p => p.OrderId == id);
                myComplexObject.Remove(removeArticle);
                int counter = 0;
                foreach (var item in myComplexObject)
                {
                    counter++;
                    item.OrderId = counter;
                }
            }

            // myComplexObject.Add(new OrderRow { Id = 0, OrderId = 0, ProductId = p.product.ProductID, Price = p.product.ProductPrice });
            SessionOrder.SetObjectAsJson(HttpContext.Session, "Test", myComplexObject);

            return RedirectToAction("GetSelected", "Product");

        }
        public IEnumerable<OrderRowListViewModel> GetSessionList()
        {
            var sessionVar = SessionOrder.GetObjectFromJason<List<OrderRow>>(HttpContext.Session, "Test");

            List<OrderRowListViewModel> lstOrderRowListViewModel = new List<OrderRowListViewModel>();
            if (sessionVar != null)
            {
                OrderRowListViewModel orderRowListViewModel;
                var prod = _productRepository.GetAllProducts();
                foreach (var o in sessionVar)
                {
                    orderRowListViewModel = new OrderRowListViewModel();
                    orderRowListViewModel.orderRow = o;
                    foreach (var p in prod)
                    {
                        if (o.ProductId == p.ProductID)
                        {
                            orderRowListViewModel.ProductName = p.ProductName;
                            break;
                        }

                    }

                    lstOrderRowListViewModel.Add(orderRowListViewModel);
                }

            }
            return lstOrderRowListViewModel;
        }
        public IActionResult GetSelected(int id)
        {
            ViewBag.sessionList = GetSessionList();
            return View();
        }

    }
}
