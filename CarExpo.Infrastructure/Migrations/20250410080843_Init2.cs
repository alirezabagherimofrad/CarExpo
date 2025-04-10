using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarExpo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("1c5ccaeb-1926-472b-8b74-4a57cfd38cee"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("26dbe990-c861-49f1-8e81-938a44985b25"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("323cf4f5-2d16-4876-ba5a-6b6e7ac25e4b"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("62c282d2-d94f-46fd-b2ad-425787274b7f"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("7643c421-5bf6-40b5-abb0-111bad1d4014"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("94b8b8ff-786d-47e2-a6f1-f91b83441744"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("9cbac66c-6f8e-43fa-954f-4a4e29c74fe9"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("9f5d1d3f-bd5d-4a49-8946-5d5f4b43326b"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("a05e4bba-15ce-403e-8f12-302c78d9eb9a"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("c2d61c82-73a0-4701-a608-06f27ec88f50"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("d6f32047-aed8-46cd-9db0-b76213e4e091"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("e60b9cda-45ea-460f-b2fe-e22be64527d4"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("ec746d11-62fc-4ce0-a2a9-f6ab0ec3bc2a"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Cars",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "TotalPrice",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("0ffd38c8-8c37-4aac-9290-de0d851c7b0c"), "ParsKhodro" },
                    { new Guid("2cfa960b-716e-4dd2-82ce-d9ede1cf165f"), "Hyundai" },
                    { new Guid("3d83986f-ce1e-4f2d-9e03-9ed62a72c630"), "Peugeot" },
                    { new Guid("416627c6-3da5-4448-b898-83e5c53d8faf"), "BahmanMotor" },
                    { new Guid("617ab0fa-d611-48b8-b073-48ee08a7de83"), "Brilliance" },
                    { new Guid("90c055bf-8564-43b9-bf0e-69fe504e2d79"), "Renault" },
                    { new Guid("9692f6a1-45ba-43fc-be3f-b93067cae72c"), "Chery" },
                    { new Guid("a28b2b58-d51d-493d-ad5a-1c7e851a11cd"), "JAC" },
                    { new Guid("d342fc33-a98a-41a8-9d0d-27aeabf540a7"), "Saipa" },
                    { new Guid("dd0e5d8f-40d1-4e14-8688-85393c36ba4e"), "Lifan" },
                    { new Guid("ea386698-1f97-462f-b4cb-9321b24b0f49"), "ModiranKhodro" },
                    { new Guid("fe16e726-2c52-44ac-a5db-e548d52db1c3"), "Kia" },
                    { new Guid("ffd844ba-3bf3-4490-9ccc-a9fb767fe7df"), "KermanMotor" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("0ffd38c8-8c37-4aac-9290-de0d851c7b0c"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("2cfa960b-716e-4dd2-82ce-d9ede1cf165f"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("3d83986f-ce1e-4f2d-9e03-9ed62a72c630"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("416627c6-3da5-4448-b898-83e5c53d8faf"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("617ab0fa-d611-48b8-b073-48ee08a7de83"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("90c055bf-8564-43b9-bf0e-69fe504e2d79"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("9692f6a1-45ba-43fc-be3f-b93067cae72c"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("a28b2b58-d51d-493d-ad5a-1c7e851a11cd"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("d342fc33-a98a-41a8-9d0d-27aeabf540a7"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("dd0e5d8f-40d1-4e14-8688-85393c36ba4e"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("ea386698-1f97-462f-b4cb-9321b24b0f49"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("fe16e726-2c52-44ac-a5db-e548d52db1c3"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("ffd844ba-3bf3-4490-9ccc-a9fb767fe7df"));

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Cars");

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("1c5ccaeb-1926-472b-8b74-4a57cfd38cee"), "KermanMotor" },
                    { new Guid("26dbe990-c861-49f1-8e81-938a44985b25"), "Renault" },
                    { new Guid("323cf4f5-2d16-4876-ba5a-6b6e7ac25e4b"), "ModiranKhodro" },
                    { new Guid("62c282d2-d94f-46fd-b2ad-425787274b7f"), "Chery" },
                    { new Guid("7643c421-5bf6-40b5-abb0-111bad1d4014"), "Hyundai" },
                    { new Guid("94b8b8ff-786d-47e2-a6f1-f91b83441744"), "ParsKhodro" },
                    { new Guid("9cbac66c-6f8e-43fa-954f-4a4e29c74fe9"), "JAC" },
                    { new Guid("9f5d1d3f-bd5d-4a49-8946-5d5f4b43326b"), "Saipa" },
                    { new Guid("a05e4bba-15ce-403e-8f12-302c78d9eb9a"), "Lifan" },
                    { new Guid("c2d61c82-73a0-4701-a608-06f27ec88f50"), "BahmanMotor" },
                    { new Guid("d6f32047-aed8-46cd-9db0-b76213e4e091"), "Peugeot" },
                    { new Guid("e60b9cda-45ea-460f-b2fe-e22be64527d4"), "Kia" },
                    { new Guid("ec746d11-62fc-4ce0-a2a9-f6ab0ec3bc2a"), "Brilliance" }
                });
        }
    }
}
