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
    public class GroupDAO : DAO<group>, IGroupDAO
    {
        public GroupDAO() : base() {}

        public new IEnumerable<group> GetBy(pigeonsEntities1 context, string columnName, object value)
        {
            Expression<Func<group, bool>> filter = null;

            switch (columnName)
            {
                case group.COLUMN_NAME:
                    filter = (g => g.Name == (string)value);
                    break;
                case group.COLUMN_IS_ACTIVE:
                    filter = (g => g.Is_active == (bool)value);
                    break;
                case group.COLUMN_DESCRIPTION:
                    filter = (g => g.Description == (string)value);
                    break;
                case group.COLUMN_CREATION_DATE:
                    //groupList = dao.Get(g => DbFunctions.TruncateTime(g.Creation_date).Equals( ((DateTime)value).Date) );                    
                    break;
                default:
                    break;
            }
            return Get(context, filter);
        }
    }
}
