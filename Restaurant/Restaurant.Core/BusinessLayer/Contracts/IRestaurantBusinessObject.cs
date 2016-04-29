using Restaurant.Core.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.BusinessLayer.Contracts
{
    public interface IRestaurantBusinessObject : IBusinessObject
    {
        Task<IEnumerable<Categories>> GetCategories();
        Task<Categories> GetCategory(Categories entity);
        Task<Categories> CreateCategory(Categories entity);
        Task<Categories> UpdateCategory(Categories entity);
        Task<Categories> DeleteCategory(Categories entity);

        Task<IEnumerable<FoodMenu>> GetFoodMenus();
        Task<FoodMenu> GetFoodMenu(FoodMenu entity);
        Task<FoodMenu> CreateFoodMenu(FoodMenu entity);
        Task<FoodMenu> UpdateFoodMenu(FoodMenu entity);
        Task<FoodMenu> DeleteFoodMenu(FoodMenu entity);

        Task<IEnumerable<Orders>> GetOrders();
        Task<Orders> GetOrder(Orders entity);
        Task<Orders> CreateOrder(Orders entity);
        Task<Orders> UpdateOrder(Orders entity);
        Task<Orders> DeleteOrder(Orders entity);

        Task<IEnumerable<SaleControl>> GetSaleControls();
        Task<SaleControl> GetSaleControl(SaleControl entity);
        Task<SaleControl> CreateSaleControl(SaleControl entity);
        Task<SaleControl> UpdateSaleControl(SaleControl entity);
        Task<SaleControl> DeleteSaleControl(SaleControl entity);

        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(User entity);
        Task<User> CreateUser(User entity);
        Task<User> UpdateUser(User entity);
        Task<User> DeleteUser(User entity);

        Task<IEnumerable<UserType>> GetUserTypes();
        Task<UserType> GetUserType(UserType entity);
        Task<UserType> CreateUserType(UserType entity);
        Task<UserType> UpdateUserType(UserType entity);
        Task<UserType> DeleteUserType(UserType entity);
    }
}
