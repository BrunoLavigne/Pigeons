using PigeonsLibrairy.DAO.Interface;
using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigeonsLibrairy.DAO.Implementation
{
    public class TaskDAO : DAO<task>, ITaskDAO
    {
        public TaskDAO(pigeonsEntities1 context) : base(context)
        {
        }

        public new IEnumerable<task> GetBy(string columnName, object value)
        {
            IEnumerable<task> taskList = new List<task>();

            switch (columnName.ToLower())
            {
                case "project_id":
                    taskList = Get(t => t.Project_ID == (int)value);
                    break;
                case "description":
                    taskList = Get(t => t.Description.ToLower().Contains(((string)value).ToLower()));
                    break;
                case "date_due":
                    //taskList = Get(t => t.Date_due.Date == ((DateTime)value).Date);
                    break;
                case "is_completed":
                    taskList = Get(t => t.Is_completed == (bool)value);
                    break;     
                default:
                    break;
            }
            return taskList;
        }
    }
}
