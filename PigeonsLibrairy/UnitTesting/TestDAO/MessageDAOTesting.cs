using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PigeonsLibrairy.Model;
using PigeonsLibrairy.DAO.Implementation;
using System.Collections;
using System.Collections.Generic;

namespace UnitTesting
{
    [TestClass]
    public class MessageDAOTesting
    {
        private int MSG_ID { get; set; }
        private int GROUP_ID { get; set; }

        #region CRUDMessage
        [TestMethod]
        public void InsertMessagetTest()
        {
            using (var context = new pigeonsEntities1())
            {
                message msgToTest = new message();

                msgToTest.Author_Id = 16;
                msgToTest.Group_Id = 16;
                msgToTest.Content = "Yepyep";
                msgToTest.Date_created = DateTime.Now;

                MessageDAO msgDAO = new MessageDAO();

                msgDAO.Insert(context, msgToTest);
                context.SaveChanges();
                MSG_ID = msgToTest.Id;

                Assert.AreEqual(msgToTest.Id, MSG_ID);
            }
        }

        [TestMethod]
        public void GetByIdMessageTest()
        {
            using (var context = new pigeonsEntities1())
            {
                MessageDAO msgDAO = new MessageDAO();

                message msgCheck = msgDAO.GetByID(context, MSG_ID);

                Assert.AreEqual(msgCheck.Id, MSG_ID);
            }
        }

        [TestMethod]
        public void UpdateMessageTest()
        {
            using (var context = new pigeonsEntities1())
            {
                MessageDAO msgDAO = new MessageDAO();
                message msgToTest = msgDAO.GetByID(context, MSG_ID);

                string modif = "CONTENU";
                msgToTest.Content = modif;

                msgDAO.Update(context, msgToTest);
                context.SaveChanges();

                Assert.AreEqual(msgToTest.Content, modif);
            }
        }

        [TestMethod]
        public void DeleteMessageTest()
        {
            using (var context = new pigeonsEntities1())
            {
                MessageDAO msgDAO = new MessageDAO();

                msgDAO.Delete(context, MSG_ID);
                context.SaveChanges();

                Assert.AreEqual(null, MSG_ID);
            }
        }
        #endregion CRUDMessage


        [TestMethod]
        public void GetGroupMessagesTest()
        {
            using(var context = new pigeonsEntities1())
            {
                MessageDAO msgDAO = new MessageDAO();
                message msgCheck = msgDAO.GetByID(context, MSG_ID);
                GROUP_ID = msgCheck.Group_Id;

                IEnumerable<message> groupMsgsEnum = msgDAO.GetGroupMessages(context, GROUP_ID);

                Assert.AreEqual(msgCheck.Group_Id, GROUP_ID);
            }
        }


    }
}
