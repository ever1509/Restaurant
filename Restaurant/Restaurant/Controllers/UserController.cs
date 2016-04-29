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
    public class UserController : ApiController
    {
        protected IRestaurantBusinessObject BusinessObject;
          public UserController(IBusinessObjectService service)
        {
            BusinessObject = service.GetRestaurantBusinessObject();
        }
        // GET: api/User
          public async Task<HttpResponseMessage> Get()
          {
              var result = new UsersResponse();
              try
              {
                  var task = await BusinessObject.GetUsers();
                  result.Model = task.ToList();
              }
              catch (Exception ex)
              {

                  result.DidError = true;
                  result.ErrorMessage = ex.Message;
              }
              return Request.CreateResponse(HttpStatusCode.OK, result);
          }

        // GET: api/User/5
          public async Task<HttpResponseMessage> Get(int id)
          {
              var result = new SingleUserResponse();
              try
              {
                  var task = await BusinessObject.GetUser(new User(id));
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
              }
              return Request.CreateResponse(HttpStatusCode.OK, result);
          }

        // POST: api/User
          public async Task<HttpResponseMessage> Post([FromBody]User value)
          {
              var result = new SingleUserResponse();
              try
              {
                  result.Model = await BusinessObject.CreateUser(value);
                  result.Message = "User added successfully!";
              }
              catch (Exception ex)
              {

                  result.DidError = true;
                  result.ErrorMessage = ex.Message;
              }
              return Request.CreateResponse(HttpStatusCode.OK, result);
          }

        // PUT: api/User/5
          public async Task<HttpResponseMessage> Put(int id, [FromBody]User value)
          {
              var result = new SingleUserResponse();
              try
              {
                  result.Model = await BusinessObject.UpdateUser(value);
                  result.Message = "User updated successfully!";
              }
              catch (Exception ex)
              {

                  result.DidError = true;
                  result.ErrorMessage = ex.Message;
              }
              return Request.CreateResponse(HttpStatusCode.OK, result);
          }

        // DELETE: api/User/5
          public async Task<HttpResponseMessage> Delete(int id)
          {
              var result = new SingleUserResponse();
              try
              {
                  var entity = await BusinessObject.GetUser(new User(id));
                  if (entity != null)
                  {
                      result.Model = await BusinessObject.DeleteUser(entity);
                      result.Message = "User deleted successfully!";
                  }
                  else
                  {
                      result.DidError = true;
                      result.ErrorMessage = "It doesn't exist the User with id " + id;
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
