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
    /// <summary>
    /// Service pour la table Task (<see cref="task"/>)
    /// </summary>         
    public class TaskService : Service<task>, ITaskService
    {
        private TaskDAO taskDAO { get; set; }

        /// <summary>
        /// Constructeur
        /// </summary>
        public TaskService() : base()
        {
            taskDAO = new TaskDAO();
        }

        /// <summary>
        /// Appel le DAO pour effectuer la recherche de task
        /// </summary>
        /// <param name="columnName">Le nom de la colonne pour la recherche</param>
        /// <param name="value">La valeur rechercher</param>
        /// <returns>Une liste de task. Une liste vide sinon</returns>
        public new IEnumerable<task> GetBy(string columnName, object value)
        {
            if (columnName == null || columnName == "")
            {
                throw new ServiceException("La valeur de la colonne ne doit pas être null");
            }

            if (value == null || (string)value == "")
            {
                throw new ServiceException("La valeur recherchée ne peut pas être null");
            }

            try
            {
                using (var context = new pigeonsEntities1())
                {
                    return taskDAO.GetBy(context, columnName, value);
                }
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }
    }
}
