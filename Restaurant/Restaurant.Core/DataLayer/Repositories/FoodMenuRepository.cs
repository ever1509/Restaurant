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
    public class FoodMenuRepository:Repository<FoodMenu>,IFoodMenuRepository
    {
        public FoodMenuRepository(DbContext dbContext)
            :base(dbContext)
        {

        }
        public override FoodMenu Get(FoodMenu entity)
        {
            return DbSet.FirstOrDefault(item => item.FoodMenuID == entity.FoodMenuID);
        }
    }
}
