using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GolfClubApp.Data;
using GolfClubApp.Models;
using Microsoft.EntityFrameworkCore;

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

            //var booking = await _context.Booking.FirstOrDefaultAsync(m => m.Id == id);
            //if (booking == null)
            //{
            //    ModelState.AddModelError("Booking.Time", $"Member {existingBooking.Member.Name} already has a booking on {existingBooking.Time.Date:d}");
            //    ViewData["MemberId"] = new SelectList(_context.Member, "Id", "Name"); //reset member ID
            //                                                                          //    return Page();
            //}

            // Check if the member has an existing booking on the specified given date
            var existingBooking = await _context.Booking.FirstOrDefaultAsync(b => b.MemberId == Booking.MemberId && b.Time.Date == Booking.Time.Date);
            if (existingBooking != null)
            {
                ModelState.AddModelError(string.Empty, "Member has a booking already on this date.");
                //ModelState.AddModelError("Booking.Time", $"Member {existingBooking.Member.Name} already has a booking on {existing
                //Booking.Time.Date.ToShortDateString()}");
                ViewData["MemberId"] = new SelectList(_context.Member, "Id", "Name"); //reset member ID
                return Page();
            }
            // end of test


            // test to ensure that only 4 players can book the same time (e.g john, joe, mary & sally (max) can play at 9.15am 

            var existingBookings = await _context.Booking.Where(b => b.Time.Date == Booking.Time.Date && b.Time.TimeOfDay == Booking.Time.TimeOfDay).ToListAsync();
            if (existingBookings.Count >= 4)
            {
                ModelState.AddModelError(string.Empty, "This time slot is already fully booked by 4 members");
                ViewData["MemberId"] = new SelectList(_context.Member, "Id", "Name"); //reset member ID
                return Page();
            }
            // end of test

            _context.Booking.Add(Booking);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
