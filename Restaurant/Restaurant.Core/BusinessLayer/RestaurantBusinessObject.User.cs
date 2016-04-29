using Restaurant.Core.BusinessLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.BusinessLayer
{
    public partial class RestaurantBusinessObject:IRestaurantBusinessObject
    {

        public async Task<IEnumerable<EntityLayer.User>> GetUsers()
        {
            return await Task.Run(() => { return UnitOfWork.UserRepository.GetAll(); });
        }

        public async Task<EntityLayer.User> GetUser(EntityLayer.User entity)
        {
            return await Task.Run(() => { return UnitOfWork.UserRepository.Get(entity); });
        }

        public async Task<EntityLayer.User> CreateUser(EntityLayer.User entity)
        {
            UnitOfWork.UserRepository.Add(entity);
            await UnitOfWork.CommitChangesAsync();
            return entity;
        }

        public async Task<EntityLayer.User> UpdateUser(EntityLayer.User entity)
        {
            UnitOfWork.UserRepository.Update(entity);
            await UnitOfWork.CommitChangesAsync();
            return entity;
        }

        public async Task<EntityLayer.User> DeleteUser(EntityLayer.User entity)
        {
            UnitOfWork.UserRepository.Remove(entity);
            await UnitOfWork.CommitChangesAsync();
            return entity;
        }

     
    }
}
