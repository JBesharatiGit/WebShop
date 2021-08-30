using WebShopIdentity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopIdentity.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult CountryList()
        {
            
            var model = _context.Countries.ToList();
            ViewBag.Country= _context.Countries.ToList();

            return View(model);
        }
        [AllowAnonymous]
        public IActionResult CitiesList()
        {

            var model = _context.Cties.ToList();
            ViewBag.City = _context.Cties.ToList();

            return View(model);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult CreateCountry()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCountry(Country country)
        {
            _context.Database.EnsureCreated();
            _context.Countries.Add(country);
            _context.SaveChanges();

            return RedirectToAction("CountryList");
        }
        [Authorize(Roles = "Admin")]
        public IActionResult EditCountry(int id)
        {
            _context.Database.EnsureCreated();
            var model = _context.Countries
                .FirstOrDefault(item => item.Id == id);

            return View(model);
        }
        [HttpPost]
        public IActionResult EditCountry(Country country)
        {
            var entity = _context.Countries
                .FirstOrDefault(item => item.Id == country.Id);
            if (entity != null)
            {
                entity.CountryName = country.CountryName;
                _context.SaveChanges();
            }
            //_context.Database.EnsureCreated();
           
            //var model = _context.SaveChanges();

            return RedirectToAction("CountryList");
        }
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteCountry(int id)
        {
            _context.Database.EnsureCreated();
            var model = _context.Countries
                .FirstOrDefault(item => item.Id == id);
            if (model != null)
            {
                _context.Countries.Remove(model);
                _context.SaveChanges();
            }
            return RedirectToAction("CountryList");
        }
        [Authorize(Roles = "Admin")]
        public IActionResult CreateCity(int id)
        {
            var model = new City() { CountryId = id };
            ViewBag.model = model;
            return View();
        }
        [HttpPost]
        public IActionResult CreateCity(City city)
        {
            city.Id = 0;
            _context.Database.EnsureCreated();
            _context.Cties.Add(city);
            _context.SaveChanges();

            return RedirectToAction("CountryList");
        }

        
    }
}
