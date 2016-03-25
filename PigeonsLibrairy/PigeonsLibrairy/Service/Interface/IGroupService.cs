using PigeonsLibrairy.Model;
using System.Collections.Generic;

namespace PigeonsLibrairy.Service.Interface
{
    public interface IGroupService : IService<group>
    {
        void CreateNewGroupAndRegister(group newGroup, int personId);
        IList<group> GetPersonGroups(int personID);
    }
}
