using Microsoft.EntityFrameworkCore;
using Michelangelo_s_Board_Game_Cafe.Models;
namespace Michelangelo_s_Board_Game_Cafe.Data
{
    public class CafeDbContext : DbContext
    {

        public CafeDbContext(DbContextOptions<CafeDbContext> options)
            : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; } = default!;
        public DbSet<BoardGame> BoardGames { get; set; } = default!;
        public DbSet<CafeTable> CafeTables { get; set; } = default!;
        public DbSet<Reservation> Reservations { get; set; } = default!;
    }
}
