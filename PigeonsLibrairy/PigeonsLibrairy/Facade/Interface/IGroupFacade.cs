using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigeonsLibrairy.Facade.Interface
{
    public interface IGroupFacade
    {
        // Group
        group GetGroupByID(object groupID);
        group CreateNewGroupAndRegister(group newGroup, object personID);

        // Person    
        person GetPersonByID(object personID);
        void AddPersonToGroup(object adminID, object personToAddID, object groupID);

        // Following
        List<following> GetGroupFollowers(object groupID);
        
        // Message
        bool CreateNewMessage(message messageToCreate);
        List<message> GetGroupMessages(object groupID);
    }
}
