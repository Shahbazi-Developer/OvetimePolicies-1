using Microsoft.EntityFrameworkCore;
using OvetimePolicies1.Infra.Data.Sql.Queries.EmployeeSalaries.Entities;
using System.Reflection;
using Zamin.Infra.Data.Sql.Queries;

namespace OvetimePolicies1.Infra.Data.Sql.Queries.Common;

public class OvetimePolicies1QueryDbContext : BaseQueryDbContext
{
    public OvetimePolicies1QueryDbContext(DbContextOptions<OvetimePolicies1QueryDbContext> options) : base(options)
    {
    }

    public DbSet<EmployeeSalary> EmployeeSalaries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}