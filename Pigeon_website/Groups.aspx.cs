using PigeonsLibrairy.Controller;
using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Web.Services;

public partial class Groups : System.Web.UI.Page
{

    static Controller controller { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {

        if(controller == null)
        {
            controller = new Controller();
        }

        if (!IsPostBack)
        {
            GlobalHelpers gh = new GlobalHelpers();

            // faudrait encore fait un helper pour ça
            if (Session["user"] != null)
            {
                // person currentUser = gh.getCurrentUser();
                person currentUser = (person)Session["user"];

                // TestLabel.Text = "Current user: " + gh.getCurrentUser().Description;
                TestLabel.Text = "Current user: " + currentUser.Email;

                IList<group> userGroups = controller.GroupService.GetPersonGroups(currentUser.Id);

                if(userGroups.Count != 0)
                {
                    noGroupsView.Visible = false;

                    gridViewUserGroups.DataSource = controller.GroupService.GetPersonGroups(currentUser.Id);
                    gridViewUserGroups.DataBind();

                    groupsListView.DataSource = controller.GroupService.GetPersonGroups(currentUser.Id);
                    groupsListView.DataBind();

                } else {

                    groupsView.Visible = false;
                    groupsViewMessage.Text = "Vous n'êtes pas encore associé à un groupe! Pourquoi pas en créer un maintenant?";

                }



            } else {

                // Redirect to home page... (no login)
                // Todo: put in helper function in master ^  v 
                Response.Redirect("Index.aspx");
            }
           
        }

    }

    [WebMethod]
    public static string GetMatchingUsers(string searchValue)
    {


        //// instantiate a serializer
        //JavaScriptSerializer TheSerializer = new JavaScriptSerializer();

        //// Fix this!
        //return TheSerializer.Serialize(controller.PersonService.GetBy(person.COLUMN_NAME.ALL.ToString(), searchValue));

        return "Alright here are the matching users: (not yet!)";
    }
}