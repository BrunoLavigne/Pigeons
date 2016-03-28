using PigeonsLibrairy.DAO.Interface;
using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PigeonsLibrairy.DAO.Implementation
{
    public class TypeDAO : DAO<type>, ITypeDAO
    {
        public TypeDAO() : base() {}

        public new IEnumerable<type> GetBy(pigeonsEntities1 context, string columnName, object value)
        {
            Expression<Func<type, bool>> filter = null;            

            switch (columnName.ToLower())
            {
                case type.COLUMN_NAME:
                    filter = (t => t.Name.ToLower().Equals(((string)value).ToLower()));
                    break;
                case type.COLUMN_DESCRIPTION:
                    filter = (t => t.Description.ToLower().Contains(((string)value).ToLower()));
                    break;
                default:
                    break;
            }
            return Get(context, filter);
        }
    }
}
