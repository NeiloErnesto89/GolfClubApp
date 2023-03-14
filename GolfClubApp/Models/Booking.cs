using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using GolfClubApp.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using GolfClubApp.Data;

namespace GolfClubApp.Models
{
    //: IValidatableObject
    public class Booking : IValidatableObject
    {
        //private object _dbContext;

        [Key]
        public int Id { get; set; }

        [Required, Display(Name = "Tee Time")]
        //[MemberTeeTimeValidation]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
        //[Display(Name = "Tee Time")]
        //[Range(typeof(DateTime), "20/03/2023", "31/12/2023", ErrorMessage = "Date must be within 2023")]

        public DateTime Time { get; set; }

        public int? MemberId { get; set; }

        //[Range(1, 4, ErrorMessage = "The tee time booking must include between 1 and 4 members.")]
        public int NumMembers { get; set; }
        // Foreign key property 
        [ForeignKey("MemberId")]
        public Member? Member { get; set; }

        // could use 'virtual' kw

        // empty interface for the time being
        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    throw new NotImplementedException();
        //}

        //private readonly BookingContext _context;

        //public Booking(BookingContext context)
        //{
        //    _context = context;
        //}

        // validation with valdation context
        // works but member ID context con is broken after validation so need to return 

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            List<ValidationResult> validationResults = new List<ValidationResult>();

            if (Time < DateTime.UtcNow)
            {
                //yield return new ValidationResult("You can't book a tee time in the past", new[] { "Time" });
                validationResults.Add(new ValidationResult("You can't book a tee time in the past", new[] { "Time" }));
            }
            if (Time.Minute % 15 != 0)
            {
                validationResults.Add(new ValidationResult("You must choose a time slot on 15 minute intervals e.g. 9.00am, 9.15am etc.", new[] { "Time" }));
            }


            // Check if a booking already exists with the same member on the same day
            //var existingBooking = validationContext.Bookings.FirstOrDefault(b => b.MemberId == MemberId && b.Time.Date == Time.Date);
            //if (existingBooking != null)
            //{
            //    validationResults.Add(new ValidationResult($"Member {existingBooking.Member.Name} already has a booking on {existingBooking.Time.Date.ToShortDateString()}", new[] { "Time" }));
            //}



            //if (_context.Booking.Any(b => b.MemberId == MemberId && b.Time.Date == Time.Date))
            //{
            //    validationResults.Add(new ValidationResult("This member has already booked a tee time on this date."));
            //}

            // Check if a member has already created a booking on this day
            //if (MemberId.HasValue)
            //{
            //    var existingBooking = validationContext.FirstOrDefault(b => b.MemberId == MemberId.Value && b.Time.Date == Time.Date);
            //    if (existingBooking != null)
            //    {
            //        validationResults.Add(new ValidationResult("This member has already booked a tee time on this day", new[] { "MemberId" }));
            //    }
            //}


            return validationResults;

            
        }

    }
}
