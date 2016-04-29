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

        public async Task<IEnumerable<EntityLayer.UserType>> GetUserTypes()
        {
            return await Task.Run(() => { return UnitOfWork.UserTypeRepository.GetAll(); });
        }

        public async Task<EntityLayer.UserType> GetUserType(EntityLayer.UserType entity)
        {
            return await Task.Run(() => { return UnitOfWork.UserTypeRepository.Get(entity); });
        }

        public async Task<EntityLayer.UserType> CreateUserType(EntityLayer.UserType entity)
        {
            UnitOfWork.UserTypeRepository.Add(entity);
            await UnitOfWork.CommitChangesAsync();
            return entity;
        }

        public async Task<EntityLayer.UserType> UpdateUserType(EntityLayer.UserType entity)
        {
            UnitOfWork.UserTypeRepository.Update(entity);
            await UnitOfWork.CommitChangesAsync();
            return entity;
        }

        public async Task<EntityLayer.UserType> DeleteUserType(EntityLayer.UserType entity)
        {
            UnitOfWork.UserTypeRepository.Remove(entity);
            await UnitOfWork.CommitChangesAsync();
            return entity;
        }
    }
}
