using Microsoft.EntityFrameworkCore;
using OvetimePolicies1.Core.Domain.Authentication.Entities;
using OvetimePolicies1.Core.Domain.EmployeeSalaries.Entities;
using OvetimePolicies1.Core.Domain.EmployeeSalaries.ValueObjects;
using OvetimePolicies1.Infra.Data.Sql.Commands.Common.ValueConverters;
using System.Reflection;
using Zamin.Extensions.Events.Outbox.Dal.EF;

namespace OvetimePolicies1.Infra.Data.Sql.Commands.Common;

public class OvetimePolicies1CommandDbContext : BaseOutboxCommandDbContext
{
    public OvetimePolicies1CommandDbContext(DbContextOptions<OvetimePolicies1CommandDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<Deleted>().HaveConversion<DeletedValueConverter>();
        configurationBuilder.Properties<OvertimeCalculatorName>().HaveConversion<OvertimeCalculatorNameValueConverter>();
        base.ConfigureConventions(configurationBuilder);
    }

    public DbSet<EmployeeSalary> EmployeeSalaries { get; set; }

    public DbSet<User> Users { get; set; }
}