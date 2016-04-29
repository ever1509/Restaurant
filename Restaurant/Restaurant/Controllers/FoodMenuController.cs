using Restaurant.Core.BusinessLayer.Contracts;
using Restaurant.Core.EntityLayer;
using Restaurant.Responses;
using Restaurant.Services;
using Restaurant.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Restaurant.Controllers
{
    public class FoodMenuController : ApiController
    {
        protected IRestaurantBusinessObject BusinessObject;
        public FoodMenuController(IBusinessObjectService service)
        {
            BusinessObject = service.GetRestaurantBusinessObject();
        }
        // GET: api/FoodMenu
        public async Task<HttpResponseMessage> Get()
        {
            var result = new FoodMenusResponse();
            try
            {
                var task = await BusinessObject.GetFoodMenus();
                result.Model = task.Select(item => new FoodMenuViewModel(item)).ToList();
            }
            catch (Exception ex)
            {
                result.DidError = true;
                result.ErrorMessage = ex.Message;
                result.Message = ex.ToString();
            }
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // GET: api/FoodMenu/5
        public async Task<HttpResponseMessage> Get(int id)
        {
            var result = new SingleFoodMenuResponse();
            try
            {
                var task = await BusinessObject.GetFoodMenu(new FoodMenu(id));
                result.Model = task;
            }
            catch (Exception ex)
            {

                result.DidError = true;
                result.ErrorMessage = ex.Message;
                result.Message = ex.ToString();
            }
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // POST: api/FoodMenu
        public async Task<HttpResponseMessage> Post([FromBody]FoodMenu value)
        {
            var result = new SingleFoodMenuResponse();
            try
            {
                var entity = await BusinessObject.GetFoodMenu(value);
                if (entity != null)
                {
                    var task = await BusinessObject.CreateFoodMenu(value);
                    result.Model = value;
                    result.Message = "Food Menu added successfully!";
                }
                else
                {
                    result.DidError = true;
                    result.ErrorMessage = String.Format("It doesn't exist a Food Menu");
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

        // PUT: api/FoodMenu/5
        public async Task<HttpResponseMessage> Put(int id, [FromBody]FoodMenu value)
        {
            var result = new SingleFoodMenuResponse();
            try
            {
                var entity = await BusinessObject.GetFoodMenu(new FoodMenu(id));
                if (entity != null)
                {
                    var task = await BusinessObject.UpdateFoodMenu(value);
                    result.Message = "Food Menu updated successfully!";
                }
                else
                {
                    result.DidError = true;
                    result.ErrorMessage = "It doesn't exist this Food Menu";
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

        // DELETE: api/FoodMenu/5
        public async Task<HttpResponseMessage> Delete(int id)
        {
            var result = new SingleFoodMenuResponse();
            try
            {
                var entity = await BusinessObject.GetFoodMenu(new FoodMenu(id));
                if (entity != null)
                {
                    var task = await BusinessObject.DeleteFoodMenu(entity);
                    result.Model = entity;
                    result.Message = "Food Menu deleted successfully!";
                }
                else
                {
                    result.DidError = true;
                    result.ErrorMessage = "It doesn't exist the Food Menu";
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
