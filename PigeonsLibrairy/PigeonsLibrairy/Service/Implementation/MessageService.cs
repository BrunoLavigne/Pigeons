using PigeonsLibrairy.DAO.Implementation;
using PigeonsLibrairy.Model;
using PigeonsLibrairy.Service.Interface;

namespace PigeonsLibrairy.Service.Implementation
{
    public class MessageService : Service<message>, IMessageService
    {
        private MessageDAO messageDAO { get; set;  }

        public MessageService(pigeonsEntities1 context) : base(context)
        {
            messageDAO = new MessageDAO(context);
        }
    }
}
