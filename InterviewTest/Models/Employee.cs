//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InterviewTest.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public Nullable<bool> isPartTime { get; set; }
        public Nullable<bool> remote { get; set; }
        public Nullable<int> positionId { get; set; }
        public Nullable<int> officeId { get; set; }
        public Nullable<System.DateTime> startDate { get; set; }
        public Nullable<System.DateTime> endDate { get; set; }
    }
}