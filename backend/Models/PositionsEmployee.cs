using System.ComponentModel.DataAnnotations;

namespace backend.models;

public class PositionsEmployee{
    public long id { get; set;}
    
    public long PositionId { get; set;}
    public virtual Position Position {get; set;}

    public long EmployeeId {get; set;}
    public  virtual Employee Employee {get; set;}

    public DateOnly start {get;set;}

    public DateOnly? end {get; set;}
}