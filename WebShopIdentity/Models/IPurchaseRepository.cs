using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopIdentity.Models
{
    public interface IPurchaseRepository
    {
        public Purchase Add(Purchase purchase);
    }
}
