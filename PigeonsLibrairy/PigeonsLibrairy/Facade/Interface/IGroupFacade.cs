using PigeonsLibrairy.Model;
using System.Collections.Generic;

namespace PigeonsLibrairy.Facade.Interface
{
    /// <summary>
    /// Interface pour la classe <see cref="Implementation.GroupFacade"/>
    /// </summary>
    public interface IGroupFacade : IFacade
    {
        // Group
        group CreateNewGroupAndRegister(group newGroup, object personID);
        bool CloseGroup(object adminID, object groupID);

        // Person    
        void AddPersonToGroup(object adminID, object personToAddID, object groupID);

        // Following
        List<following> GetGroupFollowers(object groupID);
        bool RemoveTheFollower(object groupID, object followerID);
        bool PersonIsGroupAdmin(object activePersonID, object activeGroupID);

        // Message
        bool CreateNewMessage(message messageToCreate);
        List<message> GetGroupMessages(object groupID);   
    }
}
