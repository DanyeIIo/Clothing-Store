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
    public class ManufacturerController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Manufacturer>>> GetAllCountries()
        {
            using var context = new ClothingStoreContext();
            
            return Ok(await context.Manufacturers.ToListAsync());
        }

        [HttpGet("{manufacturerName}")]
        public async Task<ActionResult<IEnumerable<Manufacturer>>> GetManufacturerByNameAsync(string manufacturerName)
        {
            using var context = new ClothingStoreContext();
            
            var res = await context.Manufacturers.Where(x => x.Equals(manufacturerName)).ToListAsync();
            if (res.Count > 0)
            {
                return Ok(res.First());
            }
            return NotFound();
        }
        [HttpPost("{manufacturerName}")]
        public async Task<ActionResult<IEnumerable<Manufacturer>>> AddManufacturerByNameAsync(string manufacturerName)
        {
            using var context = new ClothingStoreContext();

            var res = await context.Manufacturers
                .Where(x => x.Name.ToLower()
                    .Equals(manufacturerName.ToLower())).ToListAsync();
            if (res.Count == 0)
            {
                Manufacturer manufacturer = new Manufacturer();
                manufacturer.Name = manufacturerName;

                await context.Manufacturers.AddAsync(manufacturer);
                await context.SaveChangesAsync();
                return Ok();
            }
            return StatusCode(409);
        }
        [HttpPut()]
        public async Task<ActionResult<IEnumerable<Manufacturer>>> ChangeManufacturerByNameAsync(string manufacturerNameToChange, string newManufacturerName)
        {
            using var context = new ClothingStoreContext();

            var manufacturer = await context.Manufacturers
                .Where(x => x.Name.ToLower()
                    .Equals(manufacturerNameToChange.ToLower())).ToListAsync();
            if (manufacturer.Count > 0)
            {
                manufacturer[0].Name = newManufacturerName;
                await context.SaveChangesAsync();
                return Ok();
            }
            return StatusCode(404);
        }
        [HttpDelete()]
        public async Task<ActionResult<IEnumerable<Manufacturer>>> RemoveManufacturerByNameAsync(string manufacturerName)
        {
            using var context = new ClothingStoreContext();

            var manufacturer = await context.Manufacturers
                .Where(x => x.Name.ToLower()
                    .Equals(manufacturerName.ToLower())).ToListAsync();

            if (manufacturer.Count > 0)
            {
                context.Manufacturers.Remove(manufacturer[0]);
                await context.SaveChangesAsync();
                return Ok();
            }
            return StatusCode(404);
        }
    }
}
