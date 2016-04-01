using PigeonsLibrairy.DAO.Implementation;
using PigeonsLibrairy.Exceptions;
using PigeonsLibrairy.Model;
using PigeonsLibrairy.Service.Interface;
using System.Collections.Generic;
using System.Linq;
using System;

namespace PigeonsLibrairy.Service.Implementation
{
    public class ProjectService : Service<project>, IProjectService
    {
        private ProjectDAO projectDAO { get; set; }
        private GroupDAO groupDAO { get; set; }

        public ProjectService() : base()
        {
            projectDAO = new ProjectDAO();
            groupDAO = new GroupDAO();
        }

        /// <summary>
        /// Creation d'un nouveau project à l'intérieur d'un groupe
        /// </summary>
        /// <param name="aProject">Le nouveau project à créer</param>
        /// <param name="groupID">Le ID du groupe dans lequel le projet est créé</param>
        /// <returns>Le project créer, null sinon</returns>
        public project CreateNewProject(project aProject, object groupID)
        {
            if(aProject == null)
            {
                throw new ServiceException("Le projet est null");
            }

            if(groupID == null)
            {
                throw new ServiceException("Le ID du groupe est null");
            }

            using(var context = new pigeonsEntities1())
            {
                try
                {
                    group groupValidation = groupDAO.GetByID(context, groupID);

                    if (groupValidation == null)
                    {
                        throw new ServiceException("Ce groupe n'existe pas");
                    }

                    if (!groupValidation.Is_active)
                    {
                        throw new ServiceException("Ce groupe n'est pas actif");
                    }

                    projectDAO.Insert(context, aProject);
                    context.SaveChanges();
                    return aProject;
                }
                catch(DAOException daoException)
                {
                    throw new ServiceException(daoException.Message);
                }                
            }
        }

        /// <summary>
        /// Recherche des projects pour un groupe donnée
        /// </summary>
        /// <param name="groupID">Le ID du group pour lequel nous cherchons les projets</param>
        /// <returns>Une liste qui contient tout les projets du groupe</returns>
        public IEnumerable<project> GetProjectsFromGroup(object groupID)
        {
            if (groupID == null)
            {
                throw new ServiceException("Le ID du groupe est null");
            }

            try
            {
                return GetBy(project.COLUMN_GROUP_ID, groupID);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }                        
        }

        /// <summary>
        /// Recherche d'un project selon une colonne donnée
        /// </summary>
        /// <param name="columnName">Le nom de la colonne utilisée pour la recherche</param>
        /// <param name="value">La valeur recherchée</param>
        /// <returns>Une liste de project ou un liste vide si aucune project n'ai trouvé</returns>
        public new IEnumerable<project> GetBy(string columnName, object value)
        {        
            if (columnName != "" && value != null)
            {
                using(var context = new pigeonsEntities1())
                {                   
                    return projectDAO.GetBy(context, columnName, value);
                }
            }
            else
            {
                throw new ServiceException("You must provid the column name and a value");
            }
        }
    }
}
