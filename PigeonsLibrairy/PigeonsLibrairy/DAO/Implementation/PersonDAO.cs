using PigeonsLibrairy.DAO.Interface;
using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PigeonsLibrairy.DAO.Implementation
{
    public class PersonDAO : DAO<person>, IPersonDAO
    {
        public PersonDAO() : base() {}

        public new IEnumerable<person> GetBy(pigeonsEntities1 context, string columnName, object value)
        {
            Expression<Func<person, bool>> filter = null;            

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
    }
}
