using System;
using System.IO;

namespace PigeonsLibrairy.Log
{
    /// <summary>
    /// Classe pour enregistrer les erreur qui sont survenu lors de l'excécution
    /// </summary>
    static class ExceptionLog
    {
        /// <summary>
        /// La location du fichier
        /// </summary>
        private const string LOGGER_FILE = "../../Log/LoggerFile.txt";

        /// <summary>
        /// Enregistrement des erreurs
        /// </summary>
        /// <param name="errorMessage">Le message à insérer dans le fichier</param>
        public static void LogTheError(string errorMessage)
        {
            using(StreamWriter logger = new StreamWriter(LOGGER_FILE, true))
            {
                logger.WriteLine("[" + DateTime.Now + " ] : ERROR : " + errorMessage);
                logger.Close();
            }
        }
    }
}
