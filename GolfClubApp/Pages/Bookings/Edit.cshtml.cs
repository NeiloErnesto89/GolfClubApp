using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GolfClubApp.Data;
using GolfClubApp.Models;

namespace GolfClubApp.Pages.Bookings
{
    public class EditModel : PageModel
    {
        private readonly GolfClubApp.Data.MemberContext _context;

        public EditModel(GolfClubApp.Data.MemberContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Booking Booking { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Booking == null)
            {
                return NotFound();
            }

            var booking =  await _context.Booking.FirstOrDefaultAsync(m => m.Id == id);
            if (booking == null)
            {
                return NotFound();
            }
            Booking = booking;
           ViewData["MemberId"] = new SelectList(_context.Member, "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["MemberId"] = new SelectList(_context.Member, "Id", "Name"); //reset member ID
                return Page();
            }

            // Check if the member has an existing booking on the specified given date
            var existingBooking = await _context.Booking.FirstOrDefaultAsync(b => b.MemberId == Booking.MemberId && b.Time.Date == Booking.Time.Date);
            if (existingBooking != null)
            {
                ModelState.AddModelError(string.Empty, "This Member has a booking already on this date - try another date!");
                ViewData["MemberId"] = new SelectList(_context.Member, "Id", "Name"); //reset member ID
                return Page();
            }
            // end of test


            // test to ensure that only 4 players can book the same time (e.g john, joe, mary & sally (max) can play at 9.15am 

            var existingBookings = await _context.Booking.Where(b => b.Time.Date == Booking.Time.Date && b.Time.TimeOfDay == Booking.Time.TimeOfDay).ToListAsync();
            if (existingBookings.Count >= 4)
            {
                ModelState.AddModelError(string.Empty, "This time slot is already fully booked by 4 other members!");
                ViewData["MemberId"] = new SelectList(_context.Member, "Id", "Name"); //reset member ID
                return Page();
            }
            // end of test




            _context.Attach(Booking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingExists(Booking.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BookingExists(int id)
        {
          return (_context.Booking?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
