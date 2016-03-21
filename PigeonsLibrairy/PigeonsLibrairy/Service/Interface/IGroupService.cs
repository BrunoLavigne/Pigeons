using PigeonsLibrairy.Model;
using System.Collections.Generic;

namespace PigeonsLibrairy.Service.Interface
{
    public interface IGroupService
    {
        void CreateNewGroupAndRegister(group newGroup, int personId);
        IEnumerable<group> GetGroupBy(string columnName, object value);
    }
}
