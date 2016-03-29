using PigeonsLibrairy.Model;
using System.Collections.Generic;

namespace PigeonsLibrairy.Service.Interface
{
    public interface IGroupService : IService<group>
    {
        group CreateNewGroupAndRegister(group newGroup, object personId);
        IList<group> GetPersonGroups(object personID);
    }
}
