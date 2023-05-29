﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using yurovskaya_backend.Models;

namespace yurovskaya_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class usersController : ControllerBase
    {
        private readonly OrderContext _context;

        public usersController(OrderContext context)
        {
            _context = context;
        }

        // GET: api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<user>>> Getuser()
        {
          if (_context.users == null)
          {
              return NotFound();
          }
            return await _context.users.ToListAsync();
        }

        // GET: api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<user>> Getuser(int id)
        {
          if (_context.users == null)
          {
              return NotFound();
          }
            var user = await _context.users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putuser(int id, user user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!userExists(id))
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

        // POST: api/users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<user>> Postuser(user user)
        {
          if (_context.users == null)
          {
              return Problem("Entity set 'DizContext.user'  is null.");
          }
            _context.users.Add(user);
            await _context.SaveChangesAsync();

            return StatusCode(201);
        }

        // DELETE: api/users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteuser(int id)
        {
            if (_context.users == null)
            {
                return NotFound();
            }
            var user = await _context.users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool userExists(int id)
        {
            return (_context.users?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        //////////////////////

        public struct LoginData
        {
            public string login { get; set; }
            public string password { get; set; }
        }

        private string HashStr(string value)
        {
            var str = Encoding.UTF8.GetBytes(value);
            var sb = new StringBuilder();
            foreach (var b in MD5.HashData(str))
                sb.Append(b.ToString("x2"));
            return sb.ToString();
        }

        [HttpPost("auth")]
        public object GetToken([FromBody] LoginData ld)
        {
            ld.password = HashStr(ld.password);
            var user = _context.users.FirstOrDefault(u => u.Login == ld.login && u.PasswordHash == ld.password);
            if (user == null)
            {
                Response.StatusCode = 401;
                return new { message = "wrong login/password" };
            }
            return authorization.GenerateToken(user.IsAdmin/*, user.IsWorker*/);
        }

    }
}
