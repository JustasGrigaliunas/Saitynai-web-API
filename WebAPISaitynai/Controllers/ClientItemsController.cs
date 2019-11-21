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
    public class ClientItemsController : ControllerBase
    {
        private readonly TodoContext _context;

        public ClientItemsController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/ClientItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientItem>>> GetClientItems()
        {
            return await _context.ClientItems.ToListAsync();
        }

        // GET: api/ClientItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientItem>> GetClientItem(long id)
        {
            var clientItem = await _context.ClientItems.FindAsync(id);

            if (clientItem == null)
            {
                return NotFound();
            }

            return clientItem;
        }

        // PUT: api/ClientItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClientItem(long id, ClientItem clientItem)
        {
            if (id != clientItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(clientItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientItemExists(id))
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

        // POST: api/ClientItems
        [HttpPost]
        public async Task<ActionResult<ClientItem>> PostClientItem(ClientItem clientItem)
        {
            _context.ClientItems.Add(clientItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetClientItem), new { id = clientItem.Id }, clientItem);
        }

        // DELETE: api/ClientItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ClientItem>> DeleteClientItem(long id)
        {
            var clientItem = await _context.ClientItems.FindAsync(id);
            if (clientItem == null)
            {
                return NotFound();
            }

            _context.ClientItems.Remove(clientItem);
            await _context.SaveChangesAsync();

            return clientItem;
        }

        private bool ClientItemExists(long id)
        {
            return _context.ClientItems.Any(e => e.Id == id);
        }
    }
}
