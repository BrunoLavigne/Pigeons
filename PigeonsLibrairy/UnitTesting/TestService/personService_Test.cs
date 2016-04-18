using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PigeonsLibrairy.Exceptions;
using PigeonsLibrairy.Model;
using PigeonsLibrairy.Service.Implementation;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace UnitTesting.TestService
{
    /// <summary>
    /// Test des opération CRUD de la classe <see cref="PersonService"/> pour la table <see cref="person"/>
    /// </summary>
    [TestClass]
    public class personService_Test
    {
        /// <summary>
        /// Le service à tester
        /// </summary>
        private PersonService personService { get; set; }

        /// <summary>
        /// Création du service pour les tests
        /// </summary>
        [TestInitialize()]
        public void MyTestInitialize()
        {
            personService = new PersonService();
        }

        /// <summary>
        /// Remise des variables è null
        /// </summary>
        [TestCleanup()]
        public void MyTestCleanup()
        {
            personService = null;
        }

        /// <summary>
        /// Test de la méthode <see cref="PersonService.RegisterNewUser(person, string, string)"/>
        /// La person à ajouter est null. Une ServiceException devrait être lancée
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ServiceException), "Une nouvelle personne null devrait lancer une ServiceException")]
        public void RegisterNewUserTest_nullPerson()
        {
            personService.RegisterNewUser(null, null, null);
        }

        /// <summary>
        /// Test de la méthode <see cref="PersonService.RegisterNewUser(person, string, string)"/>
        /// Le email n'est pas le même que celui de la confirmation. Une ServiceException devrait être lancée
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ServiceException), "Le email n'est pas le même que celui de la confirmation. Devrait lancer une ServiceException")]
        public void RegisterNewUserTest_DifferentEmail()
        {
            person person = new person();
            person.Email = "unittester@gmail.com";
            const string wrongEmailValidation = "gmail@unittester.com";

            personService.RegisterNewUser(person, wrongEmailValidation, null);
        }

        /// <summary>
        /// Test de la méthode <see cref="PersonService.RegisterNewUser(person, string, string)"/>
        /// La validation du mot de passe n'est pas bonne. Une ServiceException devrait être lancée
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ServiceException), "La validation du mot de passe n'est pas bonne. Devrait lancer une ServiceException")]
        public void RegisterNewUserTest_DifferentPassword()
        {
            person person = new person();
            person.Email = "unittester@gmail.com";
            person.Password = "1234";

            const string emailValidtion = "unittester@gmail.com";
            const string wrongPwValidation = "4321";

            personService.RegisterNewUser(person, emailValidtion, wrongPwValidation);
        }

        /// <summary>
        /// Test de la méthode <see cref="PersonService.RegisterNewUser(person, string, string)"/>
        /// La personne existe déjà. Une ServiceException devrait être lancée
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ServiceException), "La personne existe déjà. Devrait lancer une ServiceException")]
        public void RegisterNewUserTest_ExistingUser()
        {
            person person = personService.GetByID(3);
            personService.RegisterNewUser(person, person.Email, person.Password);
        }

        [TestMethod]
        [ExpectedException(typeof(ServiceException), "Le username est null. Devrait lancer une ServiceException")]
        public void LoginValidationTest_NullUsername()
        {
            personService.LoginValidation(null, "1234");
        }

        [TestMethod]
        public void LoginValidationTest_NullPassword()
        {
            person person = personService.GetByID(3);
            person validation = personService.LoginValidation(person.Email, person.Password);
            Assert.AreEqual(person.Name, validation.Name);
            Assert.AreEqual(person.Password, validation.Password);
            Assert.AreEqual(person.Email, validation.Email);
        }
    }
}