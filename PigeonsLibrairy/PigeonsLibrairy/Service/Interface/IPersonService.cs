using PigeonsLibrairy.Model;
using System.Collections.Generic;

namespace PigeonsLibrairy.Service.Interface
{

    /// <summary>
    /// Interface pour les services sur la table person
    /// </summary>
    public interface IPersonService : IService<person>
    {
        bool registerNewUser(person newUser, string emailConfirmation, string passwordConfirmation);
        person loginValidation(string username, string password);
        person UpdatePerson(object personID, person updatedPerson);
    }
}
