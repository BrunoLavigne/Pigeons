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

    // Function fired when a webcontrol offering a download is activated
    // {param} fileName (String) : the file name to download.
    protected void fileDownloader(FileInfo file)
    {
        try
        {

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
            HttpContext.Current.Response.AddHeader("Content-Length", file.Length.ToString());
            HttpContext.Current.Response.ContentType = "text/plain";
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.TransmitFile(file.FullName);
            HttpContext.Current.Response.End();
        }
        catch (Exception error)
        {
            // yadda yadda error handling
        }
    }

    protected void fileUploader()
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
                string filename = parts[0];
                System.Diagnostics.Debug.WriteLine("File Name: " + filename);
                FileInfo savedFileInfo = homeFacade.fileControl.SaveByteFile(fileBytes, filename);
            }
            catch (Exception error)
            {
                System.Diagnostics.Debug.WriteLine(error + "\n" + error.Message);
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        fileUploader();
    }

    protected void ButtonGetFile1_Click(object sender, EventArgs e)
    {
        FileInfo fileInfo = homeFacade.fileControl.GetFileByName("1.*");
        fileDownloader(fileInfo);
    }

    protected void ButtonGetFile2_Click(object sender, EventArgs e)
    {
        FileInfo fileInfo = homeFacade.fileControl.GetFileByName("2.*");
        fileDownloader(fileInfo);
    }
}