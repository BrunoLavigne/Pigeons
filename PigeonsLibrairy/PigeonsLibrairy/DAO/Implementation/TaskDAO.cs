using PigeonsLibrairy.DAO.Interface;
using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PigeonsLibrairy.DAO.Implementation
{
    class TaskDAO : DAO<task>, ITaskDAO
    {
        public TaskDAO() : base() { }

        /// <summary>
        /// Get a task by searching a value in a column
        /// </summary>
        /// <param name="context">The connection</param>
        /// <param name="columnName">The name of the column in the table</param>
        /// <param name="value">The value to search</param>
        /// <returns>A list of task that match the query</returns>
        public new IEnumerable<task> GetBy(pigeonsEntities1 context, string columnName, object value)
        {
            Expression<Func<task, bool>> filter = null;            

            switch (columnName.ToLower())
            {
                case task.COLUMN_PROJECT_ID:
                    filter = (t => t.Project_ID == (int)value);
                    break;
                case task.COLUMN_DESCRIPTION:
                    filter = (t => t.Description.ToLower().Contains(((string)value).ToLower()));
                    break;
                case task.COLUMN_DATE_DUE:
                    //taskList = Get(t => t.Date_due.Date == ((DateTime)value).Date);
                    break;
                case task.COLUMN_IS_COMPLETED:
                    filter = (t => t.Is_completed == (bool)value);
                    break;     
                default:
                    break;
            }
            return Get(context, filter);
        }
    }
}
