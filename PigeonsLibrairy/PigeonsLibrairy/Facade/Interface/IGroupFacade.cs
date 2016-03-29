using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigeonsLibrairy.Facade.Interface
{
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
        
        // Message
        bool CreateNewMessage(message messageToCreate);
        List<message> GetGroupMessages(object groupID);
    }
}
