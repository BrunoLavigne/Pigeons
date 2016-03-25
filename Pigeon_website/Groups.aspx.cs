using PigeonsLibrairy.Controller;
using PigeonsLibrairy.Model;
using System;

public partial class Groups : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            GlobalHelpers gh = new GlobalHelpers();
            Controller controller = new Controller();

            // faudrait encore fait un helper pour ça
            if (Session["user"] != null)
            {
                // person currentUser = gh.getCurrentUser();
                person currentUser = (person)Session["user"];

                // TestLabel.Text = "Current user: " + gh.getCurrentUser().Description;
                TestLabel.Text = "Current user: " + currentUser.Email;
                gridViewUserGroups.DataSource = controller.GroupService.GetPersonGroups(currentUser.Id);
                gridViewUserGroups.DataBind();

            } else {

                // Redirect to home page... (no login)
                // Todo: put in helper function in master ^  v 
                Response.Redirect("Index.aspx");
            }
           
        }

    }
}