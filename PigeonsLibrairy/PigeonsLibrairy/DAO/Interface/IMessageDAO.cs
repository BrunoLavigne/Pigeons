using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigeonsLibrairy.DAO.Interface
{
    /// <summary>
    /// Interface magnifique
    /// </summary>
    interface IMessageDAO
    {
        message GetPersonDetailByMessageId(object id);
        IEnumerable<message> GetGroupMessages(pigeonsEntities1 context, object groupID);
    }
}
