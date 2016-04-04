using PigeonsLibrairy.Model;
using PigeonsLibrairy.Service.Interface;
using PigeonsLibrairy.DAO.Implementation;
using System;
using System.Collections.Generic;
using PigeonsLibrairy.Exceptions;

namespace PigeonsLibrairy.Service.Implementation
{   
    /// <summary>
    /// Service pour la table Task (<see cref="task"/>)
    /// </summary>         
    public class TaskService : Service<task>, ITaskService
    {
        private TaskDAO taskDAO { get; set; }
        private GroupDAO groupDAO { get; set; } 

        /// <summary>
        /// Constructeur
        /// </summary>
        public TaskService() : base()
        {
            taskDAO = new TaskDAO();
            groupDAO = new GroupDAO();
        }

        /// <summary>
        /// Création d'une nouvelle task à l'intérieur d'un groupe
        /// </summary>
        /// <param name="newTask">La nouvelle task</param>
        /// <param name="groupID">Le ID du groupe dans lequel créer la tâche</param>
        /// <param name="personID">Le ID de la personne </param>
        /// <returns></returns>
        public task CreateNewTask(task newTask, object groupID, object personID)
        {
            if(newTask == null)
            {
                throw new ServiceException("La nouvelle Task est null");
            }

            if(groupID == null)
            {
                throw new ServiceException("Le ID du group est null");
            }

            if(personID == null)
            {
                throw new ServiceException("Le ID de la personne est null");
            }

            try
            {
                using(var context = new pigeonsEntities1())
                {
                    group groupValidation = groupDAO.GetByID(context, groupID);

                    if(groupValidation == null)
                    {
                        throw new ServiceException(string.Format("Le groupe {0} n'existe pas", groupID));
                    }

                    if (!groupValidation.Is_active)
                    {
                        throw new ServiceException(string.Format("Le groupe {0} n'est pas actif. Impossible d'ajouter une Task", groupID));
                    }

                    if(newTask.Task_End != null && newTask.Task_Start != null)
                    {
                        if(newTask.Task_End < newTask.Task_Start)
                        {
                            throw new ServiceException(string.Format("La date de fin : {0} ne peut pas précéder la date de départ : {1}", newTask.Task_End, newTask.Task_Start));
                        }
                    }

                    if(newTask.Task_Start == default(DateTime))
                    {
                        newTask.Task_Start = null;
                    }

                    if(newTask.Task_End == default(DateTime))
                    {
                        newTask.Task_End = null;
                    }

                    // Tout est beau. Insertion dans la table Task
                    newTask.Is_completed = false;
                    taskDAO.Insert(context, newTask);
                    context.SaveChanges();

                    return newTask;
                }
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }

        /// <summary>
        /// Recherche des Task d'un groupe qui ne sont pas complétées
        /// </summary>
        /// <param name="groupID">Le ID du groupe pour lequel les Task sont recherchées</param>
        /// <returns>Une liste de Task. Une liste vide sinon</returns>
        public IEnumerable<task> GetAvailableTask(object groupID)
        {
            if (groupID == null)
            {
                throw new ServiceException("Le ID du group est null");
            }

            try
            {
                return taskDAO.GetAvailableTask(groupID);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }

        /// <summary>
        /// Indique une Task comme complété
        /// </summary>
        /// <param name="taskID">Le ID de la Task à modifier</param>
        public void TaskIsCompleted(object taskID)
        {
            if(taskID == null)
            {
                throw new ServiceException("Le ID de la Task est null");
            }

            try
            {
                task taskValidation = GetByID(taskID);

                if (taskValidation.Is_completed)
                {
                    throw new ServiceException(string.Format("La Task no.{0} est déjà complétée", taskID));
                }

                using (var context = new pigeonsEntities1())
                {
                    taskValidation.Is_completed = true;
                    taskDAO.Update(context, taskValidation);
                    context.SaveChanges();
                }
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }

        }

        /// <summary>
        /// Appel le DAO pour effectuer la recherche de task
        /// </summary>
        /// <param name="columnName">Le nom de la colonne pour la recherche</param>
        /// <param name="value">La valeur rechercher</param>
        /// <returns>Une liste de task. Une liste vide sinon</returns>
        public new IEnumerable<task> GetBy(string columnName, object value)
        {
            if (columnName == "")
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
                    return taskDAO.GetBy(context, columnName, value);
                }
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }
    }
}
