using Microsoft.EntityFrameworkCore;

namespace TeretanaApi.Entities.DataContext
{
    public class GymContext : DbContext
    {

        private readonly IConfiguration _configuration;
        public GymContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            this._configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("GymDb"));
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Equipment> Equipments {get; set; }
        public DbSet<Suplement> Suplements { get; set; }
        public DbSet<EquipmentType> EquipmentTypes { get; set; }
        public DbSet<SuplementType> SuplementTypes { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<GroupTrainingType> GroupTrainingTypes { get; set; }
        public DbSet<GroupTraining> GroupTrainings { get; set; }
        public DbSet<BasketEquipment> BasketEquipment { get; set; }
        public DbSet<BasketSuplement> BasketSuplement { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BasketEquipment>()
                .HasKey(be => new { be.BasketId, be.EquipmentId });
            builder.Entity<BasketEquipment>()
                .HasOne(be => be.Basket)
                .WithMany(b => b.Equipments)
                .HasForeignKey(be => be.BasketId);
           

            builder.Entity<BasketSuplement>()
                .HasKey(be => new { be.BasketId, be.SuplementId });
            builder.Entity<BasketSuplement>()
                .HasOne(be => be.Basket)
                .WithMany(b => b.Suplements)
                .HasForeignKey(be => be.BasketId);


            builder.Entity<GroupTraining>()
                .HasOne(g => g.Trainer)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
        
          


            builder.Entity<MembershipType>()
                .HasData(new
                {
                    MembershipTypeId = Guid.Parse("22efe84a-c425-4b2c-8b40-fa00e934c18b"),
                    Name = "30 treninga",
                    NumberOfTrainings = 30,
                    NumberOfGroupTrainings = 0,
                    Price = 3000.00
                });

            builder.Entity<MembershipType>()
               .HasData(new
               {
                   MembershipTypeId = Guid.Parse("b4eac379-5cf2-4caa-807a-253deb228a59"),
                   Name = "10 grupnih treninga",
                   NumberOfTrainings = 0,
                   NumberOfGroupTrainings = 10,
                   Price = 2000.00
               });

            builder.Entity<UserType>()
                .HasData(new
                {
                    UserTypeId = Guid.Parse("7f342d88-3f53-490f-a3cd-1186251af607"),
                    Name = "Admin"
                });
            builder.Entity<UserType>()
                .HasData(new
                {
                    UserTypeId = Guid.Parse("6bc0cc6a-c600-4ae9-8e2e-d4b61b601701"),
                    Name = "User"
                });
            builder.Entity<UserType>()
               .HasData(new
               {
                   UserTypeId = Guid.Parse("51371a38-00fa-4171-be2c-002e483ed463"),
                   Name = "Trainer"
               });

            

            builder.Entity<SuplementType>()
                .HasData(new
                {
                    SuplementTypeId = Guid.Parse("645b8bb6-0fa8-4082-8c8c-7fef241b7bce"),
                    Name = "Protein"
                });
            builder.Entity<SuplementType>()
                .HasData(new
                {
                    SuplementTypeId = Guid.Parse("96fbee9a-2887-4cec-8f8b-a185da06d29b"),
                    Name = "Kreatin"
                });

            builder.Entity<Suplement>()
                .HasData(new
                {
                    SuplementId = Guid.Parse("9e6bb816-2db3-46d7-91f9-0a175578f4bd"),
                    Name = "THE AMINO WHEY HYDRO PROTEIN 3.500 G",
                    Description = "Amino Whey Hydro protein The Nutrition. je preko 86% Protein i sadrži gotovo ništa Masti ili Ugljenih Hidrata. Pruža sinergističku mešavinu nakvalitetnijih izvora Proteina, koji ne samo da povećavaju sintezu Proteina, volumen ćelija i misićni anabolizam, dok istovremeno štite zglobove i hrskavice, već i jačaju imuni sistem i smanjuju nivo lošeg (LDL) Holesterola i smanjuju mogućnost Srčanih Bolesti.",
                    Manufacturer = "The Nutrition",
                    Quantity = 10,
                    Price = 7390.00,
                    SuplementTypeId = Guid.Parse("645b8bb6-0fa8-4082-8c8c-7fef241b7bce")

                });
            builder.Entity<Suplement>()
               .HasData(new
               {
                   SuplementId = Guid.Parse("d6e14c22-bc87-44ce-8c9d-5196e388d621"),
                   Name = "THE BASIC 100% WHEY PROTEIN 1800 GRAMA",
                   Description = "100% Whey Protein je napredna formula proteina surutke, napravljena za sve sportaše, koji žele više mišića, više snage i brži oporavak. Svaki obrok osigurava 22g whey proteina surutke i 5 grama aminokiselina razgranatog lanca (BCAA), te sa 2,4 grama možda i najbitnije aminokiseline L-leucin.",
                   Manufacturer = "The Nutrition",
                   Quantity = 15,
                   Price = 3600.00,
                   SuplementTypeId = Guid.Parse("645b8bb6-0fa8-4082-8c8c-7fef241b7bce")

               });

            builder.Entity<Suplement>()
            .HasData(new
            {
                SuplementId = Guid.Parse("38307eb9-669e-4c5a-b17c-237f6e52f5e2"),
                Name = "THE CREATINE - 1000G (KREATIN MONOHIDRAT)",
                Description = "THE Kreatin monohidrat povećava sintezu molekula ATP (adenozin-tri-fosfata), koja direktno utiče na povećanje snage i izdržljivosti kod anaerobnih aktivnosti,a samim tim i jacu prokrvljenost misica i na taj nacin indirektan uticaj na misicnu masu.",
                Manufacturer = "The Nutrition",
                Quantity = 15,
                Price = 3600.00,
                SuplementTypeId = Guid.Parse("96fbee9a-2887-4cec-8f8b-a185da06d29b")

            });

            builder.Entity<EquipmentType>()
                .HasData(new
                {
                    EquipmentTypeId = Guid.Parse("3e25fa5b-5717-4722-9d33-d05db2f5733b"),
                    Name = "Bučice"
                });
            builder.Entity<EquipmentType>()
                .HasData(new
                {
                    EquipmentTypeId = Guid.Parse("acc47e70-1611-4691-b2d2-81eb1ed0d30c"),
                    Name = "Tegovi"
                });

            builder.Entity<Equipment>()
                .HasData(new
                {
                    EquipmentId = Guid.Parse("5cd97245-918b-4ba7-9068-3158aeb24feb"),
                    Name = "HEX BUČICE, PROFESIONALNE FIKSNE GUMIRANE 2.5kg",
                    Description = "Gumirane bučice sa hromiranim rukohvatom",
                    Manufacturer = "Kina",
                    Quantity = 10,
                    Price = 350.00,
                    EquipmentTypeId = Guid.Parse("3e25fa5b-5717-4722-9d33-d05db2f5733b")

                });
            builder.Entity<Equipment>()
               .HasData(new
               {
                   EquipmentId = Guid.Parse("bd659cae-3bd6-4a1e-8bce-3d19b666548d"),
                   Name = "LIVENI TEGOVI FI30 10kg",
                   Description = "Liveni tegovi Fi 30 promera rupe 30mm odnosno u Fi 30 standardu. Idealni za kućno vežbanje i odgovaraju za sve šipke Fi 30.Liveni teg se može koristiti za male šipke za bučice i za velike prave šipke za trening benča, ramena, mrtvog dizanja i sl.Ploče su izlivene od metala i farbane u crno.",
                   Manufacturer = "Capriolo",
                   Quantity = 8,
                   Price = 2600.00,
                   EquipmentTypeId = Guid.Parse("acc47e70-1611-4691-b2d2-81eb1ed0d30c")

               });

            builder.Entity<GroupTrainingType>()
                .HasData(new
                {
                    GroupTrainingTypeId = Guid.Parse("383ed840-cd75-4c7b-9b20-a2bc74c4b25e"),
                    Name = "Glute & core",
                    Description = "Jak i funkcionalan trbušni zid predstavlja temelj za bavljenje bilo kojim sportom ili fizičkom aktivnošću. Dominantne mišićne grupe koje se aktiviraju prilikom ovog načina treniranja su mišići donjih ekstremiteta, trbušnih i leđnih, kao i gluteus.",
                    Duration = 60
                });
            builder.Entity<GroupTrainingType>()
                .HasData(new
                {
                    GroupTrainingTypeId = Guid.Parse("e1d2a65b-e62e-4b0e-b6b3-fbdaf9ee013b"),
                    Name = "Power pump",
                    Description = "Power Pump trening aktivira celo telo, svaku mišićnu grupu, noge, leđa, grudi, ramena, ruke i trbušno jezgro. Opterećivanjem celog tela na svakom treningu sa tegovima i velikim brojem ponavljanja, značajno se utiče na sagorevanje kalorija, smanjivanje masnog tkiva, kao i izgradnju mišične mase.",
                    Duration = 45
                });


            builder.Entity<GroupTraining>()
                .HasData(new
                {
                    GroupTrainingId = Guid.Parse("d2153f69-fe08-41b4-8256-c693c16d30ec"),
                    DateTimeOfGroupTraining = DateTime.Parse("07/1/2022 18:00:00"),
                    GroupTrainingTypeId = Guid.Parse("e1d2a65b-e62e-4b0e-b6b3-fbdaf9ee013b"),
                    TrainerId = Guid.Parse("35c20dc1-e401-4e08-8b48-4b058a4388b5")

                });
            builder.Entity<GroupTraining>()
               .HasData(new
               {
                   GroupTrainingId = Guid.Parse("df27a844-f104-4ef2-9ddb-cfc49cee6a57"),
                   DateTimeOfGroupTraining = DateTime.Parse("07/1/2022 13:00:00"),
                   GroupTrainingTypeId = Guid.Parse("383ed840-cd75-4c7b-9b20-a2bc74c4b25e"),
                   TrainerId = Guid.Parse("35c20dc1-e401-4e08-8b48-4b058a4388b5")

               });

            builder.Entity<Address>()
                .HasData(new
                {
                    AddressId = Guid.Parse("d3a4cf13-5404-426a-8410-4573ed67214c"),
                    City = "Novi Sad",
                    PostalCode = "21000",
                    Street = "Branka Ilica",
                    StreetNumber = "1"
                });
            byte[] password;
            byte[] salt;
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                salt = hmac.Key;
                password = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes("password"));
            }
            
