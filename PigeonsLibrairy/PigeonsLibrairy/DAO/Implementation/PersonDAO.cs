using PigeonsLibrairy.DAO.Interface;
using PigeonsLibrairy.Model;

namespace PigeonsLibrairy.DAO.Implementation
{
    public class PersonDAO : DAO<person>, IPersonDAO
    {
        public PersonDAO(pigeonsEntities1 context) : base(context)
        {
        }
    }
}
