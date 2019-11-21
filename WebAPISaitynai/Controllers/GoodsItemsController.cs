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
    public class GoodsItemsController : ControllerBase
    {
        private readonly TodoContext _context;

        public GoodsItemsController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/GoodsItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GoodsItem>>> GetGoodsItems()
        {
           
            return await _context.GoodsItems.ToListAsync();
        }
        //GET: api/ClientItems/5/InvoiceItems/5/GoodsItems
        [HttpGet("~/api/ClientItems/{clientid}/InvoiceItems/{invoiceid}/GoodsItems")]
        public async Task<ActionResult<IEnumerable<GoodsItem>>> GetGoodsItems(long clientid, long invoiceid)
        {
            var invoiceItems = await _context.InvoiceItems.Where(x => x.ClientItemId == clientid && x.Id == invoiceid).ToListAsync();
            if (invoiceItems.Count == 0)
            {
                return NotFound();
            }
            var goodsItems = await _context.GoodsItems.Where(x => x.InvoiceItemId == invoiceid).ToListAsync();
            if (goodsItems.Count == 0)
            {
                return NotFound();
            }

            return goodsItems;
        }
        // GET: api/GoodsItems/5
        [HttpGet("~/api/ClientItems/{clientid}/InvoiceItems/{invoiceid}/GoodsItems/{id}")]
        public async Task<ActionResult<GoodsItem>> GetGoodsItem(long clientid, long invoiceid, long id)
        {
            var invoiceItems = await _context.InvoiceItems.Where(x => x.ClientItemId == clientid && x.Id == invoiceid).ToListAsync();
            if (invoiceItems.Count == 0)
            {
                return NotFound();
            }
            var goodsItem = await _context.GoodsItems.FindAsync(id);

            if (goodsItem == null)
            {
                return NotFound();
            }

            return goodsItem;
        }

        // PUT: api/ClientItems/5/InvoiceItems/5/GoodsItems/5
        [HttpPut("~/api/ClientItems/{clientid}/InvoiceItems/{invoiceid}/GoodsItems/{id}")]
        public async Task<IActionResult> PutGoodsItem(long clientid, long invoiceid, long id, GoodsItem goodsItem)
        {
            var invoiceItems = await _context.InvoiceItems.Where(x => x.ClientItemId == clientid && x.Id == invoiceid).ToListAsync();
            if (invoiceItems.Count == 0)
            {
                return NotFound();
            }

            if (id != goodsItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(goodsItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GoodsItemExists(id))
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

        // POST: api/ClientItems/5/InvoiceItems/5/GoodsItems
        [HttpPost("~/api/ClientItems/{clientid}/InvoiceItems/{invoiceid}/GoodsItems")]
        public async Task<ActionResult<GoodsItem>> PostGoodsItem(long clientid, long invoiceid, GoodsItem goodsItem)
        {
            var invoiceItems = await _context.InvoiceItems.Where(x => x.ClientItemId == clientid && x.Id == invoiceid).ToListAsync();
            if (invoiceItems.Count == 0)
            {
                return NotFound();
            }
            _context.GoodsItems.Add(goodsItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGoodsItem), new { id = goodsItem.Id }, goodsItem);
        }

        // DELETE: api/ClientItems/5/InvoiceItems/5/GoodsItems/5
        [HttpDelete("~/api/ClientItems/{clientid}/InvoiceItems/{invoiceid}/GoodsItems{id}")]
        public async Task<ActionResult<GoodsItem>> DeleteGoodsItem(long clientid, long invoiceid, long id)
        {
            var invoiceItems = await _context.InvoiceItems.Where(x => x.ClientItemId == clientid && x.Id == invoiceid).ToListAsync();
            if (invoiceItems.Count == 0)
            {
                return NotFound();
            }
            var goodsItem = await _context.GoodsItems.FindAsync(id);
            if (goodsItem == null)
            {
                return NotFound();
            }

            _context.GoodsItems.Remove(goodsItem);
            await _context.SaveChangesAsync();

            return goodsItem;
        }

        private bool GoodsItemExists(long id)
        {
            return _context.GoodsItems.Any(e => e.Id == id);
        }
    }
}
