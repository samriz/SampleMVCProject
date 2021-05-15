using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewTest.Controllers
{
    public class Pagination
    {
        private readonly int recordsPerPage;
        private int pageNumber = 1;
        private double overallNumberOfRowsInTable;
        private int numberOfPages;

        public Pagination(int recordsPerPage)
        {
            this.recordsPerPage = recordsPerPage;
        }

        //returns maximum number of pages allowed in table based on number of rows in each page
        public void SetNumberOfPages()
        {
            //divide the number of rows in the table by the number of allowed records per page.
            double pages = overallNumberOfRowsInTable / recordsPerPage;

            
            //next, we need to figure out the max # of pages alowed in our pagination:

            //first, set the max # of pages to 0 and then calculate it
            int maxNumberOfPages = 0;
            
            //determine # of pages by dividing the # of sql table rows by the # of records allowed per page
            /*we need a whole number because if # of rows is 1012 and records per page is 100, this will be 10.12 pages which isn't acceptable.
            need whole number. if not whole number, then cast to int(which will make it into a whole number) and then increment by 1
            we need to increment by 1 because cast a double to an int will make the number round down. We need to round up so 10.12 pages should be 11 pages*/
            if (overallNumberOfRowsInTable % recordsPerPage > 0)
            {
                //when casting double to int, it will round down because it simply cuts off decimal and everything after decimal
                //example: 10.12 will become 10. We need 10.12 to become 11so that is why I am incrementing maxNumberOfPages by 1
                maxNumberOfPages = (int)pages;
                ++maxNumberOfPages;
            }
            numberOfPages = maxNumberOfPages;
        }
    }
}