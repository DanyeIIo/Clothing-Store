using ClothingStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ClothingStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly ClothingStoreContext _context;

        public MembersController(ClothingStoreContext context)
        {
            _context = context;
        }

        // GET: api/Members
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Member>>> GetMember()
        {
            return await _context.Members.ToListAsync();
        }

        // GET: api/Members/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Member>> GetMember(int id)
        {
            var member = await _context.Members.FindAsync(id);

            if (member == null)
            {
                return NotFound();
            }

            return member;
        }

        [HttpGet("{email}")]
        public async Task<ActionResult<IEnumerable<Member>>> GetMemberByEmailAsync(string email)
        {
            using var context = new ClothingStoreContext();

            var res = await context.Members.Where(x => x.Equals(email)).ToListAsync();

            if (res.Count > 0)
            {
                return Ok(res.First());
            }
            return NotFound();
        }
        // PUT: api/Members/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMember(int id, Member member)
        {
            if (id != member.Id)
            {
                return BadRequest();
            }

            _context.Entry(member).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberExists(id))
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

        // POST: api/Members
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Member>> PostMember(Member member)
        {
            _context.Members.Add(member);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMember", new { id = member.Id }, member);
        }

        // DELETE: api/Members/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMember(int id)
        {
            var member = await _context.Members.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }

            _context.Members.Remove(member);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{email}")]
        public async Task<IActionResult> RemoveMemberByEmailAsync(string email)
        {
            using var context = new ClothingStoreContext();

            var member = await context.Members
                .Where(x => x.Email.ToLower().Equals(email.ToLower())).ToListAsync();

            if (member.Count > 0)
            {
                context.Members.Remove(member[0]);
                await context.SaveChangesAsync();
                return Ok();
            }

            return StatusCode(404);
        }

        private bool MemberExists(int id)
        {
            return _context.Members.Any(e => e.Id == id);
        }
    }
}
