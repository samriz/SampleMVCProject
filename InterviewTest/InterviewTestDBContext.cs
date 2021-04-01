using InterviewTest.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InterviewTest
{
    public class InterviewTestDBContext : DbContext
    {
        public InterviewTestDBContext() : base("DefaultConnection")
        {

        }
        public DbSet<Applicant> Applicants { get; set; }
    }
}