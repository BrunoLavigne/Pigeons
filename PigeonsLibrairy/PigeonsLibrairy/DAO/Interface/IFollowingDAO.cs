﻿using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigeonsLibrairy.DAO.Interface
{
    public interface IFollowingDAO
    {
        IList<following> GetTheFollowers(pigeonsEntities1 context, int groupID);
    }
}
