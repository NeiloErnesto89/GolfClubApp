using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GolfClubApp.Data;
using GolfClubApp.Models;

namespace GolfClubApp.Pages.Bookings
{
    public class CreateModel : PageModel
    {
        private readonly GolfClubApp.Data.MemberContext _context;

        public CreateModel(GolfClubApp.Data.MemberContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["MemberId"] = new SelectList(_context.Member, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Booking Booking { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Booking == null || Booking == null)
            {
                ViewData["MemberId"] = new SelectList(_context.Member, "Id", "Name"); //reset member ID
                return Page();
            }

            //if (_context.Booking)


            // Check if the member has already booked on the chosen date
            //var existingBooking = await _context.Booking.Where(b => b.MemberId == Booking.MemberId && b.Time == Booking.Time)
            // .FirstOrDefaultAsync();

            //if (existingBooking != null)
            //{
            //    ModelState.AddModelError(string.Empty, "The member has already booked on the chosen date.");
            //    return Page();
            //}

            _context.Booking.Add(Booking);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
