using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_commorec.infrastructuer.Data.Migrations
{
    /// <inheritdoc />
    public partial class tesst : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("73db973c-bdb6-49a1-ab8b-0792a807e015"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("9acb4169-7651-4301-89aa-71edbcc42c6b"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("f10acaa5-455a-4fd1-bcc9-63f5b7720bf4"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("473f31d9-abd6-4cc4-ab60-deb1b8aee383"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("f3f6e41e-5738-49ec-b2e6-1f2fedda010a"));

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Email", "FirstTimeRegister", "Gender", "Image", "Name", "Phone", "Study", "TypeCourse" },
                values: new object[,]
                {
                    { new Guid("521e05c2-0fba-4526-987c-981205f6d848"), "test31@gmail.com", new DateTime(2024, 9, 5, 15, 52, 47, 920, DateTimeKind.Local).AddTicks(8834), 0, null, "asdgf", "123123", "", "[\"utyy\"]" },
                    { new Guid("8f6924a8-98fb-4c66-b4a3-542db0b7b3ef"), "test1@gmail.com", new DateTime(2024, 9, 5, 15, 52, 47, 920, DateTimeKind.Local).AddTicks(7381), 0, null, "sadwa", "098", "", "[\"test\"]" },
                    { new Guid("b0643f5f-4c85-45b6-92e2-020a2eab9ec7"), "test2@gmail.com", new DateTime(2024, 9, 5, 15, 52, 47, 920, DateTimeKind.Local).AddTicks(8839), 0, null, ",bvbnbn", "098", "", "[\"teghjst\"]" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Email", "FirstTimeRegister", "Gender", "Image", "LevelOfStudy", "Name", "Phone", "Position", "TimeToResign" },
                values: new object[,]
                {
                    { new Guid("e2f4fd3b-d43b-41c6-819c-2ed3e4a92593"), "test2@gmail.com", new DateTime(2024, 9, 5, 15, 52, 47, 922, DateTimeKind.Local).AddTicks(1266), 0, null, "str2ing", "s1adwa", "0981", "s3tro", new DateTime(2024, 9, 5, 15, 52, 47, 922, DateTimeKind.Local).AddTicks(1269) },
                    { new Guid("fd82fa67-ce3b-426f-ae29-83fbb9dc15c0"), "test1@gmail.com", new DateTime(2024, 9, 5, 15, 52, 47, 921, DateTimeKind.Local).AddTicks(9886), 0, null, "string", "sadwa", "098", "stro", new DateTime(2024, 9, 5, 15, 52, 47, 922, DateTimeKind.Local).AddTicks(1033) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("521e05c2-0fba-4526-987c-981205f6d848"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("8f6924a8-98fb-4c66-b4a3-542db0b7b3ef"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("b0643f5f-4c85-45b6-92e2-020a2eab9ec7"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("e2f4fd3b-d43b-41c6-819c-2ed3e4a92593"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("fd82fa67-ce3b-426f-ae29-83fbb9dc15c0"));

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
    }
}
