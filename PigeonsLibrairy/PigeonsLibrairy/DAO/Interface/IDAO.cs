using PigeonsLibrairy.Model;
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
        void Delete(pigeonsEntities1 context, object id);
        void Delete(pigeonsEntities1 context, TEntity entityToDelete);
        void Insert(pigeonsEntities1 context, TEntity entity);
        void Update(pigeonsEntities1 context, TEntity entityToUpdate);
        TEntity GetByID(pigeonsEntities1 context, object id);        
        IEnumerable<TEntity> GetAll(pigeonsEntities1 context);
        IEnumerable<TEntity> GetBy(pigeonsEntities1 context, string columnName, object value);
        IEnumerable<TEntity> Get(pigeonsEntities1 context, Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");        
    }
}
