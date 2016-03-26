using PigeonsLibrairy.Controller;
using PigeonsLibrairy.Exceptions;
using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FunctionsTester
{
    public partial class Form2 : Form
    {        
        private Controller controller { get; set; }

        public Form2()
        {
            InitializeComponent();
            controller = new Controller();
            createDataGridColumns();
        }
        
        /// <summary>
        /// Test - Creating a new user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInscription_Click(object sender, EventArgs e)
        {
            string name, email, emailConfirmation, password, passwordConfirmation, phonenumber, organisation, position, description;
            DateTime birthdate;

            name = person_name.Text;
            email = person_email.Text;
            emailConfirmation = person_emailConfirmation.Text;
            password = person_password.Text;
            passwordConfirmation = person_passwordConfirmation.Text;
            phonenumber = person_phone.Text;
            organisation = person_organization.Text;
            position = person_position.Text;
            description = person_description.Text;
            birthdate = person_birthdate.Value.Date;

            person aNewPerson = new person();
            aNewPerson.Name         = name;
            aNewPerson.Email        = email;
            aNewPerson.Password     = password;            
            aNewPerson.Phone_number = phonenumber;
            aNewPerson.Organization = organisation;
            aNewPerson.Position     = position;
            aNewPerson.Description  = description;
            aNewPerson.Birth_date   = birthdate;

            if(controller.PersonService.registerNewUser(aNewPerson, emailConfirmation, passwordConfirmation))
            {
                person_result.Text = "The user is created";
            }
            else
            {
                person_result.Text = "Error";
            }

        }

        /// <summary>
        /// Test - Login
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = loginUsername.Text;
            string password = loginPassword.Text;

            person activePerson = controller.PersonService.loginValidation(username, password);

            if (activePerson != null)
            {
                loginResult.Text = "Login Accepted";
                person currentUser = (controller.PersonService.GetBy(person.COLUMN_NAME.EMAIL.ToString(), username)).ToList()[0];
                active_personID.Text = currentUser.Id.ToString();
            }
            else
            {
                loginResult.Text = "Login Refused";
            }
        }

        /// <summary>
        /// Test - Show current groups
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnActivePersonGroups_Click(object sender, EventArgs e)
        {
            DateGrid_ActivePersonGroups.Rows.Clear();

            if (active_personID.Text == "")
            {
                DateGrid_ActivePersonGroups.Rows.Add("0", "Empty", "Empty", "0");
            }
            else
            {
                // Retrieving the groups the person is following
                List<group> personGroups = controller.GroupService.GetPersonGroups(int.Parse(active_personID.Text)).ToList();
                
                if(personGroups.Count() > 0)
                {
                    IEnumerable<following> listOfFollowers = controller.FollowingService.GetBy(following.COLUMN_NAME.GROUP_ID.ToString(), personGroups[0].Id);
                    
                    // Affichage
                    foreach (group activeGroups in personGroups)
                    {
                        DateGrid_ActivePersonGroups.Rows.Add(activeGroups.Id, activeGroups.Name, activeGroups.Description, listOfFollowers.Count());
                        cb_activePerson_groups.Items.Add(activeGroups.Id.ToString());
                    }
                    cb_activePerson_groups.SelectedIndex = 0;
                }
                else
                {
                    DateGrid_ActivePersonGroups.Rows.Add("0", "Empty", "Empty", "0");
                }
                
            }            
        }

        /// <summary>
        /// Test - Create a new group
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateGroup_Click(object sender, EventArgs e)
        {
            if(active_personID.Text != "")
            {
                string groupName = group_name.Text;
                string groupDesc = group_description.Text;

                group newGroup = new group();
                newGroup.Name = groupName;
                newGroup.Description = groupDesc;
                newGroup.Creation_date = DateTime.Now;
                newGroup.Is_active = true;                

                try
                {
                    controller.GroupService.CreateNewGroupAndRegister(newGroup, int.Parse(active_personID.Text));
                    groupResult.Text = "Success";
                }
                catch(ServiceException serviceException)
                {
                    groupResult.Text = serviceException.Message;
                }                
            }
        }

        /// <summary>
        /// Test - Find a user to be added to the selected group
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnActiveGroupFind_Click(object sender, EventArgs e)
        {
            string searchValue = activeGroup_addPerson.Text;

            List<person> searchPersonList = controller.PersonService.GetBy(person.COLUMN_NAME.EMAIL.ToString(), searchValue).ToList();

            // Afficher the user if found
            if(searchPersonList.Count() == 1)
            {
                person searchPerson = searchPersonList[0];
                activeGroup_name.Text = searchPerson.Name;
                activeGroup_id.Text = searchPerson.Id.ToString();
            }
            else
            {
                activeGroup_name.Text = "No user found";
            }
        }

        /// <summary>
        /// Test - Add the user to the group (following)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnActiveGroup_Add_Click(object sender, EventArgs e)
        {
            int personToAddID;
            int adminID;

            int.TryParse(activeGroup_id.Text, out personToAddID);
            int.TryParse(active_personID.Text, out adminID);
            int groupID = int.Parse(cb_activePerson_groups.SelectedItem.ToString());

            try
            {
                controller.FollowingService.addPersonToGroup(adminID, personToAddID, groupID);
                activeGroupResult.Text = "User " + personToAddID + " is added";
            }
            catch (ServiceException serviceException)
            {
                activeGroupResult.Text = serviceException.Message;
            }            
        }

        private void btnGoToGroup_Click(object sender, EventArgs e)
        {
            int groupID = int.Parse(cb_activePerson_groups.SelectedItem.ToString());
            int personID = int.Parse(active_personID.Text);

            GroupView groupForm = new GroupView(groupID, personID);
            groupForm.Owner = this;

            this.Hide();

            if(groupForm.ShowDialog() == DialogResult.OK)
            {
            }

            this.Show();
        }

        /// <summary>
        /// Just creating the columns for the Group DataGridView
        /// </summary>
        private void createDataGridColumns()
        {
            DateGrid_ActivePersonGroups.Columns.Add("ID", "ID");
            DateGrid_ActivePersonGroups.Columns.Add("NAME", "Name");
            DateGrid_ActivePersonGroups.Columns.Add("DESCRIPTION", "Description");
            DateGrid_ActivePersonGroups.Columns.Add("NBUSER", "Nb users in");
        }

    }
}
