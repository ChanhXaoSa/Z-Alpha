using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZAlpha.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Question",
                table: "EntranceTests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCorrect",
                table: "AnswersForEntranceTests",
                type: "bit",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41d8778f-80e0-4dd5-b7db-86eb1c32d40d",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e915b49c-cdf6-4e54-a8c6-3bd80e6f0cc8", "5600cecb-893c-4535-936c-85bb7742345c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "424ab531-d60a-487e-9625-a74a7f5747be",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1ccff15e-f859-469f-aa11-d87dda07985f", "c83ff0bf-7339-4710-b580-607acf750879" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "871a809a-b3fa-495b-9cc2-c5d738a866cf",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f15856b6-5c4e-4096-a473-4bcae3a774a7", "d727e95c-8d1a-429a-bd97-7ffab4a3fd8d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1c48523-eee4-4151-9c82-23ebf8b0f762",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9c5843bb-a429-43a2-a17c-b3d775c6e096", "6d6e11e4-8c27-45d2-a9dd-b82314ba529a" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("65191898-080f-4c24-b39a-653e57323400"),
                column: "Created",
                value: new DateTime(2024, 2, 26, 21, 50, 43, 684, DateTimeKind.Local).AddTicks(254));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("981c2b78-2662-4929-ab07-75e36d58e9bb"),
                column: "Created",
                value: new DateTime(2024, 2, 26, 21, 50, 43, 684, DateTimeKind.Local).AddTicks(264));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("cca90e51-b859-4830-8fcf-989163aaa4d9"),
                column: "Created",
                value: new DateTime(2024, 2, 26, 21, 50, 43, 684, DateTimeKind.Local).AddTicks(259));

            migrationBuilder.UpdateData(
                table: "InteractWithPosts",
                keyColumn: "Id",
                keyValue: new Guid("61291732-1599-46e4-93e2-01aa8fca3801"),
                column: "Created",
                value: new DateTime(2024, 2, 26, 21, 50, 43, 684, DateTimeKind.Local).AddTicks(287));

            migrationBuilder.UpdateData(
                table: "InteractWithPosts",
                keyColumn: "Id",
                keyValue: new Guid("795154a3-aa8a-4337-8f45-35529a400fd3"),
                column: "Created",
                value: new DateTime(2024, 2, 26, 21, 50, 43, 684, DateTimeKind.Local).AddTicks(295));

            migrationBuilder.UpdateData(
                table: "PackDetail",
                keyColumn: "Id",
                keyValue: new Guid("85ff8767-adac-4dfa-a49a-18c20d071c09"),
                column: "Created",
                value: new DateTime(2024, 2, 26, 21, 50, 43, 684, DateTimeKind.Local).AddTicks(357));

            migrationBuilder.UpdateData(
                table: "PackDetail",
                keyColumn: "Id",
                keyValue: new Guid("9ce9944f-8958-48bd-9e20-5ec5b7b283e9"),
                column: "Created",
                value: new DateTime(2024, 2, 26, 21, 50, 43, 684, DateTimeKind.Local).AddTicks(349));

            migrationBuilder.UpdateData(
                table: "Packs",
                keyColumn: "Id",
                keyValue: new Guid("8853faf2-87f1-4c17-8e20-7253720265be"),
                column: "Created",
                value: new DateTime(2024, 2, 26, 21, 50, 43, 684, DateTimeKind.Local).AddTicks(327));

            migrationBuilder.UpdateData(
                table: "Packs",
                keyColumn: "Id",
                keyValue: new Guid("8e5b48df-713e-4fe3-844b-8258c785ff7e"),
                column: "Created",
                value: new DateTime(2024, 2, 26, 21, 50, 43, 684, DateTimeKind.Local).AddTicks(316));

            migrationBuilder.UpdateData(
                table: "Packs",
                keyColumn: "Id",
                keyValue: new Guid("92b2fb8c-866c-445b-87b4-dc7bb3c828ac"),
                column: "Created",
                value: new DateTime(2024, 2, 26, 21, 50, 43, 684, DateTimeKind.Local).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "Packs",
                keyColumn: "Id",
                keyValue: new Guid("e609e43f-b6ad-468e-91d1-785b282d345b"),
                column: "Created",
                value: new DateTime(2024, 2, 26, 21, 50, 43, 684, DateTimeKind.Local).AddTicks(321));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("94422c85-1d58-4f47-b5cb-a2794e757268"),
                column: "Created",
                value: new DateTime(2024, 2, 26, 21, 50, 43, 684, DateTimeKind.Local).AddTicks(469));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("d49773a8-6f63-4803-8c46-69f1349a5c20"),
                column: "Created",
                value: new DateTime(2024, 2, 26, 21, 50, 43, 684, DateTimeKind.Local).AddTicks(473));

            migrationBuilder.UpdateData(
                table: "PostTags",
                keyColumn: "Id",
                keyValue: new Guid("5d7deaf1-d72b-457e-bf56-877a89d37fac"),
                column: "Created",
                value: new DateTime(2024, 2, 26, 21, 50, 43, 684, DateTimeKind.Local).AddTicks(228));

            migrationBuilder.UpdateData(
                table: "PostTags",
                keyColumn: "Id",
                keyValue: new Guid("647b2bd5-ea1b-42a6-a92e-8263fb160754"),
                column: "Created",
                value: new DateTime(2024, 2, 26, 21, 50, 43, 684, DateTimeKind.Local).AddTicks(223));

            migrationBuilder.UpdateData(
                table: "PostTags",
                keyColumn: "Id",
                keyValue: new Guid("bcc26154-4ca0-4b51-808a-911bb4e09447"),
                column: "Created",
                value: new DateTime(2024, 2, 26, 21, 50, 43, 684, DateTimeKind.Local).AddTicks(231));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("14b76851-0f86-4dd2-a59c-ae45893c9578"),
                column: "Created",
                value: new DateTime(2024, 2, 26, 21, 50, 43, 684, DateTimeKind.Local).AddTicks(69));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("f2c5a3b4-8885-4673-8bcc-3702dbbae15d"),
                column: "Created",
                value: new DateTime(2024, 2, 26, 21, 50, 43, 684, DateTimeKind.Local).AddTicks(158));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("150b7aba-a76f-40b2-b7e5-19961bda108f"),
                column: "Created",
                value: new DateTime(2024, 2, 26, 21, 50, 43, 684, DateTimeKind.Local).AddTicks(186));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("2b3a61bf-1543-4e9f-900b-d4901be7e78c"),
                column: "Created",
                value: new DateTime(2024, 2, 26, 21, 50, 43, 684, DateTimeKind.Local).AddTicks(197));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("6598d9c2-ef4d-4295-a06a-e45a3cfc7b9d"),
                column: "Created",
                value: new DateTime(2024, 2, 26, 21, 50, 43, 684, DateTimeKind.Local).AddTicks(200));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("79a50b87-3bb3-4acc-b164-ef5795db17e3"),
                column: "Created",
                value: new DateTime(2024, 2, 26, 21, 50, 43, 684, DateTimeKind.Local).AddTicks(202));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Question",
                table: "EntranceTests");

            migrationBuilder.DropColumn(
                name: "IsCorrect",
                table: "AnswersForEntranceTests");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41d8778f-80e0-4dd5-b7db-86eb1c32d40d",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c51583e0-0568-46d9-8cb5-459949317d2f", "db3b2a2d-4f96-4a0e-b8b9-dd021290eea9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "424ab531-d60a-487e-9625-a74a7f5747be",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "83fe8067-f041-4c70-803a-0bbfe5ab49a5", "f642d871-f267-481f-9c75-fdb449873306" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "871a809a-b3fa-495b-9cc2-c5d738a866cf",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "bbfc36bf-f5fc-413f-a682-fa9715b47961", "32b60f1d-1ed3-4082-b9a8-cfa4b8f9827c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1c48523-eee4-4151-9c82-23ebf8b0f762",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "09b49cdd-64b0-423d-810d-2ad37faa5a04", "234120e2-f38c-4187-b189-9aca5060d8a1" });

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
    }
}
