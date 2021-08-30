using WebShopIdentity.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopIdentity.ViewModels
{
    public class ProductCreateViewModel
    {
        
        [Required(ErrorMessage = "Name is rquired")]
        [MaxLength(50, ErrorMessage = "Can not exceed 50 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Product price is required")]
        public double ProductPrice { get; set; }
        //[Required]
        public ProductCategory ProductCategory { get; set; }
        //[Required(ErrorMessage ="Product Category is required")]
        public int ProductCategoryID { get; set; }
        public IFormFile Photo { get; set; }
        public IEnumerable<OrderRow> OrderRow { get; set; }
    }
}
