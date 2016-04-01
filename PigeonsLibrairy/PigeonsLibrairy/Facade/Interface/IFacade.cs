using PigeonsLibrairy.Model;
using System.Collections.Generic;

namespace PigeonsLibrairy.Facade.Interface
{
    /// <summary>
    /// Interface pour la classe <see cref="Implementation.Facade"/>
    /// </summary>
    public interface IFacade
    {
        // Person
        person GetPersonByID(object personID);
        person UpdatePerson(object personID, person personToUpdate);
        List<person> GetPersonBy(string columnName, object value);

        // Group
        group GetGroupByID(object groupID);
    }
}
