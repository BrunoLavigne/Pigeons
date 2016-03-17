using PigeonsLibrairy.DAO;
using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigeonsLibrairy.Controller
{
    public class Controller : IDisposable
    {
        private pigeonsEntities1 context = new pigeonsEntities1();
        private GenericDAO<person> personDAO;

        public GenericDAO<person> PersonDAO
        {
            get
            {
                if(this.personDAO == null)
                {
                    this.personDAO = new GenericDAO<person>(context);
                }
                return personDAO;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
