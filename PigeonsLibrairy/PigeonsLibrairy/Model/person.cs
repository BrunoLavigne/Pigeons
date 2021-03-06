//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PigeonsLibrairy.Model
{
    using System;
    using System.Collections.Generic;
    
    /// <summary>
    /// Table person
    /// </summary>
    public partial class person
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public person()
        {
            this.assignations = new HashSet<assignation>();
            this.chathistories = new HashSet<chathistory>();
            this.followings = new HashSet<following>();
            this.messages = new HashSet<message>();
        }

        /// <summary>
        /// Colonne person_id
        /// </summary>
        public const string COLUMN_PERSON_ID = "person_id";

        /// <summary>
        /// Colonne name
        /// </summary>
        public const string COLUMN_NAME = "name";

        /// <summary>
        /// Colonne email
        /// </summary>
        public const string COLUMN_EMAIL = "email";

        /// <summary>
        /// Colonne password
        /// </summary>
        public const string COLUMN_PASSWORD = "password";

        /// <summary>
        /// Colonne inscription_date
        /// </summary>
        public const string COLUMN_INSCRIPTION_DATE = "inscription_date";

        /// <summary>
        /// Colonne birth_date
        /// </summary>
        public const string COLUMN_BIRTH_DATE = "birth_date";

        /// <summary>
        /// Colonne phone_number
        /// </summary>
        public const string COLUMN_PHONE_NUMBER = "phone_number";

        /// <summary>
        /// Colonne organization
        /// </summary>
        public const string COLUMN_ORGANIZATION = "organization";

        /// <summary>
        /// Colonne position
        /// </summary>
        public const string COLUMN_POSITION = "position";

        /// <summary>
        /// Colonne description
        /// </summary>
        public const string COLUMN_DESCRIPTION = "description";

        /// <summary>
        /// Colonne name et email
        /// </summary>
        public const string COLUMN_ALL = "all";

        /// <summary>
        /// Cl� primaire de la table person
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nom de la personne (pr�nom et nom de famille)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Courriel de la person
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Mot de passe de la person
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Date d'inscription de la person
        /// </summary>
        public System.DateTime Inscription_date { get; set; }

        /// <summary>
        /// Lien ves la photo de profile
        /// </summary>
        public string Profile_picture_link { get; set; }

        /// <summary>
        /// Date de naisance de la person
        /// </summary>
        public System.DateTime Birth_date { get; set; }

        /// <summary>
        /// Num�ro de t�l�phone de la person (peut �tre null)
        /// </summary>
        public string Phone_number { get; set; }

        /// <summary>
        /// Organisation de la person (peut �tre null)
        /// </summary>
        public string Organization { get; set; }

        /// <summary>
        /// Position de la personne (peut �tre null)
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// Description de la person (peut �tre null)
        /// </summary>
        public string Description { get; set; }
    
        /// <summary>
        /// Liste des assignations d'une person
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<assignation> assignations { get; set; }

        /// <summary>
        /// Historique des messages de chat d'une person
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<chathistory> chathistories { get; set; }

        /// <summary>
        /// Liste des group suivi par une person
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<following> followings { get; set; }
        
        /// <summary>
        /// Liste des message d'une person
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<message> messages { get; set; }
    }
}
