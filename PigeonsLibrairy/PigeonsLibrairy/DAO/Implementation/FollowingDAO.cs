using PigeonsLibrairy.DAO.Interface;
using PigeonsLibrairy.Model;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Linq.Expressions;

namespace PigeonsLibrairy.DAO.Implementation
{
    public class FollowingDAO : DAO<following>, IFollowingDAO
    {
        public FollowingDAO() : base() { }

        public new IEnumerable<following> GetBy(pigeonsEntities1 context, string columnName, object value)
        {
            Expression<Func<following, bool>> filter = null;

            switch (columnName.ToLower())
            {
                case following.COLUMN_PERSON_ID:
                    filter = (f => f.Person_Id == (int)value);
                    break;
                case following.COLUMN_GROUP_ID:
                    filter = (f => f.Group_id == (int)value);
                    break;
                default:
                    break;
            }            
            return Get(context, filter);
        }

        public IEnumerable<following> GetPersonFollowingGroups(pigeonsEntities1 context, object personID)
        {
            Expression<Func<following, bool>> filter = (f => f.Person_Id == (int)personID && f.group.Is_active == true);
            string includeProperties = "group";
            return Get(context, filter, null, includeProperties);
        }

        public IList<following> GetTheFollowers(pigeonsEntities1 context, int groupID)
        {
            IList<following> followersList = new List<following>();

            followersList = Get(context, f => f.Group_id == groupID && f.Is_active).ToList();

            return followersList;
        }
    }
}
