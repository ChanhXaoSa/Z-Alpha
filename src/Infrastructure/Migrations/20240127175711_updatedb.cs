using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ZAlpha.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatedb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PostTitle",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "AnonymousStatus",
                table: "Posts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "PackPrice",
                table: "Packs",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDay",
                table: "PackDetail",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDay",
                table: "PackDetail",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "424ab531-d60a-487e-9625-a74a7f5747be",
                columns: new[] { "ConcurrencyStamp", "Email", "FirstName", "LastName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "030fb24f-140a-4ee3-99b6-65b81724d7cc", "trieu@gmail.com", "Triệu", "Gà", "AQAAAAIAAYagAAAAEJy3zCJul9KHCbPBHbaSbsgb9wFameULYiABmfOqOk4dGeF5cqYu9WcHaFm5ZcQ0vA==", "f0128319-b21e-4493-b737-4744ec58453f", "trieu" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "871a809a-b3fa-495b-9cc2-c5d738a866cf",
                columns: new[] { "ConcurrencyStamp", "FirstName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "9e624d3a-e8fe-46cf-93c9-d6613d744d65", "Trần", "AQAAAAIAAYagAAAAEJy3zCJul9KHCbPBHbaSbsgb9wFameULYiABmfOqOk4dGeF5cqYu9WcHaFm5ZcQ0vA==", "fd69beeb-df33-45d2-aa5f-7206cb0a7f8a", "vinh" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Avatar", "AvatarUrl", "BirthDay", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsPremium", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName", "Wallet" },
                values: new object[,]
                {
                    { "41d8778f-80e0-4dd5-b7db-86eb1c32d40d", 0, null, null, null, null, "a66eeaf6-c59d-4e2c-8a72-5c79bf5be965", "kiet@gmail.com", false, "Kiệt", null, "Kiệt", false, null, null, null, "AQAAAAIAAYagAAAAEJy3zCJul9KHCbPBHbaSbsgb9wFameULYiABmfOqOk4dGeF5cqYu9WcHaFm5ZcQ0vA==", null, null, false, "713150f0-4b2d-4227-8190-15b82c2355dd", 1, false, "kiet", 1000.0 },
                    { "a1c48523-eee4-4151-9c82-23ebf8b0f762", 0, null, null, null, null, "38b28065-d3e1-4fe9-b816-b2cfc4612e01", "kien@gmail.com", false, "kiên", null, "kiên", false, null, null, null, "AQAAAAIAAYagAAAAEJy3zCJul9KHCbPBHbaSbsgb9wFameULYiABmfOqOk4dGeF5cqYu9WcHaFm5ZcQ0vA==", null, null, false, "6f831d3f-b8f6-4520-bdc4-cfb1c0052c3b", 1, false, "kien", 1000.0 }
                });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("65191898-080f-4c24-b39a-653e57323400"),
                column: "Created",
                value: new DateTime(2024, 1, 28, 0, 57, 11, 137, DateTimeKind.Local).AddTicks(2820));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("981c2b78-2662-4929-ab07-75e36d58e9bb"),
                column: "Created",
                value: new DateTime(2024, 1, 28, 0, 57, 11, 137, DateTimeKind.Local).AddTicks(2830));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("cca90e51-b859-4830-8fcf-989163aaa4d9"),
                column: "Created",
                value: new DateTime(2024, 1, 28, 0, 57, 11, 137, DateTimeKind.Local).AddTicks(2827));

            migrationBuilder.UpdateData(
                table: "InteractWithPosts",
                keyColumn: "Id",
                keyValue: new Guid("61291732-1599-46e4-93e2-01aa8fca3801"),
                column: "Created",
                value: new DateTime(2024, 1, 28, 0, 57, 11, 137, DateTimeKind.Local).AddTicks(2848));

            migrationBuilder.UpdateData(
                table: "InteractWithPosts",
                keyColumn: "Id",
                keyValue: new Guid("795154a3-aa8a-4337-8f45-35529a400fd3"),
                column: "Created",
                value: new DateTime(2024, 1, 28, 0, 57, 11, 137, DateTimeKind.Local).AddTicks(2854));

            migrationBuilder.InsertData(
                table: "Packs",
                columns: new[] { "Id", "Created", "CreatedBy", "IsDeleted", "LastModified", "LastModifiedBy", "PackInfomation", "PackName", "PackPrice" },
                values: new object[,]
                {
                    { new Guid("8853faf2-87f1-4c17-8e20-7253720265be"), new DateTime(2024, 1, 28, 0, 57, 11, 137, DateTimeKind.Local).AddTicks(2878), null, false, null, null, "tương đương 365 ngày", "Năm", 499000.0 },
                    { new Guid("8e5b48df-713e-4fe3-844b-8258c785ff7e"), new DateTime(2024, 1, 28, 0, 57, 11, 137, DateTimeKind.Local).AddTicks(2869), null, false, null, null, "Giới hạn lượt đăng bài và tương tác", "Dùng thử", 0.0 },
                    { new Guid("92b2fb8c-866c-445b-87b4-dc7bb3c828ac"), new DateTime(2024, 1, 28, 0, 57, 11, 137, DateTimeKind.Local).AddTicks(2875), null, false, null, null, "3 tháng, tương đương 90 ngày", "Quý", 129000.0 },
                    { new Guid("e609e43f-b6ad-468e-91d1-785b282d345b"), new DateTime(2024, 1, 28, 0, 57, 11, 137, DateTimeKind.Local).AddTicks(2873), null, false, null, null, "30 ngày", "Tháng", 49000.0 }
                });

            migrationBuilder.UpdateData(
                table: "PostTags",
                keyColumn: "Id",
                keyValue: new Guid("5d7deaf1-d72b-457e-bf56-877a89d37fac"),
                column: "Created",
                value: new DateTime(2024, 1, 28, 0, 57, 11, 137, DateTimeKind.Local).AddTicks(2802));

            migrationBuilder.UpdateData(
                table: "PostTags",
                keyColumn: "Id",
                keyValue: new Guid("647b2bd5-ea1b-42a6-a92e-8263fb160754"),
                column: "Created",
                value: new DateTime(2024, 1, 28, 0, 57, 11, 137, DateTimeKind.Local).AddTicks(2797));

            migrationBuilder.UpdateData(
                table: "PostTags",
                keyColumn: "Id",
                keyValue: new Guid("bcc26154-4ca0-4b51-808a-911bb4e09447"),
                column: "Created",
                value: new DateTime(2024, 1, 28, 0, 57, 11, 137, DateTimeKind.Local).AddTicks(2805));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("14b76851-0f86-4dd2-a59c-ae45893c9578"),
                column: "Created",
                value: new DateTime(2024, 1, 28, 0, 57, 11, 137, DateTimeKind.Local).AddTicks(2720));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("f2c5a3b4-8885-4673-8bcc-3702dbbae15d"),
                column: "Created",
                value: new DateTime(2024, 1, 28, 0, 57, 11, 137, DateTimeKind.Local).AddTicks(2750));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("150b7aba-a76f-40b2-b7e5-19961bda108f"),
                column: "Created",
                value: new DateTime(2024, 1, 28, 0, 57, 11, 137, DateTimeKind.Local).AddTicks(2770));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("2b3a61bf-1543-4e9f-900b-d4901be7e78c"),
                column: "Created",
                value: new DateTime(2024, 1, 28, 0, 57, 11, 137, DateTimeKind.Local).AddTicks(2774));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("6598d9c2-ef4d-4295-a06a-e45a3cfc7b9d"),
                column: "Created",
                value: new DateTime(2024, 1, 28, 0, 57, 11, 137, DateTimeKind.Local).AddTicks(2779));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("79a50b87-3bb3-4acc-b164-ef5795db17e3"),
                column: "Created",
                value: new DateTime(2024, 1, 28, 0, 57, 11, 137, DateTimeKind.Local).AddTicks(2782));

            migrationBuilder.InsertData(
                table: "PackDetail",
                columns: new[] { "Id", "Created", "CreatedBy", "EndDay", "IsDeleted", "LastModified", "LastModifiedBy", "PackId", "StartDay", "UserAccountId" },
                values: new object[,]
                {
                    { new Guid("85ff8767-adac-4dfa-a49a-18c20d071c09"), new DateTime(2024, 1, 28, 0, 57, 11, 137, DateTimeKind.Local).AddTicks(2896), null, new DateTime(2024, 1, 29, 8, 30, 56, 0, DateTimeKind.Unspecified), false, null, null, new Guid("e609e43f-b6ad-468e-91d1-785b282d345b"), new DateTime(2024, 1, 27, 8, 30, 56, 0, DateTimeKind.Unspecified), "424ab531-d60a-487e-9625-a74a7f5747be" },
                    { new Guid("9ce9944f-8958-48bd-9e20-5ec5b7b283e9"), new DateTime(2024, 1, 28, 0, 57, 11, 137, DateTimeKind.Local).AddTicks(2892), null, null, false, null, null, new Guid("8e5b48df-713e-4fe3-844b-8258c785ff7e"), null, "871a809a-b3fa-495b-9cc2-c5d738a866cf" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41d8778f-80e0-4dd5-b7db-86eb1c32d40d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1c48523-eee4-4151-9c82-23ebf8b0f762");

            migrationBuilder.DeleteData(
                table: "PackDetail",
                keyColumn: "Id",
                keyValue: new Guid("85ff8767-adac-4dfa-a49a-18c20d071c09"));

            migrationBuilder.DeleteData(
                table: "PackDetail",
                keyColumn: "Id",
                keyValue: new Guid("9ce9944f-8958-48bd-9e20-5ec5b7b283e9"));

            migrationBuilder.DeleteData(
                table: "Packs",
                keyColumn: "Id",
                keyValue: new Guid("8853faf2-87f1-4c17-8e20-7253720265be"));

            migrationBuilder.DeleteData(
                table: "Packs",
                keyColumn: "Id",
                keyValue: new Guid("92b2fb8c-866c-445b-87b4-dc7bb3c828ac"));

            migrationBuilder.DeleteData(
                table: "Packs",
                keyColumn: "Id",
                keyValue: new Guid("8e5b48df-713e-4fe3-844b-8258c785ff7e"));

            migrationBuilder.DeleteData(
                table: "Packs",
                keyColumn: "Id",
                keyValue: new Guid("e609e43f-b6ad-468e-91d1-785b282d345b"));

            migrationBuilder.AlterColumn<string>(
                name: "PostTitle",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AnonymousStatus",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "PackPrice",
                table: "Packs",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDay",
                table: "PackDetail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDay",
                table: "PackDetail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "424ab531-d60a-487e-9625-a74a7f5747be",
                columns: new[] { "ConcurrencyStamp", "Email", "FirstName", "LastName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "58c0c9d7-e64d-4c19-9f04-f8b57b33bcaf", "test@gmail.com", "Chan", "Dinh", null, "a98c4667-8f3c-4403-8e26-fa70240cdceb", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "871a809a-b3fa-495b-9cc2-c5d738a866cf",
                columns: new[] { "ConcurrencyStamp", "FirstName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "4c482862-edcc-498e-822f-c1d3a07574cf", "Tran", null, "233d43d5-ade4-46ca-9df5-2d26170d0b9c", null });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("65191898-080f-4c24-b39a-653e57323400"),
                column: "Created",
                value: new DateTime(2024, 1, 26, 0, 39, 54, 171, DateTimeKind.Local).AddTicks(6747));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("981c2b78-2662-4929-ab07-75e36d58e9bb"),
                column: "Created",
                value: new DateTime(2024, 1, 26, 0, 39, 54, 171, DateTimeKind.Local).AddTicks(6752));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("cca90e51-b859-4830-8fcf-989163aaa4d9"),
                column: "Created",
                value: new DateTime(2024, 1, 26, 0, 39, 54, 171, DateTimeKind.Local).AddTicks(6750));

            migrationBuilder.UpdateData(
                table: "InteractWithPosts",
                keyColumn: "Id",
                keyValue: new Guid("61291732-1599-46e4-93e2-01aa8fca3801"),
                column: "Created",
                value: new DateTime(2024, 1, 26, 0, 39, 54, 171, DateTimeKind.Local).AddTicks(6773));

            migrationBuilder.UpdateData(
                table: "InteractWithPosts",
                keyColumn: "Id",
                keyValue: new Guid("795154a3-aa8a-4337-8f45-35529a400fd3"),
                column: "Created",
                value: new DateTime(2024, 1, 26, 0, 39, 54, 171, DateTimeKind.Local).AddTicks(6785));

            migrationBuilder.UpdateData(
                table: "PostTags",
                keyColumn: "Id",
                keyValue: new Guid("5d7deaf1-d72b-457e-bf56-877a89d37fac"),
                column: "Created",
                value: new DateTime(2024, 1, 26, 0, 39, 54, 171, DateTimeKind.Local).AddTicks(6722));

            migrationBuilder.UpdateData(
                table: "PostTags",
                keyColumn: "Id",
                keyValue: new Guid("647b2bd5-ea1b-42a6-a92e-8263fb160754"),
                column: "Created",
                value: new DateTime(2024, 1, 26, 0, 39, 54, 171, DateTimeKind.Local).AddTicks(6719));

            migrationBuilder.UpdateData(
                table: "PostTags",
                keyColumn: "Id",
                keyValue: new Guid("bcc26154-4ca0-4b51-808a-911bb4e09447"),
                column: "Created",
                value: new DateTime(2024, 1, 26, 0, 39, 54, 171, DateTimeKind.Local).AddTicks(6725));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("14b76851-0f86-4dd2-a59c-ae45893c9578"),
                column: "Created",
                value: new DateTime(2024, 1, 26, 0, 39, 54, 171, DateTimeKind.Local).AddTicks(6637));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("f2c5a3b4-8885-4673-8bcc-3702dbbae15d"),
                column: "Created",
                value: new DateTime(2024, 1, 26, 0, 39, 54, 171, DateTimeKind.Local).AddTicks(6666));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("150b7aba-a76f-40b2-b7e5-19961bda108f"),
                column: "Created",
                value: new DateTime(2024, 1, 26, 0, 39, 54, 171, DateTimeKind.Local).AddTicks(6687));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("2b3a61bf-1543-4e9f-900b-d4901be7e78c"),
                column: "Created",
                value: new DateTime(2024, 1, 26, 0, 39, 54, 171, DateTimeKind.Local).AddTicks(6690));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("6598d9c2-ef4d-4295-a06a-e45a3cfc7b9d"),
                column: "Created",
                value: new DateTime(2024, 1, 26, 0, 39, 54, 171, DateTimeKind.Local).AddTicks(6693));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("79a50b87-3bb3-4acc-b164-ef5795db17e3"),
                column: "Created",
                value: new DateTime(2024, 1, 26, 0, 39, 54, 171, DateTimeKind.Local).AddTicks(6696));
        }
    }
}
