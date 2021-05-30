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
    public class MembersProductsController : ControllerBase
    {
        private readonly ClothingStoreContext _context;

        public MembersProductsController(ClothingStoreContext context)
        {
            _context = context;
        }

        // GET: api/MembersProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MembersProduct>>> GetMembersProduct()
        {
            return await _context.MembersProducts.ToListAsync();
        }

        // GET: api/MembersProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MembersProduct>> GetMembersProduct(int id)
        {
            var membersProduct = await _context.MembersProducts.FindAsync(id);

            if (membersProduct == null)
            {
                return NotFound();
            }

            return membersProduct;
        }

        // PUT: api/MembersProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMembersProduct(int id, MembersProduct membersProduct)
        {
            if (id != membersProduct.Id)
            {
                return BadRequest();
            }

            _context.Entry(membersProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MembersProductExists(id))
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

        // POST: api/MembersProducts
        [HttpPost]
        public async Task<ActionResult<MembersProduct>> PostMembersProduct(MembersProduct membersProduct)
        {
            _context.MembersProducts.Add(membersProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMembersProduct", new { id = membersProduct.Id }, membersProduct);
        }

        // DELETE: api/MembersProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMembersProduct(int id)
        {
            var membersProduct = await _context.MembersProducts.FindAsync(id);
            if (membersProduct == null)
            {
                return NotFound();
            }

            _context.MembersProducts.Remove(membersProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MembersProductExists(int id)
        {
            return _context.MembersProducts.Any(e => e.Id == id);
        }
    }
}
