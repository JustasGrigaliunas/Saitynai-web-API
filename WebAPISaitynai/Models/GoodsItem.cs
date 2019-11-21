using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPISaitynai.Models
{
    public class GoodsItem
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        //Be PVM
        public double NetPrice { get; set; }
        //su PVM
        public double GrossPrice { get; set; }
        public double VATAmount { get; set; }
        public int VAT { get; set; }

        public int InvoiceItemId { get; set; }
        public InvoiceItem InvoiceItem { get; set; }
    }
}
