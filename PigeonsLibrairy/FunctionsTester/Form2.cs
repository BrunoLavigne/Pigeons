using PigeonsLibrairy.Controller;
using PigeonsLibrairy.Exceptions;
using PigeonsLibrairy.Facade.Implementation;
using PigeonsLibrairy.Facade.Interface;
using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FunctionsTester
{
    public partial class Form2 : Form
    {        
        private MainController controller { get; set; }
        private IHomeFacade homeFacade { get; set; }
        private IGroupFacade groupFacade { get; set; }

        public Form2()
        {
            InitializeComponent();
            controller = new MainController();
            homeFacade = new HomeFacade();
            groupFacade = new GroupFacade();
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

            name                    = person_name.Text;
            email                   = person_email.Text;
            emailConfirmation       = person_emailConfirmation.Text;
            password                = person_password.Text;
            passwordConfirmation    = person_passwordConfirmation.Text;
            phonenumber             = person_phone.Text;
            organisation            = person_organization.Text;
            position                = person_position.Text;
            description             = person_description.Text;
            birthdate               = person_birthdate.Value.Date;

            person aNewPerson = new person();
            aNewPerson.Name         = name;
            aNewPerson.Email        = email;
            aNewPerson.Password     = password;            
            aNewPerson.Phone_number = phonenumber;
            aNewPerson.Organization = organisation;
            aNewPerson.Position     = position;
            aNewPerson.Description  = description;
            aNewPerson.Birth_date   = birthdate;

            if(homeFacade.RegisterUser(aNewPerson, emailConfirmation, passwordConfirmation))
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

            person activePerson = homeFacade.LoginValidation(username, password);

            if (activePerson != null)
            {
                loginResult.Text = "Login Accepted";
                active_personID.Text = activePerson.Id.ToString();

                fillPersonCombo(activePerson.Id);
            }
            else
            {
                loginResult.Text = "Login Refused";
            }
        }

        private void fillPersonCombo(int id)
        {
            person activePerson = homeFacade.GetPersonData(id);

            foreach(following f in activePerson.followings)
            {
                cb_LoginFollowings.Items.Add(f.Person_Id + " - " + f.Group_id);
                cb_LoginGroups.Items.Add(f.group.Name);
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
                List<group> personGroups = homeFacade.GetPersonGroups(int.Parse(active_personID.Text));
                
                if(personGroups.Count() > 0)
                {                    
                    // Affichage
                    foreach (group activeGroups in personGroups)
                    {
                        // Number of followers
                        int nbOfFollowers = homeFacade.GetGroupFollowers(activeGroups.Id);

                        DateGrid_ActivePersonGroups.Rows.Add(activeGroups.Id, activeGroups.Name, activeGroups.Description, nbOfFollowers);
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
                int personID = int.Parse(active_personID.Text);

                group newGroup          = new group();
                newGroup.Name           = groupName;
                newGroup.Description    = groupDesc;                                         

                try
                {
                    group createdGroup = groupFacade.CreateNewGroupAndRegister(newGroup, personID);

                    if (createdGroup != null)
                    {
                        groupResult.Text = "Success";
                    }
                    else
                    {
                        groupResult.Text = "Fail";
                    }                                 
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

            List<person> searchPersonList = homeFacade.GetAllPersons(searchValue);

            // Afficher the user if found
            if(searchPersonList.Count() > 0)
            {
                cb_activeGroup_addPerson.Items.Clear();

                foreach (person personFound in searchPersonList)
                {
                    cb_activeGroup_addPerson.Items.Add(personFound.Name + " - " + personFound.Id);
                }
                cb_activeGroup_addPerson.SelectedIndex = 0;
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
            int groupID;

            int.TryParse(activeGroup_id.Text, out personToAddID);
            int.TryParse(active_personID.Text, out adminID);
            int.TryParse(cb_activePerson_groups.SelectedItem.ToString(), out groupID);

            try
            {
                // Adding the person
                groupFacade.AddPersonToGroup(adminID, personToAddID, groupID);

                activeGroupResult.Text = "User " + personToAddID + " is added";
            }
            catch (FacadeException facadeException)
            {
                activeGroupResult.Text = facadeException.Message;
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

        private void cb_activeGroup_addPerson_SelectedIndexChanged(object sender, EventArgs e)
        {
            string thePerson = cb_activeGroup_addPerson.SelectedItem.ToString().Trim();
            string[] splitter = thePerson.Split('-');

            activeGroup_name.Text = splitter[0];
            activeGroup_id.Text = splitter[1];
        }

        /// <summary>
        /// Test - Update a person description
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateDesc_Click(object sender, EventArgs e)
        {
            int personID;
            bool convert = int.TryParse(active_personID.Text, out personID);

            string newDescription = txtUpdateDesc.Text;

            person activePerson = homeFacade.GetPersonByID(personID);
            activePerson.Description = newDescription;

            person updateMe = homeFacade.UpdatePerson(personID, activePerson);
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
