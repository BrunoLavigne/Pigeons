using PigeonsLibrairy.Model;
using System.Collections.Generic;

namespace PigeonsLibrairy.Service.Interface
{

    /// <summary>
    /// Interface pour la classe <see cref="Implementation.PersonService"/>
    /// </summary>
    public interface IPersonService : IService<person>
    {
        bool RegisterNewUser(person newUser, string emailConfirmation, string passwordConfirmation);
        person LoginValidation(string username, string password);
        person UpdatePerson(object personID, person updatedPerson);
    }
}
