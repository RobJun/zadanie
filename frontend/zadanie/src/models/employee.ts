import type {Positions} from '@/models/position'
type EmployeePosition ={
    id : Number;
    positionId : Number;
    position : Positions;
    start : string;
    end : string;
}

export class Employee {
    id: Number;
    name: string;
    lastName: string;
    salary: Number;
    dateOfBirth: string;
    address: string;
    startingDate : string
    positions : EmployeePosition[]
}