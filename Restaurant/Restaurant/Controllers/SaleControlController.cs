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
    public class SaleControlController : ApiController
    {
        protected IRestaurantBusinessObject BusinessObject;
        public SaleControlController(IBusinessObjectService service)
        {
            BusinessObject = service.GetRestaurantBusinessObject();
        }
        // GET: api/SaleControl
        public async Task<HttpResponseMessage> Get()
        {
            var result = new SaleControlResponse();
            try
            {
                var task = await BusinessObject.GetSaleControls();
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

        // GET: api/SaleControl/5
        public async Task<HttpResponseMessage> Get(int id)
        {
            var result = new SingleSaleControlResponse();
            try
            {
                var task = await BusinessObject.GetSaleControl(new SaleControl(id));
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

        // POST: api/SaleControl
        public async Task<HttpResponseMessage> Post([FromBody]SaleControl value)
        {
            var result = new SingleSaleControlResponse();
            try
            {
                result.Model = await BusinessObject.CreateSaleControl(value);
                result.Message = "Sale Control added successfully!";
            }
            catch (Exception ex)
            {

                result.DidError = true;
                result.ErrorMessage = ex.Message;
                result.Message = ex.ToString();
            }
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // PUT: api/SaleControl/5
        public async Task<HttpResponseMessage> Put(int id, [FromBody]SaleControl value)
        {
            var result = new SingleSaleControlResponse();
            try
            {
                var entity = await BusinessObject.GetSaleControl(new SaleControl(id));
                if (entity != null)
                {
                    result.Model = await BusinessObject.UpdateSaleControl(value);
                    result.Message = "Sale Control updated successfully!";
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

        // DELETE: api/SaleControl/5
        public async Task<HttpResponseMessage> Delete(int id)
        {
            var result = new SingleSaleControlResponse();
            try
            {
                var entity = await BusinessObject.GetSaleControl(new SaleControl(id));
                if (entity != null)
                {
                    result.Model = await BusinessObject.DeleteSaleControl(entity);
                    result.Message = "SaleControl deleted successfully!";
                }
                else
                {
                    result.DidError = true;
                    result.ErrorMessage = "It doesn't exist the Sale Control";
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
