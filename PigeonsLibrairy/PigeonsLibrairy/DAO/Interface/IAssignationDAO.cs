using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigeonsLibrairy.DAO.Interface
{
    /// <summary>
    /// Interface de la classe <see cref="Implementation.AssignationDAO"/>
    /// </summary>
    internal interface IAssignationDAO : IDAO<assignation>
    {
        assignation GetByID(pigeonsEntities1 context, object personID, object taskID);
    }
}