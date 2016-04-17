using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PigeonsLibrairy.Model;
using PigeonsLibrairy.DAO.Implementation;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace UnitTesting
{
    /// <summary>
    /// Test des opération CRUD de la classe <see cref="MessageDAO"/> pour la table <see cref="message"/>
    /// </summary>
    [TestClass]
    public class messageDAO_Test
    {
        private MessageDAO messageDAO { get; set; }
        private message messageTest { get; set; }

        private const int MESSAGE_AUTHOR_ID = 3;
        private const int MESSAGE_GROUP_ID = 15;
        private const string MESSAGE_CONTENT = "Yup on y va";
        private DateTime MESSAGE_DATE_CREATED = DateTime.Now;

        /// <summary>
        /// Création du DAO et d'un message pour les tests
        /// </summary>
        [TestInitialize()]
        public void MyTestInitialize()
        {
            messageDAO = new MessageDAO();

            messageTest = new message();

            messageTest.Author_Id = MESSAGE_AUTHOR_ID;
            messageTest.Group_Id = MESSAGE_GROUP_ID;
            messageTest.Content = MESSAGE_CONTENT;
            messageTest.Date_created = MESSAGE_DATE_CREATED;
        }

        /// <summary>
        /// Remet le DAO et le message à null
        /// </summary>
        [TestCleanup()]
        public void MyTestCleanup()
        {
            messageDAO = null;
            messageTest = null;
        }

        /// <summary>
        /// Test pour la méthode Insert de la classe <see cref="PigeonsLibrairy.DAO.Implementation.MessageDAO"/>
        /// Insertion d'un Message et validation de ses propriétés
        /// </summary>
        [TestMethod]
        public void TestInsertMessage()
        {
            using (var context = new pigeonsEntities1())
            {
                messageDAO.Insert(context, messageTest);
                context.SaveChanges();
                int insertedMessageID = messageTest.Id;

                message actualMessage = messageDAO.GetByID(context, insertedMessageID);

                Assert.AreEqual(MESSAGE_AUTHOR_ID, actualMessage.Author_Id);
                Assert.AreEqual(MESSAGE_GROUP_ID, actualMessage.Group_Id);
                Assert.AreEqual(MESSAGE_CONTENT, actualMessage.Content);
                Assert.AreEqual(MESSAGE_DATE_CREATED, actualMessage.Date_created);

                messageDAO.Delete(context, messageTest);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Test pour la méthode Delete de la classe <see cref="PigeonsLibrairy.DAO.Implementation.MessageDAO"/>
        /// Insertion d'un Message et validation de ses propriétés
        /// </summary>
        [TestMethod]
        public void TestDeleteMessage()
        {
            using (var context = new pigeonsEntities1())
            {
                messageDAO.Insert(context, messageTest);
                context.SaveChanges();
                int insertedMessageID = messageTest.Id;

                message actualMessage = messageDAO.GetByID(context, insertedMessageID);
                Assert.AreEqual(messageTest, actualMessage);

                messageDAO.Delete(context, messageTest);
                context.SaveChanges();

                message DeletedMessage = messageDAO.GetByID(context, messageTest);
                Assert.AreEqual(null, DeletedMessage);
            }
        }

        /// <summary>
        /// Test pour la méthode Update de la classes <see cref="PigeonsLibrairy.DAO.Implementation.MessageDAO"/>
        /// Insertion d'un Message et validation de ses propriétés
        /// </summary>
        [TestMethod]
        public void TestUpdateMessage()
        {
            const string expected_UpdatedContent = "OK..ca sera fait!";

            using (var context = new pigeonsEntities1())
            {
                messageDAO.Insert(context, messageTest);
                context.SaveChanges();
                int insertedMessageID = messageTest.Id;

                message actualMessage = messageDAO.GetByID(context, insertedMessageID);
                actualMessage.Content = expected_UpdatedContent;

                messageDAO.Update(context, actualMessage);
                context.SaveChanges();

                message updatedMessage = messageDAO.GetByID(context, insertedMessageID);
                Assert.AreEqual(expected_UpdatedContent, updatedMessage.Content);

                messageDAO.Delete(context, messageTest);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Test pour la méthode GetBy column name de la classe <see cref="PigeonsLibrairy.DAO.Implementation.MessageDAO"/>
        /// Insertion d'un Message et validation de ses propriétés
        /// </summary>
        [TestMethod]
        public void TestGetByMessage()
        {
            using (var context = new pigeonsEntities1())
            {
                messageDAO.Insert(context, messageTest);
                context.SaveChanges();
                int insertedMessageID = messageTest.Id;

                List<message> messageByAuthorId = messageDAO.GetBy(context, message.COLUMN_AUTHOR_ID, MESSAGE_AUTHOR_ID).ToList();
                Assert.AreEqual(MESSAGE_AUTHOR_ID, messageByAuthorId[0].Author_Id);

                List<message> messageByGroupId = messageDAO.GetBy(context, message.COLUMN_GROUP_ID, MESSAGE_GROUP_ID).ToList();
                Assert.AreEqual(MESSAGE_GROUP_ID, messageByGroupId[0].Group_Id);

                messageDAO.Delete(context, messageTest);
                context.SaveChanges();
            }
        }
    }
}
