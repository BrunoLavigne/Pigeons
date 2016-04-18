using Microsoft.VisualStudio.TestTools.UnitTesting;
using PigeonsLibrairy.DAO.Implementation;
using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PigeonsTesting
{
    /// <summary>
    /// Test des opération CRUD de la classe <see cref="TaskDAO"/> pour la table <see cref="task"/>
    /// </summary>
    [TestClass]
    public class taskDAO_Test
    {
        private TaskDAO taskDAO { get; set; }
        private task taskTest { get; set; }

        private const string TASK_DESCRIPTION = "Coder";
        private const int TASK_AUTHOR_ID = 3;
        private const int TASK_GROUP_ID = 15;
        private DateTime TASK_DATE_TIME = DateTime.Parse("2016-04-18");
        private const bool TASK_IS_COMPLETED = false;
        private const bool TASK_IS_IMPORTANT = true;

        /// <summary>
        /// Création du DAO et d'une task pour les tests
        /// </summary>
        [TestInitialize()]
        public void MyTestInitialize()
        {
            taskDAO = new TaskDAO();

            taskTest = new task();

            taskTest.Description = TASK_DESCRIPTION;
            taskTest.Author_ID = TASK_AUTHOR_ID;
            taskTest.Group_ID = TASK_GROUP_ID;
            taskTest.Task_DateTime = TASK_DATE_TIME;
            taskTest.Is_completed = TASK_IS_COMPLETED;
            taskTest.Is_important = TASK_IS_IMPORTANT;
        }

        /// <summary>
        /// Remet le DAO et le task à null
        /// </summary>
        [TestCleanup()]
        public void MyTestCleanup()
        {
            taskDAO = null;
            taskTest = null;
        }

        /// <summary>
        /// Test pour la méthode Insert de la classes <see cref="PigeonsLibrairy.DAO.Implementation.TaskDAO"/>
        /// Insertion d'une Task et validation de ses propriétés
        /// </summary>
        [TestMethod]
        public void TestInsertTask()
        {
            using (var context = new pigeonsEntities1())
            {
                taskDAO.Insert(context, taskTest);
                context.SaveChanges();
                int insertedTaskID = taskTest.Id;

                task actualTask = taskDAO.GetByID(context, insertedTaskID);

                Assert.AreEqual(TASK_DESCRIPTION, actualTask.Description);
                Assert.AreEqual(TASK_AUTHOR_ID, actualTask.Author_ID);
                Assert.AreEqual(TASK_GROUP_ID, actualTask.Group_ID);
                Assert.AreEqual(TASK_DATE_TIME, actualTask.Task_DateTime);
                Assert.AreEqual(TASK_IS_COMPLETED, actualTask.Is_completed);
                Assert.AreEqual(TASK_IS_IMPORTANT, actualTask.Is_important);

                taskDAO.Delete(context, taskTest);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Test pour la méthode Delete de la classe <see cref="PigeonsLibrairy.DAO.Implementation.TaskDAO"/>
        /// Insertion d'une Task et validation de ses propriétés
        /// </summary>
        [TestMethod]
        public void TestDeleteTask()
        {
            using (var context = new pigeonsEntities1())
            {
                taskDAO.Insert(context, taskTest);
                context.SaveChanges();
                int insertedTaskID = taskTest.Id;

                task actualTask = taskDAO.GetByID(context, insertedTaskID);
                Assert.AreEqual(taskTest, actualTask);

                taskDAO.Delete(context, taskTest);
                context.SaveChanges();

                task DeletedTask = taskDAO.GetByID(context, insertedTaskID);
                Assert.AreEqual(null, DeletedTask);
            }
        }

        /// <summary>
        /// Test pour la méthode Update de la classes <see cref="PigeonsLibrairy.DAO.Implementation.TaskDAO"/>
        /// Insertion d'une Task et validation de ses propriétés
        /// </summary>
        [TestMethod]
        public void TestUpdateTask()
        {
            const bool expected_UpdatedIsCompleted = true;

            using (var context = new pigeonsEntities1())
            {
                taskDAO.Insert(context, taskTest);
                context.SaveChanges();
                int insertedTaskID = taskTest.Id;

                task actualTask = taskDAO.GetByID(context, insertedTaskID);
                actualTask.Is_completed = expected_UpdatedIsCompleted;

                taskDAO.Update(context, actualTask);
                context.SaveChanges();

                task updatedTask = taskDAO.GetByID(context, insertedTaskID);
                Assert.AreEqual(expected_UpdatedIsCompleted, updatedTask.Is_completed);

                taskDAO.Delete(context, taskTest);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Test pour la méthode GetBy column name de la classe <see cref="PigeonsLibrairy.DAO.Implementation.TaskDAO"/>
        /// Insertion d'une Task et validation de ses propriétés
        /// </summary>
        [TestMethod]
        public void TestGetByTask()
        {
            using (var context = new pigeonsEntities1())
            {
                taskDAO.Insert(context, taskTest);
                context.SaveChanges();
                int insertedTaskID = taskTest.Id;

                List<task> taskByAuthorId = taskDAO.GetBy(context, task.COLUMN_AUTHOR_ID, TASK_AUTHOR_ID).ToList();
                Assert.AreEqual(TASK_AUTHOR_ID, taskByAuthorId[0].Author_ID);

                List<task> taskByGroupId = taskDAO.GetBy(context, task.COLUMN_GROUP_ID, TASK_GROUP_ID).ToList();
                Assert.AreEqual(TASK_GROUP_ID, taskByGroupId[0].Group_ID);

                taskDAO.Delete(context, taskTest);
                context.SaveChanges();
            }
        }
    }
}