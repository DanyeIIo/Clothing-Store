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
    public class OrderController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrder()
        {
            using var context = new ClothingStoreContext();

            return Ok(await context.Orders.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrderByIdAsync([FromHeader] string orderId)
        {
            using var context = new ClothingStoreContext();

            var res = await context.Orders.Where(x => x.Id.Equals(orderId)).ToListAsync();

            if (res.Count > 0)
            {
                return Ok(res.First());
            }
            return NotFound();
        }
        [HttpPost()]
        public async Task<ActionResult<IEnumerable<Order>>> AddOrderByUserIdProductIdAsync(int productId,int memberId,int manufacturerId,int count)
        {
            //TODO dictionary to products
            using var context = new ClothingStoreContext();

            var member = await context.Members
                .FirstOrDefaultAsync(x => x.Id == memberId);

            var product = await context.Products
                .FirstOrDefaultAsync(x => x.Id == productId);

            var manufacturer = await context.Manufacturers
                .FirstOrDefaultAsync(x => x.Id == manufacturerId);

            if (member is null || product is null || manufacturer is null)
            {
                return StatusCode(404);
            }

            List<Order> orders = new List<Order>();
            for (int i = 0; i < count; i++)
            {
                Order order = new Order
                {
                    ProductId = productId,
                    MemberId = memberId,
                    ManufacturerId = manufacturerId
                };
                orders.Add(order);
            }
            
            await context.Orders.AddRangeAsync(orders);
            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpPatch()]
        public async Task<ActionResult<IEnumerable<Order>>> ChangeorderByNameAsync(int memberID, int productId, int manufacturerId, int newCount)
        {
            using var context = new ClothingStoreContext();

            var orders = await context.Orders
                .Where(x => x.MemberId == memberID && x.ProductId == productId && x.ManufacturerId == manufacturerId)
                .ToListAsync();


            if (orders.Count >= 1)
            {
                if (orders.Count > newCount)
                {
                    List<Order> removeOrder = new List<Order>();
                    for (int i = 0; i < orders.Count - newCount; i++)
                    {
                        removeOrder.Add(orders[i]);
                    }
                    context.Orders.RemoveRange(removeOrder);
                }
                else
                {
                    List<Order> addOrder = new List<Order>();
                    for (int i = 0; i < newCount-orders.Count; i++)
                    {
                        addOrder.Add(orders[0]);
                        addOrder[i].Id = 0;
                    }
                    await context.Orders.AddRangeAsync(addOrder);
                }
                await context.SaveChangesAsync();
                return Ok();
            }

            return StatusCode(404);
        }
        //[HttpDelete()]
        //public async Task<ActionResult<IEnumerable<OrderController>>> RemoveOrderControllerByEmailAsync(string email)
        //{
        //    using var context = new ClothingStoreContext();

        //    var OrderController = await context.Orders
        //        .Where(x => x..ToLower()
        //            .Equals(email.ToLower())).ToListAsync();

        //    if (OrderController.Count > 0)
        //    {
        //        context.Orders.Remove(OrderController[0]);
        //        await context.SaveChangesAsync();
        //        return Ok();
        //    }

        //    return StatusCode(404);
        //}
    }
}
