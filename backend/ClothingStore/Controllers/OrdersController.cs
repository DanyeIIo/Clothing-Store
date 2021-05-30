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
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly ClothingStoreContext _context;
        
        public OrdersController(ClothingStoreContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrder()
        {
            return await _context.Orders.ToListAsync();
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        [HttpPost()]
        public async Task<ActionResult<IEnumerable<Order>>> AddOrder(Order[] orders)
        {
            //TODO dictionary to products

            foreach (var order in orders)
            {
                var member = await _context.Members
                    .FirstOrDefaultAsync(x => x.Id == order.MemberId);

                var product = await _context.Products
                    .FirstOrDefaultAsync(x => x.Id == order.ProductId);

                var manufacturer = await _context.Manufacturers
                    .FirstOrDefaultAsync(x => x.Id == order.ManufacturerId);
                
                if (member is null || product is null || manufacturer is null)
                {
                    return StatusCode(404);
                }
            }

            await _context.Orders.AddRangeAsync(orders);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", orders);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }
            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
