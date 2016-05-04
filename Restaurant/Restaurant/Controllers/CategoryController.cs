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
    public class CategoryController : ApiController
    {
        protected IRestaurantBusinessObject BusinessObject;
        public CategoryController(IBusinessObjectService service)
        {
            BusinessObject = service.GetRestaurantBusinessObject();
        }
        protected override void Dispose(bool disposing)
        {
            if (BusinessObject != null)
            {
                BusinessObject.Release();
            }
            base.Dispose(disposing);
        }
        // GET: api/Category
        public async Task<HttpResponseMessage> Get()
        {
            var result = new CategoriesResponse();
            try
            {
                var task = await BusinessObject.GetCategories();
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

        // GET: api/Category/5
        public async Task<HttpResponseMessage> Get(int id)
        {
            var result = new SingleCategoryResponse();
            try
            {
                var task = await BusinessObject.GetCategory(new Categories(id));
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

        // POST: api/Category
        public async Task<HttpResponseMessage> Post([FromBody]Categories value)
        {
            var result = new SingleCategoryResponse();
            try
            {

                result.Model = await BusinessObject.CreateCategory(value);
                result.Message = "Category added successfully!";
            }
            catch (Exception ex)
            {

                result.DidError = true;
                result.ErrorMessage = ex.Message;
                result.Message = ex.ToString();
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // PUT: api/Category/5
        public async Task<HttpResponseMessage> Put(int id, [FromBody]Categories value)
        {
            var result = new SingleCategoryResponse();
            try
            {
                
                    result.Model = await BusinessObject.UpdateCategory(value);
                    result.Message = "Category updated successfully!";                
            }
            catch (Exception ex)
            {

                result.DidError = true;
                result.ErrorMessage = ex.Message;
                result.Message = ex.ToString();
            }
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // DELETE: api/Category/5
        public async Task<HttpResponseMessage> Delete(int id)
        {
            var result = new SingleCategoryResponse();
            try
            {
                var entity = await BusinessObject.GetCategory(new Categories(id));
                if (entity != null)
                {
                    result.Model = await BusinessObject.DeleteCategory(entity);
                    result.Message = "Category deleted successfully!";
                }
                else
                {
                    result.DidError = true;
                    result.ErrorMessage = String.Format("It doesn't exist the category with id {0}", id);
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
