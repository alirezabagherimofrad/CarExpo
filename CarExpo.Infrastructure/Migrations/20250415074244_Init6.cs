using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarExpo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<decimal>(
                name: "LoyaltyPoints",
                table: "AspNetUsers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("1c66c1e5-c4f2-48a4-8d0b-02c75648fb1f"), "JAC" },
                    { new Guid("2d075131-f70c-413a-99dd-b94c1b2cf0ab"), "Brilliance" },
                    { new Guid("4d72baac-2643-4332-b344-14529f23d0bd"), "Peugeot" },
                    { new Guid("596dee34-7e6d-41fe-8d67-f5bf9d04e805"), "Saipa" },
                    { new Guid("6320d1e5-b2de-4d12-9cfd-fd26b88122bf"), "KermanMotor" },
                    { new Guid("7552e638-e596-415f-8e53-ef29d531b00e"), "Hyundai" },
                    { new Guid("8f5eaa52-9484-4dd5-871c-9363d1cd2972"), "ModiranKhodro" },
                    { new Guid("9b585022-4858-444c-ac32-ae338118351f"), "Kia" },
                    { new Guid("9f205d17-2fd4-43d5-8c63-12173c874d0b"), "Chery" },
                    { new Guid("9fb2e7d2-f1ef-4a3b-82c3-f509da9da928"), "BahmanMotor" },
                    { new Guid("b1efe5a3-e4b0-448e-a922-d117cc2bde1f"), "Renault" },
                    { new Guid("b8f131ac-0d9a-45db-9eed-0d06fb000342"), "ParsKhodro" },
                    { new Guid("bce45e33-332f-46ca-9e53-b735b71a4587"), "Lifan" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("1c66c1e5-c4f2-48a4-8d0b-02c75648fb1f"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("2d075131-f70c-413a-99dd-b94c1b2cf0ab"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("4d72baac-2643-4332-b344-14529f23d0bd"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("596dee34-7e6d-41fe-8d67-f5bf9d04e805"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("6320d1e5-b2de-4d12-9cfd-fd26b88122bf"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("7552e638-e596-415f-8e53-ef29d531b00e"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("8f5eaa52-9484-4dd5-871c-9363d1cd2972"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("9b585022-4858-444c-ac32-ae338118351f"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("9f205d17-2fd4-43d5-8c63-12173c874d0b"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("9fb2e7d2-f1ef-4a3b-82c3-f509da9da928"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("b1efe5a3-e4b0-448e-a922-d117cc2bde1f"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("b8f131ac-0d9a-45db-9eed-0d06fb000342"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("bce45e33-332f-46ca-9e53-b735b71a4587"));

            migrationBuilder.AlterColumn<decimal>(
                name: "LoyaltyPoints",
                table: "AspNetUsers",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

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
    }
}
