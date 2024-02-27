using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ZAlpha.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seeddingdatacauhoi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EntranceTests",
                columns: new[] { "Id", "Created", "CreatedBy", "IsDeleted", "LastModified", "LastModifiedBy", "Question" },
                values: new object[,]
                {
                    { new Guid("6295c6b7-fdf6-4245-810f-89d61226f341"), new DateTime(2024, 2, 27, 15, 56, 28, 54, DateTimeKind.Local).AddTicks(9872), null, false, null, null, "Mức độ lo âu của bạn như thế nào?" },
                    { new Guid("6295c6b7-fdf6-4245-810f-89d61226f342"), new DateTime(2024, 2, 27, 15, 56, 28, 54, DateTimeKind.Local).AddTicks(9875), null, false, null, null, "Nếu bạn đang lo âu, có thể chia sẻ nó với chúng tôi không ?" },
                    { new Guid("6295c6b7-fdf6-4245-810f-89d61226f343"), new DateTime(2024, 2, 27, 15, 56, 28, 54, DateTimeKind.Local).AddTicks(9879), null, false, null, null, "Bạn có cảm thấy hài lòng với các mối quan hệ xã hội của mình? " },
                    { new Guid("6295c6b7-fdf6-4245-810f-89d61226f344"), new DateTime(2024, 2, 27, 15, 56, 28, 54, DateTimeKind.Local).AddTicks(9883), null, false, null, null, "Những điều bạn thường làm là gì ?" }
                });

            migrationBuilder.UpdateData(
                table: "Packs",
                keyColumn: "Id",
                keyValue: new Guid("8853faf2-87f1-4c17-8e20-7253720265be"),
                column: "Created",
                value: new DateTime(2024, 2, 27, 15, 56, 28, 54, DateTimeKind.Local).AddTicks(9916));

            migrationBuilder.UpdateData(
                table: "Packs",
                keyColumn: "Id",
                keyValue: new Guid("8e5b48df-713e-4fe3-844b-8258c785ff7e"),
                column: "Created",
                value: new DateTime(2024, 2, 27, 15, 56, 28, 54, DateTimeKind.Local).AddTicks(9907));

            migrationBuilder.UpdateData(
                table: "Packs",
                keyColumn: "Id",
                keyValue: new Guid("92b2fb8c-866c-445b-87b4-dc7bb3c828ac"),
                column: "Created",
                value: new DateTime(2024, 2, 27, 15, 56, 28, 54, DateTimeKind.Local).AddTicks(9914));

            migrationBuilder.UpdateData(
                table: "Packs",
                keyColumn: "Id",
                keyValue: new Guid("e609e43f-b6ad-468e-91d1-785b282d345b"),
                column: "Created",
                value: new DateTime(2024, 2, 27, 15, 56, 28, 54, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("94422c85-1d58-4f47-b5cb-a2794e757268"),
                column: "Created",
                value: new DateTime(2024, 2, 27, 15, 56, 28, 54, DateTimeKind.Local).AddTicks(9941));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("d49773a8-6f63-4803-8c46-69f1349a5c20"),
                column: "Created",
                value: new DateTime(2024, 2, 27, 15, 56, 28, 54, DateTimeKind.Local).AddTicks(9944));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("150b7aba-a76f-40b2-b7e5-19961bda108f"),
                column: "Created",
                value: new DateTime(2024, 2, 27, 15, 56, 28, 54, DateTimeKind.Local).AddTicks(9672));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("2b3a61bf-1543-4e9f-900b-d4901be7e78c"),
                column: "Created",
                value: new DateTime(2024, 2, 27, 15, 56, 28, 54, DateTimeKind.Local).AddTicks(9701));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("6598d9c2-ef4d-4295-a06a-e45a3cfc7b9d"),
                column: "Created",
                value: new DateTime(2024, 2, 27, 15, 56, 28, 54, DateTimeKind.Local).AddTicks(9704));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("79a50b87-3bb3-4acc-b164-ef5795db17e3"),
                column: "Created",
                value: new DateTime(2024, 2, 27, 15, 56, 28, 54, DateTimeKind.Local).AddTicks(9707));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EntranceTests",
                keyColumn: "Id",
                keyValue: new Guid("6295c6b7-fdf6-4245-810f-89d61226f341"));

            migrationBuilder.DeleteData(
                table: "EntranceTests",
                keyColumn: "Id",
                keyValue: new Guid("6295c6b7-fdf6-4245-810f-89d61226f342"));

            migrationBuilder.DeleteData(
                table: "EntranceTests",
                keyColumn: "Id",
                keyValue: new Guid("6295c6b7-fdf6-4245-810f-89d61226f343"));

            migrationBuilder.DeleteData(
                table: "EntranceTests",
                keyColumn: "Id",
                keyValue: new Guid("6295c6b7-fdf6-4245-810f-89d61226f344"));

            migrationBuilder.UpdateData(
                table: "Packs",
                keyColumn: "Id",
                keyValue: new Guid("8853faf2-87f1-4c17-8e20-7253720265be"),
                column: "Created",
                value: new DateTime(2024, 2, 27, 13, 53, 44, 40, DateTimeKind.Local).AddTicks(6228));

            migrationBuilder.UpdateData(
                table: "Packs",
                keyColumn: "Id",
                keyValue: new Guid("8e5b48df-713e-4fe3-844b-8258c785ff7e"),
                column: "Created",
                value: new DateTime(2024, 2, 27, 13, 53, 44, 40, DateTimeKind.Local).AddTicks(6192));

            migrationBuilder.UpdateData(
                table: "Packs",
                keyColumn: "Id",
                keyValue: new Guid("92b2fb8c-866c-445b-87b4-dc7bb3c828ac"),
                column: "Created",
                value: new DateTime(2024, 2, 27, 13, 53, 44, 40, DateTimeKind.Local).AddTicks(6223));

            migrationBuilder.UpdateData(
                table: "Packs",
                keyColumn: "Id",
                keyValue: new Guid("e609e43f-b6ad-468e-91d1-785b282d345b"),
                column: "Created",
                value: new DateTime(2024, 2, 27, 13, 53, 44, 40, DateTimeKind.Local).AddTicks(6203));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("94422c85-1d58-4f47-b5cb-a2794e757268"),
                column: "Created",
                value: new DateTime(2024, 2, 27, 13, 53, 44, 40, DateTimeKind.Local).AddTicks(6292));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("d49773a8-6f63-4803-8c46-69f1349a5c20"),
                column: "Created",
                value: new DateTime(2024, 2, 27, 13, 53, 44, 40, DateTimeKind.Local).AddTicks(6302));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("150b7aba-a76f-40b2-b7e5-19961bda108f"),
                column: "Created",
                value: new DateTime(2024, 2, 27, 13, 53, 44, 40, DateTimeKind.Local).AddTicks(5572));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("2b3a61bf-1543-4e9f-900b-d4901be7e78c"),
                column: "Created",
                value: new DateTime(2024, 2, 27, 13, 53, 44, 40, DateTimeKind.Local).AddTicks(5625));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("6598d9c2-ef4d-4295-a06a-e45a3cfc7b9d"),
                column: "Created",
                value: new DateTime(2024, 2, 27, 13, 53, 44, 40, DateTimeKind.Local).AddTicks(5644));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("79a50b87-3bb3-4acc-b164-ef5795db17e3"),
                column: "Created",
                value: new DateTime(2024, 2, 27, 13, 53, 44, 40, DateTimeKind.Local).AddTicks(5649));
        }
    }
}
