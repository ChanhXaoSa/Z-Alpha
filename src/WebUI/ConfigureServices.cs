using System.Text.Json.Serialization;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Identity;
using CleanArchitecture.Infrastructure.Persistence;
using CleanArchitecture.Infrastructure.Repositories;
using CleanArchitecture.WebUI.Filters;
using CleanArchitecture.WebUI.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
//using NSwag;
//using NSwag.Generation.Processors.Security;
//using ZymLabs.NSwag.FluentValidation;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddWebUIServices(this IServiceCollection services)
    {
        //services.AddIdentity<UserAccount, IdentityRole>()
        //    .AddEntityFrameworkStores<ApplicationDbContext>()
        //    .AddDefaultTokenProviders();

        //services.AddScoped<UserManager<UserAccount>>();


        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddScoped<ICurrentUserService, CurrentUserService>();

        services.AddHttpContextAccessor();

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        services.AddHealthChecks()
            .AddDbContextCheck<ApplicationDbContext>();

        services.AddDistributedMemoryCache();

        services.AddControllersWithViews(options =>
            options.Filters.Add<ApiExceptionFilterAttribute>())
                .AddFluentValidation(x => x.AutomaticValidationEnabled = false);

        services.AddControllers()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        });

        services.AddRazorPages();

        //DI
        //services.AddScoped<IAccountRepository, AccountRepository>();




        /*  services.AddScoped<FluentValidationSchemaProcessor>(provider =>
          {
              var validationRules = provider.GetService<IEnumerable<FluentValidationRule>>();
              var loggerFactory = provider.GetService<ILoggerFactory>();

              return new FluentValidationSchemaProcessor(provider, validationRules, loggerFactory);
          });*/

        //Customise default API behaviour
        services.Configure<ApiBehaviorOptions>(options =>
            options.SuppressModelStateInvalidFilter = true);


        services.AddSwaggerGen(option =>
        {
            option.SwaggerDoc("v1", new OpenApiInfo { Title = "Z-Alpha API", Version = "v1" });
            option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter a valid token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });
            option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
        });

        /*  services.AddOpenApiDocument((configure, serviceProvider) =>
          {
              var fluentValidationSchemaProcessor = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<FluentValidationSchemaProcessor>();

              // Add the fluent validations schema processor
              configure.SchemaProcessors.Add(fluentValidationSchemaProcessor);

              configure.Title = "CleanArchitecture API";
              configure.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
              {
                  Type = OpenApiSecuritySchemeType.ApiKey,
                  Name = "Authorization",
                  In = OpenApiSecurityApiKeyLocation.Header,
                  Description = "Type into the textbox: Bearer {your JWT token}."
              });

              configure.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
          });*/

        return services;
    }
}
