using PigeonsLibrairy.DAO.Implementation;
using PigeonsLibrairy.Exceptions;
using PigeonsLibrairy.Model;
using PigeonsLibrairy.Service.Implementation;
using PigeonsLibrairy.Service.Interface;
using System;

namespace PigeonsLibrairy.Controller
{
    public class Controller : IDisposable
    {
        private pigeonsEntities1 context = new pigeonsEntities1();
        
        private IMessageService messageService;        
        private IPersonService personService;
        private IGroupService groupeService;
        private IFollowingService followingService;
        private IProjectService projectService;
        private ITaskService taskService;
        private ITypeService typeService;

        /// <summary>
        /// Création du Service pour la table Person
        /// Vérifacation si le dao est null pour conserver le même context
        /// </summary>
        public IPersonService PersonService
        {
            get
            {
                if(this.personService == null)
                {
                    this.personService = new PersonService(context);
                }
                return personService;
            }
        }

        /// <summary>
        /// Création du Service pour la table Message
        /// Vérifacation si le dao est null pour conserver le même context
        /// </summary>
        public IMessageService MessageService
        {
            get
            {
                if (this.messageService == null)
                {
                    this.messageService = new MessageService(context);
                }
                return messageService;
            }
        }

        /// <summary>
        /// Création du Service pour la table Group
        /// Vérifacation si le dao est null pour conserver le même context
        /// </summary>
        public IGroupService GroupService
        {
            get
            {
                if (this.groupeService == null)
                {
                    this.groupeService = new GroupService(context);
                }
                return groupeService;
            }
        }

        /// <summary>
        /// Création du Service pour la table Following
        /// Vérifacation si le dao est null pour conserver le même context
        /// </summary>
        public IFollowingService FollowingService
        {
            get
            {
                if (this.followingService == null)
                {
                    this.followingService = new FollowingService(context);
                }
                return followingService;
            }
        }

        /// <summary>
        /// Création du Service pour la table Events
        /// Vérifacation si le dao est null pour conserver le même context
        /// </summary>
        public IProjectService ProjectService
        {
            get
            {
                if (this.projectService == null)
                {
                    this.projectService = new ProjectService(context);
                }
                return projectService;
            }
        }

        /// <summary>
        /// Création du Service pour la table Task
        /// Vérifacation si le dao est null pour conserver le même context
        /// </summary>
        public ITaskService TaskService
        {
            get
            {
                if (this.taskService == null)
                {
                    this.taskService = new TaskService(context);
                }
                return taskService;
            }
        }

        /// <summary>
        /// Création du Service pour la table Type
        /// Vérifacation si le dao est null pour conserver le même context
        /// </summary>
        public ITypeService TypeService
        {
            get
            {
                if (this.typeService == null)
                {
                    this.typeService = new TypeService(context);
                }
                return typeService;
            }
        }

        /// <summary>
        /// Enregistrement des modifications dans la base de données
        /// </summary>
        public void Save()
        {
            try
            {
                context.SaveChanges();                
            }
            catch
            {
                throw new ControllerException("There was an error while saving");
            }
            
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
