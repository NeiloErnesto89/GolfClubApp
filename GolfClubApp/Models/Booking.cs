using System.ComponentModel.DataAnnotations;

namespace GolfClubApp.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Time { get; set; }

        // Foreign key property
        public int MemberId { get; set; }
        public Member? Member { get; set; }
    }
}
