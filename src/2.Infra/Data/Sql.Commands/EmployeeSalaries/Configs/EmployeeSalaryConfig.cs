using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OvetimePolicies1.Core.Domain.EmployeeSalaries.Entities;
using OvetimePolicies1.SharedKernel.Translators;

namespace OvetimePolicies1.Infra.Data.Sql.Commands.EmployeeSalaries.Configs;

public class EmployeeSalaryConfig : IEntityTypeConfiguration<EmployeeSalary>
{
    public void Configure(EntityTypeBuilder<EmployeeSalary> builder)
    {
        builder.ToTable("EmployeeSalaries");
        builder.HasKey(x => x.Id);

        builder.OwnsOne(p => p.Deleted, builderAction =>
        {
            builderAction.Property(p1 => p1.Value).HasColumnName(nameof(EmployeeSalary.Deleted));
        });

        builder.OwnsOne(p => p.OvertimeCalculatorName, builderAction =>
        {
            builderAction.Property(p1 => p1.Value).HasColumnName(nameof(EmployeeSalary.OvertimeCalculatorName));
        });

        builder.Property(c => c.LastName)
            .IsRequired(false)
            .HasMaxLength(MaxLengthConfiguration.NAME_MAX_LENGTH)
            .HasColumnName(nameof(EmployeeSalary.LastName));

        builder.Property(c => c.FirstName)
            .IsRequired(false)
            .HasMaxLength(MaxLengthConfiguration.NAME_MAX_LENGTH)
            .HasColumnName(nameof(EmployeeSalary.FirstName));

        builder.Property(c => c.BasicSalary).HasColumnName(nameof(EmployeeSalary.BasicSalary));
        builder.Property(c => c.Date).HasColumnName(nameof(EmployeeSalary.Date));
        builder.Property(c => c.Allowance).HasColumnName(nameof(EmployeeSalary.Allowance));
        builder.Property(c => c.Transportation).HasColumnName(nameof(EmployeeSalary.Transportation));
        builder.Property(c => c.Tax).HasColumnName(nameof(EmployeeSalary.Tax));
        builder.Property(c => c.OvertimeAmount).HasColumnName(nameof(EmployeeSalary.OvertimeAmount));
        builder.Property(c => c.ReceivedSalary).HasColumnName(nameof(EmployeeSalary.ReceivedSalary));
    }
}
