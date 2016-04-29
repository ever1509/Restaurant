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
    public class UserRepository:Repository<User>,IUserRepository
    {
        public UserRepository(DbContext dbContext)
            :base(dbContext)
        {

        }
        public override User Get(User entity)
        {
            return DbSet.FirstOrDefault(item => item.UserID == entity.UserID);
        }
    }
}
