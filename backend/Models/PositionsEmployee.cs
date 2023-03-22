using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace backend.models;

public class PositionsEmployee{
    public long id { get; set;}
    
    public long PositionId { get; set;}
    public virtual Position Position {get; set;}

    [JsonIgnore]
    public long EmployeeId {get; set;}  
    [JsonIgnore]
    public  virtual Employee Employee {get; set;}

    public DateOnly Start {get;set;}

    public DateOnly? End {get; set;}
}