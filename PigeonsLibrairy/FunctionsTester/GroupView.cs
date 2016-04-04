﻿using PigeonsLibrairy.Controller;
using PigeonsLibrairy.Exceptions;
using PigeonsLibrairy.Facade.Implementation;
using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FunctionsTester
{
    public partial class GroupView : Form
    {
        private int activeGroupID { get; set; }
        private int activePersonID { get; set; }
        private MainController controller { get; set; }
        private GroupFacade groupFacade { get; set; }

        public GroupView(int groupID, int personID)
        {
            InitializeComponent();
            controller = new MainController();
            groupFacade = new GroupFacade();
            activeGroupID = groupID;
            activePersonID = personID;
            fillTheFields();
            fillTheMessagesDataGrid();
            fillTheType();

            bool isThisPersonTheGroupAdmin = groupFacade.PersonIsGroupAdmin(activePersonID, activeGroupID);
            if (isThisPersonTheGroupAdmin)
            {
                btnCloseGroup.Visible = true;
                btnDeleteFollower.Visible = true;
            }
            else
            {
                btnCloseGroup.Visible = false;
                btnDeleteFollower.Visible = false;
            }

        }

        /// <summary>
        /// Filling 
        /// </summary>
        private void fillTheFields()
        {
            // Retreiving the group
            group activeGroup = groupFacade.GetGroupByID(activeGroupID);

            txtGroupID.Text     = activeGroup.Id.ToString();
            txtgroupName.Text   = activeGroup.Name;
            txtGroupDesc.Text   = activeGroup.Description;

            // Retreiving the person
            person activePerson = groupFacade.GetPersonByID(activePersonID);

            txtUserID.Text      = activePerson.Id.ToString();
            txtUserName.Text    = activePerson.Name;

            // Retreiving the followers
            List<following> followers = groupFacade.GetGroupFollowers(activeGroupID);

            foreach(following follower in followers)
            {
                cb_followers.Items.Add(follower.Person_Id);
            }

            cb_followers.SelectedIndex = 0;
            followerNb.Text = followers.Count().ToString();
        }

        /// <summary>
        /// Test - Creating a new message in the group
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateMessage_Click(object sender, EventArgs e)
        {
            message messageToCreate     = new message();
            messageToCreate.Author_Id   = int.Parse( followerID.Text );
            messageToCreate.Group_Id    = activeGroupID;
            messageToCreate.Content     = txtMessageContent.Text;

            try
            {
                // Creating the message
                bool messageCreated = groupFacade.CreateNewMessage(messageToCreate);

                if (messageCreated)
                {
                    messageResult.Text = "Message created";

                    fillTheMessagesDataGrid();
                }                 
            }
            catch(FacadeException facadeException)
            {
                messageResult.Text = facadeException.Message;
            }            
        }

        private void fillTheMessagesDataGrid()
        {
            dataGrid_messages.Rows.Clear();

            List<message> messageList = groupFacade.GetGroupMessages(activeGroupID);

            foreach (message mess in messageList)
            {
                dataGrid_messages.Rows.Add(mess.Author_Id, mess.person.Name, mess.Content, mess.Date_created);
            }
        }

        /// <summary>
        /// Test - Remove a follower from the group
        /// The ID is retrieve from the followerID textbox
        /// </summary>
        private void btnDeleteFollower_Click(object sender, EventArgs e)
        {
            int theFollowerID;
            int.TryParse(followerID.Text, out theFollowerID);

            try
            {
                if(groupFacade.RemoveTheFollower(activeGroupID, theFollowerID))
                {
                    txtRemoveFollowerResult.Text = "Person id :" + theFollowerID + " is removed from the group";
                }                
            }
            catch (FacadeException facadeException)
            {
                txtRemoveFollowerResult.Text = facadeException.Message;
            }
        }

        /// <summary>
        /// Test - Closing a group
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCloseGroup_Click(object sender, EventArgs e)
        {
            try
            {
                groupFacade.CloseGroup(activePersonID, activeGroupID);
            }
            catch(FacadeException facadeException)
            {
                txtGroupCloseResult.Text = facadeException.Message;
            }
        }

        /// <summary>
        /// Test - Ajouter un project à un groupe
        /// </summary>
        private void btnAddProject_Click(object sender, EventArgs e)
        {
            DateTime projectStart = default(DateTime);
            DateTime projectEnd = default(DateTime);
            string selectedType = cbProjectType.SelectedText.Trim();
            string projectDescription = rtb_ProjectDesc.Text;
            string[] typeSplit = selectedType.Split('-');
            string typeID = typeSplit[1];

            if (!checkStart.Checked)
            {
                projectStart = dateTimePicker_start.Value;
            }

            if (!checkEnd.Checked)
            {
                projectEnd = dateTimePicker_end.Value;
            }

            project aBrandNewProject = new project();
            aBrandNewProject.Description = projectDescription;
            aBrandNewProject.Date_start = projectStart;
            aBrandNewProject.Date_end = projectEnd;

            if(groupFacade.CreateNewProject(aBrandNewProject, activeGroupID) != null)
            {
                showTheProjects();
            }
        }

        /// <summary>
        /// Test - Ajouter un Event
        /// </summary>
        private void button3_Click(object sender, EventArgs e)
        {
            DateTime eventStart = default(DateTime);
            DateTime eventtEnd = default(DateTime);
            string eventDesc = txtEventDescription.Text;

            if (dateTimePicker_eventStart.Checked)
            {
                eventStart = dateTimePicker_eventStart.Value;
            }

            if (dateTimePicker_eventEnd.Checked)
            {
                eventtEnd = dateTimePicker_eventEnd.Value;
            }
        }


        /// <summary>
        /// Selected the ID of a follower
        /// Will be used to select the author of a message
        /// </summary>        
        private void cb_followers_SelectedIndexChanged(object sender, EventArgs e)
        {
            int personID;
            int.TryParse(cb_followers.SelectedItem.ToString(), out personID);
            followerID.Text = personID.ToString();
        }

        private void fillTheType()
        {
            IEnumerable<type> typeList = groupFacade.GetAllTypes();
            foreach(type t in typeList)
            {
                cbProjectType.Items.Add(t.Name + " - " + t.Id);
            }
            cbProjectType.SelectedIndex = 0;
        }

        private void showTheProjects()
        {
            IEnumerable<project> projectList = groupFacade.GetProjectsFromGroup(activeGroupID);

            foreach(project p in projectList)
            {
                dataGridView_Projects.Rows.Add(p.Description, p.Type_id.ToString(), p.Date_start, p.Date_end);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();            
        }

        private void btn_pic_Click(object sender, EventArgs e)
        {

            openFileDialog1.Filter = "Text Files (.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;

            openFileDialog1.ShowDialog();

            string file = openFileDialog1.FileName;
            try
            {
                string text = File.ReadAllText(file);
            }
            catch (IOException)
            {
            }

        }
    }
}
