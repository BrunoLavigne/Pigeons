using PigeonsLibrairy.Service.Interface;
using PigeonsLibrairy.Model;

namespace PigeonsLibrairy.Service.Implementation
{
    public class PersonService : Service<person>, IPersonService
    {
        public PersonService(pigeonsEntities1 context) : base(context)
        {
        }
    }
}
