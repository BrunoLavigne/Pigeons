using PigeonsLibrairy.DAO.Interface;
using PigeonsLibrairy.Exceptions;
using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Linq.Expressions;

namespace PigeonsLibrairy.DAO.Implementation
{
    /// <summary>
    /// DAO pour la table <see cref="file"/>
    /// </summary>
    internal class FileDAO : DAO<file>, IFileDAO
    {
        /// <summary>
        /// Recherche des Files d'un Group dans la base de donnée
        /// </summary>
        /// <param name="context">La connection à la base de données</param>
        /// <param name="groupID">Le ID du group pour lequel nous voulons les Files</param>
        /// <returns>Une liste de File ou un liste vide</returns>
        public IEnumerable<file> GetFilesByGroup(pigeonsEntities1 context, object groupID)
        {
            try
            {
                Expression<Func<file, bool>> filter = (f => f.Group_ID == (int)groupID);
                return Get(context, filter).OrderBy(f => f.Creation_Date);
            }
            catch (Exception ex) when (ex is EntityException || ex is DAOException)
            {
                throw new DAOException("Erreur dans le FileDAO GetFilesByGroup : " + ex.Message);
            }
        }

        /// <summary>
        /// Recherche un fichier en fonction de son chemin sur le serveur
        /// </summary>
        /// <param name="context">La connection à la base de données</param>
        /// <param name="filePath">Le chemin vers le fichier sur le serveur</param>
        public IEnumerable<file> GetByFilePath(pigeonsEntities1 context, object filePath)
        {
            try
            {
                Expression<Func<file, bool>> filter = (f => f.FileURL == (string)filePath);
                return Get(context, filter);
            }
            catch (Exception ex) when (ex is EntityException || ex is DAOException)
            {
                throw new DAOException("Erreur dans le FileDAO GetByFilePath : " + ex.Message);
            }
        }
    }
}