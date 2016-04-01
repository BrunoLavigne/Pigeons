using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigeonsLibrairy.DAO.Interface
{
    /// <summary>
    /// Interface de la class <see cref="Implementation.FollowingDAO"/>
    /// </summary>
    interface IFollowingDAO : IDAO<following>
    {
        IList<following> GetTheFollowers(pigeonsEntities1 context, object groupID);
        IEnumerable<following> GetByID(pigeonsEntities1 context, object personID, object groupID);
    }
}
