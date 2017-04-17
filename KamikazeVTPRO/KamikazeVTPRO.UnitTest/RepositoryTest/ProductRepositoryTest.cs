using Microsoft.VisualStudio.TestTools.UnitTesting;
using KamikazeVTPRO.Data.Infrastructure;
using KamikazeVTPRO.Data.Repositories;
using KamikazeVTPRO.Model.Models;
using System;
using System.Linq;

namespace KamikazeVTPRO.UnitTest.RepositoryTest
{
    [TestClass]
    public class ProductRepositoryTest
    {
        private IDbFactory dbFactory;
        private IUnitOfWork unitOfWork;
        private IProductRepository productRepository;

        [TestInitialize]
        public void Initialize()
        {
            dbFactory = new DbFactory();
            unitOfWork = new UnitOfWork(dbFactory);
            productRepository = new ProductRepository(dbFactory);

        }

        [TestMethod]
        public void Post_Repository_GetAll()
        {
            var list = productRepository.GetAll().ToList();
            Assert.AreEqual(2, list.Count);
        }

        [TestMethod]
        public void Product_Repository_Create()
        {
            Product product = new Product();
            product.Name = "Công trình C";
            product.Alias = "Cong-Trinh-C";
           
            product.CategoryID = 1;
     
            product.Status = true;
            product.CreatedDate = DateTime.Now;
            var result = productRepository.Add(product);
            unitOfWork.Commit();
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.ID);
        }
    }
}