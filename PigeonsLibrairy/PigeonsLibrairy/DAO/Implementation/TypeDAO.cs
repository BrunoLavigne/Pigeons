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
    /// DAO de la table <see cref="type"/>
    /// </summary>
    class TypeDAO : DAO<type>, ITypeDAO
    {
        public TypeDAO() : base() { }

        /// <summary>
        /// Get a type by searching a value in a column
        /// </summary>
        /// <param name="context">The connection</param>
        /// <param name="columnName">The name of the column in the table</param>
        /// <param name="value">The value to search</param>
        /// <returns>A list of type that match the query</returns>
        public new IEnumerable<type> GetBy(pigeonsEntities1 context, string columnName, object value)
        {
            Expression<Func<type, bool>> filter = null;

            try
            {
                switch (columnName.ToLower())
                {
                    case type.COLUMN_NAME:
                        filter = (t => t.Name.ToLower().Equals(((string)value).ToLower()));
                        break;
                    case type.COLUMN_DESCRIPTION:
                        filter = (t => t.Description.ToLower().Contains(((string)value).ToLower()));
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
