using PigeonsLibrairy.Model;
using System.Collections.Generic;

namespace PigeonsLibrairy.Service.Interface
{
    /// <summary>
    /// Interface de la classe <see cref="Implementation.TaskService"/>
    /// </summary>
    public interface ITaskService : IService<task>
    {
        IEnumerable<task> GetGroupTasks(object groupID, bool completed);
        task CreateNewTask(task newTask, object groupID, object personID);
        void UpdateTaskCompleted(object taskID, bool completed);
    }
}
