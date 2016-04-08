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
using PigeonsLibrairy.Exceptions;
using System.Collections;

namespace FunctionsTester
{
    public partial class Form1 : Form
    {

        private MainController controller { get; set; }

        public Form1()
        {
            InitializeComponent();

            controller = new MainController();     
        }

        /// <summary>
        /// Test personDAO insert
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            person personToInsert = new person();

            personToInsert.Name                 = "Bob";
            personToInsert.Email                = "bob@gmail.com";
            personToInsert.Profile_picture_link = "http://bob.com";
            personToInsert.Inscription_date     = DateTime.Now;
            personToInsert.Birth_date           = DateTime.Parse("1999-03-02");
            personToInsert.Phone_number         = "5145224949";
            personToInsert.Organization         = "A simple test";
            personToInsert.Position             = "The master tester";
            personToInsert.Description          = "Burp";
            personToInsert.Password             = "1234";

            // Insertion de la personne
            controller.PersonService.Insert(personToInsert);            

            // Il faut faire le Save sinon l'ajout ne sera pas complété
            //controller.Save();

            MessageBox.Show("Bob is now added to the database");
        }

        /// <summary>
        /// Test message DAO insert
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            group groupToAdd = new group();

            groupToAdd.Creation_date    = DateTime.Now;
            groupToAdd.Description      = "Group testing";
            groupToAdd.Name             = "Group no.1";
            groupToAdd.Is_active        = true;

            // Insertion du groupe
            controller.GroupService.Insert(groupToAdd);            
            // Save dans la DB
            //controller.Save();

