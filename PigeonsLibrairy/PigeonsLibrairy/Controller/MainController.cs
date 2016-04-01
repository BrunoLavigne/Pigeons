using PigeonsLibrairy.Service.Implementation;
using PigeonsLibrairy.Service.Interface;

namespace PigeonsLibrairy.Controller
{
    /// <summary>
    /// Controlleur regroupant tout les services
    /// </summary>
    public class MainController
    {       
        private IMessageService messageService;        
        private IPersonService personService;
        private IGroupService groupeService;
        private IFollowingService followingService;
        private IProjectService projectService;
        private ITaskService taskService;
        private ITypeService typeService;

        /// <summary>
        /// Création du Service pour la table <see cref="Model.person"/>
        /// Vérifacation si le dao est null pour conserver le même context
        /// </summary>
        public IPersonService PersonService
        {
            get
            {
                if(this.personService == null)
                {
                    this.personService = new PersonService();
                }
                return personService;
            }
        }

        /// <summary>
        /// Création du Service pour la table <see cref="Model.message"/>
        /// Vérifacation si le dao est null pour conserver le même context
        /// </summary>
        public IMessageService MessageService
        {
            get
            {
                if (this.messageService == null)
                {
                    this.messageService = new MessageService();
                }
                return messageService;
            }
        }

        /// <summary>
        /// Création du Service pour la table <see cref="Model.group"/>
        /// Vérifacation si le dao est null pour conserver le même context
        /// </summary>
        public IGroupService GroupService
        {
            get
            {
                if (this.groupeService == null)
                {
                    this.groupeService = new GroupService();
                }
                return groupeService;
            }
        }

        /// <summary>
        /// Création du Service pour la table <see cref="Model.following"/>
        /// Vérifacation si le dao est null pour conserver le même context
        /// </summary>
        public IFollowingService FollowingService
        {
            get
            {
                if (this.followingService == null)
                {
                    this.followingService = new FollowingService();
                }
                return followingService;
            }
        }

        /// <summary>
        /// Création du Service pour la table <see cref="Model.project"/>
        /// Vérifacation si le dao est null pour conserver le même context
        /// </summary>
        public IProjectService ProjectService
        {
            get
            {
                if (this.projectService == null)
                {
                    this.projectService = new ProjectService();
                }
                return projectService;
            }
        }

        /// <summary>
        /// Création du Service pour la table <see cref="Model.task"/>
        /// Vérifacation si le dao est null pour conserver le même context
        /// </summary>
        public ITaskService TaskService
        {
            get
            {
                if (this.taskService == null)
                {
                    this.taskService = new TaskService();
                }
                return taskService;
            }
        }

        /// <summary>
        /// Création du Service pour la table <see cref="Model.type"/>
        /// Vérifacation si le dao est null pour conserver le même context
        /// </summary>
        public ITypeService TypeService
        {
            get
            {
                if (this.typeService == null)
                {
                    this.typeService = new TypeService();
                }
                return typeService;
            }
        }
    }
}
