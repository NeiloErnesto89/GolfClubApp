using GolfClubApp.Models;
using System.ComponentModel.DataAnnotations;

namespace GolfClubApp.DataAnnotations
{
    public class SameDayMemberBookingValidation : ValidationAttribute
    {

        //public SameDayMemberBookingValidation() { }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            //var booking = (Booking)validationContext.ObjectInstance;
            //var member = (Member)validationContext.ObjectInstance;
            ////var releaseYear = ((DateTime)value!).Year;

            //if (booking.Member.Name == member.Name && booking.Time == booking.MemberId.)
            //{
            //    return new ValidationResult(GetErrorMessage());
            //}


            //var valueString = value != null ? value.ToString() : null;

            //if (string.IsNullOrWhiteSpace(valueString))
            //{
            //    // convert to string, no value, return success as required will handle
            //    return ValidationResult.Success;
            //}

            //// convert to datetime and check if valid
            //if (!DateTime.TryParse(valueString, out DateTime time))
            //{
            //    return new ValidationResult("Not a valid date format");
            //}

            // check if time is less than earliest allowed time (now)


            // return success
            return ValidationResult.Success;


        }
    }
}
