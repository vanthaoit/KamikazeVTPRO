using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using KamikazeVTPRO.Model.Models;
using KamikazeVTPRO.Service;
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
            //    ID = 1,

            //    Name = "son nuoc",

            //    Alias = "son-nuoc",

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

                    var responseData = Mapper.Map<Product, ProductViewModel>(newProduct);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }
    }
}