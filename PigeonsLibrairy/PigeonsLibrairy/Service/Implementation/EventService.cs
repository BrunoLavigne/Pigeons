using PigeonsLibrairy.DAO.Implementation;
using PigeonsLibrairy.DAO.Interface;
using PigeonsLibrairy.Exceptions;
using PigeonsLibrairy.Model;
using PigeonsLibrairy.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PigeonsLibrairy.Service.Implementation
{
    /// <summary>
    /// Service de la table <see cref="@event"/>
    /// </summary>
    public class EventService : Service<@event>, IEventService
    {
        private IEventDAO eventDAO { get; set; }
        private IGroupDAO groupDAO { get; set; }

        /// <summary>
        /// Constructeur
        /// </summary>
        public EventService() : base()
        {
            eventDAO = new EventDAO();
            groupDAO = new GroupDAO();
        }

        /// <summary>
        /// Appel du DAO afin de créer un nouvel Event
        /// </summary>
        /// <param name="newEvent">Le Event à insérer dans la base de donnée</param>
        /// <returns>L'Event si créer. Null sinon</returns>
        public @event CreateNewEvent(@event newEvent)
        {
            if(newEvent == null)
            {
                throw new ServiceException("Le nouvel évènement est null");
            }

            if(newEvent.Group_ID == 0)
            {
                throw new ServiceException("Le ID du groupe pour créer l'évènement est null");
            }

            try
            {
                using(var context = new pigeonsEntities1())
                {
                    // Validation du groupe
                    group groupValidation = groupDAO.GetByID(context, newEvent.Group_ID);

                    if(groupValidation == null)
                    {
                        throw new ServiceException(string.Format("Le groupe no.{0} n'existe pas", newEvent.Group_ID));
                    }

                    if (!groupValidation.Is_active)
                    {
                        throw new ServiceException(string.Format("Le groupe no.{0} n'est pas actif. Impossible de créer un évènement", newEvent.Group_ID));
                    }

                    // Validation des dates
                    if (newEvent.Event_End != null && newEvent.Event_Start!= null)
                    {
                        if (newEvent.Event_End < newEvent.Event_Start)
                        {
                            throw new ServiceException(string.Format("La date de fin : {0} ne peut pas précéder la date de départ : {1}", newEvent.Event_End, newEvent.Event_Start));
                        }
                    }

                    if (newEvent.Event_End == default(DateTime))
                    {
                        newEvent.Event_End = null;
                    }

                    // Insertion de l'event
                    newEvent.Is_Completed = false;
                    eventDAO.Insert(context, newEvent);
                    context.SaveChanges();
                    return newEvent;
                }
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }

        /// <summary>
        /// Appel le DAO pour trouver les Events d'un groupe qui ne sont pas complétés
        /// </summary>
        /// <param name="groupID">Le ID du groupe</param>
        /// <returns>Une liste de Events ou une liste vide</returns>
        public IEnumerable<@event> GetGroupEvent(object groupID)
        {
            if(groupID == null)
            {
                throw new ServiceException("Le ID du group est null");
            }

            try
            {
                using(var context = new pigeonsEntities1())
                {
                    // Validation du groupe
                    group groupValidation = groupDAO.GetByID(context, groupID);

                    if (groupValidation == null)
                    {
                        throw new ServiceException(string.Format("Le groupe no.{0} n'existe pas", groupID));
                    }

                    if (!groupValidation.Is_active)
                    {
                        throw new ServiceException(string.Format("Le groupe no.{0} n'est pas actif.", groupID));
                    }

                    // Recherche des events
                    return eventDAO.GetGroupEvent(context, groupID);
                }
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }

        /// <summary>
        /// Retourne une liste des Évènement 
        /// </summary>
        /// <param name="numberOfEvents"></param>
        /// <returns></returns>
        public IEnumerable<@event> GetUpComingEvents(object groupID, object numberOfEvents)
        {
            if(groupID == null)
            {
                throw new ServiceException("Le ID du groupe de peu pas être null");
            }

            try
            {
                using(var context = new pigeonsEntities1())
                {
                    IEnumerable<@event> upComingEvents = eventDAO.GetUpComingEvents(context, groupID, numberOfEvents);

                    if (upComingEvents == null)
                    {
                        throw new ServiceException(string.Format("Le groupe ID : {0} n'a pas retouré d'événement", groupID));
                    }

                    return upComingEvents;
                }
            }
            catch(DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
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
