using PigeonsLibrairy.DAO.Interface;
using PigeonsLibrairy.Exceptions;
using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Linq.Expressions;

namespace PigeonsLibrairy.DAO.Implementation
{
    /// <summary>
    /// DAO de la table <see cref="person"/>
    /// </summary>
    class PersonDAO : DAO<person>, IPersonDAO
    {
        public PersonDAO() : base() {}

        /// <summary>
        /// Get a person by searching a value in a column
        /// </summary>
        /// <param name="context">The connection</param>
        /// <param name="columnName">The name of the column in the table</param>
        /// <param name="value">The value to search</param>
        /// <returns>A list of person that match the query</returns>
        public new IEnumerable<person> GetBy(pigeonsEntities1 context, string columnName, object value)
        {
            Expression<Func<person, bool>> filter = null;

            try
            {
                switch (columnName.ToLower())
                {
                    case person.COLUMN_NAME:
                        filter = (p => p.Name.ToLower() == ((string)value).ToLower());
                        break;
                    case person.COLUMN_EMAIL:
                        filter = (p => p.Email.ToLower() == ((string)value).ToLower());
                        break;
                    case person.COLUMN_PASSWORD:
                        filter = (p => p.Password == (string)value);
                        break;
                    case person.COLUMN_INSCRIPTION_DATE:
                        break;
                    case person.COLUMN_BIRTH_DATE:
                        break;
                    case person.COLUMN_PHONE_NUMBER:
                        filter = (p => p.Phone_number.ToLower() == ((string)value).ToLower());
                        break;
                    case person.COLUMN_ORGANIZATION:
                        filter = (p => p.Organization.ToLower() == ((string)value).ToLower());
                        break;
                    case person.COLUMN_POSITION:
                        filter = (p => p.Position.ToLower() == ((string)value).ToLower());
                        break;
                    case person.COLUMN_DESCRIPTION:
                        filter = (p => p.Description.ToLower().Contains(((string)value).ToLower()));
                        break;
                    case person.COLUMN_ALL:
                        filter = (p => p.Email.ToLower().Contains(((string)value).ToLower()) || p.Name.ToLower().Contains(((string)value).ToLower()));
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

        /// <summary>
        /// Recherche dans la BD les informations (person/following/group) pour une Person
        /// </summary>
        /// <param name="context">La connection à la base de données</param>
        /// <param name="personID">Le ID de la personne</param>
        /// <returns>Une liste qui contient la personne ses following et ses groupes</returns>
        public IEnumerable<person> GetPersonData(pigeonsEntities1 context, object personID)
        {
            Expression<Func<person, bool>> filter = (p => p.Id == (int)personID && p.followings.Any(f => f.Is_active && f.group.Is_active));
            string includedProperty = "followings";
            return Get(context, filter, null, includedProperty);
        }
    }
}
