using PigeonsLibrairy.DAO.Interface;
using PigeonsLibrairy.Model;
using System.Collections.Generic;

namespace PigeonsLibrairy.DAO.Implementation
{
    public class PersonDAO : DAO<person>, IPersonDAO
    {
        public PersonDAO(pigeonsEntities1 context) : base(context)
        {
        }

        public new IEnumerable<person> GetBy(string columnName, object value)
        {
            IEnumerable<person> personList = new List<person>();

            switch (columnName.ToLower())
            {
                case "name":
                    personList = Get(p => p.Name.ToLower() == ((string)value).ToLower());
                    break;
                case "email":
                    personList = Get(p => p.Email.ToLower() == ((string)value).ToLower());
                    break;
                case "password":
                    personList = Get(p => p.Password == (string)value);
                    break;
                case "inscription_date":
                    break;
                case "birth_date":
                    break;
                case "phone_number":
                    personList = Get(p => p.Phone_number.ToLower() == ((string)value).ToLower());
                    break;
                case "organisation":
                    personList = Get(p => p.Organization.ToLower() == ((string)value).ToLower());
                    break;
                case "position":
                    personList = Get(p => p.Position.ToLower() == ((string)value).ToLower());
                    break;
                case "description":
                    personList = Get(p => p.Description.ToLower().Contains(((string)value).ToLower()));
                    break;
                case "all":
                    personList = Get(p => p.Email.ToLower().Contains(((string)value).ToLower()) || p.Name.ToLower().Contains(((string)value).ToLower()));
                    break;
                default:
                    break;
            }
            return personList;
        }            
    }
}
