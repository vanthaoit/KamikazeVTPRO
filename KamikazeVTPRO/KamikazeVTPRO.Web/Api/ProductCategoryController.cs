using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KamikazeVTPRO.Service.Collections;
using KamikazeVTPRO.Web.Infrastructure.Core;
using KamikazeVTPRO.Web.Models;

namespace KamikazeVTPRO.Web.Api
{
    [RoutePrefix("api/productcateogry")]
    public class ProductCategoryController : ApiControllerBase
    {
        private IProductCategoryService _productCategoryService;

        public ProductCategoryController(IErrorService errorService, IProductCategoryService productCategoryService) : base(errorService)
        {
            this._productCategoryService = productCategoryService;
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            HttpResponseMessage response = null;
            return CreateHttpResponse(request, () =>
            {
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var responseProductCategory = _productCategoryService.GetAll();
                    var responseProductCategoryViewModel = AutoMapper.Mapper.Map<IEnumerable<ProductCategoryViewModel>>(responseProductCategory);
                    response = request.CreateResponse(HttpStatusCode.OK, responseProductCategoryViewModel);
                }

                return response;
            });
        }
        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request,int id)
        {
            return CreateHttpResponse(request,()=> {

                HttpResponseMessage response = null;

                var responseProductCategory = _productCategoryService.GetById(id);

                var responseProductCategoryViewModel = AutoMapper.Mapper.Map<ProductCategoryViewModel>(responseProductCategory);

                response = request.CreateResponse(HttpStatusCode.OK,responseProductCategoryViewModel);

                return response;

            });
        }
    }
}