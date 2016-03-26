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

        public new IEnumerable<following> GetBy(string columnName, object value)
        {
            IEnumerable<following> followingList = new List<following>();

            switch (columnName.ToLower())
            {
                case "person_id":
                    followingList = Get(f => f.Person_Id == (int)value);
                    break;
                case "group_id":
                    followingList = Get(f => f.Group_id == (int)value);
                    break;
                default:
                    break;
            }
            return followingList;
        }

        public IList<following> GetTheFollowers(int groupID)
        {
            IList<following> followersList = new List<following>();

            followersList = Get(f => f.Group_id == groupID && f.Is_active).ToList();

            return followersList;
        }
    }
}
