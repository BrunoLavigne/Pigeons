using PigeonsLibrairy.DAO.Interface;
using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigeonsLibrairy.DAO.Implementation
{
    public class FollowingDAO : DAO<following>, IFollowingDAO
    {
        public FollowingDAO(pigeonsEntities1 context) : base(context) { }
    }
}
