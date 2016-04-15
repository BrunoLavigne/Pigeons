using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PigeonsLibrairy.Model;
using PigeonsLibrairy.DAO.Implementation;
using UnitTesting.TestDAO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

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
            groupTest.Group_picture_link = GROUP_PICTURE_LINK;
            groupTest.Is_active = GROUP_IS_ACTIVE;
        }

        /// <summary>
        /// Remet le DAO et le group à null
        /// </summary>
        [TestCleanup()]
        public void MyTestCleanup()
        {
            groupDAO = null;
            groupTest = null;
        }

        /// <summary>
        /// Test pour la méthode Insert de la classes <see cref="PigeonsLibrairy.DAO.Implementation.GroupDAO"/>
        /// Insertion d'un Group et validation de ses propriétés
        /// </summary>
        [TestMethod]
        public void TestInsertGroup()
        {
            using (var context = new pigeonsEntities1())
            {
                groupDAO.Insert(context, groupTest);
                context.SaveChanges();
                int insertedGroupID = groupTest.Id;

                group actualGroup = groupDAO.GetByID(context, insertedGroupID);
                
                Assert.AreEqual(GROUP_NAME, actualGroup.Name);
                Assert.AreEqual(GROUP_CREATION_DATE, actualGroup.Creation_date);
                Assert.AreEqual(GROUP_DESCRIPTION, actualGroup.Description);
                Assert.AreEqual(GROUP_PICTURE_LINK, actualGroup.Group_picture_link);
                Assert.AreEqual(GROUP_IS_ACTIVE, actualGroup.Is_active);

                groupDAO.Delete(context, insertedGroupID);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Test pour la méthode Delete de la classes <see cref="PigeonsLibrairy.DAO.Implementation.GroupDAO"/>
        /// Insertion d'un Group et validation de ses propriétés
        /// </summary>
        [TestMethod]
        public void TestDeleteGroup()
        {
            using (var context = new pigeonsEntities1())
            {
                groupDAO.Insert(context, groupTest);
                context.SaveChanges();
                int insertedGroupID = groupTest.Id;

                group actualGroup = groupDAO.GetByID(context, insertedGroupID);
                Assert.AreEqual(groupTest, actualGroup);

                groupDAO.Delete(context, insertedGroupID);
                context.SaveChanges();

                group DeletedGroup = groupDAO.GetByID(context, insertedGroupID);
                Assert.AreEqual(null, DeletedGroup);
            }
        }

        /// <summary>
        /// Test pour la méthode Update de la classes <see cref="PigeonsLibrairy.DAO.Implementation.GroupDAO"/>
        /// Insertion d'un Group et validation de ses propriétés
        /// </summary>
        [TestMethod]
        public void TestUpdateGroup()
        {
            const string expected_UpdatedName = "We've got to change the name";

            using (var context = new pigeonsEntities1())
            {
                groupDAO.Insert(context, groupTest);
                context.SaveChanges();
                int insertedGroupID = groupTest.Id;

                group actualGroup = groupDAO.GetByID(context, insertedGroupID);
                actualGroup.Name = expected_UpdatedName;

                groupDAO.Update(context, actualGroup);
                context.SaveChanges();

                group updatedGroup = groupDAO.GetByID(context, insertedGroupID);
                Assert.AreEqual(expected_UpdatedName, updatedGroup.Name);

                groupDAO.Delete(context, insertedGroupID);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Test pour la méthode GetBy column name de la classes <see cref="PigeonsLibrairy.DAO.Implementation.GroupDAO"/>
        /// Insertion d'une Person et validation de ses propriétés
        /// </summary>
        [TestMethod]
        public void TestGetByPerson()
        {
            using (var context = new pigeonsEntities1())
            {
                groupDAO.Insert(context, groupTest);
                context.SaveChanges();
                int insertedGroupID = groupTest.Id;

                List<group> groupByName = groupDAO.GetBy(context, group.COLUMN_NAME, GROUP_NAME).ToList();
                Assert.AreEqual(GROUP_NAME, groupByName[0].Name);

                List<group> groupByDescription = groupDAO.GetBy(context, group.COLUMN_DESCRIPTION, GROUP_DESCRIPTION).ToList();
                Assert.AreEqual(GROUP_DESCRIPTION, groupByDescription[0].Description);

                List<group> groupByCreationDate = groupDAO.GetBy(context, group.COLUMN_CREATION_DATE, GROUP_CREATION_DATE).ToList();
                Assert.AreEqual(GROUP_CREATION_DATE, groupByCreationDate[0].Creation_date);

                groupDAO.Delete(context, insertedGroupID);
                context.SaveChanges();
            }
        }
    }
}
