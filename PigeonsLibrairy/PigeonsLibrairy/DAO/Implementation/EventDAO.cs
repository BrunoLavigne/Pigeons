using PigeonsLibrairy.DAO.Interface;
using PigeonsLibrairy.Exceptions;
using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq.Expressions;

namespace PigeonsLibrairy.DAO.Implementation
{
    /// <summary>
    /// DAO de la table <see cref="@event"/>
    /// </summary>
    class EventDAO : DAO<@event>, IEventDAO
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        public EventDAO() : base() { }

        /// <summary>
        /// Get an event by searching a value in a column
        /// </summary>
        /// <param name="context">The connection</param>
        /// <param name="columnName">The name of the column in the table</param>
        /// <param name="value">The value to search</param>
        /// <returns>A list of events that match the query</returns>
        public new IEnumerable<@event> GetBy(pigeonsEntities1 context, string columnName, object value)
        {
            Expression<Func<@event, bool>> filter = null;

            try
            {
                switch (columnName.ToLower())
                {
                    case @event.COLUMN_GROUP_ID:
                        filter = (e => e.Group_ID == (int)value);
                        break;
                    case @event.COLUMN_DESCRIPTION:
                        filter = (e => e.Description.ToLower().Contains(value.ToString().ToLower()));
                        break;
                    case @event.COLUMN_EVENTSTART:
                        filter = (e => e.Event_Start.Date == ((DateTime)value).Date);
                        break;
                    case @event.COLUMN_EVENTEND:
                        filter = (e => e.Event_End.Value.Date == ((DateTime)value).Date);
                        break;
                    case @event.COLUMN_IS_COMPLETED:
                        filter = (e => Convert.ToBoolean(e.Is_Completed) == (bool)value);
                        break;
                    default:
                        break;
                }
                return Get(context, filter);
            }
            catch (Exception ex) when (ex is EntityException || ex is DAOException)
            {
                throw new DAOException(ex.Message);
            }
        }
    }
}
