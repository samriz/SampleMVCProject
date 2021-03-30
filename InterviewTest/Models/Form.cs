using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewTest.Models
{
    public class Form
    {
        private string firstName;
        private string middleName;
        private string lastName;
        private int positionID;
        private string comments;
        private string remote;

        //getters
        public string GetFirstName() => firstName;
        public string GetMiddleName() => middleName;
        public string GetLastName() => lastName;
        public int GetPositionID() => positionID;
        public string GetComments() => comments;
        public string GetRemote() => remote;

        //setters
        public void SetFirstName(string firstName) => this.firstName = firstName;
        public void SetMiddleName(string middleName) => this.middleName = middleName;
        public void SetLastName(string lastName) => this.lastName = lastName;
        public void SetPositionID(int positionID) => this.positionID = positionID;
        public void SetComments(string comments) => this.comments = comments;
        public void SetRemote(string remote) => this.remote = remote;


    }
}