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
    using System.ComponentModel.DataAnnotations;

    public partial class Region
    {
        [Key]
        public int id { get; set; }

        [StringLength(250, MinimumLength = 1, ErrorMessage = "Name must be under 251 characters.")]
        public string name { get; set; }
    }
}
