using Microsoft.VisualStudio.TestTools.UnitTesting;
using PigeonsLibrairy.DAO.Implementation;
using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTesting.TestDAO
{
    /// <summary>
    /// Summary description for personDAO_Test
    /// </summary>
    [TestClass]
    public class personDAO_Test
    {
        private PersonDAO personDAO { get; set; }
        private person personTest { get; set; }

        private const string PERSON_NAME = "Unit Tester";
        private const string PERSON_EMAIL = "unitTester@gmail.com";
        private const string PERSON_PROFILEURL = "http://www.profileurltest.com";
        private const string PERSON_PHONENUMBER = "5147778877";
        private const string PERSON_ORGANISATION = "Test Organization";
        private const string PERSON_POSITION = "Test Position";
        private const string PERSON_DESCRIPTION = "Test Description";
        private const string PERSON_PASSWORD = "Test16452$%@!@#!";
        private DateTime PERSON_BIRTHDATE = DateTime.Parse("1980-01-15");
        private DateTime PERSON_INSCRIPTIONDATE = DateTime.Parse("2016-04-14");

        /// <summary>
        /// Création du DAO et d'une person pour les tests
        /// </summary>
        [TestInitialize()]
        public void MyTestInitialize()
        {
            personDAO = new PersonDAO();

            personTest = new person();

            personTest.Name = PERSON_NAME;
            personTest.Email = PERSON_EMAIL;
            personTest.Profile_picture_link = PERSON_PROFILEURL;
            personTest.Inscription_date = PERSON_INSCRIPTIONDATE;
            personTest.Birth_date = PERSON_BIRTHDATE;
            personTest.Phone_number = PERSON_PHONENUMBER;
            personTest.Organization = PERSON_ORGANISATION;
            personTest.Position = PERSON_POSITION;
            personTest.Description = PERSON_DESCRIPTION;
            personTest.Password = PERSON_PASSWORD;
        }

        /// <summary>
        /// Remet le DAO et la person à null
        /// </summary>
        [TestCleanup()]
        public void MyTestCleanup()
        {
            personDAO = null;
            personTest = null;
        }

        /// <summary>
        /// Test pour la méthode Insert de la classes <see cref="PigeonsLibrairy.DAO.Implementation.PersonDAO"/>
        /// Insertion d'une Person et validation de ses propriétés
        /// </summary>
        [TestMethod]
        public void TestInsertPerson()
        {
            using (var context = new pigeonsEntities1())
            {
                personDAO.Insert(context, personTest);
                context.SaveChanges();
                int insertedPersonID = personTest.Id;

                person actualPerson = personDAO.GetByID(context, insertedPersonID);

                Assert.AreEqual(PERSON_NAME, actualPerson.Name);
                Assert.AreEqual(PERSON_EMAIL, actualPerson.Email);
                Assert.AreEqual(PERSON_PROFILEURL, actualPerson.Profile_picture_link);
                Assert.AreEqual(PERSON_INSCRIPTIONDATE, actualPerson.Inscription_date);
                Assert.AreEqual(PERSON_BIRTHDATE, actualPerson.Birth_date);
                Assert.AreEqual(PERSON_PHONENUMBER, actualPerson.Phone_number);
                Assert.AreEqual(PERSON_ORGANISATION, actualPerson.Organization);
                Assert.AreEqual(PERSON_POSITION, actualPerson.Position);
                Assert.AreEqual(PERSON_DESCRIPTION, actualPerson.Description);
                Assert.AreEqual(PERSON_PASSWORD, actualPerson.Password);

                personDAO.Delete(context, insertedPersonID);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Test pour la méthode Delete de la classes <see cref="PigeonsLibrairy.DAO.Implementation.PersonDAO"/>
        /// Insertion d'une Person et validation de ses propriétés
        /// </summary>
        [TestMethod]
        public void TestDeletePerson()
        {
            using (var context = new pigeonsEntities1())
            {
                personDAO.Insert(context, personTest);
                context.SaveChanges();
                int insertedPersonID = personTest.Id;

                person actualPerson = personDAO.GetByID(context, insertedPersonID);
                Assert.AreEqual(personTest, actualPerson);

                personDAO.Delete(context, insertedPersonID);
                context.SaveChanges();

                person DeletedPerson = personDAO.GetByID(context, insertedPersonID);
                Assert.AreEqual(null, DeletedPerson);
            }
        }

        /// <summary>
        /// Test pour la méthode Update de la classes <see cref="PigeonsLibrairy.DAO.Implementation.PersonDAO"/>
        /// Insertion d'une Person et validation de ses propriétés
        /// </summary>
        [TestMethod]
        public void TestUpdatePerson()
        {
            const string expected_UpdatedName = "OMG I have a new name";

            using (var context = new pigeonsEntities1())
            {
                personDAO.Insert(context, personTest);
                context.SaveChanges();
                int insertedPersonID = personTest.Id;

                person actualPerson = personDAO.GetByID(context, insertedPersonID);
                actualPerson.Name = expected_UpdatedName;

                personDAO.Update(context, actualPerson);
                context.SaveChanges();

                person updatedPerson = personDAO.GetByID(context, insertedPersonID);
                Assert.AreEqual(expected_UpdatedName, updatedPerson.Name);

                personDAO.Delete(context, insertedPersonID);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Test pour la méthode GetBy column name de la classes <see cref="PigeonsLibrairy.DAO.Implementation.PersonDAO"/>
        /// Insertion d'une Person et validation de ses propriétés
        /// </summary>
        [TestMethod]
        public void TestGetByPerson()
        {
            using (var context = new pigeonsEntities1())
            {
                personDAO.Insert(context, personTest);
                context.SaveChanges();
                int insertedPersonID = personTest.Id;

                List<person> personByName = personDAO.GetBy(context, person.COLUMN_NAME, PERSON_NAME).ToList();
                Assert.AreEqual(PERSON_NAME, personByName[0].Name);

                List<person> personByEmail = personDAO.GetBy(context, person.COLUMN_EMAIL, PERSON_EMAIL).ToList();
                Assert.AreEqual(PERSON_EMAIL, personByEmail[0].Email);

                List<person> personByPhone = personDAO.GetBy(context, person.COLUMN_PHONE_NUMBER, PERSON_PHONENUMBER).ToList();
                Assert.AreEqual(PERSON_PHONENUMBER, personByEmail[0].Phone_number);

                personDAO.Delete(context, insertedPersonID);
                context.SaveChanges();
            }
        }
    }
}