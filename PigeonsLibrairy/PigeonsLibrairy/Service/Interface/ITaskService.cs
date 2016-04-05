using PigeonsLibrairy.Model;
using System.Collections.Generic;

namespace PigeonsLibrairy.Service.Interface
{
    /// <summary>
    /// Interface de la classe <see cref="Implementation.TaskService"/>
    /// </summary>
    public interface ITaskService : IService<task>
    {
        IEnumerable<task> GetAvailableTask(object groupID);
        task CreateNewTask(task newTask, object groupID, object personID);
        void TaskIsCompleted(object taskID);
    }
}
