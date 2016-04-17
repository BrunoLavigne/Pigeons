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
    /// DAO de la table <see cref="@event"/>
    /// </summary>
    public class EventDAO : DAO<@event>, IEventDAO
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        public EventDAO() : base() { }

        /// <summary>
        /// Recherche de tout les Events non complété pour un Group
        /// </summary>
        /// <param name="context">La connection</param>
        /// <param name="groupID">Le ID du groupe</param>
        /// <returns>Une liste de Events ou une liste vide</returns>
        public IEnumerable<@event> GetGroupEvent(pigeonsEntities1 context, object groupID)
        {
            try
            {
                Expression<Func<@event, bool>> filter = (e => e.Group_ID == (int)groupID && !e.Is_Completed);
                return Get(context, filter).OrderBy(e => e.Event_Start);
            }
            catch (Exception ex) when (ex is EntityException || ex is DAOException)
            {
                throw new DAOException("Erreur dans le EventDAO GetGroupEvent : " + ex.Message);
            }
        }

        /// <summary>
        /// Retourne une liste d'Events non complété d'un Group par mois
        /// </summary>
        /// <param name="context">La connection</param>
        /// <param name="groupID">Le ID du groupe</param>
        /// <param name="monthID">Le mois à afficher</param>
        /// <returns></returns>
        public IEnumerable<@event> GetGroupEventByMonth(pigeonsEntities1 context, object groupID, object date)
        {
            DateTime dateChecker = (DateTime)date;

            try
            {
                Expression<Func<@event, bool>> filter = (e => e.Group_ID == (int)groupID
                                                            && !e.Is_Completed
                                                            && (e.Event_Start.Month == dateChecker.Month || e.Event_End.Value.Month == dateChecker.Month)
                                                            && (e.Event_Start.Year == dateChecker.Year || e.Event_End.Value.Year == dateChecker.Year)
                                                            );
                return Get(context, filter).OrderBy(e => e.Event_Start);
            }
            catch (Exception ex) when (ex is EntityException || ex is DAOException)
            {
                throw new DAOException("Erreur dans le EventDAO GetGroupEventByMonth : " + ex.Message);
            }
        }

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