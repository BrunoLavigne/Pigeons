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
    
    public partial class assignation
    {
        public const string COLUMN_PERSON_ID    = "person_id";
        public const string COLUMN_TASK_ID      = "task_id";

        public int ID { get; set; }
        public int Task_ID { get; set; }
        public int Person_ID { get; set; }
    
        public virtual person person { get; set; }
        public virtual task task { get; set; }
    }
}
