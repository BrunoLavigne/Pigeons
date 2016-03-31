using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PigeonsLibrairy.Service.Interface
{
    public interface IService<TEntity> where TEntity : class
    {
        TEntity GetByID(object id);
        void Delete(object id);
        void Delete(TEntity entityToDelete);
        void Insert(TEntity entity);
        void Update(TEntity entityToUpdate);
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
        IEnumerable<TEntity> GetBy(string columnName, object value);
        IEnumerable<TEntity> GetAll();
    }
}
