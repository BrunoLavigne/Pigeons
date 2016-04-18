using PigeonsLibrairy.Exceptions;
using PigeonsLibrairy.Facade.Interface;
using PigeonsLibrairy.Log;
using PigeonsLibrairy.Model;
using System.Collections.Generic;
using System.Linq;

namespace PigeonsLibrairy.Facade.Implementation
{
    /// <summary>
    /// Facade offrant accès aux services nécessaires à partir de la page Login jusqu'à la page Groups
    /// </summary>
    public class HomeFacade : Facade, IHomeFacade
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        public HomeFacade() : base() { }

        #region Person

        /// <summary>
        /// Enregistrement d'un nouvel utilisateur (appel du service)
        /// </summary>
        public bool RegisterUser(person newUser, string emailConfirmation, string passwordConfirmation)
        {
            try
            {
                return mainControl.PersonService.RegisterNewUser(newUser, emailConfirmation, passwordConfirmation);
            }
            catch (ServiceException serviceException)
            {
                ExceptionLog.LogTheError(serviceException.Message);
                return false;
            }
        }

        /// <summary>
        /// Validation de l'acces au site (appel du service)
        /// </summary>
        public person LoginValidation(string username, string password)
        {
            try
            {
                return mainControl.PersonService.LoginValidation(username, password);
            }
            catch (ServiceException serviceException)
            {
                ExceptionLog.LogTheError(serviceException.Message);
                return null;
            }
        }

        /// <summary>
        /// Recherche des informations (person/following/groups) reliés à une person par son ID
        ///
        /// </summary>
        /// <param name="personID"></param>
        /// <returns></returns>
        public person GetPersonData(object personID)
        {
            try
            {
                return mainControl.PersonService.GetPersonData(personID);
            }
            catch (ServiceException serviceException)
            {
                ExceptionLog.LogTheError(serviceException.Message);
                return null;
            }
        }

        /// <summary>
        /// Recherche de tout les personnes dont le username (email) ou le nom concorde avec la valeur recherchée
        /// </summary>
        public List<person> GetAllPersons(object searchValue)
        {
            try
            {
                return mainControl.PersonService.GetBy(person.COLUMN_ALL, searchValue).ToList();
            }
            catch (ServiceException serviceException)
            {
                ExceptionLog.LogTheError(serviceException.Message);
                return null;
            }
        }

        #endregion Person

        #region Groups

        /// <summary>
        /// Recherche des groupes actif qu'une person suis (appel du service)
        /// </summary>
        public List<group> GetPersonGroups(object personID)
        {
            try
            {
                return mainControl.GroupService.GetPersonGroups(personID).ToList();
            }
            catch (ServiceException serviceException)
            {
                ExceptionLog.LogTheError(serviceException.Message);
                return null;
            }
        }

        #endregion Groups

        #region Following

        /// <summary>
        /// Recherche du nombre de personnes qui suivent un groupe (following) (appel du service)
        /// </summary>
        public int GetGroupFollowers(object groupID)
        {
            try
            {
                return mainControl.FollowingService.GetTheFollowers(groupID).Count();
            }
            catch (ServiceException serviceException)
            {
                ExceptionLog.LogTheError(serviceException.Message);
                return 0;
            }
        }

        #endregion Following
    }
}