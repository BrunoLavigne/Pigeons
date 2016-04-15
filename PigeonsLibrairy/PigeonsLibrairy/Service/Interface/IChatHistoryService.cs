using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigeonsLibrairy.Service.Interface
{
    /// <summary>
    /// Interface pour les service pour la table <see cref="chathistory"/>
    /// </summary>
    public interface IChatHistoryService : IService<chathistory>
    {
        void InsertChatMessage(chathistory chatMessage);

        IEnumerable<chathistory> GetAllMessagesFromGroup(object groupID);
    }
}