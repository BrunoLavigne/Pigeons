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
        void AddPersonToGroup(object adminID, object personId, object groupId);
        bool RemoveTheFollower(object groupID, object followerID);
        bool PersonIsGroupAdmin(object personID, object groupID);
        IList<following> GetTheFollowers(object groupID);
    }
}
