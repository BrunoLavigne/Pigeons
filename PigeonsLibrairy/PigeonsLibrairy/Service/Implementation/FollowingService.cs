using PigeonsLibrairy.Model;
using PigeonsLibrairy.Service.Interface;

namespace PigeonsLibrairy.Service.Implementation
{
    public class FollowingService : Service<following>, IFollowingService
    {
        public FollowingService(pigeonsEntities1 context) : base(context) { }
    }
}
