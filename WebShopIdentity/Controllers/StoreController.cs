using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopIdentity.Models.Stores;
using WebShopIdentity.ViewModels;

namespace WebShopIdentity.Controllers
{
    public class StoreController : Controller
    {
        private readonly IStoreRepository _storeRepository;
        
        public StoreController(IStoreRepository storeRepository) 
        {
            this._storeRepository = storeRepository;
        }
        [HttpGet]
        public IActionResult AddToStore()
        {
            ViewBag.DocType = _storeRepository.VBagDoumentType();
            return View();
            
        }
        [HttpPost]
        public IActionResult AddToStore(Store store)
        {
            if (ModelState.IsValid)
            {
                _storeRepository.AddToStore(store);

            }
            return RedirectToAction("GetAllStores");

        }
        public IActionResult RemoveFromStore(int id) 
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _storeRepository.RemoveFromStore(id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }

            return RedirectToAction("GetAllStores");
        }
        public IActionResult GetAllStores()
        {
            return View(_storeRepository.GetAllStores());
        }
    }
}
