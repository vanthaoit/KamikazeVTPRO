using System.Collections.Generic;
using System.Linq;
using KamikazeVTPRO.Data.Extensions;
using KamikazeVTPRO.Data.Infrastructure;
using KamikazeVTPRO.Data.Repositories;
using KamikazeVTPRO.Model.Models;
using KamikazeVTPRO.Service.Infrastructure.Core;

namespace KamikazeVTPRO.Service.Collections
{
    public interface IProductCategoryService : IGenericService<ProductCategory>, IValidationService, IBreadcrumb<ProductCategory>
    {

    }

    public class ProductCategoryService : ValidationService, IProductCategoryService
    {
        private IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._productCategoryRepository = productCategoryRepository;
        }

        public ProductCategory Add(ProductCategory entity)
        {
            return _productCategoryRepository.Add(entity);
        }

        public ProductCategory Delete(int id)
        {
            return _productCategoryRepository.Delete(id);
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            return _productCategoryRepository.GetAll();
        }

        public IEnumerable<ProductCategory> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _productCategoryRepository.GetMulti(x => (x.Name.Contains(keyword) || x.Description.Contains(keyword)) && x.Status).OrderByDescending(y => y.CreatedDate);
            else
                return _productCategoryRepository.GetAll();
        }

        public ProductCategory GetById(int id)
        {
            return _productCategoryRepository.GetSingleById(id);
        }

        public IEnumerable<ProductCategory> GetTeamTree(int Id)
        {
            return _productCategoryRepository.GetTeamTree(Id);
        }

        public IEnumerable<ProductCategory> Search(string keyword, int page, int pageSize, string sort, out int totalRow)
        {
            var query = _productCategoryRepository.GetMulti(x => x.Name.Contains(keyword) || x.Description.Contains(keyword)).OrderByDescending(y => y.CreatedDate);

            totalRow = query.Count();

            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public void Update(ProductCategory entity)
        {
            _productCategoryRepository.Update(entity);
        }
    }
}