using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_commerceMVCProject.Migrations
{
    /// <inheritdoc />
    public partial class updateProductImagemodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImage_Products_ProductId",
                table: "ProductImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductImage",
                table: "ProductImage");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f2c3f0d1-77e5-4fc2-bb59-b6b811380be7", "1081ce85-e522-4e28-91a1-ccb10e65dd5f" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1081ce85-e522-4e28-91a1-ccb10e65dd5f");

            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "ProductImage");

            migrationBuilder.RenameTable(
                name: "ProductImage",
                newName: "ProductImages");

            migrationBuilder.RenameColumn(
                name: "ImageMimeType",
                table: "ProductImages",
                newName: "ImageName");

            migrationBuilder.RenameIndex(
                name: "IX_ProductImage_ProductId",
                table: "ProductImages",
                newName: "IX_ProductImages_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductImages",
                table: "ProductImages",
                column: "ProductImageId");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "Gender", "IsAdmin", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "42913f0e-28a3-4f4d-abb4-7c16d3fc93dc", 0, "cairo", "28-10-1999", "2409346a-47ac-43f2-a830-5d804b1fea88", "ayaahmed199910@gmail.com", true, "Admin", "Female", false, false, null, "AYAAHMED199910@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEOI38+DAQ6mW+9XabC25VeryWlKm2nx1LZIwZRvyLrq2v3NRS5tO+qJZ7V7kNOzEkw==", null, false, "e5360f12-690d-419b-aaf5-9c9cc676c3ae", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f2c3f0d1-77e5-4fc2-bb59-b6b811380be7", "42913f0e-28a3-4f4d-abb4-7c16d3fc93dc" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Products_ProductId",
                table: "ProductImages",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Products_ProductId",
                table: "ProductImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductImages",
                table: "ProductImages");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f2c3f0d1-77e5-4fc2-bb59-b6b811380be7", "42913f0e-28a3-4f4d-abb4-7c16d3fc93dc" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "42913f0e-28a3-4f4d-abb4-7c16d3fc93dc");

            migrationBuilder.RenameTable(
                name: "ProductImages",
                newName: "ProductImage");

            migrationBuilder.RenameColumn(
                name: "ImageName",
                table: "ProductImage",
                newName: "ImageMimeType");

            migrationBuilder.RenameIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImage",
                newName: "IX_ProductImage_ProductId");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "ProductImage",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductImage",
                table: "ProductImage",
                column: "ProductImageId");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "Gender", "IsAdmin", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1081ce85-e522-4e28-91a1-ccb10e65dd5f", 0, "cairo", "28-10-1999", "4b32fd23-5999-41ab-9bbb-231ce7435148", "ayaahmed199910@gmail.com", true, "Admin", "Female", false, false, null, "AYAAHMED199910@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEIel5jcP/gQEc2Y8L50YBpe/FbXCp4iycdZQAlO/S4DXjiRmpzhPfLztT6TAG8ga2g==", null, false, "c1b1ff62-e118-4340-b945-cd75bd62d327", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f2c3f0d1-77e5-4fc2-bb59-b6b811380be7", "1081ce85-e522-4e28-91a1-ccb10e65dd5f" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImage_Products_ProductId",
                table: "ProductImage",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
