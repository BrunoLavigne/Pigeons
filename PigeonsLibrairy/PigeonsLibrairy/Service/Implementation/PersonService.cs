using PigeonsLibrairy.Service.Interface;
using PigeonsLibrairy.Model;
using PigeonsLibrairy.DAO.Implementation;
using System;
using System.Collections.Generic;
using PigeonsLibrairy.Exceptions;
using System.Linq;

namespace PigeonsLibrairy.Service.Implementation
{
    public class PersonService : Service<person>, IPersonService
    {
        private PersonDAO personDAO { get; set; }

        public PersonService() : base()
        {
            personDAO = new PersonDAO();
        }

        public new IEnumerable<person> GetBy(string columnName, object value)
        {
            IEnumerable<person> personsList = new List<person>();

            if (columnName != "" && value != null)
            {
                using(var context = new pigeonsEntities1())
                {
                    personsList = personDAO.GetBy(context, columnName, value);
                    return personsList;
                }                
            }
            else
            {
                throw new ServiceException("You must provid the column name and a value");
            }            
        }

        /// <summary>
        /// Register a new user
        /// </summary>
        /// <param name="newUser">The user to be added</param>
        /// <returns>True if the user was added, false if not</returns>
        public bool registerNewUser(person newUser, string emailConfirmation, string passwordConfirmation)
        {
            bool userIsAdded = false;

            if(newUser == null)
            {
                throw new ServiceException("The newUser is null");
            }

            if(newUser.Email != emailConfirmation)
            {
                throw new ServiceException("The email doesnt match");
            }

            if(newUser.Password != passwordConfirmation)
            {
                throw new ServiceException("The password doesnt match");
            }

            List<person> personAlreadyExist = (GetBy(person.COLUMN_EMAIL, newUser.Email)).ToList();            

            if (personAlreadyExist.Count() > 0)
            {
                if (personAlreadyExist[0].Email == newUser.Email)
                {
                    throw new ServiceException("This user exist already");
                }
            }

            using(var context = new pigeonsEntities1())
            {
                newUser.Inscription_date = DateTime.Now;
                newUser.Profile_picture_link = "";
                personDAO.Insert(context, newUser);
                context.SaveChanges();
                userIsAdded = true;
            }            
        
            return userIsAdded;
        }

        /// <summary>
        /// Login a user
        /// </summary>
        /// <param name="username">The username of the user that want to log</param>
        /// <param name="password">The password of the user that want to log</param>
        /// <returns>True if the username and password match, false if not</returns>
        public person loginValidation(string username, string password)
        {
            person loginAccepted = null;

            if(username == null)
            {
                throw new ServiceException("The username is null");                
            }

            if (password == null)
            {
                throw new ServiceException("The password is null");
            }

            List<person> existingPerson = (GetBy(person.COLUMN_EMAIL, username)).ToList();            

            if(existingPerson.Count() > 0)
            {
                if(existingPerson[0].Password == password)
                {
                    loginAccepted = existingPerson[0];
                }
            }

            return loginAccepted;
        }

        /// <summary>
        /// Updating a person
        /// </summary>
        /// <param name="personID">The ID of the person we want to update</param>
        /// <param name="updatedPerson">The person with the updated fields</param>
        /// <returns>The updated person</returns>
        public person UpdatePerson(int personID, person updatedPerson)
        {
            if(personID == 0)
            {
                throw new ServiceException("The person ID is null");
            }

            if (updatedPerson == null)
            {
                throw new ServiceException("The person to update is null");
            }

            using(var context = new pigeonsEntities1())
            {
                try
                {
                    person validatePerson = GetByID(personID);

                    if(validatePerson == null)
                    {
                        throw new ServiceException("The person you are trying to update is not in the DB");
                    }

                    validatePerson = updatedPerson;
                    personDAO.Update(context, validatePerson);
                    context.SaveChanges();
                    return validatePerson;
                }
                catch
                {
                    throw new ServiceException("Impossible to update");
                }
            }
        }
    }
}
