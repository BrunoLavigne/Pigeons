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

        public PersonService(pigeonsEntities1 context) : base(context)
        {
            personDAO = new PersonDAO(context);
        }

        public new IEnumerable<person> GetBy(string columnName, object value)
        {
            IEnumerable<person> personsList = new List<person>();

            if (columnName != "" && value != null)
            {
                personsList = personDAO.GetBy(columnName, value);
                return personsList;
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

            IEnumerable<person> personAlreadyExist = personDAO.GetBy(person.COLUMN_NAME.EMAIL.ToString(), newUser.Email);
            List<person> personAlreadyExistList = personAlreadyExist.ToList();

            if (personAlreadyExist.Count() > 0)
            {
                if (personAlreadyExistList[0].Email == newUser.Email)
                {
                    throw new ServiceException("This user exist already");
                }
            }

            newUser.Inscription_date = DateTime.Now;
            newUser.Profile_picture_link = "";
            Insert(newUser);
            context.SaveChanges();       
            userIsAdded = true;
        
            return userIsAdded;
        }

        /// <summary>
        /// Login a user
        /// </summary>
        /// <param name="username">The username of the user that want to log</param>
        /// <param name="password">The password of the user that want to log</param>
        /// <returns>True if the username and password match, false if not</returns>
        public bool loginValidation(string username, string password)
        {
            bool loginAccepted = false;

            if(username == null)
            {
                throw new ServiceException("The username is null");                
            }

            if (password == null)
            {
                throw new ServiceException("The password is null");
            }

            IEnumerable<person> existingPerson = personDAO.GetBy(person.COLUMN_NAME.EMAIL.ToString(), username);
            List<person> existingPersonList = existingPerson.ToList();

            if(existingPersonList.Count() > 0)
            {
                if(existingPersonList[0].Password == password)
                {
                    loginAccepted = true;
                }
            }

            return loginAccepted;
        }
    }
}
