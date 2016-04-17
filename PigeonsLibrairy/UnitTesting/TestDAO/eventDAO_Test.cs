using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PigeonsLibrairy.Model;
using PigeonsLibrairy.DAO.Implementation;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PigeonsTesting
{
    /// <summary>
    /// Test des opération CRUD de la classe <see cref="EventDAO"/> pour la table <see cref="@event"/>
    /// </summary>
    [TestClass]
    public class eventDAO_Test
    {
        private EventDAO eventDAO { get; set; }
        private @event eventTest { get; set; }

        private const string EVENT_DECRIPTION = "It's BUM BUM on code";
        private const int EVENT_GROUP_ID = 15;
        private DateTime EVENT_START = DateTime.Now;
        private DateTime EVENT_END = DateTime.Parse("2016-04-19");
        private const bool EVENT_IS_COMPLETED = false;

        /// <summary>
        /// Création du DAO et d'un event pour les tests
        /// </summary>
        [TestInitialize()]
        public void MyTestInitialize()
        {
            eventDAO = new EventDAO();

            eventTest = new @event();

            eventTest.Description = EVENT_DECRIPTION;
            eventTest.Group_ID = EVENT_GROUP_ID;
            eventTest.Event_Start = EVENT_START;
            eventTest.Event_End = EVENT_END;
            eventTest.Is_Completed = EVENT_IS_COMPLETED;
        }

        /// <summary>
        /// Remet le DAO et le event à null
        /// </summary>
        [TestCleanup()]
        public void MyTestCleanup()
        {
            eventDAO = null;
            eventTest = null;
        }

        /// <summary>
        /// Test pour la méthode Insert de la classe <see cref="PigeonsLibrairy.DAO.Implementation.EventDAO"/>
        /// Insertion d'un Event et validation de ses propriétés
        /// </summary>
        [TestMethod]
        public void TestInsertEvent()
        {
            using (var context = new pigeonsEntities1())
            {
                eventDAO.Insert(context, eventTest);
                context.SaveChanges();
                int insertedEventID = eventTest.ID;

                @event actualEvent = eventDAO.GetByID(context, insertedEventID);

                Assert.AreEqual(EVENT_DECRIPTION, actualEvent.Description);
                Assert.AreEqual(EVENT_GROUP_ID, actualEvent.Group_ID);
                Assert.AreEqual(EVENT_START, actualEvent.Event_Start);
                Assert.AreEqual(EVENT_END, actualEvent.Event_End);
                Assert.AreEqual(EVENT_IS_COMPLETED, actualEvent.Is_Completed);

                eventDAO.Delete(context, eventTest);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Test pour la méthode Delete de la classe <see cref="PigeonsLibrairy.DAO.Implementation.EventDAO"/>
        /// Insertion d'un Event et validation de ses propriétés
        /// </summary>
        [TestMethod]
        public void TestDeleteEvent()
        {
            using (var context = new pigeonsEntities1())
            {
                eventDAO.Insert(context, eventTest);
                context.SaveChanges();
                int insertedEventID = eventTest.ID;

                @event actualEvent = eventDAO.GetByID(context, insertedEventID);
                Assert.AreEqual(eventTest, actualEvent);

                eventDAO.Delete(context, eventTest);
                context.SaveChanges();

                @event DeletedEvent = eventDAO.GetByID(context, eventTest);
                Assert.AreEqual(null, DeletedEvent);
            }
        }

        /// <summary>
        /// Test pour la méthode Update de la classes <see cref="PigeonsLibrairy.DAO.Implementation.EventDAO"/>
        /// Insertion d'un Event et validation de ses propriétés
        /// </summary>
        [TestMethod]
        public void TestUpdateEvent()
        {
            const string expected_UpdatedDescription = "YOUUPIIIII";

            using (var context = new pigeonsEntities1())
            {
                eventDAO.Insert(context, eventTest);
                context.SaveChanges();
                int insertedEventID = eventTest.ID;

                @event actualEvent = eventDAO.GetByID(context, insertedEventID);
                actualEvent.Description = expected_UpdatedDescription;

                eventDAO.Update(context, actualEvent);
                context.SaveChanges();

                @event updatedEvent = eventDAO.GetByID(context, insertedEventID);
                Assert.AreEqual(expected_UpdatedDescription, updatedEvent.Description);

                eventDAO.Delete(context, eventTest);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Test pour la méthode GetBy column name de la classe <see cref="PigeonsLibrairy.DAO.Implementation.EventDAO"/>
        /// Insertion d'un Event et validation de ses propriétés
        /// </summary>
        [TestMethod]
        public void TestGetByEvent()
        {
            using (var context = new pigeonsEntities1())
            {
                eventDAO.Insert(context, eventTest);
                context.SaveChanges();
                int insertedEventID = eventTest.ID;

                List<@event> eventByDescription = eventDAO.GetBy(context, @event.COLUMN_DESCRIPTION, EVENT_DECRIPTION).ToList();
                Assert.AreEqual(EVENT_DECRIPTION, eventByDescription[0].Description);

                List<@event> eventByGroupId = eventDAO.GetBy(context, @event.COLUMN_GROUP_ID, EVENT_GROUP_ID).ToList();
                Assert.AreEqual(EVENT_GROUP_ID, eventByGroupId[0].Group_ID);

                eventDAO.Delete(context, eventTest);
                context.SaveChanges();
            }
        }
    }
}
