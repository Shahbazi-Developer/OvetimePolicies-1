using Microsoft.EntityFrameworkCore;
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
}