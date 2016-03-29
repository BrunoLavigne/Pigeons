using PigeonsLibrairy.Model;
using System.Collections.Generic;

namespace PigeonsLibrairy.Facade.Interface
{
    public interface IHomeFacade
    {
        bool RegisterUser(person newUser, string emailConfirmation, string passwordConfirmation);
        person LoginValidation(string username, string password);
        person UpdatePerson(int personID, person personToUpdate);
        person GetPersonByID(int personID);
        List<person> GetPersonBy(string columnName, object value);
        List<group> GetPersonGroups(object personID);
        int GetGroupFollowers(object groupID);
        List<person> GetAllPersons(object searchValue);
    }
}
