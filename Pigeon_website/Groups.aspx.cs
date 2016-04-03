using PigeonsLibrairy.Facade.Implementation;
using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Web.Services;

public partial class Groups : System.Web.UI.Page
{

    protected HomeFacade homeFacade { get; set;  }

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

            IList<group> userGroups = homeFacade.GetPersonGroups(currentUser.Id);

            if (userGroups.Count != 0)
            {

                noGroupsView.Visible = false;

                groupsListView.DataSource = homeFacade.GetPersonGroups(currentUser.Id);
                groupsListView.DataBind();

            } else {

                groupsViewMessage.Text = "Vous n'êtes pas encore associé à un groupe! Pourquoi pas en créer un maintenant?";

            }

        } else {

            // Redirect to home page... (no login)
            // Todo: put in helper function in master ^  v 
            Response.Redirect("Index.aspx");
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

