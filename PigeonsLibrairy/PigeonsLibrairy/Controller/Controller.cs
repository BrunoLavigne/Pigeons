using PigeonsLibrairy.DAO;
using PigeonsLibrairy.DAO.Implementation;
using PigeonsLibrairy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigeonsLibrairy.Controller
{
    public class Controller : IDisposable
    {
        private pigeonsEntities1 context = new pigeonsEntities1();
        
        private PersonDAO personDAO;
        private MessageDAO messageDAO;
        private GroupDAO groupDAO;

        /// <summary>
        /// Création du DAO pour la table Person
        /// Vérifacation si le dao est null pour conserver le même context
        /// </summary>
        public PersonDAO PersonDAO
        {
            get
            {
                if (this.personDAO == null)
                {
                    this.personDAO = new PersonDAO(context);
                }
                return personDAO;
            }
        }

        /// <summary>
        /// Création du DAO pour la table Message
        /// Vérifacation si le dao est null pour conserver le même context
        /// </summary>
        public MessageDAO MessageDAO
        {
            get
            {
                if (this.messageDAO == null)
                {
                    this.messageDAO = new MessageDAO(context);
                }
                return messageDAO;
            }
        }

        /// <summary>
        /// Création du DAO pour la table Group
        /// Vérifacation si le dao est null pour conserver le même context
        /// </summary>
        public GroupDAO GroupDAO
        {
            get
            {
                if (this.groupDAO == null)
                {
                    this.groupDAO = new GroupDAO(context);
                }
                return groupDAO;
            }
        }

        /// <summary>
        /// Enregistrement des modifications dans la base de données
        /// </summary>
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        /// <summary>
        /// Méthode pour éliminer le context
        /// </summary>
        /// <param name="disposing">Validation que le context peut être disposé</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Dispose le context
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
