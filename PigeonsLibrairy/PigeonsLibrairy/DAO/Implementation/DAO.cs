using PigeonsLibrairy.DAO.Interface;
using PigeonsLibrairy.Exceptions;
using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace PigeonsLibrairy.DAO.Implementation
{
    public class DAO<TEntity> where TEntity : class
    {

        public DAO()
        {        
        }

        /// <summary>
        /// Retreive an Entity from the Database
        /// </summary>
        /// <param name="id">The ID of the Entity we are searching</param>
        /// <returns>The Entity or null</returns>
        public virtual TEntity GetByID(pigeonsEntities1 context, object id)
        {
            try
            {
                return context.Set<TEntity>().Find(id);
            }   
            catch(ArgumentException argumentException)
            {
                throw new DAOException(argumentException.Message);
            }              
        }

        /// <summary>
        /// Delete an Entity from the Database
        /// </summary>
        /// <param name="id">The ID of the Entity to delete</param>
        public virtual void Delete(pigeonsEntities1 context, object id)
        {
            TEntity entityToDelete = context.Set<TEntity>().Find(id);
            Delete(context, entityToDelete);
        }

        /// <summary>
        /// Delete an Entity from the Database
        /// </summary>
        /// <param name="entityToDelete">The Entity to delete</param>
        public virtual void Delete(pigeonsEntities1 context, TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                context.Set<TEntity>().Attach(entityToDelete);
            }
            context.Set<TEntity>().Remove(entityToDelete);
        }

        /// <summary>
        /// Insert an Entity in the Database
        /// </summary>
        /// <param name="entity">The Entity to insert</param>
        public virtual void Insert(pigeonsEntities1 context, TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
        }

        /// <summary>
        /// Update an Entity from the Database
        /// </summary>
        /// <param name="entityToUpdate">The Entity to update</param>
        public virtual void Update(pigeonsEntities1 context, TEntity entityToUpdate)
        {
            context.Set<TEntity>().Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public IEnumerable<TEntity> GetBy(pigeonsEntities1 context, string columnName, object value)
        {
            return new List<TEntity>();
        }

        /// <summary>
        /// Retreive an Entity from the Database by a query
        /// </summary>
        /// <param name="filter">The Query</param>
        /// <param name="orderBy">The column to use to order</param>
        /// <param name="includeProperties">If we want to add soma data to the returned Entity (Because LazyLoading is True)</param>
        /// <returns>A list matching the query or null</returns>
        public virtual IEnumerable<TEntity> Get(
            pigeonsEntities1 context,
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = context.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.AsNoTracking().ToList();
            }
        }

        public virtual List<TEntity> GetAll(pigeonsEntities1 context)
        {
            return context.Set<TEntity>().AsNoTracking().ToList();
        }
    }
}
