using PigeonsLibrairy.Model;
using System.Collections.Generic;

namespace PigeonsLibrairy.DAO.Interface
{
    /// <summary>
    /// Interface de la classe <see cref="Implementation.TaskDAO"/>
    /// </summary>
    interface ITaskDAO : IDAO<task>
    {
        IEnumerable<task> GetAvailableTask(object groupID);
    }
}
