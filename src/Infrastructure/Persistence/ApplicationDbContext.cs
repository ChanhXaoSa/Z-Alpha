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
    //public DbSet<UserInteractComment> UserInteractComments => Set<UserInteractComment>();
    public DbSet<Tag>  Tags => Set<Tag>();
    public DbSet<Transaction> Transactions => Set<Transaction>();
    public DbSet<WishListPost> WishListPosts => Set<WishListPost>();
    public DbSet<CustomerAccount> CustomerAccounts => Set<CustomerAccount>();




    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        builder.Entity<UserAccount>()
        .HasData(
            new UserAccount
            {
                Id = "871a809a-b3fa-495b-9cc2-c5d738a866cf",
                Email = "vinhtc191@gmail.com",
                FirstName = "Tran",
                LastName = "Vinh",
                Status = UserStatus.Active,
                Wallet = 10000000
            },
             new UserAccount
             {
                 Id = "424ab531-d60a-487e-9625-a74a7f5747be",
                 Email = "test@gmail.com",
                 FirstName = "Chan",
                 LastName = "Dinh",
                 Status = UserStatus.Active,
                 Wallet = 1000
             }
        );
        builder.Entity<Post>()
           .HasData(
               new Post
               {
                   Id = new Guid("14b76851-0f86-4dd2-a59c-ae45893c9578"),
                   PostTitle = "Nội dung bài đăng test 1",
                   PostBody = "Nhà em cũng không phải khá giả nên em bỏ học đi làm từ sớm, muốn chạy đi kiếm tiền luôn. Hiện tại là một shipper ngày nào cũng ráng giao cả ngàn đơn, dãi nắng cả buổi, ráng cày thêm đơn để được thưởng KPI. Vậy nên mỗi khi về nhà, ngoài kiệt sức ra em thường xuyên cảm thấy căng thẳng, mệt mỏi và có những suy nghĩ tiêu cực về bản thân, mình cải cha cãi má bỏ học đi làm mà. Em chỉ muốn được nghỉ ngơi nhưng mẹ bảo em xuống làm cơm cho ba má ăn với lo dọn dẹp nhà. Điều này khiến em cảm thấy mệt mỏi và khó chịu.",
                   PostImagesUrl = "https://scontent.fsgn5-10.fna.fbcdn.net/v/t39.30808-6/387798154_632107352457871_5690110333313757656_n.jpg?_nc_cat=101&ccb=1-7&_nc_sid=3635dc&_nc_ohc=OpZIs7vdMK8AX9Hgjkq&_nc_ht=scontent.fsgn5-10.fna&oh=00_AfAvpIg3y_s3UEGS0ilM8J6x6spEamFSC3sjhVn3V7G5-A&oe=65A6DF8C",
                   NumberOfLikes = 100,
                   NumberOfDisLikes = 10,
                   AnonymousStatus = AnonymousStatus.Active,
               },
               new Post
               {
                   Id = new Guid("f2c5a3b4-8885-4673-8bcc-3702dbbae15d"),
                   PostTitle = "Nội dung bài đăng test 2",
                   PostBody = "Nội dung bài đăng test thử ",
                   PostImagesUrl = "https://scontent.fsgn5-10.fna.fbcdn.net/v/t39.30808-6/387798154_632107352457871_5690110333313757656_n.jpg?_nc_cat=101&ccb=1-7&_nc_sid=3635dc&_nc_ohc=OpZIs7vdMK8AX9Hgjkq&_nc_ht=scontent.fsgn5-10.fna&oh=00_AfAvpIg3y_s3UEGS0ilM8J6x6spEamFSC3sjhVn3V7G5-A&oe=65A6DF8C",
                   NumberOfLikes = 100,
                   NumberOfDisLikes = 10,
                   AnonymousStatus = AnonymousStatus.Active,
               }

           );

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

        builder.Entity<PostTag>()
         .HasData(
             new PostTag
             {
                 Id = new Guid("647b2bd5-ea1b-42a6-a92e-8263fb160754"),
                 PostId = new Guid("14b76851-0f86-4dd2-a59c-ae45893c9578"),
                 TagId = new Guid("150b7aba-a76f-40b2-b7e5-19961bda108f")
             },
             new PostTag
             {
                 Id = new Guid("5d7deaf1-d72b-457e-bf56-877a89d37fac"),
                 PostId = new Guid("14b76851-0f86-4dd2-a59c-ae45893c9578"),
                 TagId = new Guid("6598d9c2-ef4d-4295-a06a-e45a3cfc7b9d")
             },
             new PostTag
             {
                 Id = new Guid("bcc26154-4ca0-4b51-808a-911bb4e09447"),
                 PostId = new Guid("f2c5a3b4-8885-4673-8bcc-3702dbbae15d"),
                 TagId = new Guid("79a50b87-3bb3-4acc-b164-ef5795db17e3")
             }
         );
        builder.Entity<Comment>()
        .HasData(
            new Comment
            {
                Id = new Guid("65191898-080f-4c24-b39a-653e57323400"),
                UserAccountId = "871a809a-b3fa-495b-9cc2-c5d738a866cf",
                PostId = new Guid("14b76851-0f86-4dd2-a59c-ae45893c9578"),
                Description = "Nội dung comment"
            },
            new Comment
            {
                Id = new Guid("cca90e51-b859-4830-8fcf-989163aaa4d9"),
                UserAccountId = "424ab531-d60a-487e-9625-a74a7f5747be",
                PostId = new Guid("14b76851-0f86-4dd2-a59c-ae45893c9578"),
                Description = "Em chỉ đang cảm thấy mệt mỏi, quá tải và cần sẻ chia thôi. Anh luôn ở đây hỗ trợ em, bản chất em có những suy nghĩ trên đã là một điểm tích cực, là điều đáng quý. Hãy bắt đầu từ việc viết lại mục đích, lý do chọn lựa con đường của em, để lấy nó làm điểm tựa mỗi khi đối diện với cảm xúc khó chịu mà em đề cập. Còn nếu được hãy tham gia một buổi hẹn ngắn với anh nếu em vẫn cảm thấy struggle"
            },
            new Comment
            {
                Id = new Guid("981c2b78-2662-4929-ab07-75e36d58e9bb"),
                UserAccountId = "871a809a-b3fa-495b-9cc2-c5d738a866cf",
                PostId = new Guid("f2c5a3b4-8885-4673-8bcc-3702dbbae15d"),
                Description = "Nội dung comment test"
            }


        );
        builder.Entity<InteractWithPosts>()
       .HasData(
           new InteractWithPosts
           {
               Id = new Guid("61291732-1599-46e4-93e2-01aa8fca3801"),
               UserAccountId = "871a809a-b3fa-495b-9cc2-c5d738a866cf",
               PostId = new Guid("14b76851-0f86-4dd2-a59c-ae45893c9578"),
               InteractPostStatus = InteractPostStatus.Create
           },
            new InteractWithPosts
            {
                Id = new Guid("795154a3-aa8a-4337-8f45-35529a400fd3"),
                UserAccountId = "424ab531-d60a-487e-9625-a74a7f5747be",
                PostId = new Guid("f2c5a3b4-8885-4673-8bcc-3702dbbae15d"),
                InteractPostStatus = InteractPostStatus.Create
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
