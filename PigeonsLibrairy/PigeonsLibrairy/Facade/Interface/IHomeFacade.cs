using PigeonsLibrairy.Model;
using System.Collections.Generic;

namespace PigeonsLibrairy.Facade.Interface
{
    /// <summary>
    /// Interface pour le HomeFacade
    /// Rend accessible toutes les fonctions nécessaires lorsqu'un utilisateur accède au site, avant de rentrer dans son dashboard
    /// </summary>
    public interface IHomeFacade : IFacade
    {
        // Person
        bool RegisterUser(person newUser, string emailConfirmation, string passwordConfirmation);
        person LoginValidation(string username, string password);
        List<person> GetAllPersons(object searchValue);

        // Group
        List<group> GetPersonGroups(object personID);
        int GetGroupFollowers(object groupID);        
    }
}
