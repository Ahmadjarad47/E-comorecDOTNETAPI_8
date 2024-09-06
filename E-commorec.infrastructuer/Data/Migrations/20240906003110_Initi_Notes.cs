using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_commorec.infrastructuer.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initi_Notes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Notes");

            migrationBuilder.AddColumn<bool>(
                name: "ReadOrNot",
                table: "Notes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "WhenHeRead",
                table: "Notes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Email", "FirstTimeRegister", "Gender", "Image", "Name", "Phone", "Study", "TypeCourse" },
                values: new object[,]
                {
                    { new Guid("30f65820-4a8d-4b4c-a450-c79c1e9a3b65"), "test2@gmail.com", new DateTime(2024, 9, 5, 16, 31, 10, 12, DateTimeKind.Local).AddTicks(7410), 0, null, ",bvbnbn", "098", "", "[\"teghjst\"]" },
                    { new Guid("368fc96d-31e0-4f8e-95b3-a63db1ea8980"), "test31@gmail.com", new DateTime(2024, 9, 5, 16, 31, 10, 12, DateTimeKind.Local).AddTicks(7387), 0, null, "asdgf", "123123", "", "[\"utyy\"]" },
                    { new Guid("f71f6768-639d-40e0-a053-f8d4ae7c9bde"), "test1@gmail.com", new DateTime(2024, 9, 5, 16, 31, 10, 12, DateTimeKind.Local).AddTicks(4609), 0, null, "sadwa", "098", "", "[\"test\"]" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Email", "FirstTimeRegister", "Gender", "Image", "LevelOfStudy", "Name", "Phone", "Position", "TimeToResign" },
                values: new object[,]
                {
                    { new Guid("cd77bce1-03d9-4731-8e51-43768ba60f01"), "test2@gmail.com", new DateTime(2024, 9, 5, 16, 31, 10, 14, DateTimeKind.Local).AddTicks(24), 0, null, "str2ing", "s1adwa", "0981", "s3tro", new DateTime(2024, 9, 5, 16, 31, 10, 14, DateTimeKind.Local).AddTicks(27) },
                    { new Guid("fd25f0e6-cca6-4554-a95b-a6d378f4a3ff"), "test1@gmail.com", new DateTime(2024, 9, 5, 16, 31, 10, 13, DateTimeKind.Local).AddTicks(8686), 0, null, "string", "sadwa", "098", "stro", new DateTime(2024, 9, 5, 16, 31, 10, 13, DateTimeKind.Local).AddTicks(9798) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("30f65820-4a8d-4b4c-a450-c79c1e9a3b65"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("368fc96d-31e0-4f8e-95b3-a63db1ea8980"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("f71f6768-639d-40e0-a053-f8d4ae7c9bde"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("cd77bce1-03d9-4731-8e51-43768ba60f01"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("fd25f0e6-cca6-4554-a95b-a6d378f4a3ff"));

            migrationBuilder.DropColumn(
                name: "ReadOrNot",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "WhenHeRead",
                table: "Notes");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Notes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
    }
}
