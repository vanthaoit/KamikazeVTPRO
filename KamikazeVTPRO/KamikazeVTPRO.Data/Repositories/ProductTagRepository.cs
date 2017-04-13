using KamikazeVTPRO.Data.Infrastructure;
using KamikazeVTPRO.Model.Models;

namespace KamikazeVTPRO.Data.Repositories
{
    public interface IProductTagRepository : IRepository<ProductTag>
    {
    }

    public class ProductTagRepository : RepositoryBase<ProductTag>, IProductTagRepository
    {
        public ProductTagRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}