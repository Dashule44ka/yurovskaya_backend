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
    public class DizsController : ControllerBase
    {
        private readonly DizContext _context;

        public DizsController(DizContext context)
        {
            _context = context;
        }

        // GET: api/Dizs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Diz>>> GetDiz()
        {
          if (_context.Diz == null)
          {
              return NotFound();
          }
            return await _context.Diz.ToListAsync();
        }

        // GET: api/Dizs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Diz>> GetDiz(int id)
        {
          if (_context.Diz == null)
          {
              return NotFound();
          }
            var diz = await _context.Diz.FindAsync(id);

            if (diz == null)
            {
                return NotFound();
            }

            return diz;
        }

        // PUT: api/Dizs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiz(int id, Diz diz)
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
        public async Task<ActionResult<Diz>> PostDiz(Diz diz)
        {
          if (_context.Diz == null)
          {
              return Problem("Entity set 'DizContext.Diz'  is null.");
          }
            _context.Diz.Add(diz);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDiz", new { id = diz.id }, diz);
        }

        // DELETE: api/Dizs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiz(int id)
        {
            if (_context.Diz == null)
            {
                return NotFound();
            }
            var diz = await _context.Diz.FindAsync(id);
            if (diz == null)
            {
                return NotFound();
            }

            _context.Diz.Remove(diz);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //[HttpGet("OrdersByClient/")]
        //public async Task<ActionResult<List<order>>> GetOrdersByClientId(int id)
        //{
        //    if (_context.order == null)
        //    {
        //        return NotFound();
        //    }
        //    List<order> result = new List<order>();
        //    if (User.FindFirst("id")?.Value == id.ToString())
        //    {
        //        result = _context.Diz.Include(o => o.client).Where(o => o.client == id).ToList();
        //    }


        //    return result;
        //}

        private bool DizExists(int id)
        {
            return (_context.Diz?.Any(e => e.id == id)).GetValueOrDefault();
        }

    }
}
