using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewTest.Classes
{
    public class Pagination
    {
        private readonly int recordsPerPage;
        private int pageNumber;
        private double overallNumberOfRowsInTable;
        private int numberOfPages;
        IEnumerable<dynamic> queryList;

        public Pagination(int overallNumberOfRowsInTable, int recordsPerPage, int pageNumber = 1)
        {
            this.queryList = new List<dynamic>();
            this.pageNumber = pageNumber;
            this.overallNumberOfRowsInTable = overallNumberOfRowsInTable;
            this.recordsPerPage = recordsPerPage;
        }
        //returns maximum number of pages allowed in table based on number of rows in each page
        public void SetNumberOfPages()
        {
            //divide the number of rows in the table by the number of allowed records per page.
            double pages = overallNumberOfRowsInTable / recordsPerPage;

            //next, we need to figure out the max # of pages allowed in our pagination:

            //first, set nPages to 0 and then calculate it
            int nPages = 0;

            //determine # of pages by dividing the # of sql table rows by the # of records allowed per page
            /*we need a whole number because if # of rows is 1012 and records per page is 100, this will be 10.12 pages which isn't acceptable.
            need whole number. if not whole number, then cast to int(which will make it into a whole number) and then increment by 1
            we need to increment by 1 because cast a double to an int will make the number round down. We need to round up so 10.12 pages should be 11 pages*/
            if (overallNumberOfRowsInTable % recordsPerPage > 0)
            {
                //when casting double to int, it will round down because it simply cuts off decimal and everything after decimal
                //example: 10.12 will become 10. We need 10.12 to become 11 so that is why I am incrementing maxNumberOfPages by 1
                nPages = (int)pages;
                ++nPages;
            }
            numberOfPages = nPages;
        }
        public IEnumerable<dynamic> Paginate(int pageNumber)
        {
            var lastNameConstraintQuery = from item in this.queryList orderby item.lastName select item;

            //page 1: 1-100
            //page 2: 101-200
            //page 3: 201-300
            var newRows = lastNameConstraintQuery.Skip((pageNumber * recordsPerPage) - 100).Take(recordsPerPage);
            return newRows;
        }
        public IEnumerable<dynamic> Paginate(IEnumerable<dynamic> queryList, int pageNumber)
        {
            var lastNameConstraintQuery = from item in queryList orderby item.lastName select item;

            //page 1: 1-100
            //page 2: 101-200
            //page 3: 201-300
            var newRows = lastNameConstraintQuery.Skip((pageNumber * recordsPerPage) - 100).Take(recordsPerPage);
            return newRows;
        }
        public void IncrementPage()
        {
            if (!(pageNumber > numberOfPages)) ++pageNumber;
            else return;
        }
        public void DecrementPage()
        {
            if (!(pageNumber < 1)) --pageNumber;
            else return;
        }
    }
}