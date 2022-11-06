using Employees.Common.Models.API;
using Microsoft.EntityFrameworkCore;

namespace Employees.Common.Data
{
    public class EmployeesDbContext : DbContext
    {

        public EmployeesDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
    }
}