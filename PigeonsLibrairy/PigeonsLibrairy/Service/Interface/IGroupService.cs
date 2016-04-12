using PigeonsLibrairy.Model;
using System.Collections.Generic;

namespace PigeonsLibrairy.Service.Interface
{
    /// <summary>
    /// Interface de la classe <see cref="Implementation.GroupService"/>
    /// </summary>
    public interface IGroupService : IService<group>
    {
        group CreateNewGroupAndRegister(group newGroup, object personId);
        bool CloseGroup(object adminID, object groupID);
        IList<group> GetPersonGroups(object personID);        
    }
}
