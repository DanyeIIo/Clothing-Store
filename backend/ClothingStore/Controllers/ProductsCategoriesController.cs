//using Infrastructure.Persistence.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Threading.Tasks;

//namespace ClothingStore.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ProductsCategoriesController : ControllerBase
//    {
//        private readonly ClothingStoreContext _context;

//        public ProductsCategoriesController(ClothingStoreContext context)
//        {
//            _context = context;
//        }

//        // GET: api/ProductsCategories
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<ProductsCategory>>> GetProductsCategory()
//        {
//            return await _context.ProductsCategories.ToListAsync();
//        }

//        // GET: api/ProductsCategories/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<ProductsCategory>> GetProductsCategory(int id)
//        {
//            var productsCategory = await _context.ProductsCategories.FindAsync(id);

//            if (productsCategory == null)
//            {
//                return NotFound();
//            }

//            return productsCategory;
//        }

//        // PUT: api/ProductsCategories/5
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutProductsCategory(int id, ProductsCategory productsCategory)
//        {
//            if (id != productsCategory.Id)
//            {
//                return BadRequest();
//            }

//            _context.Entry(productsCategory).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!ProductsCategoryExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }

//        // POST: api/ProductsCategories
//        [HttpPost]
//        public async Task<ActionResult<ProductsCategory>> PostProductsCategory(ProductsCategory productsCategory)
//        {
//            _context.ProductsCategories.Add(productsCategory);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetProductsCategory", new { id = productsCategory.Id }, productsCategory);
//        }

//        // DELETE: api/ProductsCategories/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteProductsCategory(int id)
//        {
//            var productsCategory = await _context.ProductsCategories.FindAsync(id);
//            if (productsCategory == null)
//            {
//                return NotFound();
//            }

//            _context.ProductsCategories.Remove(productsCategory);
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }

//        private bool ProductsCategoryExists(int id)
//        {
//            return _context.ProductsCategories.Any(e => e.Id == id);
//        }
//    }
//}
