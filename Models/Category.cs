namespace Michelangelo_s_Board_Game_Cafe.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

 
        public ICollection<BoardGame> BoardGames { get; set; } = new List<BoardGame>();
    }
}
