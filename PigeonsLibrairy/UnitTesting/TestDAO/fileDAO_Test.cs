using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PigeonsLibrairy.DAO.Implementation;
using PigeonsLibrairy.Model;

namespace UnitTesting.TestDAO
{
    /// <summary>
    /// Test des opération CRUD de la classe <see cref="FileDAO"/> pour la table <see cref="file"/>
    /// </summary>
    [TestClass]
    public class fileDAO_Test
    {
        private FileDAO fileDAO { get; set; }
        private file fileTest { get; set; }

        private const int FILE_GROUP_ID = 16;
        private const string FILE_NAME = "Doc";
        private const string FILE_URL = "Mes affaires/Doc";
        private DateTime FILE_CREATION_DATE = DateTime.Now;

        /// <summary>
        /// Création du DAO et d'une file pour les tests
        /// </summary>
        [TestInitialize()]
        public void MyTestInitialize()
        {
            fileDAO = new FileDAO();

            fileTest = new file();

            fileTest.Group_ID = FILE_GROUP_ID;
            fileTest.FileName = FILE_NAME;
            fileTest.FileURL = FILE_URL;
            fileTest.Creation_Date = FILE_CREATION_DATE;
        }

        /// <summary>
        /// Remet le DAO et le file à null
        /// </summary>
        [TestCleanup()]
        public void MyTestCleanup()
        {
            fileDAO = null;
            fileTest = null;
        }

        /// <summary>
        /// Test pour la méthode Insert de la classes <see cref="PigeonsLibrairy.DAO.Implementation.FileDAO"/>
        /// Insertion d'une File et validation de ses propriétés
        /// </summary>
        [TestMethod]
        public void TestInsertFile()
        {
            using (var context = new pigeonsEntities1())
            {
                fileDAO.Insert(context, fileTest);
                context.SaveChanges();
                int insertedFileId = fileTest.ID;

                file actualFile = fileDAO.GetByID(context, insertedFileId);

                Assert.AreEqual(FILE_GROUP_ID, actualFile.Group_ID);
                Assert.AreEqual(FILE_NAME, actualFile.FileName);
                Assert.AreEqual(FILE_URL, actualFile.FileURL);
                Assert.AreEqual(FILE_CREATION_DATE, actualFile.Creation_Date);

                fileDAO.Delete(context, insertedFileId);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Test pour la méthode Delete de la classes <see cref="PigeonsLibrairy.DAO.Implementation.FileDAO"/>
        /// Insertion d'une File et validation de ses propriétés
        /// </summary>
        [TestMethod]
        public void TestDeleteFile()
        {
            using (var context = new pigeonsEntities1())
            {
                fileDAO.Insert(context, fileTest);
                context.SaveChanges();
                int insertedFileId = fileTest.ID;

                file actualFile = fileDAO.GetByID(context, insertedFileId);
                Assert.AreEqual(fileTest, actualFile);

                fileDAO.Delete(context, insertedFileId);
                context.SaveChanges();

                file DeletedFile = fileDAO.GetByID(context, insertedFileId);
                Assert.AreEqual(null, DeletedFile);
            }
        }

        /// <summary>
        /// Test pour la méthode Update de la classes <see cref="PigeonsLibrairy.DAO.Implementation.FileDAO"/>
        /// Insertion d'une File et validation de ses propriétés
        /// </summary>
        [TestMethod]
        public void TestUpdateFile()
        {
            const string expected_UpdatedFileName = "script";

            using (var context = new pigeonsEntities1())
            {
                fileDAO.Insert(context, fileTest);
                context.SaveChanges();
                int insertedFileID = fileTest.ID;

                file actualFile = fileDAO.GetByID(context, insertedFileID);
                actualFile.FileName = expected_UpdatedFileName;

                fileDAO.Update(context, actualFile);
                context.SaveChanges();

                file updatedFile = fileDAO.GetByID(context, insertedFileID);
                Assert.AreEqual(expected_UpdatedFileName, updatedFile.FileName);

                fileDAO.Delete(context, insertedFileID);
                context.SaveChanges();
            }
        }
    }
}
