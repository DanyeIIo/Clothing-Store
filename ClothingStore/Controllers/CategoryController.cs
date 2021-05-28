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
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAll()
        {
            using var context = new ClothingStoreContext();
            
            return Ok(await context.Categories.ToListAsync());
        }
        
        [HttpGet("{name}")]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategoryByNameAsync(string name)
        {
            using var context = new ClothingStoreContext();
            
            var res = await context.Categories
                .Where(category => category.Name.Equals(name))
                .ToListAsync();
        
            if (res.Count > 0)
            {
                return Ok(res.First());
            }
            
            return NotFound();
        }
        [HttpPost("{name}")]
        public async Task<ActionResult<IEnumerable<Category>>> AddCategoryByNameAsync(string name)
        {
            using var context = new ClothingStoreContext();

            var res = await context.Categories
                .Where(category => category.Name.ToLower()
                    .Equals(name.ToLower())).ToListAsync();
            
            if (res.Count == 0)
            {
                Category category = new Category(name);
                await context.Categories.AddAsync(category);
                await context.SaveChangesAsync();
                return Ok();
            }
            
            return StatusCode(409);
        }
        [HttpPut()]
        public async Task<ActionResult<IEnumerable<Category>>> ChangeCategoryByNameAsync(string nameToChange,string newName)
        {
            using var context = new ClothingStoreContext();

            var category = await context.Categories
                .Where(category => category.Name.ToLower()
                    .Equals(nameToChange.ToLower())).ToListAsync();
            
            if (category.Count > 0)
            {
                category[0].Name = newName;
                await context.SaveChangesAsync();
                return Ok();
            }
            
            return StatusCode(404);
        }
        [HttpDelete()]
        public async Task<ActionResult<IEnumerable<Category>>> RemoveCategoryByNameAsync(string name)
        {
            using var context = new ClothingStoreContext();

            var category = await context.Categories
                .Where(category => category.Name.ToLower()
                    .Equals(name.ToLower())).ToListAsync();
            
            if (category.Count > 0)
            {
                context.Categories.Remove(category[0]);
                await context.SaveChangesAsync();
                return Ok();
            }
            
            return StatusCode(404);
        }
    }
}
