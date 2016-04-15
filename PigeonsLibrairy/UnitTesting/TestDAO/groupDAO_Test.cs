using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PigeonsLibrairy.Model;
using PigeonsLibrairy.DAO.Implementation;

namespace UnitTesting.TestDAO
{
    [TestClass]
    public class groupDAO_Test
    {
        private GroupDAO groupDAO { get; set; }
        private group groupTest { get; set; }

        private const string GROUP_NAME = "Rookies";
        private DateTime GROUP_CREATION_DATE = DateTime.Parse("1993-10-21");
        private const string GROUP_DESCRIPTION = "We rooooock";
        private const string GROUP_PICTURE_LINK = "www.rookies.com";
        private const bool GROUP_IS_ACTIVE = true;

        /// <summary>
        /// Création du DAO et d'un group pour les tests
        /// </summary>
        [TestInitialize()]
        public void MyTestInitialize()
        {
            groupDAO = new GroupDAO();

            groupTest = new group();

            groupTest.Name = GROUP_NAME;
            groupTest.Creation_date = GROUP_CREATION_DATE;
            groupTest.Description = GROUP_DESCRIPTION;
            groupTest.pi
        }


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
    }
}
