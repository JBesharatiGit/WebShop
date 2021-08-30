using WebShopIdentity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopIdentity
{
    public class City
    {
        public int Id { get; set; }
        [Required]
        [DataType("Nvarchar(50)")]
        public string CityName { get; set; }
        [Required]
        public int CountryId { get; set; }
        public Country Country { get; set; }
        //public string ApplicationUserId { get; set; }
        //public IEnumerable<ApplicationUser> ApplicationUser { get; set; }

    }
}
