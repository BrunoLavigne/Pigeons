using PigeonsLibrairy.Facade.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PigeonsLibrairy.Model;
using PigeonsLibrairy.Controller;
using PigeonsLibrairy.Exceptions;

namespace PigeonsLibrairy.Facade.Implementation
{
    public class GroupFacade : Facade, IGroupFacade
    {
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
                throw new FacadeException(serviceException.Message);
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
                throw new FacadeException(serviceException.Message);
            }
        }

        public bool CloseGroup(object adminID, object groupID)
        {
            try
            {
                return mainControl.GroupService.CloseGroup(adminID, groupID);
            }
            catch(ServiceException serviceException)
            {
                throw new FacadeException(serviceException.Message);
            }
        }

        /// <summary>
        /// Ajouter une personne à son groupe
        /// </summary>        
        public void AddPersonToGroup(object adminID, object personToAddID, object groupID)
        {
            try
            {
                mainControl.FollowingService.addPersonToGroup(adminID, personToAddID, groupID);
            }
            catch(ServiceException serviceException)
            {
                throw new FacadeException(serviceException.Message);
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
                throw new FacadeException(serviceException.Message);
            }            
        }

        /// <summary>
        /// Creation d'un nouveau message dans un groupe
        /// </summary>
        public bool CreateNewMessage(message messageToCreate)
        {
            try
            {
                return mainControl.MessageService.createNewMessage(messageToCreate);
            }
            catch (ServiceException serviceException)
            {
                throw new FacadeException(serviceException.Message);
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
                throw new FacadeException(serviceException.Message);
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
                throw new FacadeException(serviceException.Message);
            }
        }
    }
}
