using KamikazeVTPRO.Data.Infrastructure;
using KamikazeVTPRO.Data.Repositories;
using KamikazeVTPRO.Model.Models;
using KamikazeVTPRO.Service.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace KamikazeVTPRO.UnitTest.ServiceTest
{
    [TestClass]
    public class ProductServiceTest
    {
        private Mock<IProductRepository> _mockProduct;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private IProductService _productService;
        private Mock<IProductTagRepository> _mockProductTagService;
        private Mock<ITagRepository> _mockTagService;
        private Product _product;

        [TestInitialize]
        public void Initialize()
        {
            _mockProduct = new Mock<IProductRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockProductTagService = new Mock<IProductTagRepository>();
            _mockTagService = new Mock<ITagRepository>();
            _productService = new ProductService(_mockProduct.Object, _mockProductTagService.Object, _mockTagService.Object, _mockUnitOfWork.Object);
            _product = new Product()
            {
                ID = 1,
                Name = "son nuoc",
                Alias = "son-nuoc",
                CategoryID = 1,
                Status = true
            };
        }

        [TestMethod]
        public void Product_Service_Create()
        {
            _mockProduct
                .Setup(x => x.Add(_product))
                .Returns((Product p) =>
                {
                    p.MetaKeyword = "create product";
                    return p;
                });
            var result = _productService.Add(_product);
            _productService.Save();
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.ID);
        }
    }
}