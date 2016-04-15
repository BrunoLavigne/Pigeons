using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PigeonsLibrairy.DAO.Implementation;
using PigeonsLibrairy.Model;
using System.Collections.Generic;

namespace PigeonsTesting
{
    [TestClass]
    public class TaskDAOTesting
    {

        private const string TASK_DESC = "Rock";

        private int TASK_ID { get; set; }

        #region CRUDTask
        [TestMethod]
        public void InsertTaskTest()
        {
            using (var context = new pigeonsEntities1())
            {
                task taskToTest = new task();

                taskToTest.Description = TASK_DESC;
                taskToTest.Author_ID = 16;
                taskToTest.Group_ID = 16;
                taskToTest.Task_DateTime = DateTime.Now;
                taskToTest.Is_important = true;
                taskToTest.Is_completed = false;

                TaskDAO taskDAO = new TaskDAO();

                taskDAO.Insert(context, taskToTest);
                context.SaveChanges();
                TASK_ID = taskToTest.Id;

                Assert.AreEqual(taskToTest.Id, TASK_ID);
            }
        }

        [TestMethod]
        public void GetByIdTaskTest()
        {
            using (var context = new pigeonsEntities1())
            {
                TaskDAO taskDAO = new TaskDAO();

                task taskCheck = taskDAO.GetByID(context, TASK_ID);

                Assert.AreEqual(taskCheck.Description, TASK_DESC);
            }
        }

        [TestMethod]
        public void UpdateTaskTest()
        {
            using (var context = new pigeonsEntities1())
            {
                TaskDAO taskDAO = new TaskDAO();
                task taskToTest = taskDAO.GetByID(context, TASK_ID);

                String modif = "TesaTesa";
                taskToTest.Description = modif;

                taskDAO.Update(context, taskToTest);
                context.SaveChanges();

                Assert.AreEqual(taskToTest.Description, modif);
            }
        }

        [TestMethod]
        public void DeleteTaskTest()
        {
            using (var context = new pigeonsEntities1())
            {
                TaskDAO taskDAO = new TaskDAO();

                taskDAO.Delete(context, TASK_ID);
                context.SaveChanges();

                Assert.AreEqual(null, TASK_ID);
            }
        }
        #endregion CRUDTask

        [TestMethod]
        public void GetGroupTasksTest()
        {
            using(var context = new pigeonsEntities1())
            {
                TaskDAO taskDAO = new TaskDAO();
                task taskCheck = taskDAO.GetByID(context, TASK_ID);
                int groupId = taskCheck.Group_ID;

                IEnumerable<task> groupTasksEnum = taskDAO.GetGroupTasks(groupId, taskCheck.Is_completed);

                Assert.AreEqual(taskCheck.Group_ID, groupId);
            }
        }
    }
}
