﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class pigeonsEntities1 : DbContext
    {
        public pigeonsEntities1()
            : base("name=pigeonsEntities1")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<group> groups { get; set; }
        public virtual DbSet<message> messages { get; set; }
        public virtual DbSet<person> people { get; set; }
        public virtual DbSet<task> tasks { get; set; }
        public virtual DbSet<following> followings { get; set; }
        public virtual DbSet<assignation> assignations { get; set; }
        public virtual DbSet<@event> events { get; set; }
        public virtual DbSet<chathistory> chathistories { get; set; }
    }
}
