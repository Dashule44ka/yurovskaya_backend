using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using yurovskaya_backend.Models;

namespace yurovskaya_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ordersController : ControllerBase
    {
        private readonly DizContext _context;

        public ordersController(DizContext context)
        {
            _context = context;
        }

        // GET: api/orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<order>>> GetOrders()
        {
          if (_context.order == null)
          {
              return NotFound();
          }
            return await _context.order.ToListAsync();
        }

        // GET: api/orders/5
        [HttpGet("{id}")]
        [Authorize(Roles = "admin")] // везде добавит??? где нужно
        public async Task<ActionResult<order>> Getorder(int id)
        {
          if (_context.order == null)
          {
              return NotFound();
          }
            var order = await _context.order.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // PUT: api/orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putorder(int id, order order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!orderExists(id))
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

        // POST: api/orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<order>> Postorder(order order)
        {
          if (_context.order == null)
          {
              return Problem("Entity set 'DizContext.Orders'  is null.");
          }
            var orderr = new order(order.Id, order.description, order.title, order.title, order.version);
            _context.order.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getorder", new { id = order.Id }, order);
        }

        // DELETE: api/orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteorder(int id)
        {
            if (_context.order == null)
            {
                return NotFound();
            }
            var order = await _context.order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.order.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool orderExists(int id)
        {
            return (_context.order?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        // GET: api/order/version
        [HttpGet("search/")]
        public async Task<ActionResult<IEnumerable<order>>> GetorderByclient(int version)
        {
            if (_context.order == null)
            {
                return NotFound();
            }
            var orderr = await _context.order
                .Where(a => a.version == version)
                .ToListAsync();

            if (orderr == null)
            {
                return NotFound();
            }

            return orderr;
        }

    }
}
