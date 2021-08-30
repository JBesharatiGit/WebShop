using WebShopIdentity.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using WebShopIdentity.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace WebShopIdentity.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class OrderRowController : Controller
    {
       // ApplicationDbContext _context = new ApplicationDbContext();
        private readonly IOrderRowRepository _orderRowRepository;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public OrderRowController(IOrderRowRepository orderRowRepository,UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager) 
        {
            _orderRowRepository = orderRowRepository;
            this.roleManager = roleManager;
            this.userManager = userManager;


        }

        public IActionResult GetAllOrderRows(int id) 
        {
            
            OrdersListViewModel order = new OrdersListViewModel();

            order.order = _orderRowRepository.VBageOrder(id);
            var u = userManager.Users.FirstOrDefault(u => u.Id == order.order.ApplicationUserId);

            order.CpersonName =u.FirstName  ;
            order.Email = u.Email;

            //order.BillingAddress = u.BillingAddress;
            //order.BillingZip = u.BillingZip;
            //order.BillibgCity = u.BillibgCity;
            //order.DeliveryAddress = u.DeliveryAddress;
            //order.DeliveryZip = u.DeliveryZip;
            //order.DeliveryCity = u.DeliveryCity;

            ViewBag.Order = order;
            ViewBag.Product = _orderRowRepository.VBagProduct();

            var model = _orderRowRepository.GetAllOrderRows(id);

            return View(model);
        }
         
        [HttpGet]
        public IActionResult AddOrderRow(int id)
        {
            ViewBag.OrderState = _orderRowRepository.VBageState();
            ViewBag.OrderId = id;
            ViewBag.Products = _orderRowRepository.VBagProduct();
            return View();
        }
        [HttpPost]
        public IActionResult AddOrderRow(OrderRow or)
        {
            _orderRowRepository.AddOrderRow(or);
            return RedirectToAction("GetAllOrderRows", new { Id=or.OrderId});
        }
        [HttpGet]
        public IActionResult EditOrderRow(int id) 
        {
            ViewBag.Products = _orderRowRepository.VBagProduct();
            
            var model=_orderRowRepository.GetOrderRow(id);
            ViewBag.Order = _orderRowRepository.VBageOrder(model.OrderId);
            return View(model);
        }
        [HttpPost]
        public IActionResult EditOrderRow(OrderRow orderRow)
        {

           var model= _orderRowRepository.EditOrderRow(orderRow);

            return RedirectToAction("GetAllOrderRows", new { Id = model.OrderId });
        }
        public IActionResult RemoveOrderRow(int id) 
        {
           var row= _orderRowRepository.RemoveOrderRow(id);
            return RedirectToAction("GetAllOrderRows", new { Id = row.OrderId });

        }

        public IActionResult MakeReceipt(int id)
        {

            OrdersListViewModel order = new OrdersListViewModel();

            order.order = _orderRowRepository.VBageOrder(id);
            var u = userManager.Users.FirstOrDefault(u => u.Id == order.order.ApplicationUserId);

            order.CpersonName = u.FirstName + " " + u.LastName;
            order.Email = u.Email;

            order.BillingAddress = u.BillingAddress;
            order.BillingZip = u.BillingZip;
            order.BillibgCity = u.BillibgCity;
            order.DeliveryAddress = u.DeliveryAddress;
            order.DeliveryZip = u.DeliveryZip;
            order.DeliveryCity = u.DeliveryCity;

            ViewBag.Order = order;
            ViewBag.Product = _orderRowRepository.VBagProduct();

            var model = _orderRowRepository.GetAllOrderRows(id);

            return View(model);
        }

        public IActionResult DisplaySession() 
        {
            var model = HttpContext.Session.GetObjectFromJason<List<OrderRow>>("100");
            return View();
        }


        //public JsonResult GetPrice(int id) 
        //{
        //   var p= _orderRowRepository.VBagProduct().Where(p => p.ProductID == id);

        //    return Json(new SelectList(p,"ProductId","Price"));
        //}
        

        
    }
}
