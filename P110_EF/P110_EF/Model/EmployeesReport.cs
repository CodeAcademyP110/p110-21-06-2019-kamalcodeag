//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace P110_EF.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class EmployeesReport
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public Nullable<decimal> Salary { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public string Position { get; set; }
        public string ReportsTo { get; set; }
        public string Departament { get; set; }
    }
}