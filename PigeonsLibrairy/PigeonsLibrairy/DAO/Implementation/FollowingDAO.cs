using PigeonsLibrairy.DAO.Interface;
using PigeonsLibrairy.Model;
using System.Collections.Generic;
using System.Linq;
using System;

namespace PigeonsLibrairy.DAO.Implementation
{
    public class FollowingDAO : DAO<following>, IFollowingDAO
    {
        public FollowingDAO(pigeonsEntities1 context) : base(context) { }

        /// <summary>
        /// Get the list of groups a person is following
        /// </summary>
        /// <param name="personId">The ID of the person</param>
        /// <returns>The list of the following the person have</returns>
        public List<following> GetTheFollowingGroups(int personId)
        {
            return context.followings.Where(follow => follow.Person_Id == personId).ToList();            
        }

        /// <summary>
        /// Get the list of the persons with are following a group
        /// </summary>
        /// <param name="groupId">The group Id</param>
        /// <returns>A list of following that group</returns>
        public List<following> GetThePersonsFollowingGroupsId(int groupId)
        {
            return context.followings.Where(follow => follow.Group_id == groupId).ToList();
        }
    }
}
