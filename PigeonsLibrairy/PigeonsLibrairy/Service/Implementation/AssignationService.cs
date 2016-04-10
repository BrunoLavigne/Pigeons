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
    /// Service pour la table <see cref="assignation"/>
    /// </summary>
    public class AssignationService : Service<assignation>, IAssignationService
    {

        private IAssignationDAO assignationDAO { get; set; }
        private ITaskDAO taskDAO { get; set; }

        /// <summary>
        /// Constructeur
        /// </summary>
        public AssignationService() : base()
        {
            assignationDAO = new AssignationDAO();
            taskDAO = new TaskDAO();
        }
        

        /// <summary>
        /// Assignation d'un Task à une personne
        /// </summary>
        /// <param name="newAssignation">La nouvelle assignation</param>
        /// <returns></returns>
        public assignation AssignTaskToPerson(assignation newAssignation)
        {
            if(newAssignation == null)
            {
                throw new ServiceException("L'assignation à créer est null");
            }

            if(newAssignation.Person_ID == 0)
            {
                throw new ServiceException("Vous devez fournir le ID de la personne à qui assigner la Task");
            }

            if(newAssignation.Task_ID == 0)
            {
                throw new ServiceException("Vous devez fournir le ID de la Task qui doit être assigné");
            }

            try
            {
                using(var context = new pigeonsEntities1())
                {
                    // Validation de l'assignation
                    assignation assignationValidation = assignationDAO.GetByID(context, newAssignation.Person_ID, newAssignation.Task_ID);

                    if (assignationValidation != null)
                    {
                        throw new ServiceException(string.Format("La person ID : {0} est déjà associé à cette tâche (ID : {1})", assignationValidation.Person_ID, assignationValidation.ID));
                    }

                    // Validation de la task
                    task taskValidation = taskDAO.GetByID(context, newAssignation.Task_ID);

                    if(taskValidation == null)
                    {
                        throw new ServiceException("Cette Task n'existe pas");
                    }

                    if (taskValidation.Is_completed)
                    {
                        throw new ServiceException(string.Format("La Task no.{0} ({1}) est déjà complété. Impossible d'assigner une personne", taskValidation.Id, taskValidation.Description));
                    }

                    // Tout est beau, ajouter à la BD
                    assignationDAO.Insert(context, newAssignation);
                    context.SaveChanges();
                    return newAssignation;
                }
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }

        /// <summary>
        /// Appel le DAO pour trouver une assignation dans la base de données
        /// </summary>
        /// <param name="personID">Le ID de la personne</param>
        /// <param name="taskID">Le ID de la Task</param>
        /// <returns>Une assignation ou null</returns>
        public assignation GetByID(object personID, object taskID)
        {
            if(personID == null)
            {
                throw new ServiceException("Le ID de la personne ne doit pas être null");
            }

            if(taskID == null)
            {
                throw new ServiceException("Le ID de la task ne doit pas être null");
            }

            try
            {
                using (var context = new pigeonsEntities1())
                {
                    return assignationDAO.GetByID(context, personID, taskID);
                }
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }

        /// <summary>
        /// Appel le DAO pour trouver une assignation dans la base de donnée
        /// </summary>
        /// <param name="columnName">Le nom de la colonne pour la recherche</param>
        /// <param name="value">La valeur à rechercher</param>
        /// <returns>Une liste d'assignation qui correspondent à la recherche</returns>
        public new IEnumerable<assignation> GetBy(string columnName, object value)
        {
            if (columnName == null || columnName == "")
            {
                throw new ServiceException("La valeur de la colonne ne doit pas être null");
            }

            if (value == null)
            {
                throw new ServiceException("La valeur recherchée ne peut pas être null");
            }

            try
            {
                using (var context = new pigeonsEntities1())
                {
                    return assignationDAO.GetBy(context, columnName, value);
                }
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }
    }
}
