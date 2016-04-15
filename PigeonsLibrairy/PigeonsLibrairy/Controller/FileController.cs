using PigeonsLibrairy.Exceptions;
using PigeonsLibrairy.Model;
using PigeonsLibrairy.Service.Implementation;
using PigeonsLibrairy.Service.Interface;
using System;
using System.Diagnostics;
using System.IO;
using System.Web;

namespace PigeonsLibrairy.Controller
{
    /// <summary>
    /// Controller for file uploads
    /// </summary>
    public class FileController
    {
        private readonly string FILE_DIRECTORY_PATH;
        private IFileService fileService { get; set; }
        private DirectoryInfo directoryInfo { get; set; }

        /// <summary>
        /// Constructeur
        /// </summary>
        public FileController()
        {
            //FILE_DIRECTORY_PATH = HttpContext.Current.Server.MapPath("E:/Server_Files");
            fileService = new FileService();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fileDirectoryPath">The path to the file directory to specify for the controller.</param>
        public FileController(string fileDirectoryPath)
        {
            FILE_DIRECTORY_PATH = fileDirectoryPath;
            fileService = new FileService();
            directoryInfo = new DirectoryInfo(fileDirectoryPath);
        }

        /// <summary>
        /// Function to upload a file on the server.
        /// Files are saved with a generated name being an incremental integer.
        /// Examples: 1.jpg, 2.jpg, 3.pdf, 4.png ...
        /// </summary>
        /// <param name="fileByteArray">a Byte array of the file itself</param>
        /// <param name="originalFileName">a string of the original file's full name (name + extension)</param>
        /// <returns>a FileInfo Object of the saved file, null if exception.</returns>
        public FileInfo SaveByteFile(Byte[] fileByteArray, string originalFileName)
        {
            FileInfo savedFileInfo = null;
            try
            {
                // find highest file "name" (integer code) in order to save the file to the next incrementation.
                int highestFileID = 0;
                FileInfo[] fileInfoArray = directoryInfo.GetFiles("*.*");
                foreach (FileInfo fileInfo in fileInfoArray)
                {
                    int fileID = Int32.Parse(Path.GetFileNameWithoutExtension(fileInfo.Name));
                    string fileIDWithExtension = fileInfo.Name;
                    if (fileID > highestFileID)
                    {
                        highestFileID = fileID;
                    }
                }
                string[] originalFileNameParts = originalFileName.Split('.');
                string originalFileExtension = "." + originalFileNameParts[originalFileNameParts.Length - 1];
                string newFilePath = FILE_DIRECTORY_PATH + "/" + (highestFileID + 1).ToString() + originalFileExtension;
                // saves the file itself (Byte Array) at the new path.
                File.WriteAllBytes(newFilePath, fileByteArray);
                file Fichier = new file();
                Fichier.ID = highestFileID + 1;
                Fichier.FileURL = newFilePath;
                Fichier.FileName = originalFileName;
                Fichier.Creation_Date = DateTime.Now;



                foreach (string file in Directory.GetFiles(FILE_DIRECTORY_PATH, "*.*"))
                {
                    FileInfo foundFileInfo = new FileInfo(file);
                    string fileFullName = foundFileInfo.Name;
                    Debug.WriteLine("Nom du fichier: " + fileFullName);
                    string[] nameParts = fileFullName.Split('.');
                    int currentFileID = Int32.Parse(nameParts[0]);
                    Debug.WriteLine("ID du fichier: " + currentFileID);
                    if (currentFileID > highestFileID)
                    {
                        highestFileID = currentFileID;
                    }
                    Debug.WriteLine("ID maximale trouvé: " + highestFileID);
                }
                // generates the new file path and name.
                string newFilePath = FILE_DIRECTORY_PATH + "/" + (highestFileID + 1).ToString() + fileExtension; // NOTE: p-e nécessaire de rajouter le point avant extension, ou s'assurer qu'il soit déjà présent dans le strinhg passé en paramètre.
                Debug.WriteLine("chemin de fichier uploadé généré: " + newFilePath);
                // saves the file itself (Byte Array) at the new path.
                File.WriteAllBytes(newFilePath, fileByteArray);
                Debug.WriteLine("FileInfo: \nPath: " + savedFileInfo.ToString() + "\nName: " + savedFileInfo.Name + "\nExtension: " + savedFileInfo.Extension + "\nFullName: " + savedFileInfo.FullName);
            }
            catch (Exception error)
            {
                Debug.WriteLine(error.Message);
                throw new ControllerException(error.Message);
            }
            return savedFileInfo;
        }

        /// <summary>
        /// Function to retrieve a file from the server by its file integer code or filename as saved in the database
        /// </summary>
        /// <param name="fileName">The file name / integer code to lookup and retrieve.</param>
        /// <returns>A FileInfo object representing the file information on the server (path and such).</returns>
        public FileInfo GetFileByName(string fileName)
        {
            FileInfo fileToGet = null;
            try
            {
                // find file by specified filename
                fileToGet = new FileInfo(Directory.GetFiles(FILE_DIRECTORY_PATH, fileName)[0]);
                Debug.WriteLine("Fichier trouvé: " + fileToGet.ToString());
            }
            catch (Exception)
            {
                Debug.WriteLine(error.Message);
                throw new ControllerException(error.Message);
            }
            return fileToGet;
        }

        /// <summary>
        /// Insertion des information d'un fichier dans la base de données
        /// </summary>
        /// <returns></returns>
        public file InsertInDataBase(file File)
        {
            //fileService.
            return null;
        }

        /******************************************************************************************

        //###############################################

                // Functions under this
                // are for aspx.cs files
                // and not for the controller
                // snipp'd for easy copy

        //###############################################

                // for upload: required in the aspx page:
                // FileUpload control which ID is represented here with <fileUpload>
                // Button or control for starting the upload. the iploadFile method is called on click.
                protected void uploadFile()
                {
                    if (<fileUpload>.HasFile){
                        try {
                            Byte[] fileBytes = <fileUpload>.FileBytes;
                            string[] parts = <fileUpload>.FileName.Split(".");
                            string extension = "."+ parts[parts.Length -1];
                            FileInfo savedFileInfo = saveByteFile(fileBytes, extension);
                            // shit d'affichage / modification à partir du FileInfo
                            // Accessible: FileInfo.FileName (mon du fichier sauvegardé i.e. son integer code)
                            // etc...
                        }
                        catch(Exception error)
                        {
                            // yadda yadda error handling
                        }
                    }
                }

                // Function fired when a webcontrol offering a download is activated
                // {param} fileName (String) : the file name to download.
                protected void fileDownloader(string fileName)
                {
                    try
                    {
                        HttpContext.Current.Response.ContentType = "application/octet-stream";
                        HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
                        HttpContext.Current.Response.TransmitFile(HttpContext.Current.Server.MapPath(FILE_DIRECTORY_PATH + fileName));
                        HttpContext.Current.Response.End();
                    }
                    catch (Exception error)
                    {
                        // yadda yadda error handling
                    }
                }

        *******************************************************************************************/
    }
}