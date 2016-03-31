using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigeonsLibrairy.Facade.Interface
{
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
