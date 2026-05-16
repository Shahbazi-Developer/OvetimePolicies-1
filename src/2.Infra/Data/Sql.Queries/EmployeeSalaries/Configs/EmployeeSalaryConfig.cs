using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OvetimePolicies1.Infra.Data.Sql.Queries.EmployeeSalaries.Entities;

namespace OvetimePolicies1.Infra.Data.Sql.Queries.EmployeeSalaries.Configs;

public class EmployeeSalaryConfig : IEntityTypeConfiguration<EmployeeSalary>
{
    public void Configure(EntityTypeBuilder<EmployeeSalary> builder)
    {
        builder.ToTable("EmployeeSalaries");
        builder.HasKey(x => x.Id);
    }
}
