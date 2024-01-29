using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ZAlpha.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatetransactionstatusseeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41d8778f-80e0-4dd5-b7db-86eb1c32d40d",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1cd02c24-916c-4611-88ab-0a5f8af89d22", "8cad872b-8ad4-4d9f-bb91-c7c482f0f0dd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "424ab531-d60a-487e-9625-a74a7f5747be",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "32b87f80-0d10-4f01-b46c-208ac4cd1474", "fa3c507f-42a5-44b5-bfa5-70282584e3e0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "871a809a-b3fa-495b-9cc2-c5d738a866cf",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b9e4a863-1fbb-4f69-a210-bc76c699fd9d", "86f85898-4ebd-4271-aff9-cb0eefacfc7f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1c48523-eee4-4151-9c82-23ebf8b0f762",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e8a347fb-2d80-4fb6-9de3-7246563cf8b4", "f979ed8d-9611-47f0-bc7a-7770f6ad5de9" });

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

            migrationBuilder.InsertData(
                table: "PaymentMethods",
                columns: new[] { "Id", "Created", "CreatedBy", "IsDeleted", "LastModified", "LastModifiedBy", "PaymentMethodName", "PaymentMethodStatus" },
                values: new object[,]
                {
                    { new Guid("94422c85-1d58-4f47-b5cb-a2794e757268"), new DateTime(2024, 1, 29, 19, 8, 28, 830, DateTimeKind.Local).AddTicks(969), null, false, null, null, "VNPay", 1 },
                    { new Guid("d49773a8-6f63-4803-8c46-69f1349a5c20"), new DateTime(2024, 1, 29, 19, 8, 28, 830, DateTimeKind.Local).AddTicks(980), null, false, null, null, "MoMo", 0 }
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("94422c85-1d58-4f47-b5cb-a2794e757268"));

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("d49773a8-6f63-4803-8c46-69f1349a5c20"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41d8778f-80e0-4dd5-b7db-86eb1c32d40d",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "cb009467-740b-4516-bbd1-e9c006a55b1b", "ff094f42-6424-4df8-bbad-c704704e7b14" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "424ab531-d60a-487e-9625-a74a7f5747be",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "34a1d1f0-3fec-4c74-98ce-0086ae436500", "7bd4f1c6-5e64-4d69-a80d-43b2e6a6cc47" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "871a809a-b3fa-495b-9cc2-c5d738a866cf",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "81992343-1a3e-4d45-b83f-fe7d62d1f19b", "492e3522-1d4b-4163-9b76-f92608cc7b5c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1c48523-eee4-4151-9c82-23ebf8b0f762",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a470a92a-ebc7-4771-8b5c-f92c968fbd02", "f4e0488c-b9e6-4317-8ffd-48414dff2ca5" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("65191898-080f-4c24-b39a-653e57323400"),
                column: "Created",
                value: new DateTime(2024, 1, 29, 18, 59, 25, 895, DateTimeKind.Local).AddTicks(2778));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("981c2b78-2662-4929-ab07-75e36d58e9bb"),
                column: "Created",
                value: new DateTime(2024, 1, 29, 18, 59, 25, 895, DateTimeKind.Local).AddTicks(2785));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("cca90e51-b859-4830-8fcf-989163aaa4d9"),
                column: "Created",
                value: new DateTime(2024, 1, 29, 18, 59, 25, 895, DateTimeKind.Local).AddTicks(2783));

            migrationBuilder.UpdateData(
                table: "InteractWithPosts",
                keyColumn: "Id",
                keyValue: new Guid("61291732-1599-46e4-93e2-01aa8fca3801"),
                column: "Created",
                value: new DateTime(2024, 1, 29, 18, 59, 25, 895, DateTimeKind.Local).AddTicks(2808));

            migrationBuilder.UpdateData(
                table: "InteractWithPosts",
                keyColumn: "Id",
                keyValue: new Guid("795154a3-aa8a-4337-8f45-35529a400fd3"),
                column: "Created",
                value: new DateTime(2024, 1, 29, 18, 59, 25, 895, DateTimeKind.Local).AddTicks(2813));

            migrationBuilder.UpdateData(
                table: "PackDetail",
                keyColumn: "Id",
                keyValue: new Guid("85ff8767-adac-4dfa-a49a-18c20d071c09"),
                column: "Created",
                value: new DateTime(2024, 1, 29, 18, 59, 25, 895, DateTimeKind.Local).AddTicks(2877));

            migrationBuilder.UpdateData(
                table: "PackDetail",
                keyColumn: "Id",
                keyValue: new Guid("9ce9944f-8958-48bd-9e20-5ec5b7b283e9"),
                column: "Created",
                value: new DateTime(2024, 1, 29, 18, 59, 25, 895, DateTimeKind.Local).AddTicks(2873));

            migrationBuilder.UpdateData(
                table: "Packs",
                keyColumn: "Id",
                keyValue: new Guid("8853faf2-87f1-4c17-8e20-7253720265be"),
                column: "Created",
                value: new DateTime(2024, 1, 29, 18, 59, 25, 895, DateTimeKind.Local).AddTicks(2852));

            migrationBuilder.UpdateData(
                table: "Packs",
                keyColumn: "Id",
                keyValue: new Guid("8e5b48df-713e-4fe3-844b-8258c785ff7e"),
                column: "Created",
                value: new DateTime(2024, 1, 29, 18, 59, 25, 895, DateTimeKind.Local).AddTicks(2829));

            migrationBuilder.UpdateData(
                table: "Packs",
                keyColumn: "Id",
                keyValue: new Guid("92b2fb8c-866c-445b-87b4-dc7bb3c828ac"),
                column: "Created",
                value: new DateTime(2024, 1, 29, 18, 59, 25, 895, DateTimeKind.Local).AddTicks(2837));

            migrationBuilder.UpdateData(
                table: "Packs",
                keyColumn: "Id",
                keyValue: new Guid("e609e43f-b6ad-468e-91d1-785b282d345b"),
                column: "Created",
                value: new DateTime(2024, 1, 29, 18, 59, 25, 895, DateTimeKind.Local).AddTicks(2835));

            migrationBuilder.UpdateData(
                table: "PostTags",
                keyColumn: "Id",
                keyValue: new Guid("5d7deaf1-d72b-457e-bf56-877a89d37fac"),
                column: "Created",
                value: new DateTime(2024, 1, 29, 18, 59, 25, 895, DateTimeKind.Local).AddTicks(2753));

            migrationBuilder.UpdateData(
                table: "PostTags",
                keyColumn: "Id",
                keyValue: new Guid("647b2bd5-ea1b-42a6-a92e-8263fb160754"),
                column: "Created",
                value: new DateTime(2024, 1, 29, 18, 59, 25, 895, DateTimeKind.Local).AddTicks(2749));

            migrationBuilder.UpdateData(
                table: "PostTags",
                keyColumn: "Id",
                keyValue: new Guid("bcc26154-4ca0-4b51-808a-911bb4e09447"),
                column: "Created",
                value: new DateTime(2024, 1, 29, 18, 59, 25, 895, DateTimeKind.Local).AddTicks(2756));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("14b76851-0f86-4dd2-a59c-ae45893c9578"),
                column: "Created",
                value: new DateTime(2024, 1, 29, 18, 59, 25, 895, DateTimeKind.Local).AddTicks(2660));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("f2c5a3b4-8885-4673-8bcc-3702dbbae15d"),
                column: "Created",
                value: new DateTime(2024, 1, 29, 18, 59, 25, 895, DateTimeKind.Local).AddTicks(2696));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("150b7aba-a76f-40b2-b7e5-19961bda108f"),
                column: "Created",
                value: new DateTime(2024, 1, 29, 18, 59, 25, 895, DateTimeKind.Local).AddTicks(2721));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("2b3a61bf-1543-4e9f-900b-d4901be7e78c"),
                column: "Created",
                value: new DateTime(2024, 1, 29, 18, 59, 25, 895, DateTimeKind.Local).AddTicks(2725));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("6598d9c2-ef4d-4295-a06a-e45a3cfc7b9d"),
                column: "Created",
                value: new DateTime(2024, 1, 29, 18, 59, 25, 895, DateTimeKind.Local).AddTicks(2728));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("79a50b87-3bb3-4acc-b164-ef5795db17e3"),
                column: "Created",
                value: new DateTime(2024, 1, 29, 18, 59, 25, 895, DateTimeKind.Local).AddTicks(2730));
        }
    }
}
