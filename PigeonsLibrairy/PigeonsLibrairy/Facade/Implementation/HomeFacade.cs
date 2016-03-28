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

    public class HomeFacade : IHomeFacade
    {
        private MainController mainControl { get; set; }

        public HomeFacade()
        {
            mainControl = new MainController();            
        }

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
        /// Mise à jour d'un utilisateur
        /// </summary>        
        public person UpdatePerson(int personID, person personToUpdate)
        {
            return mainControl.PersonService.UpdatePerson(personID, personToUpdate);
        }

        /// <summary>
        /// Recherche d'un utilisateur par ID
        /// </summary>        
        public person GetPersonByID(int personID)
        {
            return mainControl.PersonService.GetByID(personID);
        }

        /// <summary>
        /// Recherche d'un utilisateur selon un valeur donnée dans un colonne de la table person
        /// </summary>        
        public List<person> GetPersonBy(string columnName, object value)
        {
            return mainControl.PersonService.GetBy(columnName, value).ToList();
        }

        public List<group> GetPersonGroups(int personID)
        {
            return null;
        }
    }
}
