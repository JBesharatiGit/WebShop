using WebShopIdentity.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace WebShopIdentity.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OrdersController : Controller
    {
        //private readonly Models.ApplicationDbContext _context = new Models.ApplicationDbContext();
        private readonly IOrdersRepository _ordersRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public OrdersController(IOrdersRepository ordersRepository, UserManager<ApplicationUser> userManager) 
        {
            _ordersRepository = ordersRepository;
            this.userManager = userManager;
        }
        public IActionResult GetAllOrders() 
        {
           var model= _ordersRepository.GetAllOrders();
            return View(model);
        }
        [HttpGet]
        public IActionResult AddOrder() 
        {
            // ViewBag.User = _ordersRepository.VBagUser();
            var userid = userManager.GetUserId(HttpContext.User);
            var currentUser = userManager.Users.Where(u => u.Id == userid);

            ViewBag.User =currentUser;
            return View(); 
        }
        [HttpPost]
        public IActionResult AddOrder(Order order) 
        {
            if (ModelState.IsValid)
            {
                _ordersRepository.AddOrder(order);
                return RedirectToAction("GetAllOrders");

            }
            return View();
        }
        public IActionResult RemoveOrder(int id)
        {
           
            
            try
            {
                if (ModelState.IsValid)
                {
                    _ordersRepository.RemoveOrder(id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }

            return RedirectToAction("GetAllOrders");
        }

        [HttpGet]
        public IActionResult EditOrder(int id)
        {
            var model = _ordersRepository.EditOrder(null, id);
            ViewBag.Users = _ordersRepository.VBagUser();

            return View(model);
        }
        [HttpPost]
        public IActionResult EditOrder(Order order)
        {
            _ordersRepository.EditOrder(order, 0);
            return RedirectToAction("GetAllOrders");
        }

       

    }
}
