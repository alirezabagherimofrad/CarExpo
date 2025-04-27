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
                keyValue: new Guid("1d8d8711-d88f-4bbb-9f05-c12a074553ae"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("4d2703a2-7617-40d7-b9e0-b782d7ab7b4b"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("5bb6311c-0f04-4a32-890c-c938d648e9ae"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("60cb4c68-af99-4ecd-9e63-1361a6985a5a"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("636f269a-0291-4216-bbdf-4ddad973838d"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("7887867c-d743-4832-ac10-fea573076cb2"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("7cb42f1f-fa31-4667-8c82-0c9cb311e7fb"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("8ebafb5f-564e-459c-a42d-97cfeb420f84"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("94cf3284-9b60-4d38-8015-6779af15a3cb"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("96fa1610-3d3d-4cbf-8da1-c4f2ce5d37eb"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("bb850f46-49e7-44d3-acd6-3036ec35ba71"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("e46a0887-a9e4-4692-9468-63b767ce0fb4"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("f8f2bf07-e192-4dc6-9f71-1b8cab289f5c"));

            migrationBuilder.AlterColumn<string>(
                name: "VIN",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "ManufactureYear",
                table: "Cars",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LicensePlate",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("0b9301ad-fcea-41d1-99c5-fb0bacb3ba38"), "Brilliance" },
                    { new Guid("390f7c29-b4c4-4505-94aa-88021d4d4645"), "Hyundai" },
                    { new Guid("64d692bd-4dab-4284-a461-82a4ab33837a"), "JAC" },
                    { new Guid("7349926e-60b6-4f58-ac36-67cb461aa640"), "Saipa" },
                    { new Guid("7e3953fa-ec12-44b3-a7ee-b7efd759dc87"), "BahmanMotor" },
                    { new Guid("86180bff-374d-4ab9-aad2-7a666679f611"), "Chery" },
                    { new Guid("8f716ff3-afa1-4176-bad6-c51d908981b3"), "ParsKhodro" },
                    { new Guid("980976a5-9485-49d5-8396-04d2019c8687"), "Peugeot" },
                    { new Guid("b733b3ca-ee5d-4af2-952d-443746691361"), "Kia" },
                    { new Guid("bd7e9736-cd23-41a0-8fbb-de98280ac9c9"), "Renault" },
                    { new Guid("c8cf2988-6cb3-42ed-a2d5-e13ef5d38d49"), "KermanMotor" },
                    { new Guid("d015864e-0852-4c40-bebe-391bdf29aa56"), "Lifan" },
                    { new Guid("ea20a21b-1bf3-4bcc-a04b-463ba86c4547"), "ModiranKhodro" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("0b9301ad-fcea-41d1-99c5-fb0bacb3ba38"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("390f7c29-b4c4-4505-94aa-88021d4d4645"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("64d692bd-4dab-4284-a461-82a4ab33837a"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("7349926e-60b6-4f58-ac36-67cb461aa640"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("7e3953fa-ec12-44b3-a7ee-b7efd759dc87"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("86180bff-374d-4ab9-aad2-7a666679f611"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("8f716ff3-afa1-4176-bad6-c51d908981b3"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("980976a5-9485-49d5-8396-04d2019c8687"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("b733b3ca-ee5d-4af2-952d-443746691361"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("bd7e9736-cd23-41a0-8fbb-de98280ac9c9"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("c8cf2988-6cb3-42ed-a2d5-e13ef5d38d49"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("d015864e-0852-4c40-bebe-391bdf29aa56"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("ea20a21b-1bf3-4bcc-a04b-463ba86c4547"));

            migrationBuilder.AlterColumn<string>(
                name: "VIN",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ManufactureYear",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LicensePlate",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("1d8d8711-d88f-4bbb-9f05-c12a074553ae"), "Chery" },
                    { new Guid("4d2703a2-7617-40d7-b9e0-b782d7ab7b4b"), "Hyundai" },
                    { new Guid("5bb6311c-0f04-4a32-890c-c938d648e9ae"), "Brilliance" },
                    { new Guid("60cb4c68-af99-4ecd-9e63-1361a6985a5a"), "Peugeot" },
                    { new Guid("636f269a-0291-4216-bbdf-4ddad973838d"), "Saipa" },
                    { new Guid("7887867c-d743-4832-ac10-fea573076cb2"), "Lifan" },
                    { new Guid("7cb42f1f-fa31-4667-8c82-0c9cb311e7fb"), "Kia" },
                    { new Guid("8ebafb5f-564e-459c-a42d-97cfeb420f84"), "KermanMotor" },
                    { new Guid("94cf3284-9b60-4d38-8015-6779af15a3cb"), "BahmanMotor" },
                    { new Guid("96fa1610-3d3d-4cbf-8da1-c4f2ce5d37eb"), "JAC" },
                    { new Guid("bb850f46-49e7-44d3-acd6-3036ec35ba71"), "ModiranKhodro" },
                    { new Guid("e46a0887-a9e4-4692-9468-63b767ce0fb4"), "ParsKhodro" },
                    { new Guid("f8f2bf07-e192-4dc6-9f71-1b8cab289f5c"), "Renault" }
                });
        }
    }
}
