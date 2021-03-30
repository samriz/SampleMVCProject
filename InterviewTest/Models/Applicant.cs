using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewTest.Models
{
    public class Applicant
    {
        private string firstName; //required
        private string middleName;
        private string lastName; //required
        private int positionID; //required
        private string comments;
        private bool remote; //required

        public Applicant() { }

        public Applicant(string firstName, string lastName, int positionID, bool remote, string middleName = null, string comments = null)
        {
            this.firstName = firstName;
            this.middleName = middleName;
            this.lastName = lastName;
            this.positionID = positionID;
            this.comments = comments;
            this.remote = remote;
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string MiddleName
        {
            get { return middleName; }
            set { middleName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public int PositionID
        {
            get { return positionID; }
            set { positionID = value; }
        }

        public string Comments
        {
            get { return comments; }
            set { comments = value; }
        }

        public bool Remote
        {
            get { return remote; }
            set { remote = value; }
        }

    }
}