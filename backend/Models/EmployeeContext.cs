using Microsoft.EntityFrameworkCore;

namespace backend.models;

public class EmployeeContext : DbContext {
    public EmployeeContext(DbContextOptions<EmployeeContext> options)
        : base(options) {}

    public DbSet<Employee> Employees {get; set;}
    public DbSet<Position> Positions {get; set;}
    public DbSet<PositionsEmployee> PositionsEmployees {get;set;}
}