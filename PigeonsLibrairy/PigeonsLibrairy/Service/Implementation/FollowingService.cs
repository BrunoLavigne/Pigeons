using System;
using System.Collections.Generic;
using PigeonsLibrairy.Model;
using PigeonsLibrairy.Service.Interface;
using PigeonsLibrairy.DAO.Implementation;
using PigeonsLibrairy.Exceptions;
using System.Linq;

namespace PigeonsLibrairy.Service.Implementation
{
    public class FollowingService : Service<following>, IFollowingService
    {
        private FollowingDAO followingDAO;
        private GroupDAO groupDAO;

        public FollowingService(pigeonsEntities1 context) : base(context)
        {
            followingDAO = new FollowingDAO(context);
            groupDAO = new GroupDAO(context);
        }

        /// <summary>
        /// Adding a person to a group
        /// </summary>
        /// <param name="personId">The ID of the person to be added</param>
        /// <param name="groupeId">The ID of the group the person will be added too</param>
        public void addPersonToGroup(int adminID, int personId, int groupId)
        {

            if(personId == 0)
            {
                throw new ServiceException("The personID is null");
            }

            if(groupId == 0)
            {
                throw new ServiceException("The groupID is null");
            }

            if(adminID == 0)
            {
                throw new ServiceException("The adminID is null");
            }

            // Validating the group
            group theGroup = groupDAO.GetByID(groupId);

            if(theGroup == null)
            {
                throw new ServiceException("The group doesnt exist");
            }

            if (!theGroup.Is_active)
            {
                throw new ServiceException("This group is not active");
            }

            List<following> followingList = followingDAO.GetBy(following.COLUMN_NAME.GROUP_ID.ToString(), groupId).ToList();
         
            foreach(following follow in followingList)
            {
                // If the user is already following that group
                if(follow.Person_Id == personId && follow.Is_active)
                {
                    throw new ServiceException("The user is already following this group");
                }
                // He was following the group but was deactivated - Reactivating the person
                else if(follow.Person_Id == personId && !follow.Is_active)
                {
                    follow.Is_active = true;
                    Update(follow);
                    context.SaveChanges();
                    return;
                }
                // The user adding is not admin of this group
                if(follow.Person_Id == adminID && !follow.Is_admin)
                {
                    throw new ServiceException("The user trying to add is not the admin");
                }
            }           

            // Everyting is ok, adding the user
            following newFollowing = new following();
            newFollowing.Person_Id = personId;
            newFollowing.Group_id = groupId;
            newFollowing.Is_admin = false;
            newFollowing.Is_active = true;
            newFollowing.Last_checkin = DateTime.Now;

            Insert(newFollowing);
            context.SaveChanges();
        }

        /// <summary>
        /// Retreive a list with all the active followers of a group
        /// </summary>
        /// <param name="groupID">The group ID we want the followers</param>
        /// <returns>A list with the followers (following) or an empty list</returns>
        public IList<following> GetTheFollowers(int groupID)
        {
            if(groupID == 0)
            {
                throw new ServiceException("The groupID is null");
            }

            return followingDAO.GetTheFollowers(groupID);
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
