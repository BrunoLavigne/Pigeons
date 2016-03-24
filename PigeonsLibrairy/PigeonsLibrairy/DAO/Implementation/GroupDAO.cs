using PigeonsLibrairy.DAO.Interface;
using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigeonsLibrairy.DAO.Implementation
{
    public class GroupDAO : DAO<group>, IGroupDAO
    {
        public GroupDAO(pigeonsEntities1 context) : base(context)
        {

        }

        public new IEnumerable<group> GetBy(string columnName, object value)
        {
            IEnumerable<group> groupList = new List<group>();

            switch (columnName.ToLower())
            {
                case "name":
                    groupList = Get(g => g.Name == (string)value);
                    break;
                case "is_active":
                    groupList = Get(g => g.Is_active == (bool)value);
                    break;
                case "description":
                    groupList = Get(g => g.Description == (string)value);
                    break;
                case "creation_date":
                    //groupList = dao.Get(g => DbFunctions.TruncateTime(g.Creation_date).Equals( ((DateTime)value).Date) );                    
                    break;
                default:
                    break;
            }
            return groupList;
        }
    }
}
