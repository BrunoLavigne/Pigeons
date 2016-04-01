using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PigeonsLibrairy.Model;
using PigeonsLibrairy.DAO.Implementation;

namespace UnitTesting
{
    [TestClass]
    public class UnitTest1
    {
        pigeonsEntities1 context = new pigeonsEntities1();
        person personToTest = new person();
        [TestMethod]
        public void InsertTest()
        {
            personToTest.Name = "Toto";
            personToTest.Email = "toto@gmail.com";
            personToTest.Profile_picture_link = "http://toto.com";
            personToTest.Inscription_date = DateTime.Now;
            personToTest.Birth_date = DateTime.Parse("1980-01-15");
            personToTest.Phone_number = "5141234567";
            personToTest.Organization = "Toto Inc";
            personToTest.Position = "Analyst";
            personToTest.Description = "YOLO";
            personToTest.Password = "123456";

            PersonDAO personDAO = new PersonDAO();

            personDAO.Insert(context, personToTest);
        }

        [TestMethod]
        public void GetByIdTest()
        {

        }

        [TestMethod]
        public void UpdateTest()
        {

        }

        [TestMethod]
        public void DeleteTest()
        {

        }
    }
}
