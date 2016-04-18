using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PigeonsLibrairy.Model;
using PigeonsLibrairy.Service.Implementation;
using PigeonsLibrairy.Exceptions;

namespace UnitTesting.TestService
{
    // <summary>
    /// Test des opération CRUD de la classe <see cref="TaskService"/> pour la table <see cref="task"/>
    /// </summary>
    [TestClass]
    public class taskService_Test
    {
        /// <summary>
        /// Le service à tester
        /// </summary>
        private TaskService taskService { get; set; }

        /// <summary>
        /// Création du service pour les tests
        /// </summary>
        [TestInitialize()]
        public void MyTestInitialize()
        {
            taskService = new TaskService();
        }

        /// <summary>
        /// Remise des variables à null
        /// </summary>
        [TestCleanup()]
        public void MyTestCleanup()
        {
            taskService = null;
        }

        /// <summary>
        /// Test de la méthode <see cref="TaskService.CreateNewTask(task, object, object)"/>
        /// La tache est null. Une ServiceException devrait être lancée
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ServiceException), "La tache est null devrait lancer une ServiceException")]
        public void CreateNewTaskTest_nullTask()
        {
            taskService.CreateNewTask(null, null, null);
        }

        /// <summary>
        /// Test de la méthode <see cref="TaskService.CreateNewTask(task, object, object)"/>
        /// Le groupe est null. Une ServiceException devrait être lancée
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ServiceException), "LE groupe est null devrait lancer une ServiceException")]
        public void CreateNewTaskTest_nullGroup()
        {
            task task = new task();
            taskService.CreateNewTask(task, null, null);
        }

        /// <summary>
        /// Test de la méthode <see cref="TaskService.CreateNewTask(task, object, object)"/>
        /// La personne est null. Une ServiceException devrait être lancée
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ServiceException), "La personne est null devrait lancer une ServiceException")]
        public void CreateNewTaskTest_nullPerson()
        {
            task task = new task();
            group group = new group();
            taskService.CreateNewTask(task, group, null);
        }
    }
}
