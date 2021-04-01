using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InterviewTest.Models
{
    public class Applicant
    {

        public int ID { get; set; }

        [Required]
        [StringLength(maximumLength: 250, MinimumLength = 1)]
        public string firstName { get; set; } //required

        [StringLength(maximumLength: 250, MinimumLength = 1)]
        public string middleName { get; set; }

        [Required]
        [StringLength(maximumLength: 250, MinimumLength = 1)]
        public string lastName { get; set; } //required

        [Required]
        public int positionID { get; set; } //required
       
        public string comments { get; set; }

        [Required]
        public bool? isRemote { get; set; } //required

        public Applicant() { }

        /*public Applicant(string firstName, string lastName, int positionID, bool isRemote, string middleName = null, string comments = null)
        {
            this.firstName = firstName;
            this.middleName = middleName;
            this.lastName = lastName;
            this.positionID = positionID;
            this.comments = comments;
            this.isRemote = isRemote;
        }*/
    }
}