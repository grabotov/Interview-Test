﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InterviewTestTemplatev2.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class MvcInterviewContext : DbContext
    {
        public MvcInterviewContext()
            : base("name=MvcInterviewV3Entities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<HrDepartment> HrDepartments { get; set; }
        public virtual DbSet<HrEmployee> HrEmployees { get; set; }
    }
}
