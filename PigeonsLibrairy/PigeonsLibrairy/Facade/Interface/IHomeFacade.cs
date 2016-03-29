using PigeonsLibrairy.Model;
using System.Collections.Generic;

namespace PigeonsLibrairy.Facade.Interface
{
    public interface IHomeFacade : IFacade
    {
        bool RegisterUser(person newUser, string emailConfirmation, string passwordConfirmation);
        person LoginValidation(string username, string password);      
        List<group> GetPersonGroups(object personID);
        int GetGroupFollowers(object groupID);
        List<person> GetAllPersons(object searchValue);
    }
}
