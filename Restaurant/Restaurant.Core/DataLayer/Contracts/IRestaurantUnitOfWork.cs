using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.DataLayer.Contracts
{
   public  interface IRestaurantUnitOfWork:IUnitOfWork
    {
       ICategoryRepository CategoryRepository { get; }
       IFoodMenuRepository FoodMenuRepository { get; }
       IOrderRepository OrderRepository { get; }
       ISaleControlRepository SaleControlRepository { get; }
       IUserRepository UserRepository { get; }
       IUserTypeRepository UserTypeRepository { get; }
    }
}
