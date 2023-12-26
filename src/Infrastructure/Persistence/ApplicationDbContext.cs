using System.Reflection;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Identity;
using CleanArchitecture.Infrastructure.Identity;
using CleanArchitecture.Infrastructure.Persistence.Interceptors;
using Duende.IdentityServer.EntityFramework.Options;
using MediatR;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CleanArchitecture.Infrastructure.Persistence;

public class ApplicationDbContext : ApiAuthorizationDbContext<UserAccount>, IApplicationDbContext
{
    private readonly IMediator _mediator;
    private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;

    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options,
        IOptions<OperationalStoreOptions> operationalStoreOptions,
        IMediator mediator,
        AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor) 
        : base(options, operationalStoreOptions)
    {
        _mediator = mediator;
        _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
    }


    public DbSet<AnswersForEntranceTest> AnswersForEntranceTests => Set<AnswersForEntranceTest>();
    public DbSet<Comment>  Comments => Set<Comment>();
    public DbSet<EntranceTest> EntranceTests => Set<EntranceTest>();
    public DbSet<InteractWithPosts> InteractWithPosts => Set<InteractWithPosts>();
    public DbSet<ManagerAccount> ManagerAccounts => Set<ManagerAccount>();
    public DbSet<Pack> Packs => Set<Pack>();
    public DbSet<PackDetail> PackDetail => Set<PackDetail>();
    public DbSet<PaymentMethod> PaymentMethods => Set<PaymentMethod>(); 
    public DbSet<Post> Posts => Set<Post>();
    public DbSet<PostTag> PostTags => Set<PostTag>();
    public DbSet<UserInteractComment> UserInteractComments => Set<UserInteractComment>();
    public DbSet<Tag>  Tags => Set<Tag>();
    public DbSet<Transaction> Transactions => Set<Transaction>();
    public DbSet<WishListPost> WishListPosts => Set<WishListPost>();
    public DbSet<CustomerAccount> CustomerAccounts => Set<CustomerAccount>();




    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _mediator.DispatchDomainEvents(this);

        return await base.SaveChangesAsync(cancellationToken);
    }
}
