// function to clear out rows
function clearRows(employeesTable)
{
    // if the employees table has any rows and the number of rows is greater than 1 (the first row in the column headers)
    if (employeesTable.hasChildNodes() && employeesTable.childElementCount > 1)
    {
        for (let i = 1; i < employeesTable.childElementCount; i++)
        {
            //except for row zero, empty out each row to make way for new page's data
            if (employeesTable.children[i] != undefined || employeesTable.children[i] != null)
            {
                if (employeesTable.children[i].innerHTML.length > 0) employeesTable.children[i].innerHTML = "";
            }
        }
    }
}