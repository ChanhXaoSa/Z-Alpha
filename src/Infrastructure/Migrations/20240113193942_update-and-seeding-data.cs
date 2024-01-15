using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ZAlpha.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateandseedingdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("55b7d164-ebb7-466e-a7d8-d2c1cbed3d30"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("75da058c-13cf-4027-9962-8e4c00ec297c"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Avatar", "AvatarUrl", "BirthDay", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsPremium", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName", "Wallet" },
                values: new object[,]
                {
                    { "424ab531-d60a-487e-9625-a74a7f5747be", 0, null, null, null, null, "84e3d970-3a85-4bf6-bcbb-f2289a68805f", "test@gmail.com", false, "Chan", null, "Dinh", false, null, null, null, null, null, null, false, "8f09b226-7a29-4fdf-853c-4a50a0864b48", 1, false, null, 1000.0 },
                    { "871a809a-b3fa-495b-9cc2-c5d738a866cf", 0, null, null, null, null, "8a06d124-67a2-4734-a0b5-c71027fa0093", "vinhtc191@gmail.com", false, "Tran", null, "Vinh", false, null, null, null, null, null, null, false, "15ed186a-18ee-4aa1-9624-f0414d158d2a", 1, false, null, 10000000.0 }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AnonymousStatus", "Created", "CreatedBy", "IsDeleted", "LastModified", "LastModifiedBy", "NumberOfDisLikes", "NumberOfLikes", "PostBody", "PostImagesUrl", "PostTitle" },
                values: new object[,]
                {
                    { new Guid("14b76851-0f86-4dd2-a59c-ae45893c9578"), 1, new DateTime(2024, 1, 14, 2, 39, 42, 428, DateTimeKind.Local).AddTicks(2870), null, false, null, null, 10, 100, "Nhà em cũng không phải khá giả nên em bỏ học đi làm từ sớm, muốn chạy đi kiếm tiền luôn. Hiện tại là một shipper ngày nào cũng ráng giao cả ngàn đơn, dãi nắng cả buổi, ráng cày thêm đơn để được thưởng KPI. Vậy nên mỗi khi về nhà, ngoài kiệt sức ra em thường xuyên cảm thấy căng thẳng, mệt mỏi và có những suy nghĩ tiêu cực về bản thân, mình cải cha cãi má bỏ học đi làm mà. Em chỉ muốn được nghỉ ngơi nhưng mẹ bảo em xuống làm cơm cho ba má ăn với lo dọn dẹp nhà. Điều này khiến em cảm thấy mệt mỏi và khó chịu.", "https://scontent.fsgn5-10.fna.fbcdn.net/v/t39.30808-6/387798154_632107352457871_5690110333313757656_n.jpg?_nc_cat=101&ccb=1-7&_nc_sid=3635dc&_nc_ohc=OpZIs7vdMK8AX9Hgjkq&_nc_ht=scontent.fsgn5-10.fna&oh=00_AfAvpIg3y_s3UEGS0ilM8J6x6spEamFSC3sjhVn3V7G5-A&oe=65A6DF8C", "Nội dung bài đăng test 1" },
                    { new Guid("f2c5a3b4-8885-4673-8bcc-3702dbbae15d"), 1, new DateTime(2024, 1, 14, 2, 39, 42, 428, DateTimeKind.Local).AddTicks(2943), null, false, null, null, 10, 100, "Nội dung bài đăng test thử ", "https://scontent.fsgn5-10.fna.fbcdn.net/v/t39.30808-6/387798154_632107352457871_5690110333313757656_n.jpg?_nc_cat=101&ccb=1-7&_nc_sid=3635dc&_nc_ohc=OpZIs7vdMK8AX9Hgjkq&_nc_ht=scontent.fsgn5-10.fna&oh=00_AfAvpIg3y_s3UEGS0ilM8J6x6spEamFSC3sjhVn3V7G5-A&oe=65A6DF8C", "Nội dung bài đăng test 2" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Created", "CreatedBy", "IsDeleted", "LastModified", "LastModifiedBy", "TagName" },
                values: new object[,]
                {
                    { new Guid("150b7aba-a76f-40b2-b7e5-19961bda108f"), new DateTime(2024, 1, 14, 2, 39, 42, 428, DateTimeKind.Local).AddTicks(2965), null, false, null, null, "Học đường" },
                    { new Guid("2b3a61bf-1543-4e9f-900b-d4901be7e78c"), new DateTime(2024, 1, 14, 2, 39, 42, 428, DateTimeKind.Local).AddTicks(2973), null, false, null, null, "Công việc" },
                    { new Guid("6598d9c2-ef4d-4295-a06a-e45a3cfc7b9d"), new DateTime(2024, 1, 14, 2, 39, 42, 428, DateTimeKind.Local).AddTicks(2976), null, false, null, null, "Gia đình" },
                    { new Guid("79a50b87-3bb3-4acc-b164-ef5795db17e3"), new DateTime(2024, 1, 14, 2, 39, 42, 428, DateTimeKind.Local).AddTicks(2979), null, false, null, null, "Xã hội" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Created", "CreatedBy", "Description", "IsDeleted", "LastModified", "LastModifiedBy", "PostId", "ReplyCommentId", "UserAccountId" },
                values: new object[,]
                {
                    { new Guid("65191898-080f-4c24-b39a-653e57323400"), new DateTime(2024, 1, 14, 2, 39, 42, 428, DateTimeKind.Local).AddTicks(3023), null, "Nội dung comment", false, null, null, new Guid("14b76851-0f86-4dd2-a59c-ae45893c9578"), null, "871a809a-b3fa-495b-9cc2-c5d738a866cf" },
                    { new Guid("981c2b78-2662-4929-ab07-75e36d58e9bb"), new DateTime(2024, 1, 14, 2, 39, 42, 428, DateTimeKind.Local).AddTicks(3034), null, "Nội dung comment test", false, null, null, new Guid("f2c5a3b4-8885-4673-8bcc-3702dbbae15d"), null, "871a809a-b3fa-495b-9cc2-c5d738a866cf" },
                    { new Guid("cca90e51-b859-4830-8fcf-989163aaa4d9"), new DateTime(2024, 1, 14, 2, 39, 42, 428, DateTimeKind.Local).AddTicks(3029), null, "Em chỉ đang cảm thấy mệt mỏi, quá tải và cần sẻ chia thôi. Anh luôn ở đây hỗ trợ em, bản chất em có những suy nghĩ trên đã là một điểm tích cực, là điều đáng quý. Hãy bắt đầu từ việc viết lại mục đích, lý do chọn lựa con đường của em, để lấy nó làm điểm tựa mỗi khi đối diện với cảm xúc khó chịu mà em đề cập. Còn nếu được hãy tham gia một buổi hẹn ngắn với anh nếu em vẫn cảm thấy struggle", false, null, null, new Guid("14b76851-0f86-4dd2-a59c-ae45893c9578"), null, "424ab531-d60a-487e-9625-a74a7f5747be" }
                });

            migrationBuilder.InsertData(
                table: "PostTags",
                columns: new[] { "Id", "Created", "CreatedBy", "IsDeleted", "LastModified", "LastModifiedBy", "PostId", "TagId" },
                values: new object[,]
                {
                    { new Guid("5d7deaf1-d72b-457e-bf56-877a89d37fac"), new DateTime(2024, 1, 14, 2, 39, 42, 428, DateTimeKind.Local).AddTicks(3001), null, false, null, null, new Guid("14b76851-0f86-4dd2-a59c-ae45893c9578"), new Guid("6598d9c2-ef4d-4295-a06a-e45a3cfc7b9d") },
                    { new Guid("647b2bd5-ea1b-42a6-a92e-8263fb160754"), new DateTime(2024, 1, 14, 2, 39, 42, 428, DateTimeKind.Local).AddTicks(2997), null, false, null, null, new Guid("14b76851-0f86-4dd2-a59c-ae45893c9578"), new Guid("150b7aba-a76f-40b2-b7e5-19961bda108f") },
                    { new Guid("bcc26154-4ca0-4b51-808a-911bb4e09447"), new DateTime(2024, 1, 14, 2, 39, 42, 428, DateTimeKind.Local).AddTicks(3004), null, false, null, null, new Guid("f2c5a3b4-8885-4673-8bcc-3702dbbae15d"), new Guid("79a50b87-3bb3-4acc-b164-ef5795db17e3") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("65191898-080f-4c24-b39a-653e57323400"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("981c2b78-2662-4929-ab07-75e36d58e9bb"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("cca90e51-b859-4830-8fcf-989163aaa4d9"));

            migrationBuilder.DeleteData(
                table: "PostTags",
                keyColumn: "Id",
                keyValue: new Guid("5d7deaf1-d72b-457e-bf56-877a89d37fac"));

            migrationBuilder.DeleteData(
                table: "PostTags",
                keyColumn: "Id",
                keyValue: new Guid("647b2bd5-ea1b-42a6-a92e-8263fb160754"));

            migrationBuilder.DeleteData(
                table: "PostTags",
                keyColumn: "Id",
                keyValue: new Guid("bcc26154-4ca0-4b51-808a-911bb4e09447"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("2b3a61bf-1543-4e9f-900b-d4901be7e78c"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "424ab531-d60a-487e-9625-a74a7f5747be");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "871a809a-b3fa-495b-9cc2-c5d738a866cf");

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("14b76851-0f86-4dd2-a59c-ae45893c9578"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("f2c5a3b4-8885-4673-8bcc-3702dbbae15d"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("150b7aba-a76f-40b2-b7e5-19961bda108f"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("6598d9c2-ef4d-4295-a06a-e45a3cfc7b9d"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("79a50b87-3bb3-4acc-b164-ef5795db17e3"));

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AnonymousStatus", "Created", "CreatedBy", "IsDeleted", "LastModified", "LastModifiedBy", "NumberOfDisLikes", "NumberOfLikes", "PostBody", "PostImagesUrl", "PostTitle" },
                values: new object[,]
                {
                    { new Guid("55b7d164-ebb7-466e-a7d8-d2c1cbed3d30"), 1, new DateTime(2024, 1, 13, 19, 6, 59, 218, DateTimeKind.Local).AddTicks(1047), null, false, null, null, 10, 100, "Nội dung bài đăng test thử ", "https://scontent.fsgn5-10.fna.fbcdn.net/v/t39.30808-6/387798154_632107352457871_5690110333313757656_n.jpg?_nc_cat=101&ccb=1-7&_nc_sid=3635dc&_nc_ohc=OpZIs7vdMK8AX9Hgjkq&_nc_ht=scontent.fsgn5-10.fna&oh=00_AfAvpIg3y_s3UEGS0ilM8J6x6spEamFSC3sjhVn3V7G5-A&oe=65A6DF8C", "Nội dung bài đăng test 1" },
                    { new Guid("75da058c-13cf-4027-9962-8e4c00ec297c"), 1, new DateTime(2024, 1, 13, 19, 6, 59, 218, DateTimeKind.Local).AddTicks(1032), null, false, null, null, 10, 100, "Nội dung bài đăng test thử ", "https://scontent.fsgn5-10.fna.fbcdn.net/v/t39.30808-6/387798154_632107352457871_5690110333313757656_n.jpg?_nc_cat=101&ccb=1-7&_nc_sid=3635dc&_nc_ohc=OpZIs7vdMK8AX9Hgjkq&_nc_ht=scontent.fsgn5-10.fna&oh=00_AfAvpIg3y_s3UEGS0ilM8J6x6spEamFSC3sjhVn3V7G5-A&oe=65A6DF8C", "Nội dung bài đăng test 1" }
                });
        }
    }
}
