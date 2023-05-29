using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using yurovskaya_backend.Models;
//using static System.Reflection.Metadata.BlobBuilder;

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
          if (_context.client == null)
          {
              return NotFound();
          }
            return await _context.client.ToListAsync();
        }

        //// GET: api/clients/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<client>> Getclient(int id)
        //{
        //  if (_context.client == null)
        //  {
        //      return NotFound();
        //  }
        //    var client = await _context.client.FindAsync(id);

        //    if (client == null)
        //    {
        //        return NotFound();
        //    }

        //    return client;
        //}

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
          if (_context.client == null)
          {
              return Problem("Entity set 'DizContext.Clients'  is null.");
          }
            //var clienttt = new client(client.Id, client.surname, client.name, client.email);
            //_context.client.Add(clienttt);
            var clientt = new client(client.Id, client.surname, client.name, client.email);
            _context.client.Add(clientt);
            await _context.SaveChangesAsync();

            return clientt;// вернуть 201 код
        }

        // DELETE: api/clients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteclient(int id)
        {
            if (_context.client == null)
            {
                return NotFound();
            }
            var clientt = await _context.client.FindAsync(id);
            if (clientt == null)
            {
                return NotFound();
            }

            _context.client.Remove(clientt);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool clientExists(int id)
        {
            return (_context.client?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        // GET: api/order/name
        [HttpGet("{name}")]
        public async Task<ActionResult<IEnumerable<client>>> GetorderByclient(string name)
        {
            if (_context.client == null)
            {
                return NotFound();
            }
            var clienttt = await _context.client
                .Where(a => a.name == name)
                .ToListAsync();

            if (clienttt == null)
            {
                return NotFound();
            }

            return clienttt;
        }

    }
}
