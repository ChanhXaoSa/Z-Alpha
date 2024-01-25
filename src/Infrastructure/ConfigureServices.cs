using ZAlpha.Application.Common.Interfaces;
using ZAlpha.Domain.Identity;
using ZAlpha.Infrastructure.Identity;
using ZAlpha.Infrastructure.Persistence;
using ZAlpha.Infrastructure.Persistence.Interceptors;
using ZAlpha.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.OAuth;
using System.Transactions;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Authorization;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<AuditableEntitySaveChangesInterceptor>();

        if (configuration.GetValue<bool>("UseInMemoryDatabase"))
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("ZalphaDb"));
        }
        else
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        }

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<ApplicationDbContextInitialiser>();

        services.AddIdentity<UserAccount, IdentityRole>()
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();

        //services.AddScoped<IUserClaimsPrincipalFactory<UserAccount>, UserClaimsPrincipalFactory<UserAccount, IdentityRole>>();

        //services.AddIdentityServer()
        //    .AddApiAuthorization<UserAccount, ApplicationDbContext>();

        services.AddTransient<IDateTime, DateTimeService>();
        services.AddTransient<IIdentityService, IdentityService>();


        services.AddAuthentication(o =>
        {
            o.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            o.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            o.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        }).AddCookie(options =>
        {
            options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
            options.SlidingExpiration = true;
            options.AccessDeniedPath = "/Forbidden/";
            options.LoginPath = "/Login";
            options.LogoutPath = "/Logout";
            options.ReturnUrlParameter = "redirectUrl";
            options.Cookie.IsEssential = true;
            options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
            options.Cookie.SameSite = SameSiteMode.Lax;
        }).AddGoogle(GoogleDefaults.AuthenticationScheme , googleOptions =>
        {
            googleOptions.ClientId = "577296753487-9mrj2rur4m3glod7l5o1ljfvr9aj1bec.apps.googleusercontent.com";
            googleOptions.ClientSecret = "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";

            googleOptions.AccessDeniedPath = "/Forbidden/";
            googleOptions.ReturnUrlParameter = "redirectUrl";
            googleOptions.SaveTokens = true;

            googleOptions.SignInScheme = IdentityConstants.ExternalScheme;

            googleOptions.Events.OnCreatingTicket = OnCreatingTicket;
        }).AddFacebook(FacebookDefaults.AuthenticationScheme , option =>
        {
            option.AppId = "731092935665884";
            option.AppSecret = "a963603584803d49d9564adc914727aa";
            option.AccessDeniedPath = "/Forbidden/";
            option.ReturnUrlParameter = "redirectUrl";
            option.SaveTokens = true;

            option.SignInScheme = IdentityConstants.ExternalScheme;
            option.Events.OnCreatingTicket = OnCreatingTicket;
        });

        services.AddAuthorization(options =>
        {
            options.DefaultPolicy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();

            options.AddPolicy("admin", policy => policy
                .Combine(options.DefaultPolicy)
                .RequireRole("Administrator")
                .Build());
            options.AddPolicy("customer", policy => policy
                .Combine(options.DefaultPolicy)
                .RequireRole("Customer")
                .Build());
        });

        return services;
    }
    private static async Task OnCreatingTicket(OAuthCreatingTicketContext ctx)
    {
        using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        {
            try
            {
                var manager = ctx.HttpContext.RequestServices.GetRequiredService<UserManager<UserAccount>>();

                var email = ctx.Principal.Claims.First(x => x.Type == ClaimTypes.Email).Value;

                var isUserExisted = await manager.FindByNameAsync(email) != null;
                if (isUserExisted) return;

                var user = new UserAccount();
                user.FirstName = ctx.Principal.FindFirstValue(ClaimTypes.GivenName);
                user.LastName = ctx.Principal.FindFirstValue(ClaimTypes.Surname);
                user.Email = user.UserName = email;

                var result = await manager.CreateAsync(user);
                if (!result.Succeeded)
                    throw new Exception(string.Join("\n", result.Errors.Select(x => x.Description)));
                result = await manager.AddToRoleAsync(user, "Customer");
                if (!result.Succeeded)
                    throw new Exception(string.Join("\n", result.Errors.Select(x => x.Description)));
                result = await manager.AddClaimsAsync(user, ctx.Principal.Claims);
                if (!result.Succeeded)
                    throw new Exception(string.Join("\n", result.Errors.Select(x => x.Description)));

                scope.Complete();
            }
            finally { scope.Dispose(); }
        }
    }
}
