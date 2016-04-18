using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PigeonsLibrairy.Service.Implementation;
using PigeonsLibrairy.Model;
using PigeonsLibrairy.Exceptions;

namespace UnitTesting.TestService
{
    // <summary>
    /// Test des opération CRUD de la classe <see cref="FileService"/> pour la table <see cref="file"/>
    /// </summary>
    [TestClass]
    public class fileService_Test
    {
        /// <summary>
        /// Le service à tester
        /// </summary>
        private FileService fileService { get; set; }

        /// <summary>
        /// Création du service pour les tests
        /// </summary>
        [TestInitialize()]
        public void MyTestInitialize()
        {
            fileService = new FileService();
        }

        /// <summary>
        /// Remise des variables à null
        /// </summary>
        [TestCleanup()]
        public void MyTestCleanup()
        {
            fileService = null;
        }

        /// <summary>
        /// Test de la méthode <see cref="FileService.InsertFileInformations(file)"/>
        /// Le file est null. Une ServiceException devrait être lancée
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ServiceException), "Le file est null devrait lancer une ServiceException")]
        public void InsertFileInformationsTest_nullFile()
        {
            fileService.InsertFileInformations(null);
        }

        /// <summary>
        /// Test de la méthode <see cref="FileService.GetFilesByGroup(object)"/>
        /// Le groupe est null. Une ServiceException devrait être lancée
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ServiceException), "Le groupe est null devrait lancer une ServiceException")]
        public void GetFilesByGroupTest_nullGroup()
        {
            file file = new file();
            fileService.GetFilesByGroup(file.Group_ID == null);
        }
    }
}
