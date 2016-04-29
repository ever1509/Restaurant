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
    public class UserTypeRepository:Repository<UserType>,IUserTypeRepository
    {
        public UserTypeRepository(DbContext dbContext)
            :base(dbContext)
        {

        }
        public override UserType Get(UserType entity)
        {
            return DbSet.FirstOrDefault(item => item.UserTypeID == entity.UserTypeID);
        }
    }
}
