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
    public class UserTypeController : ApiController
    {
        protected IRestaurantBusinessObject BusinessObject;
        public UserTypeController(IBusinessObjectService service)
        {
            BusinessObject = service.GetRestaurantBusinessObject();
        }
        // GET: api/UserType
        public async Task<HttpResponseMessage> Get()
        {
            var result = new UserTypesResponse();
            try
            {
                var task = await BusinessObject.GetUserTypes();
                result.Model = task.ToList();
            }
            catch (Exception ex)
            {

                result.DidError = true;
                result.ErrorMessage = ex.Message;
            }
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // GET: api/UserType/5
        public async Task<HttpResponseMessage> Get(int id)
        {
            var result = new SingleUserTypeResponse();
            try
            {
                var task = await BusinessObject.GetUserType(new UserType(id));
                result.Model = task;
            }
            catch (Exception ex)
            {

                result.DidError = true;
                result.ErrorMessage = ex.Message;
            }
            return Request.CreateResponse(HttpStatusCode.OK, result);

        }

        // POST: api/UserType
        public async Task<HttpResponseMessage> Post([FromBody]UserType value)
        {
            var result = new SingleUserTypeResponse();
            try
            {
                result.Model = await BusinessObject.CreateUserType(value);
                result.Message = "User Type added successfully!";
            }
            catch (Exception ex)
            {

                result.DidError = true;
                result.ErrorMessage = ex.Message;
            }
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // PUT: api/UserType/5
        public async Task<HttpResponseMessage> Put(int id, [FromBody]UserType value)
        {
            var result = new SingleUserTypeResponse();
            try
            {
                result.Model = await BusinessObject.UpdateUserType(value);
                result.Message = "User Type updated successfully!";
            }
            catch (Exception ex)
            {

                result.DidError = true;
                result.ErrorMessage = ex.Message;
            }
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // DELETE: api/UserType/5
        public async Task<HttpResponseMessage> Delete(int id)
        {
            var result = new SingleUserTypeResponse();
            try
            {
                var entity = await BusinessObject.GetUserType(new UserType(id));
                if (entity != null)
                {
                    result.Model = await BusinessObject.DeleteUserType(entity);
                    result.Message = "User Type deleted successfully!";
                }
                else
                {
                    result.DidError = true;
                    result.ErrorMessage = "It doesn't exist a User Type with id : " + id;
                }
            }
            catch (Exception ex)
            {

                result.DidError = true;
                result.ErrorMessage = ex.Message;
            }
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
