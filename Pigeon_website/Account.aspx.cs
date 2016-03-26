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


    }

    // If no changes have been applied, disable this button anyways
    protected void btnEditUser_Click(object sender, EventArgs e)
    {

        person personToUpdate = gh.getCurrentUser();

        // Take new email
        personToUpdate.Email = editUserEmail.Text;

        // Take new description
        personToUpdate.Description = editUserDescription.Text;

        controller.PersonService.Update(personToUpdate);

        // Show label that everything worked / failed
        // ...
    }
}