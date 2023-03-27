export class Employee {
    id: Number;
    name: string;
    lastName: string;
    salary: Number;
    dateOfBirth: string;
    actPosition: string;

    public constructor(id: Number, name : string, lastName: string, 
        salary: Number,dateOfBirth:string,actPosition: string){
            this.id = id;
            this.name = name;
            this.lastName = lastName;
            this.salary = salary;
            this.dateOfBirth = dateOfBirth;
            this.actPosition = actPosition;
    }
}