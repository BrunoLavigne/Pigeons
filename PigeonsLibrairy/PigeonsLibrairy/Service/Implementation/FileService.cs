using PigeonsLibrairy.DAO.Implementation;
using PigeonsLibrairy.DAO.Interface;
using PigeonsLibrairy.Exceptions;
using PigeonsLibrairy.Model;
using PigeonsLibrairy.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigeonsLibrairy.Service.Implementation
{
    /// <summary>
    /// Service pour la table <see cref="file"/>
    /// </summary>
    public class FileService : Service<file>, IFileService
    {
        private IFileDAO fileDAO { get; set; }
        private IGroupDAO groupDAO { get; set; }

        public FileService()
        {
            fileDAO = new FileDAO();
            groupDAO = new GroupDAO();
        }

        /// <summary>
        /// Appel du FileDAO pour avoir les informations sur les fichier associés à un Group
        /// </summary>
        /// <param name="groupID">Le ID du group pour lequel nous voulons les fichiers</param>
        /// <returns>Une liste de fichier ou une liste vide</returns>
        public IEnumerable<file> GetFilesByGroup(object groupID)
        {
            if (groupID == null)
            {
                throw new ServiceException("Le ID du group est null");
            }

            try
            {
                using (var context = new pigeonsEntities1())
                {
                    group groupValidation = groupDAO.GetByID(context, groupID);

                    if (groupValidation == null)
                    {
                        throw new ServiceException(string.Format("Le groupe no.{0} n'existe pas", groupID));
                    }

                    if (!groupValidation.Is_active)
                    {
                        throw new ServiceException(string.Format("Le groupe no.{0} n'est pas actif. Impossible de récupérer ses fichiers", groupID));
                    }

                    return fileDAO.GetFilesByGroup(context, groupID);
                }
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }

        /// <summary>
        /// Appel du DAO pour insérer les informations d'un fichier dans la BD
        /// </summary>
        /// <param name="newFile">Le fichier à insérer</param>
        /// <returns>Le fichier insérer</returns>
        public file InsertFileInformations(file newFile)
        {
            if (newFile == null)
            {
                throw new ServiceException("La File est null");
            }

            try
            {
                using (var context = new pigeonsEntities1())
                {
                    newFile.Creation_Date = DateTime.Now;
                    fileDAO.Insert(context, newFile);
                    context.SaveChanges();

                    return fileDAO.GetByID(context, newFile.ID);
                }
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }
    }
}