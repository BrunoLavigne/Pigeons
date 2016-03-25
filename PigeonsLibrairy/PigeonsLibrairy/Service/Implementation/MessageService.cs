using PigeonsLibrairy.DAO.Implementation;
using PigeonsLibrairy.Exceptions;
using PigeonsLibrairy.Model;
using PigeonsLibrairy.Service.Interface;
using System.Collections.Generic;

namespace PigeonsLibrairy.Service.Implementation
{
    public class MessageService : Service<message>, IMessageService
    {
        private MessageDAO messageDAO { get; set;  }

        public MessageService(pigeonsEntities1 context) : base(context)
        {
            messageDAO = new MessageDAO(context);
        }

        public new IEnumerable<message> GetBy(string columnName, object value)
        {
            IEnumerable<message> messageList = new List<message>();

            if (columnName != "" && value != null)
            {
                messageList = messageDAO.GetBy(columnName, value);
                return messageList;
            }
            else
            {
                throw new ServiceException("You must provid the column name and a value");
            }
        }
    }
}
