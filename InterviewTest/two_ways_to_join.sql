select Employee.firstName, Employee.lastName, Office.officeName from Employee inner join Office on Employee.officeId = Office.id

select Employee.firstName, Employee.lastName, Office.officeName from Employee, Office where Employee.officeId = Office.id