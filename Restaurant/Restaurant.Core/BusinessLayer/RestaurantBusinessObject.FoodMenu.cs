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

        public async Task<IEnumerable<EntityLayer.FoodMenu>> GetFoodMenus()
        {
            return await Task.Run(() => { return UnitOfWork.FoodMenuRepository.GetAll(); });
        }

        public async Task<EntityLayer.FoodMenu> GetFoodMenu(EntityLayer.FoodMenu entity)
        {
            return await Task.Run(() => { return UnitOfWork.FoodMenuRepository.Get(entity); });
        }

        public async Task<EntityLayer.FoodMenu> CreateFoodMenu(EntityLayer.FoodMenu entity)
        {
            UnitOfWork.FoodMenuRepository.Add(entity);
            await UnitOfWork.CommitChangesAsync();
            return entity;
        }

        public async Task<EntityLayer.FoodMenu> UpdateFoodMenu(EntityLayer.FoodMenu entity)
        {
            UnitOfWork.FoodMenuRepository.Update(entity);
            await UnitOfWork.CommitChangesAsync();
            return entity;
        }

        public async Task<EntityLayer.FoodMenu> DeleteFoodMenu(EntityLayer.FoodMenu entity)
        {
            UnitOfWork.FoodMenuRepository.Remove(entity);
            await UnitOfWork.CommitChangesAsync();
            return entity;
        }

       
    }
}
