using PigeonsLibrairy.Facade.Implementation;
using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Script.Serialization;
using System.Web.Services;

public partial class Groups : System.Web.UI.Page
{

    protected static HomeFacade homeFacade { get; set;  }

    protected GroupFacade groupFacade { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {

        person currentUser;

        // faudrait encore fait un helper pour ça
        if (Session["user"] != null)
        {

            currentUser = (person) Session["user"];

            if (homeFacade == null)
            {
                homeFacade = new HomeFacade();
            }
            if(groupFacade == null)
            {
                groupFacade = new GroupFacade();
            }

            renderGroupsToPage(currentUser);

        } else {

            // Redirect to home page... (no login)
            // Todo: put in helper function in master ^  v 
            Response.Redirect("Index.aspx");
        }

    }

    private void renderGroupsToPage(person currentUser)
    {
        IList<group> userGroups = homeFacade.GetPersonGroups(currentUser.Id);

        if (userGroups.Count != 0)
        {

            noGroupsView.Visible = false;

            DataTable table = new DataTable();
            table.Columns.Add("id");
            table.Columns.Add("name");
            table.Columns.Add("creation_date");
            table.Columns.Add("description");
            table.Columns.Add("followers");
            table.Columns.Add("group_picture_link");

            foreach (group g in homeFacade.GetPersonGroups(currentUser.Id))
            {

                DataRow dr = table.NewRow();

                dr["id"] = g.Id;
                dr["name"] = g.Name;
                dr["creation_date"] = g.Creation_date;
                dr["description"] = g.Description;
                dr["followers"] = homeFacade.GetGroupFollowers(g.Id).ToString();
                dr["group_picture_link"] = g.Group_picture_link;

                table.Rows.Add(dr);
            }

            groupsListView.DataSource = table;
            groupsListView.DataBind();

        }
        else {

            groupsViewMessage.Text = "Vous n'êtes pas encore associé à un groupe! Pourquoi pas en créer un maintenant?";

        }
    }

    [WebMethod]
    public static string GetMatchingUsers(string searchValue)
    {


        // instantiate a serializer
        JavaScriptSerializer TheSerializer = new JavaScriptSerializer();

        List<person> matchingUsersList = new List<person>();
        matchingUsersList = homeFacade.GetAllPersons(searchValue);

        return TheSerializer.Serialize(matchingUsersList);

    }

    protected void clearNewGroupFormFields()
    {
        txtNewGroupDescription.Text = "";
        txtNewGroupFollowers.Text = "";
        txtNewGroupName.Text = "";
        txtNewGroupPicture.Text = "";
    }

    protected void btnNewGroup_Click(object sender, EventArgs e)
    {
        createNewGroup();
    }

    [WebMethod]
    protected void createNewGroup()
    {
        string groupName = txtNewGroupName.Text;
        string groupDescription = txtNewGroupDescription.Text;
        string groupPictureLink = txtNewGroupPicture.Text;

        group theNewGroup = new group();

        theNewGroup.Name = groupName;
        theNewGroup.Description = groupDescription;
        theNewGroup.Creation_date = DateTime.Now;
        theNewGroup.Group_picture_link = groupPictureLink;
        theNewGroup.Is_active = true;

        // get the group author
        person activeUser = (person)Session["user"];

        groupFacade.CreateNewGroupAndRegister(theNewGroup, activeUser.Id);

        // refresh
        renderGroupsToPage(activeUser);

        clearNewGroupFormFields();
    }
}

