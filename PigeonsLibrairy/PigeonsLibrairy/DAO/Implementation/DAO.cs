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
    public class DAO<TEntity> : IDAO<TEntity> where TEntity : class
    {

        public DAO() { }

        /// <summary>
        /// Retreive an Entity from the Database
        /// </summary>
        /// <param name="context">The connection to the database</param>
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
        /// Delete an Entity from the Database using his ID
        /// </summary>
        /// <param name="context">The connection to the database</param>
        /// <param name="id">The ID of the Entity to delete</param>
        public virtual void Delete(pigeonsEntities1 context, object id)
        {
            try
            {
                TEntity entityToDelete = context.Set<TEntity>().Find(id);
                Delete(context, entityToDelete);
            }
            catch(Exception exception)
            {
                throw new DAOException(exception.Message);
            }                        
        }

        /// <summary>
        /// Delete an Entity from the Database
        /// </summary>
        /// <param name="context">The connection to the database</param>
        /// <param name="entityToDelete">The Entity to delete</param>
        public virtual void Delete(pigeonsEntities1 context, TEntity entityToDelete)
        {
            try
            {
                if (context.Entry(entityToDelete).State == EntityState.Detached)
                {
                    context.Set<TEntity>().Attach(entityToDelete);
                }
                context.Set<TEntity>().Remove(entityToDelete);
            }
            catch(Exception exception)
            {
                throw new DAOException(exception.Message);
            }
        }

        /// <summary>
        /// Insert an Entity in the Database
        /// </summary>
        /// <param name="context">The connection to the database</param>
        /// <param name="entity">The Entity to insert</param>
        public virtual void Insert(pigeonsEntities1 context, TEntity entity)
        {
            try
            {
                context.Set<TEntity>().Add(entity);
            }
            catch(Exception exception)
            {
                throw new DAOException(exception.Message);
            }            
        }

        /// <summary>
        /// Update an Entity from the Database
        /// </summary>
        /// <param name="context">The connection to the database</param>
        /// <param name="entityToUpdate">The Entity to update</param>
        public virtual void Update(pigeonsEntities1 context, TEntity entityToUpdate)
        {
            try
            {
                context.Set<TEntity>().Attach(entityToUpdate);
                context.Entry(entityToUpdate).State = EntityState.Modified;
            }
            catch(Exception exception)
            {
                throw new DAOException(exception.Message);
            }
        }

        /// <summary>
        /// Get an Entity from the Database by searching a value that match in a specific column
        /// </summary>
        /// <param name="context">The connection to the database</param>
        /// <param name="columnName">The name of the column to search in</param>
        /// <param name="value">The value to search</param>
        /// <returns>A list with the Entity match the query</returns>
        public IEnumerable<TEntity> GetBy(pigeonsEntities1 context, string columnName, object value)
        {
            try
            {
                return new List<TEntity>();
            }
            catch(Exception exception)
            {
                throw new DAOException(exception.Message);
            }            
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
            try
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
            catch(Exception exception)
            {
                throw new DAOException(exception.Message);
            }            
        }

        /// <summary>
        /// Retreive all the Entity from a specific table
        /// </summary>
        /// <param name="context">The connection to the database</param>
        /// <returns>A list with all the Entites from the table</returns>
        public virtual IEnumerable<TEntity> GetAll(pigeonsEntities1 context)
        {
            try
            {
                return context.Set<TEntity>().AsNoTracking().ToList();
            }
            catch(Exception exception)
            {
                throw new DAOException(exception.Message);
            }            
        }
    }
}
