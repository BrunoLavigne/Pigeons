using PigeonsLibrairy.DAO.Implementation;
using PigeonsLibrairy.Exceptions;
using PigeonsLibrairy.Model;
using PigeonsLibrairy.Service.Interface;
using System.Collections.Generic;
using System;

namespace PigeonsLibrairy.Service.Implementation
{
    public class MessageService : Service<message>, IMessageService
    {
        private MessageDAO messageDAO { get; set;  }
        private GroupDAO groupDAO { get; set; }
        private PersonDAO personDAO { get; set; }

        public MessageService(pigeonsEntities1 context) : base(context)
        {
            messageDAO = new MessageDAO(context);
            groupDAO = new GroupDAO(context);
            personDAO = new PersonDAO(context);
        }

        /// <summary>
        /// Creating a new message in the active group
        /// </summary>
        /// <param name="messageToCreate">The message to be added</param>
        /// <returns>True if the message is created, false otherwise</returns>
        public bool createNewMessage(message messageToCreate)
        {
            bool messageAdded = false;

            if (messageToCreate == null)
            {
                throw new ServiceException("The message to create is null");
            }

            if(messageToCreate.Content == "")
            {
                throw new ServiceException("There is no content to the message");
            }

            group activeGroup = groupDAO.GetByID(messageToCreate.Group_Id);

            if(activeGroup == null)
            {
                throw new ServiceException("The group doesnt exist");
            }

            if (!activeGroup.Is_active)
            {
                throw new ServiceException("The group is not active : Cannot create a message");
            }

            person activePerson = personDAO.GetByID(messageToCreate.Author_Id);

            if (activePerson == null)
            {
                throw new ServiceException("The person doesnt exist");
            }

            messageToCreate.Date_created = DateTime.Now;
            Insert(messageToCreate);
            context.SaveChanges();
            messageAdded = true;

            return messageAdded;
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
