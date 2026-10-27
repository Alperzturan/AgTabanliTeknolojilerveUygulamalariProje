using Microsoft.EntityFrameworkCore;
using Michelangelo_s_Board_Game_Cafe.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace Michelangelo_s_Board_Game_Cafe.Data
{
    public class CafeDbContext : IdentityDbContext<AppUser>
    {

        public CafeDbContext(DbContextOptions<CafeDbContext> options)
         : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; } = default!;
        public DbSet<BoardGame> BoardGames { get; set; } = default!;
        public DbSet<CafeTable> CafeTables { get; set; } = default!;
        public DbSet<Reservation> Reservations { get; set; } = default!;
        public DbSet<ReservationGame> ReservationGames { get; set; } = default!;



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Strateji",
                    Description = "Taktik ve derin düşünme gerektiren kutu oyunları."
                },
                new Category
                {
                    Id = 2,
                    Name = "Parti & Eğlence",
                    Description = "Kalabalık gruplar için hızlı ve eğlenceli oyunlar."
                },
                new Category
                {
                    Id = 3,
                    Name = "Dedektiflik & Gizem",
                    Description = "İpuçlarını birleştirip gizemi çözmeye dayalı oyunlar."
                },
                new Category
                {
                    Id = 4,
                    Name = "Aile",
                    Description = "Her yaştan oyuncunun keyifle oynayabileceği oyunlar."
                }
            );

            builder.Entity<CafeTable>().HasData(
                new CafeTable
                {
                    Id = 1,
                    TableNumber = 1,
                    Capacity = 4,
                    IsActive = true
                },
                new CafeTable
                {
                    Id = 2,
                    TableNumber = 2,
                    Capacity = 4,
                    IsActive = true
                },
                new CafeTable
                {
                    Id = 3,
                    TableNumber = 3,
                    Capacity = 6,
                    IsActive = true
                },
                new CafeTable
                {
                    Id = 4,
                    TableNumber = 4,
                    Capacity = 8,
                    IsActive = true
                }
            );


            builder.Entity<BoardGame>().HasData(
                new BoardGame
                {
                    Id = 1,
                    Title = "Catan",
                    CategoryId = 1,
                    MinPlayers = 3,
                    MaxPlayers = 4,
                    PlayTimeMinutes = 90,
                    TotalCopies = 3,
                    AvailableCopies = 3,
                    Description = "Adada kaynak toplayıp ticaret yaparak yerleşim yerleri inşa etme strateji oyunu.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/a/a3/Catan-2015-boxart.jpg"
                },
                new BoardGame
                {
                    Id = 2,
                    Title = "Codenames",
                    CategoryId = 2,
                    MinPlayers = 4,
                    MaxPlayers = 8,
                    PlayTimeMinutes = 20,
                    TotalCopies = 2,
                    AvailableCopies = 2,
                    Description = "İki casus liderinin kelime ipuçlarıyla takımlarına ajanlarını buldurma oyunu.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/7/77/Codenames_game_box.jpg"
                },
                new BoardGame
                {
                    Id = 3,
                    Title = "Cluedo",
                    CategoryId = 3,
                    MinPlayers = 2,
                    MaxPlayers = 6,
                    PlayTimeMinutes = 45,
                    TotalCopies = 2,
                    AvailableCopies = 2,
                    Description = "Malikanedeki cinayeti, faili, suç aletini ve odayı ilk tahmin eden dedektiflik oyunu.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/9/90/Cluedo_box_art.jpg"
                }
            );
        }


    }
}

