using KamikazeVTPRO.Data.Migrations;
using KamikazeVTPRO.Model.Models;

namespace KamikazeVTPRO.Data.Repositories
{
    public interface IProductCategoryRepository : IRepository<ProductCategory>
    {
    }

    public class ProductCategoryRepository : RepositoryBase<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(IDbFactory DbFactory) : base(DbFactory)
        {
        }
    }
}