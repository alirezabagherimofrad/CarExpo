using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarExpo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "loyaltyaStatus",
                table: "AspNetUsers",
                newName: "LoyaltyStatus");

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("32eefa2b-f9f3-4921-a511-e2b12e814ae8"), "Hyundai" },
                    { new Guid("4076eba5-48fa-4e12-b646-f6ccb7a058f4"), "Lifan" },
                    { new Guid("4611a07f-2ce1-4abd-a3dd-faceb4db0f3e"), "Brilliance" },
                    { new Guid("49041879-a332-4233-a0b9-28743647f2fe"), "Kia" },
                    { new Guid("503546f4-7178-4173-aaa4-1994b8af9724"), "JAC" },
                    { new Guid("581f92b2-e275-48ae-bf7b-c20cfa58987c"), "ParsKhodro" },
                    { new Guid("6f57d6a7-fa47-469f-9881-2b3ec2e54abf"), "BahmanMotor" },
                    { new Guid("a21321e2-6005-4de7-a8ed-72cc7d2c6275"), "ModiranKhodro" },
                    { new Guid("a72d863f-0909-4500-90d3-72171fe97872"), "Peugeot" },
                    { new Guid("b2b0954e-c727-46fe-a6c1-e0c44c39a7a7"), "Saipa" },
                    { new Guid("e3a9138f-366a-44fa-84d7-758ea36d84d4"), "KermanMotor" },
                    { new Guid("e3f9393c-8532-4406-8cec-d86545dfc1f7"), "Renault" },
                    { new Guid("f64efce5-8b46-4d69-9077-585ee8723a38"), "Chery" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("32eefa2b-f9f3-4921-a511-e2b12e814ae8"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("4076eba5-48fa-4e12-b646-f6ccb7a058f4"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("4611a07f-2ce1-4abd-a3dd-faceb4db0f3e"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("49041879-a332-4233-a0b9-28743647f2fe"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("503546f4-7178-4173-aaa4-1994b8af9724"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("581f92b2-e275-48ae-bf7b-c20cfa58987c"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("6f57d6a7-fa47-469f-9881-2b3ec2e54abf"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("a21321e2-6005-4de7-a8ed-72cc7d2c6275"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("a72d863f-0909-4500-90d3-72171fe97872"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("b2b0954e-c727-46fe-a6c1-e0c44c39a7a7"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("e3a9138f-366a-44fa-84d7-758ea36d84d4"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("e3f9393c-8532-4406-8cec-d86545dfc1f7"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("f64efce5-8b46-4d69-9077-585ee8723a38"));

            migrationBuilder.RenameColumn(
                name: "LoyaltyStatus",
                table: "AspNetUsers",
                newName: "loyaltyaStatus");

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
    }
}
