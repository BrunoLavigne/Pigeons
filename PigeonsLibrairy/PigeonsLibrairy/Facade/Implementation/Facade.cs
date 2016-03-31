using PigeonsLibrairy.Controller;
using PigeonsLibrairy.Exceptions;
using PigeonsLibrairy.Facade.Interface;
using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigeonsLibrairy.Facade.Implementation
{
    public class Facade : IFacade
    {
        protected MainController mainControl { get; set; }

        public Facade()
        {
            mainControl = new MainController();
        }

        #region Person      

        /// <summary>
        /// Recherche d'un utilisateur par ID
        /// </summary>        
        public person GetPersonByID(object personID)
        {
            try
            {
                return mainControl.PersonService.GetByID(personID);
            }
            catch(ServiceException serviceException)
            {
                throw new FacadeException(serviceException.Message);
            }            
        }

        /// <summary>
        /// Recherche d'un utilisateur selon un valeur donnée dans un colonne de la table person
        /// </summary>        
        public List<person> GetPersonBy(string columnName, object value)
        {
            try
            {
                return mainControl.PersonService.GetBy(columnName, value).ToList();
            }
            catch (ServiceException serviceException)
            {
                throw new FacadeException(serviceException.Message);
            }
                        
        }

        /// <summary>
        /// Mise à jour d'un utilisateur
        /// </summary>        
        public person UpdatePerson(object personID, person personToUpdate)
        {
            try
            {
                return mainControl.PersonService.UpdatePerson(personID, personToUpdate);
            }            
            catch (ServiceException serviceException)
            {
                throw new FacadeException(serviceException.Message);
            }            
        }

        #endregion Person

        #region Group


        /// <summary>
        /// Recherche d'un groupe selon son ID
        /// </summary>
        public group GetGroupByID(object groupID)
        {
            try
            {
                return mainControl.GroupService.GetByID(groupID);
            }
            catch (ServiceException serviceException)
            {
                throw new FacadeException(serviceException.Message);
            }
        }

        #endregion Group
    }
}
