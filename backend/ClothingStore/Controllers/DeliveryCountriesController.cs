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
    public class DeliveryCountriesController : ControllerBase
    {
        private readonly ClothingStoreContext _context;

        public DeliveryCountriesController(ClothingStoreContext context)
        {
            _context = context;
        }

        // GET: api/DeliveryCountries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeliveryCountry>>> GetDeliveryCountry()
        {
            return await _context.DeliveryCountries.ToListAsync();
        }

        // GET: api/DeliveryCountries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeliveryCountry>> GetDeliveryCountry(int id)
        {
            var deliveryCountry = await _context.DeliveryCountries.FindAsync(id);

            if (deliveryCountry == null)
            {
                return NotFound();
            }

            return deliveryCountry;
        }

        [HttpGet("{countryName}")]
        public async Task<ActionResult<IEnumerable<DeliveryCountry>>> GetDeliveryCountryByNameAsync(string countryName)
        {
            var res = await _context.DeliveryCountries.Where(x => x.CountryName.Equals(countryName)).ToListAsync();

            if (res.Count > 0)
            {
                return Ok(res.First());
            }

            return NotFound();
        }

        // PUT: api/DeliveryCountries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeliveryCountry(int id, DeliveryCountry deliveryCountry)
        {
            if (id != deliveryCountry.Id)
            {
                return BadRequest();
            }

            _context.Entry(deliveryCountry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeliveryCountryExists(id))
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

        // POST: api/DeliveryCountries
        [HttpPost]
        public async Task<ActionResult<DeliveryCountry>> PostDeliveryCountry(DeliveryCountry deliveryCountry)
        {
            _context.DeliveryCountries.Add(deliveryCountry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeliveryCountry", new { id = deliveryCountry.Id }, deliveryCountry);
        }

        // DELETE: api/DeliveryCountries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeliveryCountry(int id)
        {
            var deliveryCountry = await _context.DeliveryCountries.FindAsync(id);
            if (deliveryCountry == null)
            {
                return NotFound();
            }

            _context.DeliveryCountries.Remove(deliveryCountry);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete()]
        public async Task<ActionResult<IEnumerable<DeliveryCountry>>> RemoveDeliveryCountryByNameAsync(string countryName)
        {
            var country = await _context.DeliveryCountries
                .Where(x => x.CountryName.ToLower()
                    .Equals(countryName.ToLower())).ToListAsync();

            if (country.Count > 0)
            {
                _context.DeliveryCountries.Remove(country[0]);
                await _context.SaveChangesAsync();
                return Ok();
            }

            return StatusCode(404);
        }

        private bool DeliveryCountryExists(int id)
        {
            return _context.DeliveryCountries.Any(e => e.Id == id);
        }
    }
}
