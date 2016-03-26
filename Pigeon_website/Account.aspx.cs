using PigeonsLibrairy.Controller;
using PigeonsLibrairy.Model;
using System;

public partial class Account : System.Web.UI.Page
{


    protected Controller controller { get; set; }

    protected GlobalHelpers gh { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {


        // Init helpers si pas fait
        if(gh == null)
        {
            gh = new GlobalHelpers();
        }

        // Get current user
        if(gh.getCurrentUser() != null)
        {
            editUserEmail.Text = gh.getCurrentUser().Email;
            editUserDescription.Text = gh.getCurrentUser().Description;
        } else {
            Response.Redirect("Index.aspx");
        }

        // Init controller
        if (controller == null)
        {
            controller = new Controller();
        }


        person personToUpdateSession = (person)Session["user"];
        testUserLabel.Text = personToUpdateSession.Organization;

    }

    // If no changes have been applied, disable this button anyways
    protected void btnEditUser_Click(object sender, EventArgs e)
    {
        // get id from the Session
        // int personToUpdateID = gh.getCurrentUser().Id;
        person personToUpdateSession = (person)Session["user"];
        int personToUpdateId = personToUpdateSession.Id;

        testUserLabel.Text = "persont » " + personToUpdateId;

        // connect id with controller
        person personToUpdate = controller.PersonService.GetByID(personToUpdateId);

        // parse new values...
        personToUpdate.Email = editUserEmail.Text;
        personToUpdate.Description = editUserDescription.Text;
        personToUpdate.Organization = "please update incorporated";

        // update via controller
        controller.PersonService.Update(personToUpdate);
        controller.Save();
    }
}