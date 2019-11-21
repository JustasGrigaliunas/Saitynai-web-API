using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPISaitynai.Models
{
    public class ClientItem
    {
        public long Id { get; set; }
        
        public string Description { get; set; }
        public string CompanyCode { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsVATPayer { get; set; }

        public ICollection<InvoiceItem> InvoiceItems { get; set; }
    }
}
