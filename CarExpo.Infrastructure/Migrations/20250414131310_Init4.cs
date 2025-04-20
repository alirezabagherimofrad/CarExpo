using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarExpo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "loyaltyaStatus",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("07ac3e52-9167-4b73-8186-9218732bc32b"), "Renault" },
                    { new Guid("1492a5da-950c-4f02-b815-6483a1f539ed"), "BahmanMotor" },
                    { new Guid("255e8e99-f250-40ac-940e-52f681e9ed68"), "Kia" },
                    { new Guid("32ec2245-3685-4e31-9b56-c1970260f17c"), "Brilliance" },
                    { new Guid("33746266-71ec-4b33-bc96-4cf4adda63e2"), "Saipa" },
                    { new Guid("6155964e-8cc5-42ea-8f61-461f6fa789a2"), "Hyundai" },
                    { new Guid("72ec7442-f9fa-4733-9536-855d4e03cbe3"), "Lifan" },
                    { new Guid("7e11e08d-42cc-4ef9-8d0b-2cd9655334a2"), "KermanMotor" },
                    { new Guid("a0d03e5c-bf6c-4ca3-88a0-78834037de8a"), "ModiranKhodro" },
                    { new Guid("b697fc0e-c4a2-42f4-919e-e77a9c8ef435"), "Peugeot" },
                    { new Guid("b8cf3555-dce0-41d9-8539-6d8bec4da869"), "Chery" },
                    { new Guid("eb6c97c2-34d5-4980-acad-691a67d9159b"), "JAC" },
                    { new Guid("f3ab961c-d080-4a93-ac81-49d2aacd7587"), "ParsKhodro" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("07ac3e52-9167-4b73-8186-9218732bc32b"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("1492a5da-950c-4f02-b815-6483a1f539ed"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("255e8e99-f250-40ac-940e-52f681e9ed68"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("32ec2245-3685-4e31-9b56-c1970260f17c"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("33746266-71ec-4b33-bc96-4cf4adda63e2"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("6155964e-8cc5-42ea-8f61-461f6fa789a2"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("72ec7442-f9fa-4733-9536-855d4e03cbe3"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("7e11e08d-42cc-4ef9-8d0b-2cd9655334a2"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("a0d03e5c-bf6c-4ca3-88a0-78834037de8a"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("b697fc0e-c4a2-42f4-919e-e77a9c8ef435"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("b8cf3555-dce0-41d9-8539-6d8bec4da869"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("eb6c97c2-34d5-4980-acad-691a67d9159b"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("f3ab961c-d080-4a93-ac81-49d2aacd7587"));

            migrationBuilder.DropColumn(
                name: "loyaltyaStatus",
                table: "AspNetUsers");

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
    }
}
