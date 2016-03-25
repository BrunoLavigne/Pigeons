using PigeonsLibrairy.DAO.Interface;
using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;

namespace PigeonsLibrairy.DAO.Implementation
{
    public class ProjectDAO : DAO<project>, IProjectDAO
    {
        public ProjectDAO(pigeonsEntities1 context) : base(context)
        {
        }

        public new IEnumerable<project> GetBy(string columnName, object value)
        {
            IEnumerable<project> projectList = new List<project>();

            switch (columnName.ToLower())
            {
                case "group_id":
                    projectList = Get(p => p.Group_id == (int)value);
                    break;
                case "type_id":
                    projectList = Get(p => p.Type_id == (int)value);
                    break;
                case "date_start":
                    //projectList = Get(p => p.Date_start.Date == ((DateTime)value).Date);
                    break;
                case "date_end":
                    //projectList = Get(p => p.Date_end.Date == ((DateTime)value).Date);
                    break;
                case "description":
                    projectList = Get(p => p.Description.ToLower().Contains(((string)value).ToLower()));
                    break;
                default:
                    break;
            }
            return projectList;
        }
    }
}
