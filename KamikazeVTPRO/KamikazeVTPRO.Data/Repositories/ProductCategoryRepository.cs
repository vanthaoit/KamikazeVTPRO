using System.Collections.Generic;
using System.Linq;
using KamikazeVTPRO.Data.Extensions;
using KamikazeVTPRO.Data.Infrastructure;
using KamikazeVTPRO.Model.Models;

namespace KamikazeVTPRO.Data.Repositories
{
    public interface IProductCategoryRepository : IRepository<ProductCategory>, IBreadcrumb<ProductCategory>
    {
    }

    public class ProductCategoryRepository : RepositoryBase<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<ProductCategory> GetTeamTree(int productCategoryId)
        {
            var query = from pc in DbContext.ProductCategories select pc;

            IEnumerable<ProductCategory> familyTree = query.AsQueryable();

            var response = GetBreadcrumbs(familyTree, productCategoryId);

            return response;
        }

        private IEnumerable<ProductCategory> GetBreadcrumbs(IEnumerable<ProductCategory> entities, int productCategoryId)
        {
            var parents = entities.Where(x => x.ID != productCategoryId);

            var current = entities.Where(x => x.ID == productCategoryId);

            foreach (var breadcrumb in current)
            {
                if (breadcrumb.ParentID.HasValue)
                {
                    foreach (var trail in GetBreadcrumbs(parents, breadcrumb.ParentID.Value))

                        yield return trail;
                }
                yield return breadcrumb;
            }
        }
    }
}