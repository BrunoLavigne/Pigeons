using PigeonsLibrairy.DAO.Interface;
using PigeonsLibrairy.Exceptions;
using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq.Expressions;

namespace PigeonsLibrairy.DAO.Implementation
{
    /// <summary>
    /// DAO de la table <see cref="project"/>
    /// </summary>
    class ProjectDAO : DAO<project>, IProjectDAO
    {
        public ProjectDAO() : base() {}

        /// <summary>
        /// Get a project by searching a value in a column
        /// </summary>
        /// <param name="context">The connection</param>
        /// <param name="columnName">The name of the column in the table</param>
        /// <param name="value">The value to search</param>
        /// <returns>A list of project that match the query</returns>
        public new IEnumerable<project> GetBy(pigeonsEntities1 context, string columnName, object value)
        {
            Expression<Func<project, bool>> filter = null;

            try
            {
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
            catch (Exception ex) when (ex is EntityException || ex is DAOException)
            {
                throw new DAOException(ex.Message);
            }
        }
    }
}
