using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PigeonsLibrairy.Service.Implementation;
using PigeonsLibrairy.Exceptions;
using PigeonsLibrairy.Model;

namespace UnitTesting.TestService
{
    // <summary>
    /// Test des opération CRUD de la classe <see cref="GroupService"/> pour la table <see cref="group"/>
    /// </summary>
    [TestClass]
    public class groupService_Test
    {
        /// <summary>
        /// Le service à tester
        /// </summary>
        private GroupService groupService { get; set; }

        /// <summary>
        /// Création du service pour les tests
        /// </summary>
        [TestInitialize()]
        public void MyTestInitialize()
        {
            groupService = new GroupService();
        }

        /// <summary>
        /// Remise des variables è null
        /// </summary>
        [TestCleanup()]
        public void MyTestCleanup()
        {
            groupService = null;
        }

        /// <summary>
        /// Test de la méthode <see cref="GroupService.CreateNewGroupAndRegister(group, object)"/>
        /// Le service à ajouter est null. Une ServiceException devrait être lancée
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ServiceException), "Un nouveau service null devrait lancer une ServiceException")]
        public void CreateNewGroupAndRegisterTest_nullGroup()
        {
            groupService.CreateNewGroupAndRegister(null, null);
        }

        /// <summary>
        /// Test de la méthode <see cref="GroupService.RegisterNewUser(group, object)"/>
        /// La personne qui ajoute le groupe est null. Une ServiceException devrait être lancée
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ServiceException), "La personne est null. Devrait lancer une ServiceException")]
        public void CreateNewGroupAndRegisterTest_nullPerson()
        {
            group group = new group();
            groupService.CreateNewGroupAndRegister(group, null);
        }
    }
}
