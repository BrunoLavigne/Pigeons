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
    public class TypeService : Service<type>, ITypeService
    {
        private TypeDAO typeDAO { get; set; }

        public TypeService() : base()
        {
            typeDAO = new TypeDAO();
        }

        public new IEnumerable<type> GetBy(string columnName, object value)
        {
            IEnumerable<type> typeList = new List<type>();

            if (columnName != "" && value != null)
            {
                using(var context = new pigeonsEntities1())
                {
                    typeList = typeDAO.GetBy(context, columnName, value);
                    return typeList;
                }
            }
            else
            {
                throw new ServiceException("You must provid the column name and a value");
            }
        }
    }
}
