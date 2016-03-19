using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PigeonsLibrairy;
using PigeonsLibrairy.DAO.Implementation;
using PigeonsLibrairy.Controller;
using PigeonsLibrairy.Model;

namespace FunctionsTester
{
    public partial class Form1 : Form
    {

        private Controller controller { get; set; }

        public Form1()
        {
            InitializeComponent();

            controller = new Controller();     
        }

        /// <summary>
        /// Test personDAO insert
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            person personToInsert = new person();

            string birthDate = "1999-03-02";
            DateTime birthDateParsed = DateTime.Parse(birthDate);

            personToInsert.Name = "Bob";
            personToInsert.Email = "bob@gmail.com";
            personToInsert.Profile_picture_link = "http://bob.com";
            personToInsert.Inscription_date = DateTime.Now;
            personToInsert.Birth_date = birthDateParsed;
            personToInsert.Phone_number = "5145224949";
            personToInsert.Organization = "A simple test";
            personToInsert.Position = "The master tester";
            personToInsert.Description = "Burp";
            personToInsert.Password = "1234";

            // Insertion de la personne
            controller.PersonService.Insert(personToInsert);

            // Il faut faire le Save sinon l'ajout ne sera pas complété
            controller.Save();

            MessageBox.Show("Bob is now added to the database");
        }

        /// <summary>
        /// Test message DAO insert
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            group groupToAdd = new group();

            groupToAdd.Creation_date = DateTime.Now;
            groupToAdd.Description = "Group testing";
            groupToAdd.Name = "Group no.1";
            groupToAdd.Is_active = true;

            // Insertion du groupe
            controller.GroupService.Insert(groupToAdd);            
            // Save dans la DB
            controller.Save();

            MessageBox.Show("Group no.1 is now added to the database");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            message messageToAdd = new message();

            messageToAdd.Author_Id = 3;
            messageToAdd.Date_created = DateTime.Now;
            messageToAdd.Group_Id = 2;
            messageToAdd.Content = "Message in place";

            controller.MessageService.Insert(messageToAdd);
            controller.Save();

            MessageBox.Show("Message createrd");
        }

        /// <summary>
        /// Update a person exemple
        /// </summary>        
        private void button4_Click(object sender, EventArgs e)
        {
            person personToUpdate = controller.PersonService.GetByID(4);
            personToUpdate.Description = "Oh my god my description is updated";
            controller.PersonService.Update(personToUpdate);
            controller.Save();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
