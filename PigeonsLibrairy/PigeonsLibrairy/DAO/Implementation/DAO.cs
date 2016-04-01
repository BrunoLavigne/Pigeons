using PigeonsLibrairy.DAO.Interface;
using PigeonsLibrairy.Exceptions;
using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using System.Linq.Expressions;

namespace PigeonsLibrairy.DAO.Implementation
{
    class DAO<TEntity> : IDAO<TEntity> where TEntity : class
    {

        public DAO() { }

        /// <summary>
        /// Recherche une Entity dans la base de donnée par sa clé primaire
        /// </summary>
        /// <param name="context">La connection vers la base de données</param>
        /// <param name="id">Le ID de l'entity recherchée</param>
        /// <returns>L'Entity ou null</returns>
        public virtual TEntity GetByID(pigeonsEntities1 context, object id)
        {
            try
            {
                return context.Set<TEntity>().Find(id);
            }   
            catch(Exception ex) when (ex is ArgumentException || ex is EntityException)
            {
                throw new DAOException("Erreur dans le GetByID du DAO" + ex.Message);
            }              
        }

        /// <summary>
        /// Efface un Entity de la base de données par sa clé primaire
        /// </summary>
        /// <param name="context">La connection vers la base de données</param>
        /// <param name="id">Le ID de l'Entity à effacer</param>
        public virtual void Delete(pigeonsEntities1 context, object id)
        {
            try
            {
                TEntity entityToDelete = context.Set<TEntity>().Find(id);
                Delete(context, entityToDelete);
            }
            catch (Exception ex) when (ex is ArgumentException || ex is EntityException)
            {
                throw new DAOException("Erreur dans le Delete du DAO" + ex.Message);
            }
        }

        /// <summary>
        /// Efface une entity de la base de donnée
        /// </summary>
        /// <param name="context">La connection vers la base de données</param>
        /// <param name="entityToDelete">L'Entity à effacer</param>
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
            catch (Exception ex) when (ex is ArgumentException || ex is EntityException)
            {
                throw new DAOException("Erreur dans le Delete du DAO" + ex.Message);
            }
        }

        /// <summary>
        /// Insert une Entity dans la base de donnée
        /// </summary>
        /// <param name="context">La connection vers la base de données</param>
        /// <param name="entity">L'Entity qui doit être inséré</param>
        public virtual void Insert(pigeonsEntities1 context, TEntity entity)
        {
            try
            {
                context.Set<TEntity>().Add(entity);
            }
            catch (Exception ex) when (ex is ArgumentException || ex is EntityException)
            {
                throw new DAOException("Erreur dans le Insert du DAO" + ex.Message);
            }
        }

        /// <summary>
        /// Mise à jour d'une Entity dans la base de donnée
        /// </summary>
        /// <param name="context">La connection vers la base de données</param>
        /// <param name="entityToUpdate">L'Entity à updater</param>
        public virtual void Update(pigeonsEntities1 context, TEntity entityToUpdate)
        {
            try
            {
                context.Set<TEntity>().Attach(entityToUpdate);
                context.Entry(entityToUpdate).State = EntityState.Modified;
            }
            catch (Exception ex) when (ex is ArgumentException || ex is EntityException)
            {
                throw new DAOException("Erreur dans le Update du DAO" + ex.Message);
            }
        }

        /// <summary>
        /// Recherche une Entity dans la base de donnée à partir d'une valeur dans une colonne donnée
        /// </summary>
        /// <param name="context">La connection vers la base de données</param>
        /// <param name="columnName">Le nom de la colonne dans la table</param>
        /// <param name="value">La valeur à rechercher</param>
        /// <returns>Une liste d'Entity qui correspond à la recherche. Une liste vide sinon.</returns>
        public IEnumerable<TEntity> GetBy(pigeonsEntities1 context, string columnName, object value)
        {
            try
            {
                return new List<TEntity>();
            }
            catch (Exception ex) when (ex is ArgumentException || ex is EntityException)
            {
                throw new DAOException("Erreur dans le GetBy du DAO" + ex.Message);
            }
        }

        /// <summary>
        /// Recherche d'une Entity dans la base de donnée à partir d'une requête Linq
        /// </summary>
        /// <param name="context">La connection vers la base de données</param>
        /// <param name="filter">La requête</param>
        /// <param name="orderBy">La colonne utilisé pour trier les résultats</param>
        /// <param name="includeProperties">Pour inclure une autre table dans le résultat (LazyLoading = False)</param>
        /// <returns>Une liste d'Entity qui correspond à la requête. Une liste vide sinon.</returns>
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
            catch (Exception ex) when (ex is ArgumentException || ex is EntityException)
            {
                throw new DAOException("Erreur dans le Get du DAO" + ex.Message);
            }
        }

        /// <summary>
        /// Recherche de toute les Entity contenu dans une table
        /// </summary>
        /// <param name="context">La connection vers la base de données</param>
        /// <returns>Une liste avec tout les Entity de la table</returns>
        public virtual IEnumerable<TEntity> GetAll(pigeonsEntities1 context)
        {
            try
            {
                return context.Set<TEntity>().AsNoTracking().ToList();
            }
            catch (Exception ex) when (ex is ArgumentException || ex is EntityException)
            {
                throw new DAOException("Erreur dans le GetAll du DAO" + ex.Message);
            }
        }
    }
}
