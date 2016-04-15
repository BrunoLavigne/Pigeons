using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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
        private PersonService personService { get; set; }

        private TestContext testContextInstance;

        [TestInitialize()]
        public void MyTestInitialize()
        {
            personService = new PersonService();
        }

        /// <summary>
        /// Création du service pour les tests
        /// </summary>
        [TestCleanup()]
        public void MyTestCleanup()
        {
            personService = null;
        }

        /// <summary>
        /// Remise du service è null à la fin de chaque test
        /// </summary>
        [TestMethod]
        public void RegisterNewUserTest()
        {
            var mockSet = new Mock<DbSet<person>>();

            var mockContext = new Mock<pigeonsEntities1>();
            mockContext.Setup(p => p.people).Returns(mockSet.Object);

            //var service = new BlogService(mockContext.Object);
            //service.AddBlog("ADO.NET Blog", "http://blogs.msdn.com/adonet");

            //mockSet.Verify(m => m.Add(It.IsAny<Blog>()), Times.Once());
            //mockContext.Verify(m => m.SaveChanges(), Times.Once());

            //personService.RegisterNewUser()
        }
    }
}