using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using KamikazeVTPRO.Model.Models;
using KamikazeVTPRO.Service.Collections;
using KamikazeVTPRO.Web.Infrastructure.Core;
using KamikazeVTPRO.Web.Infrastructure.Extensions;
using KamikazeVTPRO.Web.Models;

namespace KamikazeVTPRO.Web.Api
{
    [RoutePrefix("api/product")]
    public class ProductController : ApiControllerBase
    {
        #region Initialize

        private IProductService _productService;

        public ProductController(IErrorService errorService, IProductService productService) : base(errorService)
        {
            this._productService = productService;
        }

        #endregion Initialize

        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, ProductViewModel productVm)
        {
            //ProductViewModel productVm = new ProductViewModel()
            //{
            //    Name = "son nuoc clg",

            //    Alias = "son-nuoc clg",

            //    CategoryID = 1,

            //    Status = true
            //};
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    Product newProduct = new Product();
                    newProduct.UpdateProduct(productVm);
                    newProduct.CreatedDate = DateTime.Now;
                    newProduct.CreatedBy = User.Identity.Name;
                    _productService.Add(newProduct);
                    _productService.Save();

                    var responseData = Mapper.Map<ProductViewModel>(newProduct);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }

        [Route("getall")]
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
                     var listProduct = _productService.GetAll();

                     var listProductVm = Mapper.Map<IEnumerable<ProductViewModel>>(listProduct);

                     response = request.CreateResponse(HttpStatusCode.OK, listProductVm);
                 }
                 return response;
             });
        }
    }
}