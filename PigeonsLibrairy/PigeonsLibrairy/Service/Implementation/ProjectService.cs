using PigeonsLibrairy.DAO.Implementation;
using PigeonsLibrairy.Exceptions;
using PigeonsLibrairy.Model;
using PigeonsLibrairy.Service.Interface;
using System.Collections.Generic;

namespace PigeonsLibrairy.Service.Implementation
{
    public class ProjectService : Service<project>, IProjectService
    {
        private ProjectDAO projectDAO { get; set; }

        public ProjectService() : base()
        {
            projectDAO = new ProjectDAO();
        }

        public new IEnumerable<project> GetBy(string columnName, object value)
        {
            IEnumerable<project> projectList = new List<project>();

            if (columnName != "" && value != null)
            {
                using(var context = new pigeonsEntities1())
                {
                    projectList = projectDAO.GetBy(context, columnName, value);
                    return projectList;
                }
            }
            else
            {
                throw new ServiceException("You must provid the column name and a value");
            }
        }
    }
}
