using PigeonsLibrairy.Service.Interface;
using PigeonsLibrairy.Model;
using PigeonsLibrairy.DAO.Implementation;
using System;
using System.Collections.Generic;
using PigeonsLibrairy.Exceptions;

namespace PigeonsLibrairy.Service.Implementation
{
    public class PersonService : Service<person>, IPersonService
    {
        private PersonDAO personDAO { get; set; }

        public PersonService(pigeonsEntities1 context) : base(context)
        {
            personDAO = new PersonDAO(context);
        }

        public new IEnumerable<person> GetBy(string columnName, object value)
        {
            IEnumerable<person> personsList = new List<person>();

            if (columnName != "" && value != null)
            {
                personsList = personDAO.GetBy(columnName, value);
                return personsList;
            }
            else
            {
                throw new ServiceException("You must provid the column name and a value");
            }            
        }
    }
}
