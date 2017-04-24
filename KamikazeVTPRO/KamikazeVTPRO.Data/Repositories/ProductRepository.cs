using System.Collections.Generic;
using System.Linq;
using KamikazeVTPRO.Data.Infrastructure;
using KamikazeVTPRO.Model.Models;

namespace KamikazeVTPRO.Data.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetListProductByTag(string tagId, int index, int pageSize, out int totalRow);
    }

    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Product> GetListProductByTag(string tagId, int index, int pageSize, out int totalRow)
        {
            var query = from p in DbContext.Products
                        join pt in DbContext.ProductTags
                        on p.ID equals pt.ProductID
                        where pt.TagID.Contains(p.Tags)
                        select p;

            totalRow = query.Count();

            var response = query.OrderByDescending(x => x.CreatedDate).Skip((index - 1) * pageSize).Take(pageSize);

            return response;
        }
    }
}