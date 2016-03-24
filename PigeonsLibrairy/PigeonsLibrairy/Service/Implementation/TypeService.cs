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

        public TypeService(pigeonsEntities1 context) : base(context)
        {
            typeDAO = new TypeDAO(context);
        }

        public new IEnumerable<type> GetBy(string columnName, object value)
        {
            IEnumerable<type> typeList = new List<type>();

            if (columnName != "" && value != null)
            {
                typeList = typeDAO.GetBy(columnName, value);
                return typeList;
            }
            else
            {
                throw new ServiceException("You must provid the column name and a value");
            }
        }
    }
}
