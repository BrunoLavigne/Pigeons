using PigeonsLibrairy.DAO.Interface;
using PigeonsLibrairy.Model;

namespace PigeonsLibrairy.DAO.Implementation
{
    public class EventDAO : DAO<@event>, IEventDAO
    {
        public EventDAO(pigeonsEntities1 context) : base(context) { }
    }
}
