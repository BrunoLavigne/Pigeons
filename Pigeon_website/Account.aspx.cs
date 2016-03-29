using PigeonsLibrairy.Controller;
using PigeonsLibrairy.Facade.Implementation;
using PigeonsLibrairy.Model;
using System;

public partial class Account : System.Web.UI.Page
{

    protected HomeFacade homeFacade { get; set; }

    protected GlobalHelpers gh { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {

        if(homeFacade == null)
        {
            homeFacade = new HomeFacade();
        }

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

            } else {
                Response.Redirect("Index.aspx");
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
        person personToUpdate = homeFacade.GetPersonByID(personToUpdateId);

        // parse new values...
        personToUpdate.Email = editUserEmail.Text;
        personToUpdate.Phone_number = editUserPhoneNumber.Text;

        personToUpdate.Description = editUserDescription.Text;
        personToUpdate.Organization = editUserOrganization.Text;
        
        personToUpdate.Position = editUserPosition.Text;

        personToUpdate.Profile_picture_link = editUserProfilePicture.Text;

        // update via controller
        homeFacade.UpdatePerson(personToUpdateId, personToUpdate);

        // update in session (override previous)
        Session["user"] = personToUpdate;

    }
}