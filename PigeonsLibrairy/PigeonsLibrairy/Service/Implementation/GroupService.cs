using PigeonsLibrairy.Model;
using PigeonsLibrairy.Service.Interface;

namespace PigeonsLibrairy.Service.Implementation
{
    public class GroupService : Service<group>, IGroupService
    {
        public GroupService(pigeonsEntities1 context) : base(context) { }       
    }
}
