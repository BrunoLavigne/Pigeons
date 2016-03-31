using PigeonsLibrairy.Model;
using System.Collections.Generic;

namespace PigeonsLibrairy.Service.Interface
{
    public interface IProjectService : IService<project>
    {
        project CreateNewProject(project aProject, object groupID);
        IEnumerable<project> GetProjectsFromGroup(object groupID);
    }
}
