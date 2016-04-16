using PigeonsLibrairy.Controller;
using PigeonsLibrairy.Facade.Implementation;
using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FileUploadTest : System.Web.UI.Page
{
    HomeFacade homeFacade = new HomeFacade();
    private enum ActionType { NONE, SAVE_PERSON_PICTURE, SAVE_GROUP_PICTURE, SAVE_GROUP_FILE };

    protected void Page_Load(object sender, EventArgs e)
    {
        // something to retrieve the ID of the GROUP?
        /*
        homeFacade.m
        ListGroupSelectDownload.Items.Add
        */
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
                for (int i=0; i<(parts.Length); i++)
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
                switch (optionnalActionType)
                {
                    case ActionType.NONE:
                        break;
                    case ActionType.SAVE_PERSON_PICTURE:
                        homeFacade.fileControl.AddPictureToUser(fileBytes, optionnalID, filename);
                        break;
                    case ActionType.SAVE_GROUP_PICTURE:
                        homeFacade.fileControl.AddPictureToGroup(fileBytes, optionnalID, filename);
                        break;
                    case ActionType.SAVE_GROUP_FILE:
                        homeFacade.fileControl.AddAssociatedFileToGroup(fileBytes, optionnalID, filename);
                        break;
                }
            }
            catch (Exception error)
            {
                System.Diagnostics.Debug.WriteLine(error + "\n" + error.Message);
                return;
            }
        }
    }

    protected void SaveUserPicture(object sender, EventArgs e)
    {
        // something to get the person ID (session attribute?)
        System.Diagnostics.Debug.WriteLine("FileUploadTest SaveUserPicture method called.");
        int personID = 22;
        System.Diagnostics.Debug.WriteLine("Fixed personID set at int = 22");
        fileUploader(personID, ActionType.SAVE_PERSON_PICTURE);
    }
    protected void SaveGroupPicture(object sender, EventArgs e)
    {
        // something to get the group ID (request parameter, ex &groupID=######## ?)
        int groupID = 0;
        fileUploader(groupID, ActionType.SAVE_GROUP_PICTURE);
    }
    protected void SaveGroupFile(object sender, EventArgs e)
    {
        // something to get the group ID (request parameter, ex &groupID=######## ?)
        int groupID = 0;
        fileUploader(groupID, ActionType.SAVE_GROUP_FILE);
    }

    protected void DownloadButtonClick(Object sender, EventArgs e)
    {
        Button button = (Button)sender;
        homeFacade.fileControl.DownloadAFile(button.CommandArgument);
    }

    protected void AfficherGroupFiles(int groupID)
    {
        try
        {
            List<file> listeFichiersGroupe = homeFacade.fileControl.GetAllGroupFiles(groupID);
            Control allFilesPanel = Page.FindControl(PanelGroupFiles.ID);
            allFilesPanel.Controls.Clear();
            foreach (file fichier in listeFichiersGroupe)
            {
                // create sub-panel for each file
                Panel singleFilePanel = new Panel();
                singleFilePanel.ID = "filePanel" + fichier.ID;
                singleFilePanel.Attributes.Add("runat", "server");

                // Create an ImageButton  with a download method as its click command
                ImageButton fileImageButton = new ImageButton();
                fileImageButton.ID = "fileImageButton" + fichier.ID;
                fileImageButton.Attributes.Add("runat", "server");
                fileImageButton.ImageUrl = Server.MapPath("Resources/img/Icon_File_256x256.png");
                fileImageButton.CommandArgument = fichier.FileURL;
                fileImageButton.CommandName = "DownloadButtonClick";

                // Create a Label with the file name
                Label fileNameLabel = new Label();
                fileNameLabel.ID = "fileNameLabel" + fichier.ID;
                fileNameLabel.Attributes.Add("runat", "server");
                fileNameLabel.Text = fichier.FileName;

                // Add the ImageButton and Label to the file sub-panel
                singleFilePanel.Controls.Add(fileImageButton);
                singleFilePanel.Controls.Add(fileNameLabel);

                // Add the sub-panel and a line break to the main group file panel.
                allFilesPanel.Controls.Add(singleFilePanel);
                allFilesPanel.Controls.Add(new LiteralControl("<br/>"));
            }
        }
        catch (Exception error)
        {
            System.Diagnostics.Debug.WriteLine(error + "\n" + error.Message);
            return;
        }
    }

    protected void ListGroupSelectDownload_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}