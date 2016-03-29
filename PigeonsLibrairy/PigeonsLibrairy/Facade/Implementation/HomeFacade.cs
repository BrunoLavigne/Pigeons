using PigeonsLibrairy.Controller;
using PigeonsLibrairy.Facade.Interface;
using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigeonsLibrairy.Facade.Implementation
{

    public class HomeFacade : Facade, IHomeFacade
    {
        public HomeFacade() : base() {}

        /// <summary>
        /// Enregistrement d'un nouvel utilisateur
        /// </summary>
        public bool RegisterUser(person newUser, string emailConfirmation, string passwordConfirmation)
        {
            return mainControl.PersonService.registerNewUser(newUser, emailConfirmation, passwordConfirmation);
        }

        /// <summary>
        /// Validation de l'acces au site
        /// </summary>
        public person LoginValidation(string username, string password)
        {
            return mainControl.PersonService.loginValidation(username, password);
        }

        /// <summary>
        /// Recherche des groupes actif qu'une person suis
        /// </summary>
        public List<group> GetPersonGroups(object personID)
        {
            return mainControl.GroupService.GetPersonGroups(personID).ToList();
        }

        /// <summary>
        /// Recherche du nombre de personnes qui suivent un groupe (following)
        /// </summary>        
        public int GetGroupFollowers(object groupID)
        {
            return mainControl.FollowingService.GetTheFollowers(groupID).Count();
        }

        /// <summary>
        /// Recherche de tout les personnes dont le username (email) ou le nom concorde avec la valeur recherchée
        /// </summary>
        public List<person> GetAllPersons(object searchValue)
        {
            return mainControl.PersonService.GetBy(person.COLUMN_ALL, searchValue).ToList();
        }
    }
}
