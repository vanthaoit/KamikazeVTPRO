using System.Collections.Generic;

namespace KamikazeVTPRO.Data.Extensions
{
    public interface IBreadcrumb<TEntity>
    {
        IEnumerable<TEntity> GetTeamTree(int parentId);
    }
}