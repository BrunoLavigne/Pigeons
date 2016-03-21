using PigeonsLibrairy.Model;
using PigeonsLibrairy.Service.Interface;
using PigeonsLibrairy.DAO.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigeonsLibrairy.Service.Implementation
{    
    public class TaskService : Service<task>, ITaskService
    {
        private TaskDAO taskDAO { get; set; }

        public TaskService(pigeonsEntities1 context) : base(context)
        {
            taskDAO = new TaskDAO(context);
        }
    }
}
