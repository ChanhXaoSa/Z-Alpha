using System.Reflection;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Enums;
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
    //public DbSet<UserInteractComment> UserInteractComments => Set<UserInteractComment>();
    public DbSet<Tag>  Tags => Set<Tag>();
    public DbSet<Transaction> Transactions => Set<Transaction>();
    public DbSet<WishListPost> WishListPosts => Set<WishListPost>();
    public DbSet<CustomerAccount> CustomerAccounts => Set<CustomerAccount>();




    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        builder.Entity<Post>()
       .HasData(
           new Post
           {
               PostTitle = "Nội dung bài đăng test 1",
               PostBody = "Nội dung bài đăng test thử ",
               PostImagesUrl = "https://scontent.fsgn5-10.fna.fbcdn.net/v/t39.30808-6/387798154_632107352457871_5690110333313757656_n.jpg?_nc_cat=101&ccb=1-7&_nc_sid=3635dc&_nc_ohc=OpZIs7vdMK8AX9Hgjkq&_nc_ht=scontent.fsgn5-10.fna&oh=00_AfAvpIg3y_s3UEGS0ilM8J6x6spEamFSC3sjhVn3V7G5-A&oe=65A6DF8C",
               NumberOfLikes = 100,
               NumberOfDisLikes = 10,
               AnonymousStatus = AnonymousStatus.Active,
           },
           new Post
           {
               PostTitle = "Nội dung bài đăng test 1",
               PostBody = "Nội dung bài đăng test thử ",
               PostImagesUrl = "https://scontent.fsgn5-10.fna.fbcdn.net/v/t39.30808-6/387798154_632107352457871_5690110333313757656_n.jpg?_nc_cat=101&ccb=1-7&_nc_sid=3635dc&_nc_ohc=OpZIs7vdMK8AX9Hgjkq&_nc_ht=scontent.fsgn5-10.fna&oh=00_AfAvpIg3y_s3UEGS0ilM8J6x6spEamFSC3sjhVn3V7G5-A&oe=65A6DF8C",
               NumberOfLikes = 100,
               NumberOfDisLikes = 10,
               AnonymousStatus = AnonymousStatus.Active,
           }

       );
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

    public DbSet<T> Get<T>() where T : BaseAuditableEntity => Set<T>();
}
