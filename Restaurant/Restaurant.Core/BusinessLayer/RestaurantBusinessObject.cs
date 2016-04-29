using Restaurant.Core.BusinessLayer.Contracts;
using Restaurant.Core.DataLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.BusinessLayer
{
    public partial class RestaurantBusinessObject : IRestaurantBusinessObject
    {
        IRestaurantUnitOfWork UnitOfWork;
        public RestaurantBusinessObject(IRestaurantUnitOfWork unitofwork)
        {
            UnitOfWork = unitofwork;
        }
        public void Release()
        {
            if (UnitOfWork != null)
            {
                UnitOfWork.Dispose();
            }
        }
    }
}
