using PigeonsLibrairy.DAO.Interface;
using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigeonsLibrairy.DAO.Implementation
{
    public class DAO<TEntity> where TEntity : class
    {

        public DAO()
        {
            Console.WriteLine("in the DAO class");
        }

        public void delete()
        {
            Console.WriteLine("deleting");
        }

        public void delete(object id)
        {
            throw new NotImplementedException();
        }

        public void insert()
        {
            throw new NotImplementedException();
        }

        public void save()
        {
            throw new NotImplementedException();
        }

        public void update()
        {
            throw new NotImplementedException();
        }
    }
}
