using System;
using PigeonsLibrairy.Model;
using PigeonsLibrairy.Service.Interface;
using PigeonsLibrairy.DAO.Implementation;
using System.Collections.Generic;
using PigeonsLibrairy.Exceptions;
using System.Linq;

namespace PigeonsLibrairy.Service.Implementation
{
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
        public void CreateNewGroupAndRegister(group newGroup, int personId)
        {
            using(var context = new pigeonsEntities1())
            using(var dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    // Inserting the group
                    groupDAO.Insert(context, newGroup);
                    context.SaveChanges();

                    // Creating the following
                    following personIsFollowing = new following();
                    personIsFollowing.Person_Id = personId;
                    personIsFollowing.Group_id = newGroup.Id; // The id of the group can be retreived right away without querying the DB
                    personIsFollowing.Is_active = true;
                    personIsFollowing.Is_admin = true;
                    personIsFollowing.Last_checkin = DateTime.Now;

                    // Inserting the following
                    followingDAO.Insert(context, personIsFollowing);
                    context.SaveChanges();

                    // Committing the changes
                    dbContextTransaction.Commit();
                }
                catch(Exception)
                {
                    // Something went wrong so we are rollbacking the db
                    dbContextTransaction.Rollback();
                }                
            }
        }

        /// <summary>
        /// Finding all the groups a person is registered too
        /// </summary>
        /// <param name="personID">The ID of the person we want the groups</param>
        /// <returns>A list of active groups that a person is following or an empty list of he is not following any group</returns>
        public IList<group> GetPersonGroups(int personID)
        {
            if(personID == 0)
            {
                throw new ServiceException("The ID of the person is null");
            }

            IList<group> personGroups = new List<group>();
            IList<following> personFollowings = new List<following>();

            //List<following> test = new List<following>();            

            using(var context = new pigeonsEntities1())
            {
                //test = followingDAO.GetPersonFollowingGroups(context, personID).ToList();
                //foreach(following f in test)
                //{
                //    Console.WriteLine(f.group.Name);
                //}

                // Getting the list of followings
                personFollowings = (followingDAO.GetBy(context, following.COLUMN_PERSON_ID, personID)).ToList();

                if (personFollowings.Count() > 0)
                {
                    foreach (following followingGroup in personFollowings)
                    {
                        if (followingGroup.Is_active)
                        {
                            // The group is active so adding to the list
                            personGroups.Add(GetByID(followingGroup.Group_id));
                        }
                    }
                }
            }
            
            return personGroups;
        }

        /// <summary>
        /// Following GetBy a specific column name and value
        /// </summary>
        /// <param name="columnName">The column name in the following table</param>
        /// <param name="value">The value to search</param>
        /// <returns></returns>
        public new IEnumerable<group> GetBy(string columnName, object value)
        {
            IEnumerable<group> groupList = new List<group>();

            if(columnName != "" && value != null)
            {
                using(var context = new pigeonsEntities1())
                {
                    groupList = groupDAO.GetBy(context, columnName, value);
                    return groupList;
                }
            }
            else
            {
                throw new ServiceException("You must provid the column name and a value");
            }                                    
        }        
    }
}
