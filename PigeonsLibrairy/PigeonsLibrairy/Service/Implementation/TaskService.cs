using PigeonsLibrairy.Model;
using PigeonsLibrairy.Service.Interface;
using PigeonsLibrairy.DAO.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PigeonsLibrairy.Exceptions;

namespace PigeonsLibrairy.Service.Implementation
{    
    public class TaskService : Service<task>, ITaskService
    {
        private TaskDAO taskDAO { get; set; }

        public TaskService(pigeonsEntities1 context) : base(context)
        {
            taskDAO = new TaskDAO(context);
        }

        public new IEnumerable<task> GetBy(string columnName, object value)
        {
            IEnumerable<task> taskList = new List<task>();

            if (columnName != "" && value != null)
            {
                taskList = taskDAO.GetBy(columnName, value);
                return taskList;
            }
            else
            {
                throw new ServiceException("You must provid the column name and a value");
            }
        }
    }
}
