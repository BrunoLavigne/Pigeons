using System;
using PigeonsLibrairy.Model;
using PigeonsLibrairy.Service.Interface;
using PigeonsLibrairy.DAO.Implementation;

namespace PigeonsLibrairy.Service.Implementation
{
    public class GroupService : Service<group>, IGroupService
    {
        private GroupDAO groupDAO { get; set; }
        private FollowingDAO followingDAO { get; set; }

        public GroupService(pigeonsEntities1 context) : base(context)
        {
            groupDAO = new GroupDAO(context);
            followingDAO = new FollowingDAO(context);
        }

        /// <summary>
        /// The group was creating on the form view with the provided informations
        /// It is now added to the database
        /// At the sametime, we are registering (following) the creator of the group to that new group
        /// </summary>
        /// <param name="newGroup"></param>
        /// <param name="personId"></param>
        public void CreateNewGroupAndRegister(group newGroup, int personId)
        {
            using(var dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    dao.Insert(newGroup);
                    context.SaveChanges();

                    following personIsFollowing = new following();
                    personIsFollowing.Person_Id = personId;
                    personIsFollowing.Group_id = newGroup.Id; // The id of the group can be retreived right away without querying the DB
                    personIsFollowing.Is_active = true;
                    personIsFollowing.Is_admin = true;
                    personIsFollowing.Last_checkin = DateTime.Now;

                    followingDAO.Insert(personIsFollowing);
                    context.SaveChanges();

                    dbContextTransaction.Commit();
                }
                catch(Exception)
                {
                    dbContextTransaction.Rollback();
                }                
            }
        }
    }
}
