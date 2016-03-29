using PigeonsLibrairy.Controller;
using PigeonsLibrairy.Exceptions;
using PigeonsLibrairy.Facade.Implementation;
using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
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
            messageToCreate.Author_Id   = activePersonID;
            messageToCreate.Group_Id    = activeGroupID;
            messageToCreate.Content     = txtMessageContent.Text;

            try
            {
                // Creating the message
                bool messageCreated = groupFacade.CreateNewMessage(messageToCreate);

                if (messageCreated)
                {
                    messageResult.Text = "Message created";

                    List<message> messageList = groupFacade.GetGroupMessages(activeGroupID);

                    foreach(message mess in messageList)
                    {
                        //person author = controller.PersonService.GetByID(mess.Author_Id);
                        dataGrid_messages.Rows.Add(mess.Author_Id, mess.person.Name, mess.Content, mess.Date_created);
                    }
                }                 
            }
            catch(FacadeException facadeException)
            {
                messageResult.Text = facadeException.Message;
            }            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();            
        }


    }
}
