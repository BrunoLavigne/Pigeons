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
            MessageDAO messagedao = new MessageDAO();
            messagedao.delete(1);
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            person getPersonById = controller.PersonDAO.GetByID(1);

            MessageBox.Show(getPersonById.Name);                                 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            person personAdd = new person();

            personAdd.Name = "Jimmy";
            personAdd.Email = "jimmy@gmail.com";
            personAdd.Profile_picture_link = "http://jimmy.com";
            personAdd.Birth_date = DateTime.Now.Date;
            personAdd.Phone_number = "5145224949";
            personAdd.Organization = "A simple test";
            personAdd.Position = "The master tester";
            personAdd.Description = "Burp";
            personAdd.Password = "1234";

            controller.PersonDAO.Insert(personAdd);
            controller.Save();

            MessageBox.Show("Jimmy is added to the database");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var persons = controller.PersonDAO.Get();

            List<person> lesPersonnes = new List<person>();
            lesPersonnes = persons.ToList();

            string personList = "The person name in the database";

            foreach(person p in lesPersonnes)
            {
                personList += p.Name + "\n";                
            }
            MessageBox.Show(personList);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            person getPersonById = controller.PersonDAO.GetByID( 3 );
            controller.PersonDAO.Delete( 3 );
            controller.Save();

            MessageBox.Show(getPersonById.Name + " as been deleted id : " + getPersonById.Id);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string message = "";

            person personToUpdate = controller.PersonDAO.GetByID( 1 );

            message += "before : " + personToUpdate.Description + "\n";

            personToUpdate.Description = "OMG I WAS UPDATED";

            controller.PersonDAO.Update(personToUpdate);
            controller.Save();

            person personUpdated = controller.PersonDAO.GetByID(1);

            message += "after : " + personUpdated.Description;

            MessageBox.Show(message);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not yet");
        }
    }
}
