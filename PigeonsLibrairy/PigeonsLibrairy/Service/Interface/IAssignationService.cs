using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigeonsLibrairy.Service.Interface
{
    /// <summary>
    /// Interface de la classe <see cref="Implementation.AssignationService"/>
    /// </summary>
    public interface IAssignationService : IService<assignation>
    {
        assignation AssignTaskToPerson(assignation newAssignation);

        void RemoveAssignation(object taskID, object personID);
    }
}