using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopIdentity.Models.Stores
{
    public class DocumentType
    {
        public int Id { get; set; }
        public string DocumentName { get; set; }
        public IEnumerable<Store> Store { get; set; }
    }
}
