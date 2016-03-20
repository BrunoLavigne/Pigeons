using PigeonsLibrairy.Service.Interface;
using PigeonsLibrairy.Model;
using PigeonsLibrairy.DAO.Implementation;

namespace PigeonsLibrairy.Service.Implementation
{
    public class PersonService : Service<person>, IPersonService
    {
        private PersonDAO personDAO { get; set; }

        public PersonService(pigeonsEntities1 context) : base(context)
        {
            personDAO = new PersonDAO(context);
        }
    }
}
