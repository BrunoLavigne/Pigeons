using PigeonsLibrairy.Controller;
using PigeonsLibrairy.Model;
using System;
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
                gridViewUserGroups.DataSource = controller.GroupService.GetPersonGroups(currentUser.Id);
                gridViewUserGroups.DataBind();

            } else {

                // Redirect to home page... (no login)
                // Todo: put in helper function in master ^  v 
                Response.Redirect("Index.aspx");
            }
           
        }

    }

    [WebMethod]
    public static string GetCurrentTime()
    {

        string msg = "";
        foreach(group g in controller.GroupService.Get())
        {
            msg += g.Description + "    " + g.Name;
        }

        return "Hello you okay here's the time: " + DateTime.Now.ToLongTimeString() + msg;
    }
}