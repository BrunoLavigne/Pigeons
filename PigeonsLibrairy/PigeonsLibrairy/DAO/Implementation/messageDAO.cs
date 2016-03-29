using PigeonsLibrairy.DAO.Interface;
using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PigeonsLibrairy.DAO.Implementation
{
    public class MessageDAO : DAO<message>, IMessageDAO
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

        public IEnumerable<message> GetGroupMessages(pigeonsEntities1 context, object groupID)
        {
            Expression<Func<message, bool>> filter = (m => m.Group_Id == (int)groupID);
            string includeProperties = "person";
            return Get(context, filter, null, includeProperties).OrderByDescending(m => m.Date_created);
        }

        public new IEnumerable<message> GetBy(pigeonsEntities1 context, string columnName, object value)
        {
            Expression<Func<message, bool>> filter = null;            

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

    }
}
