using PigeonsLibrairy.Model;
using System.Collections.Generic;

namespace PigeonsLibrairy.Service.Interface
{
    /// <summary>
    /// Interface de la classe <see cref="Implementation.FollowingService"/>
    /// </summary>
    public interface IFollowingService : IService<following>
    {
        void AddPersonToGroup(object adminID, object personId, object groupId);
        bool RemoveTheFollower(object groupID, object followerID);
        bool PersonIsGroupAdmin(object personID, object groupID);
        IList<following> GetTheFollowers(object groupID);
    }
}
