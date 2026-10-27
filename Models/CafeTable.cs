namespace Michelangelo_s_Board_Game_Cafe.Models
{
    public class CafeTable
    {
        public int Id { get; set; }
        public int TableNumber { get; set; }
        public int Capacity { get; set; }

        public bool IsActive { get; set; } = true;

        // Masaya ait rezervasyonlar (1-N)
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
