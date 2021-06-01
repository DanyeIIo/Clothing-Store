////using CachingMVC.Models;
//using ClothingStore.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Caching.Memory;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace CachingMVC.Services
//{
//    public class UserService
//    {
//        private ClothingStoreContext _db;
//        private IMemoryCache _cache;
//        public UserService(ClothingStoreContext context, IMemoryCache memoryCache)
//        {
//            _db = context;
//            _cache = memoryCache;
//        }

//        public void Initialize()
//        {
//            if (!_db.Categories.Any())
//            {
//                _db.Categories.Add(
//                    new Category { Name = "Tom", Id = 1 }
//                );
//                _db.SaveChanges();
//            }
//        }

//        public async Task<IEnumerable<Category>> GetUsers()
//        {
//            return await _db.Categories.ToListAsync();
//        }

//        public async Task AddUser(User user)
//        {
//            _db.Categories.Add(user);
//            int n = await _db.SaveChangesAsync();
//            if (n > 0)
//            {
//                _cache.Set(user.Id, user, new MemoryCacheEntryOptions
//                {
//                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
//                });
//            }
//        }

//        public async Task<User> GetUser(int id)
//        {
//            User user = null;
//            if (!_cache.TryGetValue(id, out user))
//            {
//                user = await _db.Categories.FirstOrDefaultAsync(p => p.Id == id);
//                if (user != null)
//                {
//                    _cache.Set(user.Id, user,
//                    new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(5)));
//                }
//            }
//            return user;
//        }
//    }
//}