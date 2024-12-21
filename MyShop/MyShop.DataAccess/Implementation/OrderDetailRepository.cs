using MyShop.Entities.Models;
using MyShop.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.Implementation
{
    public class OrdreDetailRepository : GenericRepository<OrderDtail>, IOrderDetailRepository
    {
        private readonly ApplicationDbContext _context;
        public OrdreDetailRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(OrderDtail orderDetail)
        {
            _context.OrderDtails.Update(orderDetail); 
        }
    }
}
