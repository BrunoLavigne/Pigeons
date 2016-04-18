using PigeonsLibrairy.Facade.Implementation;
using PigeonsLibrairy.Model;
using System;

public partial class Account : System.Web.UI.Page
{
    protected HomeFacade homeFacade { get; set; }

    private enum ActionType { NONE, SAVE_PERSON_PICTURE, SAVE_GROUP_PICTURE, SAVE_GROUP_FILE };

    protected void Page_Load(object sender, EventArgs e)
    {
        if (homeFacade == null)
        {
            homeFacade = new HomeFacade();
        }

        if (!IsPostBack)
        {
            setValuesInPage();
        }
    }

    // If no changes have been applied, disable this button anyways
    protected void btnEditUser_Click(object sender, EventArgs e)
    {
        // get id from the Session
        // int personToUpdateID = gh.getCurrentUser().Id;
        person personToUpdateSession = (person)Session["user"];
        int personToUpdateId = personToUpdateSession.Id;

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

        // set values in page (refresh) DIRTY
        setValuesInPage();
    }

    protected void setValuesInPage()
    {
        // Get current user
        if (Session["user"] != null)
        {
            person activeP = (person)Session["user"];
            lblUserName.Text = activeP.Name;
            editUserEmail.Text = activeP.Email;
            editUserDescription.Text = activeP.Description;
            editUserOrganization.Text = activeP.Organization;
            editUserPosition.Text = activeP.Position;
            editUserPhoneNumber.Text = activeP.Phone_number;
            editUserProfilePicture.Text = activeP.Profile_picture_link;
            userProfilePicture.ImageUrl = activeP.Profile_picture_link;
        }
        else
        {
            Response.Redirect("Index.aspx");
        }
    }

    protected void SaveUserPicture(object sender, EventArgs e)
    {
        person activeP = (person)Session["user"];

        System.Diagnostics.Debug.WriteLine("FileUploadTest SaveUserPicture method called.");

        int personID = activeP.Id;
        fileUploader(personID, ActionType.SAVE_PERSON_PICTURE);
    }

    private void fileUploader(int optionnalID = -1, ActionType optionnalActionType = ActionType.NONE)
    {
        System.Diagnostics.Debug.WriteLine("FileUploadTest fileUploader method called.");
        System.Diagnostics.Debug.WriteLine("Parameter optionnalID: " + optionnalID);
        System.Diagnostics.Debug.WriteLine("Parameter optionnalActionType: " + optionnalActionType);
        if (FileUpload1.HasFile)
        {
            try
            {
                Byte[] fileBytes = FileUpload1.FileBytes;
                System.Diagnostics.Debug.WriteLine("File Byte Array: " + fileBytes.ToString());
                string[] parts = FileUpload1.FileName.Split('.');
                string extension = "." + parts[parts.Length - 1];
                System.Diagnostics.Debug.WriteLine("File extension: " + extension);
                string filename = null;
                for (int i = 0; i < (parts.Length); i++)
                {
                    if (i == 0)
                    {
                        filename += parts[i];
                    }
                    else
                    {
                        filename += "." + parts[i];
                    }
                }
                System.Diagnostics.Debug.WriteLine("File Name: " + filename);

                homeFacade.fileControl.AddPictureToUser(fileBytes, optionnalID, filename);
            }
            catch (Exception error)
            {
                System.Diagnostics.Debug.WriteLine(error + "\n" + error.Message);
                return;
            }
        }
    }
}