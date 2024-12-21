using MyShop.Entities.Models;
using MyShop.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.Implementation
{
    public class ShoppingCartRepository : GenericRepository<ShoppingCart>, IShoppingCartRepository
    {
        private readonly ApplicationDbContext _context;
        public ShoppingCartRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public int DecreaseCount(ShoppingCart shoppingCart, int count)
        {
            shoppingCart.Count -= count;
            return shoppingCart.Count;
        }

        public int IncreaseCount(ShoppingCart shoppingCart, int count)
        {
            shoppingCart.Count += count;
            return shoppingCart.Count;
        }

        //public void Update(Category category)
        //{
        //    var categoryInDb = _context.Categories.FirstOrDefault(x=> x.Id == category.Id);
        //    if (categoryInDb != null)
        //    {
        //        categoryInDb.Name = category.Name;
        //        categoryInDb.Description = category.Description;
        //        categoryInDb.CreatedTime = DateTime.Now;
        //    }
        //}
    }
}
