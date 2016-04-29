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
    public class CategoryRepository : Repository<Categories>, ICategoryRepository
    {
        public CategoryRepository(DbContext dbContext)
            : base(dbContext)
        {

        }
        public override Categories Get(Categories entity)
        {
            return DbSet.FirstOrDefault(item => item.CategoryID == entity.CategoryID);
        }
    }
}
