using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace OvetimePolicies1.Infra.Data.Sql.Commands.Common;

public class OvetimePolicies1CommandDbContextFactory : IDesignTimeDbContextFactory<OvetimePolicies1CommandDbContext>
{
    public OvetimePolicies1CommandDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<OvetimePolicies1CommandDbContext>();

        builder.UseSqlServer("Server =.; Database=OvetimePolicies1Db;User Id = ;Password = ; MultipleActiveResultSets = true; Encrypt = false");

        return new OvetimePolicies1CommandDbContext(builder.Options);
    }
}