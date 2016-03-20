using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigeonsLibrairy.DAO.Interface
{
    public interface IFollowingDAO
    {
        List<following> GetTheFollowingGroups(int personId);
        List<following> GetThePersonsFollowingGroupsId(int groupId);
    }
}
