using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PigeonsLibrairy.DAO.Implementation;
using PigeonsLibrairy.Model;
using System.Collections.Generic;

namespace UnitTesting.TestDAO
{
    /// <summary>
    /// Test des opération CRUD de la classe <see cref="ChatHistoryDAO"/> pour la table <see cref="chathistory"/>
    /// </summary>
    [TestClass]
    public class chatHistoryDAO_Test
    {
        private ChatHistoryDAO chatHistoryDAO { get; set; }
        private chathistory chatHistoryTest { get; set; }

        private const int CHAT_HISTORY_GROUP_ID = 16;
        private const int CHAT_HISTORY_AUTHOR_ID = 16;
        private const string CHAT_HISTORY_MESSAGE = "nice then";
        private DateTime CHAT_HISTORY_CREATION_DATE = DateTime.Now;

        /// <summary>
        /// Création du DAO et d'une chathistory pour les tests
        /// </summary>
        [TestInitialize()]
        public void MyTestInitialize()
        {
            chatHistoryDAO = new ChatHistoryDAO();

            chatHistoryTest = new chathistory();

            chatHistoryTest.Group_ID = CHAT_HISTORY_GROUP_ID;
            chatHistoryTest.Author_ID = CHAT_HISTORY_AUTHOR_ID;
            chatHistoryTest.Message = CHAT_HISTORY_MESSAGE;
            chatHistoryTest.CreationDate = CHAT_HISTORY_CREATION_DATE;
        }

        /// <summary>
        /// Remet le DAO et le chathistory à null
        /// </summary>
        [TestCleanup()]
        public void MyTestCleanup()
        {
            chatHistoryDAO = null;
            chatHistoryTest = null;
        }

        /// <summary>
        /// Test pour la méthode Insert de la classes <see cref="PigeonsLibrairy.DAO.Implementation.ChatHistoryDAO"/>
        /// Insertion d'une ChatHistory et validation de ses propriétés
        /// </summary>
        [TestMethod]
        public void TestInsertChatHistory()
        {
            using (var context = new pigeonsEntities1())
            {
                chatHistoryDAO.Insert(context, chatHistoryTest);
                context.SaveChanges();
                int insertedChatHistoryId = chatHistoryTest.ID;

                chathistory actualChatHistory = chatHistoryDAO.GetByID(context, insertedChatHistoryId);

                Assert.AreEqual(CHAT_HISTORY_GROUP_ID, actualChatHistory.Group_ID);
                Assert.AreEqual(CHAT_HISTORY_AUTHOR_ID, actualChatHistory.Author_ID);
                Assert.AreEqual(CHAT_HISTORY_MESSAGE, actualChatHistory.Message);
                Assert.AreEqual(CHAT_HISTORY_CREATION_DATE, actualChatHistory.CreationDate);

                chatHistoryDAO.Delete(context, insertedChatHistoryId);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Test pour la méthode Delete de la classes <see cref="PigeonsLibrairy.DAO.Implementation.ChatHistoryDAO"/>
        /// Insertion d'une ChatHistory et validation de ses propriétés
        /// </summary>
        [TestMethod]
        public void TestDeleteChatHistory()
        {
            using (var context = new pigeonsEntities1())
            {
                chatHistoryDAO.Insert(context, chatHistoryTest);
                context.SaveChanges();
                int insertedChatHistoryId = chatHistoryTest.ID;

                chathistory actualChatHistory = chatHistoryDAO.GetByID(context, insertedChatHistoryId);
                Assert.AreEqual(chatHistoryTest, actualChatHistory);

                chatHistoryDAO.Delete(context, insertedChatHistoryId);
                context.SaveChanges();

                chathistory DeletedChatHistory = chatHistoryDAO.GetByID(context, insertedChatHistoryId);
                Assert.AreEqual(null, DeletedChatHistory);
            }
        }

        /// <summary>
        /// Test pour la méthode Update de la classes <see cref="PigeonsLibrairy.DAO.Implementation.ChatHistoryDAO"/>
        /// Insertion d'une ChatHistory et validation de ses propriétés
        /// </summary>
        [TestMethod]
        public void TestUpdateChatHistory()
        {
            const string expected_UpdatedMessage = "There we go!";

            using (var context = new pigeonsEntities1())
            {
                chatHistoryDAO.Insert(context, chatHistoryTest);
                context.SaveChanges();
                int insertedChatHistoryID = chatHistoryTest.ID;

                chathistory actualChatHistory = chatHistoryDAO.GetByID(context, insertedChatHistoryID);
                actualChatHistory.Message = expected_UpdatedMessage;

                chatHistoryDAO.Update(context, actualChatHistory);
                context.SaveChanges();

                chathistory updatedChatHistory = chatHistoryDAO.GetByID(context, insertedChatHistoryID);
                Assert.AreEqual(expected_UpdatedMessage, updatedChatHistory.Message);

                chatHistoryDAO.Delete(context, insertedChatHistoryID);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Test pour la méthode GetBy column name de la classes <see cref="PigeonsLibrairy.DAO.Implementation.ChatHistoryDAO"/>
        /// Insertion d'une ChatHistory et validation de ses propriétés
        /// </summary>
        //[TestMethod]
        //public void TestGetByChatHistory()
        //{
        //    using (var context = new pigeonsEntities1())
        //    {
        //        chatHistoryDAO.Insert(context, chatHistoryTest);
        //        context.SaveChanges();
        //        int insertedChatHistoryID = chatHistoryTest.ID;

        //        IEnumerable<chathistory> actualChatHistory = chatHistoryDAO.GetBy(context, chathist);
        //        Assert.AreEqual();
        //        assignationDAO.Delete(context, insertedAssignationID);
        //        context.SaveChanges();
        //    }
        //}
    }
}
