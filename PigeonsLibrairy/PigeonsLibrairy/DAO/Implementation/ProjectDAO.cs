﻿using PigeonsLibrairy.DAO.Interface;
using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PigeonsLibrairy.DAO.Implementation
{
    public class ProjectDAO : DAO<project>, IProjectDAO
    {
        public ProjectDAO() : base() {}

        public new IEnumerable<project> GetBy(pigeonsEntities1 context, string columnName, object value)
        {
            Expression<Func<project, bool>> filter = null;            

            switch (columnName.ToLower())
            {
                case project.COLUMN_GROUP_ID:
                    filter = (p => p.Group_id == (int)value);
                    break;
                case project.COLUMN_TYPE_ID:
                    filter = (p => p.Type_id == (int)value);
                    break;
                case project.COLUMN_DATE_START:
                    //projectList = Get(p => p.Date_start.Date == ((DateTime)value).Date);
                    break;
                case project.COLUMN_DATE_END:
                    //projectList = Get(p => p.Date_end.Date == ((DateTime)value).Date);
                    break;
                case project.COLUMN_DESCRIPTION:
                    filter = (p => p.Description.ToLower().Contains(((string)value).ToLower()));
                    break;
                default:
                    break;
            }
            return Get(context, filter);
        }
    }
}
