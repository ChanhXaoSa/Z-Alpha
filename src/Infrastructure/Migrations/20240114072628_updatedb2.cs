using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CleanArchitecture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatedb2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "424ab531-d60a-487e-9625-a74a7f5747be",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0d89dc8f-235f-4115-9d46-0aaa873a1426", "d673a412-0f9b-4b18-bbcf-af5d26c99019" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "871a809a-b3fa-495b-9cc2-c5d738a866cf",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4744d20a-dd52-4ca8-8dcd-4bfeb3a6ccd6", "7411781f-3485-4c57-8807-f2264a66cbcb" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("65191898-080f-4c24-b39a-653e57323400"),
                column: "Created",
                value: new DateTime(2024, 1, 14, 14, 26, 28, 673, DateTimeKind.Local).AddTicks(8353));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("981c2b78-2662-4929-ab07-75e36d58e9bb"),
                column: "Created",
                value: new DateTime(2024, 1, 14, 14, 26, 28, 673, DateTimeKind.Local).AddTicks(8361));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("cca90e51-b859-4830-8fcf-989163aaa4d9"),
                column: "Created",
                value: new DateTime(2024, 1, 14, 14, 26, 28, 673, DateTimeKind.Local).AddTicks(8358));

            migrationBuilder.InsertData(
                table: "InteractWithPosts",
                columns: new[] { "Id", "Created", "CreatedBy", "InteractPostStatus", "IsDeleted", "LastModified", "LastModifiedBy", "PostId", "UserAccountId" },
                values: new object[,]
                {
                    { new Guid("61291732-1599-46e4-93e2-01aa8fca3801"), new DateTime(2024, 1, 14, 14, 26, 28, 673, DateTimeKind.Local).AddTicks(8377), null, 0, false, null, null, new Guid("14b76851-0f86-4dd2-a59c-ae45893c9578"), "871a809a-b3fa-495b-9cc2-c5d738a866cf" },
                    { new Guid("795154a3-aa8a-4337-8f45-35529a400fd3"), new DateTime(2024, 1, 14, 14, 26, 28, 673, DateTimeKind.Local).AddTicks(8382), null, 0, false, null, null, new Guid("f2c5a3b4-8885-4673-8bcc-3702dbbae15d"), "424ab531-d60a-487e-9625-a74a7f5747be" }
                });

            migrationBuilder.UpdateData(
                table: "PostTags",
                keyColumn: "Id",
                keyValue: new Guid("5d7deaf1-d72b-457e-bf56-877a89d37fac"),
                column: "Created",
                value: new DateTime(2024, 1, 14, 14, 26, 28, 673, DateTimeKind.Local).AddTicks(8332));

            migrationBuilder.UpdateData(
                table: "PostTags",
                keyColumn: "Id",
                keyValue: new Guid("647b2bd5-ea1b-42a6-a92e-8263fb160754"),
                column: "Created",
                value: new DateTime(2024, 1, 14, 14, 26, 28, 673, DateTimeKind.Local).AddTicks(8328));

            migrationBuilder.UpdateData(
                table: "PostTags",
                keyColumn: "Id",
                keyValue: new Guid("bcc26154-4ca0-4b51-808a-911bb4e09447"),
                column: "Created",
                value: new DateTime(2024, 1, 14, 14, 26, 28, 673, DateTimeKind.Local).AddTicks(8336));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("14b76851-0f86-4dd2-a59c-ae45893c9578"),
                column: "Created",
                value: new DateTime(2024, 1, 14, 14, 26, 28, 673, DateTimeKind.Local).AddTicks(8256));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("f2c5a3b4-8885-4673-8bcc-3702dbbae15d"),
                column: "Created",
                value: new DateTime(2024, 1, 14, 14, 26, 28, 673, DateTimeKind.Local).AddTicks(8280));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("150b7aba-a76f-40b2-b7e5-19961bda108f"),
                column: "Created",
                value: new DateTime(2024, 1, 14, 14, 26, 28, 673, DateTimeKind.Local).AddTicks(8301));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("2b3a61bf-1543-4e9f-900b-d4901be7e78c"),
                column: "Created",
                value: new DateTime(2024, 1, 14, 14, 26, 28, 673, DateTimeKind.Local).AddTicks(8304));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("6598d9c2-ef4d-4295-a06a-e45a3cfc7b9d"),
                column: "Created",
                value: new DateTime(2024, 1, 14, 14, 26, 28, 673, DateTimeKind.Local).AddTicks(8306));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("79a50b87-3bb3-4acc-b164-ef5795db17e3"),
                column: "Created",
                value: new DateTime(2024, 1, 14, 14, 26, 28, 673, DateTimeKind.Local).AddTicks(8308));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "InteractWithPosts",
                keyColumn: "Id",
                keyValue: new Guid("61291732-1599-46e4-93e2-01aa8fca3801"));

            migrationBuilder.DeleteData(
                table: "InteractWithPosts",
                keyColumn: "Id",
                keyValue: new Guid("795154a3-aa8a-4337-8f45-35529a400fd3"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "424ab531-d60a-487e-9625-a74a7f5747be",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "84e3d970-3a85-4bf6-bcbb-f2289a68805f", "8f09b226-7a29-4fdf-853c-4a50a0864b48" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "871a809a-b3fa-495b-9cc2-c5d738a866cf",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8a06d124-67a2-4734-a0b5-c71027fa0093", "15ed186a-18ee-4aa1-9624-f0414d158d2a" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("65191898-080f-4c24-b39a-653e57323400"),
                column: "Created",
                value: new DateTime(2024, 1, 14, 2, 39, 42, 428, DateTimeKind.Local).AddTicks(3023));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("981c2b78-2662-4929-ab07-75e36d58e9bb"),
                column: "Created",
                value: new DateTime(2024, 1, 14, 2, 39, 42, 428, DateTimeKind.Local).AddTicks(3034));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("cca90e51-b859-4830-8fcf-989163aaa4d9"),
                column: "Created",
                value: new DateTime(2024, 1, 14, 2, 39, 42, 428, DateTimeKind.Local).AddTicks(3029));

            migrationBuilder.UpdateData(
                table: "PostTags",
                keyColumn: "Id",
                keyValue: new Guid("5d7deaf1-d72b-457e-bf56-877a89d37fac"),
                column: "Created",
                value: new DateTime(2024, 1, 14, 2, 39, 42, 428, DateTimeKind.Local).AddTicks(3001));

            migrationBuilder.UpdateData(
                table: "PostTags",
                keyColumn: "Id",
                keyValue: new Guid("647b2bd5-ea1b-42a6-a92e-8263fb160754"),
                column: "Created",
                value: new DateTime(2024, 1, 14, 2, 39, 42, 428, DateTimeKind.Local).AddTicks(2997));

            migrationBuilder.UpdateData(
                table: "PostTags",
                keyColumn: "Id",
                keyValue: new Guid("bcc26154-4ca0-4b51-808a-911bb4e09447"),
                column: "Created",
                value: new DateTime(2024, 1, 14, 2, 39, 42, 428, DateTimeKind.Local).AddTicks(3004));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("14b76851-0f86-4dd2-a59c-ae45893c9578"),
                column: "Created",
                value: new DateTime(2024, 1, 14, 2, 39, 42, 428, DateTimeKind.Local).AddTicks(2870));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("f2c5a3b4-8885-4673-8bcc-3702dbbae15d"),
                column: "Created",
                value: new DateTime(2024, 1, 14, 2, 39, 42, 428, DateTimeKind.Local).AddTicks(2943));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("150b7aba-a76f-40b2-b7e5-19961bda108f"),
                column: "Created",
                value: new DateTime(2024, 1, 14, 2, 39, 42, 428, DateTimeKind.Local).AddTicks(2965));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("2b3a61bf-1543-4e9f-900b-d4901be7e78c"),
                column: "Created",
                value: new DateTime(2024, 1, 14, 2, 39, 42, 428, DateTimeKind.Local).AddTicks(2973));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("6598d9c2-ef4d-4295-a06a-e45a3cfc7b9d"),
                column: "Created",
                value: new DateTime(2024, 1, 14, 2, 39, 42, 428, DateTimeKind.Local).AddTicks(2976));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("79a50b87-3bb3-4acc-b164-ef5795db17e3"),
                column: "Created",
                value: new DateTime(2024, 1, 14, 2, 39, 42, 428, DateTimeKind.Local).AddTicks(2979));
        }
    }
}
