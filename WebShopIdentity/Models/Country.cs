using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopIdentity
{
    public class Country
    {
        public int Id { get; set; }
        [Required]
        [DataType("Nvarchar(50)")]
        public string CountryName { get; set; }
        public IEnumerable<City> City { get; set; }
    }
}
