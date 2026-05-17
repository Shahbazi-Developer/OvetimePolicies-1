using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OvetimePolicies1.Core.Contracts.Authentication.Users;
using OvetimePolicies1.Endpoints.API.Authentication;
using OvetimePolicies1.Endpoints.API.Extentions;
using OvetimePolicies1.Infra.Data.Sql.Commands.Authentication.Users;
using System.Text;
using Zamin.Extensions.DependencyInjection;
using Zamin.Utilities.SerilogRegistration.Extensions;

SerilogExtensions.RunWithSerilogExceptionHandling(() =>
{
    var builder = WebApplication.CreateBuilder(args);

    // =====================================================
    // 1) JWT CONFIGURATION
    // =====================================================
    builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("Jwt"));
    builder.Services.AddScoped<JwtTokenGenerator>();

    var jwtSection = builder.Configuration.GetSection("Jwt");
    var key = Encoding.UTF8.GetBytes(jwtSection["Key"]!);

    builder.Services
        .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSection["Issuer"],
                ValidAudience = jwtSection["Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(key)
            };

            // بدون / نامعتبر بودن JWT → 403 (به‌جای 401 پیش‌فرض)
            options.Events = new JwtBearerEvents
            {
                OnChallenge = context =>
                {
                    context.HandleResponse();
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                    return Task.CompletedTask;
                },
                OnAuthenticationFailed = context =>
                {
                    context.NoResult();
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                    return Task.CompletedTask;
                }
            };
        });

    builder.Services.AddAuthorization();

    // =====================================================
    // 2) USER REPOSITORY
    // =====================================================
    builder.Services.AddScoped<IUserRepository, UserRepository>();

    // =====================================================
    // 3) SWAGGER WITH JWT AUTH
    // =====================================================
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "OvetimePolicies1 API (Zamin + JWT)",
            Version = "v1"
        });

        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "توکن را به این شکل وارد کنید: Bearer {token}",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT"
        });

        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                Array.Empty<string>()
            }
        });
    });

    // =====================================================
    // 4) ZAMIN + SERILOG + PIPELINE
    // =====================================================
    var app = builder
        .AddZaminSerilog(o =>
        {
            o.ApplicationName = builder.Configuration.GetValue<string>("ApplicationName");
            o.ServiceId = builder.Configuration.GetValue<string>("ServiceId");
            o.ServiceName = builder.Configuration.GetValue<string>("ServiceName");
            o.ServiceVersion = builder.Configuration.GetValue<string>("ServiceVersion");
        })
        .ConfigureServices()
        .ConfigurePipeline();

    // =====================================================
    // 5) SWAGGER UI
    // =====================================================
    app.UseSwagger();
    app.UseSwaggerUI();

    app.Run();
});
