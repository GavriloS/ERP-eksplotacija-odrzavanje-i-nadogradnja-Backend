using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeretanaApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentTypes",
                columns: table => new
                {
                    EquipmentTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentTypes", x => x.EquipmentTypeId);
                });

            migrationBuilder.CreateTable(
                name: "GroupTrainingTypes",
                columns: table => new
                {
                    GroupTrainingTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupTrainingTypes", x => x.GroupTrainingTypeId);
                });

            migrationBuilder.CreateTable(
                name: "MembershipTypes",
                columns: table => new
                {
                    MembershipTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfTrainings = table.Column<int>(type: "int", nullable: false),
                    NumberOfGroupTrainings = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipTypes", x => x.MembershipTypeId);
                });

            migrationBuilder.CreateTable(
                name: "SuplementTypes",
                columns: table => new
                {
                    SuplementTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuplementTypes", x => x.SuplementTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Trainers",
                columns: table => new
                {
                    TrainerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainers", x => x.TrainerId);
                });

            migrationBuilder.CreateTable(
                name: "UserTypes",
                columns: table => new
                {
                    UserTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypes", x => x.UserTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    EquipmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    EquipmentTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.EquipmentId);
                    table.ForeignKey(
                        name: "FK_Equipments_EquipmentTypes_EquipmentTypeId",
                        column: x => x.EquipmentTypeId,
                        principalTable: "EquipmentTypes",
                        principalColumn: "EquipmentTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Suplements",
                columns: table => new
                {
                    SuplementId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    SuplementTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suplements", x => x.SuplementId);
                    table.ForeignKey(
                        name: "FK_Suplements_SuplementTypes_SuplementTypeId",
                        column: x => x.SuplementTypeId,
                        principalTable: "SuplementTypes",
                        principalColumn: "SuplementTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    NumberOfTrainings = table.Column<int>(type: "int", nullable: true),
                    NumberOfGroupTraings = table.Column<int>(type: "int", nullable: true),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_UserTypes_UserTypeId",
                        column: x => x.UserTypeId,
                        principalTable: "UserTypes",
                        principalColumn: "UserTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Baskets",
                columns: table => new
                {
                    BasketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateTimeOfPurchase = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baskets", x => x.BasketId);
                    table.ForeignKey(
                        name: "FK_Baskets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupTrainings",
                columns: table => new
                {
                    GroupTrainingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateTimeOfGroupTraining = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GroupTrainingTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrainerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupTrainings", x => x.GroupTrainingId);
                    table.ForeignKey(
                        name: "FK_GroupTrainings_GroupTrainingTypes_GroupTrainingTypeId",
                        column: x => x.GroupTrainingTypeId,
                        principalTable: "GroupTrainingTypes",
                        principalColumn: "GroupTrainingTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupTrainings_Users_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Memberships",
                columns: table => new
                {
                    MembershipId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateTimeOfPayment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MembershipTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memberships", x => x.MembershipId);
                    table.ForeignKey(
                        name: "FK_Memberships_MembershipTypes_MembershipTypeId",
                        column: x => x.MembershipTypeId,
                        principalTable: "MembershipTypes",
                        principalColumn: "MembershipTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Memberships_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BasketEquipment",
                columns: table => new
                {
                    BasketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EquipmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketEquipment", x => new { x.BasketId, x.EquipmentId });
                    table.ForeignKey(
                        name: "FK_BasketEquipment_Baskets_BasketId",
                        column: x => x.BasketId,
                        principalTable: "Baskets",
                        principalColumn: "BasketId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasketEquipment_Equipments_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipments",
                        principalColumn: "EquipmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BasketSuplement",
                columns: table => new
                {
                    BasketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SuplementId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketSuplement", x => new { x.BasketId, x.SuplementId });
                    table.ForeignKey(
                        name: "FK_BasketSuplement_Baskets_BasketId",
                        column: x => x.BasketId,
                        principalTable: "Baskets",
                        principalColumn: "BasketId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasketSuplement_Suplements_SuplementId",
                        column: x => x.SuplementId,
                        principalTable: "Suplements",
                        principalColumn: "SuplementId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupTrainingUser",
                columns: table => new
                {
                    GroupTrainingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupTrainingUser", x => new { x.GroupTrainingId, x.UserId });
                    table.ForeignKey(
                        name: "FK_GroupTrainingUser_GroupTrainings_GroupTrainingId",
                        column: x => x.GroupTrainingId,
                        principalTable: "GroupTrainings",
                        principalColumn: "GroupTrainingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupTrainingUser_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressId", "City", "PostalCode", "Street", "StreetNumber" },
                values: new object[] { new Guid("d3a4cf13-5404-426a-8410-4573ed67214c"), "Novi Sad", "21000", "Branka Ilica", "1" });

            migrationBuilder.InsertData(
                table: "EquipmentTypes",
                columns: new[] { "EquipmentTypeId", "Name" },
                values: new object[,]
                {
                    { new Guid("3e25fa5b-5717-4722-9d33-d05db2f5733b"), "Bučice" },
                    { new Guid("acc47e70-1611-4691-b2d2-81eb1ed0d30c"), "Tegovi" }
                });

            migrationBuilder.InsertData(
                table: "GroupTrainingTypes",
                columns: new[] { "GroupTrainingTypeId", "Description", "Duration", "Name" },
                values: new object[,]
                {
                    { new Guid("383ed840-cd75-4c7b-9b20-a2bc74c4b25e"), "Jak i funkcionalan trbušni zid predstavlja temelj za bavljenje bilo kojim sportom ili fizičkom aktivnošću. Dominantne mišićne grupe koje se aktiviraju prilikom ovog načina treniranja su mišići donjih ekstremiteta, trbušnih i leđnih, kao i gluteus.", 60, "Glute & core" },
                    { new Guid("e1d2a65b-e62e-4b0e-b6b3-fbdaf9ee013b"), "Power Pump trening aktivira celo telo, svaku mišićnu grupu, noge, leđa, grudi, ramena, ruke i trbušno jezgro. Opterećivanjem celog tela na svakom treningu sa tegovima i velikim brojem ponavljanja, značajno se utiče na sagorevanje kalorija, smanjivanje masnog tkiva, kao i izgradnju mišične mase.", 45, "Power pump" }
                });

            migrationBuilder.InsertData(
                table: "MembershipTypes",
                columns: new[] { "MembershipTypeId", "Name", "NumberOfGroupTrainings", "NumberOfTrainings", "Price" },
                values: new object[,]
                {
                    { new Guid("22efe84a-c425-4b2c-8b40-fa00e934c18b"), "30 treninga", 0, 30, 3000.0 },
                    { new Guid("b4eac379-5cf2-4caa-807a-253deb228a59"), "10 grupnih treninga", 10, 0, 2000.0 }
                });

            migrationBuilder.InsertData(
                table: "SuplementTypes",
                columns: new[] { "SuplementTypeId", "Name" },
                values: new object[,]
                {
                    { new Guid("645b8bb6-0fa8-4082-8c8c-7fef241b7bce"), "Protein" },
                    { new Guid("96fbee9a-2887-4cec-8f8b-a185da06d29b"), "Kreatin" }
                });

            migrationBuilder.InsertData(
                table: "UserTypes",
                columns: new[] { "UserTypeId", "Name" },
                values: new object[,]
                {
                    { new Guid("51371a38-00fa-4171-be2c-002e483ed463"), "Trainer" },
                    { new Guid("6bc0cc6a-c600-4ae9-8e2e-d4b61b601701"), "User" },
                    { new Guid("7f342d88-3f53-490f-a3cd-1186251af607"), "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "EquipmentId", "Description", "EquipmentTypeId", "Manufacturer", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { new Guid("5cd97245-918b-4ba7-9068-3158aeb24feb"), "Gumirane bučice sa hromiranim rukohvatom", new Guid("3e25fa5b-5717-4722-9d33-d05db2f5733b"), "Kina", "HEX BUČICE, PROFESIONALNE FIKSNE GUMIRANE 2.5kg", 350.0, 10 },
                    { new Guid("bd659cae-3bd6-4a1e-8bce-3d19b666548d"), "Liveni tegovi Fi 30 promera rupe 30mm odnosno u Fi 30 standardu. Idealni za kućno vežbanje i odgovaraju za sve šipke Fi 30.Liveni teg se može koristiti za male šipke za bučice i za velike prave šipke za trening benča, ramena, mrtvog dizanja i sl.Ploče su izlivene od metala i farbane u crno.", new Guid("acc47e70-1611-4691-b2d2-81eb1ed0d30c"), "Capriolo", "LIVENI TEGOVI FI30 10kg", 2600.0, 8 }
                });

            migrationBuilder.InsertData(
                table: "Suplements",
                columns: new[] { "SuplementId", "Description", "Manufacturer", "Name", "Price", "Quantity", "SuplementTypeId" },
                values: new object[,]
                {
                    { new Guid("38307eb9-669e-4c5a-b17c-237f6e52f5e2"), "THE Kreatin monohidrat povećava sintezu molekula ATP (adenozin-tri-fosfata), koja direktno utiče na povećanje snage i izdržljivosti kod anaerobnih aktivnosti,a samim tim i jacu prokrvljenost misica i na taj nacin indirektan uticaj na misicnu masu.", "The Nutrition", "THE CREATINE - 1000G (KREATIN MONOHIDRAT)", 3600.0, 15, new Guid("96fbee9a-2887-4cec-8f8b-a185da06d29b") },
                    { new Guid("9e6bb816-2db3-46d7-91f9-0a175578f4bd"), "Amino Whey Hydro protein The Nutrition. je preko 86% Protein i sadrži gotovo ništa Masti ili Ugljenih Hidrata. Pruža sinergističku mešavinu nakvalitetnijih izvora Proteina, koji ne samo da povećavaju sintezu Proteina, volumen ćelija i misićni anabolizam, dok istovremeno štite zglobove i hrskavice, već i jačaju imuni sistem i smanjuju nivo lošeg (LDL) Holesterola i smanjuju mogućnost Srčanih Bolesti.", "The Nutrition", "THE AMINO WHEY HYDRO PROTEIN 3.500 G", 7390.0, 10, new Guid("645b8bb6-0fa8-4082-8c8c-7fef241b7bce") },
                    { new Guid("d6e14c22-bc87-44ce-8c9d-5196e388d621"), "100% Whey Protein je napredna formula proteina surutke, napravljena za sve sportaše, koji žele više mišića, više snage i brži oporavak. Svaki obrok osigurava 22g whey proteina surutke i 5 grama aminokiselina razgranatog lanca (BCAA), te sa 2,4 grama možda i najbitnije aminokiseline L-leucin.", "The Nutrition", "THE BASIC 100% WHEY PROTEIN 1800 GRAMA", 3600.0, 15, new Guid("645b8bb6-0fa8-4082-8c8c-7fef241b7bce") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "AddressId", "ContactNumber", "Email", "FirstName", "LastName", "NumberOfGroupTraings", "NumberOfTrainings", "Password", "PasswordSalt", "UserTypeId" },
                values: new object[,]
                {
                    { new Guid("17b66c64-185f-48e0-9901-b322b8523760"), new Guid("d3a4cf13-5404-426a-8410-4573ed67214c"), "0665235235", "gavrilo@gmail.com", "Gavrilo", "Stanic", 0, 3, new byte[] { 55, 210, 44, 162, 209, 215, 29, 146, 62, 8, 132, 169, 224, 0, 25, 155, 22, 56, 209, 7, 131, 162, 63, 190, 155, 58, 149, 51, 127, 147, 15, 184, 244, 32, 156, 255, 225, 30, 1, 212, 117, 29, 50, 69, 22, 95, 1, 173, 125, 104, 212, 179, 187, 78, 175, 253, 145, 128, 100, 237, 53, 94, 198, 92 }, new byte[] { 189, 120, 189, 42, 7, 247, 180, 188, 237, 207, 67, 168, 101, 53, 195, 6, 107, 128, 85, 116, 59, 140, 223, 243, 137, 229, 93, 171, 231, 78, 242, 90, 164, 224, 226, 196, 60, 82, 152, 71, 4, 11, 195, 18, 45, 231, 68, 58, 175, 138, 30, 174, 151, 29, 210, 104, 238, 12, 216, 210, 246, 41, 44, 108, 46, 45, 36, 102, 189, 21, 226, 221, 150, 84, 72, 120, 196, 2, 116, 70, 68, 247, 199, 116, 190, 202, 120, 26, 124, 140, 247, 71, 131, 161, 90, 73, 100, 240, 13, 153, 28, 196, 176, 136, 223, 253, 109, 164, 220, 207, 7, 95, 77, 81, 25, 53, 143, 59, 143, 229, 215, 3, 223, 113, 56, 232, 130, 115 }, new Guid("7f342d88-3f53-490f-a3cd-1186251af607") },
                    { new Guid("35c20dc1-e401-4e08-8b48-4b058a4388b5"), new Guid("d3a4cf13-5404-426a-8410-4573ed67214c"), "0665235325", "Petar@gmail.com", "Petar", "Markovic", 0, 0, new byte[] { 9, 111, 43, 224, 117, 57, 19, 222, 37, 144, 21, 206, 83, 13, 104, 220, 24, 65, 208, 186, 246, 95, 57, 62, 111, 218, 234, 156, 76, 150, 212, 249, 102, 46, 198, 13, 50, 183, 111, 197, 58, 25, 97, 166, 41, 192, 248, 95, 149, 198, 121, 148, 194, 90, 88, 151, 168, 231, 33, 28, 29, 130, 241, 183 }, new byte[] { 72, 106, 47, 146, 45, 36, 53, 31, 29, 124, 175, 98, 102, 185, 163, 76, 33, 96, 61, 201, 100, 94, 195, 145, 170, 81, 14, 118, 47, 196, 76, 167, 70, 126, 82, 109, 44, 251, 84, 248, 63, 42, 76, 0, 4, 127, 6, 9, 252, 23, 175, 48, 11, 61, 132, 10, 118, 74, 51, 243, 198, 142, 175, 51, 221, 121, 213, 237, 0, 240, 47, 54, 107, 213, 140, 33, 126, 104, 14, 228, 103, 201, 119, 128, 145, 141, 238, 205, 34, 123, 251, 150, 78, 176, 19, 208, 99, 2, 150, 73, 189, 31, 255, 1, 2, 90, 12, 139, 205, 81, 50, 178, 157, 155, 129, 18, 167, 135, 157, 194, 233, 55, 188, 71, 155, 118, 55, 239 }, new Guid("51371a38-00fa-4171-be2c-002e483ed463") },
                    { new Guid("668abb5d-51f7-4db1-b3b4-69b3fc32fa6e"), new Guid("d3a4cf13-5404-426a-8410-4573ed67214c"), "06653252354", "marko@gmail.com", "Marko", "Stanic", 8, 0, new byte[] { 145, 164, 181, 33, 40, 80, 174, 132, 201, 128, 175, 172, 148, 77, 163, 78, 189, 100, 103, 62, 220, 153, 183, 68, 213, 112, 134, 133, 199, 144, 115, 239, 205, 144, 228, 1, 149, 22, 170, 9, 136, 66, 253, 88, 211, 137, 246, 51, 145, 133, 140, 93, 39, 30, 171, 173, 140, 42, 91, 182, 42, 247, 0, 202 }, new byte[] { 227, 229, 252, 121, 248, 160, 105, 106, 177, 193, 208, 241, 199, 85, 12, 209, 128, 203, 239, 190, 82, 196, 232, 125, 35, 35, 141, 175, 250, 142, 208, 209, 191, 8, 213, 142, 82, 180, 83, 74, 56, 114, 20, 24, 133, 42, 154, 197, 188, 116, 114, 147, 169, 12, 133, 198, 157, 92, 50, 117, 211, 173, 68, 223, 7, 148, 0, 2, 2, 86, 221, 87, 243, 134, 200, 107, 145, 209, 238, 0, 104, 214, 189, 250, 45, 113, 133, 152, 88, 5, 239, 73, 222, 248, 3, 45, 23, 213, 162, 184, 198, 112, 76, 80, 152, 195, 227, 6, 24, 100, 79, 160, 8, 2, 250, 177, 81, 141, 30, 79, 19, 226, 17, 250, 15, 248, 173, 22 }, new Guid("6bc0cc6a-c600-4ae9-8e2e-d4b61b601701") }
                });

            migrationBuilder.InsertData(
                table: "Baskets",
                columns: new[] { "BasketId", "DateTimeOfPurchase", "IsCompleted", "UserId" },
                values: new object[] { new Guid("6d4550ec-122d-4bd1-a823-d136edd94bf7"), new DateTime(2022, 1, 6, 13, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("668abb5d-51f7-4db1-b3b4-69b3fc32fa6e") });

            migrationBuilder.InsertData(
                table: "GroupTrainings",
                columns: new[] { "GroupTrainingId", "DateTimeOfGroupTraining", "GroupTrainingTypeId", "TrainerId" },
                values: new object[,]
                {
                    { new Guid("d2153f69-fe08-41b4-8256-c693c16d30ec"), new DateTime(2022, 1, 7, 18, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e1d2a65b-e62e-4b0e-b6b3-fbdaf9ee013b"), new Guid("35c20dc1-e401-4e08-8b48-4b058a4388b5") },
                    { new Guid("df27a844-f104-4ef2-9ddb-cfc49cee6a57"), new DateTime(2022, 1, 7, 13, 0, 0, 0, DateTimeKind.Unspecified), new Guid("383ed840-cd75-4c7b-9b20-a2bc74c4b25e"), new Guid("35c20dc1-e401-4e08-8b48-4b058a4388b5") }
                });

            migrationBuilder.InsertData(
                table: "Memberships",
                columns: new[] { "MembershipId", "DateTimeOfPayment", "MembershipTypeId", "UserId" },
                values: new object[,]
                {
                    { new Guid("1a1ae6ea-5cf4-419a-a5ab-5888aa177a34"), new DateTime(2022, 1, 4, 13, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b4eac379-5cf2-4caa-807a-253deb228a59"), new Guid("668abb5d-51f7-4db1-b3b4-69b3fc32fa6e") },
                    { new Guid("c02e8458-930f-4e0d-bd28-66361dd72f85"), new DateTime(2022, 1, 4, 13, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22efe84a-c425-4b2c-8b40-fa00e934c18b"), new Guid("17b66c64-185f-48e0-9901-b322b8523760") }
                });

            migrationBuilder.InsertData(
                table: "BasketEquipment",
                columns: new[] { "BasketId", "EquipmentId", "Quantity" },
                values: new object[] { new Guid("6d4550ec-122d-4bd1-a823-d136edd94bf7"), new Guid("5cd97245-918b-4ba7-9068-3158aeb24feb"), 2 });

            migrationBuilder.InsertData(
                table: "BasketSuplement",
                columns: new[] { "BasketId", "SuplementId", "Quantity" },
                values: new object[] { new Guid("6d4550ec-122d-4bd1-a823-d136edd94bf7"), new Guid("9e6bb816-2db3-46d7-91f9-0a175578f4bd"), 1 });

            migrationBuilder.InsertData(
                table: "GroupTrainingUser",
                columns: new[] { "GroupTrainingId", "UserId" },
                values: new object[] { new Guid("d2153f69-fe08-41b4-8256-c693c16d30ec"), new Guid("668abb5d-51f7-4db1-b3b4-69b3fc32fa6e") });

            migrationBuilder.CreateIndex(
                name: "IX_BasketEquipment_EquipmentId",
                table: "BasketEquipment",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_UserId",
                table: "Baskets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketSuplement_SuplementId",
                table: "BasketSuplement",
                column: "SuplementId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_EquipmentTypeId",
                table: "Equipments",
                column: "EquipmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupTrainings_GroupTrainingTypeId",
                table: "GroupTrainings",
                column: "GroupTrainingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupTrainings_TrainerId",
                table: "GroupTrainings",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupTrainingUser_UserId",
                table: "GroupTrainingUser",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Memberships_MembershipTypeId",
                table: "Memberships",
                column: "MembershipTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Memberships_UserId",
                table: "Memberships",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Suplements_SuplementTypeId",
                table: "Suplements",
                column: "SuplementTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AddressId",
                table: "Users",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserTypeId",
                table: "Users",
                column: "UserTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketEquipment");

            migrationBuilder.DropTable(
                name: "BasketSuplement");

            migrationBuilder.DropTable(
                name: "GroupTrainingUser");

            migrationBuilder.DropTable(
                name: "Memberships");

            migrationBuilder.DropTable(
                name: "Trainers");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "Baskets");

            migrationBuilder.DropTable(
                name: "Suplements");

            migrationBuilder.DropTable(
                name: "GroupTrainings");

            migrationBuilder.DropTable(
                name: "MembershipTypes");

            migrationBuilder.DropTable(
                name: "EquipmentTypes");

            migrationBuilder.DropTable(
                name: "SuplementTypes");

            migrationBuilder.DropTable(
                name: "GroupTrainingTypes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "UserTypes");
        }
    }
}
