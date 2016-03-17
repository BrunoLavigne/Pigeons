using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigeonsLibrairy.DAO.Interface
{
    interface IDAO<TEntity> where TEntity : class
    {
        void insert();
        void delete(object id);
        void save();
        void update();
    }
}
