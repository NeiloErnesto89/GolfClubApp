using System.ComponentModel.DataAnnotations;

namespace GolfClubApp.Models
{
    public class Member
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(20, ErrorMessage = "Name length can't be more than 20.")]
        public string? Name { get; set; }
        
        [EmailAddress]
        public string? Email { get; set; }
        public string? Sex { get; set; }
        
        [Range(0, 36)]
        public int Handicap { get; set; }

        public bool Booking { get; set; }
    }
}
