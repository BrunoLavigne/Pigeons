using PigeonsLibrairy.DAO.Implementation;
using PigeonsLibrairy.Exceptions;
using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PigeonsLibrairy.Service.Implementation
{
    /// <summary>
    /// Service partager par toute les classe de service
    /// </summary>
    /// <typeparam name="TEntity">Le type de l'Entity</typeparam>
    public class Service<TEntity> where TEntity : class
    {
        private DAO<TEntity> dao { get; set; }

        public Service()
        {
            this.dao = new DAO<TEntity>();
        }

        /// <summary>
        /// Appel le DAO pour effacer une Entity de la base de données
        /// </summary>
        /// <param name="entityToDelete">L'Entity à effacer</param>
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
                catch (Exception ex) when (ex is DAOException)
                {
                    throw new ServiceException(ex.Message);                    
                }                
            }                  
        }

        /// <summary>
        /// Appel le DAO afin d'effacer une Entity de la base de données
        /// </summary>
        /// <param name="id">Le ID de l'Entity qui doit être effacée</param>
        public void Delete(object id)
        {
            try
            {
                using (var context = new pigeonsEntities1())
                {
                    TEntity entityToDelete = dao.GetByID(context, id);
                    Delete(entityToDelete);
                }
            }
            catch (Exception ex) when (ex is DAOException)
            {
                throw new ServiceException(ex.Message);
            }
        }

        /// <summary>
        /// Appel le DAO pour trouver une Entity à l'aide d'une requête Linq
        /// </summary>
        /// <param name="filter">La requête</param>
        /// <param name="orderBy">La colonne de tri</param>
        /// <param name="includeProperties">Les tables rajouter à la requête</param>
        /// <returns>Une liste d'Entity qui corresponde à la requête</returns>
        public IEnumerable<TEntity> Get(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            try
            {
                using (var context = new pigeonsEntities1())
                {
                    return dao.Get(context, filter, orderBy, includeProperties);
                }
            }
            catch (Exception ex) when (ex is DAOException)
            {
                throw new ServiceException(ex.Message);
            }
        }

        /// <summary>
        /// Appel le DAO pour rechercher une Entity par sa clé primaire
        /// </summary>
        /// <param name="id">Le ID de l'Entity rechercher</param>
        /// <returns>L'Entity rechercher. Null sinon</returns>
        public TEntity GetByID(object id)
        {
            try
            {
                using (var context = new pigeonsEntities1())
                {
                    return dao.GetByID(context, id);
                }
            }
            catch(Exception ex) when (ex is DAOException)
            {
                throw new ServiceException(ex.Message);
            }
                     
        }

        /// <summary>
        /// Appel le DAO pour rechercher une Entity à l'aide d'une valeur dans une colonne donnée
        /// </summary>
        /// <param name="columnName">Le nom de la colonne</param>
        /// <param name="value">La valeur à rechercher</param>
        /// <returns>Une liste d'Entity qui corresponde à la recherche, une liste vide sinon</returns>
        public IEnumerable<TEntity> GetBy(string columnName, object value)
        {
            try
            {
                using (var context = new pigeonsEntities1())
                {
                    return dao.GetBy(context, columnName, value);
                }
            }            
            catch(Exception ex) when (ex is DAOException)
            {
                throw new ServiceException(ex.Message);
            }
        }

        /// <summary>
        /// Appel le DAO pour insérer une Entity dans la base de données
        /// </summary>
        /// <param name="entity">L'Entity qui doit être inséré</param>
        public void Insert(TEntity entity)
        {
            try
            {
                using (var context = new pigeonsEntities1())
                {
                    dao.Insert(context, entity);
                }
            }
            catch (Exception ex) when (ex is DAOException)
            {
                throw new ServiceException(ex.Message);
            }                      
        }

        /// <summary>
        /// Appel le DAO pour Updater une Entity
        /// </summary>
        /// <param name="entityToUpdate">L'Entity qui doit être updater</param>
        public void Update(TEntity entityToUpdate)
        {
            try
            {
                using (var context = new pigeonsEntities1())
                {
                    dao.Update(context, entityToUpdate);
                }
            }
            catch(Exception ex) when (ex is DAOException)
            {
                throw new ServiceException(ex.Message);
            }            
        }

        /// <summary>
        /// Appel le DAO afin d'avoir la liste de toute les Entity comprise dans une table
        /// </summary>
        /// <returns>Une liste d'Entity</returns>
        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                using (var context = new pigeonsEntities1())
                {
                    return dao.GetAll(context);
                }
            }
            catch(Exception ex) when (ex is DAOException)
            {
                throw new ServiceException(ex.Message);
            }                     
        }
    }
}
