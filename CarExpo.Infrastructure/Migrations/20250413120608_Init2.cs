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
                keyValue: new Guid("0d109a9f-4da6-40c2-a310-768c01c78747"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("14be60e2-fa34-427b-889e-5ca473ae49d7"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("1fd3d7bf-472f-46cf-ad92-e4b37d0f1b77"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("243bbaf8-6c48-4bc5-9733-1a34dde12661"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("3c6ccc83-4440-4ca0-a284-6306d764dddf"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("54d71bde-1570-43ec-84a1-63dd24da969a"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("74fd2900-71dc-4310-a61a-ba93a7f8f011"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("7cbb7f58-3d91-4069-878f-1b537610b7f4"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("b6542e22-029c-4a38-9d5e-df88659b11f7"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("c6027a1f-1a3d-4a51-9853-5e18966daf4d"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("e50e00cc-db34-41c7-af1d-cb35be9901fb"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("e91e5c61-4c18-407f-bdfc-4dca286dadeb"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("ec8d87eb-3d72-4372-a6c8-1ba2ffcd029f"));

            migrationBuilder.AddColumn<string>(
                name: "InvoiceNumber",
                table: "payments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TrackingCode",
                table: "payments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "InvoiceNumber",
                table: "payments");

            migrationBuilder.DropColumn(
                name: "TrackingCode",
                table: "payments");

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("0d109a9f-4da6-40c2-a310-768c01c78747"), "KermanMotor" },
                    { new Guid("14be60e2-fa34-427b-889e-5ca473ae49d7"), "Lifan" },
                    { new Guid("1fd3d7bf-472f-46cf-ad92-e4b37d0f1b77"), "Saipa" },
                    { new Guid("243bbaf8-6c48-4bc5-9733-1a34dde12661"), "Brilliance" },
                    { new Guid("3c6ccc83-4440-4ca0-a284-6306d764dddf"), "Chery" },
                    { new Guid("54d71bde-1570-43ec-84a1-63dd24da969a"), "ModiranKhodro" },
                    { new Guid("74fd2900-71dc-4310-a61a-ba93a7f8f011"), "Hyundai" },
                    { new Guid("7cbb7f58-3d91-4069-878f-1b537610b7f4"), "ParsKhodro" },
                    { new Guid("b6542e22-029c-4a38-9d5e-df88659b11f7"), "JAC" },
                    { new Guid("c6027a1f-1a3d-4a51-9853-5e18966daf4d"), "BahmanMotor" },
                    { new Guid("e50e00cc-db34-41c7-af1d-cb35be9901fb"), "Peugeot" },
                    { new Guid("e91e5c61-4c18-407f-bdfc-4dca286dadeb"), "Kia" },
                    { new Guid("ec8d87eb-3d72-4372-a6c8-1ba2ffcd029f"), "Renault" }
                });
        }
    }
}
