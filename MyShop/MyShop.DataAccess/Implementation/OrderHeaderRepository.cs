using MyShop.Entities.Models;
using MyShop.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.Implementation
{
    public class OrdreHeaderRepository : GenericRepository<OrderHeader>, IOrderHeaderRepository
    {
        private readonly ApplicationDbContext _context;
        public OrdreHeaderRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        

        public void Update(OrderHeader orderHeader)
        {
            _context.OrderHeaders.Update(orderHeader);
        }

        public void UpdateStatus(int id, string? OrderStatus, string? PaymentStatus)
        {
            var OrderFromDb = _context.OrderHeaders.SingleOrDefault(x => x.Id == id);
            if (OrderFromDb != null)
            {
                OrderFromDb.OdersStatus = OrderStatus;
                OrderFromDb.PaymentDate = DateTime.Now;
                if (PaymentStatus != null)
                {
                    OrderFromDb.PaymentStatus = PaymentStatus;
                }
            }
        }
    }
}
