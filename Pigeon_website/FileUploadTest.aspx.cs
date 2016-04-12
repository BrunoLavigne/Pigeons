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
                string[] parts = FileUpload1.FileName.Split('.');
                string extension = "." + parts[parts.Length - 1];
                string filename = parts[0];
                FileInfo savedFileInfo = homeFacade.fileControl.saveByteFile(fileBytes, extension);
                // shit d'affichage / modification à partir du FileInfo
                // Accessible: FileInfo.FileName (mon du fichier sauvegardé i.e. son integer code)
                // etc...
            }
            catch (Exception error)
            {
                // yadda yadda error handling
            }
        }
    }
}