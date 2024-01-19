using BCrypt.Net;
using LibraryManagement.Domain.Configurations;
using LibraryManagement.Domain.Configurations.EnumConfigurations;
using LibraryManagement.Domain.Entities.EnumEntities;
using LibraryManagement.Domain.Entities.JoiningEntities;
using LibraryManagement.Domain.Entities.RegularEntities;
using LibraryManagement.Utils.Enums;
using Microsoft.EntityFrameworkCore;
using MembershipType = LibraryManagement.Domain.Entities.RegularEntities.MembershipType;

namespace LibraryManagement.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Genre> Genere { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
        public DbSet<BookAuthor> BookAuthor { get; set; }
        public DbSet<BookGenre> BookGenere { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<Loan> Loan { get; set; }
        public DbSet<Membership> Membership { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<Bookings> Bookings { get; set; }

        public DbSet<User> User { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            new UserConfiguration().Configure(builder.Entity<User>());
            new GenreConfiguration().Configure(builder.Entity<Genre>());
            new PublisherConfiguration().Configure(builder.Entity<Publisher>());
            new BookAuthorConfiguration().Configure(builder.Entity<BookAuthor>());
            new BookGenreConfiguration().Configure(builder.Entity<BookGenre>());
            new AuthorConfiguration().Configure(builder.Entity<Author>());
            new BookConfiguration().Configure(builder.Entity<Book>());
            new LoanConfiguration().Configure(builder.Entity<Loan>());
            new MembershipConfiguration().Configure(builder.Entity<Membership>());
            new MembershipTypeConfiguration().Configure(builder.Entity<MembershipType>());
            new BookingConfiguration().Configure(builder.Entity<Bookings>());

            AddDefaultEnums(builder);
            SeedUsers(builder);
        }

        private void AddDefaultEnums(ModelBuilder builder)
        {
            AddGeneres(builder);
            AddMembershipTypes(builder);
            AddPublishers(builder);
            AddAuthors(builder);
        }

        private void AddGeneres(ModelBuilder builder)
        {
            var genres = new List<Genre>
            {
                new Genre 
                { 
                    Id = 1, 
                    Name = "Action"
                },
                new Genre
                {
                    Id = 2,
                    Name = "Adventure"
                },
                new Genre
                {
                    Id = 3,
                    Name = "Biography"
                },
                new Genre
                {
                    Id = 4,
                    Name = "Children"
                },
                new Genre
                {
                    Id = 5,
                    Name = "Classics"
                },
                new Genre
                {
                    Id = 6,
                    Name = "Comics"
                },
                new Genre
                {
                    Id = 7,
                    Name = "Contemporary"
                },
                new Genre
                {
                    Id = 8,
                    Name = "Cookbooks"
                },
                new Genre
                {
                    Id = 9,
                    Name = "Crime"
                },
                new Genre
                {
                    Id = 10,
                    Name = "Fantasy"
                },
                new Genre
                {
                    Id = 11,
                    Name = "Fiction"
                },
                new Genre
                {
                    Id = 12,
                    Name = "GraphicNovel"
                },
                new Genre
                {
                    Id = 13,
                    Name = "HistoricalFiction"
                },
                new Genre
                {
                    Id = 14,
                    Name = "Horror"
                },
                new Genre
                {
                    Id = 15,
                    Name = "Humor"
                },
                new Genre
                {
                    Id = 16,
                    Name = "Mystery"
                },
                new Genre
                {
                    Id = 17,
                    Name = "NonFiction"
                },
                new Genre
                {
                    Id = 18,
                    Name = "Paranormal"
                },
                new Genre
                {
                    Id = 19,
                    Name = "Poetry"
                },
                new Genre
                {
                    Id = 20,
                    Name = "Romance"
                },
                new Genre
                {
                    Id = 21,
                    Name = "ScienceFiction"
                },
                new Genre
                {
                    Id = 22,
                    Name = "SelfHelp"
                },
                new Genre
                {
                    Id = 23,
                    Name = "Suspense"
                },
                new Genre
                {
                    Id = 24,
                    Name = "Thriller"
                },
                new Genre
                {
                    Id = 25,
                    Name = "Travel"
                },
                new Genre
                {
                    Id = 26,
                    Name = "Young adult"
                },
                new Genre
                {
                    Id = 27,
                    Name = "Art"
                },
                new Genre
                {
                    Id = 28,
                    Name = "Bussines"
                },
                new Genre
                {
                    Id = 29,
                    Name = "Manga"
                },

            };

            builder.Entity<Genre>().HasData(genres);
        }

        private void AddAuthors(ModelBuilder builder)
        {
            var author1 = new Author {
                Id = Guid.NewGuid(),
                FirstName = "Mihai",
                LastName = "Eminescu",
                DateOfBirth = new DateTime(1850, 1, 15),
                DateOfDeath = new DateTime(1889, 6, 15),
                Biography = "Mihai Eminescu a fost un poet, prozator și jurnalist român, considerat, în general, ca fiind cea mai cunoscută și influentă personalitate din literatura română.",
                Nationality = Enum.GetName(Nationality.Romanian),
                Photo = string.Empty
            };

            builder.Entity<Author>().HasData(author1);
        }

        private void AddPublishers(ModelBuilder builder)
        {
            var publisher1 = new Publisher { Id = 1, Name = "Penguin Random House" };
            var publisher2 = new Publisher { Id = 2, Name = "HarperCollins Publishers" };
            var publisher3 = new Publisher { Id = 3, Name = "Simon & Schuster" };
            var publisher4 = new Publisher { Id = 4, Name = "Hachette Book Group" };

            builder.Entity<Publisher>().HasData(publisher1, publisher2, publisher3, publisher4);
        }

        private void AddMembershipTypes(ModelBuilder builder)
        {
            var youngling = new MembershipType
            { 
                Id = (int)Utils.Enums.MembershipType.Youngling,
                Name = Enum.GetName(Utils.Enums.MembershipType.Youngling),
                NumberOfLoansAllowed = 2,
                NumberOfLoansNeeded = 0,
                Price = 10,
                Badge = string.Empty
            };

            var initiate = new MembershipType
            {
                Id = (int)Utils.Enums.MembershipType.Initiate,
                Name = Enum.GetName(Utils.Enums.MembershipType.Initiate),
                NumberOfLoansAllowed = 4,
                NumberOfLoansNeeded = 10,
                Price = 20,
                Badge = string.Empty
            };

            var padawan = new MembershipType
            {
                Id = (int)Utils.Enums.MembershipType.Padawan,
                Name = Enum.GetName(Utils.Enums.MembershipType.Padawan),
                NumberOfLoansAllowed = 6,
                NumberOfLoansNeeded = 15,
                Price = 30,
                Badge = string.Empty
            };

            var master = new MembershipType
            {
                Id = (int)Utils.Enums.MembershipType.Master,
                Name = Enum.GetName(Utils.Enums.MembershipType.Master),
                NumberOfLoansAllowed = 8,
                NumberOfLoansNeeded = 20,
                Price = 40,
                Badge = string.Empty
            };

            builder.Entity<MembershipType>().HasData(youngling, initiate, padawan, master);
        }

        private void SeedUsers(ModelBuilder builder)
        {
            var password = "Password123!";
            var cryptedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            var adminAccount = new User
            {
                Id = Guid.NewGuid(),
                FirstName = "Library",
                LastName = "Administrator",
                Email = "librarymanager0125@gmail.com",
                Password = cryptedPassword,
                Phone = "+40740535564",
                Address = "Universitatii 13, Suceava, Romania",
                Gender = Domain.Enums.Gender.Male,
                Role = Domain.Enums.Role.Admin,
                DateOfBirth = new DateTime(2000,01,25).ToUniversalTime(),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };


            var userAccount = new User
            {
                Id = new Guid("6976fe0d-f926-4c30-a38c-8f440a1e11ce"),
                FirstName = "Maria",
                LastName = "Elena",
                Email = "maria.cotofrec1@student.usv.ro",
                Password = cryptedPassword,
                Phone = "+40740535564",
                Address = "Suceava, Suceava",
                Gender = Domain.Enums.Gender.Male,
                Role = Domain.Enums.Role.User,
                DateOfBirth = new DateTime(2000, 01, 25).ToUniversalTime(),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            builder.Entity<User>().HasData(adminAccount, userAccount);
        }
    }
}
