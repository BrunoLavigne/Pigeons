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
    
    public partial class task
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public task()
        {
            this.assignations = new HashSet<assignation>();
        }

        public const string COLUMN_PERSON_ID    = "person_id";
        public const string COLUMN_DESCRIPTION  = "description";
        public const string COLUMN_IS_COMPLETED = "is_completed";
        public const string COLUMN_GROUP_ID     = "group_id";
        public const string COLUMN_TASK_START   = "task_start";
        public const string COLUMN_TASK_END     = "task_end";

        public int Id { get; set; }
        public string Description { get; set; }
        public bool Is_completed { get; set; }
        public int Group_ID { get; set; }
        public Nullable<System.DateTime> Task_Start { get; set; }
        public Nullable<System.DateTime> Task_End { get; set; }
        public int Author_ID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<assignation> assignations { get; set; }
        public virtual group group { get; set; }
        public virtual person person { get; set; }
    }
}
