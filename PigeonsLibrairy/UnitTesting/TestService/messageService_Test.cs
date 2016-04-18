using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PigeonsLibrairy.Service.Implementation;
using PigeonsLibrairy.Model;
using PigeonsLibrairy.Exceptions;

namespace UnitTesting.TestService
{
    // <summary>
    /// Test des opération CRUD de la classe <see cref="MessageService"/> pour la table <see cref="message"/>
    /// </summary>
    [TestClass]
    public class messageService_Test
    {
        /// <summary>
        /// Le service à tester
        /// </summary>
        private MessageService messageService { get; set; }

        /// <summary>
        /// Création du service pour les tests
        /// </summary>
        [TestInitialize()]
        public void MyTestInitialize()
        {
            messageService = new MessageService();
        }

        /// <summary>
        /// Remise des variables à null
        /// </summary>
        [TestCleanup()]
        public void MyTestCleanup()
        {
            messageService = null;
        }

        /// <summary>
        /// Test de la méthode <see cref="MessageService.CreateNewMessage(message)"/>
        /// Le event est null. Une ServiceException devrait être lancée
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ServiceException), "Le message est null devrait lancer une ServiceException")]
        public void CreateNewMessageTest_nullMessage()
        {
            messageService.CreateNewMessage(null);
        }

        /// <summary>
        /// Test de la méthode <see cref="MessageService.CreateNewMessage(message)"/>
        /// Le content est vide. Une ServiceException devrait être lancée
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ServiceException), "Le content est vide devrait lancer une ServiceException")]
        public void CreateNewMessageTest_emptyContent()
        {
            message message = new message();
            message.Content = "";
            messageService.CreateNewMessage(message);
        }
    }
}
