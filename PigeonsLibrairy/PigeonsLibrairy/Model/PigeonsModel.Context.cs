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
    
    /// <summary>
    /// Context de connection pour la base de donnée Pigeons
    /// </summary>
    public partial class pigeonsEntities1 : DbContext
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        public pigeonsEntities1()
            : base("name=pigeonsEntities1")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
    
        /// <summary>
        /// Construction du modèle
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        /// <summary>
        /// DbSet des <see cref="assignation"/>
        /// </summary>
        public virtual DbSet<assignation> assignations { get; set; }

        /// <summary>
        /// DbSet des <see cref="chathistory"/>
        /// </summary>
        public virtual DbSet<chathistory> chathistories { get; set; }

        /// <summary>
        /// DbSet des <see cref="@event"/>
        /// </summary>
        public virtual DbSet<@event> events { get; set; }

        /// <summary>
        /// DbSet des <see cref="following"/>
        /// </summary>
        public virtual DbSet<following> followings { get; set; }

        /// <summary>
        /// DbSet des <see cref="group"/>
        /// </summary>
        public virtual DbSet<group> groups { get; set; }

        /// <summary>
        /// DbSet des <see cref="message"/>
        /// </summary>
        public virtual DbSet<message> messages { get; set; }

        /// <summary>
        /// DbSet des <see cref="person"/>
        /// </summary>
        public virtual DbSet<person> people { get; set; }

        /// <summary>
        /// DbSet des <see cref="task"/>
        /// </summary>
        public virtual DbSet<task> tasks { get; set; }

        /// <summary>
        /// DbSet des <see cref="file"/>
        /// </summary>
        public virtual DbSet<file> files { get; set; }
    }
}
