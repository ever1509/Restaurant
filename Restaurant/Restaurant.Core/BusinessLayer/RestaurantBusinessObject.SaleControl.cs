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

        public async Task<IEnumerable<EntityLayer.SaleControl>> GetSaleControls()
        {
            return await Task.Run(() => { return UnitOfWork.SaleControlRepository.GetAll(); });
        }

        public async Task<EntityLayer.SaleControl> GetSaleControl(EntityLayer.SaleControl entity)
        {
            return await Task.Run(() => { return UnitOfWork.SaleControlRepository.Get(entity); });
        }

        public async Task<EntityLayer.SaleControl> CreateSaleControl(EntityLayer.SaleControl entity)
        {
            UnitOfWork.SaleControlRepository.Add(entity);
            await UnitOfWork.CommitChangesAsync();
            return entity;
        }

        public async Task<EntityLayer.SaleControl> UpdateSaleControl(EntityLayer.SaleControl entity)
        {
            UnitOfWork.SaleControlRepository.Update(entity);
            await UnitOfWork.CommitChangesAsync();
            return entity;
        }

        public async Task<EntityLayer.SaleControl> DeleteSaleControl(EntityLayer.SaleControl entity)
        {
            UnitOfWork.SaleControlRepository.Remove(entity);
            await UnitOfWork.CommitChangesAsync();
            return entity;
        }

       
    }
}
