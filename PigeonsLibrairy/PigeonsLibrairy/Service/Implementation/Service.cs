using PigeonsLibrairy.DAO.Implementation;
using PigeonsLibrairy.Model;
using PigeonsLibrairy.Service.Implementation;
using PigeonsLibrairy.Service.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PigeonsLibrairy.Service.Implementation
{
    public class Service<TEntity> where TEntity : class
    {
        internal DAO<TEntity> dao;

        public Service()
        {
            this.dao = new DAO<TEntity>();
        }

        public void Delete(TEntity entityToDelete)
        {
            if(entityToDelete != null)
            {
                try                   
                {   
                    using(var context = new pigeonsEntities1())
                    {
                        dao.Delete(context, entityToDelete);
                    }                                                         
                }
                catch
                {
                    throw new Exception("Fail to delete");
                }                
            }                  
        }

        public void Delete(object id)
        {
            using(var context = new pigeonsEntities1())
            {
                TEntity entityToDelete = dao.GetByID(context, id);
                Delete(entityToDelete);
            }                
        }

        public IEnumerable<TEntity> Get(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            using (var context = new pigeonsEntities1())
            {
                return dao.Get(context, filter, orderBy, includeProperties);
            }
                
        }

        public TEntity GetByID(object id)
        {
            using (var context = new pigeonsEntities1())
            {
                return dao.GetByID(context, id);
            }            
        }

        public IEnumerable<TEntity> GetBy(string columnName, object value)
        {
            using (var context = new pigeonsEntities1())
            {
                return dao.GetBy(context, columnName, value);
            }
            
        }

        public void Insert(TEntity entity)
        { 
            using (var context = new pigeonsEntities1())
            {
                dao.Insert(context, entity);
            }                      
        }

        public void Update(TEntity entityToUpdate)
        {
            using (var context = new pigeonsEntities1())
            {
                dao.Update(context, entityToUpdate);
            }            
        }

        public List<TEntity> GetAll()
        {
            using (var context = new pigeonsEntities1())
            {
                return dao.GetAll(context);
            }            
        }
    }
}
