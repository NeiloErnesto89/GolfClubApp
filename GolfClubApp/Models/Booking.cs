using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GolfClubApp.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        [Required]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Tee Time")]
        //[Range(typeof(DateTime), "20/03/2023", "31/12/2023", ErrorMessage = "Date must be within 2023")]
        public DateTime Time { get; set; }

            
        // Foreign key property
        public int MemberId { get; set; }

        //[Range(1, 4, ErrorMessage = "The tee time booking must include between 1 and 4 members.")]
        public int NumMembers { get; set; }
        public Member? Member { get; set; }
    }
}
