using PigeonsLibrairy.Model;
using System.Collections.Generic;

namespace PigeonsLibrairy.Service.Interface
{
    /// <summary>
    /// Interface de la classe <see cref="Implementation.ProjectService"/>
    /// </summary>
    public interface IProjectService : IService<project>
    {
        project CreateNewProject(project aProject, object groupID);
        IEnumerable<project> GetProjectsFromGroup(object groupID);
    }
}
