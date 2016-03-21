using System;
using System.Collections.Generic;
using PigeonsLibrairy.Model;
using PigeonsLibrairy.Service.Interface;
using PigeonsLibrairy.DAO.Implementation;
using PigeonsLibrairy.Exceptions;

namespace PigeonsLibrairy.Service.Implementation
{
    public class FollowingService : Service<following>, IFollowingService
    {
        private FollowingDAO followingDAO;

        public FollowingService(pigeonsEntities1 context) : base(context)
        {
            followingDAO = new FollowingDAO(context);
        }

        /// <summary>
        /// Get a list of following by person id
        /// </summary>
        /// <param name="personId">The ID of the person</param>
        /// <returns>A list of following</returns>
        public List<following> GetTheFollowingGroupsOfPersonId(int personId)
        {
            if (personId == 0)
            {
                throw new ServiceException("The id cannot be null");
            }

            List<following> theFollowings = new List<following>();
            theFollowings = followingDAO.GetTheFollowingGroups(personId);
            return theFollowings;
        }

        /// <summary>
        /// Adding a person to a group
        /// </summary>
        /// <param name="personId">The ID of the person to be added</param>
        /// <param name="groupeId">The ID of the group the person will be added too</param>
        public void addPersonToGroup(int personId, int groupeId)
        {
            following newFollowing = new following();
            newFollowing.Person_Id = personId;
            newFollowing.Group_id = groupeId;
            newFollowing.Is_admin = false;
            newFollowing.Is_active = true;

            followingDAO.Insert(newFollowing);
            context.SaveChanges();
        }

        /// <summary>
        /// Retreiving the list of the person following a group (followers)
        /// </summary>
        /// <param name="groupId">The group ID we are searching for</param>
        /// <returns>A list of followers</returns>
        public List<following> GetThePersonsFollowingGroupsId(int groupId)
        {
            if(groupId == 0)
            {
                throw new ServiceException("The group id cannot be null");
            }

            List<following> theFollowers = new List<following>();
            theFollowers = followingDAO.GetThePersonsFollowingGroupsId(groupId);
            return theFollowers;
        }
    }
}
