using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PigeonsLibrairy.Service.Implementation;
using PigeonsLibrairy.Model;
using PigeonsLibrairy.Exceptions;

namespace UnitTesting.TestService
{
    // <summary>
    /// Test des opération CRUD de la classe <see cref="FollowingService"/> pour la table <see cref="following"/>
    /// </summary>
    [TestClass]
    public class followingService_Test
    {
        /// <summary>
        /// Le service à tester
        /// </summary>
        private FollowingService followingService { get; set; }

        /// <summary>
        /// Création du service pour les tests
        /// </summary>
        [TestInitialize()]
        public void MyTestInitialize()
        {
            followingService = new FollowingService();
        }

        /// <summary>
        /// Remise des variables à null
        /// </summary>
        [TestCleanup()]
        public void MyTestCleanup()
        {
            followingService = null;
        }

        /// <summary>
        /// Test de la méthode <see cref="FollowingService.AddPersonToGroup(object, object, object)"/>
        /// La personne est null. Une ServiceException devrait être lancée
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ServiceException), "La personne est null devrait lancer une ServiceException")]
        public void AddPersonToGroupTest_nullPerson()
        {
            followingService.AddPersonToGroup(null,null,null);
        }

        /// <summary>
        /// Test de la méthode <see cref="FollowingService.AddPersonToGroup(object, object, object)"/>
        /// Le groupe est null. Une ServiceException devrait être lancée
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ServiceException), "Le groupe est null devrait lancer une ServiceException")]
        public void AddPersonToGroupTest_nullGroup()
        {
            person person = new person();
            followingService.AddPersonToGroup(person, null,null);
        }

        /// <summary>
        /// Test de la méthode <see cref="FollowingService.AddPersonToGroup(object, object, object)"/>
        /// La personne n'est pas admin. Une ServiceException devrait être lancée
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ServiceException), "La personne n'est pas admin devrait lancer une ServiceException")]
        public void AddPersonToGroupTest_nullAdmin()
        {
            person person = new person();
            group group = new group();
            followingService.AddPersonToGroup(person, group, null);
        }
    }
}
