using PigeonsLibrairy.Controller;
using PigeonsLibrairy.Model;
using System;

public partial class Account : System.Web.UI.Page
{


    protected Controller controller { get; set; }

    protected GlobalHelpers gh { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            
            // Init helpers si pas fait
            if(gh == null)
            {
                gh = new GlobalHelpers();
            }

            // Get current user
            if(Session["user"] != null)
            {

                person p = (person)Session["user"];

                //editUserEmail.Text = p.Email;
                //editUserDescription.Text = p.Description;
                //userProfilePicture.ResolveUrl(p.Profile_picture_link);
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

        if(Session["user"] != null )
        {
            person activeP = (person)Session["user"];
            editUserEmail.Text = activeP.Email;
            editUserDescription.Text = activeP.Description;
            userProfilePicture.ImageUrl = activeP.Profile_picture_link;
            testUserLabel.Text = "The active user is : " + activeP.Description + " 00 " + activeP.Name + " 00 " + activeP.Organization;
        } else
        {
            testUserLabel.Text = "There seems to be no active user on this page, move along";
        }



    }

    // If no changes have been applied, disable this button anyways
    protected void btnEditUser_Click(object sender, EventArgs e)
    {
        // get id from the Session
        // int personToUpdateID = gh.getCurrentUser().Id;
        person personToUpdateSession = (person)Session["user"];
        int personToUpdateId = personToUpdateSession.Id;

        testUserLabel.Text = "persont » " + personToUpdateId;

        // connect id with controller (cleanup)
        if(controller == null)
        {
            controller = new Controller();
        }

        person personToUpdate = controller.PersonService.GetByID(personToUpdateId);

        // parse new values...
        personToUpdate.Email = editUserEmail.Text;
        personToUpdate.Phone_number = editUserPhoneNumber.Text;

        personToUpdate.Description = editUserDescription.Text;
        personToUpdate.Organization = editUserOrganization.Text;
        
        personToUpdate.Position = editUserPosition.Text;

        personToUpdate.Profile_picture_link = editUserProfilePicture.Text;

        // update via controller
        controller.PersonService.Update(personToUpdate);
        controller.Save();

        // update in session (override previous)
        Session["user"] = personToUpdate;

    }
}