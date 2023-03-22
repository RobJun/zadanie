namespace backend.models;


public class EmployeeCreation {
    public string Name {get; set;}

    public string LastName {get; set;}

    public string? Address {get; set;}

    public DateOnly DateOfBirth {get; set;}

    public DateOnly StartingDate {get;set;}

    public decimal Salary {get; set;}

    public long PositionId {get;set;}
}