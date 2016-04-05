using PigeonsLibrairy.DAO.Implementation;
using PigeonsLibrairy.DAO.Interface;
using PigeonsLibrairy.Exceptions;
using PigeonsLibrairy.Model;
using PigeonsLibrairy.Service.Interface;
using System.Collections.Generic;

namespace PigeonsLibrairy.Service.Implementation
{
    /// <summary>
    /// Service de la table <see cref="@event"/>
    /// </summary>
    public class EventService : Service<@event>, IEventService
    {
        private IEventDAO eventDAO { get; set; }

        /// <summary>
        /// Constructeur
        /// </summary>
        public EventService() : base()
        {
            eventDAO = new EventDAO();
        }

        /// <summary>
        /// Appel le DAO pour trouver un event dans la base de donnée
        /// </summary>
        /// <param name="columnName">Le nom de la colonne pour la recherche</param>
        /// <param name="value">La valeur à rechercher</param>
        /// <returns>Une liste de event qui correspondent à la recherche</returns>
        public new IEnumerable<@event> GetBy(string columnName, object value)
        {
            if (columnName == null || columnName == "")
            {
                throw new ServiceException("La valeur de la colonne ne doit pas être null");
            }

            if (value == null)
            {
                throw new ServiceException("La valeur recherchée ne peut pas être null");
            }

            try
            {
                using (var context = new pigeonsEntities1())
                {
                    return eventDAO.GetBy(context, columnName, value);
                }
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }
    }
}
