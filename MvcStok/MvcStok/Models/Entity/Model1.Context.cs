﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcStok.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DBMvcStokEntities : DbContext
    {
        public DBMvcStokEntities()
            : base("name=DBMvcStokEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TBLKATEGORİ> TBLKATEGORİ { get; set; }
        public virtual DbSet<TBLMUSTERİ> TBLMUSTERİ { get; set; }
        public virtual DbSet<TBLPERSONEL> TBLPERSONEL { get; set; }
        public virtual DbSet<TBLSATİS> TBLSATİS { get; set; }
        public virtual DbSet<TBLURUNLER> TBLURUNLER { get; set; }
        public virtual DbSet<TBLADMIN> TBLADMIN { get; set; }
    }
}
