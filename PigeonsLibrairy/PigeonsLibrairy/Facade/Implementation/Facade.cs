using PigeonsLibrairy.Controller;
using PigeonsLibrairy.Exceptions;
using PigeonsLibrairy.Facade.Interface;
using PigeonsLibrairy.Log;
using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PigeonsLibrairy.Facade.Implementation
{
    /// <summary>
    /// Services partagés par toutes les Facades
    /// </summary>
    public class Facade : IFacade
    {
        /// <summary>
        /// Le controlleur principal des services
        /// </summary>
        public MainController mainControl { get; set; }

        /// <summary>
        /// Le controlleur des fichiers pour le upload/download
        /// </summary>
        public FileController fileControl { get; set; }

        /// <summary>
        /// Constructeur
        /// </summary>
        public Facade()
        {
            mainControl = new MainController();
            fileControl = new FileController();
        }

        #region Person

        /// <summary>
        /// Recherche d'un utilisateur par ID
        /// </summary>
        public person GetPersonByID(object personID)
        {
            try
            {
                return mainControl.PersonService.GetByID(personID);
            }
            catch (ServiceException serviceException)
            {
                ExceptionLog.LogTheError(serviceException.Message);
                return null;
            }
        }

        /// <summary>
        /// Recherche d'un utilisateur selon un valeur donnée dans un colonne de la table person
        /// </summary>
        public List<person> GetPersonBy(string columnName, object value)
        {
            try
            {
                return mainControl.PersonService.GetBy(columnName, value).ToList();
            }
            catch (ServiceException serviceException)
            {
                ExceptionLog.LogTheError(serviceException.Message);
                return null;
            }
        }

        /// <summary>
        /// Mise à jour d'un utilisateur
        /// </summary>
        public person UpdatePerson(object personID, person personToUpdate)
        {
            try
            {
                return mainControl.PersonService.UpdatePerson(personID, personToUpdate);
            }
            catch (ServiceException serviceException)
            {
                ExceptionLog.LogTheError(serviceException.Message);
                return null;
            }
        }

        #endregion Person

        #region Group

        /// <summary>
        /// Recherche d'un groupe selon son ID
        /// </summary>
        public group GetGroupByID(object groupID)
        {
            try
            {
                return mainControl.GroupService.GetByID(groupID);
            }
            catch (ServiceException serviceException)
            {
                ExceptionLog.LogTheError(serviceException.Message);
                return null;
            }
        }

        /// <summary>
        /// Mise à jour des informations d'un groupe
        /// </summary>
        public group UpdateGroup(object groupID, group groupToUpdate)
        {
            try
            {
                return mainControl.GroupService.UpdateGroup(groupID, groupToUpdate);
            }
            catch (ServiceException serviceException)
            {
                ExceptionLog.LogTheError(serviceException.Message);
                return null;
            }
        }

        #endregion Group

        #region File

        /*
        /// <summary>
        /// Sauvegarde d'un fichiersur le serveur
        /// </summary>
        /// <param name="fileByteArray">Un tableau de byte qui reprérente le fichier à sauvegarder</param>
        /// <param name="filename">Le nom complet du fichier</param>
        public FileInfo SaveByteFile(Byte[] fileByteArray, string filename)
        {
            try
            {
                return fileControl.SaveByteFile(null, null);
            }
            catch (ControllerException controllerException)
            {
                ExceptionLog.LogTheError(controllerException.Message);
                return null;
            }
        }

        /// <summary>
        /// Insertion des valeurs d'un ficher dans la base de données
        /// </summary>
        /// <returns></returns>
        public void InsertFileInfo(file fichier)
        {
            try
            {
                fileControl.InsertInDataBase(fichier);
            }
            catch (ServiceException serviceException)
            {
                ExceptionLog.LogTheError(serviceException.Message);
            }
        }
        */

        #endregion File
    }
}