using PigeonsLibrairy.Model;
using PigeonsLibrairy.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigeonsLibrairy.Service.Implementation
{
    public class MessageService : Service<message>, IMessageService
    {
        public MessageService(pigeonsEntities1 context) : base(context) { }
    }
}
