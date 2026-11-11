using Michelangelo_s_Board_Game_Cafe.Data;
using Michelangelo_s_Board_Game_Cafe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Michelangelo_s_Board_Game_Cafe.Pages
{
    public class OyunlarModel : PageModel
    {
        private readonly CafeDbContext _context;


        public OyunlarModel(CafeDbContext context)
        {
            _context = context;
        }


        public IList<BoardGame> BoardGames { get; set; } = new List<BoardGame>();
        public IList<Category> Categories { get; set; } = new List<Category>();



        [BindProperty(SupportsGet = true)]
        public string? Category { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Search { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Players { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Duration { get; set; }








        public async Task OnGetAsync()
        {
            Categories = await _context.Categories.AsNoTracking().ToListAsync();

            IQueryable<BoardGame> query = _context.BoardGames
            .Include(b => b.Category)
            .AsNoTracking();



            if (!string.IsNullOrWhiteSpace(Search))
            {
                var lowerSearch = Search.Trim().ToLower();

                query = query.Where(g => g.Title.ToLower().Contains(lowerSearch));
            }


            if (!string.IsNullOrWhiteSpace(Category))
            {
                var lowerCategory = Category.Trim().ToLower();
                query = query.Where(g => g.Category != null && g.Category.Name.ToLower() == lowerCategory);
            }


            if (!string.IsNullOrWhiteSpace(Players))
            {
                query = Players switch
                {
                    "1-2" => query.Where(g => g.MinPlayers <= 2 && g.MaxPlayers >= 1),
                    "3-4" => query.Where(g => g.MinPlayers <= 4 && g.MaxPlayers >= 3),
                    "5+" => query.Where(g => g.MaxPlayers >= 5),
                    _ => query
                };
            }


            if (!string.IsNullOrWhiteSpace(Duration))
            {
                query = Duration switch
                {
                    "kisa" => query.Where(g => g.PlayTimeMinutes <= 30),
                    "orta" => query.Where(g => g.PlayTimeMinutes > 30 && g.PlayTimeMinutes <= 60),
                    "uzun" => query.Where(g => g.PlayTimeMinutes > 60),
                    _ => query
                };
            }

            BoardGames = await query.ToListAsync();
        }
    }
}
