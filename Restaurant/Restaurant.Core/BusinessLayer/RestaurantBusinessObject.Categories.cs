using Restaurant.Core.BusinessLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.BusinessLayer
{
    public partial class RestaurantBusinessObject : IRestaurantBusinessObject
    {
        public async Task<IEnumerable<EntityLayer.Categories>> GetCategories()
        {
            return await Task.Run(() => { return UnitOfWork.CategoryRepository.GetAll(); });
        }

        public async Task<EntityLayer.Categories> GetCategory(EntityLayer.Categories entity)
        {
            return await Task.Run(() => { return UnitOfWork.CategoryRepository.Get(entity); });
        }

        public async Task<EntityLayer.Categories> CreateCategory(EntityLayer.Categories entity)
        {
            UnitOfWork.CategoryRepository.Add(entity);
            await UnitOfWork.CommitChangesAsync();
            return entity;
        }

        public async Task<EntityLayer.Categories> UpdateCategory(EntityLayer.Categories entity)
        {
            UnitOfWork.CategoryRepository.Update(entity);
            await UnitOfWork.CommitChangesAsync();
            return entity;
        }

        public async Task<EntityLayer.Categories> DeleteCategory(EntityLayer.Categories entity)
        {
            UnitOfWork.CategoryRepository.Remove(entity);
            await UnitOfWork.CommitChangesAsync();
            return entity;
        }


    }
}
