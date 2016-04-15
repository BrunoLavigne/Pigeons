using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PigeonsLibrairy.Model;

namespace UnitTesting.TestDAO
{
    [TestClass]
    public class groupDAO_Test
    {
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
    }
}
