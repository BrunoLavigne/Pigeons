using System;
using PigeonsLibrairy.Model;
using PigeonsLibrairy.Service.Interface;
using PigeonsLibrairy.DAO.Implementation;
using System.Collections.Generic;
using PigeonsLibrairy.Exceptions;
using System.Linq;

namespace PigeonsLibrairy.Service.Implementation
{
    /// <summary>
    /// Service pour la table Group (<see cref="group"/>)
    /// </summary>
    public class GroupService : Service<group>, IGroupService
    {
        private GroupDAO groupDAO { get; set; }
        private FollowingDAO followingDAO { get; set; }

        public GroupService() : base()
        {
            groupDAO = new GroupDAO();
            followingDAO = new FollowingDAO();
        }

        /// <summary>
        /// The group was creating on the form view with the provided informations
        /// It is now added to the database
        /// At the sametime, we are registering (following) the creator of the group to that new group
        /// </summary>
        /// <param name="newGroup">The group to be created</param>
        /// <param name="personId">The ID of the person creating the group</param>
        public group CreateNewGroupAndRegister(group newGroup, object personId)
        {
            if(newGroup == null)
            {
                throw new ServiceException("The group is null");
            }

            if(personId == null)
            {
                throw new ServiceException("The personID is null");
            }

            try
            {
                using (var context = new pigeonsEntities1())
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    newGroup.Creation_date = DateTime.Now;
                    newGroup.Is_active = true;

                    // Inserting the group                    
                    groupDAO.Insert(context, newGroup);
                    context.SaveChanges();

                    // Creating the following
                    following personIsFollowing = new following();
                    personIsFollowing.Person_Id = (int)personId;
                    personIsFollowing.Group_id = newGroup.Id; // The id of the group can be retreived right away without querying the DB
                    personIsFollowing.Is_active = true;
                    personIsFollowing.Is_admin = true;
                    personIsFollowing.Last_checkin = DateTime.Now;

                    // Inserting the following
                    followingDAO.Insert(context, personIsFollowing);
                    context.SaveChanges();

                    // Committing the changes
                    dbContextTransaction.Commit();
                    return newGroup;
                }
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }

        /// <summary>
        /// Finding all the groups a person is registered too
        /// </summary>
        /// <param name="personID">The ID of the person we want the groups</param>
        /// <returns>A list of active groups that a person is following or an empty list of he is not following any group</returns>
        public IList<group> GetPersonGroups(object personID)
        {
            if(personID == null)
            {
                throw new ServiceException("The ID of the person is null");
            }

            IList<group> personGroups = new List<group>();
            IList<following> personFollowings = new List<following>();

            try
            {
                using (var context = new pigeonsEntities1())
                {
                    // Getting the list of followings
                    personFollowings = (followingDAO.GetPersonFollowingGroups(context, personID)).ToList();

                    if (personFollowings.Count() > 0)
                    {
                        foreach (following followingGroup in personFollowings)
                        {
                            personGroups.Add(followingGroup.group);
                        }
                    }
                }
                return personGroups;
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }

        /// <summary>
        /// Closing a group service (Setting the group to inactive and the follower too)
        /// </summary>
        /// <param name="adminID">The ID of the person trying to close the group (should only be the admin)</param>
        /// <param name="groupID">The ID of the group we are closing</param>
        /// <returns>True if the group is closed, throwing a ServiceException otherwise</returns>
        public bool CloseGroup(object adminID, object groupID)
        {
            if (adminID == null)
            {
                throw new ServiceException("The ID of the admin is null");
            }

            if (groupID == null)
            {
                throw new ServiceException("The ID of the group is null");
            }

            try
            {
                using (var context = new pigeonsEntities1())
                {
                    group groupValidation = groupDAO.GetByID(context, groupID);

                    if (groupValidation == null)
                    {
                        throw new ServiceException("The group doesnt exist");
                    }

                    if (!groupValidation.Is_active)
                    {
                        throw new ServiceException("This group is already inactive");
                    }

                    List<following> followingValidation = followingDAO.GetByID(context, adminID, groupID).ToList();

                    if (followingValidation.Count != 1)
                    {
                        throw new ServiceException("This person is not following the group");
                    }

                    if (!followingValidation[0].Is_admin)
                    {
                        throw new ServiceException("This person is not the admin of the group");
                    }

                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            // Setting the group to inactive
                            groupValidation.Is_active = false;
                            groupDAO.Update(context, groupValidation);

                            IEnumerable<following> followersList = followingDAO.GetTheFollowers(context, groupValidation.Id);

                            // Setting each follower to inactive
                            foreach(following follower in followersList)
                            {
                                follower.Is_active = false;
                                followingDAO.Update(context, follower);
                            }

                            // Saving and committing
                            context.SaveChanges();
                            dbContextTransaction.Commit();
                            return true;
                        }
                        catch (Exception)
                        {
                            // Something went wrong so we are rollbacking the db
                            dbContextTransaction.Rollback();
                            throw new ServiceException("Error in the transaction");
                        }
                    }
                }
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }

        /// <summary>
        /// Following GetBy a specific column name and value
        /// </summary>
        /// <param name="columnName">The column name in the following table</param>
        /// <param name="value">The value to search</param>
        /// <returns>The groups we are searching. An empty list of none are found</returns>
        public new IEnumerable<group> GetBy(string columnName, object value)
        {
            if (columnName == null || columnName == "")
            {
                throw new ServiceException("La valeur de la colonne ne doit pas être null");
            }

            if (value == null || (string)value == "")
            {
                throw new ServiceException("La valeur recherchée ne peut pas être null");
            }

            try
            {
                using (var context = new pigeonsEntities1())
                {
                    return groupDAO.GetBy(context, columnName, value);
                }
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }                                  
        }        
    }
}
