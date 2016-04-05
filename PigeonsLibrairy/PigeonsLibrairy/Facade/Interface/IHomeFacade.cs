using PigeonsLibrairy.Model;
using System.Collections.Generic;

namespace PigeonsLibrairy.Facade.Interface
{
    /// <summary>
    /// Interface pour la classe <see cref="Implementation.HomeFacade"/>
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
