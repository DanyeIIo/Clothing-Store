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
    [ApiController]
    [Route("[controller]")]
    public class DeliveryCountryController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeliveryCountry>>> GetAllCountries()
        {
            using var context = new ClothingStoreContext();
            return Ok(await context.DeliveryCountries.ToListAsync());
        }
        // Todo here get countries for products

        [HttpGet("{countryName}")]
        public async Task<ActionResult<IEnumerable<DeliveryCountry>>> GetDeliveryCountryByNameAsync(string countryName)
        {
            using var context = new ClothingStoreContext();
            var res = await context.DeliveryCountries.Where(x => x.CountryName.Equals(countryName)).ToListAsync();
           
            if (res.Count > 0)
            {
                return Ok(res.First());
            }
            
            return NotFound();
        }
        [HttpPost("{countryName}")]
        public async Task<ActionResult<IEnumerable<DeliveryCountry>>> AddDeliveryCountryByNameAsync(string countryName)
        {
            using var context = new ClothingStoreContext();

            var res = await context.DeliveryCountries
                .Where(x => x.CountryName.ToLower()
                    .Equals(countryName.ToLower())).ToListAsync();
            
            if (res.Count == 0)
            {
                DeliveryCountry country = new DeliveryCountry();
                country.CountryName = countryName;
                
                await context.DeliveryCountries.AddAsync(country);
                await context.SaveChangesAsync();
                return Ok();
            }
            
            return StatusCode(409);
        }
        [HttpPut()]
        public async Task<ActionResult<IEnumerable<DeliveryCountry>>> ChangeDeliveryCountryByNameAsync(string nameToChange, string newCountryName)
        {
            using var context = new ClothingStoreContext();

            var country = await context.DeliveryCountries
                .Where(x => x.CountryName.ToLower()
                    .Equals(nameToChange.ToLower())).ToListAsync();
            
            if (country.Count > 0)
            {
                country[0].CountryName = newCountryName;
                await context.SaveChangesAsync();
                return Ok();
            }
            
            return StatusCode(404);
        }
        [HttpDelete()]
        public async Task<ActionResult<IEnumerable<DeliveryCountry>>> RemoveDeliveryCountryByNameAsync(string countryName)
        {
            using var context = new ClothingStoreContext();

            var country = await context.DeliveryCountries
                .Where(x => x.CountryName.ToLower()
                    .Equals(countryName.ToLower())).ToListAsync();

            if (country.Count > 0)
            {
                context.DeliveryCountries.Remove(country[0]);
                await context.SaveChangesAsync();
                return Ok();
            }
            
            return StatusCode(404);
        }
    }
}
