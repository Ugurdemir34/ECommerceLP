using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Identity.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UserRefreshTokenAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1071ba6d-c98d-413f-aac6-e654ac657b93"));

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiry",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiry",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "EMail", "FirstName", "IsDeleted", "LastName", "ModifiedDate", "PasswordHash", "PhoneNumber", "UserName", "UserTypeId" },
                values: new object[] { new Guid("1071ba6d-c98d-413f-aac6-e654ac657b93"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ugurdemir551@gmail.com", "Uğur", false, "Demir", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=", "5340682415", "Ugur", null });
        }
    }
}
