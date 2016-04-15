using PigeonsLibrairy.Model;
using System.Collections.Generic;

namespace PigeonsLibrairy.DAO.Interface
{
    /// <summary>
    /// Interface de la classe <see cref="Implementation.PersonDAO"/>
    /// </summary>
    interface IPersonDAO : IDAO<person>
    {
        IEnumerable<person> GetPersonData(pigeonsEntities1 context, object personID);
    }
}
