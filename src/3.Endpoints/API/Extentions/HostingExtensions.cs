using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using OvetimePolicies1.Infra.Data.Sql.Commands.Common;
using OvetimePolicies1.Infra.Data.Sql.Commands.Common.ParrotTranslatorinitializers;
using Serilog;
using Zamin.EndPoints.Web.Extensions.ModelBinding;
using Zamin.Extensions.DependencyInjection;
using Zamin.Infra.Data.Sql.Commands.Interceptors;

namespace OvetimePolicies1.Endpoints.API.Extentions;

public static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        IConfiguration configuration = builder.Configuration;

        //zamin
        builder.Services.AddZaminApiCore("Zamin", "OvetimePolicies1");

        //microsoft
        builder.Services.AddEndpointsApiExplorer();

        //zamin
        builder.Services.AddZaminWebUserInfoService(configuration, "WebUserInfo", true);

        var parrotTranslatorSection = configuration.GetSection("ParrotTranslator");

        //zamin
        builder.Services.AddZaminParrotTranslator(option =>
        {
            option.ConnectionString = parrotTranslatorSection.GetValue<string>("ConnectionString")!;
            option.SchemaName = parrotTranslatorSection.GetValue<string>("SchemaName")!;
            option.TableName = parrotTranslatorSection.GetValue<string>("TableName")!;
        });

        // ParrotTranslatorInitializer runs after EF migrations (ConfigurePipeline); DB must exist first for Docker/SQL.

        //zamin
        //builder.Services.AddSoftwarePartDetector(configuration, "SoftwarePart");

        //zamin
        builder.Services.AddNonValidatingValidator();

        //zamin
        builder.Services.AddZaminMicrosoftSerializer();

        builder.Services.Configure<Microsoft.AspNetCore.Mvc.JsonOptions>(options =>
        {
            options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
        });

        //zamin
        builder.Services.AddZaminAutoMapperProfiles(configuration, "AutoMapper");

        //zamin
        builder.Services.AddZaminInMemoryCaching();
        //builder.Services.AddZaminSqlDistributedCache(configuration, "SqlDistributedCache");

        //CommandDbContext
        builder.Services.AddDbContext<OvetimePolicies1CommandDbContext>(c => c.UseSqlServer(configuration.GetConnectionString("CommandDb_ConnectionString"))
            .AddInterceptors(new SetPersianYeKeInterceptor(), new AddAuditDataInterceptor()));

        //PollingPublisher
        builder.Services.AddZaminPollingPublisherDalSql(configuration, "PollingPublisherSqlStore");
        //builder.Services.AddZaminPollingPublisher(configuration, "PollingPublisher");

        //MessageInbox
        builder.Services.AddZaminMessageInboxDalSql(configuration, "MessageInboxSqlStore");
        //builder.Services.AddZaminMessageInbox(configuration, "MessageInbox");

        //builder.Services.AddZaminRabbitMqMessageBus(configuration, "RabbitMq");

        //builder.Services.AddZaminTraceJeager(configuration, "OpenTeletmetry");

        builder.Services.AddSwaggerGen();

        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        ApplyCommandDbMigrationsIfRequested(app);
        InitializeParrotTranslatorWithRetry(app.Configuration);

        //zamin
        app.UseZaminApiExceptionHandler();

        //Serilog
        app.UseSerilogRequestLogging();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseStatusCodePages();

        app.UseCors(delegate (CorsPolicyBuilder builder)
        {
            builder.AllowAnyOrigin();
            builder.AllowAnyHeader();
            builder.AllowAnyMethod();
        });

        if (!app.Environment.IsEnvironment("Docker"))
        {
            app.UseHttpsRedirection();
        }

        //app.Services.ReceiveEventFromRabbitMqMessageBus(new KeyValuePair<string, string>("MiniAggregateName", "AggregateNameCreated"));

        //var useIdentityServer = app.UseIdentityServer("OAuth");

        var controllerBuilder = app.MapControllers();

        //if (useIdentityServer)
        //    controllerBuilder.RequireAuthorization();

        //app.Services.GetService<SoftwarePartDetectorService>()?.Run();

        return app;
    }

    private static void ApplyCommandDbMigrationsIfRequested(WebApplication app)
    {
        if (!app.Configuration.GetValue<bool>("ApplyDatabaseMigrationsOnStartup"))
            return;

        using var scope = app.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<OvetimePolicies1CommandDbContext>();

        const int maxAttempts = 30;
        for (var attempt = 1; attempt <= maxAttempts; attempt++)
        {
            try
            {
                db.Database.Migrate();
                return;
            }
            catch (Exception ex) when (attempt < maxAttempts)
            {
                Log.Warning(ex, "Command DB migrate attempt {Attempt}/{Max} failed; retrying.", attempt, maxAttempts);
                Thread.Sleep(TimeSpan.FromSeconds(3));
            }
        }

        db.Database.Migrate();
    }

    private static void InitializeParrotTranslatorWithRetry(IConfiguration configuration)
    {
        var section = configuration.GetSection("ParrotTranslator");
        var cs = section.GetValue<string>("ConnectionString")!;
        var schemaName = section.GetValue<string>("SchemaName")!;
        var tableName = section.GetValue<string>("TableName")!;

        const int maxAttempts = 30;
        for (var attempt = 1; attempt <= maxAttempts; attempt++)
        {
            try
            {
                ParrotTranslatorInitializer.Initialize(cs, schemaName, tableName);
                return;
            }
            catch (Exception ex) when (attempt < maxAttempts)
            {
                Log.Warning(ex, "Parrot translator init attempt {Attempt}/{Max} failed; retrying.", attempt, maxAttempts);
                Thread.Sleep(TimeSpan.FromSeconds(3));
            }
        }

        ParrotTranslatorInitializer.Initialize(cs, schemaName, tableName);
    }
}