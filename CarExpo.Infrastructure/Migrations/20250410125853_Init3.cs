using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarExpo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrederId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItem_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("1956f132-4c63-47e1-8c71-b359c1db7369"), "Saipa" },
                    { new Guid("27e73a5e-1b0e-4df2-a48c-47921584f49f"), "Brilliance" },
                    { new Guid("3d8fbba8-ea94-4f22-8151-bc4773edbef9"), "ParsKhodro" },
                    { new Guid("510adcb7-cdc6-4a00-b754-40dd00c96db6"), "Peugeot" },
                    { new Guid("52d18654-4e99-4577-896a-5bc105153979"), "Lifan" },
                    { new Guid("6f3fbfbb-cb9d-4c3d-920a-cac91b4a54ca"), "KermanMotor" },
                    { new Guid("7f55acec-da5a-4fc2-aa00-5ead95be5ac9"), "Kia" },
                    { new Guid("7fc68c83-8dfa-40f9-8c3b-c90b240e0bb7"), "Chery" },
                    { new Guid("86f4cf4e-aa51-4d7f-9731-f06ad7a5a4e7"), "JAC" },
                    { new Guid("b1875e70-9405-4ffc-ab05-76f026d15fe7"), "Hyundai" },
                    { new Guid("baa04ca7-e4aa-4d0a-8e9e-54e170830dfa"), "ModiranKhodro" },
                    { new Guid("d0632efd-5839-49b8-a740-2014bd35030c"), "BahmanMotor" },
                    { new Guid("e4c63fa9-30a5-4cda-9cb4-711f64d1c176"), "Renault" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("1956f132-4c63-47e1-8c71-b359c1db7369"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("27e73a5e-1b0e-4df2-a48c-47921584f49f"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("3d8fbba8-ea94-4f22-8151-bc4773edbef9"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("510adcb7-cdc6-4a00-b754-40dd00c96db6"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("52d18654-4e99-4577-896a-5bc105153979"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("6f3fbfbb-cb9d-4c3d-920a-cac91b4a54ca"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("7f55acec-da5a-4fc2-aa00-5ead95be5ac9"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("7fc68c83-8dfa-40f9-8c3b-c90b240e0bb7"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("86f4cf4e-aa51-4d7f-9731-f06ad7a5a4e7"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("b1875e70-9405-4ffc-ab05-76f026d15fe7"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("baa04ca7-e4aa-4d0a-8e9e-54e170830dfa"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("d0632efd-5839-49b8-a740-2014bd35030c"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("e4c63fa9-30a5-4cda-9cb4-711f64d1c176"));

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
    }
}
