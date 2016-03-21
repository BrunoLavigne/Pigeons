using PigeonsLibrairy.DAO.Interface;
using PigeonsLibrairy.Model;

namespace PigeonsLibrairy.DAO.Implementation
{
    public class ProjectDAO : DAO<project>, IProjectDAO
    {
        public ProjectDAO(pigeonsEntities1 context) : base(context) { }
    }
}
