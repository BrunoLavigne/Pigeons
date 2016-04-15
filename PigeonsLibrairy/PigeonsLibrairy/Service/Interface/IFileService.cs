using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigeonsLibrairy.Service.Interface
{
    /// <summary>
    /// Interface de la classe <see cref="Implementation.FileService"/>
    /// </summary>
    internal interface IFileService : IService<file>
    {
        IEnumerable<file> GetFilesByGroup(object groupID);

        file InsertFileInformations(file newFile);

        void DeleteFileByFilePath(object filePath);
    }
}