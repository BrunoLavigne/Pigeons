using PigeonsLibrairy.DAO.Interface;
using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigeonsLibrairy.DAO.Implementation
{
    public class TypeDAO : DAO<type>, ITypeDAO
    {
        public TypeDAO(pigeonsEntities1 context) : base(context)
        {
        }

        public new IEnumerable<type> GetBy(string columnName, object value)
        {
            IEnumerable<type> typeList = new List<type>();

            switch (columnName.ToLower())
            {
                case "name":
                    typeList = Get(t => t.Name.ToLower().Equals(((string)value).ToLower()));
                    break;
                case "description":
                    typeList = Get(t => t.Description.ToLower().Contains(((string)value).ToLower()));
                    break;
                default:
                    break;
            }
            return typeList;
        }
    }
}
