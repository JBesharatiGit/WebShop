using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopIdentity.Models
{
    public class ProductCategory
    {
        [Required]
        public int ProductCategoryID { get; set; }
        public string  Name { get; set; }
        public IEnumerable<Product> products { get; set; }
    }
}
