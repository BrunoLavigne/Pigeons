using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PigeonsLibrairy.DAO.Implementation;
using PigeonsLibrairy.Model;
using System.Linq;

namespace UnitTesting.TestDAO
{
    /// <summary>
    /// Test des opération CRUD de la classe <see cref="AssignationDAO"/> pour la table <see cref="assignation"/>
    /// </summary>
    [TestClass]
    public class assignationDAO_Test
    {
        private AssignationDAO assignationDAO { get; set; }
        private assignation assignationTest { get; set; }

        private const int ASSIGNATION_TASK_ID = 1;
        private const int ASSIGNATION_PERSON_ID = 3;

        /// <summary>
        /// Création du DAO et d'une assignation pour les tests
        /// </summary>
        [TestInitialize()]
        public void MyTestInitialize()
        {
            assignationDAO = new AssignationDAO();

            assignationTest = new assignation();

            assignationTest.Task_ID = ASSIGNATION_TASK_ID;
            assignationTest.Person_ID = ASSIGNATION_PERSON_ID;
        }

        /// <summary>
        /// Remet le DAO et l'assignation à null
        /// </summary>
        [TestCleanup()]
        public void MyTestCleanup()
        {
            assignationDAO = null;
            assignationTest = null;
        }

        /// <summary>
        /// Test pour la méthode Insert de la classes <see cref="PigeonsLibrairy.DAO.Implementation.AssignationDAO"/>
        /// Insertion d'une Assignation et validation de ses propriétés
        /// </summary>
        [TestMethod]
        public void TestInsertAssignation()
        {
            using (var context = new pigeonsEntities1())
            {
                assignationDAO.Insert(context, assignationTest);
                context.SaveChanges();
                int insertedAssignationID = assignationTest.ID;

                assignation actualAssignation = assignationDAO.GetByID(context, insertedAssignationID);

                Assert.AreEqual(ASSIGNATION_TASK_ID, actualAssignation.Task_ID);
                Assert.AreEqual(ASSIGNATION_PERSON_ID, actualAssignation.Person_ID);

                assignationDAO.Delete(context, insertedAssignationID);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Test pour la méthode Delete de la classes <see cref="PigeonsLibrairy.DAO.Implementation.AssignationDAO"/>
        /// Insertion d'une Assignation et validation de ses propriétés
        /// </summary>
        [TestMethod]
        public void TestDeleteAssignation()
        {
            using (var context = new pigeonsEntities1())
            {
                assignationDAO.Insert(context, assignationTest);
                context.SaveChanges();
                int insertedAssignationID = assignationTest.ID;

                assignation actualAssignation = assignationDAO.GetByID(context, insertedAssignationID);
                Assert.AreEqual(assignationTest, actualAssignation);

                assignationDAO.Delete(context, insertedAssignationID);
                context.SaveChanges();

                assignation DeletedAssignation = assignationDAO.GetByID(context, insertedAssignationID);
                Assert.AreEqual(null, DeletedAssignation);
            }
        }

        /// <summary>
        /// Test pour la méthode Update de la classes <see cref="PigeonsLibrairy.DAO.Implementation.AssignationDAO"/>
        /// Insertion d'une Assignation et validation de ses propriétés
        /// </summary>
        [TestMethod]
        public void TestUpdateAssignation()
        {
            const int expected_UpdatedPersonId = 16;

            using (var context = new pigeonsEntities1())
            {
                assignationDAO.Insert(context, assignationTest);
                context.SaveChanges();
                int insertedAssignationID = assignationTest.ID;

                assignation actualAssignation = assignationDAO.GetByID(context, insertedAssignationID);
                actualAssignation.Person_ID = expected_UpdatedPersonId;

                assignationDAO.Update(context, actualAssignation);
                context.SaveChanges();

                assignation updatedAssignation = assignationDAO.GetByID(context, insertedAssignationID);
                Assert.AreEqual(expected_UpdatedPersonId, updatedAssignation.Person_ID);

                assignationDAO.Delete(context, insertedAssignationID);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Test pour la méthode GetBy column name de la classes <see cref="PigeonsLibrairy.DAO.Implementation.AssignationDAO"/>
        /// Insertion d'une Assignation et validation de ses propriétés
        /// </summary>
        [TestMethod]
        public void TestGetByAssignation()
        {
            using (var context = new pigeonsEntities1())
            {
                assignationDAO.Insert(context, assignationTest);
                context.SaveChanges();
                int insertedAssignationID = assignationTest.ID;

                List<assignation> assignationByTaskId = assignationDAO.GetBy(context, assignation.COLUMN_TASK_ID, ASSIGNATION_TASK_ID).ToList();
                Assert.AreEqual(ASSIGNATION_TASK_ID, assignationByTaskId[0].Task_ID);

                List<assignation> assignationByPersonId = assignationDAO.GetBy(context, assignation.COLUMN_PERSON_ID, ASSIGNATION_PERSON_ID).ToList();
                Assert.AreEqual(ASSIGNATION_PERSON_ID, assignationByPersonId[0].Person_ID);

                assignationDAO.Delete(context, insertedAssignationID);
                context.SaveChanges();
            }
        }
    }
}
