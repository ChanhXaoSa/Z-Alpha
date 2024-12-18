﻿using System.Security.Cryptography;
using System.Text;
using ZAlpha.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using WebUI.Hubs;
using Microsoft.AspNetCore.Identity.UI.Services;
using WebUI;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddWebUIServices();

//builder.Services.AddSwaggerGen();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.Configure<DataProtectionTokenProviderOptions>(opt =>
   opt.TokenLifespan = TimeSpan.FromMinutes(30));

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("*"
                                              )
                                                .AllowAnyHeader()
                                                .AllowAnyMethod();
                      });
});

//JWT
//builder.Services.AddAuthentication(option =>
//{
//    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//    option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
//}).AddJwtBearer(option =>
//{
//    option.SaveToken = true;
//    option.RequireHttpsMetadata = true;
//    option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
//    {
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ValidAudience = builder.Configuration["JWT:ValidAudience"],
//        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
//        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWT:SecrectKey"]))
//    };
//});
builder.Services.AddControllersWithViews().AddNToastNotifyNoty(new NToastNotify.NotyOptions(){
    ProgressBar = true,
    Timeout = 2000
});
builder.Services.AddSignalR();

var app = builder.Build();

app.UseNToastNotify();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseDeveloperExceptionPage();
    //app.UseMigrationsEndPoint();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
        c.RoutePrefix = "swagger";
    });
    // Initialise and seed database
    using (var scope = app.Services.CreateScope())
    {
        var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();
        await initialiser.InitialiseAsync();
        await initialiser.SeedAsync();
    }
}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseMigrationsEndPoint();

app.UseHealthChecks("/health");
app.UseHttpsRedirection();
app.UseStaticFiles();



//app.UseSwaggerUi3(settings =>
//{
//    settings.Path = "/api";
//    settings.DocumentPath = "/api/specification.json";
//});

app.UseRouting();

app.UseAuthentication();
//app.UseIdentityServer();
app.UseAuthorization();
app.UseSession();
/*app.UseCookiePolicy(new CookiePolicyOptions
{
    HttpOnly = HttpOnlyPolicy.Always,
    Secure = CookieSecurePolicy.Always,
});*/
app.UseCors(MyAllowSpecificOrigins);
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute(
//    name: "default",
//    pattern: "{controller}/{action=Index}/{id?}");
//});
/*app.UseCookiePolicy(new CookiePolicyOptions
{
    HttpOnly = HttpOnlyPolicy.Always,
    Secure = CookieSecurePolicy.Always,
});*/
app.MapDefaultControllerRoute();
app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<ChatHub>("/chat");
});
app.MapControllerRoute(
    name: "default",
    pattern: "{area:exists}/{controller=Login}/{action=Index}/{id?}");

app.MapRazorPages();

//app.MapFallbackToFile("index.html");

app.Run();