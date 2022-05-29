using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeretanaApi.Migrations
{
    public partial class Stripe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PriceId",
                table: "Suplements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductId",
                table: "Suplements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PriceId",
                table: "MembershipTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductId",
                table: "MembershipTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PriceId",
                table: "Equipments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductId",
                table: "Equipments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: new Guid("5cd97245-918b-4ba7-9068-3158aeb24feb"),
                columns: new[] { "PriceId", "ProductId" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "EquipmentId",
                keyValue: new Guid("bd659cae-3bd6-4a1e-8bce-3d19b666548d"),
                columns: new[] { "PriceId", "ProductId" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "MembershipTypes",
                keyColumn: "MembershipTypeId",
                keyValue: new Guid("22efe84a-c425-4b2c-8b40-fa00e934c18b"),
                columns: new[] { "PriceId", "ProductId" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "MembershipTypes",
                keyColumn: "MembershipTypeId",
                keyValue: new Guid("b4eac379-5cf2-4caa-807a-253deb228a59"),
                columns: new[] { "PriceId", "ProductId" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Suplements",
                keyColumn: "SuplementId",
                keyValue: new Guid("38307eb9-669e-4c5a-b17c-237f6e52f5e2"),
                columns: new[] { "PriceId", "ProductId" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Suplements",
                keyColumn: "SuplementId",
                keyValue: new Guid("9e6bb816-2db3-46d7-91f9-0a175578f4bd"),
                columns: new[] { "PriceId", "ProductId" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Suplements",
                keyColumn: "SuplementId",
                keyValue: new Guid("d6e14c22-bc87-44ce-8c9d-5196e388d621"),
                columns: new[] { "PriceId", "ProductId" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("17b66c64-185f-48e0-9901-b322b8523760"),
                columns: new[] { "Password", "PasswordSalt" },
                values: new object[] { new byte[] { 76, 140, 241, 227, 61, 234, 133, 74, 172, 205, 188, 209, 208, 123, 188, 250, 160, 228, 207, 20, 210, 173, 104, 75, 240, 9, 4, 67, 220, 106, 238, 17, 204, 118, 190, 169, 116, 120, 40, 22, 159, 177, 232, 136, 84, 216, 188, 82, 111, 67, 103, 188, 212, 128, 19, 78, 27, 192, 55, 233, 208, 109, 210, 210 }, new byte[] { 46, 254, 28, 115, 179, 121, 41, 100, 89, 217, 181, 124, 83, 240, 1, 60, 81, 207, 135, 105, 27, 131, 66, 106, 245, 141, 8, 91, 44, 49, 239, 105, 85, 10, 91, 64, 46, 221, 255, 179, 115, 218, 235, 237, 171, 2, 219, 170, 190, 171, 146, 125, 73, 243, 23, 137, 104, 173, 138, 226, 114, 216, 156, 232, 239, 13, 131, 177, 233, 174, 57, 172, 1, 150, 236, 232, 23, 165, 219, 214, 177, 118, 236, 220, 146, 51, 197, 199, 25, 86, 12, 29, 55, 248, 223, 131, 184, 132, 193, 1, 183, 97, 89, 227, 247, 44, 156, 38, 33, 128, 188, 129, 53, 7, 238, 83, 97, 222, 33, 76, 219, 21, 79, 87, 69, 193, 22, 198 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("35c20dc1-e401-4e08-8b48-4b058a4388b5"),
                columns: new[] { "Password", "PasswordSalt" },
                values: new object[] { new byte[] { 108, 119, 90, 64, 50, 50, 88, 145, 17, 219, 153, 187, 109, 76, 150, 171, 35, 118, 250, 34, 221, 183, 142, 92, 42, 232, 21, 147, 148, 238, 230, 25, 247, 168, 195, 253, 124, 26, 138, 208, 254, 0, 120, 144, 204, 45, 127, 189, 178, 149, 166, 52, 76, 91, 77, 86, 96, 221, 4, 59, 136, 73, 139, 25 }, new byte[] { 203, 206, 67, 226, 202, 45, 176, 98, 179, 1, 234, 218, 133, 102, 29, 204, 136, 123, 117, 247, 140, 209, 37, 123, 215, 210, 182, 131, 44, 197, 66, 234, 52, 98, 213, 2, 83, 158, 71, 235, 214, 12, 16, 114, 189, 38, 36, 151, 55, 253, 51, 136, 134, 134, 149, 202, 150, 113, 125, 16, 120, 150, 210, 2, 33, 142, 139, 254, 139, 113, 239, 165, 180, 90, 228, 29, 50, 248, 157, 93, 73, 66, 53, 173, 105, 182, 62, 82, 139, 193, 54, 238, 170, 67, 86, 84, 107, 177, 142, 27, 254, 236, 24, 131, 169, 138, 152, 29, 21, 131, 106, 118, 9, 43, 105, 180, 184, 207, 83, 228, 217, 117, 90, 106, 252, 58, 72, 166 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("668abb5d-51f7-4db1-b3b4-69b3fc32fa6e"),
                columns: new[] { "Password", "PasswordSalt" },
                values: new object[] { new byte[] { 168, 171, 214, 112, 140, 123, 189, 168, 118, 83, 20, 4, 128, 131, 61, 137, 192, 65, 237, 112, 145, 188, 54, 182, 94, 106, 53, 192, 193, 46, 59, 85, 32, 103, 39, 63, 167, 125, 129, 239, 219, 75, 128, 161, 196, 138, 75, 51, 54, 16, 228, 182, 53, 135, 25, 128, 187, 158, 44, 114, 64, 246, 36, 129 }, new byte[] { 117, 9, 41, 1, 208, 144, 205, 141, 164, 63, 226, 228, 250, 164, 183, 103, 53, 210, 145, 131, 48, 101, 250, 214, 153, 96, 8, 186, 226, 185, 201, 119, 7, 106, 87, 171, 189, 13, 255, 91, 132, 40, 95, 180, 160, 1, 197, 209, 15, 134, 189, 194, 215, 98, 50, 131, 158, 222, 44, 33, 73, 255, 17, 5, 58, 0, 109, 189, 38, 231, 200, 206, 164, 120, 181, 69, 25, 59, 68, 26, 96, 244, 69, 76, 73, 199, 160, 125, 130, 184, 252, 253, 45, 83, 93, 138, 192, 79, 244, 42, 68, 20, 187, 249, 88, 7, 148, 234, 162, 19, 217, 94, 213, 93, 89, 252, 161, 87, 29, 121, 153, 37, 124, 15, 67, 189, 202, 26 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceId",
                table: "Suplements");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Suplements");

            migrationBuilder.DropColumn(
                name: "PriceId",
                table: "MembershipTypes");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "MembershipTypes");

            migrationBuilder.DropColumn(
                name: "PriceId",
                table: "Equipments");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Equipments");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("17b66c64-185f-48e0-9901-b322b8523760"),
                columns: new[] { "Password", "PasswordSalt" },
                values: new object[] { new byte[] { 55, 210, 44, 162, 209, 215, 29, 146, 62, 8, 132, 169, 224, 0, 25, 155, 22, 56, 209, 7, 131, 162, 63, 190, 155, 58, 149, 51, 127, 147, 15, 184, 244, 32, 156, 255, 225, 30, 1, 212, 117, 29, 50, 69, 22, 95, 1, 173, 125, 104, 212, 179, 187, 78, 175, 253, 145, 128, 100, 237, 53, 94, 198, 92 }, new byte[] { 189, 120, 189, 42, 7, 247, 180, 188, 237, 207, 67, 168, 101, 53, 195, 6, 107, 128, 85, 116, 59, 140, 223, 243, 137, 229, 93, 171, 231, 78, 242, 90, 164, 224, 226, 196, 60, 82, 152, 71, 4, 11, 195, 18, 45, 231, 68, 58, 175, 138, 30, 174, 151, 29, 210, 104, 238, 12, 216, 210, 246, 41, 44, 108, 46, 45, 36, 102, 189, 21, 226, 221, 150, 84, 72, 120, 196, 2, 116, 70, 68, 247, 199, 116, 190, 202, 120, 26, 124, 140, 247, 71, 131, 161, 90, 73, 100, 240, 13, 153, 28, 196, 176, 136, 223, 253, 109, 164, 220, 207, 7, 95, 77, 81, 25, 53, 143, 59, 143, 229, 215, 3, 223, 113, 56, 232, 130, 115 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("35c20dc1-e401-4e08-8b48-4b058a4388b5"),
                columns: new[] { "Password", "PasswordSalt" },
                values: new object[] { new byte[] { 9, 111, 43, 224, 117, 57, 19, 222, 37, 144, 21, 206, 83, 13, 104, 220, 24, 65, 208, 186, 246, 95, 57, 62, 111, 218, 234, 156, 76, 150, 212, 249, 102, 46, 198, 13, 50, 183, 111, 197, 58, 25, 97, 166, 41, 192, 248, 95, 149, 198, 121, 148, 194, 90, 88, 151, 168, 231, 33, 28, 29, 130, 241, 183 }, new byte[] { 72, 106, 47, 146, 45, 36, 53, 31, 29, 124, 175, 98, 102, 185, 163, 76, 33, 96, 61, 201, 100, 94, 195, 145, 170, 81, 14, 118, 47, 196, 76, 167, 70, 126, 82, 109, 44, 251, 84, 248, 63, 42, 76, 0, 4, 127, 6, 9, 252, 23, 175, 48, 11, 61, 132, 10, 118, 74, 51, 243, 198, 142, 175, 51, 221, 121, 213, 237, 0, 240, 47, 54, 107, 213, 140, 33, 126, 104, 14, 228, 103, 201, 119, 128, 145, 141, 238, 205, 34, 123, 251, 150, 78, 176, 19, 208, 99, 2, 150, 73, 189, 31, 255, 1, 2, 90, 12, 139, 205, 81, 50, 178, 157, 155, 129, 18, 167, 135, 157, 194, 233, 55, 188, 71, 155, 118, 55, 239 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("668abb5d-51f7-4db1-b3b4-69b3fc32fa6e"),
                columns: new[] { "Password", "PasswordSalt" },
                values: new object[] { new byte[] { 145, 164, 181, 33, 40, 80, 174, 132, 201, 128, 175, 172, 148, 77, 163, 78, 189, 100, 103, 62, 220, 153, 183, 68, 213, 112, 134, 133, 199, 144, 115, 239, 205, 144, 228, 1, 149, 22, 170, 9, 136, 66, 253, 88, 211, 137, 246, 51, 145, 133, 140, 93, 39, 30, 171, 173, 140, 42, 91, 182, 42, 247, 0, 202 }, new byte[] { 227, 229, 252, 121, 248, 160, 105, 106, 177, 193, 208, 241, 199, 85, 12, 209, 128, 203, 239, 190, 82, 196, 232, 125, 35, 35, 141, 175, 250, 142, 208, 209, 191, 8, 213, 142, 82, 180, 83, 74, 56, 114, 20, 24, 133, 42, 154, 197, 188, 116, 114, 147, 169, 12, 133, 198, 157, 92, 50, 117, 211, 173, 68, 223, 7, 148, 0, 2, 2, 86, 221, 87, 243, 134, 200, 107, 145, 209, 238, 0, 104, 214, 189, 250, 45, 113, 133, 152, 88, 5, 239, 73, 222, 248, 3, 45, 23, 213, 162, 184, 198, 112, 76, 80, 152, 195, 227, 6, 24, 100, 79, 160, 8, 2, 250, 177, 81, 141, 30, 79, 19, 226, 17, 250, 15, 248, 173, 22 } });
        }
    }
}
