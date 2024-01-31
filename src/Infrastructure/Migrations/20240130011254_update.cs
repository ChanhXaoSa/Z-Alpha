using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZAlpha.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41d8778f-80e0-4dd5-b7db-86eb1c32d40d",
                columns: new[] { "ConcurrencyStamp", "Email", "FirstName", "SecurityStamp" },
                values: new object[] { "c51583e0-0568-46d9-8cb5-459949317d2f", "test3@gmail.com", "Tài khoản ảo", "db3b2a2d-4f96-4a0e-b8b9-dd021290eea9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "424ab531-d60a-487e-9625-a74a7f5747be",
                columns: new[] { "ConcurrencyStamp", "Email", "FirstName", "SecurityStamp" },
                values: new object[] { "83fe8067-f041-4c70-803a-0bbfe5ab49a5", "test2@gmail.com", "Tài khoản ảo", "f642d871-f267-481f-9c75-fdb449873306" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "871a809a-b3fa-495b-9cc2-c5d738a866cf",
                columns: new[] { "ConcurrencyStamp", "Email", "FirstName", "SecurityStamp" },
                values: new object[] { "bbfc36bf-f5fc-413f-a682-fa9715b47961", "test1@gmail.com", "Tài khoản ảo", "32b60f1d-1ed3-4082-b9a8-cfa4b8f9827c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1c48523-eee4-4151-9c82-23ebf8b0f762",
                columns: new[] { "ConcurrencyStamp", "Email", "FirstName", "SecurityStamp" },
                values: new object[] { "09b49cdd-64b0-423d-810d-2ad37faa5a04", "test4@gmail.com", "Tài khoản ảo", "234120e2-f38c-4187-b189-9aca5060d8a1" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("65191898-080f-4c24-b39a-653e57323400"),
                column: "Created",
                value: new DateTime(2024, 1, 30, 8, 12, 53, 822, DateTimeKind.Local).AddTicks(5701));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("981c2b78-2662-4929-ab07-75e36d58e9bb"),
                column: "Created",
                value: new DateTime(2024, 1, 30, 8, 12, 53, 822, DateTimeKind.Local).AddTicks(5710));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("cca90e51-b859-4830-8fcf-989163aaa4d9"),
                column: "Created",
                value: new DateTime(2024, 1, 30, 8, 12, 53, 822, DateTimeKind.Local).AddTicks(5706));

            migrationBuilder.UpdateData(
                table: "InteractWithPosts",
                keyColumn: "Id",
                keyValue: new Guid("61291732-1599-46e4-93e2-01aa8fca3801"),
                column: "Created",
                value: new DateTime(2024, 1, 30, 8, 12, 53, 822, DateTimeKind.Local).AddTicks(5733));

            migrationBuilder.UpdateData(
                table: "InteractWithPosts",
                keyColumn: "Id",
                keyValue: new Guid("795154a3-aa8a-4337-8f45-35529a400fd3"),
                column: "Created",
                value: new DateTime(2024, 1, 30, 8, 12, 53, 822, DateTimeKind.Local).AddTicks(5739));

            migrationBuilder.UpdateData(
                table: "PackDetail",
                keyColumn: "Id",
                keyValue: new Guid("85ff8767-adac-4dfa-a49a-18c20d071c09"),
                column: "Created",
                value: new DateTime(2024, 1, 30, 8, 12, 53, 822, DateTimeKind.Local).AddTicks(5789));

            migrationBuilder.UpdateData(
                table: "PackDetail",
                keyColumn: "Id",
                keyValue: new Guid("9ce9944f-8958-48bd-9e20-5ec5b7b283e9"),
                column: "Created",
                value: new DateTime(2024, 1, 30, 8, 12, 53, 822, DateTimeKind.Local).AddTicks(5784));

            migrationBuilder.UpdateData(
                table: "Packs",
                keyColumn: "Id",
                keyValue: new Guid("8853faf2-87f1-4c17-8e20-7253720265be"),
                column: "Created",
                value: new DateTime(2024, 1, 30, 8, 12, 53, 822, DateTimeKind.Local).AddTicks(5765));

            migrationBuilder.UpdateData(
                table: "Packs",
                keyColumn: "Id",
                keyValue: new Guid("8e5b48df-713e-4fe3-844b-8258c785ff7e"),
                column: "Created",
                value: new DateTime(2024, 1, 30, 8, 12, 53, 822, DateTimeKind.Local).AddTicks(5755));

            migrationBuilder.UpdateData(
                table: "Packs",
                keyColumn: "Id",
                keyValue: new Guid("92b2fb8c-866c-445b-87b4-dc7bb3c828ac"),
                column: "Created",
                value: new DateTime(2024, 1, 30, 8, 12, 53, 822, DateTimeKind.Local).AddTicks(5762));

            migrationBuilder.UpdateData(
                table: "Packs",
                keyColumn: "Id",
                keyValue: new Guid("e609e43f-b6ad-468e-91d1-785b282d345b"),
                column: "Created",
                value: new DateTime(2024, 1, 30, 8, 12, 53, 822, DateTimeKind.Local).AddTicks(5760));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("94422c85-1d58-4f47-b5cb-a2794e757268"),
                column: "Created",
                value: new DateTime(2024, 1, 30, 8, 12, 53, 822, DateTimeKind.Local).AddTicks(5891));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("d49773a8-6f63-4803-8c46-69f1349a5c20"),
                column: "Created",
                value: new DateTime(2024, 1, 30, 8, 12, 53, 822, DateTimeKind.Local).AddTicks(5894));

            migrationBuilder.UpdateData(
                table: "PostTags",
                keyColumn: "Id",
                keyValue: new Guid("5d7deaf1-d72b-457e-bf56-877a89d37fac"),
                column: "Created",
                value: new DateTime(2024, 1, 30, 8, 12, 53, 822, DateTimeKind.Local).AddTicks(5673));

            migrationBuilder.UpdateData(
                table: "PostTags",
                keyColumn: "Id",
                keyValue: new Guid("647b2bd5-ea1b-42a6-a92e-8263fb160754"),
                column: "Created",
                value: new DateTime(2024, 1, 30, 8, 12, 53, 822, DateTimeKind.Local).AddTicks(5668));

            migrationBuilder.UpdateData(
                table: "PostTags",
                keyColumn: "Id",
                keyValue: new Guid("bcc26154-4ca0-4b51-808a-911bb4e09447"),
                column: "Created",
                value: new DateTime(2024, 1, 30, 8, 12, 53, 822, DateTimeKind.Local).AddTicks(5676));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("14b76851-0f86-4dd2-a59c-ae45893c9578"),
                column: "Created",
                value: new DateTime(2024, 1, 30, 8, 12, 53, 822, DateTimeKind.Local).AddTicks(5497));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("f2c5a3b4-8885-4673-8bcc-3702dbbae15d"),
                column: "Created",
                value: new DateTime(2024, 1, 30, 8, 12, 53, 822, DateTimeKind.Local).AddTicks(5528));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("150b7aba-a76f-40b2-b7e5-19961bda108f"),
                column: "Created",
                value: new DateTime(2024, 1, 30, 8, 12, 53, 822, DateTimeKind.Local).AddTicks(5551));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("2b3a61bf-1543-4e9f-900b-d4901be7e78c"),
                column: "Created",
                value: new DateTime(2024, 1, 30, 8, 12, 53, 822, DateTimeKind.Local).AddTicks(5556));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("6598d9c2-ef4d-4295-a06a-e45a3cfc7b9d"),
                column: "Created",
                value: new DateTime(2024, 1, 30, 8, 12, 53, 822, DateTimeKind.Local).AddTicks(5562));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("79a50b87-3bb3-4acc-b164-ef5795db17e3"),
                column: "Created",
                value: new DateTime(2024, 1, 30, 8, 12, 53, 822, DateTimeKind.Local).AddTicks(5565));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41d8778f-80e0-4dd5-b7db-86eb1c32d40d",
                columns: new[] { "ConcurrencyStamp", "Email", "FirstName", "SecurityStamp" },
                values: new object[] { "1cd02c24-916c-4611-88ab-0a5f8af89d22", "kiet@gmail.com", "Kiệt", "8cad872b-8ad4-4d9f-bb91-c7c482f0f0dd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "424ab531-d60a-487e-9625-a74a7f5747be",
                columns: new[] { "ConcurrencyStamp", "Email", "FirstName", "SecurityStamp" },
                values: new object[] { "32b87f80-0d10-4f01-b46c-208ac4cd1474", "trieu@gmail.com", "Triệu", "fa3c507f-42a5-44b5-bfa5-70282584e3e0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "871a809a-b3fa-495b-9cc2-c5d738a866cf",
                columns: new[] { "ConcurrencyStamp", "Email", "FirstName", "SecurityStamp" },
                values: new object[] { "b9e4a863-1fbb-4f69-a210-bc76c699fd9d", "vinhtc191@gmail.com", "Trần", "86f85898-4ebd-4271-aff9-cb0eefacfc7f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1c48523-eee4-4151-9c82-23ebf8b0f762",
                columns: new[] { "ConcurrencyStamp", "Email", "FirstName", "SecurityStamp" },
                values: new object[] { "e8a347fb-2d80-4fb6-9de3-7246563cf8b4", "kien@gmail.com", "kiên", "f979ed8d-9611-47f0-bc7a-7770f6ad5de9" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("65191898-080f-4c24-b39a-653e57323400"),
                column: "Created",
                value: new DateTime(2024, 1, 29, 19, 8, 28, 830, DateTimeKind.Local).AddTicks(679));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("981c2b78-2662-4929-ab07-75e36d58e9bb"),
                column: "Created",
                value: new DateTime(2024, 1, 29, 19, 8, 28, 830, DateTimeKind.Local).AddTicks(686));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("cca90e51-b859-4830-8fcf-989163aaa4d9"),
                column: "Created",
                value: new DateTime(2024, 1, 29, 19, 8, 28, 830, DateTimeKind.Local).AddTicks(683));

            migrationBuilder.UpdateData(
                table: "InteractWithPosts",
                keyColumn: "Id",
                keyValue: new Guid("61291732-1599-46e4-93e2-01aa8fca3801"),
                column: "Created",
                value: new DateTime(2024, 1, 29, 19, 8, 28, 830, DateTimeKind.Local).AddTicks(716));

            migrationBuilder.UpdateData(
                table: "InteractWithPosts",
                keyColumn: "Id",
                keyValue: new Guid("795154a3-aa8a-4337-8f45-35529a400fd3"),
                column: "Created",
                value: new DateTime(2024, 1, 29, 19, 8, 28, 830, DateTimeKind.Local).AddTicks(723));

            migrationBuilder.UpdateData(
                table: "PackDetail",
                keyColumn: "Id",
                keyValue: new Guid("85ff8767-adac-4dfa-a49a-18c20d071c09"),
                column: "Created",
                value: new DateTime(2024, 1, 29, 19, 8, 28, 830, DateTimeKind.Local).AddTicks(788));

            migrationBuilder.UpdateData(
                table: "PackDetail",
                keyColumn: "Id",
                keyValue: new Guid("9ce9944f-8958-48bd-9e20-5ec5b7b283e9"),
                column: "Created",
                value: new DateTime(2024, 1, 29, 19, 8, 28, 830, DateTimeKind.Local).AddTicks(783));

            migrationBuilder.UpdateData(
                table: "Packs",
                keyColumn: "Id",
                keyValue: new Guid("8853faf2-87f1-4c17-8e20-7253720265be"),
                column: "Created",
                value: new DateTime(2024, 1, 29, 19, 8, 28, 830, DateTimeKind.Local).AddTicks(759));

            migrationBuilder.UpdateData(
                table: "Packs",
                keyColumn: "Id",
                keyValue: new Guid("8e5b48df-713e-4fe3-844b-8258c785ff7e"),
                column: "Created",
                value: new DateTime(2024, 1, 29, 19, 8, 28, 830, DateTimeKind.Local).AddTicks(749));

            migrationBuilder.UpdateData(
                table: "Packs",
                keyColumn: "Id",
                keyValue: new Guid("92b2fb8c-866c-445b-87b4-dc7bb3c828ac"),
                column: "Created",
                value: new DateTime(2024, 1, 29, 19, 8, 28, 830, DateTimeKind.Local).AddTicks(755));

            migrationBuilder.UpdateData(
                table: "Packs",
                keyColumn: "Id",
                keyValue: new Guid("e609e43f-b6ad-468e-91d1-785b282d345b"),
                column: "Created",
                value: new DateTime(2024, 1, 29, 19, 8, 28, 830, DateTimeKind.Local).AddTicks(752));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("94422c85-1d58-4f47-b5cb-a2794e757268"),
                column: "Created",
                value: new DateTime(2024, 1, 29, 19, 8, 28, 830, DateTimeKind.Local).AddTicks(969));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("d49773a8-6f63-4803-8c46-69f1349a5c20"),
                column: "Created",
                value: new DateTime(2024, 1, 29, 19, 8, 28, 830, DateTimeKind.Local).AddTicks(980));

            migrationBuilder.UpdateData(
                table: "PostTags",
                keyColumn: "Id",
                keyValue: new Guid("5d7deaf1-d72b-457e-bf56-877a89d37fac"),
                column: "Created",
                value: new DateTime(2024, 1, 29, 19, 8, 28, 830, DateTimeKind.Local).AddTicks(652));

            migrationBuilder.UpdateData(
                table: "PostTags",
                keyColumn: "Id",
                keyValue: new Guid("647b2bd5-ea1b-42a6-a92e-8263fb160754"),
                column: "Created",
                value: new DateTime(2024, 1, 29, 19, 8, 28, 830, DateTimeKind.Local).AddTicks(646));

            migrationBuilder.UpdateData(
                table: "PostTags",
                keyColumn: "Id",
                keyValue: new Guid("bcc26154-4ca0-4b51-808a-911bb4e09447"),
                column: "Created",
                value: new DateTime(2024, 1, 29, 19, 8, 28, 830, DateTimeKind.Local).AddTicks(655));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("14b76851-0f86-4dd2-a59c-ae45893c9578"),
                column: "Created",
                value: new DateTime(2024, 1, 29, 19, 8, 28, 830, DateTimeKind.Local).AddTicks(541));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("f2c5a3b4-8885-4673-8bcc-3702dbbae15d"),
                column: "Created",
                value: new DateTime(2024, 1, 29, 19, 8, 28, 830, DateTimeKind.Local).AddTicks(587));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("150b7aba-a76f-40b2-b7e5-19961bda108f"),
                column: "Created",
                value: new DateTime(2024, 1, 29, 19, 8, 28, 830, DateTimeKind.Local).AddTicks(613));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("2b3a61bf-1543-4e9f-900b-d4901be7e78c"),
                column: "Created",
                value: new DateTime(2024, 1, 29, 19, 8, 28, 830, DateTimeKind.Local).AddTicks(617));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("6598d9c2-ef4d-4295-a06a-e45a3cfc7b9d"),
                column: "Created",
                value: new DateTime(2024, 1, 29, 19, 8, 28, 830, DateTimeKind.Local).AddTicks(622));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("79a50b87-3bb3-4acc-b164-ef5795db17e3"),
                column: "Created",
                value: new DateTime(2024, 1, 29, 19, 8, 28, 830, DateTimeKind.Local).AddTicks(625));
        }
    }
}
