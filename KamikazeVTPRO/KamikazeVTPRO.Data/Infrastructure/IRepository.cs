using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace KamikazeVTPRO.Data.Migrations
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Add(TEntity entity);

        void Update(TEntity entity);

        TEntity Delete(TEntity entity);

        TEntity Delete(int id);

        void DeleteMulti(Expression<Func<TEntity, bool>> where);

        TEntity GetSingleById(int id);

        TEntity GetSingleByCondition(Expression<Func<TEntity, bool>> expression, string[] includes = null);

        IEnumerable<TEntity> GetAll(string[] includes = null);

        IEnumerable<TEntity> GetMulti(Expression<Func<TEntity, bool>> predicate, string[] includes = null);

        IEnumerable<TEntity> GetMultiPaging(Expression<Func<TEntity, bool>> filter, out int total, int index = 0, int size = 50, string[] includes = null);

        int Count(Expression<Func<TEntity, bool>> where);

        bool CheckContains(Expression<Func<TEntity, bool>> predicate);
    }
}