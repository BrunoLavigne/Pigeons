using PigeonsLibrairy.Exceptions;
using PigeonsLibrairy.Facade.Interface;
using PigeonsLibrairy.Log;
using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PigeonsLibrairy.Facade.Implementation
{
    /// <summary>
    /// Facade offrant les service pour les pages de group
    /// </summary>
    public class GroupFacade : Facade, IGroupFacade
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        public GroupFacade() : base() { }

        #region Group

        /// <summary>
        /// Création d'un nouveau groupe et inscription du membre à celui-ci
        /// </summary>
        public group CreateNewGroupAndRegister(group newGroup, object personID)
        {
            try
            {
                return mainControl.GroupService.CreateNewGroupAndRegister(newGroup, personID);
            }
            catch (ServiceException serviceException)
            {
                ExceptionLog.LogTheError(serviceException.Message);
                return null;
            }
        }

        /// <summary>
        /// Fermeture d'un groupe
        /// </summary>
        public bool CloseGroup(object adminID, object groupID)
        {
            try
            {
                return mainControl.GroupService.CloseGroup(adminID, groupID);
            }
            catch (ServiceException serviceException)
            {
                ExceptionLog.LogTheError(serviceException.Message);
                return false;
            }
        }

        #endregion Group

        #region Following

        /// <summary>
        /// Retire une personne du groupe
        /// </summary>
        /// <param name="groupID">Le groupe ID du groupe à modifier</param>
        /// <param name="followerID">Le ID de la person à retirer du groupe</param>
        /// <returns>True si la personne à été retiré, une erreur sinon</returns>
        public bool RemoveTheFollower(object groupID, object followerID)
        {
            try
            {
                return mainControl.FollowingService.RemoveTheFollower(groupID, followerID);
            }
            catch (ServiceException serviceException)
            {
                ExceptionLog.LogTheError(serviceException.Message);
                return false;
            }
        }

        /// <summary>
        /// Ajouter une personne à son groupe
        /// </summary>
        public void AddPersonToGroup(object adminID, object personToAddID, object groupID)
        {
            try
            {
                mainControl.FollowingService.AddPersonToGroup(adminID, personToAddID, groupID);
            }
            catch (ServiceException serviceException)
            {
                ExceptionLog.LogTheError(serviceException.Message);
            }
        }

        /// <summary>
        /// Recherche des personnes qui suivent un groupe (following)
        /// </summary>
        public List<person> GetGroupFollowers(object groupID)
        {
            try
            {
                return mainControl.FollowingService.GetTheFollowers(groupID).ToList();
            }
            catch (ServiceException serviceException)
            {
                ExceptionLog.LogTheError(serviceException.Message);
                return null;
            }
        }

        /// <summary>
        /// Vérification si la personne est l'administrateur du groupe
        /// </summary>
        public bool PersonIsGroupAdmin(object activePersonID, object activeGroupID)
        {
            try
            {
                return mainControl.FollowingService.PersonIsGroupAdmin(activePersonID, activeGroupID);
            }
            catch (ServiceException serviceException)
            {
                ExceptionLog.LogTheError(serviceException.Message);
                return false;
            }
        }

        #endregion Following

        #region Message

        /// <summary>
        /// Creation d'un nouveau message dans un groupe
        /// </summary>
        public bool CreateNewMessage(message messageToCreate)
        {
            try
            {
                return mainControl.MessageService.CreateNewMessage(messageToCreate);
            }
            catch (ServiceException serviceException)
            {
                ExceptionLog.LogTheError(serviceException.Message);
                return false;
            }
        }

        /// <summary>
        /// Recherche des message d'un groupe
        /// </summary>
        public List<message> GetGroupMessages(object groupID)
        {
            try
            {
                return mainControl.MessageService.GetGroupMessages(groupID).ToList();
            }
            catch (ServiceException serviceException)
            {
                ExceptionLog.LogTheError(serviceException.Message);
                return null;
            }
        }

        #endregion Message

        #region Task

        /// <summary>
        /// Recherche de toutes les Tasks associées à un groupe
        /// </summary>
        public List<task> GetGroupTasks(object groupID, bool completed)
        {
            try
            {
                return mainControl.TaskService.GetGroupTasks(groupID, completed).ToList();
            }
            catch (ServiceException serviceException)
            {
                ExceptionLog.LogTheError(serviceException.Message);
                return null;
            }
        }

        /// <summary>
        /// Efface une Task
        /// </summary>
        public void DeleteTask(object taskID)
        {
            try
            {
                mainControl.TaskService.DeleteTask(taskID);
            }
            catch (ServiceException serviceException)
            {
                ExceptionLog.LogTheError(serviceException.Message);
            }
        }

        /// <summary>
        /// Création d'une nouvelle Task dans un groupe
        /// </summary>
        public task CreateNewTask(task newTask, object groupID, object personID)
        {
            try
            {
                return mainControl.TaskService.CreateNewTask(newTask, groupID, personID);
            }
            catch (ServiceException serviceException)
            {
                ExceptionLog.LogTheError(serviceException.Message);
                return null;
            }
        }

        /// <summary>
        /// Marque une assignation comme étant complétée ou non
        /// </summary>
        public void UpdateTaskCompleted(object taskID, bool completed)
        {
            try
            {
                mainControl.TaskService.UpdateTaskCompleted(taskID, completed);
            }
            catch (ServiceException serviceException)
            {
                ExceptionLog.LogTheError(serviceException.Message);
            }
        }

        #endregion Task

        #region Assignation

        /// <summary>
        /// Assignation d'une Person à une Task
        /// </summary>
        public assignation AssignTaskToPerson(assignation newAssignation)
        {
            try
            {
                return mainControl.AssignationService.AssignTaskToPerson(newAssignation);
            }
            catch (ServiceException serviceException)
            {
                ExceptionLog.LogTheError(serviceException.Message);
                return null;
            }
        }

        /// <summary>
        /// Retire une assignation faite à une personne
        /// </summary>
        public void RemoveAssignation(object taskID, object personID)
        {
            try
            {
                mainControl.AssignationService.RemoveAssignation(taskID, personID);
            }
            catch (ServiceException serviceException)
            {
                ExceptionLog.LogTheError(serviceException.Message);
            }
        }

        #endregion Assignation

        #region Event

        /// <summary>
        /// Création d'un nouvel évènement dans un groupe
        /// </summary>
        public @event CreateNewEvent(@event newEvent)
        {
            try
            {
                return mainControl.EventService.CreateNewEvent(newEvent);
            }
            catch (ServiceException serviceException)
            {
                ExceptionLog.LogTheError(serviceException.Message);
                return null;
            }
        }

        /// <summary>
        /// Recherche de tout les Events non complétés d'un groupe
        /// </summary>
        public List<@event> GetGroupEvent(object groupID, object date = null)
        {
            try
            {
                return mainControl.EventService.GetGroupEvent(groupID, date).ToList();
            }
            catch (ServiceException serviceException)
            {
                ExceptionLog.LogTheError(serviceException.Message);
                return null;
            }
        }

        /// <summary>
        /// Changement du status d'un Event
        /// </summary>
        public void ChangeEventStatus(object taskID, object taskStatus)
        {
            try
            {
                mainControl.EventService.ChangeEventStatus(taskID, taskStatus);
            }
            catch (ServiceException serviceException)
            {
                ExceptionLog.LogTheError(serviceException.Message);
            }
        }

        #endregion Event

        #region ChatHistory

        /// <summary>
        /// Recherche des messages chats pour un Groupe
        /// </summary>
        /// 
        ////////////////////////JE DOIS ME SERVIRE DE CELLE CI ////////////////////////
        public List<chathistory> GetGroupChatHistory(object groupID)
        {
            try
            {
                return mainControl.ChatHistoryService.GetAllMessagesFromGroup(groupID).ToList();
            }
            catch (ServiceException serviceException)
            {
                ExceptionLog.LogTheError(serviceException.Message);
                return null;
            }
        }

        /// <summary>
        /// Insertion du message dans la base de données
        /// </summary>
        public void InsertChatMessage(chathistory chatMessage)
        {
            try
            {
                mainControl.ChatHistoryService.InsertChatMessage(chatMessage);
            }
            catch (ServiceException serviceException)
            {
                ExceptionLog.LogTheError(serviceException.Message);
            }
        }

        #endregion ChatHistory
    }
}