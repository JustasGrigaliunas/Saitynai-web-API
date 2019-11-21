using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPISaitynai.Models;

namespace WebAPISaitynai.Controllers
{
   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceItemsController : ControllerBase
    {
        private readonly TodoContext _context;

        public InvoiceItemsController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/InvoiceItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceItem>>> GetInvoiceItems()
        {
            return await _context.InvoiceItems.ToListAsync();
        }
        // GET: api/ClientItem/5/InvoiceItems
        [HttpGet("~/api/ClientItems/{clientid}/InvoiceItems")]
        public async Task<ActionResult<IEnumerable<InvoiceItem>>> GetInvoiceItemsByClient(long clientid)
        {
            var invoiceItem = await _context.InvoiceItems.FindAsync(clientid);

            var invoiceItem2 = await _context.InvoiceItems.Where(x => x.ClientItemId == clientid).ToListAsync();

            if (invoiceItem2.Count == 0)
            {
                return NotFound();
            }

            return invoiceItem2;
        }

        // GET: api/ClientItems/5/InvoiceItems/5
        [HttpGet("~/api/ClientItems/{clientid}/InvoiceItems/{id}")]
        public async Task<ActionResult<InvoiceItem>> GetInvoiceItem(long clientid,long id)
        {
            var invoiceItem = await _context.InvoiceItems.FindAsync(id);
            var invoiceItem2 = await _context.InvoiceItems.Where(x => x.ClientItemId == clientid && x.Id == id).ToListAsync();
            if (invoiceItem2.Count == 0)
            {
                return NotFound();
            }

            if (invoiceItem == null)
            {
                return NotFound();
            }

            return invoiceItem;
        }


        // PUT: api/ClientItems/5/InvoiceItems/5
        [HttpPut("~/api/ClientItems/{clientid}/InvoiceItems/{id}")]
        public async Task<IActionResult> PutInvoiceItem(long id, InvoiceItem invoiceItem)
        {
           
            if (id != invoiceItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(invoiceItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ClientItems/5/InvoiceItems
        [HttpPost("~/api/ClientItems/{clientid}/InvoiceItems")]
        public async Task<ActionResult<InvoiceItem>> PostInvoiceItem(long clientid, InvoiceItem invoiceItem)
        {
            var clientItems = await _context.ClientItems.FindAsync(clientid);
            if (clientItems == null)
            {
                return NotFound();
            }
            _context.InvoiceItems.Add(invoiceItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetInvoiceItem), new { id = invoiceItem.Id }, invoiceItem);
        }

        // DELETE: api/ClientItems/5/InvoiceItems/5
        [HttpDelete("~/api/ClientItems/{clientid}/InvoiceItems/{id}")]
        public async Task<ActionResult<InvoiceItem>> DeleteInvoiceItem(long clientid, long id)
        {
            var invoiceItem = await _context.InvoiceItems.FindAsync(id);
            if (invoiceItem == null)
            {
                return NotFound();
            }
            var invoiceItem2 = await _context.InvoiceItems.Where(x => x.ClientItemId == clientid && x.Id == id).ToListAsync();
            if (invoiceItem2.Count == 0)
            {
                return NotFound();
            }

            _context.InvoiceItems.Remove(invoiceItem);
            await _context.SaveChangesAsync();

            return invoiceItem;
        }

        private bool InvoiceItemExists(long id)
        {
            return _context.InvoiceItems.Any(e => e.Id == id);
        }
    }
}
