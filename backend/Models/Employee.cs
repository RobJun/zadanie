namespace backend.models;


public class Employee {

    public long id {get; set;}
    public string Name {get; set;}

    public string LastName {get; set;}

    public string? Address {get; set;}

    public DateOnly DateOfBirth {get; set;}

    public DateOnly StartingDate {get;set;}

    public decimal Salary {get; set;}

    public virtual ICollection<PositionsEmployee> Positions {get; set;}
}