﻿using PigeonsLibrairy.DAO.Interface;
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

        /// <summary>
        /// Get a following using his primary key (personID and groupID)
        /// </summary>
        /// <param name="context">The connection to the database</param>
        /// <param name="personID">The ID of the person</param>
        /// <param name="groupID">The ID of the group</param>
        /// <returns>A list of following matching the query. An empty list of nothing is found</returns>
        public IEnumerable<following> GetByID(pigeonsEntities1 context, object personID, object groupID)
        {
            Expression<Func<following, bool>> filter = null;
            filter = (f => f.Person_Id == (int)personID && f.Group_id == (int)groupID);
            return Get(context, filter);
        }

        /// <summary>
        /// Get a following by search a value in a column
        /// </summary>
        /// <param name="context">The connection</param>
        /// <param name="columnName">The name of the column in the table</param>
        /// <param name="value">The value to search</param>
        /// <returns>A list of following that match the query</returns>
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

        /// <summary>
        /// Retrieve the groups that a person is following
        /// </summary>
        /// <param name="context">The connection</param>
        /// <param name="personID">The ID of the person</param>
        /// <returns>A list of following including the group</returns>
        public IEnumerable<following> GetPersonFollowingGroups(pigeonsEntities1 context, object personID)
        {
            Expression<Func<following, bool>> filter = (f => f.Person_Id == (int)personID && f.group.Is_active == true);            
            string includeProperties = "group";
            return Get(context, filter, null, includeProperties).OrderBy(m => m.group.Creation_date);
        }

        /// <summary>
        /// Get a list of person following a group
        /// </summary>
        /// <param name="context">The connection</param>
        /// <param name="groupID">The ID of the group</param>
        /// <returns>A list of following the group</returns>
        public IList<following> GetTheFollowers(pigeonsEntities1 context, object groupID)
        {
            IList<following> followersList = new List<following>();
            followersList = Get(context, f => f.Group_id == (int)groupID && f.Is_active).ToList();
            return followersList;
        }
    }
}
