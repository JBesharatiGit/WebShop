using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopIdentity.Models
{
    public class ApplicationUser:IdentityUser
    {
        [PersonalData]
        public DateTime CareerDate { get; set; }
        public int CityId { get; set; }
        //public City City { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BillingAddress { get; set; }
        public string BillingZip { get; set; }
        public string BillibgCity { get; set; }
        public string DeliveryAddress { get; set; }
        public string DeliveryZip { get; set; }
        public string DeliveryCity { get; set; }
        public IEnumerable<Order> Orders { get; set; }

    }
}
