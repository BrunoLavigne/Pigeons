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
    
    public partial class project
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public project()
        {
            this.tasks = new HashSet<task>();
        }
    
        public int Id { get; set; }
        public int Group_id { get; set; }
        public int Type_id { get; set; }
        public System.DateTime Date_start { get; set; }
        public System.DateTime Date_end { get; set; }
        public string Description { get; set; }
    
        public virtual group group { get; set; }
        public virtual type type { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<task> tasks { get; set; }

        public enum COLUMN_NAME { GROUP_ID, TYPE_ID, DATE_START, DATE_END, DESCRIPTION }
    }
}
