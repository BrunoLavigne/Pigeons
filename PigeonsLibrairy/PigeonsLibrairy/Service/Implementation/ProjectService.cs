using PigeonsLibrairy.DAO.Implementation;
using PigeonsLibrairy.Model;
using PigeonsLibrairy.Service.Interface;

namespace PigeonsLibrairy.Service.Implementation
{
    public class ProjectService : Service<project>, IProjectService
    {
        private ProjectDAO projectDAO { get; set; }

        public ProjectService(pigeonsEntities1 context) : base(context)
        {
            projectDAO = new ProjectDAO(context);
        }
    }
}
