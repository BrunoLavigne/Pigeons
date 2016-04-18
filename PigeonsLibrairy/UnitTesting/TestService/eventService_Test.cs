using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PigeonsLibrairy.Service.Implementation;
using PigeonsLibrairy.Model;
using PigeonsLibrairy.Exceptions;

namespace UnitTesting.TestService
{
    // <summary>
    /// Test des opération CRUD de la classe <see cref="EventService"/> pour la table <see cref="@event"/>
    /// </summary>
    [TestClass]
    public class eventService_Test
    {
        /// <summary>
        /// Le service à tester
        /// </summary>
        private EventService eventService { get; set; }

        /// <summary>
        /// Création du service pour les tests
        /// </summary>
        [TestInitialize()]
        public void MyTestInitialize()
        {
            eventService = new EventService();
        }

        /// <summary>
        /// Remise des variables à null
        /// </summary>
        [TestCleanup()]
        public void MyTestCleanup()
        {
            eventService = null;
        }

        /// <summary>
        /// Test de la méthode <see cref="EventService.CreateNewEvent(@event)"/>
        /// Le event est null. Une ServiceException devrait être lancée
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ServiceException), "Le event est null devrait lancer une ServiceException")]
        public void CreateNewEventTest_nullEvent()
        {
            eventService.CreateNewEvent(null);
        }

        /// <summary>
        /// Test de la méthode <see cref="EventService.CreateNewEvent(@event)"/>
        /// Le groupe est null. Une ServiceException devrait être lancée
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ServiceException), "Le groupe est null devrait lancer une ServiceException")]
        public void CreateNewEventTest_zeroGroup()
        {
            @event newEvent = new @event();
            newEvent.Group_ID = 0;
            eventService.CreateNewEvent(newEvent);
        }
    }
}
