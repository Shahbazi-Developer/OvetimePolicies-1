using System.Data;
using Dapper;
using OvetimePolicies1.Core.RequestResponse.EmployeeSalaries.Queries.Get;
using OvetimePolicies1.Core.RequestResponse.EmployeeSalaries.Queries.GetRange;

namespace OvetimePolicies1.Infra.Data.Sql.Queries.EmployeeSalaries;

internal static class EmployeeSalaryDapperRead
{
    private const string GetSql =
        """
        SELECT TOP (1)
            [Id],
            [LastName],
            [FirstName],
            [BasicSalary],
            [Date],
            [Allowance],
            [Transportation],
            [Tax],
            [OvertimeCalculatorName],
            [OvertimeAmount],
            [ReceivedSalary]
        FROM [EmployeeSalaries]
        WHERE [Deleted] = @Deleted
          AND [FirstName] = @FirstName
          AND [LastName] = @LastName
          AND [Date] >= @MonthStartInclusive
          AND [Date] < @MonthEndExclusive;
        """;

    private const string GetRangeSql =
        """
        SELECT
            [Id],
            [LastName],
            [FirstName],
            [BasicSalary],
            [Date],
            [Allowance],
            [Transportation],
            [Tax],
            [OvertimeCalculatorName],
            [OvertimeAmount],
            [ReceivedSalary]
        FROM [EmployeeSalaries]
        WHERE [Deleted] = @Deleted
          AND [FirstName] = @FirstName
          AND [LastName] = @LastName
          AND [Date] >= @FromDate
          AND [Date] <= @ToDate
        ORDER BY [Date];
        """;

    internal static Task<EmployeeSalaryGetQr?> GetAsync(
        IDbConnection connection,
        EmployeeSalaryGetQuery query,
        CancellationToken cancellationToken = default)
    {
        var monthStartInclusive = new DateTime(query.Date.Year, query.Date.Month, 1);
        var monthEndExclusive = monthStartInclusive.AddMonths(1);

        var command = new CommandDefinition(
            GetSql,
            new
            {
                Deleted = false,
                FirstName = query.FirstName,
                LastName = query.LastName,
                MonthStartInclusive = monthStartInclusive,
                MonthEndExclusive = monthEndExclusive,
            },
            cancellationToken: cancellationToken);

        return connection.QuerySingleOrDefaultAsync<EmployeeSalaryGetQr>(command);
    }

    internal static async Task<List<EmployeeSalaryGetRangeQr>> GetRangeAsync(
        IDbConnection connection,
        EmployeeSalaryGetRangeQuery query,
        CancellationToken cancellationToken = default)
    {
        var command = new CommandDefinition(
            GetRangeSql,
            new
            {
                Deleted = false,
                FirstName = query.FirstName,
                LastName = query.LastName,
                FromDate = query.FromDate,
                ToDate = query.ToDate,
            },
            cancellationToken: cancellationToken);

        var rows = await connection.QueryAsync<EmployeeSalaryGetRangeQr>(command).ConfigureAwait(false);
        return rows.ToList();
    }
}
