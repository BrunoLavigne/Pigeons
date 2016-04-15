using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PigeonsLibrairy.Model;
using PigeonsLibrairy.DAO.Implementation;
using System.Collections.Generic;

namespace UnitTesting
{
    [TestClass]
    public class FollowingDAOTesting
    {

        private const bool FOLLOW_ACTIVITY = true;

        private int PERSON_ID { get; set; }
        private int GROUP_ID { get; set; }

        #region CRUD
        [TestMethod]
        public void InsertTest()
        {
            using (var context = new pigeonsEntities1())
            {
                following followsToTest = new following();

                followsToTest.Group_id = 15;
                followsToTest.Person_Id = 20;
                followsToTest.Is_admin = false;
                followsToTest.Last_checkin = DateTime.Now;
                followsToTest.Is_active = true;

                FollowingDAO followDAO = new FollowingDAO();

                followDAO.Insert(context, followsToTest);
                context.SaveChanges();
                PERSON_ID = followsToTest.Person_Id;
                GROUP_ID = followsToTest.Group_id;

                Assert.AreEqual(followsToTest.Is_active, FOLLOW_ACTIVITY);
            }
        }

        [TestMethod]
        public void GetByIdTest()
        {
            using (var context = new pigeonsEntities1())
            {
                FollowingDAO followDAO = new FollowingDAO();

                following followCheck = followDAO.GetByID(context, PERSON_ID, GROUP_ID);

                Assert.AreEqual(followCheck.Person_Id, PERSON_ID);
                Assert.AreEqual(followCheck.Group_id, GROUP_ID);
            }
        }

        [TestMethod]
        public void UpdateTest()
        {
            using (var context = new pigeonsEntities1())
            {
                FollowingDAO followDAO = new FollowingDAO();
                following followToTest = followDAO.GetByID(context, PERSON_ID, GROUP_ID);

                bool modif = false;
                followToTest.Is_active = modif;

                followDAO.Update(context, followToTest);
                context.SaveChanges();

                Assert.AreEqual(followToTest.Is_active, modif);
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            using (var context = new pigeonsEntities1())
            {
                FollowingDAO followDAO = new FollowingDAO();
                following followToTest = followDAO.GetByID(context, PERSON_ID, GROUP_ID);

                followDAO.Delete(context, followToTest);
                context.SaveChanges();

                Assert.AreEqual(null, followToTest);
            }
        }
        #endregion CRUD

        [TestMethod]
        public void GetTheFollowersTest()
        {
            using (var context = new pigeonsEntities1())
            {
                FollowingDAO followDAO = new FollowingDAO();
                IEnumerable<following> followersEnum = followDAO.GetTheFollowers(context, GROUP_ID);

                Assert.AreEqual(followDAO.GetTheFollowers(context, GROUP_ID), followersEnum);
            }
        }

        [TestMethod]
        public void GetTheFollowersCountTest()
        {
            using (var context = new pigeonsEntities1())
            {
                FollowingDAO followDAO = new FollowingDAO();
                IList<following> followersList = followDAO.GetTheFollowersCount(context, GROUP_ID);

                Assert.AreEqual(followDAO.GetTheFollowersCount(context, GROUP_ID), followersList);
            }
        }

        [TestMethod]
        public void GetPersonFollowingGroupsTest()
        {
            using (var context = new pigeonsEntities1())
            {
                FollowingDAO followDAO = new FollowingDAO();
                IEnumerable<following> followersEnum = followDAO.GetPersonFollowingGroups(context, PERSON_ID);

                Assert.AreEqual(followDAO.GetPersonFollowingGroups(context, GROUP_ID), followersEnum);
            }
        }
        
    }
}
