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
    public class SaleControlRepository:Repository<SaleControl>,ISaleControlRepository
    {
        public SaleControlRepository(DbContext dbContext)
            :base(dbContext)
        {

        }
        public override SaleControl Get(SaleControl entity)
        {
            return DbSet.FirstOrDefault(item => item.SaleControlID == entity.SaleControlID);
        }
    }
}
