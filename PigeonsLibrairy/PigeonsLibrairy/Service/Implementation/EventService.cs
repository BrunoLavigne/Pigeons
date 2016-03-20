using PigeonsLibrairy.Model;
using PigeonsLibrairy.Service.Interface;

namespace PigeonsLibrairy.Service.Implementation
{
    public class EventService : Service<@event>, IEventService
    {
        public EventService(pigeonsEntities1 context) : base(context) { }
    }
}
