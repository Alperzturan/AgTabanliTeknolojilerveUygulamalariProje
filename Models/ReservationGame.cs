namespace Michelangelo_s_Board_Game_Cafe.Models
{
    public class ReservationGame
    {
        public int Id { get; set; }

        public int ReservationId { get; set; }
        public Reservation? Reservation { get; set; }

        public int BoardGameId { get; set; }
        public BoardGame? BoardGame { get; set; }

        public int Quantity { get; set; } = 1;
    }
}
