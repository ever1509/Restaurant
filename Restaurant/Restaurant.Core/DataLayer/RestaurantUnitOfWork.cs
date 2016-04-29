using Restaurant.Core.DataLayer.Contracts;
using Restaurant.Core.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.DataLayer
{
    public class RestaurantUnitOfWork : UnitOfWork, IRestaurantUnitOfWork
    {
        protected ICategoryRepository categoryRepository;
        protected IFoodMenuRepository foodmenuRepository;
        protected IOrderRepository orderRepository;
        protected ISaleControlRepository salecontrolRepository;
        protected IUserRepository userRepository;
        protected IUserTypeRepository usertypeRepository;
        public RestaurantUnitOfWork(DbContext dbContext)
            : base(dbContext)
        {

        }
        public ICategoryRepository CategoryRepository
        {
            get { return categoryRepository ?? (categoryRepository = new CategoryRepository(DbContext)); }
        }
        public IFoodMenuRepository FoodMenuRepository
        {
            get { return foodmenuRepository ?? (foodmenuRepository = new FoodMenuRepository(DbContext)); }
        }

        public IOrderRepository OrderRepository
        {
            get { return orderRepository ?? (orderRepository = new OrderRepository(DbContext)); }
        }

        public ISaleControlRepository SaleControlRepository
        {
            get { return salecontrolRepository ?? (salecontrolRepository = new SaleControlRepository(DbContext)); }
        }

        public IUserRepository UserRepository
        {
            get { return userRepository ?? (userRepository = new UserRepository(DbContext)); }
        }

        public IUserTypeRepository UserTypeRepository
        {
            get { return usertypeRepository ?? (usertypeRepository = new UserTypeRepository(DbContext)); }
        }
    }
}
