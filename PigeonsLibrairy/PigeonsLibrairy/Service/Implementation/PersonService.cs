﻿using PigeonsLibrairy.Service.Interface;
using PigeonsLibrairy.Model;
using PigeonsLibrairy.DAO.Implementation;
using System;
using System.Collections.Generic;
using PigeonsLibrairy.Exceptions;
using System.Linq;
using PigeonsLibrairy.DAO.Interface;
using System.Text.RegularExpressions;

namespace PigeonsLibrairy.Service.Implementation
{
    /// <summary>
    /// Service pour la table Person (<see cref="person"/>)
    /// </summary>
    public class PersonService : Service<person>, IPersonService
    {
        private IPersonDAO personDAO { get; set; }

        /// <summary>
        /// Constructeur
        /// </summary>
        public PersonService() : base()
        {
            personDAO = new PersonDAO();
        }

        /// <summary>
        /// Appel le DAO pour trouver une person dans la table
        /// </summary>
        /// <param name="columnName">Le nom de la colonne pour la recherche</param>
        /// <param name="value">La valeur rechercher</param>
        /// <returns>Une liste de personne. Une liste vide sinon</returns>
        public new IEnumerable<person> GetBy(string columnName, object value)
        {
            if (columnName == "")
            {
                throw new ServiceException("La valeur de la colonne ne doit pas être null");
            }

            if (value == null)
            {
                throw new ServiceException("La valeur recherchée ne peut pas être null");
            }

            try
            {
                using (var context = new pigeonsEntities1())
                {                    
                    return personDAO.GetBy(context, columnName, value);
                }
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }           
        }

        /// <summary>
        /// Register a new user
        /// </summary>
        /// <param name="newUser">The user to be added</param>
        /// <returns>True if the user was added, false if not</returns>
        public bool RegisterNewUser(person newUser, string emailConfirmation, string passwordConfirmation)
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

            try
            {
                using (var context = new pigeonsEntities1())
                {
                    newUser.Inscription_date = DateTime.Now;
                    newUser.Profile_picture_link = "";
                    personDAO.Insert(context, newUser);
                    context.SaveChanges();
                    userIsAdded = true;
                }
                return userIsAdded;
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }

        /// <summary>
        /// Login a user
        /// </summary>
        /// <param name="username">The username of the user that want to log</param>
        /// <param name="password">The password of the user that want to log</param>
        /// <returns>True if the username and password match, false if not</returns>
        public person LoginValidation(string username, string password)
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

            try
            {
                List<person> existingPerson = (GetBy(person.COLUMN_EMAIL, username)).ToList();

                if (existingPerson.Count() > 0)
                {
                    if (existingPerson[0].Password == password)
                    {
                        loginAccepted = existingPerson[0];
                    }
                }

                return loginAccepted;
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }                
        }

        /// <summary>
        /// Updating a person
        /// </summary>
        /// <param name="personID">The ID of the person we want to update</param>
        /// <param name="updatedPerson">The person with the updated fields</param>
        /// <returns>The updated person</returns>
        public person UpdatePerson(object personID, person updatedPerson)
        {
            if (personID == null)
            {
                throw new ServiceException("The person ID is null");
            }

            if (updatedPerson == null)
            {
                throw new ServiceException("The person to update is null");
            }

            try
            {
                using (var context = new pigeonsEntities1())
                {

                    person validatePerson = GetByID(personID);

                    if (validatePerson == null)
                    {
                        throw new ServiceException("The person you are trying to update is not in the DB");
                    }

                    string phoneNumber = updatedPerson.Phone_number;

                    if (phoneNumber != "")
                    {
                        Regex pattern = new Regex("[()-]");
                        string formatedPhoneNumber = pattern.Replace(phoneNumber.Trim(), "");

                        if(formatedPhoneNumber.Count() <= 10)
                        {
                            updatedPerson.Phone_number = formatedPhoneNumber;
                        }
                        else
                        {
                            throw new ServiceException("Le numéro de téléphone n'est pas valide");
                        }
                    }

                    validatePerson = updatedPerson;
                    personDAO.Update(context, validatePerson);
                    context.SaveChanges();
                    return validatePerson;
                }
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }
        
        /// <summary>
        /// Recherche d'une Person qui inclu la person, ses following et ses group
        /// </summary>
        /// <param name="personID">Le ID de la personne</param>
        /// <returns>La person et ses information qui corresponde au ID. Null sinon</returns>
        public person GetPersonData(object personID)
        {
            if (personID == null)
            {
                throw new ServiceException("Erreur GetPersonDate : Le ID de la personne est null");
            }

            try
            {
                using(var context = new pigeonsEntities1())
                {
                    List<person> personList = personDAO.GetPersonData(context, personID).ToList();

                    if(personList.Count() != 1)
                    {
                        throw new ServiceException("Erreur personService GetPersonData : La requête ne retourne pas qu'une personne");
                    }

                    return personList[0];
                }
            }
            catch (DAOException daoException)
            {
                throw new ServiceException(daoException.Message);
            }
        }
    }
}
