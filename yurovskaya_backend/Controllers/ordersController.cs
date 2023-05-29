using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using yurovskaya_backend.Models;

namespace yurovskaya_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderContext _context;

        public OrdersController(OrderContext context)
        {
            _context = context;
        }

        // GET: api/Dizs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetDiz()
        {
          if (_context.orders == null)
          {
              return NotFound();
          }
            return await _context.orders.ToListAsync();
        }

        // GET: api/Dizs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetDiz(int id)
        {
          if (_context.orders == null)
          {
              return NotFound();
          }
            var diz = await _context.orders.FindAsync(id);

            if (diz == null)
            {
                return NotFound();
            }

            return diz;
        }

        // PUT: api/Dizs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiz(int id, Order diz)
        {
            if (id != diz.id)
            {
                return BadRequest();
            }

            _context.Entry(diz).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DizExists(id))
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

        // POST: api/Dizs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Order>> PostDiz(OrderDTO dto)
        {
          if (_context.orders == null)
          {
              return Problem("Entity set 'DizContext.Diz'  is null.");
          }
            
            var user = await _context.clients.FindAsync(dto.clientid);
            var tp = await _context.designs.FindAsync(dto.designid);
            if (tp == null || user == null) { return NotFound(); }
            var ord = new Order(dto);
            _context.orders.Add(ord);

            await _context.SaveChangesAsync();

            return StatusCode(201);
        }

        // DELETE: api/Dizs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiz(int id)
        {
            if (_context.orders == null)
            {
                return NotFound();
            }
            var diz = await _context.orders.FindAsync(id);
            if (diz == null)
            {
                return NotFound();
            }

            _context.orders.Remove(diz);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("OrdersByClient/")]
        public async Task<ActionResult<List<Order>>> GetOrdersByClientId(int id)
        {
            if (_context.orders == null)
            {
                return NotFound();
            }
            List<Order> result = new List<Order>();
                result = _context.orders.Include(o => o.client).Where(o => o.client.Id == id).ToList();


            return result;
        }

        private bool DizExists(int id)
        {
            return (_context.orders?.Any(e => e.id == id)).GetValueOrDefault();
        }

    }
}
