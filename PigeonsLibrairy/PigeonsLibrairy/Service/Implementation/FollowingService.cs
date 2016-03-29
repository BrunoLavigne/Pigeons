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

        public FollowingService() : base()
        {
            followingDAO = new FollowingDAO();
            groupDAO = new GroupDAO();
        }

        /// <summary>
        /// Adding a person to a group
        /// </summary>
        /// <param name="personId">The ID of the person to be added</param>
        /// <param name="groupeId">The ID of the group the person will be added too</param>
        public void addPersonToGroup(object adminID, object personId, object groupId)
        {
            if(personId == null)
            {
                throw new ServiceException("The personID is null");
            }

            if(groupId == null)
            {
                throw new ServiceException("The groupID is null");
            }

            if(adminID == null)
            {
                throw new ServiceException("The adminID is null");
            }

            using (var context = new pigeonsEntities1())
            {
                // Validating the group
                group theGroup = groupDAO.GetByID(context, groupId);

                if (theGroup == null)
                {
                    throw new ServiceException("The group doesnt exist");
                }

                if (!theGroup.Is_active)
                {
                    throw new ServiceException("This group is not active");
                }

                List<following> followingList = followingDAO.GetBy(context, following.COLUMN_GROUP_ID, groupId).ToList();

                foreach (following follow in followingList)
                {
                    // If the user is already following that group
                    if (follow.Person_Id == (int) personId && follow.Is_active)
                    {
                        throw new ServiceException("The user is already following this group");
                    }
                    // He was following the group but was deactivated - Reactivating the person
                    else if (follow.Person_Id == (int) personId && !follow.Is_active)
                    {
                        follow.Is_active = true;
                        followingDAO.Update(context, follow);
                        context.SaveChanges();
                        return;
                    }
                    // The user adding is not admin of this group
                    if (follow.Person_Id == (int) adminID && !follow.Is_admin)
                    {
                        throw new ServiceException("The user trying to add is not the admin");
                    }
                }

                // Everyting is ok, adding the following
                following newFollowing = new following();
                newFollowing.Person_Id = (int)personId;
                newFollowing.Group_id = (int)groupId;
                newFollowing.Is_admin = false;
                newFollowing.Is_active = true;
                newFollowing.Last_checkin = DateTime.Now;

                followingDAO.Insert(context, newFollowing);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Remove a follower from a group (Setting the following is_active to false)
        /// </summary>
        /// <param name="groupID">The group ID of the group we are modifying</param>
        /// <param name="followerID">The follower ID to remove</param>
        /// <returns>True if the follower is removed, false otherwise</returns>
        public bool RemoveTheFollower(object groupID, object followerID)
        {
            if(groupID == null)
            {
                throw new ServiceException("The ID of the group is null");
            }

            if (followerID == null)
            {
                throw new ServiceException("The ID of the follower is null");
            }

            using(var context = new pigeonsEntities1())
            {
                try
                {
                    group groupValidation = groupDAO.GetByID(context, groupID);

                    if (groupValidation == null)
                    {
                        throw new ServiceException("The group doesnt exist");
                    }

                    if (!groupValidation.Is_active)
                    {
                        throw new ServiceException("The group is not active. Cannot change it");
                    }

                    List<following> followerList = followingDAO.GetBy(context, following.COLUMN_PERSON_ID, followerID).ToList();

                    if(followerList == null)
                    {
                        throw new ServiceException("The follower doesn't exist");
                    }

                    following theFollower = followerList[0];

                    if (!theFollower.Is_active)
                    {
                        throw new ServiceException("The follower is already removed from this group");
                    }

                    if (theFollower.Is_admin)
                    {
                        throw new ServiceException("You cannot remove the admin from the group");
                    }            

                    theFollower.Is_active = false;
                    followingDAO.Update(context, theFollower);
                    context.SaveChanges();
                    return true;
                }
                catch(DAOException daoException)
                {
                    throw new ServiceException(daoException.Message);
                }                
            }            
        }

        /// <summary>
        /// Retreive a list with all the active followers of a group
        /// </summary>
        /// <param name="groupID">The group ID we want the followers</param>
        /// <returns>A list with the followers (following) or an empty list</returns>
        public IList<following> GetTheFollowers(object groupID)
        {
            if(groupID == null)
            {
                throw new ServiceException("The groupID is null");
            }

            using(var context = new pigeonsEntities1())
            {
                group group = groupDAO.GetByID(context, groupID);

                if(group == null)
                {
                    throw new ServiceException("This group doesn't exist");
                }

                if (!group.Is_active)
                {
                    throw new ServiceException("This group is not active");
                }

                return followingDAO.GetTheFollowers(context, groupID);
            }            
        }

        /// <summary>
        /// Checking if the user accessing a group is the administrator of it
        /// </summary>
        /// <param name="personID">The ID of the person accessing the group</param>
        /// <param name="groupID">The ID of the group</param>
        /// <returns>True if the person is admin, false if not.</returns>
        public bool PersonIsGroupAdmin(object personID, object groupID)
        {
            if (personID == null)
            {
                throw new ServiceException("The person ID is null");
            }

            if (groupID == null)
            {
                throw new ServiceException("The group ID is null");
            }

            using(var context = new pigeonsEntities1())
            {
                List<following> adminValidation = followingDAO.GetByID(context, personID, groupID).ToList();

                if (adminValidation == null)
                {
                    throw new ServiceException("This person is not following this group");
                }

                if(adminValidation.Count != 1)
                {
                    throw new ServiceException("Something is wrong with this group");
                }

                // returning the value
                return adminValidation[0].Is_admin;                
            }            
        }

        public new IEnumerable<following> GetBy(string columnName, object value)
        {
            IEnumerable<following> followingList = new List<following>();

            if (columnName != "" && value != null)
            {
                using(var context = new pigeonsEntities1())
                {
                    followingList = followingDAO.GetBy(context, columnName, value);
                    return followingList;
                }                
            }
            else
            {
                throw new ServiceException("You must provid the column name and a value");
            }
        }

    }
}
