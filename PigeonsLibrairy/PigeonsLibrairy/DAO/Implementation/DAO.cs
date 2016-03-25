using PigeonsLibrairy.DAO.Interface;
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
        public pigeonsEntities1 context { get; private set; }
        public DbSet<TEntity> dbSet { get; private set; }

        public DAO(pigeonsEntities1 context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();            
        }

        /// <summary>
        /// Retreive an Entity from the Database
        /// </summary>
        /// <param name="id">The ID of the Entity we are searching</param>
        /// <returns>The Entity or null</returns>
        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);            
        }

        /// <summary>
        /// Delete an Entity from the Database
        /// </summary>
        /// <param name="id">The ID of the Entity to delete</param>
        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        /// <summary>
        /// Delete an Entity from the Database
        /// </summary>
        /// <param name="entityToDelete">The Entity to delete</param>
        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        /// <summary>
        /// Insert an Entity in the Database
        /// </summary>
        /// <param name="entity">The Entity to insert</param>
        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        /// <summary>
        /// Update an Entity from the Database
        /// </summary>
        /// <param name="entityToUpdate">The Entity to update</param>
        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public IEnumerable<TEntity> GetBy(string columnName, object value)
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
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

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
                return query.ToList();
            }
        }
    }
}
