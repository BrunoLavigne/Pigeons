using PigeonsLibrairy.DAO.Implementation;
using PigeonsLibrairy.Exceptions;
using PigeonsLibrairy.Model;
using PigeonsLibrairy.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigeonsLibrairy.Service.Implementation
{
    /// <summary>
    /// Service de la table Type (<see cref="type"/>)
    /// </summary>
    public class TypeService : Service<type>, ITypeService
    {
        private TypeDAO typeDAO { get; set; }

        /// <summary>
        /// Constructeur
        /// </summary>
        public TypeService() : base()
        {
            typeDAO = new TypeDAO();
        }

        /// <summary>
        /// Appel le DAO pour trouver un type dans la base de donnée
        /// </summary>
        /// <param name="columnName">Le nom de la colonne pour la recherche</param>
        /// <param name="value">La valeur à rechercher</param>
        /// <returns>Une liste de type qui correspondent à la recherche</returns>
        public new IEnumerable<type> GetBy(string columnName, object value)
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
                    return typeDAO.GetBy(context, columnName, value);
                }
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }
    }
}
