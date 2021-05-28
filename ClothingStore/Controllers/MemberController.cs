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
    public class MemberController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Member>>> GetAllCountries()
        {
            using var context = new ClothingStoreContext();
            
            return Ok(await context.Members.ToListAsync());
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
        [HttpPost("{email}")]
        public async Task<ActionResult<IEnumerable<Member>>> AddMemberByNameAsync(string email)
        {
            using var context = new ClothingStoreContext();

            var res = await context.Members
                .Where(x => x.Email.ToLower()
                    .Equals(email.ToLower())).ToListAsync();
            
            if (res.Count == 0)
            {
                Member member = new Member();
                member.Email = email;

                await context.Members.AddAsync(member);
                await context.SaveChangesAsync();
                return Ok();
            }
            return StatusCode(409);
        }
        [HttpPut()]
        public async Task<ActionResult<IEnumerable<Member>>> ChangeMemberByNameAsync(string memberEmailToChange, string newMemberEmail)
        {
            using var context = new ClothingStoreContext();

            var member = await context.Members
                .Where(x => x.Email.ToLower()
                    .Equals(memberEmailToChange.ToLower())).ToListAsync();
            
            if (member.Count > 0)
            {
                member[0].Email = newMemberEmail;
                await context.SaveChangesAsync();
                return Ok();
            }
            
            return StatusCode(404);
        }
        [HttpDelete()]
        public async Task<ActionResult<IEnumerable<Member>>> RemoveMemberByEmailAsync(string email)
        {
            using var context = new ClothingStoreContext();

            var member = await context.Members
                .Where(x => x.Email.ToLower()
                    .Equals(email.ToLower())).ToListAsync();

            if (member.Count > 0)
            {
                context.Members.Remove(member[0]);
                await context.SaveChangesAsync();
                return Ok();
            }
            
            return StatusCode(404);
        }
    }
}
