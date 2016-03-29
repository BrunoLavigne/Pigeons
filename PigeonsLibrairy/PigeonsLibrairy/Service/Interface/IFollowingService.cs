using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigeonsLibrairy.Service.Interface
{
    public interface IFollowingService : IService<following>
    {
        void addPersonToGroup(object adminID, object personId, object groupId);
        IList<following> GetTheFollowers(object groupID);
    }
}
