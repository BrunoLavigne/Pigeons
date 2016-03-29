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
    public class GroupFacade : IGroupFacade
    {
        private MainController mainControl { get; set; }

        public GroupFacade()
        {
            mainControl = new MainController();
        }

        /// <summary>
        /// Création d'un nouveau groupe et inscription du membre à celui-ci
        /// </summary>
        public group CreateNewGroupAndRegister(group newGroup, object personID)
        {
            return mainControl.GroupService.CreateNewGroupAndRegister(newGroup, personID);
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
        /// Recherche d'un groupe selon son ID
        /// </summary>
        public group GetGroupByID(object groupID)
        {
            try
            {
                return mainControl.GroupService.GetByID(groupID);
            }
            catch(ServiceException serviceException)
            {
                throw new FacadeException(serviceException.Message);
            }            
        }

        /// <summary>
        /// Recherche d'une personne selon son ID
        /// </summary>        
        public person GetPersonByID(object personID)
        {
            try
            {
                return mainControl.PersonService.GetByID(personID);
            }
            catch (ServiceException serviceException)
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
    }
}
