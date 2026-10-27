namespace Michelangelo_s_Board_Game_Cafe.Models
{
    public class BoardGame
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public string? WikiPageId { get; set; }

        public int MinPlayers { get; set; }
        public int MaxPlayers { get; set; }
        public int PlayTimeMinutes { get; set; }

        public int TotalCopies { get; set; }
        public int AvailableCopies { get; set; }


        public int CategoryId { get; set; }
        public Category? Category { get; set; }


        public ICollection<ReservationGame> ReservationGames { get; set; } = new List<ReservationGame>();
    }
}
