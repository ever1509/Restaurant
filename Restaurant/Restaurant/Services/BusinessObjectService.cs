using Restaurant.Core.BusinessLayer;
using Restaurant.Core.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.Services
{
    public class BusinessObjectService : IBusinessObjectService
    {
        public Core.BusinessLayer.Contracts.IRestaurantBusinessObject GetRestaurantBusinessObject()
        {
            return new RestaurantBusinessObject(new RestaurantUnitOfWork(new RestaurantDbContext()));
        }
    }
}