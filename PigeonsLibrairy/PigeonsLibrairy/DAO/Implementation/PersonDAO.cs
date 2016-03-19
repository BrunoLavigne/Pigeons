using PigeonsLibrairy.DAO.Interface;
using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigeonsLibrairy.DAO.Implementation
{
    public class PersonDAO : DAO<person>, IPersonDAO
    {
        public PersonDAO(pigeonsEntities1 context) : base(context)
        {
        }
    }
}
