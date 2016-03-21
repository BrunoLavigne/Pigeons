using PigeonsLibrairy.Service.Interface;
using PigeonsLibrairy.Model;
using PigeonsLibrairy.DAO.Implementation;
using System;
using System.Collections.Generic;

namespace PigeonsLibrairy.Service.Implementation
{
    public class PersonService : Service<person>, IPersonService
    {
        private PersonDAO personDAO { get; set; }

        public PersonService(pigeonsEntities1 context) : base(context)
        {
            personDAO = new PersonDAO(context);
        }

        public IEnumerable<person> GetPersonsBy(string columnName, object value)
        {

            IEnumerable<person> personsList = new List<person>();

            switch (columnName.ToLower())
            {
                case "name":
                    personsList = dao.Get(p => p.Name == (string)value);
                    break;
                case "email":
                    personsList = dao.Get(p => p.Email == (string)value);                 
                    break;
                case "password":
                    break;
                case "inscription_date":
                    break;
                case "birth_date":
                    break;
                case "phone_number":
                    break;
                case "organisation":
                    break;
                case "position":
                    break;
                case "description":
                    break;
                default:
                    break;

            }
            return personsList;
        }
    }
}
