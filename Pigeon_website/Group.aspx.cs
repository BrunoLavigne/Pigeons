using PigeonsLibrairy.Facade.Implementation;
using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;

public partial class Group : System.Web.UI.Page
{

    protected GroupFacade groupFacade { get; set; }

    protected HomeFacade homeFacade { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {

        if(groupFacade == null)
        {
            groupFacade = new GroupFacade();
        }

        if(homeFacade == null)
        {
            homeFacade = new HomeFacade();
        }


        // Also check if the group actually exists and if the user is following it
        if(Session["user"] == null || Request.Params["groupID"] == null)
        {
            Response.Redirect("Index.aspx");
        } else
        {

            person currentUser = (person) Session["user"];


            // Get group ID from url parameter
            Boolean goodGroupId = false;
            int groupId;

            goodGroupId = int.TryParse(Request.Params["groupID"], out groupId);

            if(goodGroupId)
            {

                // For todos testing
                testTodosLink.NavigateUrl = "Taskinator.aspx?groupID=" + groupId;

                // Render group to page
                renderGroupToPage(groupId);

                if(!groupFacade.PersonIsGroupAdmin(currentUser.Id, groupId))
                {
                    panelAdminButtons.Visible = false;
                }
            }
        }
    }

    // On devrait plus passer un groupe
    protected void renderGroupToPage(int groupId)
    {

        group theGroup;

        // TODO: Faire une méthode bool groupExists(int groupId)
        try
        {
            theGroup = groupFacade.GetGroupByID(groupId);

            lblGroupName.Text = theGroup.Name;
            lblGroupDescription.Text = theGroup.Description;

            presentationPicture.ImageUrl = theGroup.Group_picture_link;

            CultureInfo frCA = new CultureInfo("fr-CA");

            lblGroupDateCreated.Text = theGroup.Creation_date.ToString(frCA.DateTimeFormat.LongDatePattern, frCA);
            lblGroupTimeCreated.Text = theGroup.Creation_date.ToString(frCA.DateTimeFormat.ShortDatePattern, frCA);
            messagesListView.DataSource = groupFacade.GetGroupMessages(int.Parse(Request.Params["groupID"]));
            renderMessagesToPage();


        } catch(Exception e)
        {
            Console.WriteLine("Group not found: " + e.Message);
        }
        
    }

    protected void renderMessagesToPage()
    {

        DataTable table = new DataTable();
        table.Columns.Add("date_created");
        table.Columns.Add("content");
        table.Columns.Add("author");
        table.Columns.Add("profile_picture_link");

        foreach (message m in groupFacade.GetGroupMessages(int.Parse(Request.Params["groupID"])))
        {

            DataRow dr = table.NewRow();
            dr["date_created"] = m.Date_created;
            dr["content"] = m.Content;
            dr["author"] = homeFacade.GetPersonByID(m.Author_Id).Name;
            dr["profile_picture_link"] = homeFacade.GetPersonByID(m.Author_Id).Profile_picture_link;

            table.Rows.Add(dr);
        }

        messagesListView.DataSource = table; // old: groupFacade.GetGroupMessages(int.Parse(Request.Params["groupID"]));
        messagesListView.DataBind();
    }


    protected void btnNewMessage_Click(object sender, EventArgs e)
    {

        person user = (person)Session["user"];

        // Create the message
        message newMessage = new message();
        newMessage.Date_created = DateTime.Now;
        newMessage.Content = Server.HtmlEncode(txtNewMessage.Text);
        newMessage.Author_Id = user.Id;
        newMessage.Group_Id = int.Parse(Request.Params["groupID"]);

        // Save it
        groupFacade.CreateNewMessage(newMessage);

        // Refresh
        renderMessagesToPage();

        // Clear textbox for eventual new messages
        txtNewMessage.Text = "";
    }

}