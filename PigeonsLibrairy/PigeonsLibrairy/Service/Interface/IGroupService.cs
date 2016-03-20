using PigeonsLibrairy.Model;

namespace PigeonsLibrairy.Service.Interface
{
    public interface IGroupService
    {
        void CreateNewGroupAndRegister(group newGroup, int personId);
    }
}
