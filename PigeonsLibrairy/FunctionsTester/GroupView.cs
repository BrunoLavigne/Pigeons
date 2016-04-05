using PigeonsLibrairy.Controller;
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
            List<person> followers = groupFacade.GetGroupFollowers(activeGroupID);

            foreach(person follower in followers)
            {
                cb_followers.Items.Add(follower.Id);
                cbFollowerAssignation.Items.Add(follower.Name + " - " + follower.Id);
            }

            cb_followers.SelectedIndex = 0;
            cbFollowerAssignation.SelectedIndex = 0;
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
        /// Test - Création d'une Task
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddTask_Click(object sender, EventArgs e)
        {
            DateTime taskStart = default(DateTime);
            DateTime tasktEnd = default(DateTime);
            string taskDesc = rtb_TaskDesc.Text;

            if (dateTimePicker_start.Checked)
            {
                taskStart = dateTimePicker_start.Value;
            }

            if (dateTimePicker_end.Checked)
            {
                tasktEnd = dateTimePicker_end.Value;
            }

            task newTask = new task();
            newTask.Group_ID = activeGroupID;
            newTask.Author_ID = activePersonID;
            newTask.Task_Start = taskStart;
            newTask.Task_End = tasktEnd;
            newTask.Description = taskDesc;

            groupFacade.CreateNewTask(newTask, newTask.Group_ID, activePersonID);
        }

        private void btn_ShowTasks_Click(object sender, EventArgs e)
        {
            IEnumerable<task> taskList = groupFacade.GetGroupTasks(activeGroupID);

            dataGridView_Task.Rows.Clear();

            foreach (task t in taskList)
            {
                dataGridView_Task.Rows.Add(t.Id, t.Description, t.Task_Start, t.Task_End, t.Is_completed);
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
            //IEnumerable<type> typeList = groupFacade.GetAllTypes();
            //foreach(type t in typeList)
            //{
            //    cbProjectType.Items.Add(t.Name + " - " + t.Id);
            //}
            //cbProjectType.SelectedIndex = 0;
        }

        private void showTheProjects()
        {
            //IEnumerable<project> projectList = groupFacade.GetProjectsFromGroup(activeGroupID);

            //foreach(project p in projectList)
            //{
            //    dataGridView_Projects.Rows.Add(p.Description, p.Type_id.ToString(), p.Date_start, p.Date_end);
            //}
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

        private void btnCompletedTask_Click(object sender, EventArgs e)
        {
            int taskID = int.Parse(txtTaskID.Text);

            groupFacade.TaskIsCompleted(taskID);

        }

        private void dataGridView_Task_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRow = dataGridView_Task.CurrentRow.Index;
            object selectedRowID = dataGridView_Task[0, selectedRow].Value;
            String taskid = selectedRowID.ToString();

            txtTaskID.Text = taskid;
        }

        private void cbFollowerAssignation_SelectedIndexChanged(object sender, EventArgs e)
        {
            int personID;
            string personInfo = cbFollowerAssignation.SelectedItem.ToString();
            string[] splitPersonInfo = personInfo.Trim().Split('-');

            int.TryParse(splitPersonInfo[1], out personID);
            followerID.Text = personID.ToString();
        }

        /// <summary>
        /// Test - Assignation d'une task à une personne
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            int personID = int.Parse(followerID.Text);
            int taskID = int.Parse(txtTaskID.Text);

            assignation taskAssignation = new assignation();
            taskAssignation.Person_ID = personID;
            taskAssignation.Task_ID = taskID;

            groupFacade.AssignTaskToPerson(taskAssignation);
        }
    }
}
