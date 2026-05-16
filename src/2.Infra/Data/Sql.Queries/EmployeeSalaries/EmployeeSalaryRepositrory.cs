using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using OvetimePolicies1.Core.Contracts.EmployeeSalaries.Queries;
using OvetimePolicies1.Core.RequestResponse.EmployeeSalaries.Queries.Get;
using OvetimePolicies1.Core.RequestResponse.EmployeeSalaries.Queries.GetRange;

namespace OvetimePolicies1.Infra.Data.Sql.Queries.EmployeeSalaries;

public sealed class EmployeeSalaryRepositrory : IEmployeeSalaryQueryRepasitory
{
    private readonly string _connectionString;

    public EmployeeSalaryRepositrory(IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(configuration);
        _connectionString = configuration.GetConnectionString("QueryDb_ConnectionString")
                            ?? throw new InvalidOperationException(
                                "Connection string 'QueryDb_ConnectionString' is not configured.");
    }

    public async Task<EmployeeSalaryGetQr?> ExecuteAsync(EmployeeSalaryGetQuery query)
    {
        await using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync().ConfigureAwait(false);
        return await EmployeeSalaryDapperRead.GetAsync(connection, query).ConfigureAwait(false);
    }

    public async Task<List<EmployeeSalaryGetRangeQr>> ExecuteAsync(EmployeeSalaryGetRangeQuery query)
    {
        await using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync().ConfigureAwait(false);
        return await EmployeeSalaryDapperRead.GetRangeAsync(connection, query).ConfigureAwait(false);
    }
}
