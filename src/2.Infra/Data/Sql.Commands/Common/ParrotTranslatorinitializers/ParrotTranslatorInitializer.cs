using System.Text;
using Dapper;
using Microsoft.Data.SqlClient;
using OvetimePolicies1.SharedKernel.Translators;

namespace OvetimePolicies1.Infra.Data.Sql.Commands.Common.ParrotTranslatorinitializers;

public static class ParrotTranslatorInitializer
{
    public static void Initialize(string connectionString, string schemaName, string tableName)
    {
        var translatorKeyFieldInfo = typeof(TranslatorKeys).GetFields();
        var translatorValueFieldInfo = typeof(TranslatorValues).GetFields();

        if (!translatorKeyFieldInfo.Any())
            throw new ArgumentNullException(nameof(TranslatorKeys), "TranslatorKeys is empty.");

        if (!translatorValueFieldInfo.Any())
            throw new ArgumentNullException(nameof(TranslatorValues), "TranslatorValues is empty.");

        var notExistsValueFieldInfo = translatorKeyFieldInfo
            .Where(k => !translatorValueFieldInfo.Any(v => v.Name == k.Name))
            .Select(q => q.Name)
            .ToList();

        if (notExistsValueFieldInfo.Any())
        {
            throw new ArgumentException(
                $"Not found value for below keys:\n{string.Join("\n", notExistsValueFieldInfo)}");
        }

        var queryBuilder = new StringBuilder();

        queryBuilder.AppendLine("IF (EXISTS (SELECT * FROM sys.tables AS T WHERE SCHEMA_NAME(T.schema_id) = @SchemaName AND T.name = @TableName))");
        queryBuilder.AppendLine("BEGIN");
        queryBuilder.AppendLine("SET XACT_ABORT ON");
        queryBuilder.AppendLine("SET NOCOUNT ON");
        queryBuilder.AppendLine("BEGIN TRANSACTION");

        foreach (var keyFieldInfo in translatorKeyFieldInfo)
        {
            var valueFieldInfo = translatorValueFieldInfo.First(q => q.Name == keyFieldInfo.Name);
            var key = keyFieldInfo.GetValue(null)?.ToString() ?? string.Empty;
            var value = valueFieldInfo.GetValue(null)?.ToString()?.Replace("'", "''") ?? string.Empty;

            foreach (var culture in new[] { "fa-IR", "en-US" })
            {
                queryBuilder.AppendLine($"IF NOT EXISTS (SELECT 1 FROM [{schemaName}].[{tableName}] WHERE [Key] COLLATE Latin1_General_CS_AS = N'{key}' AND [Culture] = N'{culture}')");
                queryBuilder.AppendLine($"INSERT INTO [{schemaName}].[{tableName}]([BusinessId], [Key], [Value], [Culture])");
                queryBuilder.AppendLine($"VALUES (NEWID(), N'{key}', N'{value}', N'{culture}');");
            }
        }

        queryBuilder.AppendLine("COMMIT TRANSACTION");
        queryBuilder.AppendLine("END");

        using var connection = new SqlConnection(connectionString);
        connection.Execute(queryBuilder.ToString(), new { schemaName, tableName });
    }
}
