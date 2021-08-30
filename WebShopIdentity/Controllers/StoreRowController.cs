using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopIdentity.Models.Stores;

namespace WebShopIdentity.Controllers
{
    public class StoreRowController : Controller
    {
        private readonly IStoreRowRepository _storeRowRepository;
        public StoreRowController(IStoreRowRepository storeRowRepository) 
        {
            _storeRowRepository = storeRowRepository;
        }
        [HttpGet]
        public IActionResult AddStoreRow(int id)
        {
            var s=_storeRowRepository.VBageStore(id);
            ViewBag.StoreId = s.Id;
            ViewBag.Products = _storeRowRepository.VBagProduct();
            if (s.DocumentTypeId == 1)
            {
                return View("AddStoreRowReceipt");
            }
            else if(s.DocumentTypeId == 2) 
            {
                return View("AddStoreRowRemittance");
            }
            return RedirectToAction("GetAllStoreRows", new { id = s.Id });

        }

        [HttpPost]
        public IActionResult AddStoreRow(StoreRow storeRow)
        {
            if (ModelState.IsValid)
            {
                _storeRowRepository.AddStoreRow(storeRow);
            }
           
            return RedirectToAction("GetAllStoreRows",new {id= storeRow.StoreId });
        }
        public IActionResult GetAllStoreRows(int id)
        {
            var model = _storeRowRepository.GetAllStoreRows(id);
            //ViewBag.Store = model.Where(s=>s.Id==id);
            ViewBag.Store = _storeRowRepository.VBageStore(id);
            return View(model);
        }
        public IActionResult RemoveStoreRows(int id) 
        {
            var row = _storeRowRepository.RemoveStoreRow(id);
            return RedirectToAction("GetAllStoreRows", new { Id = row.StoreId });
        }
    }
}
