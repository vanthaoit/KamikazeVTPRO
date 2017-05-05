using System.Collections.Generic;
using System.Linq;

namespace KamikazeVTPRO.Web.Infrastructure.Core
{
    public class PaginationSet<TEntity>
    {
        public int Page { set; get; }

        public int MaxPage { set; get; }

        public int TotalPage { set; get; }

        public int Count
        {
            get
            {
                return (Items != null) ? Items.Count() : 0;
            }
        }

        public int TotalCount { set; get; }

        public IEnumerable<TEntity> Items { set; get; }
    }
}