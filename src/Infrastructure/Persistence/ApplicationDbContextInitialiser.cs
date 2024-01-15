using ZAlpha.Domain.Entities;
using ZAlpha.Domain.Identity;
using ZAlpha.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ZAlpha.Infrastructure.Persistence;

public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<UserAccount> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context, UserManager<UserAccount> userManager, RoleManager<IdentityRole> roleManager)
    {
        _logger = logger;
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            if (_context.Database.IsSqlServer())
            {
                await _context.Database.MigrateAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {

        // Roles
        //var roles = new List<IdentityRole>
        //{
        //    new IdentityRole("Admin"),
        //    new IdentityRole("Manager"),
        //    new IdentityRole("Customer"),
        //    new IdentityRole("Expert")
        //};
        //foreach (var role in roles)
        //{
        //    if (_roleManager.Roles.All(r => r.Name != role.Name))
        //    {
        //        await _roleManager.CreateAsync(role);
        //        _logger.LogInformation($"Role '{role.Name}' seeded successfully.");
        //    }
        //}

        // Default roles
        var administratorRole = new IdentityRole("Administrator");

        if (_roleManager.Roles.All(r => r.Name != administratorRole.Name))
        {
            await _roleManager.CreateAsync(administratorRole);
        }

        // Default users
        var administrator = new UserAccount { UserName = "administrator@localhost", Email = "administrator@localhost" };

        if (_userManager.Users.All(u => u.UserName != administrator.UserName))
        {
            await _userManager.CreateAsync(administrator, "Administrator1!");
            if (!string.IsNullOrWhiteSpace(administratorRole.Name))
            {
                await _userManager.AddToRolesAsync(administrator, new [] { administratorRole.Name });
                _logger.LogInformation($"User '{administrator.UserName}' seeded successfully.");
            }
        }

        var managerRole = new IdentityRole("Manager");

        if (_roleManager.Roles.All(r => r.Name != managerRole.Name))
        {
            await _roleManager.CreateAsync(managerRole);
        }

        var manager = new UserAccount { UserName = "manager@localhost", Email = "manager@localhost" };

        if (_userManager.Users.All(u => u.UserName != manager.UserName))
        {
            await _userManager.CreateAsync(manager, "Manager1!");
            await _userManager.AddToRolesAsync(manager, new[] { managerRole.Name });
        }

        var customerRole = new IdentityRole("Customer");

        if (_roleManager.Roles.All(r => r.Name != customerRole.Name))
        {
            await _roleManager.CreateAsync(customerRole);
        }

        var customer = new UserAccount { UserName = "customer@localhost", Email = "customer@localhost" };

        if (_userManager.Users.All(u => u.UserName != customer.UserName))
        {
            await _userManager.CreateAsync(customer, "Customer1!");
            await _userManager.AddToRolesAsync(customer, new[] { customerRole.Name });
        }

        var expertRole = new IdentityRole("Expert");

        if (_roleManager.Roles.All(r => r.Name != expertRole.Name))
        {
            await _roleManager.CreateAsync(expertRole);
        }

        var expert = new UserAccount { UserName = "expert@localhost", Email = "expert@localhost" };

        if (_userManager.Users.All(u => u.UserName != expert.UserName))
        {
            await _userManager.CreateAsync(expert, "Expert1!");
            await _userManager.AddToRolesAsync(expert, new[] { expertRole.Name });
        }
        await _context.SaveChangesAsync();
        // Default data
        /*// Seed, if necessary
        if (!_context.TodoLists.Any())
        {
            _context.TodoLists.Add(new TodoList
            {
                Title = "Todo List",
                Items =
                {
                    new TodoItem { Title = "Make a todo list 📃" },
                    new TodoItem { Title = "Check off the first item ✅" },
                    new TodoItem { Title = "Realise you've already done two things on the list! 🤯"},
                    new TodoItem { Title = "Reward yourself with a nice, long nap 🏆" },
                }
            });

            await _context.SaveChangesAsync();
        }*/
    }
}
