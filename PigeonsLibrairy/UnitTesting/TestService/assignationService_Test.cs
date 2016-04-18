using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PigeonsLibrairy.Service.Implementation;
using PigeonsLibrairy.Model;
using PigeonsLibrairy.Exceptions;

namespace UnitTesting.TestService
{
    // <summary>
    /// Test des opération CRUD de la classe <see cref="AssignationService"/> pour la table <see cref="assignation"/>
    /// </summary>
    [TestClass]
    public class assignationService_Test
    {
        /// <summary>
        /// Le service à tester
        /// </summary>
        private AssignationService assignationService { get; set; }

        /// <summary>
        /// Création du service pour les tests
        /// </summary>
        [TestInitialize()]
        public void MyTestInitialize()
        {
            assignationService = new AssignationService();
        }

        /// <summary>
        /// Remise des variables à null
        /// </summary>
        [TestCleanup()]
        public void MyTestCleanup()
        {
            assignationService = null;
        }

        /// <summary>
        /// Test de la méthode <see cref="AssignationService.AssignTaskToPerson(assignation)"/>
        /// L'assignation est null. Une ServiceException devrait être lancée
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ServiceException), "L'assignation est null devrait lancer une ServiceException")]
        public void AssignTaskToPersonTest_nullAssignation()
        {
            assignationService.AssignTaskToPerson(null);
        }

        /// <summary>
        /// Test de la méthode <see cref="AssignationService.AssignTaskToPerson(assignation)"/>
        /// La personne est null. Une ServiceException devrait être lancée
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ServiceException), "La personne est null devrait lancer une ServiceException")]
        public void AssignTaskToPersonTest_zeroPerson()
        {
            assignation assignation = new assignation();
            assignation.Person_ID = 0;
            assignationService.AssignTaskToPerson(assignation);
        }

        /// <summary>
        /// Test de la méthode <see cref="AssignationService.AssignTaskToPerson(assignation)"/>
        /// La task est null. Une ServiceException devrait être lancée
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ServiceException), "La task est null devrait lancer une ServiceException")]
        public void AssignTaskToPersonTest_zeroTask()
        {
            assignation assignation = new assignation();
            assignation.Task_ID = 0;
            assignationService.AssignTaskToPerson(assignation);
        }
    }
}
