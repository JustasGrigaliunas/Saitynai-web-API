using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPISaitynai.Models
{
    public class InvoiceItem
    {
        public long Id { get; set; }
        public string InvoiceNumber { get; set; }
        //Be PVM
        public double NetPrice { get; set; }
        //su PVM
        public double GrossPrice { get; set; }
        public double VATAmount { get; set; }
        public int VAT { get; set; }
        public bool IsPayed { get; set; }

        public int ClientItemId { get; set; }
        public ClientItem ClientItem { get; set; }
    }
}
