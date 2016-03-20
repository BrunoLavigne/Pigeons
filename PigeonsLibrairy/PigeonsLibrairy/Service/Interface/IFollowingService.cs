using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigeonsLibrairy.Service.Interface
{
    public interface IFollowingService
    {
        List<following> GetTheFollowingGroupsOfPersonId(int personId);
        List<following> GetThePersonsFollowingGroupsId(int groupId);
        void addPersonToGroup(int personId, int groupeId);
    }
}
