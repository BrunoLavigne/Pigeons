using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigeonsLibrairy.Service.Interface
{
    /// <summary>
    /// Interface de la classe <see cref="Implementation.EventService"/>
    /// </summary>
    public interface IEventService : IService<@event>
    {
        @event CreateNewEvent(@event newEvent);

        IEnumerable<@event> GetGroupEvent(object groupID, object date);

        void ChangeEventStatus(object taskID, object taskStatus);
    }
}