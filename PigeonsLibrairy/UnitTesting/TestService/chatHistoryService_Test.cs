using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PigeonsLibrairy.Service.Implementation;
using PigeonsLibrairy.Model;
using PigeonsLibrairy.Exceptions;

namespace UnitTesting.TestService
{
    // <summary>
    /// Test des opération CRUD de la classe <see cref="ChatHistoryService"/> pour la table <see cref="chathistory"/>
    /// </summary>
    [TestClass]
    public class chatHistoryService_Test
    {
        /// <summary>
        /// Le service à tester
        /// </summary>
        private ChatHistoryService chatHistoryService { get; set; }

        /// <summary>
        /// Création du service pour les tests
        /// </summary>
        [TestInitialize()]
        public void MyTestInitialize()
        {
            chatHistoryService = new ChatHistoryService();
        }

        /// <summary>
        /// Remise des variables à null
        /// </summary>
        [TestCleanup()]
        public void MyTestCleanup()
        {
            chatHistoryService = null;
        }

        /// <summary>
        /// Test de la méthode <see cref="ChatHistoryService.InsertChatMessage(chathistory)"/>
        /// Le chat est null. Une ServiceException devrait être lancée
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ServiceException), "Le chat est null devrait lancer une ServiceException")]
        public void InsertChatMessageTest_nullChatHistory()
        {
            chatHistoryService.InsertChatMessage(null);
        }

        /// <summary>
        /// Test de la méthode <see cref="AssignationService.AssignTaskToPerson(chathistory)"/>
        /// Le groupe est null. Une ServiceException devrait être lancée
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ServiceException), "Le groupe est null devrait lancer une ServiceException")]
        public void InsertChatMessageTest_zeroGroup()
        {
            chathistory chathistory = new chathistory();
            chathistory.Group_ID= 0;
            chatHistoryService.InsertChatMessage(chathistory);
        }

        /// <summary>
        /// Test de la méthode <see cref="ChatHistoryService.InsertChatMessage(chathistory)"/>
        /// La personne est null. Une ServiceException devrait être lancée
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ServiceException), "La personne est null devrait lancer une ServiceException")]
        public void InsertChatMessageTest_zeroPerson()
        {
            chathistory chathistory = new chathistory();
            chathistory.Author_ID = 0;
            chatHistoryService.InsertChatMessage(chathistory);
        }
    }
}
