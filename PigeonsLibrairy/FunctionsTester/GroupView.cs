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
    public partial class GroupView : Form
    {
        private int activeGroupID { get; set; }
        private int activePersonID { get; set; }
        private Controller controller { get; set; }

        public GroupView(int groupID, int personID)
        {
            InitializeComponent();
            controller = new Controller();
            activeGroupID = groupID;
            activePersonID = personID;
            fillTheFields();
            
        }

        /// <summary>
        /// Filling 
        /// </summary>
        private void fillTheFields()
        {
            // Retreiving the group
            group activeGroup = controller.GroupService.GetByID(activeGroupID);
            txtGroupID.Text = activeGroup.Id.ToString();
            txtgroupName.Text = activeGroup.Name;
            txtGroupDesc.Text = activeGroup.Description;

            // Retreiving the person
            person activePerson = controller.PersonService.GetByID(activePersonID);
            txtUserID.Text = activePerson.Id.ToString();
            txtUserName.Text = activePerson.Name;

            // Retreiving the followers
            IEnumerable<following> followers = controller.FollowingService.GetTheFollowers(activeGroupID);
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
            message messageToCreate = new message();
            messageToCreate.Author_Id = activePersonID;
            messageToCreate.Group_Id = activeGroupID;
            messageToCreate.Content = txtMessageContent.Text;

            try
            {
                if (controller.MessageService.createNewMessage(messageToCreate))
                {
                    messageResult.Text = "Message created";

                    IEnumerable<message> messageList = controller.MessageService.GetBy(message.COLUMN_NAME.GROUP_ID.ToString(), activeGroupID);
                    foreach(message mess in messageList)
                    {
                        person author = controller.PersonService.GetByID(mess.Author_Id);
                        dataGrid_messages.Rows.Add(mess.Author_Id, author.Name, mess.Content, mess.Date_created);
                    }
                }                 
            }
            catch(ServiceException serviceException)
            {
                messageResult.Text = serviceException.Message;
            }            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();            
        }


    }
}
