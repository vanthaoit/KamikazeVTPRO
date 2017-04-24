using System.Collections.Generic;

namespace KamikazeVTPRO.Service.Infrastructure.Core
{
    public interface IGenericService<TEntity> where TEntity : class
    {
        TEntity Add(TEntity entity);

        void Update(TEntity entity);

        TEntity Delete(int id);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> GetAll(string keyword);

        IEnumerable<TEntity> Search(string keyword, int page, int pageSize, string sort, out int totalRow);

        TEntity GetById(int id);
    }
}
