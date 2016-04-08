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
        protected MainController mainControl { get; set; }
        protected FileController fileControl { get; set; }

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

        #endregion Group

        #region FileControl

        /// <summary>
        /// Sauvegarde d'un fichiersur le serveur
        /// </summary>
        /// <param name="fileByteArray">Un tableau de byte qui reprérente le fichier à sauvegarder</param>
        /// <param name="fileExtension">L'extension du fichier</param>        
        public FileInfo SaveByteFile(Byte[] fileByteArray, string fileExtension)
        {
            try
            {
                return fileControl.saveByteFile(null, null);
            }
            catch(ControllerException controllerException)
            {
                ExceptionLog.LogTheError(controllerException.Message);
                return null;
            }
        }

        #endregion FileControl
    }
}
