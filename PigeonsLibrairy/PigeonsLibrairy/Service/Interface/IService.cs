using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PigeonsLibrairy.Service.Interface
{
    /// <summary>
    /// Interface pour la classe <see cref="Implementation.Service{TEntity}"/>
    /// </summary>
    /// <typeparam name="TEntity">Le type de l'Entity</typeparam>
    public interface IService<TEntity> where TEntity : class
    {        
        void Delete(object id);
        void Delete(TEntity entityToDelete);
        void Insert(TEntity entity);
        void Update(TEntity entityToUpdate);
        TEntity GetByID(object id);
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
        IEnumerable<TEntity> GetBy(string columnName, object value);
        IEnumerable<TEntity> GetAll();
    }
}
