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
    internal interface IEventDAO : IDAO<@event>
    {
        IEnumerable<@event> GetGroupEvent(pigeonsEntities1 context, object groupID);

        IEnumerable<@event> GetGroupEventByMonth(pigeonsEntities1 context, object groupID, object date);
    }
}