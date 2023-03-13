using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using GolfClubApp.DataAnnotations;

namespace GolfClubApp.Models
{
    //: IValidatableObject
    public class Booking : IValidatableObject
    {
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

            return validationResults;

            //    new[] { "Time" })

            //if (Time < DateTime.UtcNow)
            //{
            //    yield return new ValidationResult("You can't book a tee time in the past", new[] { "Time" });
            //    yield break;
            //}

            //if (Time.Minute % 15 != 0)
            //{
            //    yield return new ValidationResult("You must choose a time slot on 15 minute intervals e.g. 9.00am, 9.15am etc.", new[] { "Time" });
            //    yield break;
            //}



            // If all validation passes, return an empty result

            //yield return ValidationResult.Success;
            //}
        }
    }
}
