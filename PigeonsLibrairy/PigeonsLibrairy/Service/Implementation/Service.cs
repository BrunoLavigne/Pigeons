using PigeonsLibrairy.DAO.Implementation;
using PigeonsLibrairy.Model;
using PigeonsLibrairy.Service.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PigeonsLibrairy.Service.Implementation
{
    public class Service<TEntity> where TEntity : class
    {
        internal pigeonsEntities1 context;
        internal DbSet<TEntity> dbSet;
        internal DAO<TEntity> dao;

        public Service(pigeonsEntities1 context)
        {
            if(context != null)
            {
                this.context = context;
                this.dbSet = context.Set<TEntity>();
                this.dao = new DAO<TEntity>(context);
            }
            else
            {
                throw new Exception("context is null");
            }            
        }

        public void Delete(TEntity entityToDelete)
        {
            if(entityToDelete != null)
            {
                try
                {
                    dao.Delete(entityToDelete);                    
                }
                catch
                {
                    throw new Exception("Fail to delete");
                }                
            }                  
        }

        public void Delete(object id)
        {
            TEntity entityToDelete = dao.GetByID(id);
            Delete(entityToDelete);
        }

        public IEnumerable<TEntity> Get(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            return dao.Get(filter, orderBy, includeProperties);
        }

        public TEntity GetByID(object id)
        {
            return dao.GetByID(id);
        }

        public IEnumerable<TEntity> GetBy(string columnName, object value)
        {
            return dao.GetBy(columnName, value);
        }

        public void Insert(TEntity entity)
        {
            dao.Insert(entity);
        }

        public void Update(TEntity entityToUpdate)
        {
            dao.Update(entityToUpdate);
        }
    }
}
