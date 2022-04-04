class Employee
{
    #firstName;
    #lastName;
    #officeName;
    #position;

    constructor(firstName, lastName, officeName, position)
    {
        this.#firstName = firstName;
        this.#lastName = lastName;
        this.#officeName = officeName;
        this.#position = position;

        //if (typeof firstName === "string") this.#firstName = firstName;
        //else console.log("firstName must be a string.");

        //if (typeof lastName === "string") this.#lastName = lastName;
        //else console.log("lastName must be a string.");

        //if (typeof officeName === "string") this.#officeName = officeName;
        //else console.log("officeName must be a string.");

        //if (typeof position === "string") this.#position = position;
        //else console.log("position must be a string.");
    }

    get firstName() { return this.#firstName; }
    get lastName() { return this.#lastName; }
    get officeName() { return this.#officeName; }
    get position() { return this.#position; }

    set firstName(firstName) { this.#firstName = firstName; }
    set lastName(lastName) { this.#lastName = lastName; }
    set officeName(officeName) { this.#officeName = officeName; }
    set position(position) { this.#position = position; }
}

class Employees
{
    #ListOfEmployees;
    constructor()
    {
        this.#ListOfEmployees = new Array();
        //if (Employees === null || Employees === undefined) this.#ListOfEmployees = new Array();
        //else if (typeof Employees === "object")
        //{
        //    if (Array.isArray(Employees)) this.#ListOfEmployees = Employees;
        //    else console.log("Employees needs to be an array.");
        //}
        //else console.log("Employees needs to be an array.");
    }
    get ListOfEmployees() { return this.#ListOfEmployees; }
    set ListOfEmployees(ListOfEmployees) { this.#ListOfEmployees = ListOfEmployees; }
}