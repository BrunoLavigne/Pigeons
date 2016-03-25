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

        public new IEnumerable<following> GetBy(string columnName, object value)
        {
            IEnumerable<following> followingList = new List<following>();

            if (columnName != "" && value != null)
            {
                followingList = followingDAO.GetBy(columnName, value);
                return followingList;
            }
            else
            {
                throw new ServiceException("You must provid the column name and a value");
            }
        }
    }
}
