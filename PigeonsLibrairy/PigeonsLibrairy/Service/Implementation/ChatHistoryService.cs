using PigeonsLibrairy.Model;
using PigeonsLibrairy.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigeonsLibrairy.Service.Implementation
{
    /// <summary>
    /// Service pour la table <see cref="chathistory"/>
    /// </summary>
    public class ChatHistoryService : Service<chathistory>, IChatHistoryService
    {
    }
}
