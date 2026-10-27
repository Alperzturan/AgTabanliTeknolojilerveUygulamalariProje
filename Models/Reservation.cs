namespace Michelangelo_s_Board_Game_Cafe.Models
{
    public enum ReservationStatus
    {
        Pending,  
        Approved,  
        Cancelled, 
        Completed  
    }

    public class Reservation
    {
        public int Id { get; set; }

        public string UserId { get; set; } = string.Empty;
        public AppUser? User { get; set; }

        public int CafeTableId { get; set; }
        public CafeTable? CafeTable { get; set; }

        public DateOnly ReservationDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public int GuestCount { get; set; }
        public ReservationStatus Status { get; set; } = ReservationStatus.Pending;
        public string? Notes { get; set; }
    
        public ICollection<ReservationGame> ReservationGames { get; set; } = new List<ReservationGame>();
    }
}
