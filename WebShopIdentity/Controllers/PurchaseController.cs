using WebShopIdentity.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WebShopIdentity.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly IPurchaseRepository _purchaiseRepository;
        private readonly UserManager<ApplicationUser> userManager;
        public PurchaseController(IPurchaseRepository purchaseRepository, UserManager<ApplicationUser> userManager)
        {
            _purchaiseRepository = purchaseRepository;
            this.userManager = userManager;
        }
        public IActionResult Purchase()
        {
            try
            {
                var sessionVar = SessionOrder.GetObjectFromJason<List<OrderRow>>(HttpContext.Session, "Test");
                if (sessionVar != null) 
                {
                    Purchase purchase = new Purchase();

                    purchase.LstOrderRow = sessionVar;

                    var userid = userManager.GetUserId(HttpContext.User);
                    var currentUser = userManager.Users.Where(u => u.Id == userid);

                    purchase.UserId = userid;
                    purchase.OrderState = 1;

                    purchase.OrderDate = DateTime.Now.ToString();

                    var pr = _purchaiseRepository.Add(purchase);

                    HttpContext.Session.Clear();

                    //return RedirectToAction("GetAllOrderRows", "OrderRow", new { Id = pr.OrderId });
                    return RedirectToAction("MakeReceipt", "OrderRow", new { Id = pr.OrderId });
                    

                }


            }
            catch (Exception ex)
            {
                
                throw new ArgumentException("", ex.Message);
            }

            //return RedirectToAction("GAP","product");  
            return RedirectToAction("GAP", "product");
        }

       
    }
}
