﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace sr26
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Sr26Entities : DbContext
    {
        public Sr26Entities()
            : base("name=Sr26Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<FD_GROUP> FD_GROUP { get; set; }
        public DbSet<FOOD_DES> FOOD_DES { get; set; }
        public DbSet<NUT_DATA> NUT_DATA { get; set; }
        public DbSet<NUTR_DEF> NUTR_DEF { get; set; }
    }
}
