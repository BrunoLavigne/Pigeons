using PigeonsLibrairy.Facade.Interface;
using System.Collections.Generic;
using System.Linq;
using PigeonsLibrairy.Model;
using PigeonsLibrairy.Exceptions;
using PigeonsLibrairy.Log;

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
        public GroupFacade() : base() {}

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
        public List<following> GetGroupFollowers(object groupID)
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

        /// <summary>
        /// Ajout un nouveau projet à un groupe
        /// </summary>
        /// <param name="projectToInsert"></param>
        /// <returns></returns>
            //public project CreateNewProject(project projectToInsert, object groupID)
            //{
            //    try
            //    {
            //        return mainControl.ProjectService.CreateNewProject(projectToInsert, groupID);
            //    }
            //    catch (ServiceException serviceException)
            //    {
            //        ExceptionLog.LogTheError(serviceException.Message);
            //        return null;
            //    }
            //}

            //public IEnumerable<project> GetProjectsFromGroup(object groupID)
            //{
            //    try
            //    {
            //        return mainControl.ProjectService.GetProjectsFromGroup(groupID);
            //    }
            //    catch (ServiceException serviceException)
            //    {
            //        ExceptionLog.LogTheError(serviceException.Message);
            //        return null;
            //    }
            //}

        /// <summary>
        /// Recherche de tout les types qui sont disponibles
        /// </summary>
        /// <returns></returns>
            //public IEnumerable<type> GetAllTypes()
            //{
            //    try
            //    {
            //        return mainControl.TypeService.GetAll();
            //    }
            //    catch (ServiceException serviceException)
            //    {
            //        ExceptionLog.LogTheError(serviceException.Message);
            //        return null;
            //    }
            //}
    }
}
