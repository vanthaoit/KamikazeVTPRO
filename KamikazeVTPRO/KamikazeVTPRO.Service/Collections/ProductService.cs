using System;
using System.Collections.Generic;
using System.Linq;
using KamikazeVTPRO.Data.Infrastructure;
using KamikazeVTPRO.Data.Repositories;
using KamikazeVTPRO.Model.Models;
using KamikazeVTPRO.Service.Infrastructure.Core;

namespace KamikazeVTPRO.Service.Collections
{
    public interface IProductService : IGenericService<Product>, IValidationService
    {
        IEnumerable<Product> GetLastest(int top);

        IEnumerable<Product> GetHotProduct(int top);

        IEnumerable<Product> GetListProductByCategoryIdPaging(int categoryId, int page, int pageSize, string sort, out int totalRow);

        IEnumerable<Product> GetReatedProducts(int id, int top);

        IEnumerable<string> GetListProductByName(string name);

        IEnumerable<Tag> GetListTagByProductId(int id);

        Tag GetTag(string tagId);

        void IncreaseView(int id);

        IEnumerable<Product> GetListProductByTag(string tagId, int page, int pagesize, out int totalRow);
    }

    public class ProductService : ValidationService, IProductService
    {
        private IProductRepository _productRepository;
        private IProductTagRepository _productTagRepository;
        private ITagRepository _tagRepository;

        public ProductService(IProductRepository productRepository, IProductTagRepository productTagRepository, ITagRepository tagRepository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._productRepository = productRepository;
            this._productTagRepository = productTagRepository;
            this._tagRepository = tagRepository;
        }

        public Product Add(Product product)
        {
            var item = _productRepository.Add(product);
            _unitOfWork.Commit();

            return item;
        }

        public Product Delete(int id)
        {
            return _productRepository.Delete(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public IEnumerable<Product> GetAll(string keyword)
        {
            return _productRepository.GetMulti(x => x.Status && (x.Name.Contains(keyword) || x.Content.Contains(keyword))).OrderByDescending(x => x.Name);
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetHotProduct(int top)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetLastest(int top)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetListProductByCategoryIdPaging(int categoryId, int page, int pageSize, string sort, out int totalRow)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetListProductByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetListProductByTag(string tagId, int page, int pagesize, out int totalRow)
        {
            return _productRepository.GetListProductByTag(tagId, page, pagesize, out totalRow);
        }

        public IEnumerable<Tag> GetListTagByProductId(int id)
        {
            return _productTagRepository.GetMulti(x => x.ProductID.Equals(id), new string[] { "Tag" }).Select(y => y.Tag);
        }

        public IEnumerable<Product> GetReatedProducts(int id, int top)
        {
            var productModel = _productRepository.GetSingleById(id);
            return _productRepository.GetMulti(x => x.ID != id && x.Status && x.CategoryID == productModel.CategoryID).OrderByDescending(y => y.CreatedDate).Take(top);
        }

        public Tag GetTag(string tagId)
        {
            return _tagRepository.GetSingleByCondition(x => x.ID == tagId);
        }

        public void IncreaseView(int id)
        {
            var productModel = _productRepository.GetSingleById(id);
            if (productModel.ViewCount.HasValue)
                productModel.ViewCount += 1;
            else
                productModel.ViewCount = 1;
        }

        public IEnumerable<Product> Search(string keyword, int page, int pageSize, string sort, out int totalRow)
        {
            IEnumerable<Product> query = new List<Product>();

            if (!string.IsNullOrEmpty(keyword))
                query = _productRepository.GetMulti(x => (x.Name.Contains(keyword) || x.Content.Contains(keyword)) && x.Status);
            else
                query = _productRepository.GetMulti(x => x.Status);
            switch (sort)
            {
                case "createdDate":
                    query = query.OrderByDescending(x => x.CreatedDate);
                    break;

                default:
                    query = query.OrderByDescending(x => x.Name);
                    break;
            }
            totalRow = query.Count();

            return query;
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}