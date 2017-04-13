using KamikazeVTPRO.Data.Migrations;
using KamikazeVTPRO.Model.Models;

namespace KamikazeVTPRO.Data.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
    }

    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IDbFactory DbFactory) : base(DbFactory)
        {
        }
    }
}