            MessageBox.Show("Group no.1 is now added to the database");
        }

        /// <summary>
        /// Creating a message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            message messageToAdd = new message();

            messageToAdd.Author_Id      = 3;
            messageToAdd.Date_created   = DateTime.Now;
            messageToAdd.Group_Id       = 2;
            messageToAdd.Content        = "Message in place";

            controller.MessageService.Insert(messageToAdd);            
            //controller.Save();            

            MessageBox.Show("Message created");
        }

        /// <summary>
        /// Update a person exemple
        /// </summary>        
        private void button4_Click(object sender, EventArgs e)
        {
            person personToUpdate = controller.PersonService.GetByID(4);
            personToUpdate.Description = "Oh my god my description is updated";
            controller.PersonService.Update(personToUpdate);
            //controller.Save();
        }

        /// <summary>
        /// Person following a group exemple
        /// </summary>
        private void button6_Click(object sender, EventArgs e)
        {
            following follow    = new following();
            follow.Person_Id    = 3;
            follow.Group_id     = 3;
            follow.Is_active    = true;
            follow.Is_admin     = true;
            follow.Last_checkin = DateTime.Now;

            controller.FollowingService.Insert(follow);

            try
            {
                //controller.Save();
                MessageBox.Show("Person id: 3 is now following groupe id: 2");
            }
            catch(ControllerException controllerException)
            {
                MessageBox.Show(controllerException.Message);
            }                        
        }

        /// <summary>
        /// Getting the list of the group a person is following exemple
        /// </summary>
        private void button5_Click(object sender, EventArgs e)
        {
            int personId = 3;

            IEnumerable<following> testList = controller.FollowingService.GetBy("person_id", personId);

            foreach(following f in testList)
            {
                group theGroupIamFollowing = controller.GroupService.GetByID(f.Group_id);
                MessageBox.Show("The person id 3 is following this groupe id : " + f.Group_id + " named : " + theGroupIamFollowing.Name);
            }
        }

        /// <summary>
        /// Dirty group creating and registering the person as following that new group
        /// </summary>        
        private void button8_Click(object sender, EventArgs e)
        {
            // User id 11 is creating a group from his dashboard so we are creating the group and adding him to that group
            int personId = 11;

            // Creating the new group
            group aNewGroup = new group();
            aNewGroup.Creation_date = DateTime.Now;
            aNewGroup.Description = "Creating a group and a following";
            aNewGroup.Name = "The group of person ID 11";
            aNewGroup.Is_active = true;

            // Insertion and saving of the group
            controller.GroupService.Insert(aNewGroup);
            //controller.Save();

            // Creating the following
            following personIsFollowing = new following();
            personIsFollowing.Person_Id = personId;
            personIsFollowing.Group_id = aNewGroup.Id; // The id of the group can be retreived right away without querying the DB
            personIsFollowing.Is_active = true;
            personIsFollowing.Is_admin = true;
            personIsFollowing.Last_checkin = DateTime.Now;

            // Insertion the the following
            controller.FollowingService.Insert(personIsFollowing);
            // Saving
            //controller.Save();

        }

        /// <summary>
        /// Creating a new group and following using the service and a transaction
        /// </summary>        
        private void button9_Click(object sender, EventArgs e)
        {
            // User id 11 is creating a group from his dashboard so we are creating the group and adding him to that group
            int personId = 11;

            // Creating the new group
            group aNewGroup = new group();
            aNewGroup.Creation_date = DateTime.Now;
            aNewGroup.Description = "Creating a group and a following";
            aNewGroup.Name = "The group of person ID 11";
            aNewGroup.Is_active = true;

            // Insertion and saving of the group
            controller.GroupService.CreateNewGroupAndRegister(aNewGroup, personId);

            MessageBox.Show("Smooth, the data should be in the DB");
        }

        /// <summary>
        /// Adding some persons to join a group
        /// </summary>
        private void button10_Click(object sender, EventArgs e)
        {
            // Adding some persons to join the group ID 8
            int groupeId = 8;

            // Ids to be added
            int[] personToBeAdded = { 3, 4, 5, 6, 7, 8, 9, 10 };

            foreach(int i in personToBeAdded)
            {
                // adding them to the group (creating a following)
                controller.FollowingService.AddPersonToGroup(1, i, groupeId);
            }

            MessageBox.Show("omg everyone is added to my group !");
        }

        /// <summary>
        /// Getting a list of all the followers to a group
        /// </summary>
        private void button11_Click(object sender, EventArgs e)
        {
            int groupId = 8;
            // Getting the list
            IEnumerable<following> listOfFollowers = controller.FollowingService.GetBy(following.COLUMN_GROUP_ID, groupId);
            
            int nbOfAdmin = 0;
            int nbOfFollower = 0;

            // Just going through the list to see the status of each follower
            foreach(following follower in listOfFollowers)
            {
                if (follower.Is_admin)
                {
                    nbOfAdmin += 1;
                }
                else
                {
                    nbOfFollower += 1;
                }
            }

            MessageBox.Show("The group no. 8 have " + listOfFollowers.Count() + " followers ( Number of admin : " + nbOfAdmin + ", numbers of followers : " + nbOfFollower);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            person pers = controller.PersonService.Get(p => p.Name == "Bob").First();
            MessageBox.Show(pers.Description);

            IEnumerable<person> tester = new List<person>();
            tester = controller.PersonService.Get(p => p.Name == "Bob").ToList();

            int nb = 0;
            foreach(person p in tester)
            {
                nb++;
            }
            MessageBox.Show("There is " + nb + " bob");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            IEnumerable<person> tester = new List<person>();
            tester = controller.PersonService.GetBy(person.COLUMN_EMAIL, "bob@gmail.com");
            int nb = 0;
            foreach (person p in tester)
            {
                nb++;
            }
            MessageBox.Show("There is " + nb + " bob");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            IEnumerable<group> tester = new List<group>();
            tester = controller.GroupService.GetBy("is_active", true);
            int nb = 0;
            foreach (group g in tester)
            {
                nb++;
            }
            MessageBox.Show("There is " + nb + " active groups");

            // -------------------------------------------------- //

            IEnumerable<group> tester2 = new List<group>();
            tester2 = controller.GroupService.GetBy("name", "Group no.1");
            int nb2 = 0;
            foreach (group g in tester2)
            {
                nb2++;
            }
            MessageBox.Show("There is " + nb2 + " group named Group no.1");

        }
    }
}
