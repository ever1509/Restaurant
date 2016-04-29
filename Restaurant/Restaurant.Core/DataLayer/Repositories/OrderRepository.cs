using Restaurant.Core.DataLayer.Contracts;
using Restaurant.Core.EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.DataLayer.Repositories
{
    public class OrderRepository:Repository<Orders>,IOrderRepository
    {
        public OrderRepository(DbContext dbContext)
            :base(dbContext)
        {

        }
        public override Orders Get(Orders entity)
        {
            return DbSet.FirstOrDefault(item => item.OrderID == entity.OrderID);
        }
    }
}
