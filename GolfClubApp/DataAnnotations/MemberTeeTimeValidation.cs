﻿

using System.ComponentModel.DataAnnotations;
//using GolfClubApp.Models;

namespace GolfClubApp.DataAnnotations
{
    public class MemberTeeTimeValidation : ValidationAttribute
    {
        public const string EARLIEST_TEE_TIME = "you must a time now or in the future - not in the past!!";

        // earliest time
        private DateTime earliestTime = DateTime.UtcNow;

 

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            var valueString = value != null ? value.ToString() : null;

            if (string.IsNullOrWhiteSpace(valueString))
            {
                // convert to string, no value, return success as required will handle
                return ValidationResult.Success;
            }

            // convert to datetime and check if valid
            if (!DateTime.TryParse(valueString, out DateTime time))
            {
                return new ValidationResult("Not a valid date format");
            }

            // check if time is less than earliest allowed time (now)
            if (time < earliestTime )
            {
                return new ValidationResult(EARLIEST_TEE_TIME);
            }

            // return success
            return ValidationResult.Success;

            
        }
    }
}
