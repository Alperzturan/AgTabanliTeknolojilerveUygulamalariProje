using Michelangelo_s_Board_Game_Cafe.Data;
using Michelangelo_s_Board_Game_Cafe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Michelangelo_s_Board_Game_Cafe.Pages
{
    public class OyunDetayModel : PageModel
    {
        private readonly CafeDbContext _context;
        public OyunDetayModel(CafeDbContext context)
        {
            _context = context;
        }


        public BoardGame? BoardGame { get; set; }

        public async Task<IActionResult> OnGetAsync(int id) {

            if (id == null)
            {
                return NotFound(); 
            }

            BoardGame = await _context.BoardGames
                 .Include(b => b.Category)
                 .AsNoTracking()
                 .FirstOrDefaultAsync(m => m.Id == id);


            if (BoardGame == null)
            {
                return NotFound(); 
            }

            return Page();
        }
    }
}
