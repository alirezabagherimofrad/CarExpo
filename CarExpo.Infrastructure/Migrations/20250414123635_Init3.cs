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
                keyValue: new Guid("0d691527-42d1-4c3f-bf4b-05fc19ffc798"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("137bf5f3-27ed-42a6-928c-9d5f9b0e4bd5"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("3b0f8480-d3a8-4f9e-82f2-6a53f12527ea"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("4169d5de-3848-4019-8d70-132dcb7df4c9"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("6331ba38-73d0-4e09-ac30-fc8f09976a0b"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("6e2f455b-39e3-4270-bfd8-4e2e4978587c"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("73117532-bd80-47e1-b6ff-96f051bc9e68"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("7d7554b0-6e02-46d9-bfc7-7f9b7f23e7ee"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("ca856877-f44f-45b9-9803-c9c64d8f1605"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("e530f976-55df-43ce-97d2-e2bc9c0d5c5c"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("f490ba25-8ff8-48da-a23d-3315dd24d6de"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("f5fd1e90-d515-4688-9bf8-147afa08da45"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("f802bd56-39bb-4e8c-b7ea-df7c4f5b9fec"));

            migrationBuilder.AddColumn<decimal>(
                name: "LoyaltyPoints",
                table: "payments",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "LoyaltyPoints",
                table: "AspNetUsers",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("0396016a-895f-4530-8d34-bfdd6bb8d730"), "Kia" },
                    { new Guid("180b6162-565e-4d83-a0fc-239019664f3b"), "BahmanMotor" },
                    { new Guid("1ec908f8-fc07-4910-b8f4-a219fa1ec86a"), "Saipa" },
                    { new Guid("26f35791-7562-4838-b5de-5a8c9c457ac4"), "Lifan" },
                    { new Guid("30a07769-6c57-4b07-8660-ee6d8495062a"), "Chery" },
                    { new Guid("3400bbfd-9806-42b2-a59e-55b645ab1710"), "Brilliance" },
                    { new Guid("4110fb46-9257-4327-b2bd-8b3da19c570e"), "Renault" },
                    { new Guid("49dc499b-f5e9-4598-83d4-78bdecf7821a"), "ModiranKhodro" },
                    { new Guid("4b398238-5aa5-4ba6-b32d-fa3b9b05f56c"), "Hyundai" },
                    { new Guid("90c33d3b-f5b6-425d-beec-971893e2b2c0"), "JAC" },
                    { new Guid("b23aaeb9-1b65-4987-be3c-69e416a70514"), "ParsKhodro" },
                    { new Guid("e7e93ccc-b2ee-46ee-9e3d-becc7639be64"), "KermanMotor" },
                    { new Guid("ea147952-b3e8-4c52-a783-6e0683c6b22f"), "Peugeot" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("0396016a-895f-4530-8d34-bfdd6bb8d730"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("180b6162-565e-4d83-a0fc-239019664f3b"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("1ec908f8-fc07-4910-b8f4-a219fa1ec86a"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("26f35791-7562-4838-b5de-5a8c9c457ac4"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("30a07769-6c57-4b07-8660-ee6d8495062a"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("3400bbfd-9806-42b2-a59e-55b645ab1710"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("4110fb46-9257-4327-b2bd-8b3da19c570e"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("49dc499b-f5e9-4598-83d4-78bdecf7821a"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("4b398238-5aa5-4ba6-b32d-fa3b9b05f56c"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("90c33d3b-f5b6-425d-beec-971893e2b2c0"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("b23aaeb9-1b65-4987-be3c-69e416a70514"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("e7e93ccc-b2ee-46ee-9e3d-becc7639be64"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("ea147952-b3e8-4c52-a783-6e0683c6b22f"));

            migrationBuilder.DropColumn(
                name: "LoyaltyPoints",
                table: "payments");

            migrationBuilder.DropColumn(
                name: "LoyaltyPoints",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("0d691527-42d1-4c3f-bf4b-05fc19ffc798"), "Hyundai" },
                    { new Guid("137bf5f3-27ed-42a6-928c-9d5f9b0e4bd5"), "Peugeot" },
                    { new Guid("3b0f8480-d3a8-4f9e-82f2-6a53f12527ea"), "ModiranKhodro" },
                    { new Guid("4169d5de-3848-4019-8d70-132dcb7df4c9"), "Brilliance" },
                    { new Guid("6331ba38-73d0-4e09-ac30-fc8f09976a0b"), "Renault" },
                    { new Guid("6e2f455b-39e3-4270-bfd8-4e2e4978587c"), "Lifan" },
                    { new Guid("73117532-bd80-47e1-b6ff-96f051bc9e68"), "Chery" },
                    { new Guid("7d7554b0-6e02-46d9-bfc7-7f9b7f23e7ee"), "JAC" },
                    { new Guid("ca856877-f44f-45b9-9803-c9c64d8f1605"), "BahmanMotor" },
                    { new Guid("e530f976-55df-43ce-97d2-e2bc9c0d5c5c"), "ParsKhodro" },
                    { new Guid("f490ba25-8ff8-48da-a23d-3315dd24d6de"), "Kia" },
                    { new Guid("f5fd1e90-d515-4688-9bf8-147afa08da45"), "KermanMotor" },
                    { new Guid("f802bd56-39bb-4e8c-b7ea-df7c4f5b9fec"), "Saipa" }
                });
        }
    }
}
