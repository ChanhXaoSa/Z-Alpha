using System.Reflection;
using ZAlpha.Application.Common.Interfaces;
using ZAlpha.Domain.Common;
using ZAlpha.Domain.Entities;
using ZAlpha.Domain.Identity;
using ZAlpha.Infrastructure.Identity;
using ZAlpha.Infrastructure.Persistence.Interceptors;
using Duende.IdentityServer.EntityFramework.Options;
using MediatR;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ZAlpha.Domain.Enums;

namespace ZAlpha.Infrastructure.Persistence;

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
    public DbSet<InteractWithComments> InteractWithComments => Set<InteractWithComments>();
    public DbSet<Tag>  Tags => Set<Tag>();
    public DbSet<Transaction> Transactions => Set<Transaction>();
    public DbSet<WishListPost> WishListPosts => Set<WishListPost>();
    public DbSet<CustomerAccount> CustomerAccounts => Set<CustomerAccount>();
    public DbSet<PsychologistAccount> PsychologistAccounts => Set<PsychologistAccount>();
    



    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
       
     

        builder.Entity<Tag>()
          .HasData(
              new Tag
              {
                  Id = new Guid("150b7aba-a76f-40b2-b7e5-19961bda108f"),
                  TagName = "Học đường"             
              },
              new Tag
              {
                  Id = new Guid("2b3a61bf-1543-4e9f-900b-d4901be7e78c"),
                  TagName = "Công việc"
              },
              new Tag
              {
                  Id = new Guid("6598d9c2-ef4d-4295-a06a-e45a3cfc7b9d"),
                  TagName = "Gia đình"
              },
              new Tag
              {
                  Id = new Guid("79a50b87-3bb3-4acc-b164-ef5795db17e3"),
                  TagName = "Xã hội"
              }
          );

      
     

       
        builder.Entity<Pack>()
      .HasData(
           new Pack
           {
               Id = new Guid("8e5b48df-713e-4fe3-844b-8258c785ff7e"),
               PackName = "Dùng thử",
               PackInfomation = "Giới hạn lượt đăng bài và tương tác",
               PackPrice = 0
           },
           new Pack
           {
               Id = new Guid("e609e43f-b6ad-468e-91d1-785b282d345b"),
               PackName = "Tháng",
               PackInfomation = "30 ngày",
               PackPrice = 49000
           },
           new Pack
           {
               Id = new Guid("92b2fb8c-866c-445b-87b4-dc7bb3c828ac"),
               PackName = "Quý",
               PackInfomation = "3 tháng, tương đương 90 ngày",
               PackPrice = 129000
           },
           new Pack
           {
               Id = new Guid("8853faf2-87f1-4c17-8e20-7253720265be"),
               PackName = "Năm",
               PackInfomation = "tương đương 365 ngày",
               PackPrice = 499000
           }
      );
       
        builder.Entity<PaymentMethod>()
            .HasData(
            new PaymentMethod
            {
                Id= new Guid("94422c85-1d58-4f47-b5cb-a2794e757268"),
                PaymentMethodName = "VNPay",
                PaymentMethodStatus = PaymentMethodStatus.Available,
            },
            new PaymentMethod
            {
                Id = new Guid("d49773a8-6f63-4803-8c46-69f1349a5c20"),
                PaymentMethodName = "MoMo",
                PaymentMethodStatus = PaymentMethodStatus.Unavailable,
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
