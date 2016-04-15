using PigeonsLibrairy.Controller;
using PigeonsLibrairy.Facade.Implementation;
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
        // something to retrieve the ID of the GROUP
    }

    private void fileUploader(int optionnalID = -1, ActionType optionnalActionType = ActionType.NONE)
    {
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
                for (int i=0; i<(parts.Length - 1); i++)
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
        int personID = 0;
        fileUploader(personID, ActionType.SAVE_PERSON_PICTURE);
    }
    protected void SaveGroupPicture(object sender, EventArgs e)
    {
        // something to get the group ID (request parameter, ex &groupID=######## ?)
        int personID = 0;
        fileUploader(personID, ActionType.SAVE_GROUP_PICTURE);
    }
    protected void SaveGroupFile(object sender, EventArgs e)
    {
        // something to get the group ID (request parameter, ex &groupID=######## ?)
        int personID = 0;
        fileUploader(personID, ActionType.SAVE_GROUP_FILE);
    }

    protected void DownloadButtonClick(Object sender, EventArgs e)
    {
        Button button = (Button)sender;
        homeFacade.fileControl.DownloadAFile(button.CommandArgument);
    }
}