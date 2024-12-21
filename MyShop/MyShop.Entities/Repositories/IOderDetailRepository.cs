using MyShop.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Entities.Repositories
{
    public interface IOrderDetailRepository :IGenericRepository<OrderDtail>
    {
        void Update(OrderDtail orderDetail);

        
    }
}
