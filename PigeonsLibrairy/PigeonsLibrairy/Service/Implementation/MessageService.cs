using PigeonsLibrairy.DAO.Implementation;
using PigeonsLibrairy.Exceptions;
using PigeonsLibrairy.Model;
using PigeonsLibrairy.Service.Interface;
using System.Collections.Generic;
using System;
using PigeonsLibrairy.DAO.Interface;

namespace PigeonsLibrairy.Service.Implementation
{
    /// <summary>
    /// Service pour la table Message(<see cref="message"/>)
    /// </summary>
    public class MessageService : Service<message>, IMessageService
    {
        private IMessageDAO messageDAO { get; set;  }
        private IGroupDAO groupDAO { get; set; }
        private IPersonDAO personDAO { get; set; }

        /// <summary>
        /// Constructeur
        /// </summary>
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
        public bool CreateNewMessage(message messageToCreate)
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

            try
            {
                using (var context = new pigeonsEntities1())
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
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }

        /// <summary>
        /// Recherche des messages associés à un groupe
        /// </summary>
        /// <param name="groupID">Le ID du groupe pour lequel nous cherchons les messages</param>
        /// <returns>Une liste de tout les messages du groupe. Une liste vide sinon.</returns>
        public IEnumerable<message> GetGroupMessages(object groupID)
        {
            if(groupID == null)
            {
                throw new ServiceException("The group ID is null");
            }

            try
            {
                using (var context = new pigeonsEntities1())
                {
                    return messageDAO.GetGroupMessages(context, groupID);
                }
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }

        /// <summary>
        /// Appel le DAO pour trouver un message dans la base de donnée
        /// </summary>
        /// <param name="columnName">Le nom de la colonne pour la recherche</param>
        /// <param name="value">La valeur recherché dans la colonne</param>
        /// <returns>Une liste de message correspondant à la recherche. Une liste vide sinon.</returns>
        public new IEnumerable<message> GetBy(string columnName, object value)
        {
            if (columnName == null || columnName == "")
            {
                throw new ServiceException("La valeur de la colonne ne doit pas être null");
            }

            if (value == null || (string)value == "")
            {
                throw new ServiceException("La valeur recherchée ne peut pas être null");
            }

            try
            {
                using (var context = new pigeonsEntities1())
                {
                    return messageDAO.GetBy(context, columnName, value);
                }
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }
    }
}
