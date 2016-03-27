using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PigeonsLibrairy.DAO.Implementation;
using PigeonsLibrairy.Service.Implementation;
using PigeonsLibrairy.Model;
using System.Data.Entity;

namespace UnitTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void InsertTest()
        {
            pigeonsEntities1 context = new pigeonsEntities1();
            PersonDAO personne = new PersonDAO(context);
            PersonService service = new PersonService(context);
            //personne.Insert()
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
