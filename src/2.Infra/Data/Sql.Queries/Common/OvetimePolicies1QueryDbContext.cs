using Microsoft.EntityFrameworkCore;
using OvetimePolicies1.Infra.Data.Sql.Queries.EmployeeSalaries.Entities;
using Zamin.Infra.Data.Sql.Queries;

namespace OvetimePolicies1.Infra.Data.Sql.Queries.Common;

public class OvetimePolicies1QueryDbContext : BaseQueryDbContext
{
    public OvetimePolicies1QueryDbContext(DbContextOptions<OvetimePolicies1QueryDbContext> options) : base(options)
    {
    }

    public DbSet<EmployeeSalary> EmployeeSalaries { get; set; }
}