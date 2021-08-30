using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using WebShopIdentity.Models.Stores;

namespace WebShopIdentity.ViewModels
{
    public class VW_Stores
    {
        public int Id { get; set; }
        [DisplayName("Document Date")]
        public string ReceipDate { get; set; }
        public int DocumentTypeId { get; set; }
        public string DocumentName { get; set; }
        
    }
}
