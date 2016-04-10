using PigeonsLibrairy.Facade.Implementation;
using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Globalization;

public partial class Group : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        // Also check if the group actually exists and if the user is following it
        if(Session["user"] == null || Request.Params["groupID"] == null)
        {
            Response.Redirect("Index.aspx");
        } else
        {

            person currentUser = (person) Session["user"];

            // Check if user is admin of the group
            GroupFacade gf = new GroupFacade();


            // Get group ID from url parameter
            Boolean goodGroupId = false;
            int groupId;

            goodGroupId = int.TryParse(Request.Params["groupID"], out groupId);

            if(goodGroupId)
            {

                // For todos testing
                testTodosLink.NavigateUrl = "Taskinator.aspx?groupID=" + groupId;

                // For chatroom testing
                testChatLink.NavigateUrl = "Chat.aspx?groupID=" + groupId;

                // Render group to page
                renderGroupToPage(groupId);

                if(!gf.PersonIsGroupAdmin(currentUser.Id, groupId))
                {

                }
            }
        }
    }

    // On devrait plus passer un groupe
    protected void renderGroupToPage(int groupId)
    {

        GroupFacade gf = new GroupFacade();

        group theGroup;

        // TODO: Faire une méthode bool groupExists(int groupId)
        try
        {
            theGroup = gf.GetGroupByID(groupId);

            lblGroupName.Text = theGroup.Name;
            lblGroupDescription.Text = theGroup.Description;

            presentationPicture.ImageUrl = theGroup.Group_picture_link;

            CultureInfo frCA = new CultureInfo("fr-CA");

            lblGroupDateCreated.Text = theGroup.Creation_date.ToString(frCA.DateTimeFormat.LongDatePattern, frCA);
            lblGroupTimeCreated.Text = theGroup.Creation_date.ToString(frCA.DateTimeFormat.ShortDatePattern, frCA);

            // render messages to page
            messagesListView.DataSource = gf.GetGroupMessages(groupId);
            messagesListView.DataBind();

            // render todos to page
            // test for now
            List<task> taskList = new List<task>();

            task task1 = new task();

            task1.Description = "Finir le frontend";
            task1.Task_End = DateTime.Now;

            task1.Is_completed = false;
            // ...

            taskList.Add(task1);
            //todosListView.DataSource = taskList;
            //todosListView.DataBind();

        } catch(Exception e)
        {
            Console.WriteLine("Group not found: " + e.Message);
        }
        
    }

    protected void BtnTest_Click(object sender, EventArgs e)
    {
        // fun
    }

}