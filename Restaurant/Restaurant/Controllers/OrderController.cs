using Restaurant.Core.BusinessLayer.Contracts;
using Restaurant.Core.EntityLayer;
using Restaurant.Responses;
using Restaurant.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Restaurant.Controllers
{
    public class OrderController : ApiController
    {
        protected IRestaurantBusinessObject BusinessOBject;
        public OrderController(IBusinessObjectService service)
        {
            BusinessOBject = service.GetRestaurantBusinessObject();
        }
        // GET: api/Order
        public async Task<HttpResponseMessage> Get()
        {
            var result = new OrdersResponse();
            try
            {
                var task = await BusinessOBject.GetOrders();
                result.Model = task.ToList();

            }
            catch (Exception ex)
            {

                result.DidError = true;
                result.ErrorMessage = ex.Message;
                result.Message = ex.ToString();
            }
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // GET: api/Order/5
        public async Task<HttpResponseMessage> Get(int id)
        {
            var result = new SingleOrderResponse();
            try
            {
                var task = await BusinessOBject.GetOrder(new Orders(id));
                result.Model = task;
                if (result.Model == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            catch (Exception ex)
            {

                result.DidError = true;
                result.ErrorMessage = ex.Message;
                result.Message = ex.ToString();
            }
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // POST: api/Order
        public async Task<HttpResponseMessage> Post([FromBody]Orders value)
        {
            var result = new SingleOrderResponse();
            try
            {
                result.Model = await BusinessOBject.CreateOrder(value);
                result.Message = "Order added successfully!";
            }
            catch (Exception ex)
            {

                result.DidError = true;
                result.ErrorMessage = ex.Message;
                result.Message = ex.ToString();
            }
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // PUT: api/Order/5
        public async Task<HttpResponseMessage> Put(int id, [FromBody]Orders value)
        {
            var result = new SingleOrderResponse();
            try
            {
                var entity = await BusinessOBject.GetOrder(value);
                if (entity != null)
                {
                    result.Model = await BusinessOBject.UpdateOrder(value);
                    result.Message = "Order updated successfully!";
                }
                else
                {
                    result.DidError = true;
                    result.ErrorMessage = "It doesn't exist the Order";
                }
            }
            catch (Exception ex)
            {

                result.DidError = true;
                result.ErrorMessage = ex.Message;
                result.Message = ex.ToString();
            }
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // DELETE: api/Order/5
        public async Task<HttpResponseMessage> Delete(int id)
        {
            var result = new SingleOrderResponse();
            try
            {
                var entity = await BusinessOBject.GetOrder(new Orders(id));
                if (entity != null)
                {
                    result.Model = await BusinessOBject.DeleteOrder(entity);
                    result.Message = "Order deleted successfully!";
                }
                else
                {
                    result.DidError = true;
                    result.ErrorMessage = "It doesn't exist the order";
                }
            }
            catch (Exception ex)
            {

                result.DidError = true;
                result.ErrorMessage = ex.Message;
                result.Message = ex.ToString();
            }
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
