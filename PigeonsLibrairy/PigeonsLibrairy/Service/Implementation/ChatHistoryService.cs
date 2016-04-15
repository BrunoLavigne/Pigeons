using PigeonsLibrairy.DAO.Implementation;
using PigeonsLibrairy.DAO.Interface;
using PigeonsLibrairy.Exceptions;
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
        private IChatHistoryDAO chatHistoryDAO { get; set; }
        private IGroupDAO groupDAO { get; set; }
        private IPersonDAO personDAO { get; set; }
        private IFollowingDAO followingDAO { get; set; }

        /// <summary>
        /// Constructeur
        /// </summary>
        public ChatHistoryService()
        {
            chatHistoryDAO = new ChatHistoryDAO();
            groupDAO = new GroupDAO();
            personDAO = new PersonDAO();
            followingDAO = new FollowingDAO();
        }

        /// <summary>
        /// Appel du DAO pour insérer un Chat Message dans la base de donnée
        /// </summary>
        /// <param name="chatMessage">Le message qui doit être inséré</param>
        public void InsertChatMessage(chathistory chatMessage)
        {
            if (chatMessage == null)
            {
                throw new ServiceException("Le chatMessage est null");
            }

            if (chatMessage.Group_ID == 0)
            {
                throw new ServiceException("Le message ne contient pas de ID pour le Group");
            }

            if (chatMessage.Author_ID == 0)
            {
                throw new ServiceException("Le message ne contient pas de ID pour l'auteur");
            }

            if (chatMessage.Message.Equals(""))
            {
                throw new ServiceException("Impossible d'insérer un message vide");
            }

            try
            {
                using (var context = new pigeonsEntities1())
                {
                    group groupValidation = groupDAO.GetByID(context, chatMessage.Group_ID);

                    if (groupValidation == null)
                    {
                        throw new ServiceException(string.Format("Le groupe no.{0} n'existe pas. Impossible d'insérer le message", chatMessage.Group_ID));
                    }

                    if (!groupValidation.Is_active)
                    {
                        throw new ServiceException(string.Format("Le groupe no.{0} n'est pas actif en ce moment. Impossible d'insérer le message", chatMessage.Group_ID));
                    }

                    person personValidation = personDAO.GetByID(context, chatMessage.Author_ID);

                    if (personValidation == null)
                    {
                        throw new ServiceException(string.Format("La person no.{0} n'existe pas. Impossible d'insérer le message", chatMessage.Group_ID));
                    }

                    following followingValidation = followingDAO.GetByID(context, chatMessage.Author_ID, chatMessage.Group_ID);

                    if (followingValidation == null)
                    {
                        throw new ServiceException(string.Format("La person no.{0} ne suis pas le groupe {1}. Impossible d'insérer le message", chatMessage.Author_ID, chatMessage.Group_ID));
                    }

                    if (!followingValidation.Is_active)
                    {
                        throw new ServiceException(string.Format("La person no.{0} ne suis plus ce groupe ({1}). Impossible d'insérer le message", chatMessage.Author_ID, chatMessage.Group_ID));
                    }

                    chatMessage.CreationDate = DateTime.Now;
                    chatHistoryDAO.Insert(context, chatMessage);
                    context.SaveChanges();
                }
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }

        /// <summary>
        /// Appel du DAO pour avoir la liste de tout les message chat d'un Group
        /// </summary>
        /// <param name="groupID">Le ID du Group pour lequel les messages sont voulues</param>
        /// <returns>Une liste de chatMessage ou bien un liste vide</returns>
        public IEnumerable<chathistory> GetAllMessagesFromGroup(object groupID)
        {
            if (groupID == null)
            {
                throw new ServiceException("Le ID du groupe est null");
            }

            try
            {
                using (var context = new pigeonsEntities1())
                {
                    group groupValidation = groupDAO.GetByID(context, groupID);

                    if (groupValidation == null)
                    {
                        throw new ServiceException(string.Format("Le groupe no.{0} n'existe pas. Impossible de récupérer les messages", groupID));
                    }

                    if (!groupValidation.Is_active)
                    {
                        throw new ServiceException(string.Format("Le groupe no.{0} n'est pas actif en ce moment. Impossible de récupérer les messages", groupID));
                    }

                    return chatHistoryDAO.GetAllMessagesByGroup(context, groupID);
                }
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }
    }
}