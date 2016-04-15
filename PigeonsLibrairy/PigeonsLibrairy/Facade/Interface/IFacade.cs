using PigeonsLibrairy.Model;
using System.Collections.Generic;

namespace PigeonsLibrairy.Facade.Interface
{
    /// <summary>
    /// Interface pour la classe <see cref="Implementation.Facade"/>
    /// </summary>
    public interface IFacade
    {
        #region Person

        person GetPersonByID(object personID);

        person UpdatePerson(object personID, person personToUpdate);

        List<person> GetPersonBy(string columnName, object value);

        #endregion Person

        #region Group

        group GetGroupByID(object groupID);

        #endregion Group

        #region File

        file InsertFileInfo(file fichier);

        #endregion File
    }
}