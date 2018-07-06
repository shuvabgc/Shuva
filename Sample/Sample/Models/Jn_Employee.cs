using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sample.Models
{
    public class Jn_Employee
    {
        [Key]
        public Int64 Empid { get; set; }
        public string Empname { get; set; }
        public string Empaddress { get; set; }
        public decimal Empsalary{ get; set; }
        public string Empemail { get; set; }
        public DateTime Empdateofbirth { get; set; }

        public int DesignId { get; set; }
        public virtual Jn_DesignationByEmployee Designation { get; set; }


    }
    public class Jn_DesignationByEmployee
    {
        [Key]
        public int DesignId { get; set; }
        public string DesignationName { get; set; }
        public virtual ICollection<Jn_Employee> emp { get; set; }
    }
    public class Branch
    {
        [Key]
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public string SwiftCode { get; set; }
        public int BankId { get; set; }
        public virtual Bank Bank { get; set; }
    }

    public class Bank
    {
        [Key]
        public int BankId { get; set; }
        public string BankName { get; set; }
        public string BankCode { get; set; }
        public virtual ICollection<Branch> branch { get; set; }
    }
}