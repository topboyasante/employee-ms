using employee_ms.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace employee_ms.Data;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
    {
        
    }

    public DbSet<Employee> Employees { get; set;}
}
