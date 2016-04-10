using PigeonsLibrairy.DAO.Interface;
using PigeonsLibrairy.Exceptions;
using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PigeonsLibrairy.DAO.Implementation
{
    /// <summary>
    /// DAO de la table <see cref="task"/>
    /// </summary>
    class TaskDAO : DAO<task>, ITaskDAO
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        public TaskDAO() : base() { }

        /// <summary>
        /// Recherche des Task qui ne sont pas compétés
        /// </summary>
        /// <param name="groupID"></param>
        /// <returns></returns>
        public IEnumerable<task> GetGroupTasks(object groupID, bool completed)
        {
            try
            {
                using (var context = new pigeonsEntities1())
                {
                    Expression<Func<task, bool>> filter = (t => t.Group_ID == (int)groupID && t.Is_completed == completed);
                    return Get(context, filter).OrderBy(t => t.Task_Start);
                }                
            }
            catch (Exception ex) when (ex is EntityException || ex is DAOException)
            {
                throw new DAOException(ex.Message);
            }
        }

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

            try
            {
                switch (columnName.ToLower())
                {
                    case task.COLUMN_GROUP_ID:
                        filter = (t => t.Group_ID == (int)value);
                        break;
                    case task.COLUMN_DESCRIPTION:
                        filter = (t => t.Description.ToLower().Contains(((string)value).ToLower()));
                        break;
                    case task.COLUMN_TASK_START:
                        //filter = (t => t.Task_Start.Value.Date == ((DateTime)value).Date);
                        break;
                    case task.COLUMN_TASK_END:
                        //filter = (t => t.Task_End.Value.Date == ((DateTime)value).Date);
                        break;
                    case task.COLUMN_IS_COMPLETED:
                        filter = (t => t.Is_completed == (bool)value);
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
