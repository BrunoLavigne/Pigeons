using PigeonsLibrairy.DAO.Interface;
using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigeonsLibrairy.DAO.Implementation
{
    public class MessageDAO : DAO<message>, IMessageDAO
    {
        public MessageDAO(pigeonsEntities1 context) : base(context)
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
            var message = this.dbSet.Find(id);
            this.context.Entry(message).Reference("person").Load();
            return message;
        }

        public new IEnumerable<message> GetBy(string columnName, object value)
        {
            IEnumerable<message> messageList = new List<message>();

            switch (columnName.ToLower())
            {
                case "author_id":
                    messageList = Get(m => m.Author_Id == (int)value);
                    break;
                case "group_id":
                    messageList = Get(m => m.Group_Id == (int)value);
                    break;
                case "content":
                    messageList = Get(m => m.Content.ToLower().Contains(((string)value).ToLower()));
                    break;
                case "date_created":
                    //messageList = Get(m => DbFunctions.TruncateTime(m.Date_created).Equals( ((DateTime)value).Date) );                    
                    break;
                default:
                    break;
            }
            return messageList;
        }

    }
}
