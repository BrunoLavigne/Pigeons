using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigeonsLibrairy.DAO.Interface
{
    /// <summary>
    /// Interface de la classe <see cref="Implementation.EventDAO"/>
    /// </summary>
    interface IEventDAO : IDAO<@event>
    {
        IEnumerable<@event> GetGroupEvent(pigeonsEntities1 context, object groupID);
        IEnumerable<@event> GetUpComingEvents(pigeonsEntities1 context, object groupID, object numberOfEvent);
    }
}
