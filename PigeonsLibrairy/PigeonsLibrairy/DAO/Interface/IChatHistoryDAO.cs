using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigeonsLibrairy.DAO.Interface
{
    /// <summary>
    /// Interface pour la classe <see cref="chathistory"/>
    /// </summary>
    internal interface IChatHistoryDAO : IDAO<chathistory>
    {
        IEnumerable<chathistory> GetAllMessagesByGroup(pigeonsEntities1 context, object groupID);
    }
}