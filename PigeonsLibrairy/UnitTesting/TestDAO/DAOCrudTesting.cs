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

        private int PERSON_ID { get; set; }
        private int GROUP_ID { get; set; }
        private int ASSIGNATION_ID { get; set; }
        private int CHAT_ID { get; set; }
        private int FILE_ID { get; set; }


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

                groupToTest.Name = GROUP_NAME;
                groupToTest.Creation_date = DateTime.Now;
                groupToTest.Description = "WE ROCK";
                groupToTest.Group_picture_link = "www.flickr.com";
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

        #region CRUDAssignation
        [TestMethod]
        public void InsertAssignationTest()
        {
            using (var context = new pigeonsEntities1())
            {
                assignation assignToTest = new assignation();

                assignToTest.Task_ID = 6;
                assignToTest.Person_ID = 3;

                AssignationDAO assignDAO = new AssignationDAO();

                assignDAO.Insert(context, assignToTest);
                context.SaveChanges();
                ASSIGNATION_ID = assignToTest.ID;

                Assert.AreEqual(assignToTest.ID, ASSIGNATION_ID);
            }
        }

        [TestMethod]
        public void GetByIdAssignationTest()
        {
            using (var context = new pigeonsEntities1())
            {
                AssignationDAO assignDAO = new AssignationDAO();

                assignation assignCheck = assignDAO.GetByID(context, ASSIGNATION_ID);

                Assert.AreEqual(assignCheck.ID, ASSIGNATION_ID);
            }
        }

        [TestMethod]
        public void UpdateAssignationTest()
        {
            using (var context = new pigeonsEntities1())
            {
                AssignationDAO assignDAO = new AssignationDAO();
                assignation assignToTest = assignDAO.GetByID(context, ASSIGNATION_ID);

                int modif = 16;
                assignToTest.Person_ID = modif;

                assignDAO.Update(context, assignToTest);
                context.SaveChanges();

                Assert.AreEqual(assignToTest.Person_ID, modif);
            }
        }

        [TestMethod]
        public void DeleteAssignationTest()
        {
            using (var context = new pigeonsEntities1())
            {
                AssignationDAO assignDAO = new AssignationDAO();

                assignDAO.Delete(context, ASSIGNATION_ID);
                context.SaveChanges();

                Assert.AreEqual(null, ASSIGNATION_ID);
            }
        }
        #endregion CRUDAssignation

        #region CRUDChatHistory
        [TestMethod]
        public void InsertChatHistoryTest()
        {
            using (var context = new pigeonsEntities1())
            {
                chathistory chatToTest = new chathistory();

                chatToTest.Author_ID = 3;
                chatToTest.Group_ID = 15;
                chatToTest.Message = "yup yup";
                chatToTest.CreationDate = DateTime.Now;

                ChatHistoryDAO chatDAO = new ChatHistoryDAO();

                chatDAO.Insert(context, chatToTest);
                context.SaveChanges();
                CHAT_ID = chatToTest.ID;

                Assert.AreEqual(chatToTest.ID, CHAT_ID);
            }
        }

        [TestMethod]
        public void GetByIdChatHistoryTest()
        {
            using (var context = new pigeonsEntities1())
            {
                ChatHistoryDAO chatDAO = new ChatHistoryDAO();

                chathistory chatCheck = chatDAO.GetByID(context, CHAT_ID);

                Assert.AreEqual(chatCheck.ID, CHAT_ID);
            }
        }

        [TestMethod]
        public void UpdateChatHistoryTest()
        {
            using (var context = new pigeonsEntities1())
            {
                ChatHistoryDAO chatDAO = new ChatHistoryDAO();
                chathistory chatToTest = chatDAO.GetByID(context, CHAT_ID);

                string modif = "Hapo";
                chatToTest.Message = modif;

                chatDAO.Update(context, chatToTest);
                context.SaveChanges();

                Assert.AreEqual(chatToTest.Message, modif);
            }
        }

        [TestMethod]
        public void DeleteChatHistoryTest()
        {
            using (var context = new pigeonsEntities1())
            {
                ChatHistoryDAO chatDAO = new ChatHistoryDAO();

                chatDAO.Delete(context, CHAT_ID);
                context.SaveChanges();

                Assert.AreEqual(null, CHAT_ID);
            }
        }
        #endregion CRUDChatHistory

        #region CRUDFile
        [TestMethod]
        public void InsertFiletTest()
        {
            using (var context = new pigeonsEntities1())
            {
                file fileToTest = new file();

                fileToTest.Group_ID = 15;
                fileToTest.FileName = "PdfChat";
                fileToTest.FileURL = "work/files";
                fileToTest.Creation_Date = DateTime.Now;

                FileDAO fileDAO = new FileDAO();

                fileDAO.Insert(context, fileToTest);
                context.SaveChanges();
                FILE_ID = fileToTest.ID;

                Assert.AreEqual(fileToTest.ID, FILE_ID);
            }
        }

        [TestMethod]
        public void GetByIdFileTest()
        {
            using (var context = new pigeonsEntities1())
            {
                FileDAO fileDAO = new FileDAO();

                file fileCheck = fileDAO.GetByID(context, FILE_ID);

                Assert.AreEqual(fileCheck.ID, FILE_ID);
            }
        }

        [TestMethod]
        public void UpdateFileTest()
        {
            using (var context = new pigeonsEntities1())
            {
                FileDAO fileDAO = new FileDAO();
                file fileToTest = fileDAO.GetByID(context, FILE_ID);

                string modif = "fichier";
                fileToTest.FileName = modif;

                fileDAO.Update(context, fileToTest);
                context.SaveChanges();

                Assert.AreEqual(fileToTest.FileName, modif);
            }
        }

        [TestMethod]
        public void DeleteFileTest()
        {
            using (var context = new pigeonsEntities1())
            {
                FileDAO fileDAO = new FileDAO();

                fileDAO.Delete(context, FILE_ID);
                context.SaveChanges();

                Assert.AreEqual(null, FILE_ID);
            }
        }
        #endregion CRUDFile
        
    }
}
