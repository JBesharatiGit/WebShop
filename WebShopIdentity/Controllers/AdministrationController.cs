using WebShopIdentity.Data;
using WebShopIdentity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopIdentity.ViewModels;

namespace WebShopIdentity.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext _context;

        public AdministrationController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            _context = context;
        }

        //UDF20210812
        //[Authorize]
        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Admin()
        {
            return View();
        }

        [Authorize]
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult ProdAndOrder()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole() { Name = model.RoleName };
                IdentityResult result = await roleManager.CreateAsync(identityRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles", "Administration");
                }
            }

            return View(model);
        }
        [Authorize]
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult ListRoles()
        {
            var model = roleManager.Roles;
            return View(model);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id {id} not found";
                return View("Not found");
            }

            var model = new EditRoleViewModel() { Id = role.Id, RoleName = role.Name };
            foreach (var user in userManager.Users)
            {
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.UserName);
                }
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {
            var role = await roleManager.FindByIdAsync(model.Id);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id {model.Id} not found";
                return View("Not found");
            }
            else
            {
                role.Name = model.RoleName;
                var result = await roleManager.UpdateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles");
                }
                foreach (var eror in result.Errors)
                {
                    ModelState.AddModelError("", eror.Description);
                }
            }
            return View(model);
        }

        //public IActionResult TickAdmin() 
        //{
        //    userManager.FindByNameAsync("Test@hotmail.com");
        //    return RedirectToAction("EditUsersInRole",)
        //}

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> EditUsersInRole(/*string roleId*/string id)
        {
            ViewBag.roleId = id;
            var role = await roleManager.FindByIdAsync(/*roleId*/id);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with id={/*roleId*/id} can not be find";
                return View("Not Found");
            }
            var model = new List<UserRoleViewModel>();
            foreach (var user in userManager.Users)
            {
                var userRoleViewModel = new UserRoleViewModel
                {
                    Id = user.Id,
                    UserName = user.UserName
                };
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    userRoleViewModel.Ischecked = true;
                }
                else
                {
                    userRoleViewModel.Ischecked = false;
                }
                model.Add(userRoleViewModel);
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditUsersInRole(List<UserRoleViewModel> model, string /*roleId*/id)
        {
            var role = await roleManager.FindByIdAsync(id);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id ={/*roleId*/id} can not be found";
                return View("Role not found");
            }
            for (int i = 0; i < model.Count; i++)
            {
                var user = await userManager.FindByIdAsync(model[i].Id);
                IdentityResult result = null;
                if (model[i].Ischecked && !(await userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await userManager.AddToRoleAsync(user, role.Name);
                }
                else if (!model[i].Ischecked && (await userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await userManager.RemoveFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                }
                if (result.Succeeded)
                {
                    if (i < model.Count - 1)
                    {
                        continue;
                    }
                    else
                        return RedirectToAction("ListRoles");
                    //return RedirectToAction("/*EditRole*/ListRoles", new { Id = /*roleId*/id });


                }
            }

            return RedirectToAction("ListRoles");//RedirectToAction("EditRole", new { Id = /*roleId*/ id});
        }

        [AllowAnonymous]
        public IActionResult ListUsers()
        //public async Task<IActionResult> ListUsers()
        {

            var userid = userManager.GetUserId(HttpContext.User);
            //var currentUser = userManager.Users.Where(u => u.Id == userid);

            //var commonrole = await userManager.GetUsersInRoleAsync("common");

            //var UserRole = commonrole.FirstOrDefault(u => u.Id == userid);

            List<VW_UserCity> LstuserCityViewModel = new List<VW_UserCity>();
            
            if (User.IsInRole("Admin"))
            {
                var v = _context.VW_UserCity.ToList();
                LstuserCityViewModel.AddRange(v);
                
            }
            else  
            {
                var v = _context.VW_UserCity.ToList().Where(u => u.Id == userid);
                LstuserCityViewModel.AddRange(v);
            }
            return View(LstuserCityViewModel);
        }
        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult EditUser(string id)
        {

            var user = userManager.Users.FirstOrDefault(u => u.Id == id);
            ViewBag.City = _context.Cties.ToList();
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> EditUser(ApplicationUser applicationUser)
        {
            var user = await userManager.FindByIdAsync(applicationUser.Id);


            if (user == null)
            {
                ViewBag.ErrorMessage = $"user with Id {applicationUser.Id} not found";
                return View("Not found");
            }
            else
            {
                user.FirstName = applicationUser.FirstName;
                user.LastName = applicationUser.LastName;
                user.DeliveryCity = applicationUser.DeliveryCity;
                user.DeliveryZip = applicationUser.DeliveryZip;
                user.DeliveryAddress = applicationUser.DeliveryAddress;
                user.CityId = applicationUser.CityId;
                user.BillingAddress = applicationUser.BillingAddress;
                user.BillingZip = applicationUser.BillingZip;
                user.FirstName = applicationUser.FirstName;

                var result = await userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListUsers");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }
        //public async task<AppRole> GetRoleList()
        //{
        //}
        public async Task<IActionResult> ActivateUser() 
        {
            var userid = userManager.GetUserId(HttpContext.User);
            var currentUser = userManager.Users.FirstOrDefault(u => u.Id == userid);


            var role = await roleManager.FindByNameAsync("common");
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with  ={"common"} can not be found";
                return View("Role not found");
            }

            if (!(await userManager.IsInRoleAsync(currentUser, role.Name)))
            {
                IdentityResult result = null;
                if (!(await userManager.IsInRoleAsync(currentUser, role.Name)))
                {
                    result = await userManager.AddToRoleAsync(currentUser, role.Name);
                }

                if (result.Succeeded)
                {
                    ViewBag.result = "User is activated please log out and log in again!";
                    return View();
                }
            }
            else if ( (await userManager.IsInRoleAsync(currentUser, role.Name)))
            {
                ViewBag.result = "User already activated please log out and log in again!";
                return View();
            }




           

            ViewBag.result = "Unsuccessfull try!";
            return View();
        }
    }
}
