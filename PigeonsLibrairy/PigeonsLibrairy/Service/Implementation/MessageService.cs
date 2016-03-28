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

        public MessageService() : base()
        {
            messageDAO = new MessageDAO();
            groupDAO = new GroupDAO();
            personDAO = new PersonDAO();
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

            using(var context = new pigeonsEntities1())
            {
                group activeGroup = groupDAO.GetByID(context, messageToCreate.Group_Id);

                if (activeGroup == null)
                {
                    throw new ServiceException("The group doesnt exist");
                }

                if (!activeGroup.Is_active)
                {
                    throw new ServiceException("The group is not active : Cannot create a message");
                }

                person activePerson = personDAO.GetByID(context, messageToCreate.Author_Id);

                if (activePerson == null)
                {
                    throw new ServiceException("The person doesnt exist");
                }

                messageToCreate.Date_created = DateTime.Now;
                messageDAO.Insert(context, messageToCreate);
                context.SaveChanges();
                messageAdded = true;
            }

            return messageAdded;
        }

        public new IEnumerable<message> GetBy(string columnName, object value)
        {
            IEnumerable<message> messageList = new List<message>();

            if (columnName != "" && value != null)
            {
                using(var context = new pigeonsEntities1())
                {
                    messageList = messageDAO.GetBy(context, columnName, value);
                    return messageList;
                }
            }
            else
            {
                throw new ServiceException("You must provid the column name and a value");
            }
        }
    }
}
