using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarExpo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "LoyaltyPoints",
                table: "payments");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("011a1588-92ee-44a7-998e-957f2528cf40"), "Renault" },
                    { new Guid("0b4f967f-f82a-43b6-8e5c-d636779b2890"), "ModiranKhodro" },
                    { new Guid("3bdfbda7-f1c2-4bf2-b5bf-b8e152ef0657"), "ParsKhodro" },
                    { new Guid("41c6da2b-077a-4da1-b6e4-fbe6c24f5a46"), "Saipa" },
                    { new Guid("44da3b36-8684-4f03-a713-7354411862a4"), "Peugeot" },
                    { new Guid("46032581-acaf-45a4-b22c-ef6ebe51bcec"), "Brilliance" },
                    { new Guid("4c2f34aa-853b-4281-a282-ebf5a9811c34"), "Kia" },
                    { new Guid("67c16414-d167-4d92-9659-1aa3cbc44f07"), "KermanMotor" },
                    { new Guid("cc8989e4-67d0-4e06-83b7-06707bd187fa"), "BahmanMotor" },
                    { new Guid("d2b7e23e-b078-4f95-931d-eaf84d9d72dd"), "Chery" },
                    { new Guid("d7795a56-d254-4e01-a735-764b5f28cfa3"), "JAC" },
                    { new Guid("e7439f07-65f0-4305-bb61-d2d4c145b51d"), "Hyundai" },
                    { new Guid("fe131880-31e0-4de2-a39d-7cf97edb8aa5"), "Lifan" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("011a1588-92ee-44a7-998e-957f2528cf40"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("0b4f967f-f82a-43b6-8e5c-d636779b2890"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("3bdfbda7-f1c2-4bf2-b5bf-b8e152ef0657"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("41c6da2b-077a-4da1-b6e4-fbe6c24f5a46"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("44da3b36-8684-4f03-a713-7354411862a4"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("46032581-acaf-45a4-b22c-ef6ebe51bcec"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("4c2f34aa-853b-4281-a282-ebf5a9811c34"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("67c16414-d167-4d92-9659-1aa3cbc44f07"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("cc8989e4-67d0-4e06-83b7-06707bd187fa"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("d2b7e23e-b078-4f95-931d-eaf84d9d72dd"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("d7795a56-d254-4e01-a735-764b5f28cfa3"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("e7439f07-65f0-4305-bb61-d2d4c145b51d"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("fe131880-31e0-4de2-a39d-7cf97edb8aa5"));

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<decimal>(
                name: "LoyaltyPoints",
                table: "payments",
                type: "decimal(18,2)",
                nullable: true);

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
    }
}
