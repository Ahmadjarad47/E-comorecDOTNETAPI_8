using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_commorec.infrastructuer.Data.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("6863a2f9-42d8-4a33-82c7-da3c3c76ee32"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("73bd0ebf-fb90-4c56-98c4-66a25de2394b"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("bd2a9f06-fbcd-42e7-8aa3-450596e42e5b"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("ba0cf0e2-b4b0-4801-b7b3-458405d2bccd"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("ec045839-b1fb-436c-9d9b-37e8df6ecff0"));

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Email", "FirstTimeRegister", "Gender", "Image", "Name", "Phone", "Study", "TypeCourse" },
                values: new object[,]
                {
                    { new Guid("73db973c-bdb6-49a1-ab8b-0792a807e015"), "test2@gmail.com", new DateTime(2024, 9, 5, 15, 51, 52, 864, DateTimeKind.Local).AddTicks(5202), 0, null, ",bvbnbn", "098", "", "[\"teghjst\"]" },
                    { new Guid("9acb4169-7651-4301-89aa-71edbcc42c6b"), "test1@gmail.com", new DateTime(2024, 9, 5, 15, 51, 52, 864, DateTimeKind.Local).AddTicks(4055), 0, null, "sadwa", "098", "", "[\"test\"]" },
                    { new Guid("f10acaa5-455a-4fd1-bcc9-63f5b7720bf4"), "test31@gmail.com", new DateTime(2024, 9, 5, 15, 51, 52, 864, DateTimeKind.Local).AddTicks(5195), 0, null, "asdgf", "123123", "", "[\"utyy\"]" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Email", "FirstTimeRegister", "Gender", "Image", "LevelOfStudy", "Name", "Phone", "Position", "TimeToResign" },
                values: new object[,]
                {
                    { new Guid("473f31d9-abd6-4cc4-ab60-deb1b8aee383"), "test2@gmail.com", new DateTime(2024, 9, 5, 15, 51, 52, 865, DateTimeKind.Local).AddTicks(7085), 0, null, "str2ing", "s1adwa", "0981", "s3tro", new DateTime(2024, 9, 5, 15, 51, 52, 865, DateTimeKind.Local).AddTicks(7089) },
                    { new Guid("f3f6e41e-5738-49ec-b2e6-1f2fedda010a"), "test1@gmail.com", new DateTime(2024, 9, 5, 15, 51, 52, 865, DateTimeKind.Local).AddTicks(5788), 0, null, "string", "sadwa", "098", "stro", new DateTime(2024, 9, 5, 15, 51, 52, 865, DateTimeKind.Local).AddTicks(6859) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
