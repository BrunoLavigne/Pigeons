using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PigeonsLibrairy.Model;
using PigeonsLibrairy.DAO.Implementation;
using System.Collections;
using System.Collections.Generic;

namespace PigeonsTesting
{
    [TestClass]
    public class EventDAOTesting
    {
        private int EVENT_ID { get; set; }

        #region CRUDEvent
        [TestMethod]
        public void InsertEventTest()
        {
            using (var context = new pigeonsEntities1())
            {
                @event eventToTest = new @event();

                eventToTest.Description = "travaux";
                eventToTest.Group_ID = 15;
                eventToTest.Event_Start = DateTime.Now;
                eventToTest.Event_End = DateTime.Now;
                eventToTest.Is_Completed = false;

                EventDAO eventDAO = new EventDAO();

                eventDAO.Insert(context, eventToTest);
                context.SaveChanges();
                EVENT_ID = eventToTest.ID;

                Assert.AreEqual(eventToTest.ID, EVENT_ID);
            }
        }

        [TestMethod]
        public void GetByIdEventTest()
        {
            using (var context = new pigeonsEntities1())
            {
                EventDAO eventDAO = new EventDAO();

                @event eventCheck = eventDAO.GetByID(context, EVENT_ID);

                Assert.AreEqual(eventCheck.ID, EVENT_ID);
            }
        }

        [TestMethod]
        public void UpdateEventTest()
        {
            using (var context = new pigeonsEntities1())
            {
                EventDAO eventDAO = new EventDAO();
                @event eventToTest = eventDAO.GetByID(context, EVENT_ID);

                string modif = "NiceCool";
                eventToTest.Description = modif;

                eventDAO.Update(context, eventToTest);
                context.SaveChanges();

                Assert.AreEqual(eventToTest.Description, modif);
            }
        }

        [TestMethod]
        public void DeleteEventTest()
        {
            using (var context = new pigeonsEntities1())
            {
                EventDAO eventDAO = new EventDAO();

                eventDAO.Delete(context, EVENT_ID);
                context.SaveChanges();

                Assert.AreEqual(null, EVENT_ID);
            }
        }
        #endregion CRUDEvent

        [TestMethod]
        public void GetGroupEventTest()
        {
            using(var context = new pigeonsEntities1())
            {
                EventDAO eventDAO = new EventDAO();
                @event eventCheck = eventDAO.GetByID(context, EVENT_ID);
                int groupId = eventCheck.Group_ID;

                IEnumerable<@event> groupEventsEnum = eventDAO.GetGroupEvent(context, groupId);

                Assert.AreEqual(eventCheck.Group_ID,groupId);
            }
        }

        [TestMethod]
        public void GetGroupEventByMonthTest()
        {
            using (var context = new pigeonsEntities1())
            {
                EventDAO eventDAO = new EventDAO();
                @event eventCheck = eventDAO.GetByID(context, EVENT_ID);
                int groupId = eventCheck.Group_ID;
                DateTime dateChecker = eventCheck.Event_Start;

                IEnumerable<@event> groupEventsByMonthEnum = eventDAO.GetGroupEventByMonth(context, groupId, dateChecker.Month);

                Assert.AreEqual(eventCheck.Group_ID, groupId);
            }
        }
    }
}
