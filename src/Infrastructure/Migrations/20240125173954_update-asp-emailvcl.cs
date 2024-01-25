using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZAlpha.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateaspemailvcl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "424ab531-d60a-487e-9625-a74a7f5747be",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "58c0c9d7-e64d-4c19-9f04-f8b57b33bcaf", "a98c4667-8f3c-4403-8e26-fa70240cdceb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "871a809a-b3fa-495b-9cc2-c5d738a866cf",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4c482862-edcc-498e-822f-c1d3a07574cf", "233d43d5-ade4-46ca-9df5-2d26170d0b9c" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "424ab531-d60a-487e-9625-a74a7f5747be",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c89d2137-3cac-4965-b6cb-0b653d112005", "a222679e-12d4-49d1-b3e3-dfa5c24acbb2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "871a809a-b3fa-495b-9cc2-c5d738a866cf",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "99a35769-b846-43a7-be81-9c6844bcca1c", "0b87f7b3-b6de-4c35-929f-702597cf1da5" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("65191898-080f-4c24-b39a-653e57323400"),
                column: "Created",
                value: new DateTime(2024, 1, 21, 21, 50, 6, 242, DateTimeKind.Local).AddTicks(7056));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("981c2b78-2662-4929-ab07-75e36d58e9bb"),
                column: "Created",
                value: new DateTime(2024, 1, 21, 21, 50, 6, 242, DateTimeKind.Local).AddTicks(7072));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("cca90e51-b859-4830-8fcf-989163aaa4d9"),
                column: "Created",
                value: new DateTime(2024, 1, 21, 21, 50, 6, 242, DateTimeKind.Local).AddTicks(7066));

            migrationBuilder.UpdateData(
                table: "InteractWithPosts",
                keyColumn: "Id",
                keyValue: new Guid("61291732-1599-46e4-93e2-01aa8fca3801"),
                column: "Created",
                value: new DateTime(2024, 1, 21, 21, 50, 6, 242, DateTimeKind.Local).AddTicks(7092));

            migrationBuilder.UpdateData(
                table: "InteractWithPosts",
                keyColumn: "Id",
                keyValue: new Guid("795154a3-aa8a-4337-8f45-35529a400fd3"),
                column: "Created",
                value: new DateTime(2024, 1, 21, 21, 50, 6, 242, DateTimeKind.Local).AddTicks(7099));

            migrationBuilder.UpdateData(
                table: "PostTags",
                keyColumn: "Id",
                keyValue: new Guid("5d7deaf1-d72b-457e-bf56-877a89d37fac"),
                column: "Created",
                value: new DateTime(2024, 1, 21, 21, 50, 6, 242, DateTimeKind.Local).AddTicks(7028));

            migrationBuilder.UpdateData(
                table: "PostTags",
                keyColumn: "Id",
                keyValue: new Guid("647b2bd5-ea1b-42a6-a92e-8263fb160754"),
                column: "Created",
                value: new DateTime(2024, 1, 21, 21, 50, 6, 242, DateTimeKind.Local).AddTicks(7023));

            migrationBuilder.UpdateData(
                table: "PostTags",
                keyColumn: "Id",
                keyValue: new Guid("bcc26154-4ca0-4b51-808a-911bb4e09447"),
                column: "Created",
                value: new DateTime(2024, 1, 21, 21, 50, 6, 242, DateTimeKind.Local).AddTicks(7032));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("14b76851-0f86-4dd2-a59c-ae45893c9578"),
                column: "Created",
                value: new DateTime(2024, 1, 21, 21, 50, 6, 242, DateTimeKind.Local).AddTicks(6937));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("f2c5a3b4-8885-4673-8bcc-3702dbbae15d"),
                column: "Created",
                value: new DateTime(2024, 1, 21, 21, 50, 6, 242, DateTimeKind.Local).AddTicks(6966));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("150b7aba-a76f-40b2-b7e5-19961bda108f"),
                column: "Created",
                value: new DateTime(2024, 1, 21, 21, 50, 6, 242, DateTimeKind.Local).AddTicks(6994));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("2b3a61bf-1543-4e9f-900b-d4901be7e78c"),
                column: "Created",
                value: new DateTime(2024, 1, 21, 21, 50, 6, 242, DateTimeKind.Local).AddTicks(6998));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("6598d9c2-ef4d-4295-a06a-e45a3cfc7b9d"),
                column: "Created",
                value: new DateTime(2024, 1, 21, 21, 50, 6, 242, DateTimeKind.Local).AddTicks(7001));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("79a50b87-3bb3-4acc-b164-ef5795db17e3"),
                column: "Created",
                value: new DateTime(2024, 1, 21, 21, 50, 6, 242, DateTimeKind.Local).AddTicks(7005));
        }
    }
}
