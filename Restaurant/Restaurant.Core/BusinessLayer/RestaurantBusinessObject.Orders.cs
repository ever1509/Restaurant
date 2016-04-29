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

        public async Task<IEnumerable<EntityLayer.Orders>> GetOrders()
        {
            return await Task.Run(() => { return UnitOfWork.OrderRepository.GetAll(); });
        }

        public async Task<EntityLayer.Orders> GetOrder(EntityLayer.Orders entity)
        {
            return await Task.Run(() => { return UnitOfWork.OrderRepository.Get(entity); });
        }

        public async Task<EntityLayer.Orders> CreateOrder(EntityLayer.Orders entity)
        {
            UnitOfWork.OrderRepository.Add(entity);
            await UnitOfWork.CommitChangesAsync();
            return entity;
        }

        public async Task<EntityLayer.Orders> UpdateOrder(EntityLayer.Orders entity)
        {
            UnitOfWork.OrderRepository.Update(entity);
            await UnitOfWork.CommitChangesAsync();
            return entity;
        }

        public async Task<EntityLayer.Orders> DeleteOrder(EntityLayer.Orders entity)
        {
            UnitOfWork.OrderRepository.Remove(entity);
            await UnitOfWork.CommitChangesAsync();
            return entity;
        }

      
    }
}
