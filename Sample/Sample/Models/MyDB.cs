using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace Sample.Models
{
    public class MyDB : DbContext
    {
        public DbSet<Jn_Employee> Employee { get; set; }
        public DbSet<Jn_DesignationByEmployee> employeeDesig {get;set;}
        public DbSet<Bank> bank { get; set; }
        public DbSet<Branch> branch { get; set; }
    }
}