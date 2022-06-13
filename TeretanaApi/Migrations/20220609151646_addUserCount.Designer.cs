﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TeretanaApi.Entities.DataContext;

#nullable disable

namespace TeretanaApi.Migrations
{
    [DbContext(typeof(GymContext))]
    [Migration("20220609151646_addUserCount")]
    partial class addUserCount
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GroupTrainingUser", b =>
                {
                    b.Property<Guid>("GroupTrainingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GroupTrainingId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("GroupTrainingUser");

                    b.HasData(
                        new
                        {
                            GroupTrainingId = new Guid("d2153f69-fe08-41b4-8256-c693c16d30ec"),
                            UserId = new Guid("668abb5d-51f7-4db1-b3b4-69b3fc32fa6e")
                        });
                });

            modelBuilder.Entity("TeretanaApi.Entities.Address", b =>
                {
                    b.Property<Guid>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AddressId");

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            AddressId = new Guid("d3a4cf13-5404-426a-8410-4573ed67214c"),
                            City = "Novi Sad",
                            PostalCode = "21000",
                            Street = "Branka Ilica",
                            StreetNumber = "1"
                        });
                });

            modelBuilder.Entity("TeretanaApi.Entities.Basket", b =>
                {
                    b.Property<Guid>("BasketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateTimeOfPurchase")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BasketId");

                    b.HasIndex("UserId");

                    b.ToTable("Baskets");

                    b.HasData(
                        new
                        {
                            BasketId = new Guid("6d4550ec-122d-4bd1-a823-d136edd94bf7"),
                            DateTimeOfPurchase = new DateTime(2022, 1, 6, 13, 0, 0, 0, DateTimeKind.Unspecified),
                            IsCompleted = true,
                            UserId = new Guid("668abb5d-51f7-4db1-b3b4-69b3fc32fa6e")
                        });
                });

            modelBuilder.Entity("TeretanaApi.Entities.BasketEquipment", b =>
                {
                    b.Property<Guid>("BasketId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EquipmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("BasketId", "EquipmentId");

                    b.HasIndex("EquipmentId");

                    b.ToTable("BasketEquipment");

                    b.HasData(
                        new
                        {
                            BasketId = new Guid("6d4550ec-122d-4bd1-a823-d136edd94bf7"),
                            EquipmentId = new Guid("5cd97245-918b-4ba7-9068-3158aeb24feb"),
                            Quantity = 2
                        });
                });

            modelBuilder.Entity("TeretanaApi.Entities.BasketSuplement", b =>
                {
                    b.Property<Guid>("BasketId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SuplementId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("BasketId", "SuplementId");

                    b.HasIndex("SuplementId");

                    b.ToTable("BasketSuplement");

                    b.HasData(
                        new
                        {
                            BasketId = new Guid("6d4550ec-122d-4bd1-a823-d136edd94bf7"),
                            SuplementId = new Guid("9e6bb816-2db3-46d7-91f9-0a175578f4bd"),
                            Quantity = 1
                        });
                });

            modelBuilder.Entity("TeretanaApi.Entities.Equipment", b =>
                {
                    b.Property<Guid>("EquipmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("EquipmentTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("PriceId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("EquipmentId");

                    b.HasIndex("EquipmentTypeId");

                    b.ToTable("Equipments");

                    b.HasData(
                        new
                        {
                            EquipmentId = new Guid("5cd97245-918b-4ba7-9068-3158aeb24feb"),
                            Description = "Gumirane bučice sa hromiranim rukohvatom",
                            EquipmentTypeId = new Guid("3e25fa5b-5717-4722-9d33-d05db2f5733b"),
                            Manufacturer = "Kina",
                            Name = "HEX BUČICE, PROFESIONALNE FIKSNE GUMIRANE 2.5kg",
                            Price = 350.0,
                            PriceId = "",
                            ProductId = "",
                            Quantity = 10
                        },
                        new
                        {
                            EquipmentId = new Guid("bd659cae-3bd6-4a1e-8bce-3d19b666548d"),
                            Description = "Liveni tegovi Fi 30 promera rupe 30mm odnosno u Fi 30 standardu. Idealni za kućno vežbanje i odgovaraju za sve šipke Fi 30.Liveni teg se može koristiti za male šipke za bučice i za velike prave šipke za trening benča, ramena, mrtvog dizanja i sl.Ploče su izlivene od metala i farbane u crno.",
                            EquipmentTypeId = new Guid("acc47e70-1611-4691-b2d2-81eb1ed0d30c"),
                            Manufacturer = "Capriolo",
                            Name = "LIVENI TEGOVI FI30 10kg",
                            Price = 2600.0,
                            PriceId = "",
                            ProductId = "",
                            Quantity = 8
                        });
                });

            modelBuilder.Entity("TeretanaApi.Entities.EquipmentType", b =>
                {
                    b.Property<Guid>("EquipmentTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EquipmentTypeId");

                    b.ToTable("EquipmentTypes");

                    b.HasData(
                        new
                        {
                            EquipmentTypeId = new Guid("3e25fa5b-5717-4722-9d33-d05db2f5733b"),
                            Name = "Bučice"
                        },
                        new
                        {
                            EquipmentTypeId = new Guid("acc47e70-1611-4691-b2d2-81eb1ed0d30c"),
                            Name = "Tegovi"
                        });
                });

            modelBuilder.Entity("TeretanaApi.Entities.GroupTraining", b =>
                {
                    b.Property<Guid>("GroupTrainingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ActualUserCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTimeOfGroupTraining")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("GroupTrainingTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TrainerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("UserCapacity")
                        .HasColumnType("int");

                    b.HasKey("GroupTrainingId");

                    b.HasIndex("GroupTrainingTypeId");

                    b.HasIndex("TrainerId");

                    b.ToTable("GroupTrainings");

                    b.HasData(
                        new
                        {
                            GroupTrainingId = new Guid("d2153f69-fe08-41b4-8256-c693c16d30ec"),
                            ActualUserCount = 15,
                            DateTimeOfGroupTraining = new DateTime(2022, 1, 7, 18, 0, 0, 0, DateTimeKind.Unspecified),
                            GroupTrainingTypeId = new Guid("e1d2a65b-e62e-4b0e-b6b3-fbdaf9ee013b"),
                            TrainerId = new Guid("35c20dc1-e401-4e08-8b48-4b058a4388b5"),
                            UserCapacity = 20
                        },
                        new
                        {
                            GroupTrainingId = new Guid("df27a844-f104-4ef2-9ddb-cfc49cee6a57"),
                            ActualUserCount = 15,
                            DateTimeOfGroupTraining = new DateTime(2022, 1, 7, 13, 0, 0, 0, DateTimeKind.Unspecified),
                            GroupTrainingTypeId = new Guid("383ed840-cd75-4c7b-9b20-a2bc74c4b25e"),
                            TrainerId = new Guid("35c20dc1-e401-4e08-8b48-4b058a4388b5"),
                            UserCapacity = 20
                        });
                });

            modelBuilder.Entity("TeretanaApi.Entities.GroupTrainingType", b =>
                {
                    b.Property<Guid>("GroupTrainingTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GroupTrainingTypeId");

                    b.ToTable("GroupTrainingTypes");

                    b.HasData(
                        new
                        {
                            GroupTrainingTypeId = new Guid("383ed840-cd75-4c7b-9b20-a2bc74c4b25e"),
                            Description = "Jak i funkcionalan trbušni zid predstavlja temelj za bavljenje bilo kojim sportom ili fizičkom aktivnošću. Dominantne mišićne grupe koje se aktiviraju prilikom ovog načina treniranja su mišići donjih ekstremiteta, trbušnih i leđnih, kao i gluteus.",
                            Duration = 60,
                            Name = "Glute & core"
                        },
                        new
                        {
                            GroupTrainingTypeId = new Guid("e1d2a65b-e62e-4b0e-b6b3-fbdaf9ee013b"),
                            Description = "Power Pump trening aktivira celo telo, svaku mišićnu grupu, noge, leđa, grudi, ramena, ruke i trbušno jezgro. Opterećivanjem celog tela na svakom treningu sa tegovima i velikim brojem ponavljanja, značajno se utiče na sagorevanje kalorija, smanjivanje masnog tkiva, kao i izgradnju mišične mase.",
                            Duration = 45,
                            Name = "Power pump"
                        });
                });

            modelBuilder.Entity("TeretanaApi.Entities.Membership", b =>
                {
                    b.Property<Guid>("MembershipId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateTimeOfPayment")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("MembershipTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MembershipId");

                    b.HasIndex("MembershipTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("Memberships");

                    b.HasData(
                        new
                        {
                            MembershipId = new Guid("1a1ae6ea-5cf4-419a-a5ab-5888aa177a34"),
                            DateTimeOfPayment = new DateTime(2022, 1, 4, 13, 0, 0, 0, DateTimeKind.Unspecified),
                            MembershipTypeId = new Guid("b4eac379-5cf2-4caa-807a-253deb228a59"),
                            UserId = new Guid("668abb5d-51f7-4db1-b3b4-69b3fc32fa6e")
                        },
                        new
                        {
                            MembershipId = new Guid("c02e8458-930f-4e0d-bd28-66361dd72f85"),
                            DateTimeOfPayment = new DateTime(2022, 1, 4, 13, 0, 0, 0, DateTimeKind.Unspecified),
                            MembershipTypeId = new Guid("22efe84a-c425-4b2c-8b40-fa00e934c18b"),
                            UserId = new Guid("17b66c64-185f-48e0-9901-b322b8523760")
                        });
                });

            modelBuilder.Entity("TeretanaApi.Entities.MembershipType", b =>
                {
                    b.Property<Guid>("MembershipTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfGroupTrainings")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfTrainings")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("PriceId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MembershipTypeId");

                    b.ToTable("MembershipTypes");

                    b.HasData(
                        new
                        {
                            MembershipTypeId = new Guid("22efe84a-c425-4b2c-8b40-fa00e934c18b"),
                            Name = "30 treninga",
                            NumberOfGroupTrainings = 0,
                            NumberOfTrainings = 30,
                            Price = 3000.0,
                            PriceId = "",
                            ProductId = ""
                        },
                        new
                        {
                            MembershipTypeId = new Guid("b4eac379-5cf2-4caa-807a-253deb228a59"),
                            Name = "10 grupnih treninga",
                            NumberOfGroupTrainings = 10,
                            NumberOfTrainings = 0,
                            Price = 2000.0,
                            PriceId = "",
                            ProductId = ""
                        });
                });

            modelBuilder.Entity("TeretanaApi.Entities.Suplement", b =>
                {
                    b.Property<Guid>("SuplementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("PriceId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid>("SuplementTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("SuplementId");

                    b.HasIndex("SuplementTypeId");

                    b.ToTable("Suplements");

                    b.HasData(
                        new
                        {
                            SuplementId = new Guid("9e6bb816-2db3-46d7-91f9-0a175578f4bd"),
                            Description = "Amino Whey Hydro protein The Nutrition. je preko 86% Protein i sadrži gotovo ništa Masti ili Ugljenih Hidrata. Pruža sinergističku mešavinu nakvalitetnijih izvora Proteina, koji ne samo da povećavaju sintezu Proteina, volumen ćelija i misićni anabolizam, dok istovremeno štite zglobove i hrskavice, već i jačaju imuni sistem i smanjuju nivo lošeg (LDL) Holesterola i smanjuju mogućnost Srčanih Bolesti.",
                            Manufacturer = "The Nutrition",
                            Name = "THE AMINO WHEY HYDRO PROTEIN 3.500 G",
                            Price = 7390.0,
                            PriceId = "",
                            ProductId = "",
                            Quantity = 10,
                            SuplementTypeId = new Guid("645b8bb6-0fa8-4082-8c8c-7fef241b7bce")
                        },
                        new
                        {
                            SuplementId = new Guid("d6e14c22-bc87-44ce-8c9d-5196e388d621"),
                            Description = "100% Whey Protein je napredna formula proteina surutke, napravljena za sve sportaše, koji žele više mišića, više snage i brži oporavak. Svaki obrok osigurava 22g whey proteina surutke i 5 grama aminokiselina razgranatog lanca (BCAA), te sa 2,4 grama možda i najbitnije aminokiseline L-leucin.",
                            Manufacturer = "The Nutrition",
                            Name = "THE BASIC 100% WHEY PROTEIN 1800 GRAMA",
                            Price = 3600.0,
                            PriceId = "",
                            ProductId = "",
                            Quantity = 15,
                            SuplementTypeId = new Guid("645b8bb6-0fa8-4082-8c8c-7fef241b7bce")
                        },
                        new
                        {
                            SuplementId = new Guid("38307eb9-669e-4c5a-b17c-237f6e52f5e2"),
                            Description = "THE Kreatin monohidrat povećava sintezu molekula ATP (adenozin-tri-fosfata), koja direktno utiče na povećanje snage i izdržljivosti kod anaerobnih aktivnosti,a samim tim i jacu prokrvljenost misica i na taj nacin indirektan uticaj na misicnu masu.",
                            Manufacturer = "The Nutrition",
                            Name = "THE CREATINE - 1000G (KREATIN MONOHIDRAT)",
                            Price = 3600.0,
                            PriceId = "",
                            ProductId = "",
                            Quantity = 15,
                            SuplementTypeId = new Guid("96fbee9a-2887-4cec-8f8b-a185da06d29b")
                        });
                });

            modelBuilder.Entity("TeretanaApi.Entities.SuplementType", b =>
                {
                    b.Property<Guid>("SuplementTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SuplementTypeId");

                    b.ToTable("SuplementTypes");

                    b.HasData(
                        new
                        {
                            SuplementTypeId = new Guid("645b8bb6-0fa8-4082-8c8c-7fef241b7bce"),
                            Name = "Protein"
                        },
                        new
                        {
                            SuplementTypeId = new Guid("96fbee9a-2887-4cec-8f8b-a185da06d29b"),
                            Name = "Kreatin"
                        });
                });

            modelBuilder.Entity("TeretanaApi.Entities.Trainer", b =>
                {
                    b.Property<Guid>("TrainerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TrainerId");

                    b.ToTable("Trainers");
                });

            modelBuilder.Entity("TeretanaApi.Entities.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NumberOfGroupTraings")
                        .HasColumnType("int");

                    b.Property<int?>("NumberOfTrainings")
                        .HasColumnType("int");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<Guid>("UserTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId");

                    b.HasIndex("AddressId");

                    b.HasIndex("UserTypeId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("17b66c64-185f-48e0-9901-b322b8523760"),
                            AddressId = new Guid("d3a4cf13-5404-426a-8410-4573ed67214c"),
                            ContactNumber = "0665235235",
                            Email = "gavrilo@gmail.com",
                            FirstName = "Gavrilo",
                            LastName = "Stanic",
                            NumberOfGroupTraings = 0,
                            NumberOfTrainings = 3,
                            Password = new byte[] { 160, 95, 44, 227, 117, 91, 167, 174, 170, 160, 150, 98, 133, 78, 34, 32, 198, 62, 128, 76, 119, 177, 81, 70, 84, 28, 104, 153, 0, 194, 3, 228, 28, 117, 129, 1, 140, 24, 173, 85, 139, 101, 46, 3, 58, 56, 104, 30, 216, 141, 3, 133, 44, 245, 62, 153, 213, 62, 160, 130, 94, 150, 164, 28 },
                            PasswordSalt = new byte[] { 58, 195, 75, 226, 153, 74, 170, 54, 92, 165, 4, 67, 12, 128, 75, 13, 57, 34, 141, 13, 28, 254, 214, 185, 45, 1, 61, 100, 119, 212, 36, 177, 236, 111, 189, 255, 26, 157, 3, 26, 195, 128, 162, 178, 126, 222, 208, 161, 19, 237, 178, 176, 202, 85, 120, 217, 241, 252, 117, 205, 73, 160, 247, 181, 153, 150, 234, 95, 209, 56, 218, 71, 194, 123, 108, 210, 176, 201, 76, 244, 14, 74, 121, 213, 26, 24, 49, 97, 132, 122, 153, 108, 95, 6, 211, 233, 222, 202, 6, 149, 152, 239, 67, 64, 52, 136, 185, 22, 192, 78, 13, 58, 41, 197, 223, 192, 6, 89, 95, 115, 117, 142, 78, 56, 79, 197, 33, 179 },
                            UserTypeId = new Guid("7f342d88-3f53-490f-a3cd-1186251af607")
                        },
                        new
                        {
                            UserId = new Guid("668abb5d-51f7-4db1-b3b4-69b3fc32fa6e"),
                            AddressId = new Guid("d3a4cf13-5404-426a-8410-4573ed67214c"),
                            ContactNumber = "06653252354",
                            Email = "marko@gmail.com",
                            FirstName = "Marko",
                            LastName = "Stanic",
                            NumberOfGroupTraings = 8,
                            NumberOfTrainings = 0,
                            Password = new byte[] { 28, 86, 82, 126, 228, 82, 110, 86, 243, 10, 133, 129, 14, 123, 215, 53, 139, 249, 197, 194, 92, 102, 167, 188, 78, 41, 159, 86, 222, 32, 25, 217, 33, 26, 30, 225, 78, 38, 172, 50, 46, 44, 31, 24, 75, 139, 238, 123, 212, 169, 86, 97, 165, 183, 14, 8, 123, 199, 217, 31, 9, 196, 246, 51 },
                            PasswordSalt = new byte[] { 191, 85, 233, 222, 154, 151, 33, 95, 113, 237, 219, 10, 255, 169, 81, 188, 161, 212, 126, 200, 0, 161, 154, 158, 236, 168, 233, 91, 131, 120, 182, 230, 74, 9, 64, 166, 181, 49, 218, 211, 106, 127, 34, 170, 150, 11, 147, 140, 56, 7, 108, 71, 44, 221, 6, 99, 159, 234, 142, 77, 81, 95, 64, 154, 103, 134, 131, 145, 75, 184, 136, 27, 30, 172, 149, 36, 28, 100, 168, 61, 255, 77, 101, 222, 125, 231, 212, 169, 161, 212, 2, 207, 47, 187, 11, 196, 3, 212, 56, 40, 7, 98, 136, 26, 39, 135, 100, 21, 106, 111, 131, 136, 81, 108, 213, 35, 227, 124, 18, 188, 119, 194, 65, 170, 22, 47, 149, 110 },
                            UserTypeId = new Guid("6bc0cc6a-c600-4ae9-8e2e-d4b61b601701")
                        },
                        new
                        {
                            UserId = new Guid("35c20dc1-e401-4e08-8b48-4b058a4388b5"),
                            AddressId = new Guid("d3a4cf13-5404-426a-8410-4573ed67214c"),
                            ContactNumber = "0665235325",
                            Email = "Petar@gmail.com",
                            FirstName = "Petar",
                            LastName = "Markovic",
                            NumberOfGroupTraings = 0,
                            NumberOfTrainings = 0,
                            Password = new byte[] { 42, 116, 69, 83, 92, 59, 17, 1, 48, 82, 214, 39, 137, 139, 108, 22, 93, 123, 200, 74, 38, 196, 159, 241, 224, 78, 152, 236, 189, 217, 180, 131, 9, 176, 199, 196, 172, 40, 194, 235, 227, 10, 248, 78, 254, 152, 252, 84, 240, 47, 174, 154, 220, 72, 96, 48, 61, 70, 176, 221, 244, 119, 174, 5 },
                            PasswordSalt = new byte[] { 196, 38, 220, 45, 73, 214, 47, 122, 241, 124, 31, 95, 131, 32, 148, 16, 28, 250, 178, 251, 113, 156, 230, 214, 124, 190, 72, 67, 194, 241, 135, 245, 220, 82, 122, 239, 209, 17, 163, 142, 62, 57, 230, 177, 250, 57, 147, 169, 252, 134, 55, 221, 75, 141, 110, 209, 90, 90, 147, 196, 15, 59, 28, 141, 216, 102, 204, 2, 182, 0, 131, 218, 173, 222, 159, 41, 213, 242, 123, 109, 51, 163, 184, 101, 231, 165, 187, 86, 50, 93, 184, 165, 130, 44, 52, 192, 0, 108, 228, 27, 151, 173, 142, 106, 65, 241, 32, 78, 116, 48, 228, 249, 183, 0, 143, 196, 2, 39, 159, 217, 145, 157, 119, 114, 5, 245, 73, 135 },
                            UserTypeId = new Guid("51371a38-00fa-4171-be2c-002e483ed463")
                        });
                });

            modelBuilder.Entity("TeretanaApi.Entities.UserType", b =>
                {
                    b.Property<Guid>("UserTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserTypeId");

                    b.ToTable("UserTypes");

                    b.HasData(
                        new
                        {
                            UserTypeId = new Guid("7f342d88-3f53-490f-a3cd-1186251af607"),
                            Name = "Admin"
                        },
                        new
                        {
                            UserTypeId = new Guid("6bc0cc6a-c600-4ae9-8e2e-d4b61b601701"),
                            Name = "User"
                        },
                        new
                        {
                            UserTypeId = new Guid("51371a38-00fa-4171-be2c-002e483ed463"),
                            Name = "Trainer"
                        });
                });

            modelBuilder.Entity("GroupTrainingUser", b =>
                {
                    b.HasOne("TeretanaApi.Entities.GroupTraining", null)
                        .WithMany()
                        .HasForeignKey("GroupTrainingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TeretanaApi.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TeretanaApi.Entities.Basket", b =>
                {
                    b.HasOne("TeretanaApi.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TeretanaApi.Entities.BasketEquipment", b =>
                {
                    b.HasOne("TeretanaApi.Entities.Basket", "Basket")
                        .WithMany("Equipments")
                        .HasForeignKey("BasketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TeretanaApi.Entities.Equipment", "Equipment")
                        .WithMany()
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Basket");

                    b.Navigation("Equipment");
                });

            modelBuilder.Entity("TeretanaApi.Entities.BasketSuplement", b =>
                {
                    b.HasOne("TeretanaApi.Entities.Basket", "Basket")
                        .WithMany("Suplements")
                        .HasForeignKey("BasketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TeretanaApi.Entities.Suplement", "Suplement")
                        .WithMany()
                        .HasForeignKey("SuplementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Basket");

                    b.Navigation("Suplement");
                });

            modelBuilder.Entity("TeretanaApi.Entities.Equipment", b =>
                {
                    b.HasOne("TeretanaApi.Entities.EquipmentType", "EquipmentType")
                        .WithMany()
                        .HasForeignKey("EquipmentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EquipmentType");
                });

            modelBuilder.Entity("TeretanaApi.Entities.GroupTraining", b =>
                {
                    b.HasOne("TeretanaApi.Entities.GroupTrainingType", "GroupTrainingType")
                        .WithMany()
                        .HasForeignKey("GroupTrainingTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TeretanaApi.Entities.User", "Trainer")
                        .WithMany()
                        .HasForeignKey("TrainerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("GroupTrainingType");

                    b.Navigation("Trainer");
                });

            modelBuilder.Entity("TeretanaApi.Entities.Membership", b =>
                {
                    b.HasOne("TeretanaApi.Entities.MembershipType", "MembershipType")
                        .WithMany()
                        .HasForeignKey("MembershipTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TeretanaApi.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MembershipType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TeretanaApi.Entities.Suplement", b =>
                {
                    b.HasOne("TeretanaApi.Entities.SuplementType", "SuplementType")
                        .WithMany()
                        .HasForeignKey("SuplementTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SuplementType");
                });

            modelBuilder.Entity("TeretanaApi.Entities.User", b =>
                {
                    b.HasOne("TeretanaApi.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TeretanaApi.Entities.UserType", "UserType")
                        .WithMany()
                        .HasForeignKey("UserTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("UserType");
                });

            modelBuilder.Entity("TeretanaApi.Entities.Basket", b =>
                {
                    b.Navigation("Equipments");

                    b.Navigation("Suplements");
                });
#pragma warning restore 612, 618
        }
    }
}