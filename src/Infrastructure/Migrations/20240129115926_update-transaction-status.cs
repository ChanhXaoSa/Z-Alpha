using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZAlpha.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatetransactionstatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Transactions");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41d8778f-80e0-4dd5-b7db-86eb1c32d40d",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a66eeaf6-c59d-4e2c-8a72-5c79bf5be965", "713150f0-4b2d-4227-8190-15b82c2355dd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "424ab531-d60a-487e-9625-a74a7f5747be",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "030fb24f-140a-4ee3-99b6-65b81724d7cc", "f0128319-b21e-4493-b737-4744ec58453f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "871a809a-b3fa-495b-9cc2-c5d738a866cf",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9e624d3a-e8fe-46cf-93c9-d6613d744d65", "fd69beeb-df33-45d2-aa5f-7206cb0a7f8a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1c48523-eee4-4151-9c82-23ebf8b0f762",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "38b28065-d3e1-4fe9-b816-b2cfc4612e01", "6f831d3f-b8f6-4520-bdc4-cfb1c0052c3b" });

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

            migrationBuilder.UpdateData(
                table: "PackDetail",
                keyColumn: "Id",
                keyValue: new Guid("85ff8767-adac-4dfa-a49a-18c20d071c09"),
                column: "Created",
                value: new DateTime(2024, 1, 28, 0, 57, 11, 137, DateTimeKind.Local).AddTicks(2896));

            migrationBuilder.UpdateData(
                table: "PackDetail",
                keyColumn: "Id",
                keyValue: new Guid("9ce9944f-8958-48bd-9e20-5ec5b7b283e9"),
                column: "Created",
                value: new DateTime(2024, 1, 28, 0, 57, 11, 137, DateTimeKind.Local).AddTicks(2892));

            migrationBuilder.UpdateData(
                table: "Packs",
                keyColumn: "Id",
                keyValue: new Guid("8853faf2-87f1-4c17-8e20-7253720265be"),
                column: "Created",
                value: new DateTime(2024, 1, 28, 0, 57, 11, 137, DateTimeKind.Local).AddTicks(2878));

            migrationBuilder.UpdateData(
                table: "Packs",
                keyColumn: "Id",
                keyValue: new Guid("8e5b48df-713e-4fe3-844b-8258c785ff7e"),
                column: "Created",
                value: new DateTime(2024, 1, 28, 0, 57, 11, 137, DateTimeKind.Local).AddTicks(2869));

            migrationBuilder.UpdateData(
                table: "Packs",
                keyColumn: "Id",
                keyValue: new Guid("92b2fb8c-866c-445b-87b4-dc7bb3c828ac"),
                column: "Created",
                value: new DateTime(2024, 1, 28, 0, 57, 11, 137, DateTimeKind.Local).AddTicks(2875));

            migrationBuilder.UpdateData(
                table: "Packs",
                keyColumn: "Id",
                keyValue: new Guid("e609e43f-b6ad-468e-91d1-785b282d345b"),
                column: "Created",
                value: new DateTime(2024, 1, 28, 0, 57, 11, 137, DateTimeKind.Local).AddTicks(2873));

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
        }
    }
}
