using PigeonsLibrairy.DAO.Interface;
using PigeonsLibrairy.Exceptions;
using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Linq.Expressions;

namespace PigeonsLibrairy.DAO.Implementation
{
    /// <summary>
    /// DAO de la table <see cref="message"/>
    /// </summary>
    class MessageDAO : DAO<message>, IMessageDAO
    {
        public MessageDAO() : base()
        {            
        }

        /// <summary>
        /// Testing with lazyloading set to False
        /// This method allow to load the person associated with the message.
        /// </summary>
        /// <param name="id">The id of the message we are looking for</param>
        /// <returns></returns>
        public message GetPersonDetailByMessageId(object id)
        {
            //var message = this.dbSet.Find(id);
            //this.context.Entry(message).Reference("person").Load();
            //return message;
            return null;
        }

        /// <summary>
        /// Get the messages from a group
        /// </summary>
        /// <param name="context">The connection</param>
        /// <param name="groupID">The ID of the group we want the messages</param>
        /// <returns>A list with the messages from the group. An empty list of there is no message</returns>
        public IEnumerable<message> GetGroupMessages(pigeonsEntities1 context, object groupID)
        {
            try
            {
                Expression<Func<message, bool>> filter = (m => m.Group_Id == (int)groupID);
                string includeProperties = "person";
                return Get(context, filter, null, includeProperties).OrderByDescending(m => m.Date_created);
            }
            catch (Exception ex) when (ex is EntityException || ex is DAOException)
            {
                throw new DAOException("Erreur dans le MessageDAO GetGroupMessages : " + ex.Message);
            }
        }

        /// <summary>
        /// Get a message by searching a value in a column
        /// </summary>
        /// <param name="context">The connection</param>
        /// <param name="columnName">The name of the column in the table</param>
        /// <param name="value">The value to search</param>
        /// <returns>A list of message that match the query</returns>
        public new IEnumerable<message> GetBy(pigeonsEntities1 context, string columnName, object value)
        {
            Expression<Func<message, bool>> filter = null;

            try
            {
                switch (columnName.ToLower())
                {
                    case message.COLUMN_AUTHOR_ID:
                        filter = (m => m.Author_Id == (int)value);
                        break;
                    case message.COLUMN_GROUP_ID:
                        filter = (m => m.Group_Id == (int)value);
                        break;
                    case message.COLUMN_CONTENT:
                        filter = (m => m.Content.ToLower().Contains(((string)value).ToLower()));
                        break;
                    case message.COLUMN_DATE_CREATED:
                        //messageList = Get(m => DbFunctions.TruncateTime(m.Date_created).Equals( ((DateTime)value).Date) );                    
                        break;
                    default:
                        break;
                }
                return Get(context, filter);
            }
            catch (Exception ex) when (ex is EntityException || ex is DAOException)
            {
                throw new DAOException("Erreur dans le MessageDAO GetBy : " + ex.Message);
            }
        }
    }
}
