using PigeonsLibrairy.DAO.Interface;
using PigeonsLibrairy.Exceptions;
using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq.Expressions;
using System.Linq;

namespace PigeonsLibrairy.DAO.Implementation
{
    /// <summary>
    /// DAO de la table <see cref="assignation"/>
    /// </summary>
    class AssignationDAO : DAO<assignation>, IAssignationDAO
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        public AssignationDAO() : base() { }

        /// <summary>
        /// Recherche d'une assignation par sa clé primaire
        /// </summary>
        /// <param name="context">La connexion</param>
        /// <param name="personID">Le ID de la person</param>
        /// <param name="taskID">Le ID de la Task</param>
        /// <returns>Une assignation si elle existe. Null sinon</returns>
        public assignation GetByID(pigeonsEntities1 context, object personID, object taskID)
        {
            Expression<Func<assignation, bool>> filter = (a => a.Person_ID == (int)personID && a.Task_ID == (int)taskID);
            IList<assignation> assignations = Get(context, filter).ToList();
            return (assignations.Count() == 1) ? assignations[0] : null;
        }

        /// <summary>
        /// Get an assignation by searching a value in a column
        /// </summary>
        /// <param name="context">The connection</param>
        /// <param name="columnName">The name of the column in the table</param>
        /// <param name="value">The value to search</param>
        /// <returns>A list of assignations that match the query</returns>
        public new IEnumerable<assignation> GetBy(pigeonsEntities1 context, string columnName, object value)
        {
            Expression<Func<assignation, bool>> filter = null;

            try
            {
                switch (columnName.ToLower())
                {
                    case assignation.COLUMN_PERSON_ID:
                        filter = (t => t.Person_ID == (int)value);
                        break;
                    case assignation.COLUMN_TASK_ID:
                        filter = (t => t.Task_ID == (int)value);
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
