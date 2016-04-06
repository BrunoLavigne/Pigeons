using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PigeonsLibrairy.Model;
using PigeonsLibrairy.DAO.Implementation;

namespace UnitTesting
{
    [TestClass]
    public class DAOCrudTesting
    {
        private const string PERSON_NAME = "Toto";
        private const string GROUP_NAME = "Rookies";
        private const string TASK_DESC = "Rock";
        private const string TYPE_NAME = "HEHEHE";

        private int PERSON_ID { get; set; }
        private int GROUP_ID { get; set; }
        private int TASK_ID { get; set; }
        private int TYPE_ID { get; set; }

        #region CRUDPerson
        [TestMethod]
        public void InsertPersonTest()
        {
            using (var context = new pigeonsEntities1())
            {
                person personToTest = new person();

                personToTest.Name = PERSON_NAME;
                personToTest.Email = "toto@gmail.com";
                personToTest.Profile_picture_link = "http://toto.com";
                personToTest.Inscription_date = DateTime.Now;
                personToTest.Birth_date = DateTime.Parse("1980-01-15");
                personToTest.Phone_number = "5141234567";
                personToTest.Organization = "Toto Inc";
                personToTest.Position = "Analyst";
                personToTest.Description = "YOLO";
                personToTest.Password = "123456";

                PersonDAO personDAO = new PersonDAO();

                personDAO.Insert(context, personToTest);
                context.SaveChanges();
                PERSON_ID = personToTest.Id;

                Assert.AreEqual(personToTest.Id, PERSON_ID);
                
            }
        }

        [TestMethod]
        public void GetByIdPersonTest()
        {
            using (var context = new pigeonsEntities1())
            {
                PersonDAO personDAO = new PersonDAO();

                person personCheck = personDAO.GetByID(context, PERSON_ID);

                Assert.AreEqual(personCheck.Name, PERSON_NAME);
            }
        }

        [TestMethod]
        public void UpdatePersonTest()
        {
            using (var context = new pigeonsEntities1())
            {
                PersonDAO personDAO = new PersonDAO();
                person personToTest = personDAO.GetByID(context, PERSON_ID);

                String modif = "www.toto.org";
                personToTest.Profile_picture_link = modif;

                personDAO.Update(context, personToTest);
                context.SaveChanges();

                Assert.AreEqual(personToTest.Profile_picture_link, modif);
            }
        }

        [TestMethod]
        public void DeletePersonTest()
        {
            using (var context = new pigeonsEntities1())
            {
                PersonDAO personDAO = new PersonDAO();

                personDAO.Delete(context, PERSON_ID);
                context.SaveChanges();

                Assert.AreEqual(null, PERSON_ID);
            }
        }
        #endregion CRUDPerson

        #region CRUDGroup
        [TestMethod]
        public void InsertGroupTest()
        {
            using (var context = new pigeonsEntities1())
            {
                group groupToTest = new group();

                groupToTest.Name = "Rookies";
                groupToTest.Creation_date = DateTime.Now;
                groupToTest.Description = "WE ROCK";
                groupToTest.Is_active = true;

                GroupDAO groupDAO = new GroupDAO();

                groupDAO.Insert(context, groupToTest);
                context.SaveChanges();
                GROUP_ID = groupToTest.Id;

                Assert.AreEqual(groupToTest.Id, GROUP_ID);
            }
        }

        [TestMethod]
        public void GetByIdGroupTest()
        {
            using (var context = new pigeonsEntities1())
            {
                GroupDAO groupDAO = new GroupDAO();

                group groupCheck = groupDAO.GetByID(context, GROUP_ID);

                Assert.AreEqual(groupCheck.Name, GROUP_NAME);
            }
        }

        [TestMethod]
        public void UpdateGroupTest()
        {
            using (var context = new pigeonsEntities1())
            {
                GroupDAO groupDAO = new GroupDAO();
                group groupToTest = groupDAO.GetByID(context, GROUP_ID);

                String modif = "TesaTesa";
                groupToTest.Description = modif;

                groupDAO.Update(context, groupToTest);
                context.SaveChanges();

                Assert.AreEqual(groupToTest.Description, modif);
            }
        }

        [TestMethod]
        public void DeleteGroupTest()
        {
            using (var context = new pigeonsEntities1())
            {
                GroupDAO groupDAO = new GroupDAO();
                
                groupDAO.Delete(context, GROUP_ID);
                context.SaveChanges();

                Assert.AreEqual(null, GROUP_ID);
            }
        }
        #endregion CRUDGroup

        #region CRUDTask
        [TestMethod]
        public void InsertTaskTest()
        {
            using (var context = new pigeonsEntities1())
            {
                task taskToTest = new task();

                taskToTest.Project_ID = 1;
                taskToTest.Description = "Coder";
                taskToTest.Date_due = DateTime.Now;
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

                task taskCheck = taskDAO.GetByID(context,TASK_ID);

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

        #region CRUDType
        [TestMethod]
        public void InsertTypeTest()
        {
            using (var context = new pigeonsEntities1())
            {
                task taskToTest = new task();

                taskToTest.Project_ID = 1;
                taskToTest.Description = "Coder";
                taskToTest.Date_due = DateTime.Now;
                taskToTest.Is_completed = false;

                TaskDAO taskDAO = new TaskDAO();

                taskDAO.Insert(context, taskToTest);
                context.SaveChanges();
                TASK_ID = taskToTest.Id;

                Assert.AreEqual(taskToTest.Id, TASK_ID);
            }
        }

        [TestMethod]
        public void GetByIdTypeTest()
        {
            using (var context = new pigeonsEntities1())
            {
                TaskDAO taskDAO = new TaskDAO();

                task taskCheck = taskDAO.GetByID(context, TASK_ID);

                Assert.AreEqual(taskCheck.Description, TASK_DESC);
            }
        }

        [TestMethod]
        public void UpdateTypeTest()
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
        public void DeleteTypeTest()
        {
            using (var context = new pigeonsEntities1())
            {
                TaskDAO taskDAO = new TaskDAO();

                taskDAO.Delete(context, TASK_ID);
                context.SaveChanges();

                Assert.AreEqual(null, TASK_ID);
            }
        }
        #endregion CRUDType
    }
}
