using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PigeonsLibrairy.DAO.Interface
{
    public interface IDAO<TEntity> where TEntity : class
    {
        TEntity GetByID(object id);
        void Delete(object id);
        void Delete(TEntity entityToDelete);
        void Insert(TEntity entity);
        void Update(TEntity entityToUpdate);
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
        IEnumerable<TEntity> GetBy(string columnName, object value);
        List<TEntity> GetAll();
    }
}
