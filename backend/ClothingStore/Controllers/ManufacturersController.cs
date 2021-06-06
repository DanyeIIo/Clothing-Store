using Infrastructure.Persistence.Models;
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
    public class ManufacturersController : ControllerBase
    {
        private readonly ClothingStoreContext _context;

        public ManufacturersController(ClothingStoreContext context)
        {
            _context = context;
        }

        // GET: api/Manufacturers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Manufacturer>>> GetManufacturer()
        {
            return await _context.Manufacturers.ToListAsync();
        }
        //ODataController
        // GET: api/Manufacturers/5
        [HttpGet("id")]
        public async Task<ActionResult<Manufacturer>> GetManufacturer([FromHeader] int id)
        {
            var manufacturer = await _context.Manufacturers.FindAsync(id);

            if (manufacturer == null)
            {
                return NotFound();
            }

            return manufacturer;
        }

        [HttpGet("{manufacturerName}")]
        public async Task<ActionResult<IEnumerable<Manufacturer>>> GetManufacturerByNameAsync(string manufacturerName)
        {
            var res = await _context.Manufacturers.Where(x => x.Equals(manufacturerName)).ToListAsync();
            if (res.Count > 0)
            {
                return Ok(res.First());
            }
            return NotFound();
        }

        // PUT: api/Manufacturers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManufacturer(int id, Manufacturer manufacturer)
        {
            if (id != manufacturer.Id)
            {
                return BadRequest();
            }

            _context.Entry(manufacturer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManufacturerExists(id))
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

        // POST: api/Manufacturers
        [HttpPost]
        public async Task<ActionResult<Manufacturer>> PostManufacturer(Manufacturer manufacturer)
        {
            _context.Manufacturers.Add(manufacturer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetManufacturer", new { id = manufacturer.Id }, manufacturer);
        }

        // DELETE: api/Manufacturers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManufacturer(int id)
        {
            var manufacturer = await _context.Manufacturers.FindAsync(id);
            if (manufacturer == null)
            {
                return NotFound();
            }

            _context.Manufacturers.Remove(manufacturer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{manufacturerName}")]
        public async Task<ActionResult<IEnumerable<Manufacturer>>> RemoveManufacturerByNameAsync(string manufacturerName)
        {
            var manufacturer = await _context.Manufacturers
                .Where(x => x.Name.ToLower()
                    .Equals(manufacturerName.ToLower())).FirstAsync();

            if (manufacturer is not null)
            {
                _context.Manufacturers.Remove(manufacturer);
                await _context.SaveChangesAsync();
                
                return NoContent();
            }

            return StatusCode(404);
        }

        private bool ManufacturerExists(int id)
        {
            return _context.Manufacturers.Any(e => e.Id == id);
        }

    }
}
