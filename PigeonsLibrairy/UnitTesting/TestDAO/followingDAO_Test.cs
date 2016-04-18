using Microsoft.VisualStudio.TestTools.UnitTesting;
using PigeonsLibrairy.DAO.Implementation;
using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTesting
{
    /// <summary>
    /// Test des opération CRUD de la classe <see cref="FollowingDAO"/> pour la table <see cref="following"/>
    /// </summary>
    [TestClass]
    public class followingDAO_Test
    {
        private FollowingDAO followingDAO { get; set; }
        private following followingTest { get; set; }

        private const int FOLLOWING_PERSON_ID = 20;
        private const int FOLLOWING_GROUP_ID = 22;
        private const bool FOLLOWING_IS_ADMIN = true;
        private DateTime FOLLOWING_LAST_CHECKIN = DateTime.Parse("2016-02-09");
        private const bool FOLLOWING_IS_ACTIVE = true;

        /// <summary>
        /// Création du DAO et d'un following pour les tests
        /// </summary>
        [TestInitialize()]
        public void MyTestInitialize()
        {
            followingDAO = new FollowingDAO();

            followingTest = new following();

            followingTest.Person_Id = FOLLOWING_PERSON_ID;
            followingTest.Group_id = FOLLOWING_GROUP_ID;
            followingTest.Is_admin = FOLLOWING_IS_ADMIN;
            followingTest.Last_checkin = FOLLOWING_LAST_CHECKIN;
            followingTest.Is_active = FOLLOWING_IS_ACTIVE;
        }

        /// <summary>
        /// Remet le DAO et le following à null
        /// </summary>
        [TestCleanup()]
        public void MyTestCleanup()
        {
            followingDAO = null;
            followingTest = null;
        }

        /// <summary>
        /// Test pour la méthode Insert de la classes <see cref="PigeonsLibrairy.DAO.Implementation.FollowingDAO"/>
        /// Insertion d'un Group et validation de ses propriétés
        /// </summary>
        public void TestInsertFollowing()
        {
            using (var context = new pigeonsEntities1())
            {
                followingDAO.Insert(context, followingTest);
                context.SaveChanges();
                int insertedFollowPersonID = followingTest.Person_Id;
                int insertedFollowGroupID = followingTest.Group_id;

                following actualFollowing = followingDAO.GetByID(context, insertedFollowPersonID, insertedFollowGroupID);

                Assert.AreEqual(FOLLOWING_PERSON_ID, actualFollowing.Person_Id);
                Assert.AreEqual(FOLLOWING_GROUP_ID, actualFollowing.Group_id);
                Assert.AreEqual(FOLLOWING_IS_ADMIN, actualFollowing.Is_admin);
                Assert.AreEqual(FOLLOWING_LAST_CHECKIN, actualFollowing.Last_checkin);
                Assert.AreEqual(FOLLOWING_IS_ACTIVE, actualFollowing.Is_active);

                followingDAO.Delete(context, followingTest);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Test pour la méthode Delete de la classes <see cref="PigeonsLibrairy.DAO.Implementation.FollowingDAO"/>
        /// Insertion d'un Following et validation de ses propriétés
        /// </summary>
        public void TestDeleteFollowing()
        {
            using (var context = new pigeonsEntities1())
            {
                followingDAO.Insert(context, followingTest);
                context.SaveChanges();
                int insertedFollowPersonID = followingTest.Person_Id;
                int insertedFollowGroupID = followingTest.Group_id;

                following actualFollowing = followingDAO.GetByID(context, insertedFollowPersonID, insertedFollowGroupID);
                Assert.AreEqual(followingTest, actualFollowing);

                followingDAO.Delete(context, followingTest);
                context.SaveChanges();

                following DeletedFollowing = followingDAO.GetByID(context, insertedFollowPersonID, insertedFollowGroupID);
                Assert.AreEqual(null, DeletedFollowing);
            }
        }

        /// <summary>
        /// Test pour la méthode Update de la classes <see cref="PigeonsLibrairy.DAO.Implementation.FollowingDAO"/>
        /// Insertion d'un Group et validation de ses propriétés
        /// </summary>

        public void TestUpdateFollowing()
        {
            const bool expected_UpdatedIsActive = false;

            using (var context = new pigeonsEntities1())
            {
                followingDAO.Insert(context, followingTest);
                context.SaveChanges();
                int insertedFollowPersonID = followingTest.Person_Id;
                int insertedFollowGroupID = followingTest.Group_id;

                following actualFollowing = followingDAO.GetByID(context, insertedFollowPersonID, insertedFollowGroupID);
                actualFollowing.Is_active = expected_UpdatedIsActive;

                followingDAO.Update(context, actualFollowing);
                context.SaveChanges();

                following updatedFollowing = followingDAO.GetByID(context, insertedFollowPersonID, insertedFollowGroupID);
                Assert.AreEqual(expected_UpdatedIsActive, updatedFollowing.Is_active);

                followingDAO.Delete(context, followingTest);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Test pour la méthode GetBy column name de la classes <see cref="PigeonsLibrairy.DAO.Implementation.FollowingDAO"/>
        /// Insertion d'un Following et validation de ses propriétés
        /// </summary>
        public void TestGetByFollowingTest()
        {
            using (var context = new pigeonsEntities1())
            {
                followingDAO.Insert(context, followingTest);
                context.SaveChanges();
                int insertedFollowPersonID = followingTest.Person_Id;
                int insertedFollowGroupID = followingTest.Group_id;

                List<following> followingByPesonId = followingDAO.GetBy(context, following.COLUMN_PERSON_ID, FOLLOWING_PERSON_ID).ToList();
                Assert.AreEqual(FOLLOWING_PERSON_ID, followingByPesonId[0].Person_Id);

                List<following> followingByGroupId = followingDAO.GetBy(context, following.COLUMN_GROUP_ID, FOLLOWING_GROUP_ID).ToList();
                Assert.AreEqual(FOLLOWING_GROUP_ID, followingByGroupId[0].Group_id);

                followingDAO.Delete(context, followingTest);
                context.SaveChanges();
            }
        }
    }
}