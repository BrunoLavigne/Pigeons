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
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            try
            {
                Byte[] fileBytes = FileUpload1.FileBytes;
                System.Diagnostics.Debug.WriteLine("File Byte Array: "+fileBytes.ToString());
                string[] parts = FileUpload1.FileName.Split('.');
                string extension = "." + parts[parts.Length - 1];
                System.Diagnostics.Debug.WriteLine("File extension: " + extension);
                string filename = parts[0];
                System.Diagnostics.Debug.WriteLine("File Name: " + filename);
                FileInfo savedFileInfo = homeFacade.fileControl.SaveByteFile(fileBytes, extension);
                // shit d'affichage / modification à partir du FileInfo
                // Accessible: FileInfo.FileName (mon du fichier sauvegardé i.e. son integer code)
                // etc...
            }
            catch (Exception error)
            {
                System.Diagnostics.Debug.WriteLine(error + "\n" + error.Message);
            }
        }
    }
}