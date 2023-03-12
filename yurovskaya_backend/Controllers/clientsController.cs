using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using yurovskaya_backend.Models;

namespace yurovskaya_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class clientsController : ControllerBase
    {
        private readonly DizContext _context;

        public clientsController(DizContext context)
        {
            _context = context;
        }

        // GET: api/clients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<client>>> GetClients()
        {
          if (_context.Clients == null)
          {
              return NotFound();
          }
            return await _context.Clients.ToListAsync();
        }

        // GET: api/clients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<client>> Getclient(int id)
        {
          if (_context.Clients == null)
          {
              return NotFound();
          }
            var client = await _context.Clients.FindAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

        // PUT: api/clients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putclient(int id, client client)
        {
            if (id != client.Id)
            {
                return BadRequest();
            }

            _context.Entry(client).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!clientExists(id))
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

        // POST: api/clients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<client>> Postclient(client client)
        {
          if (_context.Clients == null)
          {
              return Problem("Entity set 'DizContext.Clients'  is null.");
          }
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getclient", new { id = client.Id }, client);
        }

        // DELETE: api/clients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteclient(int id)
        {
            if (_context.Clients == null)
            {
                return NotFound();
            }
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool clientExists(int id)
        {
            return (_context.Clients?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
