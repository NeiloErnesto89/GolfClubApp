using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GolfClubApp.Data;
using GolfClubApp.Models;

namespace GolfClubApp.Pages.Bookings
{
    public class IndexModel : PageModel
    {
        private readonly GolfClubApp.Data.MemberContext _context;

        public IndexModel(GolfClubApp.Data.MemberContext context)
        {
            _context = context;
        }

        public IList<Booking> Booking { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Booking != null)
            {
                Booking = await _context.Booking
                .Include(b => b.Member).ToListAsync();
            }
        }
    }
}
