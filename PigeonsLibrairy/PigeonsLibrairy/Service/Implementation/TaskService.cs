using PigeonsLibrairy.Model;
using PigeonsLibrairy.Service.Interface;
using PigeonsLibrairy.DAO.Implementation;
using System;
using System.Collections.Generic;
using PigeonsLibrairy.Exceptions;
using PigeonsLibrairy.DAO.Interface;

namespace PigeonsLibrairy.Service.Implementation
{   
    /// <summary>
    /// Service pour la table Task (<see cref="task"/>)
    /// </summary>         
    public class TaskService : Service<task>, ITaskService
    {
        private ITaskDAO taskDAO { get; set; }
        private IGroupDAO groupDAO { get; set; } 
        private IPersonDAO personDAO { get; set; }
        private IFollowingDAO followingDAO { get; set; }

        /// <summary>
        /// Constructeur
        /// </summary>
        public TaskService() : base()
        {
            taskDAO     = new TaskDAO();
            groupDAO    = new GroupDAO();
            personDAO   = new PersonDAO();
            followingDAO = new FollowingDAO();
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

                    if (newTask.Task_Start == default(DateTime))
                    {
                        newTask.Task_Start = null;
                    }

                    if (newTask.Task_End == default(DateTime))
                    {
                        newTask.Task_End = null;
                    }

                    /*********** Validation du groupe ***********/
                    group groupValidation = groupDAO.GetByID(context, groupID);

                    if(groupValidation == null)
                    {
                        throw new ServiceException(string.Format("Le groupe {0} n'existe pas", groupID));
                    }

                    if (!groupValidation.Is_active)
                    {
                        throw new ServiceException(string.Format("Le groupe {0} n'est pas actif. Impossible d'ajouter une Task", groupID));
                    }

                    /*********** Validation de la personne ***********/
                    person personValidation = personDAO.GetByID(context, personID);

                    if(personValidation == null)
                    {
                        throw new ServiceException(string.Format("La person {0} n'existe pas", personID));
                    }

                    /*********** Validation du following ***********/
                    following followingValidation = followingDAO.GetByID(context, personID, groupID);

                    if(followingValidation == null)
                    {
                        throw new ServiceException(string.Format("Le following [ {0} - {1} ] n'existe pas", personID, groupID));
                    }

                    if (!followingValidation.Is_active)
                    {
                        throw new ServiceException(string.Format("Le person ID : {0} n'est plus active dans le groupe ID : {1}", personID, groupID));
                    }

                    /************* Validation des dates *************/
                    if (newTask.Task_End != null && newTask.Task_Start != null)
                    {
                        if(newTask.Task_End < newTask.Task_Start)
                        {
                            throw new ServiceException(string.Format("La date de fin : {0} ne peut pas précéder la date de départ : {1}", newTask.Task_End, newTask.Task_Start));
                        }
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
        public IEnumerable<task> GetGroupTasks(object groupID, bool completed)
        {
            if (groupID == null)
            {
                throw new ServiceException("Le ID du group est null");
            }

            try
            {
                return taskDAO.GetGroupTasks(groupID, completed);
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }

        /// <summary>
        /// Indique une Task comme complété ou non
        /// </summary>
        /// <param name="taskID">Le ID de la Task à modifier</param>
        /// <param name="completed">True si la task est complété, False si elle ne l'est pas</param>
        public void UpdateTaskCompleted(object taskID, bool completed)
        {
            if(taskID == null)
            {
                throw new ServiceException("Le ID de la Task est null");
            }

            try
            {
                task taskValidation = GetByID(taskID);

                if (taskValidation.Is_completed == completed)
                {
                    throw new ServiceException(string.Format("La Task no.{0} est déjà dans l'état désiré ( {1} )", taskID, completed));
                }

                using (var context = new pigeonsEntities1())
                {
                    taskValidation.Is_completed = completed;
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
