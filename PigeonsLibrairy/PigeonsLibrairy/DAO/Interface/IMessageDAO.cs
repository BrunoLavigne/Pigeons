using PigeonsLibrairy.Model;
using System.Collections.Generic;

namespace PigeonsLibrairy.DAO.Interface
{
    /// <summary>
    /// Interface de la classe <see cref="Implementation.MessageDAO"/>
    /// </summary>
    interface IMessageDAO : IDAO<message>
    {
        message GetPersonDetailByMessageId(object id);
        IEnumerable<message> GetGroupMessages(pigeonsEntities1 context, object groupID);
    }
}