            builder.Entity<User>()
                .HasData(new
                {
                    UserId = Guid.Parse("17b66c64-185f-48e0-9901-b322b8523760"),
                    FirstName = "Gavrilo",
                    LastName = "Stanic",
                    Email = "gavrilo@gmail.com",
                    ContactNumber = "0665235235",
                    Password = password,
                    PasswordSalt = salt,
                    NumberOfTrainings = 3,
                    NumberOfGroupTraings = 0,
                    AddressId = Guid.Parse("d3a4cf13-5404-426a-8410-4573ed67214c"),
                    UserTypeId = Guid.Parse("7F342D88-3F53-490F-A3CD-1186251AF607")

                });
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                salt = hmac.Key;
                password = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes("password"));
            }
            builder.Entity<User>()
              .HasData(new
              {
                  UserId = Guid.Parse("668abb5d-51f7-4db1-b3b4-69b3fc32fa6e"),
                  FirstName = "Marko",
                  LastName = "Stanic",
                  ContactNumber = "06653252354",
                  Email = "marko@gmail.com",
                  Password = password,
                  PasswordSalt = salt,
                  NumberOfTrainings = 0,
                  NumberOfGroupTraings = 8,
                  AddressId = Guid.Parse("d3a4cf13-5404-426a-8410-4573ed67214c"),
                  UserTypeId = Guid.Parse("6bc0cc6a-c600-4ae9-8e2e-d4b61b601701")

              });
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                salt = hmac.Key;
                password = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes("password"));
            }
            builder.Entity<User>()
              .HasData(new
              {
                  UserId = Guid.Parse("35c20dc1-e401-4e08-8b48-4b058a4388b5"),
                  FirstName = "Petar",
                  LastName = "Markovic",
                  Email = "Petar@gmail.com",
                  ContactNumber = "0665235325",
                  Password = password,
                  PasswordSalt = salt,
                  NumberOfTrainings = 0,
                  NumberOfGroupTraings = 0,
                  AddressId = Guid.Parse("d3a4cf13-5404-426a-8410-4573ed67214c"),
                  UserTypeId = Guid.Parse("51371a38-00fa-4171-be2c-002e483ed463")

              });

            builder.Entity<Basket>()
                .HasData(new
                {
                    BasketId = Guid.Parse("6d4550ec-122d-4bd1-a823-d136edd94bf7"),
                    DateTimeOfPurchase = DateTime.Parse("06/1/2022 13:00:00"),
                    UserId = Guid.Parse("668abb5d-51f7-4db1-b3b4-69b3fc32fa6e"),
                    IsCompleted = true
                });
            builder.Entity<BasketEquipment>()
                .HasData(new
                {
                    BasketId = Guid.Parse("6d4550ec-122d-4bd1-a823-d136edd94bf7"),
                    EquipmentId = Guid.Parse("5cd97245-918b-4ba7-9068-3158aeb24feb"),
                    Quantity = 2
                }) ;
            builder.Entity<BasketSuplement>()
                .HasData(new
                {
                    BasketId = Guid.Parse("6d4550ec-122d-4bd1-a823-d136edd94bf7"),
                    SuplementId = Guid.Parse("9e6bb816-2db3-46d7-91f9-0a175578f4bd"),
                    Quantity = 1
                });

            builder.Entity<Membership>()
                .HasData(new
                {
                    MembershipId = Guid.Parse("1a1ae6ea-5cf4-419a-a5ab-5888aa177a34"),
                    UserId = Guid.Parse("668abb5d-51f7-4db1-b3b4-69b3fc32fa6e"),
                    DateTimeOfPayment = DateTime.Parse("04/1/2022 13:00:00"),
                    MembershipTypeId = Guid.Parse("b4eac379-5cf2-4caa-807a-253deb228a59")

                });

            builder.Entity<Membership>()
               .HasData(new
               {
                   MembershipId = Guid.Parse("c02e8458-930f-4e0d-bd28-66361dd72f85"),
                   UserId = Guid.Parse("17b66c64-185f-48e0-9901-b322b8523760"),
                   DateTimeOfPayment = DateTime.Parse("04/1/2022 13:00:00"),
                   MembershipTypeId = Guid.Parse("22efe84a-c425-4b2c-8b40-fa00e934c18b")

               });

            builder.Entity<GroupTraining>()
              .HasMany(g => g.Users)
              .WithMany(u => u.GroupTrainings)
              .UsingEntity<Dictionary<string, object>>(
                  "GroupTrainingUser",
                  r => r.HasOne<User>().WithMany().HasForeignKey("UserId"),
                  l => l.HasOne<GroupTraining>().WithMany().HasForeignKey("GroupTrainingId"),
                  je =>
                  {
                      je.HasKey("GroupTrainingId", "UserId");
                      je.HasData(
                          new
                          {
                              UserId = Guid.Parse("668abb5d-51f7-4db1-b3b4-69b3fc32fa6e"),
                              GroupTrainingId = Guid.Parse("d2153f69-fe08-41b4-8256-c693c16d30ec")
                          });

                  });
        }

    }
    

    


}
