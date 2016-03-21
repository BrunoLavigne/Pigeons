using PigeonsLibrairy.Model;
using System.Collections.Generic;

namespace PigeonsLibrairy.Service.Interface
{

    /// <summary>
    /// Interface pour les services sur la table person
    /// </summary>
    public interface IPersonService
    {
        IEnumerable<person> GetPersonsBy(string columnName, object value);
    }
}
