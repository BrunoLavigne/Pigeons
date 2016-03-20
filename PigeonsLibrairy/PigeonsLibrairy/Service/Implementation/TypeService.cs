using PigeonsLibrairy.DAO.Implementation;
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
    }
}
