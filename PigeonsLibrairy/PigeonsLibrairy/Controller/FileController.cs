using PigeonsLibrairy.Exceptions;
using PigeonsLibrairy.Model;
using PigeonsLibrairy.Service.Implementation;
using PigeonsLibrairy.Service.Interface;
using System;
using System.Diagnostics;
using System.IO;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Validation;

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
        private IGroupService groupService { get; set; }
        private IPersonService personService { get; set; }


        // START TEST ACCESS
        public file getFileByID(int fileID)
        {
            return fileService.GetByID(fileID);
        }
        // END TEST ACCESS

        #region Constructeurs

        /// <summary>
        /// Constructeur
        /// </summary>
        public FileController()
        {
            if (!Directory.Exists("~/Server_Files"))
            {
                // Directory.CreateDirectory("~/Server_Files");
            }
            FILE_DIRECTORY_PATH = "~/Server_Files";
            directoryInfo = new DirectoryInfo(HttpContext.Current.Server.MapPath(FILE_DIRECTORY_PATH));
            fileService = new FileService();
            groupService = new GroupService();
            personService = new PersonService();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="PhysicalFileDirectoryPath">The full path to the file directory to specify for the controller.</param>
        public FileController(string PhysicalFileDirectoryPath)
        {
            if (!Directory.Exists(PhysicalFileDirectoryPath))
            {
                Directory.CreateDirectory(PhysicalFileDirectoryPath);
            }
            FILE_DIRECTORY_PATH = PhysicalFileDirectoryPath;
            fileService = new FileService();
            directoryInfo = new DirectoryInfo(FILE_DIRECTORY_PATH);
            groupService = new GroupService();
            personService = new PersonService();
        }

        #endregion Constructeurs


        #region AspCalledMethods


        /// <summary>
        /// Method to add a person-associated picture file both physically on the server and in the database.
        /// The file must be passed as a Byte array parameter.
        /// </summary>
        /// <param name="fileByteArray">The Byte array of the picture file itself.</param>
        /// <param name="personID">The person ID (Int32) of the person the picture is associated to.</param>
        /// <param name="originalFileName">The original file name (String) saved by the database for later user readability</param>
        public void AddPictureToUser(Byte[] fileByteArray, int personID, string originalFileName)
        {
            try
            {
                Debug.WriteLine("FileController AddPictureToUser method called.");
                person personne = personService.GetByID(personID);
                string pictureLink = SaveByteFile(fileByteArray, originalFileName);
                Debug.WriteLine("File saved and picture link returned: " + pictureLink);
                personne.Profile_picture_link = pictureLink;
                personService.UpdatePerson(personID, personne);
                Debug.WriteLine("Personne updated.");

                Debug.WriteLine("Creating file entry in database.");
                file Fichier = new file();
                Fichier.FileURL = pictureLink;
                Debug.WriteLine("file entry fileURL: " + pictureLink);
                Fichier.FileName = originalFileName;
                fileService.InsertFileInformations(Fichier);
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
            }
            catch (Exception error)
            {
                Debug.WriteLine(error.Message);
                // throw new ControllerException(error.Message);
            }
        }

        /// <summary>
        /// Method to add a group-associated picture file both physically on the server and in the database.
        /// The file must be passed as a Byte array parameter.
        /// </summary>
        /// <param name="fileByteArray">The Byte array of the picture file itself.</param>
        /// <param name="groupID">The group ID (Int32) of the group the picture is associated to.</param>
        /// <param name="originalFileName">The original file name (String) saved by the database for later user readability</param>
        public void AddPictureToGroup(Byte[] fileByteArray, int groupID, string originalFileName)
        {
            try
            {
                group groupe = groupService.GetByID(groupID);
                string pictureLink = SaveByteFile(fileByteArray, originalFileName);
                groupe.Group_picture_link = pictureLink;
                groupService.Update(groupe);
                file Fichier = new file();
                Fichier.FileURL = pictureLink;
                Fichier.FileName = originalFileName;
                fileService.InsertFileInformations(Fichier);
            }
            catch (Exception error)
            {
                Debug.WriteLine(error.Message);
                throw new ControllerException(error.Message);
            }

        }

        /// <summary>
        /// Method to add both physically on the server and in the database a file associated to a group.
        /// The file must be passed as a Byte array parameter.
        /// </summary>
        /// <param name="fileByteArray">The Byte array of the file itself.</param>
        /// <param name="groupID">The group ID (Int32) of the group the file is associated to.</param>
        /// <param name="originalFileName">The original file name (String) saved by the database for later user readability</param>
        public void AddAssociatedFileToGroup(Byte[] fileByteArray, int groupID, string originalFileName)
        {
            try
            {
                file Fichier = new file();
                Fichier.FileURL = SaveByteFile(fileByteArray, originalFileName);
                Fichier.Group_ID = groupID;
                Fichier.FileName = originalFileName;
                fileService.InsertFileInformations(Fichier);
            }
            catch (Exception error)
            {
                Debug.WriteLine(error.Message);
                throw new ControllerException(error.Message);
            }
        }

        /// <summary>
        /// Method to download a requested file.
        /// Also sets the response's MIME type so the browser has an idea what to do with it.
        /// </summary>
        /// <param name="FilePath">The file path of the requested file.</param>
        public void DownloadAFile(string FilePath)
        {
            Debug.WriteLine("FileController DownloadAFile method called.");
            try
            {
                FileInfo fileInfo = new FileInfo(HttpContext.Current.Server.MapPath(FilePath));
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ClearHeaders();
                HttpContext.Current.Response.ClearContent();
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + fileInfo.Name);
                HttpContext.Current.Response.AddHeader("Content-Length", fileInfo.Length.ToString());
                HttpContext.Current.Response.ContentType = MimeMapping.GetMimeMapping(fileInfo.FullName);
                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.TransmitFile(fileInfo.FullName);
                HttpContext.Current.ApplicationInstance.CompleteRequest();
                //HttpContext.Current.Response.End();
            }
            catch (Exception error)
            {
                Debug.WriteLine(error.Message);
                //throw new ControllerException(error.Message);
            }
        }


        /// <summary>
        /// Suppression physique d'un fichier sur le serveur par son chemin d'accès.
        /// </summary>
        /// <param name="filePath">Le chemin d'accès du fichier à supprimer (Ex.: "~/Server_Files/3.jpg" - récupérable dans la base de données).</param>
        public void DeleteFileByPath(string filePath)
        {
            try
            {
                // Efface le fichier sur le serveur
                File.Delete(HttpContext.Current.Server.MapPath(filePath));
                fileService.DeleteFileByFilePath(filePath);
            }
            catch (Exception error)
            {
                Debug.WriteLine(error.Message);
                throw new ControllerException(error.Message);
            }
        }


        /// <summary>
        /// Supprime sur le serveur et dans la base de données tous les fichiers associés à un groupe.
        /// </summary>
        /// <param name="groupID">L'ID du groupe dont les fichiers sont à supprimer</param>
        public void DeleteAllGroupAssociatedFiles(int groupID)
        {
            try
            {
                List<file> listeEntreesFichiers = (List<file>)fileService.GetFilesByGroup(groupID);
                foreach (file entreeFichier in listeEntreesFichiers)
                {
                    DeleteFileByPath(entreeFichier.FileURL);
                }
            }
            catch (Exception error)
            {
                Debug.WriteLine(error.Message);
                throw new ControllerException(error.Message);
            }
        }

        /// <summary>
        /// Méthode retournant une List d'objets file représentant tous les fichiers associés à un groupe dont l'ID est
        /// passé en paramètre.
        /// </summary>
        /// <param name="groupID">Un entier représentant l'ID du groupe</param>
        /// <returns></returns>
        public List<file> GetAllGroupFiles(int groupID)
        {
            try
            {
                return (List<file>)fileService.GetFilesByGroup(groupID);
            }
            catch (Exception error)
            {
                Debug.WriteLine(error.Message);
                throw new ControllerException(error.Message);
            }
        }


        #endregion AspCalledMethods


        #region LocalMethods


        /// <summary>
        /// Function to upload a file on the server.
        /// Files are saved with a generated name being an incremental integer.
        /// Examples: 1.jpg, 2.jpg, 3.pdf, 4.png ...
        /// </summary>
        /// <param name="fileByteArray">a Byte array of the file itself</param>
        /// <param name="originalFileName">a string of the original file's full name (name + extension)</param>
        /// <returns>A string of the file path on the server</returns>
        private string SaveByteFile(Byte[] fileByteArray, string originalFileName)
        {
            Debug.WriteLine("FileController SaveByteFile method called.");
            try
            {
                // find highest file "name" (integer code) in order to save the file to the next incrementation.
                int highestFileID = 0;
                FileInfo[] fileInfoArray = directoryInfo.GetFiles("*.*");
                Debug.WriteLine("Looking for files in: " + directoryInfo.FullName);
                foreach (FileInfo fileInfo in fileInfoArray)
                {
                    Debug.WriteLine("File found: " + fileInfo.FullName);
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
                Debug.WriteLine("Next free file ID code found: " + (highestFileID + 1));
                Debug.WriteLine("Writing file to target directory: " + HttpContext.Current.Server.MapPath(newFilePath));
                File.WriteAllBytes(HttpContext.Current.Server.MapPath(newFilePath), fileByteArray);
                return newFilePath;
            }
            catch (Exception error)
            {
                Debug.WriteLine(error.Message);
                throw new ControllerException(error.Message);
            }
        }


        /// <summary>
        /// Insertion des information d'un fichier dans la base de données
        /// </summary>
        /// <returns></returns>
        private Boolean InsertInDataBase(file File)
        {
            Boolean InsertCompleted = false;
            try
            {
                fileService.InsertFileInformations(File);
                InsertCompleted = true;
            }
            catch (Exception error)
            {
                Debug.WriteLine(error.Message);
                throw new ControllerException(error.Message);
            }
            return InsertCompleted;
        }


        #endregion LocalMethods


        /*
        /// <summary>
        /// Function to retrieve a file from the server by its file integer code or filename as saved in the database
        /// </summary>
        /// <param name="fileName">The file name / integer code to lookup and retrieve.</param>
        /// <returns>A FileInfo object representing the file information on the server (path and such).</returns>
        public FileInfo GetFileByName(string filePath)
        {
            FileInfo fileToGet = null;
            try
            {
                // find file by specified filename
                fileToGet = new FileInfo(Directory.GetFiles(FILE_DIRECTORY_PATH, fileName)[0]);
                Debug.WriteLine("Fichier trouvé: " + fileToGet.ToString());
            }
            catch (Exception error)
            {
                Debug.WriteLine(error.Message);
                throw new ControllerException(error.Message);
            }
            return fileToGet;
        }
        */
        
    }
}