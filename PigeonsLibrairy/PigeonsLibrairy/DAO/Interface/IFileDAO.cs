using PigeonsLibrairy.Model;
using System.Collections.Generic;

namespace PigeonsLibrairy.DAO.Interface
{
    /// <summary>
    /// Interface de la classe <see cref="Implementation.FileDAO"/>
    /// </summary>
    internal interface IFileDAO : IDAO<file>
    {
        IEnumerable<file> GetFilesByGroup(pigeonsEntities1 context, object groupID);

        IEnumerable<file> GetByFilePath(pigeonsEntities1 context, object filePath);
    }
}